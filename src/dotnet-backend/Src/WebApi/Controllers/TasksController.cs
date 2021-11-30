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
    public class TasksController : ApiController
    {
        public TasksController(IMediator mediator) : base(mediator) {}

        /// <summary>
        /// Get list of tasks to solve
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ChallengeTaskDto>> Get(CancellationToken cancellationToken)
            => await Mediator.Send(new GetChallengeTaskListQuery(), cancellationToken);
    }
}
