using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Enums
{
    public enum ChessPieceType
    {
        [Description("K")]
        KING = 0,
        [Description("Q")]
        QUEEN = 1,
        [Description("R")]
        ROOK = 2,
        [Description("B")]
        BISHOP = 3,
        [Description("Kn")]
        KNIGHT = 4,
        [Description("P")]
        PAWN = 5,
    }
}
