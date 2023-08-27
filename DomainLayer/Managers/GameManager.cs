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
        public GameStatus MakeMove(Position piecePosition, Position movePosition, out Notification invalidStatus)
        {
            ChessPiece piece = chessBoard.GetPiece(piecePosition);

            if (!piece.ValidateMove(movePosition, chessBoard.GetChessBoard(), out invalidStatus))
                return null;

            chessBoard.MovePiece(piece, movePosition);

            roundManager.NextRound();

            return GetGameStatus();
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
        public bool IsCheck()
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
