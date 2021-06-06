using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Notifications
{
    public class NotificationGetByIdDto
    {
        [Required]
        public long NotificationId { get; set; }
    }
}
