using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace ViewLayer.Models
{
    public static class ConsoleWritter
    {
        private const int topPadding = 2;
        private const int bottomPadding = 4;

        public static void WriteLineAtPosition(string text, ConsoleTextPosition position)
        {
            Dictionary<string, int> consoleInfo = GetConsoleInfo();

            string[] lines = GetLines(text);

            int modifiedTopPadding = GetTopPadding(position, consoleInfo, lines);

            WritteLines(consoleInfo, lines, modifiedTopPadding);

            Console.WriteLine();
        }

        private static void WritteLines(Dictionary<string, int> consoleInfo, string[] lines, int topPadding)
        {
            foreach (string line in lines)
            {
                Console.SetCursorPosition(0, topPadding);
                Console.Write(new string(' ', Console.WindowWidth));

                Console.SetCursorPosition(GetLeftPadding(consoleInfo, line), topPadding);
                Console.WriteLine(line);
                topPadding++;
            }
        }
        private static string[] GetLines(string text)
        {
            return text.Split(new[] { '\n' });
        }
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
        private static int GetLeftPadding(Dictionary<string, int> consoleInfo, string line)
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
        public static void RewriteCurrentLine(string newText, int currentCursorTop)
        {
            ClearLine(currentCursorTop);

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
