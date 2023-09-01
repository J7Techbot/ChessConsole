using HW2.Helpers;
using HW2.Managers;
using HW2.Models;
using ViewLayer.Enums;

namespace ViewLayer.Models
{
    /// <summary>
    /// Provide communication beteween view and models. Its binded to view via delegates.
    /// </summary>
    public class ViewModel
    {
        private GameManager gameManager;
        private GameStatus gameStatus;
        private ConstraintValidator constraintValidator;

        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<Notification> NotificationEvent { get; set; }
        public Func<InputQueryType, string> ExpectedInputEvent { get; set; }

        public ViewModel()
        {
            gameManager = new GameManager();
            constraintValidator = new ConstraintValidator();
        }

        /// <summary>
        /// Starts main game loop.
        /// </summary>
        public void RunGame()
        {            
            UpdateView(gameManager.GetGameStatus());

            while (true)
            {
                ///verify if king of current player is exposed
                gameManager.InitNewRound(out Notification notification);

                if (notification != null)
                    NotificationEvent?.Invoke(notification);

                ///call for input at view and check if its valid string.This input select piece at position 
                var piecePositionInput = ExpectedInputEvent?.Invoke(InputQueryType.SELECT_PIECE); 
                
                if (!constraintValidator.SelectionValidation(piecePositionInput, this.gameStatus, out notification))
                {
                    NotificationEvent?.Invoke(notification);
                    continue;
                }

                ///call for input at view and check if its valid string.This input targets location for selected piece 
                var movePositionInput = ExpectedInputEvent?.Invoke(InputQueryType.SELECT_MOVE);
                if (!constraintValidator.MoveValidation(movePositionInput, this.gameStatus, out notification))
                {
                    NotificationEvent?.Invoke(notification);
                    continue;
                }
                    
                ///pass validated and parsed input from user to <see cref="GameManager"/>
                GameStatus gameStatus = gameManager.MakeMove(
                        PositionHelper.ParseInput(piecePositionInput),
                        PositionHelper.ParseInput(movePositionInput),
                        out notification);

                ///update view or notify user that he cant move like this
                if (gameStatus != null)
                    UpdateView(gameStatus);
                else
                    NotificationEvent?.Invoke(notification);
            }
        }

        /// <summary>
        /// Sands information about player,round and chessboard to view.
        /// </summary>
        /// <param name="gameStatus"></param>
        private void UpdateView(GameStatus gameStatus)
        {
            this.gameStatus = gameStatus;

            UpdateGameStatusEvent?.Invoke(gameStatus);
        }        
    }
}
