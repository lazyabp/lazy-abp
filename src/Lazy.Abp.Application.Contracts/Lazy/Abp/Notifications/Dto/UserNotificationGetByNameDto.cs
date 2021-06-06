using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Notifications
{
    public class UserNotificationGetByNameDto
    {
        [Required]
        [StringLength(NotificationConsts.MaxNameLength)]
        public string NotificationName { get; set; }
    }
}
