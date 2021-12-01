using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProgrammingChallenge.Domain.Entities;
using ProgrammingChallenge.Domain.Enums;

namespace ProgrammingChallenge.Infrastructure.Persistence.Configurations
{
    public class ExecutionInfoConfiguration : IEntityTypeConfiguration<ExecutionInfo>
    {
        public void Configure(EntityTypeBuilder<ExecutionInfo> builder)
        {
            builder
                .Property(e => e.Language)
                .HasConversion(
                    v => v.ToString(),
                    v => (Language)Enum.Parse(typeof(Language), v)
                );
            
            var enumerableComparer = new ValueComparer<IEnumerable<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
            
            builder
                .Property(e => e.Stdin)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<IEnumerable<string>>(v),
                    enumerableComparer
                );
        }
    }
}