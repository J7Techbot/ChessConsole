using HW2.Enums;
using HW2.Models.Pieces;

namespace HW2.Models
{
    public class ChessBoard
    {
        private readonly ChessPiece[,] chessBoard = new ChessPiece[8, 8];

        public ChessBoard()
        {
            InitChessBoard();
        }

        private void InitChessBoard()
        {
            Dictionary<Color, List<ChessPiece>> allChessPieces = new Dictionary<Color, List<ChessPiece>>()
            {
                { Color.WHITE, new List<ChessPiece>()
                    {
                        { new King(defaultPosition:new Position(7,3),Color.WHITE )},
                        { new Queen(defaultPosition:new Position(7,4),Color.WHITE )},
                        { new Bishop(defaultPosition:new Position(7,2),Color.WHITE )},
                        { new Bishop(defaultPosition:new Position(7,5),Color.WHITE )},
                        { new Knight(defaultPosition:new Position(7,1),Color.WHITE )},
                        { new Knight(defaultPosition:new Position(7,6),Color.WHITE )},
                        { new Rook(defaultPosition:new Position(7,0),Color.WHITE )},
                        { new Rook(defaultPosition:new Position(7,7),Color.WHITE )},                        
                    }
                },
                { Color.BLACK, new List<ChessPiece>()
                    {
                        { new King(defaultPosition:new Position(0,4),Color.BLACK )},
                        { new Queen(defaultPosition:new Position(0,3),Color.BLACK )},
                        { new Bishop(defaultPosition:new Position(0,2),Color.BLACK )},
                        { new Bishop(defaultPosition:new Position(0,5),Color.BLACK )},
                        { new Knight(defaultPosition:new Position(0,1),Color.BLACK )},
                        { new Knight(defaultPosition:new Position(0,6),Color.BLACK )},
                        { new Rook(defaultPosition:new Position(0,0),Color.BLACK )},
                        { new Rook(defaultPosition:new Position(0,7),Color.BLACK )},
                    }
                }
            };

            allChessPieces[Color.WHITE].AddRange(CreatePawns(Color.WHITE, row: 6));
            allChessPieces[Color.WHITE].AddRange(CreatePawns(Color.BLACK, row: 1));

            foreach (var piece in allChessPieces[Color.WHITE])
            {
                chessBoard[piece.GetCurrentPosition().X, piece.GetCurrentPosition().Y] = piece;
            }
            foreach (var piece in allChessPieces[Color.BLACK])
            {
                chessBoard[piece.GetCurrentPosition().X, piece.GetCurrentPosition().Y] = piece;
            }

        }
        public void DrawChessBoard()
        {
            Console.WriteLine("round one");
            string board = "";
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    if (chessBoard[i, j] == null)
                        board += "[]";
                    else
                        board += chessBoard[i, j];

                    board += " ";
                }

                board += "\n\n";
            }

            CustomConsole.WriteLineCentered(board);
        }
        private List<ChessPiece> CreatePawns(Color color,int row)
        {
            List<ChessPiece> pawns = new List<ChessPiece>();

            for (int i = 0; i < 8; i++)
            {
                pawns.Add(new Pawn(new Position(row, i), color));
            }

            return pawns;
        }
        private void SetPiece(ChessPiece chessPiece)
        {

        }
    }
}
