using HW2.Models;

namespace HW2.Helpers
{
    /// <summary>
    /// It contains methods that facilitate working with piece positions.
    /// </summary>
    public static class PositionHelper
    {
        private static readonly Dictionary<string, int> map = new Dictionary<string, int>()
        {
            {"a", 0},
            {"b", 1},
            {"c", 2},
            {"d", 3},
            {"e", 4},
            {"f", 5},
            {"g", 6},
            {"h", 7},
        };

        /// <summary>
        /// It checks if the provided input contains a valid position on the game board, i.e., one letter and one number.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is valid</returns>
        public static bool ValidateInput(string input)
        {
            return ExtractLetter(input) != -1 && ExtractNumber(input) != -1;
        }

        /// <summary>
        /// It parses the provided input from string to Position.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Position ParseInput(string input)
        {
            return new Position(x: RevertNumberToIndex(ExtractNumber(input)), y: ExtractLetter(input));
        }

        /// <summary>
        /// It extracts the letter from the input and checks if it is present on the game board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>It returns -1 if the input does not contain a letter or the letter is not present on the game board.</returns>
        private static int ExtractLetter(string input)
        {
            string letter = input.First(ch => char.IsLetter(ch)).ToString().ToLower();

            if (map.ContainsKey(letter))
                return map[letter];
            else
                return -1;
        }

        /// <summary>
        /// It extracts the number from the input and checks if it is present on the game board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>It returns -1 if the input does not contain a number or the number is not present on the game board.</returns>
        private static int ExtractNumber(string input)
        {
            int number = int.Parse(input.First(ch => char.IsDigit(ch)).ToString());

            if (number < 9)
                return number;
            else
                return -1;
        }

        /// <summary>
        /// Due to the fact that numbers on the board start from the lower-left corner, but array indices start from the upper-left corner,
        /// it is necessary to convert the input number into an array index.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Transformed number to index</returns>
        private static int RevertNumberToIndex(int number)
        {
            return 8 - number;
        }

        /// <summary>
        /// It calculates all horizontal positions on the board from the current position.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="distance">Optional: Maximum distance of fields from the current position.</param>
        /// <param name="lenght">Optional: Lenght of board row.</param>
        /// <returns></returns>
        public static List<Position> GetHorizontals(Position currentPosition,int distance = 8,int lenght = 8)
        {
            List<Position> positions = new List<Position>();

            int floor = (currentPosition.Y - distance) < 0 ? 0 : currentPosition.Y - distance;
            int ceil = (currentPosition.Y + distance) >= lenght ? lenght : currentPosition.Y + distance;

            for (int i = floor; i <= ceil; i++)
            {
                if (i >= 0 && i < lenght && i != currentPosition.Y)
                {
                    positions.Add(new Position(currentPosition.X, i));
                }
            }

            return positions;
        }

        /// <summary>
        /// It calculates all vertical positions on the board from the current position.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="distance">Optional: Maximum distance of fields from the current position.</param>
        /// <param name="lenght">Optional: Lenght of board columns.</param>
        /// <returns></returns>
        public static List<Position> GetVerticals(Position currentPosition, int distance = 8, int lenght = 8)
        {
            List<Position> positions = new List<Position>();

            int floor = (currentPosition.X - distance) < 0 ? 0 : currentPosition.X - distance;
            int ceil = (currentPosition.X + distance) >= lenght ? lenght : currentPosition.X + distance;

            for (int i = floor; i <= ceil; i++)
            {
                if (i >= 0 && i < lenght && i != currentPosition.X)
                {
                    positions.Add(new Position(i,currentPosition.Y));
                }
            }

            return positions;
        }

        /// <summary>
        ///  It calculates all diagonal positions on the board from the current position.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="distance">Optional: Maximum distance of fields from the current position.</param>
        /// <param name="lenght">Optional: Lenght of board rows and columns.</param>
        /// <returns></returns>
        public static List<Position> GetDiagonals(Position currentPosition, int distance = 8, int lenght = 8)
        {
            List<Position> positions = new List<Position>();
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    int rowDistance = Math.Abs(i - currentPosition.X);
                    int columnDistance = Math.Abs(j - currentPosition.Y);

                    if (rowDistance == columnDistance && columnDistance <= distance && rowDistance <= distance)
                    {
                        positions.Add(new Position(i, j));
                    }
                }
            }
            return positions;
        }
    }
}
