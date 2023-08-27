using System.ComponentModel;

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
        [Description("A")]
        KNIGHT = 4,
        [Description("P")]
        PAWN = 5,
    }
}
