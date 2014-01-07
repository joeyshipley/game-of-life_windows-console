using System;
using System.Collections.Generic;
using System.Linq;
using Kata.App;

namespace Kata.ConsoleClient.Engine
{
    public class ConsoleFormatter : IConsoleFormatter
    {
        public int _boardSize;

        public void Initialize(int boardSize)
        {
            _boardSize = boardSize;
        }

        public string Display(List<Cell> cells)
        {
            var display = "";

            for(var x = 0; x < _boardSize; x++)
            {
                display += startRow();
                for(var y = 0; y < _boardSize; y++)
                {
                    var cell = cells.First(c => c.X == x && c.Y == y);
                    display += formatColumn(cell);
                }
            }
            return display;
        }

        private string startRow()
        {
            return Environment.NewLine;
        }

        private string formatColumn(Cell cell)
        {
            return string.Format(" {0}", cell.IsAlive ? "+" : " ");;
        }
    }
}