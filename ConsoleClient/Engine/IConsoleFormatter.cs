using System.Collections.Generic;
using Kata.App;

namespace Kata.ConsoleClient.Engine
{
    public interface IConsoleFormatter
    {
        void Initialize(int boardSize);
        string Display(List<Cell> cells);
    }
}