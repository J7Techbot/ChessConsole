using DomainLayer.Interfaces;
using HW2.Enums;
using HW2.Managers;
using HW2.Models;
using HW2.Models.Pieces;

namespace DomainLayer.Directors
{
    /// <summary>
    /// It serves to control the game.It updates the game board using the methods InitNewRound and MakeMove.
    /// It collects information about the game state and generates error notifications.
    /// </summary>
    public class ChessDirector : IGameDirector
    {
        private ChessBoard chessBoard;
        private RoundManager roundManager;

        public ChessDirector()
        {
            chessBoard = new ChessBoard();
            roundManager = new RoundManager();
        }

        /// <summary>
        /// Try to make move with selected piece.  
        /// </summary>
        /// <param name="selectedPiecePosition">Position of the piece to move.</param>
        /// <param name="targetPosition">Position where the piece attempts to move.</param>
        /// <param name="notification"></param>
        /// <returns>If the move is valid, it creates and returns a new <see cref="GameStatus"/> otherwise, it returns null,
        /// and error information is stored in the <paramref name="notification"/> parameter.</returns>
        public GameStatus MakeMove(Position selectedPiecePosition, Position targetPosition, out Notification notification)
        {
            ChessPiece selectedPiece = chessBoard.GetPiece(selectedPiecePosition);

            ///color validation
            if (selectedPiece.Color != roundManager.CurrentPlayerColor)
            {
                notification = new Notification(NotificationType.INVALID_COLOR);
                return null;
            }

            ///move validation
            if (!selectedPiece.ValidateMove(targetPosition, chessBoard.GetChessBoard(), out notification))
                return null;

            ///check validation
            if (IsCheck())
                if (!CanProtectKing(selectedPiece, targetPosition, out notification))
                    return null;

            ///king exposion validation 
            if (CanExposeKing(selectedPiece, targetPosition, out notification))
                return null;

            chessBoard.MovePiece(selectedPiece, targetPosition);

            roundManager.NextRound();

            return GetGameStatus();
        }

        /// <summary>
        /// At the beginning of a new round, it checks if the king is not in check; if so,
        /// the information is conveyed through the 'notification' parameter.
        /// </summary>
        /// <param name="notification"></param>
        public void InitNewRound(out Notification notification)
        {
            if (IsCheck())
            {
                notification = new Notification(NotificationType.CHECK);
                return;
            }

            notification = null;
        }

        /// <summary>
        /// It gathers and returns the current information about the game board, the current player, and the current round.
        /// </summary>
        /// <returns></returns>
        public GameStatus GetGameStatus()
        {
            return new GameStatus()
            {
                ChessBoard = chessBoard.GetChessBoard(),
                CurrentPlayer = roundManager.CurrentPlayerColor,
                CurrentRound = roundManager.CurrentRound,
            };
        }

        /// <summary>
        /// It verifies whether the king is in check.
        /// </summary>
        /// <returns>If the king is being threatened, it returns true.</returns>
        private bool IsCheck()
        {
            ChessPiece king = chessBoard.GetAllPieces(roundManager.CurrentPlayerColor, ChessPieceType.KING).First();

            List<ChessPiece> enemyPieces = chessBoard.GetAllPieces(
                roundManager.CurrentPlayerColor == Color.WHITE ? Color.BLACK : Color.WHITE);

            ///It attempts to find an enemy piece that directly threatens the target position.
            foreach (var enemy in enemyPieces)
            {
                if (enemy.ValidateMove(king.GetCurrentPosition(), chessBoard.GetChessBoard(), out _))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// It verifies that a given move does not put the king in check. It moves the <paramref name="piece"/> to the <paramref name="targetPosition"/> and checks
        /// if the king is in check; if so, it returns the piece back to its original position.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="targetPosition"></param>
        /// <returns>It returns true if the move does not endanger the king.</returns>
        private bool VerifyKingCover(ChessPiece piece, Position targetPosition)
        {
            Position originalPosition = piece.GetCurrentPosition();

            ChessPiece removedPiece = chessBoard.MovePiece(piece, targetPosition);

            if (IsCheck())
            {
                chessBoard.MovePiece(piece, originalPosition);

                if (removedPiece != null)
                    chessBoard.MovePiece(removedPiece, removedPiece.GetCurrentPosition());

                return false;
            }

            return true;
        }

        /// <summary>
        /// It verifies whether the move endangers the king; if so, it conveys the information to the <paramref name="notification"/> parameter and returns true.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="targetPosition"></param>
        /// <param name="notification"></param>
        /// <returns>True if king will be exposed.</returns>
        private bool CanExposeKing(ChessPiece piece, Position targetPosition, out Notification notification)
        {
            if (!VerifyKingCover(piece, targetPosition))
            {
                notification = new Notification(NotificationType.KING_EXPOSED);
                return true;
            }

            notification = null;
            return false;
        }

        /// <summary>
        /// It verifies whether the move protects the king; if not, it conveys the information to the <paramref name="notification"/> parameter and returns false.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="targetPosition"></param>
        /// <param name="notification"></param>
        /// <returns>True if move will protect king.</returns>
        private bool CanProtectKing(ChessPiece piece, Position targetPosition, out Notification notification)
        {
            if (!VerifyKingCover(piece, targetPosition))
            {
                notification = new Notification(NotificationType.MUST_PROTECT_KING);
                return false;
            }

            notification = null;
            return true;
        }
    }
}
