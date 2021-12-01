using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ProgrammingChallenge.Domain.Entities;

#nullable disable

namespace ProgrammingChallenge.Infrastructure.Persistence.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[]
                {
                    "Fibonacci algorithm",
                    "Write a program that takes a number N from keyboard " +
                    "and calculates Nth Fibonacci number",
                    "46" + Environment.NewLine,
                    "1836311903"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChallengeTasks",
                nameof(ChallengeTask.Name),
                "Fibonacci algorithm"
            );
        }
    }
}
