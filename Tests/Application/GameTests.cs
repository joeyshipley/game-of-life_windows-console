using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kata.App;
using Kata.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLife.GameTests
{
    [TestClass]
    public class When_getting_a_cells_neighbors_that_happen_to_be_alive
        : ClassicalTestBase<Game>
    {
        List<Cell> _result;
        List<Cell> _cells;

        public override void Arrange() 
        {
            _cells = new List<Cell>
            {
                Cell.CreateLive(0, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(0, 2),
                Cell.CreateLive(1, 0),
                Cell.CreateLive(1, 1),
                Cell.CreateLive(1, 2),
                Cell.CreateLive(2, 0),
                Cell.CreateLive(2, 1),
                Cell.CreateLive(2, 2)
            };
            SUT.Initialize(3, _cells);
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateLive(1, 1);
            _result = SUT.GetNeighbours(cellInQuestion);
        }

        [TestMethod]
        public void It_returns_NW_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_N_neighbour() 
        {
            _result.Any(c => c.X == 1 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returnsNE_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_W_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 1).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_E_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 1).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_SW_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 2).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_S_neighbour() 
        {
            _result.Any(c => c.X == 1 && c.Y == 2).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_SE_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 2).Should().BeTrue();
        }
    }

    [TestClass]
    public class When_getting_a_cells_neighbors_that_happen_to_be_dead
        : ClassicalTestBase<Game>
    {
        List<Cell> _result;
        List<Cell> _cells;

        public override void Arrange() 
        {
            _cells = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateDead(0, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateDead(1, 0),
                Cell.CreateDead(1, 1),
                Cell.CreateDead(1, 2),
                Cell.CreateDead(2, 0),
                Cell.CreateDead(2, 1),
                Cell.CreateDead(2, 2)
            };
            SUT.Initialize(3, _cells);
        }

        public override void Act() 
        {
            var cellInQuestion = Cell.CreateLive(1, 1);
            _result = SUT.GetNeighbours(cellInQuestion);
        }

        [TestMethod]
        public void It_returns_NW_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_N_neighbour() 
        {
            _result.Any(c => c.X == 1 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returnsNE_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 0).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_W_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 1).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_E_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 1).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_SW_neighbour() 
        {
            _result.Any(c => c.X == 0 && c.Y == 2).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_S_neighbour() 
        {
            _result.Any(c => c.X == 1 && c.Y == 2).Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_SE_neighbour() 
        {
            _result.Any(c => c.X == 2 && c.Y == 2).Should().BeTrue();
        }
    }

    [TestClass]
    public class When_the_game_performs_a_tick_from_simple_three_pattern_top_to_bottom
        : ClassicalTestBase<Game>
    {
        private List<Cell> _result;
        List<Cell> _cells;

        public override void Arrange() 
        {
            //    0 1 2 (x)
            //  0 - + - 
            //  1 - + -
            //  2 - + -
            // (y)
            _cells = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateLive(1, 0),
                Cell.CreateDead(2, 0),
                Cell.CreateDead(0, 1),
                Cell.CreateLive(1, 1),
                Cell.CreateDead(2, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateLive(1, 2),
                Cell.CreateDead(2, 2)
            };
            SUT.Initialize(3, _cells);
        }

        public override void Act() 
        {
            _result = SUT.Tick();
        }
        
        [TestMethod]
        public void It_returns_a_live_cell_for_1_1()
        {
            _result.First(c => c.X == 1 && c.Y == 1).IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_a_dead_cell_for_1_0()
        {
            _result.First(c => c.X == 1 && c.Y == 0).IsAlive.Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_a_dead_cell_for_1_2()
        {
            _result.First(c => c.X == 1 && c.Y == 2).IsAlive.Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_a_live_cell_for_0_1()
        {
            _result.First(c => c.X == 0 && c.Y == 1).IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_a_live_cell_for_2_1()
        {
            _result.First(c => c.X == 2 && c.Y == 1).IsAlive.Should().BeTrue();
        }
    }

    [TestClass]
    public class When_the_game_performs_a_tick_from_simple_three_pattern_left_to_right
        : ClassicalTestBase<Game>
    {
        private List<Cell> _result;
        List<Cell> _cells;

        public override void Arrange() 
        {
            //    0 1 2 (x)
            //  0 - - - 
            //  1 + + +
            //  2 - - -
            // (y)
            _cells = new List<Cell>
            {
                Cell.CreateDead(0, 0),
                Cell.CreateDead(1, 0),
                Cell.CreateDead(2, 0),
                Cell.CreateLive(0, 1),
                Cell.CreateLive(1, 1),
                Cell.CreateLive(2, 1),
                Cell.CreateDead(0, 2),
                Cell.CreateDead(1, 2),
                Cell.CreateDead(2, 2)
            };
            SUT.Initialize(3, _cells);
        }

        public override void Act() 
        {
            _result = SUT.Tick();
        }
        
        [TestMethod]
        public void It_returns_a_live_cell_for_1_1()
        {
            _result.First(c => c.X == 1 && c.Y == 1).IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_a_live_cell_for_1_0()
        {
            _result.First(c => c.X == 1 && c.Y == 0).IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_a_live_cell_for_1_2()
        {
            _result.First(c => c.X == 1 && c.Y == 2).IsAlive.Should().BeTrue();
        }

        [TestMethod]
        public void It_returns_a_false_cell_for_0_1()
        {
            _result.First(c => c.X == 0 && c.Y == 1).IsAlive.Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_a_false_cell_for_2_1()
        {
            _result.First(c => c.X == 2 && c.Y == 1).IsAlive.Should().BeFalse();
        }
    }
}