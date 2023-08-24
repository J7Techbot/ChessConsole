using DomainLayer.Interfaces;
using DomainLayer.Models;
using HW2.Enums;
using HW2.Models;

namespace DomainLayer.Managers
{
    public class GameManager : IViewTrigger
    {
        public bool GameOver { get; private set; }
        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
        public Action<InvalidStatus> InvalidMoveEvent { get; set; }
        public Func<string> ExpectedInputEvent { get; set; }

        private ChessBoard chessBoard;
        private RoundManager roundManager;
        private MoveValidator moveValidator;
        private PositionManager positionManager;
                
        public GameManager()
        {
            chessBoard = new ChessBoard(); 
            roundManager = new RoundManager();
            moveValidator = new MoveValidator();
            positionManager = new PositionManager();
        }

        public void Run()
        {
            while (!GameOver)
            {
                InitRound();

                string selectedPositionInput = ExpectedInputEvent.Invoke();

                while (!TrySelectPiece(selectedPositionInput))
                {
                    selectedPositionInput = ExpectedInputEvent.Invoke();
                }
                
                string selectedDestinationInput = ExpectedInputEvent.Invoke();

                while (!TrySelectDestination(selectedDestinationInput))
                {
                    selectedDestinationInput = ExpectedInputEvent.Invoke();
                }

                Position selectedPositionParsed = positionManager.ParseInput(selectedPositionInput);
                Position selectedMoveParsed = positionManager.ParseInput(selectedDestinationInput);

                //validation move

                //refactor
                var selectedPiece = chessBoard.GetChessBoard()[selectedPositionParsed.X, selectedPositionParsed.Y];
                chessBoard.GetChessBoard()[selectedMoveParsed.X, selectedMoveParsed.Y] = selectedPiece;
                chessBoard.GetChessBoard()[selectedPositionParsed.X, selectedPositionParsed.Y] = null ;

                NextRound();


            }
        }
        public void NextRound()
        {
            roundManager.NextRound();
        }
        public void InitRound()
        {
            UpdateGameStatus();
        }
        private void UpdateGameStatus() 
        {           
            UpdateGameStatusEvent?.Invoke(GetGameStatus());
        }
        private GameStatus GetGameStatus()
        {
            return new GameStatus()
            {
                ChessBoard = chessBoard.GetChessBoard(),
                CurrentPlayer = roundManager.CurrentPlayer,
                CurrentRound = roundManager.CurrentRound,
            };
        }

        public bool TrySelectPiece(string? position)
        {
            if (!moveValidator.SelectionValidation(position, out InvalidStatus invalidStatus))
            {
                InvalidMoveEvent?.Invoke(invalidStatus);
                return false;
            }
                
            return true;
        }
        public bool TrySelectDestination(string? position)
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
