using HW2.Helpers;
using HW2.Managers;
using HW2.Models;
using ViewLayer.Enums;

namespace ViewLayer.Models
{
    public class ViewModel
    {
        private GameManager gameManager;
        private ConstraintValidator constraintValidator;
        private GameStatus gameStatus;

        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<InvalidStatus> InvalidStatusNotificationEvent { get; set; }
        public Func<InputQueryType, string> ExpectedInputEvent { get; set; }

        public ViewModel()
        {
            gameManager = new GameManager();
            constraintValidator = new ConstraintValidator();
        }
        public void RunGame()
        {
            UpdateView(gameManager.GetGameStatus());

            while (true)
            {
                var piecePositionInput = GetUserInputs(InputQueryType.SELECT_PIECE);
                if (!ValidatePiecePosition(piecePositionInput))
                    continue;
                var movePositionInput = GetUserInputs(InputQueryType.SELECT_MOVE);
                if (!ValidateMovePosition(movePositionInput))
                    continue;

                GameStatus gameStatus = gameManager.MakeMove(
                        PositionHelper.ParseInput(piecePositionInput),
                        PositionHelper.ParseInput(movePositionInput),
                        out InvalidStatus invalidStatus);

                if(gameStatus != null)
                    UpdateView(gameStatus);
                else
                    InvalidStatusNotificationEvent?.Invoke(invalidStatus);
            }
        }
        private void UpdateView(GameStatus gameStatus)
        {
            this.gameStatus = gameStatus;

            UpdateGameStatusEvent?.Invoke(gameStatus);
        }
        private string GetUserInputs(InputQueryType inputQueryType)
        {
            return ExpectedInputEvent?.Invoke(inputQueryType);
        }
        public bool ValidatePiecePosition(string? position)
        {
            if (!constraintValidator.SelectionValidation(position, gameStatus, out InvalidStatus invalidStatus))
            {
                InvalidStatusNotificationEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
        public bool ValidateMovePosition(string? position)
        {
            if (!constraintValidator.MoveValidation(position, gameStatus, out InvalidStatus invalidStatus))
            {
                InvalidStatusNotificationEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
    }
}
