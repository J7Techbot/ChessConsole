using HW2.Enums;

namespace HW2.Models
{
    /// <summary>
    /// It defines the format of the notification presented to the user on the UI.
    /// </summary>
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
