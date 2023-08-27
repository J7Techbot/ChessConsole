using HW2.Enums;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    public class Queen : ChessPiece
    {
        public Queen(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.QUEEN;
        }

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out InvalidStatus invalidStatus)
        {
            if (MoveHelper.VerticalHorizontal(currentPosition, targetPosition, chessBoard, out invalidStatus))
            {
                if (invalidStatus != null)
                {
                    return false;
                }
            }
            else if (MoveHelper.Diagonal(currentPosition, targetPosition, chessBoard, out invalidStatus))
            {
                if (invalidStatus != null)
                {
                    return false;
                }
            }
            else
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.INVALID_MOVE);
                return false;
            }

            if (!IsValidTarget(targetPosition, chessBoard, out invalidStatus))
                return false;

            return true;
        }
    }
}
