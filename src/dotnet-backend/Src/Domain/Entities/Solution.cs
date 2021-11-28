namespace ProgrammingChallenge.Domain.Entities
{
    public class Solution
    {
        public int Id { get; set; }
        
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public int ChallengeTaskId { get; set; }
        public ChallengeTask ChallengeTask { get; set; }
        
        public int ExecutionInfoId { get; set; }
        public ExecutionInfo ExecutionInfo { get; set; }
        public bool IsPassed { get; set; }
    }
}