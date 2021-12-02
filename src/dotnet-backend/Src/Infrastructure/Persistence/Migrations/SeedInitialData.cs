using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using ProgrammingChallenge.Domain.Entities;

#nullable disable

namespace ProgrammingChallenge.Infrastructure.Persistence.Migrations
{
    public partial class SeedInitialData : Migration
    {
        private ChallengeTask[] _tasksToSeed = new ChallengeTask[]
        {
            new()
            {
                Name = "Fibonacci algorithm",
                Description = "Write a program that takes a number N from keyboard " +
                              "and prints computed Nth Fibonacci number",
                StdIn = "46" + Environment.NewLine,
                ExpectedStdOut = "1836311903"
            },
            new()
            {
                Name = "Print input",
                Description = "Write a program that prints input from keyboard",
                StdIn = "1234" + Environment.NewLine,
                ExpectedStdOut = "1234"
            }
        };

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var task in _tasksToSeed)
            {
                migrationBuilder.InsertData(
                    table: "ChallengeTasks",
                    columns: new[]
                    {
                        nameof(ChallengeTask.Name),
                        nameof(ChallengeTask.Description),
                        nameof(ChallengeTask.StdIn),
                        nameof(ChallengeTask.ExpectedStdOut),
                    },
                    values: new []
                    {
                        task.Name,
                        task.Description,
                        task.StdIn,
                        task.ExpectedStdOut
                    });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChallengeTasks",
                nameof(ChallengeTask.Name),
                _tasksToSeed.Select(t => t.Name).ToArray()
            );
        }
    }
}
