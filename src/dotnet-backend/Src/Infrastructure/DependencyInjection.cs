using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ProgrammingChallenge.Application.Common.Interfaces;
using ProgrammingChallenge.Infrastructure.Persistence;
using ProgrammingChallenge.Infrastructure.Services.CompilerService;

namespace ProgrammingChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IApplicationConfig config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(config.DbConnection, SetMigrationsAssembly));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ICompilerService, JDoodleCompilerService>();
            services.AddScoped<JDoodleConfig>();
            
            return services;
        }

        private static void SetMigrationsAssembly(SqlServerDbContextOptionsBuilder b) 
            => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
    }
}