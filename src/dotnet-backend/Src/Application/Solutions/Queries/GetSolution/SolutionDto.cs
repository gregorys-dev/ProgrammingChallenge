namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public class SolutionDto
    {
        public int Id { get; set; }
        
        public int ParticipantId { get; set; }
        public int ChallengeTaskId { get; set; }
        
        public int ExecutionInfoId { get; set; }
        public ExecutionInfoDto ExecutionInfo { get; set; }
        public bool IsPassed { get; set; }
    }
}