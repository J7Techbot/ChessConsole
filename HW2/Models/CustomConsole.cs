using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Models
{
    public static class CustomConsole
    {
        public static void WriteLineCentered(string text)
        {
            string[] lines = text.Split(new[] { '\n' });

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int originalCursorTop = Console.CursorTop;

            int topPadding = (windowHeight - lines.Length) / 2;

            foreach (string line in lines)
            {
                int leftPadding = (windowWidth - line.Length) / 2;
                Console.SetCursorPosition(leftPadding, topPadding);
                Console.WriteLine(line);
                topPadding++;
            }

            Console.SetCursorPosition(0, originalCursorTop + lines.Length);
        }
    }
}
