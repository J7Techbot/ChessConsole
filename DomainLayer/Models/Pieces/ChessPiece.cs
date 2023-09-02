using HW2.Enums;
using HW2.Extensions;

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

        /// <summary>
        /// It verifies if the entered target position does not contain a piece with the same color as the moving piece.
        /// If so, it creates the corresponding notification and conveys it through the <paramref name="notification"/> parameter.
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <param name="chessBoard"></param>
        /// <param name="notification"></param>
        /// <returns>True if the piece is of the opposite color.</returns>
        public bool IsValidTarget(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification)
        {
            notification = null;

            if (chessBoard[targetPosition.X, targetPosition.Y] != null && chessBoard[targetPosition.X, targetPosition.Y].Color == Color)
            {
                notification = new Notification(NotificationType.INVALID_TARGET);
                return false;
            }

            return true;
        }

        /// <summary>
        /// It verifies that the movement of the piece is valid according to its defined rules.
        /// If not, it creates and conveys a message in the 'notification' parameter.
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <param name="chessBoard"></param>
        /// <param name="notification"></param>
        /// <returns>True if the move can be executed.</returns>
        public abstract bool ValidateMove(Position targetPosition, ChessPiece[,] chessBoard, out Notification notification);

        public override string ToString()
        {
            return $"{Color.GetDescription()}{chessPieceType.GetDescription()}";
        }        
    }
}
