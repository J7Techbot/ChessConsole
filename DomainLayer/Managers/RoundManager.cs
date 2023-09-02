using HW2.Enums;

namespace HW2.Managers
{
    /// <summary>
    /// It keeps track of round information.
    /// </summary>
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
