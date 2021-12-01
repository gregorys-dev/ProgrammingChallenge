using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingChallenge.Domain.Entities;

namespace ProgrammingChallenge.Infrastructure.Persistence.Configurations
{
    public class ChallengeTaskConfiguration : IEntityTypeConfiguration<ChallengeTask>
    {
        public void Configure(EntityTypeBuilder<ChallengeTask> builder)
        {
            
        }
    }
}