using HW2.Enums;

namespace HW2.Managers
{
    public class RoundManager
    {
        public int CurrentRound { get; private set; } = 1;
        public Color CurrentPlayer { get; private set; } = Color.WHITE;

        public void NextRound()
        {
            CurrentRound++;

            CurrentPlayer = CurrentPlayer == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}
