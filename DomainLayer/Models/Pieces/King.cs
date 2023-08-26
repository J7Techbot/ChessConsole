using HW2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models.Pieces
{
    public class King : ChessPiece
    {
        public King(Position defaultPosition, Color color) : base(defaultPosition, color)
        {
            chessPieceType = ChessPieceType.KING;
        }

        public override bool ValidateMove(Position nextPosition)
        {
            throw new NotImplementedException();
        }
    }
}
