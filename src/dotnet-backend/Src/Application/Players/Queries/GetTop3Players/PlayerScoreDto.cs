using System.Collections.Generic;
using System.Linq;

namespace ProgrammingChallenge.Application.Players.Queries.GetTop3Players
{
    public class PlayerScoreDto
    {
        public string PlayerName { get; set; }
        public int SuccessfulSubmissions { get; set; }
        public IEnumerable<int> SolvedTaskIds { get; set; } = Enumerable.Empty<int>();
    }
}