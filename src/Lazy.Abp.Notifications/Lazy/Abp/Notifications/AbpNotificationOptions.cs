﻿using Volo.Abp.Collections;

namespace Lazy.Abp.Notifications
{
    // TODO: 需要重命名 AbpNotificationsOptions
    public class AbpNotificationOptions
    {
        /// <summary>
        /// 通知系统对于某个应用的定义
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 自定义通知集合
        /// </summary>
        public ITypeList<INotificationDefinitionProvider> DefinitionProviders { get; }
        /// <summary>
        /// 发布者集合
        /// </summary>
        public ITypeList<INotificationPublishProvider> PublishProviders { get; }
        /// <summary>
        /// 可以自定义某个通知的格式
        /// </summary>
        public NotificationDataMappingDictionary NotificationDataMappings { get; }
        public AbpNotificationOptions()
        {
            Application = "Abp";
            PublishProviders = new TypeList<INotificationPublishProvider>();
            DefinitionProviders = new TypeList<INotificationDefinitionProvider>();
            NotificationDataMappings = new NotificationDataMappingDictionary();
        }
    }
}
