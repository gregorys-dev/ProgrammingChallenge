using AutoMapper;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.ChallengeTasks.Queries.GetChallengeTaskList
{
    public class ChallengeTaskMappings : Profile
    {
        public ChallengeTaskMappings()
        {
            CreateMap<ChallengeTask, ChallengeTaskDto>();
        }
    }
}