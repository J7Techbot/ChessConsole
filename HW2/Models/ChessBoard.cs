using HW2.Enums;
using HW2.Models.Pieces;

namespace HW2.Models
{
    public class ChessBoard
    {
        private readonly ChessPiece[,] chessBoard = new ChessPiece[8, 8];

        private void InitChessBoard()
        {
            List<ChessPiece> whitePawns = CreatePawns(Color.WHITE,row: 5);
            List<ChessPiece> blackPawns = CreatePawns(Color.BLACK, row: 1);

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
