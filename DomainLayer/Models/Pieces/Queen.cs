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

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            if (MoveHelper.VerticalHorizontal(currentPosition, targetPosition, chessBoard, out notification))
            {
                if (notification != null)
                {
                    return false;
                }
            }
            else if (MoveHelper.Diagonal(currentPosition, targetPosition, chessBoard, out notification))
            {
                if (notification != null)
                {
                    return false;
                }
            }
            else
            {
                notification = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }

            if (!IsValidTarget(targetPosition, chessBoard, out notification))
                return false;

            return true;
        }
    }
}
