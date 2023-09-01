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

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            List<Position> positions = new List<Position>();
            int[] knightMovesX = { -1, -2, -2, -1, 1, 2, 2, 1 };
            int[] knightMovesY = { -2, -1, 1, 2, 2, 1, -1, -2 };

            for (int i = 0; i < knightMovesX.Length; i++)
            {
                int newX = currentPosition.X + knightMovesX[i];
                int newY = currentPosition.Y + knightMovesY[i];

                if (IsWithinChessboard(newX, newY))
                {
                    positions.Add(new Position(newX, newY));
                }
            }  
            
            if (!positions.Contains(targetPosition))
            {
                notification = new Notification(NotificationType.INVALID_MOVE);
                return false;
            }


            if (!IsValidTarget(targetPosition, chessBoard, out notification))
                return false;

            notification = null;

            return true;
        }

        private bool IsWithinChessboard(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }
    }
}
