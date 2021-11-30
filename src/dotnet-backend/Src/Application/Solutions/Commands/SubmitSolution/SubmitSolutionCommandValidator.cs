using System;
using FluentValidation;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution
{
    public class SubmitSolutionCommandValidator : AbstractValidator<SubmitSolutionCommand>
    {
        public SubmitSolutionCommandValidator()
        {
            RuleFor(v => v.PlayerName).NotEmpty();
            RuleFor(v => v.SolutionCode).NotEmpty();
            RuleFor(v => v.ChallengeTaskId).GreaterThan(0);
            RuleFor(v => v.Language).Must(BeConvertibleToLanguageEnum);
        }

        private static bool BeConvertibleToLanguageEnum(string lang) 
            => Enum.TryParse(typeof(Language), lang, true, out _);
    }
}