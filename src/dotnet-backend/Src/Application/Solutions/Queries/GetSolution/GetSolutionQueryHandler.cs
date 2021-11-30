using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Application.Common.Exceptions;
using ProgrammingChallenge.Application.Common.Interfaces;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public class GetSolutionQueryHandler : IRequestHandler<GetSolutionQuery, SolutionDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetSolutionQueryHandler(
            IMapper mapper,
            IApplicationDbContext dbContext
        )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<SolutionDto> Handle(GetSolutionQuery request, CancellationToken cancellationToken)
        {
            var solution = await _dbContext.Solutions.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken) 
                           ?? throw new NotFoundException<Solution>(request.Id);

            return _mapper.Map<SolutionDto>(solution);
        }
    }
}