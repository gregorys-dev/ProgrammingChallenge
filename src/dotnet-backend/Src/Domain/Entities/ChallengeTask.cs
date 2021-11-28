using System.Collections.Generic;

namespace ProgrammingChallenge.Domain.Entities
{
    public class ChallengeTask
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string StdIn { get; set; }
        public string ExpectedStdOut { get; set; }

        public ICollection<Solution> Solutions { get; set; } = new List<Solution>();
    }
}