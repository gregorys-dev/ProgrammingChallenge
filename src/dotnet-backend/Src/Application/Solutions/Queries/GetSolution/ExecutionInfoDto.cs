namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public class ExecutionInfoDto
    {
        public int Id { get; set; }
        
        public string Script { get; set; }
        public string Language { get; set; }
        public string UsedMemory { get; set; }
        public string CpuTime { get; set; }
    }
}