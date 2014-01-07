using System.Collections.Generic;
using System.Linq;

namespace Kata.App
{
    public class LifeSpecification
    {
        public bool WillItLive(Cell cell, List<Cell> neighbours)
        {
            var liveNeighbours = neighbours.Count(c => c.IsAlive);

            if(cell.IsAlive && liveNeighbours < 2)
                return false;

            if(cell.IsAlive && liveNeighbours > 3)
                return false;

            if(cell.IsAlive && (liveNeighbours == 2 || liveNeighbours == 3))
                return true;

            if(!cell.IsAlive && liveNeighbours == 3)
                return true;

            return false;
        }
    }
}