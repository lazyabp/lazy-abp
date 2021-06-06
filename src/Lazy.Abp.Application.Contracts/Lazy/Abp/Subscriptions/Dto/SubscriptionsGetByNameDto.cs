using Lazy.Abp.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Subscriptions
{
    public class SubscriptionsGetByNameDto
    {
        [Required]
        [StringLength(NotificationConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
