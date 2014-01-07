using System.Collections.Generic;

namespace Kata.App
{
    public interface IGame
    {
        void Initialize(int boardSize, List<Cell> boardSeed);
        List<Cell> Tick();
    }
}