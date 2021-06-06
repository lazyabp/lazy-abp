using Lazy.Abp.AspNetCore.SignalR.JwtToken;
using Lazy.Abp.Notifications;
using Lazy.Abp.Notifications.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace Lazy.Abp
{
    [DependsOn(
        typeof(LazyAbpNotificationsModule),
        typeof(AbpAspNetCoreSignalRModule)
    )]
    public class LazyAbpNotificationsSignalRModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpAspNetCoreSignalRJwtTokenMapPathOptions>(configuration.GetSection("SignalR:MapPath"));

            Configure<AbpNotificationOptions>(options =>
            {
                options.PublishProviders.Add<SignalRNotificationPublishProvider>();
                options.NotificationDataMappings
                       .MappingDefault(SignalRNotificationPublishProvider.ProviderName,
                       data => data);
            });

            Configure<AbpAspNetCoreSignalRJwtTokenMapPathOptions>(options =>
            {
                options.MapPath("notifications");
            });
        }
    }
}
