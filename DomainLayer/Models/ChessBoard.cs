using HW2.Enums;
using HW2.Managers;
using HW2.Models.Pieces;

namespace HW2.Models
{
    public class ChessBoard
    {
        private readonly ChessPiece[,] chessBoard = new ChessPiece[8, 8];

        private readonly PiecesManager piecesManager;

        public ChessBoard()
        {
            piecesManager = new PiecesManager();

            InitChessBoard(piecesManager.InstantiateAllPieces());
        }
              
        private void InitChessBoard(Dictionary<Color, List<ChessPiece>> allPieces)
        {
            foreach (var item in allPieces.SelectMany(x=>x.Value))
            {
                chessBoard[item.GetCurrentPosition().X, item.GetCurrentPosition().Y] = item;
            }
        }
        
        public void MovePiece(ChessPiece piece, Position destination)
        {
            chessBoard[piece.GetCurrentPosition().X, piece.GetCurrentPosition().Y] = null;
            chessBoard[destination.X, destination.Y] = piece;

            piece.UpdateCurrentPosition(destination);
        }

        public ChessPiece[,] GetChessBoard()
        {
            return chessBoard;
        }

        public ChessPiece GetPiece(Position piecePosition)
        {
            return chessBoard[piecePosition.X, piecePosition.Y];
        }
    }
}
