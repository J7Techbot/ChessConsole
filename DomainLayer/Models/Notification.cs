using HW2.Enums;

namespace HW2.Models
{
    public class Notification
    {
        public NotificationType NotificationType { get; set; }
        public object Param { get; set; } 

        public Notification(NotificationType notificationType)
        {
            NotificationType = notificationType;
        }
    }

}
