using HW2.Enums;

namespace DomainLayer.Models
{
    public class InvalidStatus
    {
        public InvalidErrorType InvalidErrorType { get; set; }
        public InvalidMoveType InvalidMoveType { get; set; }
        public InvalidStatus(InvalidErrorType invalidErrorType, InvalidMoveType invalidMoveType)
        {
            InvalidErrorType = invalidErrorType;
            InvalidMoveType = invalidMoveType;
        }
    }

}
