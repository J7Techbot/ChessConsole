using HW2.Enums;
using HW2.Extensions;
using HW2.Helpers;

namespace HW2.Models
{
    /// <summary>
    /// It validates the selection and movement of pieces against the constraints of the game board.
    /// </summary>
    public class ConstraintValidator
    {
        /// <summary>
        /// It validates whether a specific piece can be selected on the game board using the input.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="gameStatus"></param>
        /// <returns>It returns false and notification if it's not possible to select a piece.</returns>
        public Tuple<bool, Notification> SelectionValidation(string position, GameStatus gameStatus)
        {
            Notification notification = null;

            if (!ValidateCommonConstraints(position, gameStatus, out notification))
            {
                return Tuple.Create(false, notification);
            }              

            Position parsedPosition = PositionHelper.ParseInput(position);
            if (!gameStatus.ChessBoard.Contains(parsedPosition.X, parsedPosition.Y))
            {
                notification = new Notification(NotificationType.INVALID_PIECE);

                return Tuple.Create(false, notification);
            }

            return Tuple.Create(true, notification);
        }

        /// <summary>
        /// It validates whether it's possible to move the selected piece to the target position on the game board using the input.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="gameStatus"></param>
        /// <returns>It returns false and notification if it's not possible to move with selected piece.</returns>
        public Tuple<bool,Notification> MoveValidation(string position, GameStatus gameStatus)
        {
            Notification notification = null;

            if (!ValidateCommonConstraints(position, gameStatus, out notification))
            {
                return Tuple.Create(false, notification); 
            }                           

            return Tuple.Create(true, notification);
        }

        /// <summary>
        /// Validate common board and input constraints.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="gameStatus"></param>
        /// <param name="notification"></param>
        /// <returns></returns>
        private bool ValidateCommonConstraints(string position, GameStatus gameStatus, out Notification notification)
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
