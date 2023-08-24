using DomainLayer.Managers;
using HW2.Enums;
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
        
        public ChessPiece[,] GetChessBoard()
        {
            return chessBoard;
        }        
    }
}
