using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models.Pieces
{
    /// <summary>
    /// Base class for all chess pieces.
    /// </summary>
    public abstract class ChessPiece
    {
        protected Position currentPosition;
        protected ChessPieceType chessPieceType;
        public Color Color { get; private set; }

        public ChessPiece(Position defaultPosition, Color color)
        {
            this.currentPosition = defaultPosition;
            this.Color = color;
        }

        public Position GetCurrentPosition()
        {
            return currentPosition;
        }
        public void UpdateCurrentPosition(Position newPosition)
        {
            currentPosition = newPosition;
        }
        public ChessPieceType GetPieceType()
        {
            return chessPieceType;
        }
        public abstract bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification invalidStatus);
        public override string ToString()
        {
            return $"{Color.GetDescription()}{chessPieceType.GetDescription()}";
        }
        public bool IsValidTarget(Position targetPosition, ChessPiece[,] chessBoard, out Notification invalidStatus)
        {
            invalidStatus = null;

            //target same color
            if (chessBoard[targetPosition.X, targetPosition.Y] != null && chessBoard[targetPosition.X, targetPosition.Y].Color == Color)
            {
                invalidStatus = new Notification(NotificationType.INVALID_TARGET);
                return false;
            }
                            
            return true;
        }
    }
}
