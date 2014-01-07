using System.Collections.Generic;
using System.Linq;

namespace Kata.App
{
    public class Game : IGame
    {
        private LifeSpecification _lifeSpecification;
        private int _boardSize;
        private List<Cell> _board;
  
        public void Initialize(int boardSize, List<Cell> boardSeed)
        {
            _lifeSpecification = new LifeSpecification();
            _boardSize = boardSize;
            _board = boardSeed;
        }

        public List<Cell> Tick()
        {
            var nextState = new List<Cell>();
            for(var x = 0; x < _boardSize; x++)
            {
                for(var y = 0; y < _boardSize; y++)
                {
                    var existingCell = getCellFromBoard(x, y);
                    var neighbours = GetNeighbours(existingCell);
                    var willLive = _lifeSpecification.WillItLive(existingCell, neighbours);
                    var newCell = willLive 
                        ? Cell.CreateLive(existingCell.X, existingCell.Y)
                        : Cell.CreateDead(existingCell.X, existingCell.Y);
                    nextState.Add(newCell);
                }
            }
            _board = nextState;
            return _board;
        }

        public List<Cell> GetNeighbours(Cell cell)
        {
            var northwestXY = new { Y = cell.Y - 1, X = cell.X - 1 };
            var northXY = new { Y = cell.Y - 1, X = cell.X };
            var northeastXY = new { Y = cell.Y - 1, X = cell.X + 1 };
            var westXY = new { Y = cell.Y, X = cell.X - 1 };
            var eastXY = new { Y = cell.Y, X = cell.X + 1 };
            var southwestXY = new { Y = cell.Y + 1, X = cell.X - 1 };
            var southXY = new { Y = cell.Y + 1, X = cell.X };
            var southeastXY = new { Y = cell.Y + 1, X = cell.X + 1 };

            var neighbours = new List<Cell>
            {
                getCellFromBoard(northwestXY.X, northwestXY.Y),
                getCellFromBoard(northXY.X, northXY.Y),
                getCellFromBoard(northeastXY.X, northeastXY.Y),
                getCellFromBoard(westXY.X, westXY.Y),
                getCellFromBoard(eastXY.X, eastXY.Y),
                getCellFromBoard(southwestXY.X, southwestXY.Y),
                getCellFromBoard(southXY.X, southXY.Y),
                getCellFromBoard(southeastXY.X, southeastXY.Y)
            };
            return neighbours;
        }

        private Cell getCellFromBoard(int x, int y)
        {
            return _board.FirstOrDefault(c => c.X == x && c.Y == y) 
                ?? Cell.CreateDead(x, y);
        }
    }
}