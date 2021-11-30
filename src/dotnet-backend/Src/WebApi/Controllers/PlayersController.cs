using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution;

namespace ProgrammingChallenge.WebApi.Controllers
{
    [ApiController]
    public class PlayersController : AppController
    {
        public PlayersController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<int> Get(SubmitSolutionCommand query, CancellationToken cancellationToken)
            => await Mediator.Send(query, cancellationToken);
        
        [HttpGet]
        public async Task<int> GetTop3BySuccessfulSubmissions(SubmitSolutionCommand query, CancellationToken cancellationToken)
            => await Mediator.Send(query, cancellationToken);
    }
}