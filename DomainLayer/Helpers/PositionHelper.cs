using HW2.Models;

namespace HW2.Helpers
{
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

        public static bool ValidateInput(string input)
        {
            return ExtractLetter(input) != -1 && ExtractNumber(input) != -1;
        }

        public static Position ParseInput(string input)
        {
            return new Position(x: RevertNumberToIndex(ExtractNumber(input)), y: ExtractLetter(input));
        }

        private static int ExtractLetter(string input)
        {
            string letter = input.First(ch => char.IsLetter(ch)).ToString().ToLower();

            if (map.ContainsKey(letter))
                return map[letter];
            else
                return -1;
        }

        private static int ExtractNumber(string input)
        {
            int number = int.Parse(input.First(ch => char.IsDigit(ch)).ToString());

            if (number < 9)
                return number;
            else
                return -1;
        }

        private static int RevertNumberToIndex(int number)
        {
            return 8 - number;
        }

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
