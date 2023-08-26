using DomainLayer.Interfaces;
using DomainLayer.Models;
using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;

namespace DomainLayer.Managers
{
    public class GameManager 
    {
        public bool GameOver { get; private set; }

        public Action<Position, Position> UserInputReceived { get; set; }

        private ChessBoard chessBoard;
        private RoundManager roundManager;

        public GameManager()
        {
            chessBoard = new ChessBoard();
            roundManager = new RoundManager();
        }
        public GameStatus MakeMove(Position piecePosition, Position movePosition)
        {
            ChessPiece piece = chessBoard.GetPiece(piecePosition);

            if (!piece.ValidateMove(movePosition))
                return null;

            chessBoard.MovePiece(piece, movePosition);

            NextRound();

            return GetGameStatus();
        }
        public void NextRound()
        {
            roundManager.NextRound();
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
