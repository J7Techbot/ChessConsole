using HW2.Enums;
using HW2.Models;
using HW2.Models.Pieces;
using ViewLayer.Constants;
using ViewLayer.Enums;
using ViewLayer.Models;

namespace ViewLayer
{
    /// <summary>
    /// Represents User Interface. Its binded with viewModel via delegates.
    /// </summary>
    public class View
    {
        private ViewModel viewModel;
        public View()
        {
            viewModel = new ViewModel();

            ///binds view model
            viewModel.UpdateGameStatusEvent += UpdateGameStatus;
            viewModel.NotificationEvent += Notify;
            viewModel.ExpectedInputEvent += GetInput;
        }

        /// <summary>
        /// Starts main game loop
        /// </summary>
        public void Start()
        {
            NotifyNewMatch();

            viewModel.RunGame();
        }

        /// <summary>
        /// Offer input to user with notification defined by <paramref name="inputQueryType"/> and waits until input is set. 
        /// </summary>
        /// <param name="inputQueryType"></param>
        /// <returns>User input</returns>
        private string GetInput(InputQueryType inputQueryType)
        {
            switch (inputQueryType)
            {
                case InputQueryType.SELECT_PIECE:
                    ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.SelectPieceInfo}", ConsoleTextPosition.BOTTOM);
                    break;
                case InputQueryType.SELECT_MOVE:
                    ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.SelectMoveInfo}", ConsoleTextPosition.BOTTOM);
                    break;
            }

            string input = Console.ReadLine();

            ConsoleWritter.ClearLine(Console.CursorTop - 1);

            return input;
        }

        /// <summary>
        /// Write notification selected by its type to UI.
        /// </summary>
        /// <param name="notification"></param>
        private void Notify(Notification notification)
        {
            switch (notification.NotificationType)
            {
                case NotificationType.NULL:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.NullError);
                    break;
                case NotificationType.TOO_LONG:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooLongError);
                    break;
                case NotificationType.TOO_SHORT:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.TooShortError);
                    break;
                case NotificationType.BAD_COMBINATION:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.BadCombinationError);
                    break;
                case NotificationType.SQUARE_OCCUPIED:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.SquareOccupiedError);
                    break;
                case NotificationType.INVALID_VALUES:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidValuesError);
                    break;
                case NotificationType.INVALID_PIECE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidPieceError);
                    break;
                case NotificationType.INVALID_MOVE:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidMoveError);
                    break;
                case NotificationType.INVALID_TARGET:
                    ConsoleWritter.RewriteCurrentLine(ViewNotificationsConstants.InvalidTargetError);
                    break;
                case NotificationType.INVALID_POSITION:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.ThreatenedPositionError} : {notification.Param.ToString()}");
                    break;
                case NotificationType.INVALID_COLOR:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.InvalidColorError}");
                    break;
                case NotificationType.CHECK:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.Check}", offset: 2);
                    break;
                case NotificationType.MUST_PROTECT_KING:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.MustProtectKing}");
                    break;
                case NotificationType.KING_EXPOSED:
                    ConsoleWritter.RewriteCurrentLine($"{ViewNotificationsConstants.KingExposed}");
                    break;

            }
        }

        /// <summary>
        /// First view after start app.
        /// </summary>
        public void NotifyNewMatch()
        {
            ConsoleWritter.WriteLineAtPosition($"{ViewNotificationsConstants.NewGameInfo}", ConsoleTextPosition.MIDDLE);

            Console.ReadKey();

            Console.Clear();
        }

        /// <summary>
        /// Main view that current player, round and chessboard. Need to be updated every round. 
        /// </summary>
        /// <param name="gameStatus"></param>
        private void UpdateGameStatus(GameStatus gameStatus)
        {
            Console.Clear();

            ConsoleWritter.WriteLineAtPosition(
                $"{ViewNotificationsConstants.CurrentPlayerInfo}{gameStatus.CurrentPlayer}\n" +
                $"{ViewNotificationsConstants.CurrentRoundInfo}{gameStatus.CurrentRound}", ConsoleTextPosition.TOP);

            ConsoleWritter.WriteLineAtPosition($"{StringifyChessBoard(gameStatus.ChessBoard)}", ConsoleTextPosition.MIDDLE);
        }

        /// <summary>
        /// Parse chessBoard to string for console view.
        /// </summary>
        /// <param name="chessBoard"></param>
        /// <returns></returns>
        public string StringifyChessBoard(ChessPiece[,] chessBoard)
        {
            string board = $"A  B  C  D  E  F  G  H \n\n";

            ///chessboard is 2d array, so both dimension must be iterate 
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                board += $"{8 - i} - ";

                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    ///if position is empty fill string with [], if there is chessPiece shows overrided ToString()
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
