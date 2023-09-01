using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    public class King : ChessPiece
    {
        public King(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.KING;
        }

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            if (MoveHelper.VerticalHorizontal(currentPosition, targetPosition, chessBoard, out notification, distance: 1))
            {
                if (notification != null)
                {
                    return false;
                }
            }
            else if (MoveHelper.Diagonal(currentPosition, targetPosition, chessBoard, out notification, distance: 1))
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

            if (!CanMove(targetPosition, chessBoard,out notification))            
                return false;
            

            return true;
        }
        public bool CanMoveToAvoidCheck(ChessPiece[,] chessBoard)
        {
            List<Position> allowedPositions = new List<Position>();

            allowedPositions.AddRange(PositionHelper.GetDiagonals(currentPosition, distance: 1));
            allowedPositions.AddRange(PositionHelper.GetHorizontals(currentPosition, distance: 1));
            allowedPositions.AddRange(PositionHelper.GetVerticals(currentPosition, distance: 1));

            foreach (var allowedPosition in allowedPositions)
            {
                ChessPiece piece = chessBoard[allowedPosition.X, allowedPosition.Y];
                if (piece != null && piece.Color == Color)
                    continue;

                if (CanMove(allowedPosition, chessBoard, out _))
                    return true;
            }

            return false;
        }
        private bool CanMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            notification = null;

            List<ChessPiece> enemies = GetAllEnemyPieces(chessBoard);

            foreach (var enemy in enemies)
            {
                //The target position is threatened by an enemy piece.
                if (enemy.ValidateMove(targetPosition, chessBoard,out _))
                {
                    notification = new Notification(NotificationType.INVALID_POSITION);
                    notification.Param = enemy;
                    return false;
                }
            }

            return true;
        }
        private List<ChessPiece> GetAllEnemyPieces(ChessPiece[,] chessBoard)
        {
            List<ChessPiece> enemies = new List<ChessPiece>();
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int column = 0; column < chessBoard.GetLength(1); column++)
                {
                    if(chessBoard[row, column] != null && chessBoard[row, column].Color != Color)
                        enemies.Add(chessBoard[row, column]);
                }
            }
            return enemies;
        }

    }
}
