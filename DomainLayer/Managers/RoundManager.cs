using HW2.Enums;
using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Managers
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
