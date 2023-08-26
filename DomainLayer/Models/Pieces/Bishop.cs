using HW2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models.Pieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.BISHOP;
        }

        public override bool ValidateMove(Position nextPosition)
        {
            throw new NotImplementedException();
        }
    }
}
