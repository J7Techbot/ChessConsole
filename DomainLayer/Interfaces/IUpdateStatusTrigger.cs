using HW2.Models;

namespace HW2.Interfaces
{
    public interface IUpdateStatusTrigger
    {
        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
    }
}
