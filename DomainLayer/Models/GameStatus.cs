using HW2.Enums;
using HW2.Models.Pieces;

namespace HW2.Models
{
    public class GameStatus
    {
        public ChessPiece[,] ChessBoard { get; set; }
        public int CurrentRound { get; set; }
        public Color CurrentPlayer { get; set; }
    }
}
