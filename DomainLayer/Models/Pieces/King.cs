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

        public override bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification invalidStatus)
        {
            if (MoveHelper.VerticalHorizontal(currentPosition, targetPosition, chessBoard, out invalidStatus, distance: 1))
            {
                if (invalidStatus != null)
                {
                    return false;
                }
            }
            else if (MoveHelper.Diagonal(currentPosition, targetPosition, chessBoard, out invalidStatus, distance: 1))
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

            if (!CanMove(targetPosition, chessBoard,out invalidStatus))            
                return false;
            

            return true;
        }
        private bool CanMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification invalidStatus)
        {
            invalidStatus = null;

            List<ChessPiece> enemies = GetAllEnemyPieces(chessBoard);

            foreach (var enemy in enemies)
            {
                //The target position is threatened by an enemy piece.
                if (enemy.ValidateMove(targetPosition, chessBoard,out _))
                {
                    invalidStatus = new Notification(NotificationType.THREATENED_POSITION);
                    invalidStatus.Param = enemy;
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
