using System.Collections.Generic;

namespace Lazy.Abp.Notifications
{
    public class NotificationGroupDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<NotificationDto> Notifications { get; set; } = new List<NotificationDto>();
    }
}
