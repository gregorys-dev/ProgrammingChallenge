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

        [HttpGet]
        public async Task<SolutionDto> Get(GetSolutionQuery query, CancellationToken cancellationToken)
            => await Mediator.Send(query, cancellationToken);
        
        [HttpPost]
        public async Task<int> Post(SubmitSolutionCommand command, CancellationToken cancellationToken)
            => await Mediator.Send(command, cancellationToken);
    }
}