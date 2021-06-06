using System.Collections.Generic;

namespace Lazy.Abp.Notifications
{
    public interface INotificationPublishProviderManager
    {
        List<INotificationPublishProvider> Providers { get; }
    }
}
