using Lazy.Abp.Notifications;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Notifications
{
    public class UserNotificationGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public bool Reverse { get; set; }

        public NotificationReadState? ReadState { get; set; }
    }
}
