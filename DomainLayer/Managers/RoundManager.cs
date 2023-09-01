using HW2.Enums;

namespace HW2.Managers
{
    public class RoundManager
    {
        public int CurrentRound { get; private set; } = 1;
        public Color CurrentPlayerColor { get; private set; } = Color.WHITE;

        public void NextRound()
        {
            CurrentRound++;

            CurrentPlayerColor = CurrentPlayerColor == Color.WHITE ? Color.BLACK : Color.WHITE;
        }
    }
}
