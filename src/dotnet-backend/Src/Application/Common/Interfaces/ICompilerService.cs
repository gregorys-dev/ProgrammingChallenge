using System.Threading;
using System.Threading.Tasks;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.Common.Interfaces
{
    public interface ICompilerService
    {
        Task ExecuteScriptAsync(ExecutionInfo info, CancellationToken cancellationToken);
    }

    public interface IApplicationConfig
    {
        string DbConnection { get; }
    } 
}