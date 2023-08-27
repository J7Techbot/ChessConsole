using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;
using ViewLayer.Constants;
using ViewLayer.Enums;
using ViewLayer.Models;

namespace ViewLayer
{
    public class View
    {
        private ViewModel viewModel;
        public View()
        {
            viewModel = new ViewModel();

            viewModel.UpdateGameStatusEvent += UpdateGameStatus;
            viewModel.InvalidStatusNotificationEvent += InvalidStatusNotification;
            viewModel.ExpectedInputEvent += GetInput;

            viewModel.RunGame();
        }

        private string GetInput(InputQueryType inputQueryType)
        {
            switch (inputQueryType)
            {
                case InputQueryType.SELECT_PIECE:
                    ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.SelectPiece}", ConsoleTextPosition.BOTTOM);
                    break;
                case InputQueryType.SELECT_MOVE:
                    ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.SelectMove}", ConsoleTextPosition.BOTTOM);
                    break;
            }

            string input = Console.ReadLine();

            ConsoleWritter.ClearLine(Console.CursorTop - 1);

            return input;
        }

        private void InvalidStatusNotification(InvalidStatus invalidStatus)
        {
            switch (invalidStatus.InvalidErrorType)
            {
                case InvalidErrorType.NULL:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.NullError, Console.CursorTop);
                    break;
                case InvalidErrorType.TOO_LONG:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooLongError, Console.CursorTop);
                    break;
                case InvalidErrorType.TOO_SHORT:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooShortError, Console.CursorTop);
                    break;
                case InvalidErrorType.BAD_COMBINATION:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.BadCombinationError, Console.CursorTop);
                    break;
                case InvalidErrorType.INVALID_VALUES:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidValuesError, Console.CursorTop);
                    break;
                case InvalidErrorType.INVALID_PIECE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidPiece, Console.CursorTop);
                    break;
                case InvalidErrorType.INVALID_MOVE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidMove, Console.CursorTop);
                    break;
                case InvalidErrorType.SQUARE_OCCUPIED:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.SquareOccupied, Console.CursorTop);
                    break;
                case InvalidErrorType.INVALID_TARGET:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidTarget, Console.CursorTop);
                    break;
                case InvalidErrorType.THREATENED_POSITION:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.ThreatenedPosition, Console.CursorTop);
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
