using DomainLayer.Extensions;
using DomainLayer.Helpers;
using HW2.Enums;
using HW2.Models;

namespace DomainLayer.Models
{
    public class MoveValidator
    {
        public bool SelectionValidation(string position, GameStatus gameStatus, out InvalidStatus invalidStatus)
        {
            if (!ValidateBoardConstraints(position, InvalidMoveType.INVALID_PIECE_SELECTION, gameStatus, out invalidStatus))
                return false;

            Position parsedPosition = PositionHelper.ParseInput(position);
            if (!gameStatus.ChessBoard.Contains(parsedPosition.X, parsedPosition.Y))
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.INVALID_PIECE, InvalidMoveType.INVALID_PIECE_SELECTION);
                return false;
            }

            invalidStatus = null;

            return true;
        }

        public bool MoveValidation(string position, GameStatus gameStatus, out InvalidStatus invalidStatus)
        {
            if (!ValidateBoardConstraints(position, InvalidMoveType.INVALID_MOVE_SELECTION, gameStatus, out invalidStatus))            
                return false;
            
            invalidStatus = null;

            return true;
        }

        private bool ValidateBoardConstraints(string position, InvalidMoveType invalidMoveType, GameStatus gameStatus, out InvalidStatus invalidStatus)
        {
            
            if (string.IsNullOrEmpty(position))
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.NULL, invalidMoveType);
                return false;
            }
            else if (position.Length > 2)
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.TOO_LONG, invalidMoveType);
                return false;
            }
            else if (position.Length < 2)
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.TOO_SHORT, invalidMoveType);
                return false;
            }
            else if (position.Count(char.IsLetter) != 1 && position.Count(char.IsDigit) != 1)
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.BAD_COMBINATION, invalidMoveType);
                return false;
            }
            else if (!PositionHelper.ValidateInput(position))
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.INVALID_VALUES, invalidMoveType);
                return false;
            }           

            invalidStatus = null;

            return true;
        }
    }
}
