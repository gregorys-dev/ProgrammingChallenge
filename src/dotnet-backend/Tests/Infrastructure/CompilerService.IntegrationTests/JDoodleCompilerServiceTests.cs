using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ProgrammingChallenge.Domain.Entities;
using ProgrammingChallenge.Domain.Enums;
using ProgrammingChallenge.Infrastructure.Services.CompilerService;

namespace ProgrammingChallenge.CompilerService.IntegrationTests
{
    [TestFixture, Explicit("Since it's using real API with limited daily plan")]
    public class JDoodleCompilerServiceTests
    {
        private JDoodleCompilerService _service;

        [SetUp]
        public void Setup()
        {
            _service = new JDoodleCompilerService(new JDoodleConfig());
        }

        [Test]
        public async Task SuccessfulResponseParsedProperly()
        {
            var executionDetails = new ExecutionInfo()
            {
                Language = Language.Python3,
                Script = "print(int(input()) + int(input()))",
                Stdin = new [] {"123", "456"}
            };

            await _service.ExecuteScriptAsync(executionDetails, CancellationToken.None);
            executionDetails.Output.Should().BeEquivalentTo((123 + 456).ToString());
        }
        
        [Test]
        public async Task FailureParsedProperly()
        {
            var executionDetails = new ExecutionInfo()
            {
                Language = Language.Python3,
                Script = Guid.NewGuid().ToString(),
                Stdin = new [] {"123", "456"}
            };

            await _service.ExecuteScriptAsync(executionDetails, CancellationToken.None);
            executionDetails.Output.Should().Contain("Error");
        }
    }
}