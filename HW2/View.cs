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
            viewModel.NotificationEvent += InvalidStatusNotification;
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

        private void InvalidStatusNotification(Notification invalidStatus)
        {
            switch (invalidStatus.NotificationType)
            {
                case NotificationType.NULL:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.NullError, Console.CursorTop);
                    break;
                case NotificationType.TOO_LONG:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooLongError, Console.CursorTop);
                    break;
                case NotificationType.TOO_SHORT:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooShortError, Console.CursorTop);
                    break;
                case NotificationType.BAD_COMBINATION:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.BadCombinationError, Console.CursorTop);
                    break;
                case NotificationType.INVALID_VALUES:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidValuesError, Console.CursorTop);
                    break;
                case NotificationType.INVALID_PIECE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidPiece, Console.CursorTop);
                    break;
                case NotificationType.INVALID_MOVE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidMove, Console.CursorTop);
                    break;
                case NotificationType.SQUARE_OCCUPIED:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.SquareOccupied, Console.CursorTop);
                    break;
                case NotificationType.INVALID_TARGET:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidTarget, Console.CursorTop);
                    break;
                case NotificationType.THREATENED_POSITION:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.ThreatenedPosition} : {invalidStatus.Param.ToString()}", Console.CursorTop);
                    break;
                case NotificationType.CHECK:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.Check}", Console.CursorTop);
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
            string board = $"A  B  C  D  E  F  G  H \n\n";

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

                board += $"- {8 - i}";

                board += "\n\n";
            }

            board += $"A  B  C  D  E  F  G  H ";

            return board;
        }
    }
}
