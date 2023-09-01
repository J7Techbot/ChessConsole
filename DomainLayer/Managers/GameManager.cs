using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;

namespace HW2.Managers
{
    public class GameManager
    {
        public bool GameOver { get; private set; }

        private ChessBoard chessBoard;
        private RoundManager roundManager;

        public GameManager()
        {
            chessBoard = new ChessBoard();
            roundManager = new RoundManager();
        }
        public GameStatus MakeMove(Position piecePosition, Position targetPosition, out Notification notification)
        {
            ChessPiece piece = chessBoard.GetPiece(piecePosition);

            if (piece.Color != roundManager.CurrentPlayerColor)
            {
                notification = new Notification(NotificationType.INVALID_COLOR);
                return null;
            }
                
            if (!piece.ValidateMove(targetPosition, chessBoard.GetChessBoard(), out notification))
                return null;

            if (CanExposeKing(piece, targetPosition, out notification))
                return null;

            if (IsCheck())
            {
                if (!CanProtectKing(piece, targetPosition, out notification))
                    return null;
            }
            else
                chessBoard.MovePiece(piece, targetPosition);

            roundManager.NextRound();

            return GetGameStatus();
        }

        public void InitNewRound(out Notification notification)
        {                        
            if (IsCheck())
            {
                notification = new Notification(NotificationType.CHECK);
                return;
            }

            notification = null;
        }

        public GameStatus GetGameStatus()
        {
            return new GameStatus()
            {
                ChessBoard = chessBoard.GetChessBoard(),
                CurrentPlayer = roundManager.CurrentPlayerColor,
                CurrentRound = roundManager.CurrentRound,
            };
        }

        private bool IsCheck()
        {
            ChessPiece king = chessBoard.GetAllPieces(roundManager.CurrentPlayerColor, ChessPieceType.KING).First();

            List<ChessPiece> enemyPieces = chessBoard.GetAllPieces(
                roundManager.CurrentPlayerColor == Color.WHITE ? Color.BLACK : Color.WHITE);

            foreach (var enemy in enemyPieces)
            {
                if (enemy.ValidateMove(king.GetCurrentPosition(), chessBoard.GetChessBoard(), out _))               
                    return true;
                
            }

            return false;
        }

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
        
        private bool CanProtectKing(ChessPiece piece, Position targetPosition, out Notification notification)
        {
            if (!VerifyKingCover(piece, targetPosition))
            {
                notification = new Notification(NotificationType.KING_EXPOSED);
                return true;
            }

            notification = null;
            return false;
        }
    }
}
