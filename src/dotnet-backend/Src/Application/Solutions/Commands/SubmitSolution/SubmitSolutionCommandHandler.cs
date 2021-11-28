﻿using System;
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
            var participant = await GetOrCreateParticipantAsync(request.ParticipantName, cancellationToken);

            var language = Enum.Parse<Language>(request.Language, true);
            
            var executionInfo = new ExecutionInfo
            {
                Language = language,
                Script = request.SolutionCode
            };
            
            var solution = new Solution()
            {
                Participant = participant,
                ChallengeTaskId = request.ChallengeTaskId,
                ExecutionInfo = executionInfo,
            };

            _dbContext.Solutions.Add(solution);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await _compilerService.ExecuteScriptAsync(executionInfo, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return solution.Id;
        }

        private async Task<Participant> GetOrCreateParticipantAsync(string name, CancellationToken cancellationToken)
        {
            var existingParticipant = await _dbContext.Participants.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
            if (existingParticipant is not null)
                return existingParticipant;

            var newParticipant = new Participant{Name = name};
            _dbContext.Participants.Add(newParticipant);
            return newParticipant;
        }
    }
}