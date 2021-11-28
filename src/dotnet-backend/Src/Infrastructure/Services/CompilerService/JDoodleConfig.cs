using System.Collections.Generic;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Infrastructure.Services.CompilerService
{
    public class JDoodleConfig
    {
        // todo move values to appconfig.json
        public string ClientSecret = "c66ba145160508e060c6c0a64e16f3db8d6910fca4f79d93507c343418b2236e";
        public string ClientId = "d2fb204d3fbbd7e4f27f6064539c0361";
        public string Address = "https://api.jdoodle.com/v1/execute";

        public Dictionary<Language, (string language, int version)> LanguageMap = new()
        {
            { Language.Csharp, ("csharp", 3) },
            { Language.Python3, ("python3", 3) }
        };
    }
}