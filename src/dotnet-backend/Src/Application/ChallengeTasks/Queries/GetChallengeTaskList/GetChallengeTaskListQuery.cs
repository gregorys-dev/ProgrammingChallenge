using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProgrammingChallenge.Application.ChallengeTasks.Queries.GetChallengeTaskList
{
    public record GetChallengeTaskListQuery : IRequest<IEnumerable<ChallengeTaskDto>>;
}