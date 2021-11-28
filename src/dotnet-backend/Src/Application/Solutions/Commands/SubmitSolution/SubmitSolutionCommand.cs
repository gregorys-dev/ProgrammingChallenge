using MediatR;

namespace ProgrammingChallenge.Application.Solutions.Commands.SubmitSolution
{
    public record SubmitSolutionCommand(
        string ParticipantName,
        int ChallengeTaskId,
        string SolutionCode,
        string Language
    ) : IRequest<int>;
}