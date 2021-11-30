using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgrammingChallenge.Application.ChallengeTasks.Queries.GetChallengeTaskList;

namespace ProgrammingChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : AppController
    {
        public TasksController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<IEnumerable<ChallengeTaskDto>> Get(CancellationToken cancellationToken)
            => await Mediator.Send(new GetChallengeTaskListQuery(), cancellationToken);
    }
}
