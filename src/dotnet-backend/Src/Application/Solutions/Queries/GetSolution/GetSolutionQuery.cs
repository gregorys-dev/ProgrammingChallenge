using System.Collections.Generic;
using MediatR;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public record GetSolutionQuery(int Id) : IRequest<SolutionDto>;

    public class GetSolutionQueryHandler : IRequestHandler<GetSolutionQuery, SolutionDto>
    {
        
    } 
}