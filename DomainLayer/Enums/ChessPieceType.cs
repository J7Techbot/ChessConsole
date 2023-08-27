using System.ComponentModel;

namespace HW2.Enums
{
    [Flags]
    public enum ChessPieceType
    {
        [Description("K")]
        KING = 1,
        [Description("Q")]
        QUEEN = 2,
        [Description("R")]
        ROOK = 4,
        [Description("B")]
        BISHOP = 8,
        [Description("F")]
        KNIGHT = 16,
        [Description("P")]
        PAWN = 32,
    }
}
