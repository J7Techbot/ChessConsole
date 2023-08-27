using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    public class Rook : ChessPiece
    {
        public Rook(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.ROOK;
        }

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification invalidStatus)
        {
            if (MoveHelper.VerticalHorizontal(currentPosition, targetPosition, chessBoard, out invalidStatus))
            {
                if (invalidStatus != null)
                {
                    return false;
                }
            }           
            else
            {
                invalidStatus = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }

            if (!IsValidTarget(targetPosition, chessBoard, out invalidStatus))
                return false;

            return true;
        }
    }
}
