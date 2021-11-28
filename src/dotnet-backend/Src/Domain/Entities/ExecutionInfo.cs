using System.Collections.Generic;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Domain.Entities
{
    public class ExecutionInfo
    {
        public int Id { get; set; }
        
        public string Script { get; set; }
        public IEnumerable<string> Stdin { get; set; }
        public Language Language { get; set; }
        public string Output { get; set; }
        public string UsedMemory { get; set; }
        public string CpuTime { get; set; }
    }
}