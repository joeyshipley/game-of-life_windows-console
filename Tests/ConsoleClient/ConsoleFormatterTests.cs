using System.Collections.Generic;
using FluentAssertions;
using Kata.App;
using Kata.ConsoleClient.Engine;
using Kata.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLife.ConsoleFormatterTests
{
    [TestClass]
    public class When_formatting_a_live_cell
        : ClassicalTestBase<ConsoleFormatter>
    {
        private string _result;
        private List<Cell> _cells;

        public override void Arrange() 
        {
            SUT.Initialize(1);
            _cells = new List<Cell>
            {
                Cell.CreateLive(0, 0)
            };
        }

        public override void Act() 
        {
            _result = SUT.Display(_cells);
        }

        [TestMethod]
        public void It_returns_a_formatted_live_cell()
        {
            _result.Should().BeEquivalentTo("\r\n +");
        }
    }

    [TestClass]
    public class When_formatting_a_dead_cell
        : ClassicalTestBase<ConsoleFormatter>
    {
        private string _result;
        private List<Cell> _cells;

        public override void Arrange() 
        {
            SUT.Initialize(1);
            _cells = new List<Cell>
            {
                Cell.CreateDead(0, 0)
            };
        }

        public override void Act() 
        {
            _result = SUT.Display(_cells);
        }

        [TestMethod]
        public void It_returns_a_formatted_live_cell()
        {
            _result.Should().BeEquivalentTo("\r\n  ");
        }
    }

    [TestClass]
    public class When_formatting_cells_together
        : ClassicalTestBase<ConsoleFormatter>
    {
        private string _result;
        private List<Cell> _cells;

        public override void Arrange() 
        {
            SUT.Initialize(2);
            _cells = new List<Cell>
            {
                Cell.CreateLive(0, 0),
                Cell.CreateDead(0, 1),
                Cell.CreateDead(1, 0),
                Cell.CreateLive(1, 1)
            };
        }

        public override void Act() 
        {
            _result = SUT.Display(_cells);
        }

        [TestMethod]
        public void It_returns_a_formatted_live_cell()
        {
            _result.Should().BeEquivalentTo("\r\n +  \r\n   +");
        }
    }
}