using HW2.Enums;

namespace HW2.Models
{
    public class InvalidStatus
    {
        public InvalidErrorType InvalidErrorType { get; set; }

        public InvalidStatus(InvalidErrorType invalidErrorType)
        {
            InvalidErrorType = invalidErrorType;
        }
    }

}
