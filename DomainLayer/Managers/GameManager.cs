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
        public GameStatus MakeMove(Position piecePosition, Position movePosition, out InvalidStatus invalidStatus)
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
    }
}
