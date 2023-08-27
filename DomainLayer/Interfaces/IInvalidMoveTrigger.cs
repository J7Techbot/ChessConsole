using HW2.Models;

namespace HW2.Interfaces
{
    public interface IInvalidMoveTrigger
    {
        public Action<InvalidStatus> InvalidMoveEvent { get; set; }
    }
}
