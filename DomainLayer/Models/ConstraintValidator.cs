using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models
{
    public class ConstraintValidator
    {
        public bool SelectionValidation(string position, GameStatus gameStatus, out Notification invalidStatus)
        {
            if (!ValidateBoardConstraints(position, gameStatus, out invalidStatus))
                return false;

            Position parsedPosition = PositionHelper.ParseInput(position);
            if (!gameStatus.ChessBoard.Contains(parsedPosition.X, parsedPosition.Y))
            {
                invalidStatus = new Notification(NotificationType.INVALID_PIECE);
                return false;
            }

            invalidStatus = null;

            return true;
        }

        public bool MoveValidation(string position, GameStatus gameStatus, out Notification invalidStatus)
        {
            if (!ValidateBoardConstraints(position, gameStatus, out invalidStatus))            
                return false;
            
            invalidStatus = null;

            return true;
        }

        private bool ValidateBoardConstraints(string position, GameStatus gameStatus, out Notification invalidStatus)
        {            
            if (string.IsNullOrEmpty(position))
            {
                invalidStatus = new Notification(NotificationType.NULL);
                return false;
            }
            else if (position.Length > 2)
            {
                invalidStatus = new Notification(NotificationType.TOO_LONG);
                return false;
            }
            else if (position.Length < 2)
            {
                invalidStatus = new Notification(NotificationType.TOO_SHORT);
                return false;
            }
            else if (position.Count(char.IsLetter) != 1 && position.Count(char.IsDigit) != 1)
            {
                invalidStatus = new Notification(NotificationType.BAD_COMBINATION);
                return false;
            }
            else if (!PositionHelper.ValidateInput(position))
            {
                invalidStatus = new Notification(NotificationType.INVALID_VALUES);
                return false;
            }           

            invalidStatus = null;

            return true;
        }
    }
}
