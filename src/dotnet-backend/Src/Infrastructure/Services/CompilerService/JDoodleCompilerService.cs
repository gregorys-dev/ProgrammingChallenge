using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProgrammingChallenge.Application.Common.Exceptions;
using ProgrammingChallenge.Application.Common.Interfaces;
using ProgrammingChallenge.Domain.Entities;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Infrastructure.Services.CompilerService
{
    ///<inheritdoc/>
    public class JDoodleCompilerService : ICompilerService
    {
        private readonly JDoodleConfig _config;

        public JDoodleCompilerService(JDoodleConfig config) => _config = config;

        ///<inheritdoc/>
        public async Task ExecuteScriptAsync(ExecutionInfo info, CancellationToken cancellationToken)
        {
            var (language, version) = GetLanguageParams(info.Language);

            var jDoodleRequest = new JDoodleRequest
            {
                ClientId = _config.ClientId,
                ClientSecret = _config.ClientSecret,
                VersionIndex = version.ToString(),
                Language = language,
                Script = info.Script,
                Stdin = string.Join(Environment.NewLine, info.Stdin),
            };
            var jDoodleResponse = await PostRequest(jDoodleRequest);
            
            info.UsedMemory = jDoodleResponse.Memory;
            info.Output = jDoodleResponse.Output.Trim();
            info.CpuTime = jDoodleResponse.CpuTime;
        }

        private (string language, int version) GetLanguageParams(Language language)
        {
            if (_config.LanguageMap.TryGetValue(language, out var languageParams))
                return languageParams;
            
            return (language.ToString().ToLower(), 0);
        }

        private async Task<JDoodleResponse> PostRequest(JDoodleRequest requestBody)
        {
            var json = RequestToJson(requestBody);
            var responseBody = await PostJsonRequest(json);
            var response = ParseResponse(responseBody);
            return response;
        }

        private async Task<string> PostJsonRequest(string json)
        {
            using var api = new HttpClient();
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await api.PostAsync(_config.Address, content);
            
            if (responseMessage.StatusCode != HttpStatusCode.OK) 
                throw new CompilerServiceFailureException();
            
            return await responseMessage.Content.ReadAsStringAsync();
        }

        private static JDoodleResponse ParseResponse(string responseBody) 
            => JsonConvert.DeserializeObject<JDoodleResponse>(responseBody);

        private static string RequestToJson(JDoodleRequest requestBody) 
            => JsonConvert.SerializeObject(
                requestBody, 
                Formatting.None, 
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );

    }
}