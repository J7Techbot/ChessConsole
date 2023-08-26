using DomainLayer.Managers;
using HW2.Enums;
using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class MoveValidator
    {
        private PositionManager positionManager;

        public MoveValidator()
        {
            this.positionManager = new PositionManager();
        }


        public bool SelectionValidation(string position, out InvalidStatus invalidStatus)
        {
            if (!ValidateBoardConstraints(position, InvalidMoveType.INVALID_PIECE_SELECTION, out invalidStatus))
                return false;

            invalidStatus = null;

            return true;
        }

        public bool MoveValidation(string position, out InvalidStatus invalidStatus)
        {
            if (!ValidateBoardConstraints(position, InvalidMoveType.INVALID_MOVE_SELECTION, out invalidStatus))            
                return false;
            
            invalidStatus = null;

            return true;
        }

        private bool ValidateBoardConstraints(string position, InvalidMoveType invalidMoveType, out InvalidStatus invalidStatus)
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
            else if (!positionManager.ValidateInput(position))
            {
                invalidStatus = new InvalidStatus(InvalidErrorType.INVALID_VALUES, invalidMoveType);
                return false;
            }

            invalidStatus = null;

            return true;
        }
    }
}
