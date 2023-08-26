using DomainLayer.Helpers;
using DomainLayer.Managers;
using DomainLayer.Models;
using HW2.Models;
using ViewLayer.Enums;

namespace ViewLayer.Models
{
    public class ViewModel
    {
        private GameManager gameManager;
        private MoveValidator moveValidator;
        private GameStatus gameStatus;

        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<InvalidStatus> InvalidMoveEvent { get; set; }
        public Func<InputQueryType, string> ExpectedInputEvent { get; set; }

        public ViewModel()
        {
            gameManager = new GameManager();
            moveValidator = new MoveValidator();
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
                        PositionHelper.ParseInput(movePositionInput));

                if(gameStatus != null)
                    UpdateView(gameStatus);
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
            if (!moveValidator.SelectionValidation(position, gameStatus, out InvalidStatus invalidStatus))
            {
                InvalidMoveEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
        public bool ValidateMovePosition(string? position)
        {
            if (!moveValidator.MoveValidation(position, gameStatus, out InvalidStatus invalidStatus))
            {
                InvalidMoveEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
    }
}
