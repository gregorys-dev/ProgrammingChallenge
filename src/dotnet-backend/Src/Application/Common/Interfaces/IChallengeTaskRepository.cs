using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ChallengeTask> ChallengeTasks { get; }
        DbSet<Participant> Participants { get; }
        DbSet<Solution> Solutions { get; }
        DbSet<ExecutionInfo> ExecutionInfos { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}