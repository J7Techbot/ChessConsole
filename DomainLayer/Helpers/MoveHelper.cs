using HW2.Enums;
using HW2.Extensions;
using HW2.Models;
using HW2.Models.Pieces;

namespace HW2.Helpers
{
    public static class MoveHelper
    {
        public static bool Diagonal(Position currentPosition, Position nextPosition, ChessPiece[,] chessBoard, out Notification invalidStatus,int distance = 8)
        {
            invalidStatus = null;

            List<Position> allDiagonals = PositionHelper.GetDiagonals(currentPosition, distance);

            if (allDiagonals.Contains(nextPosition))
            {
                int dx = nextPosition.X - currentPosition.X;
                int dy = nextPosition.Y - currentPosition.Y;

                int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

                for (int step = 1; step < steps; step++)
                {
                    int x = currentPosition.X + (dx * step / steps);
                    int y = currentPosition.Y + (dy * step / steps);

                    if (chessBoard.Contains(x, y))
                    {
                        invalidStatus = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
            }
            else
            {
                invalidStatus = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }

            return true;
        }
        public static bool VerticalHorizontal(Position currentPosition, Position nextPosition, ChessPiece[,] chessBoard, out Notification invalidStatus, int distance = 8)
        {
            invalidStatus = null;

            List<Position> allVerticals = PositionHelper.GetVerticals(currentPosition, distance);
            List<Position> allHorizontals = PositionHelper.GetHorizontals(currentPosition, distance);

            if (allVerticals.Contains(nextPosition) || allHorizontals.Contains(nextPosition))
            {
                //horizontal
                if (currentPosition.X == nextPosition.X)
                {
                    int floor = (currentPosition.Y > nextPosition.Y ? nextPosition.Y : currentPosition.Y) + 1;
                    int ceil = (currentPosition.Y > nextPosition.Y ? currentPosition.Y : nextPosition.Y) - 1;

                    for (int i = floor; i <= ceil; i++)
                    {
                        if (chessBoard.Contains(currentPosition.X, i))
                            invalidStatus = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
                //vertical
                else
                {
                    int floor = (currentPosition.X > nextPosition.X ? nextPosition.X : currentPosition.X) + 1;
                    int ceil = (currentPosition.X > nextPosition.X ? currentPosition.X : nextPosition.X) - 1;

                    for (int i = floor; i <= ceil; i++)
                    {
                        if (chessBoard.Contains(i, currentPosition.Y))
                            invalidStatus = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
            }
            else            
                return false;
            
            return true;
        }
    }
}
