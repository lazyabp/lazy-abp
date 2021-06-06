using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Notifications
{
    public interface IMyNotificationAppService :
        IReadOnlyAppService<NotificationInfo, long, UserNotificationGetByPagedDto>,
        IDeleteAppService<long>
    {
        Task SendNofiterAsync(NotificationSendDto input);

        Task<ListResultDto<NotificationGroupDto>> GetAssignableNotifiersAsync();
    }
}
