using HW2.Enums;
using HW2.Extensions;
using HW2.Models;
using HW2.Models.Pieces;

namespace HW2.Helpers
{
    /// <summary>
    /// It contains methods that facilitate the movement of pieces.
    /// </summary>
    public static class MoveHelper
    {
        /// <summary>
        /// It determines if diagonal movement to the target position can be executed.
        /// If not, it creates and conveys a message in the <paramref name="notification"/> parameter.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="nextPosition"></param>
        /// <param name="chessBoard"></param>
        /// <param name="notification"></param>
        /// <param name="distance">Optional: Maximum distance of fields from the current position.</param>
        /// <returns>True if move can be executed</returns>
        public static bool Diagonal(Position currentPosition, Position nextPosition, ChessPiece[,] chessBoard, out Notification notification, int distance = 8)
        {
            notification = null;

            List<Position> allDiagonals = PositionHelper.GetDiagonals(currentPosition, distance);

            ///determine if the target position is valid within the range of movement possibilities
            if (allDiagonals.Contains(nextPosition))
            {
                int dx = nextPosition.X - currentPosition.X;
                int dy = nextPosition.Y - currentPosition.Y;

                int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

                ///steps thrue all diagonal fields
                for (int step = 1; step < steps; step++)
                {
                    int x = currentPosition.X + (dx * step / steps);
                    int y = currentPosition.Y + (dy * step / steps);

                    if (chessBoard.Contains(x, y))
                    {
                        notification = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
            }
            else
            {
                notification = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }

            return true;
        }

        /// <summary>
        /// It determines if horizontal or vertical movement to the target position can be executed.
        /// If not, it creates and conveys a message in the <paramref name="notification"/> parameter.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="nextPosition"></param>
        /// <param name="chessBoard"></param>
        /// <param name="notification"></param>
        /// <param name="distance">Optional: Maximum distance of fields from the current position.</param>
        /// <returns>True if move can be executed</returns>
        public static bool VerticalHorizontal(Position currentPosition, Position nextPosition, ChessPiece[,] chessBoard, out Notification notification, int distance = 8)
        {
            notification = null;

            List<Position> allVerticals = PositionHelper.GetVerticals(currentPosition, distance);
            List<Position> allHorizontals = PositionHelper.GetHorizontals(currentPosition, distance);

            ///determine if the target position is valid within the range of movement possibilities
            if (allVerticals.Contains(nextPosition) || allHorizontals.Contains(nextPosition))
            {
                //horizontal
                if (currentPosition.X == nextPosition.X)
                {
                    int floor = (currentPosition.Y > nextPosition.Y ? nextPosition.Y : currentPosition.Y) + 1;
                    int ceil = (currentPosition.Y > nextPosition.Y ? currentPosition.Y : nextPosition.Y) - 1;

                    ///steps thrue all horizontal fields
                    for (int i = floor; i <= ceil; i++)
                    {
                        if (chessBoard.Contains(currentPosition.X, i))
                            notification = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
                //vertical
                else
                {
                    int floor = (currentPosition.X > nextPosition.X ? nextPosition.X : currentPosition.X) + 1;
                    int ceil = (currentPosition.X > nextPosition.X ? currentPosition.X : nextPosition.X) - 1;

                    ///steps thrue all vertical fields
                    for (int i = floor; i <= ceil; i++)
                    {
                        if (chessBoard.Contains(i, currentPosition.Y))
                            notification = new Notification(NotificationType.INVALID_MOVE);
                    }
                }
            }
            else            
                return false;
            
            return true;
        }
    }
}
