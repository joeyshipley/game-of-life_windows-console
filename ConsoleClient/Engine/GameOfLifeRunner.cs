using System;
using System.Collections.Generic;
using System.Linq;
using Kata.App;

namespace Kata.ConsoleClient.Engine
{
    public class GameOfLifeRunner
    {
        private const int BOARD_SIZE = 25;
        private readonly IConsoleFormatter _formatter;
        private readonly IGame _game;

        public GameOfLifeRunner(IGame game, IConsoleFormatter formatter)
        {
            _game = game;
            _formatter = formatter;

            var seed = generateRandomBoard();
            _game.Initialize(BOARD_SIZE, seed);
            _formatter.Initialize(BOARD_SIZE);
        }

        public string PerformCycleOfLife()
        {
            var cellState = _game.Tick();
            var display = _formatter.Display(cellState);
            return display;
        }
        
        private static List<Cell> generateRandomBoard()
        {
            const int TO_GENERATE = BOARD_SIZE * BOARD_SIZE / 2;
            var board = new List<Cell>();
            for(var i = 0; i < TO_GENERATE; i++)
                board.Add(generateRandomUnique(board));
            return board;
        }

        private static Cell generateRandomUnique(List<Cell> existing)
        {
            const int MAX = BOARD_SIZE * BOARD_SIZE;
            var count = 0;
            var random = new Random();
            var randomX = -1;
            var randomY = -1;
            while(count < MAX 
                && (
                    randomX == -1 
                    || existing.Any(c => c.X == randomX && c.Y == randomY)
                )
            )
            {
                randomX = random.Next(BOARD_SIZE) + 1;
                randomY = random.Next(BOARD_SIZE) + 1;
                count += 1;
            }
            return Cell.CreateLive(randomX, randomY);
        }
    }
}