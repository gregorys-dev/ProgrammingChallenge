namespace ProgrammingChallenge.Infrastructure.Services.CompilerService
{
    /// <summary>
    /// Request Parameters according to the documentation
    /// https://docs.jdoodle.com/compiler-api/compiler-api#what-are-the-input-parameters-for-execute-api-call
    /// </summary>
    public class JDoodleRequest
    {
        /// <summary>
        /// Client ID for your subscription
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret for your subscription
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// program to compile and execute
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// StdIn
        /// </summary>
        public string Stdin { get; set; }

        /// <summary>
        /// language of the script (refer the supported language list below)
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// version of the language to be used (refere the supportoed languages and versions in list below)
        /// </summary>
        public string VersionIndex { get; set; }
    }
}