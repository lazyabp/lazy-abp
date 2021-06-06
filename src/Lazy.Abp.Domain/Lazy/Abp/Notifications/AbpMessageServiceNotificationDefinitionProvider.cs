using Lazy.Abp.Localization;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace Lazy.Abp.Notifications
{
    public class AbpMessageServiceNotificationDefinitionProvider : NotificationDefinitionProvider
    {
        public override void Define(INotificationDefinitionContext context)
        {
            var tenantsGroup = context.AddGroup(
                TenantNotificationNames.GroupName,
                L("Notifications:MultiTenancy"),
                false);

            tenantsGroup.AddNotification(
                TenantNotificationNames.NewTenantRegistered,
                L("Notifications:NewTenantRegisterd"),
                L("Notifications:NewTenantRegisterd"),
                notificationType: NotificationType.System,
                lifetime: NotificationLifetime.OnlyOne,
                allowSubscriptionToClients: false
                )
                .WithProviders();

            var usersGroup = context.AddGroup(
                UserNotificationNames.GroupName,
                L("Notifications:Users"));

            usersGroup.AddNotification(
                UserNotificationNames.WelcomeToApplication,
                L("Notifications:WelcomeToApplication"),
                L("Notifications:WelcomeToApplication"),
                notificationType: NotificationType.System,
                lifetime: NotificationLifetime.OnlyOne,
                allowSubscriptionToClients: true);
        }

        protected LocalizableString L(string name)
        {
            return LocalizableString.Create<LazyAbpResource>(name);
        }
    }
}
