using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution;

namespace ProgrammingChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolutionsController : AppController
    {
        public SolutionsController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<int> Post(SubmitSolutionCommand command, CancellationToken cancellationToken)
            => await Mediator.Send(command, cancellationToken);
    }
}