namespace Kata.App
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
        
        public static Cell CreateLive(int x, int y)
        {
            return new Cell
            {
                X = x,
                Y = y,
                IsAlive = true
            };
        }

        public static Cell CreateDead(int x, int y)
        {
            return new Cell
            {
                X = x,
                Y = y,
                IsAlive = false
            };
        }
    }
}