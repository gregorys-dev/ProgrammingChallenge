using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Application.Common.Interfaces;

namespace ProgrammingChallenge.Application.Players.Queries.GetTop3Players
{
    public class GetTop3PlayersQueryHandler : IRequestHandler<GetTop3PlayersQuery, IEnumerable<PlayerScoreDto>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTop3PlayersQueryHandler(
            IApplicationDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PlayerScoreDto>> Handle(GetTop3PlayersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Solutions
                .Where(s => s.IsPassed)
                .GroupBy(s => s.PlayerId)
                .Select(grouping => new PlayerScoreDto
                {
                    PlayerName = grouping.First().Player.Name,
                    SuccessfulSubmissions = grouping.Count(),
                    SolvedTaskIds = grouping.Select(s => s.ChallengeTask.Id).Distinct()
                })
                .OrderByDescending(dto => dto.SuccessfulSubmissions)
                .Take(3)
                .ToListAsync(cancellationToken);
        }
    }
}