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
        private PositionManager positionManager;

        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<InvalidStatus> InvalidMoveEvent { get; set; }
        public Func<InputQueryType,string> ExpectedInputEvent { get; set; }

        public ViewModel()
        {
            gameManager = new GameManager();
            moveValidator = new MoveValidator();
            positionManager = new PositionManager();
        }
        public void StartGame()
        {
            gameManager.Run(UpdateView);

            while (true)
            {                
                var piecePositionInput =  GetUserInputs(InputQueryType.SELECT_PIECE);
                if (!ValidatePiecePosition(piecePositionInput))
                    continue;
                var movePositionInput = GetUserInputs(InputQueryType.SELECT_MOVE);
                if (!ValidateMovePosition(movePositionInput))
                    continue;

                gameManager.UserInputReceived(positionManager.ParseInput(piecePositionInput), positionManager.ParseInput(movePositionInput));
            }
        }
        private void UpdateView(GameStatus gameStatus)
        {
            UpdateGameStatusEvent?.Invoke(gameStatus);
        } 
        private string GetUserInputs(InputQueryType inputQueryType)
        {
            return ExpectedInputEvent?.Invoke(inputQueryType);
        }
        public bool ValidatePiecePosition(string? position)
        {
            if (!moveValidator.SelectionValidation(position, out InvalidStatus invalidStatus))
            {
                InvalidMoveEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
        public bool ValidateMovePosition(string? position)
        {
            if (!moveValidator.MoveValidation(position, out InvalidStatus invalidStatus))
            {
                InvalidMoveEvent?.Invoke(invalidStatus);
                return false;
            }

            return true;
        }
    }
}
