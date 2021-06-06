﻿using Lazy.Abp.Notifications;
using Lazy.Abp.Notifications.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace Lazy.Abp
{
    [DependsOn(
        typeof(AbpBackgroundJobsModule),
        typeof(AbpJsonModule))]
    public class LazyAbpNotificationsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AutoAddDefinitionProviders(context.Services);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<AbpNotificationCleanupOptions>>().Value;
            if (options.IsEnabled)
            {
                context.ServiceProvider
                    .GetRequiredService<IBackgroundWorkerManager>()
                    .Add(
                        context.ServiceProvider
                            .GetRequiredService<NotificationCleanupBackgroundWorker>()
                    );
            }
        }

        private static void AutoAddDefinitionProviders(IServiceCollection services)
        {
            var definitionProviders = new List<Type>();

            services.OnRegistred(context =>
            {
                if (typeof(INotificationDefinitionProvider).IsAssignableFrom(context.ImplementationType))
                {
                    definitionProviders.Add(context.ImplementationType);
                }
            });

            services.Configure<AbpNotificationOptions>(options =>
            {
                services.ExecutePreConfiguredActions(options);
                options.DefinitionProviders.AddIfNotContains(definitionProviders);
            });
        }
    }
}
