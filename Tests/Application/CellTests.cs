using FluentAssertions;
using Kata.App;
using Kata.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLife.CellTests
{
    [TestClass]
    public class When_creating_a_live_cell
        : ClassicalTestBase<Cell>
    {
        private Cell _result;
        
        public override void Arrange() {}

        public override void Act() 
        {
            _result = Cell.CreateLive(1, 2);
        }

        [TestMethod]
        public void It_sets_the_X_value()
        {
            _result.X.Should().Be(1);
        }

        [TestMethod]
        public void It_sets_the_Y_value()
        {
            _result.Y.Should().Be(2);
        }

        [TestMethod]
        public void It_is_alive()
        {
            _result.IsAlive.Should().BeTrue();
        }
    }    
    
    [TestClass]
    public class When_creating_a_dead_cell
        : ClassicalTestBase<Cell>
    {
        private Cell _result;
        
        public override void Arrange() {}

        public override void Act() 
        {
            _result = Cell.CreateDead(1, 2);
        }

        [TestMethod]
        public void It_sets_the_X_value()
        {
            _result.X.Should().Be(1);
        }

        [TestMethod]
        public void It_sets_the_Y_value()
        {
            _result.Y.Should().Be(2);
        }

        [TestMethod]
        public void It_is_dead()
        {
            _result.IsAlive.Should().BeFalse();
        }
    }
}