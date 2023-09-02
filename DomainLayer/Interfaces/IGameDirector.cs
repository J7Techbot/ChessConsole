using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IGameDirector
    {
        GameStatus MakeMove(Position selectedPiecePosition, Position targetPosition, out Notification notification);
        GameStatus GetGameStatus();
        void InitNewRound(out Notification notification);
    }
}
