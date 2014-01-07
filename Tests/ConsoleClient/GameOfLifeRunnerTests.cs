using System.Collections.Generic;
using FluentAssertions;
using Kata.App;
using Kata.ConsoleClient.Engine;
using Kata.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLife.GameOfLifeRunnerTests
{
    [TestClass]
    public class When_performing_a_game_cycle
        : MockistTestBase<GameOfLifeRunner>
    {
        private string _result;

        public override void Arrange()
        {
            var state = new List<Cell> { new Cell() };
            Mocks.GetMock<IGame>()
                .Setup(m => m.Tick())
                .Returns(state);
            Mocks.GetMock<IConsoleFormatter>()
                .Setup(m => m.Display(state))
                .Returns("Correct Game Format");
        }

        public override void Act()
        {
            _result = SUT.PerformCycleOfLife();
        }

        [TestMethod]
        public void It_barks_correctly_to_perform_the_cycle()
        {
            _result.Should().BeEquivalentTo("Correct Game Format");
        }
    }
}