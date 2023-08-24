using DomainLayer.Interfaces;
using DomainLayer.Models;
using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;
using ViewLayer.Constants;
using ViewLayer.Enums;

namespace ViewLayer.Models
{
    public class GamePresenter
    {
        public GamePresenter(IViewTrigger viewTrigger)
        {
            viewTrigger.UpdateGameStatusEvent += UpdateGameStatus;
            viewTrigger.InvalidMoveEvent += InvalidMove;
            viewTrigger.ExpectedInputEvent += GetInput;
        }

        private string GetInput()
        {
            return Console.ReadLine();
        }

        private void InvalidMove(InvalidStatus invalidStatus)
        {
            switch (invalidStatus.InvalidErrorType)
            {
                case InvalidErrorType.NULL:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.NullError);
                    break;
                case InvalidErrorType.TOO_LONG:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooLongError);
                    break;
                case InvalidErrorType.TOO_SHORT:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooShortError);
                    break;
                case InvalidErrorType.BAD_COMBINATION:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.BadCombinationError);
                    break;
                case InvalidErrorType.INVALID_VALUES:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidValuesError);
                    break;
            }
        }

        public void StartNewMatch()
        {
            ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.NewGameInfo}", ConsoleTextPosition.MIDDLE);

            Console.ReadKey();

            Console.Clear();
        }
        private void UpdateGameStatus(GameStatus gameStatus)
        {
            Console.Clear();

            ConsoleWritter.WriteLineAtPosition(
                $"{ViewNotificationsConstants.CurrentPlayerInfo}{gameStatus.CurrentPlayer}\n" +
                $"{ViewNotificationsConstants.CurrentRoundInfo}{gameStatus.CurrentRound}", ConsoleTextPosition.TOP);

            ConsoleWritter.WriteLineAtPosition($"{StringifyChessBoard(gameStatus.ChessBoard)}", ConsoleTextPosition.MIDDLE);

            SelectPiece();
        }
        private void SelectPiece()
        {
            ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.SelectPiece}", ConsoleTextPosition.BOTTOM);
        }

        public string StringifyChessBoard(ChessPiece[,] chessBoard)
        {
            string board = "";
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                board += $"{8 - i} - ";
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    if (chessBoard[i, j] == null)
                        board += "[]";
                    else
                        board += chessBoard[i, j];

                    board += " ";
                }

                board += "\n\n";
            }

            board += $"   A  B  C  D  E  F  G  H ";

            return board;
        }
    }
}
