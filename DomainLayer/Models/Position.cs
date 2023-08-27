namespace HW2.Models
{
    /// <summary>
    /// It determines the position on the chessboard using the X and Y axes.
    /// </summary>
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; } 
        public int Y { get; set; }
    }
}
