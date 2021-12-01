using Microsoft.Extensions.Configuration;
using ProgrammingChallenge.Application.Common.Interfaces;

namespace ProgrammingChallenge.WebApi
{
    public class ApplicationConfig : IApplicationConfig
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DbConnection => _configuration.GetValue<string>(nameof(DbConnection));
    }
}