using HW2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models.Pieces
{
    public class Knight : ChessPiece
    {
        public Knight(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.PAWN;
        }

        public override void Move(Position nextPosition)
        {
            throw new NotImplementedException();
        }
    }
}
