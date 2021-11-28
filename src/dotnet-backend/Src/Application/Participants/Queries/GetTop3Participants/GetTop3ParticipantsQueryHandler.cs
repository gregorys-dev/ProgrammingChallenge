using System.Collections.Generic;
using MediatR;

namespace ProgrammingChallenge.Application.Participants.Queries.GetTop3Participants
{
    public class GetTop3ParticipantsQueryHandler : IRequestHandler<GetTop3ParticipantsQuery, IEnumerable<ParticipantScoreDto>>
    {
        
    }
}