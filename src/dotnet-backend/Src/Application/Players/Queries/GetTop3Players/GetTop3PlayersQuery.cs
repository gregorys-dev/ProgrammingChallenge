using System.Collections.Generic;
using MediatR;

namespace ProgrammingChallenge.Application.Players.Queries.GetTop3Players
{
    public record GetTop3PlayersQuery : IRequest<IEnumerable<PlayerScoreDto>>;
}