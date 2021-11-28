using System.Collections.Generic;
using MediatR;

namespace ProgrammingChallenge.Application.Participants.Queries.GetTop3Participants
{
    public record GetTop3ParticipantsQuery : IRequest<IEnumerable<ParticipantScoreDto>>;
}