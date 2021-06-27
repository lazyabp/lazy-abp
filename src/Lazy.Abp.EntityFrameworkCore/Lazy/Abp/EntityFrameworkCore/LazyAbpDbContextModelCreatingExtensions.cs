using System;
using Lazy.Abp.Files;
using Lazy.Abp.Notifications;
using Lazy.Abp.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.EntityFrameworkCore
{
    public static class LazyAbpDbContextModelCreatingExtensions
    {
        public static void ConfigureLazyAbp(
            this ModelBuilder builder,
            Action<LazyAbpModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new LazyAbpModelBuilderConfigurationOptions(
                LazyAbpDbProperties.DbTablePrefix,
                LazyAbpDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Notification>(b =>
            {
                b.ToTable(options.TablePrefix + "Notifications", options.Schema);

                b.Property(p => p.NotificationName).HasMaxLength(NotificationConsts.MaxNameLength).IsRequired();
                b.Property(p => p.NotificationTypeName).HasMaxLength(NotificationConsts.MaxTypeNameLength).IsRequired();
                b.Property(p => p.NotificationData).HasMaxLength(NotificationConsts.MaxDataLength).IsRequired();

                b.ConfigureByConvention();

                b.HasIndex(p => new { p.TenantId, p.NotificationName });
            });

            builder.Entity<UserNotification>(b =>
            {
                b.ToTable(options.TablePrefix + "UserNotifications", options.Schema);

                b.ConfigureByConvention();

                b.HasIndex(p => new { p.TenantId, p.UserId, p.NotificationId })
                .HasDatabaseName("IX_Tenant_User_Notification_Id");
            });

            builder.Entity<UserSubscribe>(b =>
            {
                b.ToTable(options.TablePrefix + "UserSubscribes", options.Schema);

                b.Property(p => p.NotificationName).HasMaxLength(SubscribeConsts.MaxNotificationNameLength).IsRequired();
                b.Property(p => p.UserName)
                    .HasMaxLength(SubscribeConsts.MaxUserNameLength)
                    .HasDefaultValue("/")// 不是必须的
                    .IsRequired();

                b.ConfigureByConvention();

                b.HasIndex(p => new { p.TenantId, p.UserId, p.NotificationName })
                .HasDatabaseName("IX_Tenant_User_Notification_Name")
                .IsUnique();
            });
        }
    }
}