using HW2.Enums;
using HW2.Managers;
using HW2.Models.Pieces;

namespace HW2.Models
{
    /// <summary>
    /// It manages the game board.
    /// </summary>
    public class ChessBoard
    {
        private readonly ChessPiece[,] chessBoard = new ChessPiece[8, 8];

        private readonly PiecesManager piecesManager;

        public ChessBoard()
        {
            piecesManager = new PiecesManager();

            InitChessBoard(piecesManager.InstantiateAllPieces());
        }

        /// <summary>
        /// It sets up the pieces on the game board according to their default positions.
        /// </summary>
        /// <param name="allPieces"></param>
        private void InitChessBoard(Dictionary<Color, List<ChessPiece>> allPieces)
        {
            foreach (var item in allPieces.SelectMany(x=>x.Value))
            {
                chessBoard[item.GetCurrentPosition().X, item.GetCurrentPosition().Y] = item;
            }
        }

        /// <summary>
        /// It ensures the safe movement of a piece on the game board.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="targetPosition"></param>
        /// <returns>If the move results in capturing an enemy piece, it returns it; otherwise, it returns null.</returns>
        public ChessPiece MovePiece(ChessPiece piece, Position targetPosition)
        {
            ChessPiece capturedPiece = chessBoard[targetPosition.X, targetPosition.Y];

            chessBoard[piece.GetCurrentPosition().X, piece.GetCurrentPosition().Y] = null;
            chessBoard[targetPosition.X, targetPosition.Y] = piece;

            piece.UpdateCurrentPosition(targetPosition);

            return capturedPiece;
        }

        public ChessPiece[,] GetChessBoard()
        {
            return chessBoard;
        }

        public ChessPiece GetPiece(Position piecePosition)
        {
            return chessBoard[piecePosition.X, piecePosition.Y];
        }

        /// <summary>
        /// It retrieves all available pieces for a given color and type.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="chessPieceType"></param>
        /// <returns></returns>
        public List<ChessPiece> GetAllPieces(Color color, ChessPieceType chessPieceType = (ChessPieceType)63)
        {
            List<ChessPiece> pieces = new List<ChessPiece>();
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int column = 0; column < chessBoard.GetLength(1); column++)
                {
                    if (chessBoard[row, column] != null && chessBoard[row, column].Color == color && (chessPieceType & chessBoard[row, column].GetPieceType()) != 0)
                        pieces.Add(chessBoard[row, column]);
                }
            }
            return pieces;
        }
    }
}
