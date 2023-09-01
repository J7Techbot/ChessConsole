using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.PAWN;
        }

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            notification = null;

            bool? isVertical = IsVerticalMove(targetPosition);

            //vertical move (common move)
            if (isVertical != null && (bool)isVertical)
            {
                if (chessBoard.Contains(targetPosition.X, targetPosition.Y))
                {
                    notification = new Notification(NotificationType.SQUARE_OCCUPIED);
                    return false;
                }
            }

            //diagonal move (kill move)
            else if(isVertical != null && !(bool)isVertical)
            {
                if(!IsValidTarget(targetPosition, chessBoard, out notification))
                    return false;
            }

            //invalid square
            else
            {
                notification = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }

            return true;
        }
        private bool? IsVerticalMove(Position nextPosition)
        {
            List<Position> allVerticals = PositionHelper.GetVerticals(currentPosition, distance: 1);
            List<Position> allDiagonals = PositionHelper.GetDiagonals(currentPosition, distance: 1);

            if (Color == Color.WHITE)
            {
                allVerticals.RemoveAll(position => position.X > currentPosition.X);
                allDiagonals.RemoveAll(position => position.X > currentPosition.X);
            }
            else
            {
                allVerticals.RemoveAll(position => position.X < currentPosition.X);
                allDiagonals.RemoveAll(position => position.X < currentPosition.X);
            }

            if (allVerticals.Contains(nextPosition))
                return true;

            else if (allDiagonals.Contains(nextPosition))
                return false;

            else
                return null;
        }
    }
}
