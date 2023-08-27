using HW2.Models;

namespace HW2.Interfaces
{
    public interface IInvalidMoveTrigger
    {
        public Action<Notification> InvalidMoveEvent { get; set; }
    }
}
