using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution;
using ProgrammingChallenge.Application.Solutions.Queries.GetSolution;

namespace ProgrammingChallenge.WebApi.Controllers
{
    public class SolutionsController : ApiController
    {
        public SolutionsController(IMediator mediator) : base(mediator) {}

        [HttpGet("{id}")]
        public async Task<SolutionDto> Get(int id, CancellationToken cancellationToken)
            => await Mediator.Send(new GetSolutionQuery(id), cancellationToken);
        
        [HttpPost]
        public async Task<int> Post(SubmitSolutionCommand command, CancellationToken cancellationToken)
            => await Mediator.Send(command, cancellationToken);
    }
}