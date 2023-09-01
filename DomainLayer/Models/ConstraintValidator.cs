using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models
{
    public class ConstraintValidator
    {
        public bool SelectionValidation(string position, GameStatus gameStatus, out Notification notification)
        {
            if (!ValidateBoardConstraints(position, gameStatus, out notification))
                return false;

            Position parsedPosition = PositionHelper.ParseInput(position);
            if (!gameStatus.ChessBoard.Contains(parsedPosition.X, parsedPosition.Y))
            {
                notification = new Notification(NotificationType.INVALID_PIECE);
                return false;
            }



            notification = null;

            return true;
        }

        public bool MoveValidation(string position, GameStatus gameStatus, out Notification notification)
        {
            if (!ValidateBoardConstraints(position, gameStatus, out notification))            
                return false;
            
            notification = null;

            return true;
        }

        private bool ValidateBoardConstraints(string position, GameStatus gameStatus, out Notification notification)
        {            
            if (string.IsNullOrEmpty(position))
            {
                notification = new Notification(NotificationType.NULL);
                return false;
            }
            else if (position.Length > 2)
            {
                notification = new Notification(NotificationType.TOO_LONG);
                return false;
            }
            else if (position.Length < 2)
            {
                notification = new Notification(NotificationType.TOO_SHORT);
                return false;
            }
            else if (position.Count(char.IsLetter) != 1 && position.Count(char.IsDigit) != 1)
            {
                notification = new Notification(NotificationType.BAD_COMBINATION);
                return false;
            }
            else if (!PositionHelper.ValidateInput(position))
            {
                notification = new Notification(NotificationType.INVALID_VALUES);
                return false;
            }           

            notification = null;

            return true;
        }
    }
}
