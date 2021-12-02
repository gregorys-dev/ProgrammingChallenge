using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Application.Common.Interfaces;

namespace ProgrammingChallenge.Application.ChallengeTasks.Queries.GetChallengeTaskList
{
    public class GetChallengeTaskListQueryHandler : 
        IRequestHandler<GetChallengeTaskListQuery, IEnumerable<ChallengeTaskDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetChallengeTaskListQueryHandler(
            IMapper mapper,
            IApplicationDbContext dbContext
        )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<ChallengeTaskDto>> Handle(GetChallengeTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.ChallengeTasks.ToListAsync(cancellationToken);
            var taskDtoList = _mapper.Map<IEnumerable<ChallengeTaskDto>>(tasks);
            return taskDtoList;
        }
    }
}