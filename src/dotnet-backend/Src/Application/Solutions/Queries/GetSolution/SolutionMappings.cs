using System.Linq;
using System.Text;
using AutoMapper;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.Solutions.Queries.GetSolution
{
    public class SolutionMappings : Profile
    {
        public SolutionMappings()
        {
            CreateMap<Solution, SolutionDto>();
            CreateMap<ExecutionInfo, ExecutionInfoDto>()
                .ForMember(dto => dto.Output, e => e.MapFrom(ei => CensorTestCase(ei)));
        }

        private string CensorTestCase(ExecutionInfo executionInfo)
        {
            var sb = new StringBuilder(executionInfo.Output);
            foreach (var testInput in executionInfo.Stdin.Where(s => !string.IsNullOrWhiteSpace(s)))
                sb.Replace(testInput, "*test input*");
            
            return sb.ToString();
        }
    }
}