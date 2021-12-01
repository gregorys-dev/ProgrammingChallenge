using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Application.Common.Interfaces;
using ProgrammingChallenge.Domain.Entities;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution
{
    public class SubmitSolutionCommandHandler : IRequestHandler<SubmitSolutionCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICompilerService _compilerService;

        public SubmitSolutionCommandHandler(
            IApplicationDbContext dbContext,
            ICompilerService compilerService
        )
        {
            _dbContext = dbContext;
            _compilerService = compilerService;
        }
        
        public async Task<int> Handle(SubmitSolutionCommand request, CancellationToken cancellationToken)
        {
            var player = await GetOrCreatePlayerAsync(request.PlayerName, cancellationToken);

            var language = Enum.Parse<Language>(request.Language, true);

            var task = await _dbContext.ChallengeTasks
                .FirstAsync(t => t.Id == request.ChallengeTaskId, cancellationToken);
            
            var executionInfo = new ExecutionInfo
            {
                Language = language,
                Script = request.SolutionCode,
                Stdin = task.StdIn.Split(Environment.NewLine)
            };
            
            var solution = new Solution
            {
                Player = player,
                ChallengeTaskId = request.ChallengeTaskId,
                ExecutionInfo = executionInfo,
            };

            _dbContext.Solutions.Add(solution);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await _compilerService.ExecuteScriptAsync(executionInfo, cancellationToken);

            solution.IsPassed = task.ExpectedStdOut.Trim() == executionInfo.Output.Trim();
            
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return solution.Id;
        }

        private async Task<Player> GetOrCreatePlayerAsync(string name, CancellationToken cancellationToken)
        {
            var existingPlayer = await _dbContext.Players.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
            if (existingPlayer is not null)
                return existingPlayer;

            var newPlayer = new Player{Name = name};
            _dbContext.Players.Add(newPlayer);
            return newPlayer;
        }
    }
}