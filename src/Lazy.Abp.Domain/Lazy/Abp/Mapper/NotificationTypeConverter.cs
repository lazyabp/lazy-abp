﻿using AutoMapper;
using Lazy.Abp.Notifications;
using Newtonsoft.Json;
using System;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Mapper
{
    public class NotificationTypeConverter : ITypeConverter<Notification, NotificationInfo>, ISingletonDependency
    {
        public NotificationInfo Convert(Notification source, NotificationInfo destination, ResolutionContext context)
        {
            destination = new NotificationInfo
            {
                Name = source.NotificationName,
                Type = source.Type,
                Severity = source.Severity,
                CreationTime = source.CreationTime,
                TenantId = source.TenantId
            };
            destination.SetId(source.NotificationId);

            var dataType = Type.GetType(source.NotificationTypeName);
            Check.NotNull(dataType, source.NotificationTypeName);

            var data = JsonConvert.DeserializeObject(source.NotificationData, dataType);
            if (data != null && data is NotificationData notificationData)
            {
                destination.Data = NotificationDataConverter.Convert(notificationData);
            }
            else
            {
                destination.Data = new NotificationData();
                destination.Data.TrySetData("data", source.NotificationData);
            }
            return destination;
        }
    }
}
