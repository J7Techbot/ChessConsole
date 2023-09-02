using DomainLayer.Directors;
using DomainLayer.Interfaces;
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
