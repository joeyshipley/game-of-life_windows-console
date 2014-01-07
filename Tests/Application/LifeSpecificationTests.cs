using System.Collections.Generic;
using FluentAssertions;
using Kata.App;
using Kata.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLife.LifeSpecificationTests
{
    [TestClass]
    public class When_a_live_cell_has_less_than_two_live_neighbours
        : ClassicalTestBase<LifeSpecification>
    {
        bool _result;
        List<Cell> _neighbours;

        public override void Arrange() 
        {
            _neighbours = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateDead(0, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateDead(1, 0),
                Cell.CreateDead(1, 2),
                Cell.CreateDead(2, 0),
                Cell.CreateDead(2, 1),
                Cell.CreateDead(2, 2)
            };
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateLive(1, 1);
            _result = SUT.WillItLive(cellInQuestion, _neighbours);
        }

        [TestMethod]
        public void It_dies() 
        {
            _result.Should().BeFalse();
        }
    }

    [TestClass]
    public class When_a_live_cell_has_either_two_or_three_live_neighbours
        : ClassicalTestBase<LifeSpecification>
    {
        private bool _result;
        List<Cell> _neighbours;

        public override void Arrange() 
        {
            _neighbours = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateDead(0, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateLive(1, 0),
                Cell.CreateLive(1, 2),
                Cell.CreateDead(2, 0),
                Cell.CreateDead(2, 1),
                Cell.CreateDead(2, 2)
            };
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateLive(1, 1);
            _result = SUT.WillItLive(cellInQuestion, _neighbours);
        }

        [TestMethod]
        public void It_lives() 
        {
            _result.Should().BeTrue();
        }
    }

    [TestClass]
    public class When_a_live_cell_has_more_than_three_live_neighbours
        : ClassicalTestBase<LifeSpecification>
    {
        private bool _result;
        List<Cell> _neighbours;

        public override void Arrange() 
        {
            _neighbours = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateLive(1, 0),
                Cell.CreateLive(1, 2),
                Cell.CreateDead(2, 0),
                Cell.CreateLive(2, 1),
                Cell.CreateDead(2, 2)
            };
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateLive(1, 1);
            _result = SUT.WillItLive(cellInQuestion, _neighbours);
        }

        [TestMethod]
        public void It_dies()
        {
            _result.Should().BeFalse();
        }
    }

    [TestClass]
    public class When_a_dead_cell_has_exactly_three_live_neighbours
        : ClassicalTestBase<LifeSpecification>
    {
        private bool _result;
        List<Cell> _neighbours;

        public override void Arrange() 
        {
            _neighbours = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateLive(1, 0),
                Cell.CreateLive(1, 2),
                Cell.CreateDead(2, 0),
                Cell.CreateDead(2, 1),
                Cell.CreateDead(2, 2)
            };
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateDead(1, 1);
            _result = SUT.WillItLive(cellInQuestion, _neighbours);
        }

        [TestMethod]
        public void It_lives() 
        {
            _result.Should().BeTrue();
        }
    }
}