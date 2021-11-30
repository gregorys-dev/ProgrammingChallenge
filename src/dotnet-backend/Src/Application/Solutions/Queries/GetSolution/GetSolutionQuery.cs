using System.Collections.Generic;
using MediatR;

namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public record GetSolutionQuery(int Id) : IRequest<SolutionDto>;
}