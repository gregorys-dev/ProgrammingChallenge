using System.Collections.Generic;

namespace ProgrammingChallenge.Domain.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Solution> Solutions { get; set; } = new List<Solution>();
    }
}