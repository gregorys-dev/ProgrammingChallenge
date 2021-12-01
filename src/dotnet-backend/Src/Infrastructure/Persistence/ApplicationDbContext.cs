using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProgrammingChallenge.Application.Common.Interfaces;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ChallengeTask> ChallengeTasks => Set<ChallengeTask>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Solution> Solutions => Set<Solution>();
        public DbSet<ExecutionInfo> ExecutionInfos => Set<ExecutionInfo>();
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}