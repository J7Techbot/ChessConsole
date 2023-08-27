using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.KNIGHT;
        }

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out InvalidStatus invalidStatus)
        {
            invalidStatus = null;
            return false;
        }
    }
}
