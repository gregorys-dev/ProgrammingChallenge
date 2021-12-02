using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingChallenge.Application.Players.Queries.GetTop3Players;
using ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution;

namespace ProgrammingChallenge.WebApi.Controllers
{
    public class PlayersController : ApiController
    {
        public PlayersController(IMediator mediator) : base(mediator) {}

        [HttpGet("get-top-3")]
        public async Task<IEnumerable<PlayerScoreDto>> GetTop3BySuccessfulSubmissions(CancellationToken cancellationToken)
            => await Mediator.Send(new GetTop3PlayersQuery(), cancellationToken);
    }
}