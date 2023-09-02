using ViewLayer.Enums;

namespace ViewLayer.Models
{
    /// <summary>
    /// It assists in displaying notifications on the console-based UI.
    /// </summary>
    public static class ConsoleWritter
    {
        private const int topPadding = 2;
        private const int bottomPadding = 3;

        /// <summary>
        /// It prints lines to the correct position in the console based on the provided <paramref name="position"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="position"></param>
        public static void WriteLineAtPosition(string text, ConsoleTextPosition position)
        {
            Dictionary<string, int> consoleInfo = GetConsoleInfo();

            string[] lines = GetLines(text);

            int modifiedTopPadding = GetTopPadding(position, consoleInfo, lines);

            WritteLines(consoleInfo, lines, modifiedTopPadding);

            Console.WriteLine();
        }

        /// <summary>
        /// It clears the previous text and writes the new input on the line selected using the provided <paramref name="topPadding"/> parameter.
        /// </summary>
        /// <param name="consoleInfo"></param>
        /// <param name="lines"></param>
        /// <param name="topPadding"></param>
        private static void WritteLines(Dictionary<string, int> consoleInfo, string[] lines, int topPadding)
        {
            foreach (string line in lines)
            {
                Console.SetCursorPosition(0, topPadding);
                Console.Write(new string(' ', Console.WindowWidth));

                Console.SetCursorPosition(GetCenter(consoleInfo, line), topPadding);
                Console.WriteLine(line);
                topPadding++;
            }
        }

        private static string[] GetLines(string text)
        {
            return text.Split(new[] { '\n' });
        }

        /// <summary>
        /// It determines the top padding based on the <paramref name="position"/> parameter.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="consoleInfo"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static int GetTopPadding(ConsoleTextPosition position, Dictionary<string, int> consoleInfo, string[] lines)
        {
            switch (position)
            {
                case ConsoleTextPosition.TOP:
                    return topPadding;
                case ConsoleTextPosition.MIDDLE:
                    return (consoleInfo["windowHeight"] - lines.Length) / 2;
                case ConsoleTextPosition.BOTTOM:
                    return consoleInfo["windowHeight"] - lines.Length - bottomPadding;

                default:
                    throw new ArgumentException("Neplatná pozice.", nameof(position));
            }
        }

        private static int GetCenter(Dictionary<string, int> consoleInfo, string line)
        {
            return (consoleInfo["windowWidth"] - line.Length) / 2;
        }

        private static Dictionary<string, int> GetConsoleInfo()
        {
            return new Dictionary<string, int>()
            {
                {"windowWidth", Console.WindowWidth},
                {"windowHeight", Console.WindowHeight},
                {"originalCursorTop", Console.CursorTop}
            };
        }
        public static void ClearUserText(string newText)
        {
            int currentCursorTop = Console.CursorTop;
            int currentCursorLeft = Console.CursorLeft;

            ClearLine(currentCursorTop - 1);

            RewriteCurrentLine(newText, currentCursorLeft);

            Console.Write(newText);
        }
        public static void RewriteCurrentLine(string newText, int? cursorTop = null,int offset = 0)
        {
            cursorTop = cursorTop ?? Console.CursorTop;

            ClearLine(cursorTop + offset);

            Console.Write(newText);
        }

        public static void ClearLine(int? cursorTop = null)
        {
            cursorTop = cursorTop ?? Console.CursorTop;

            Console.SetCursorPosition(0, (int)cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
