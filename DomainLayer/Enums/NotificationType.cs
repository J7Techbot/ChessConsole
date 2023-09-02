namespace HW2.Enums
{
    public enum NotificationType
    {
        //parse
        NULL = 0,
        TOO_LONG = 1,
        TOO_SHORT = 2,
        BAD_COMBINATION = 3,
        
        //move
        SQUARE_OCCUPIED = 4,        
        INVALID_POSITION = 5,
        INVALID_TARGET = 6,
        INVALID_VALUES = 7,
        INVALID_PIECE = 8,
        INVALID_MOVE = 9,
        INVALID_COLOR = 10,

        //important info
        CHECK = 20,
        KING_EXPOSED = 21,
        MUST_PROTECT_KING = 22,
        GAME_OVER = 23,
    }
}
