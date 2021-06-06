using Lazy.Abp.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Notifications
{
    public class UserNotificationChangeReadStateDto
    {
        [Required]
        public long NotificationId { get; set; }

        [Required]
        public NotificationReadState ReadState { get; set; } = NotificationReadState.Read;
    }
}
