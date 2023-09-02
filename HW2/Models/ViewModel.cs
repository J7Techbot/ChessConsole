using DomainLayer.Directors;
using DomainLayer.Interfaces;
using HW2.Enums;
using HW2.Helpers;
using HW2.Models;
using ViewLayer.Enums;

namespace ViewLayer.Models
{
    /// <summary>
    /// Provide communication beteween view and models. Its binded to view via delegates.
    /// </summary>
    public class ViewModel
    {
        private IGameDirector gameDirector;
        private GameStatus gameStatus;
        private ConstraintValidator constraintValidator;

        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<Notification> NotificationEvent { get; set; }
        public Func<InputQueryType, string> ExpectedInputEvent { get; set; }

        public ViewModel()
        {
            gameDirector = new ChessDirector();
            constraintValidator = new ConstraintValidator();
        }

        /// <summary>
        /// Starts main game loop.
        /// </summary>
        public void RunGame()
        {
            UpdateView(gameDirector.GetGameStatus());

            while (true)
            {
                ///verify if king of current player is exposed
                gameDirector.InitNewRound(out Notification notification);

                if (notification != null)
                    NotificationEvent?.Invoke(notification);

                ///call for input at view and check if its valid string.This input select piece at position 
                var piecePositionInput = ExpectedInputEvent?.Invoke(InputQueryType.SELECT_PIECE);
                if (!ValidateInput(constraintValidator.SelectionValidation, piecePositionInput, this.gameStatus, out bool canContinue))
                {
                    if (canContinue)
                        continue;
                    else
                        return;
                }

                ///call for input at view and check if its valid string.This input targets location for selected piece 
                var movePositionInput = ExpectedInputEvent?.Invoke(InputQueryType.SELECT_MOVE);
                if (!ValidateInput(constraintValidator.MoveValidation, movePositionInput, this.gameStatus, out canContinue))
                {
                    if (canContinue)
                        continue;
                    else
                        return;
                }
                   

                ///pass validated and parsed input from user to <see cref="ChessDirector"/>
                GameStatus gameStatus = gameDirector.MakeMove(
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


        public bool ValidateInput(Func<string, GameStatus, Tuple<bool, Notification>> validationFunc, string input, GameStatus gameStatus, out bool canContinue)
        {
            if (!CheckEndGame(input, gameStatus))
            {
                canContinue = false;
                return false;
            }
            else
            {
                var result = validationFunc.Invoke(input, gameStatus);

                bool isValid = result.Item1;

                canContinue = true;

                if (!isValid)
                    NotificationEvent?.Invoke(result.Item2);

                return isValid;
            }            
        }

        /// <summary>
        /// It checks the input to see if the player has chosen to end the game.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>If game has ended return false</returns>
        private bool CheckEndGame(string input, GameStatus gameStatus)
        {
            if (input.ToLower().Trim() == "end")
            {
                NotificationEvent?.Invoke(new Notification(NotificationType.GAME_OVER, gameStatus.CurrentPlayer == Color.WHITE ? Color.BLACK : Color.WHITE));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Actualize information about player,round and chessboard at view.
        /// </summary>
        /// <param name="gameStatus"></param>
        private void UpdateView(GameStatus gameStatus)
        {
            this.gameStatus = gameStatus;

            UpdateGameStatusEvent?.Invoke(gameStatus);
        }
    }
}
