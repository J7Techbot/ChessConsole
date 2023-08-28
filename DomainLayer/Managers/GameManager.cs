using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;

namespace HW2.Managers
{
    public class GameManager
    {
        public bool GameOver { get; private set; }
        public bool IsCheck { get; private set; }

        private ChessBoard chessBoard;
        private RoundManager roundManager;

        public GameManager()
        {
            chessBoard = new ChessBoard();
            roundManager = new RoundManager();
        }
        public GameStatus MakeMove(Position piecePosition, Position targetPosition, out Notification invalidStatus)
        {
            ChessPiece piece = chessBoard.GetPiece(piecePosition);

            if (!piece.ValidateMove(targetPosition, chessBoard.GetChessBoard(), out invalidStatus))
                return null;

            if(IsCheck)
            {
                if(!CanUncheckKing(piece, targetPosition, out invalidStatus))
                    return null;
            }
            else
                chessBoard.MovePiece(piece, targetPosition);

            roundManager.NextRound();

            IsCheck = IsKingInCheck();

            return GetGameStatus();
        }

        private bool CanUncheckKing(ChessPiece piece, Position targetPosition, out Notification invalidStatus)
        {
            invalidStatus = null;

            Position originalPosition = piece.GetCurrentPosition();

            ChessPiece removedPiece = chessBoard.MovePiece(piece, targetPosition);

            if (IsKingInCheck())
            {
                chessBoard.MovePiece(piece, originalPosition);

                if(removedPiece != null)
                    chessBoard.MovePiece(removedPiece, removedPiece.GetCurrentPosition());

                invalidStatus = new Notification(NotificationType.UNCHECK_KING_FAILED);

                return false;
            }

            return true;
        }

        public GameStatus GetGameStatus()
        {
            return new GameStatus()
            {
                ChessBoard = chessBoard.GetChessBoard(),
                CurrentPlayer = roundManager.CurrentPlayer,
                CurrentRound = roundManager.CurrentRound,
            };
        }
        public bool IsKingInCheck()
        {
            ChessPiece king = chessBoard.GetAllPieces(roundManager.CurrentPlayer,Enums.ChessPieceType.KING).First();

            List<ChessPiece> enemyPieces = chessBoard.GetAllPieces(
                roundManager.CurrentPlayer == Enums.Color.WHITE ? Enums.Color.BLACK : Enums.Color.WHITE);

            foreach (var enemy in enemyPieces)
            {
                if (enemy.ValidateMove(king.GetCurrentPosition(), chessBoard.GetChessBoard(), out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
