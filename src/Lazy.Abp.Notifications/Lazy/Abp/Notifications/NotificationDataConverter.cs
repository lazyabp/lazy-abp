﻿using Newtonsoft.Json;

namespace Lazy.Abp.Notifications
{
    public class NotificationDataConverter
    {
        public static NotificationData Convert(NotificationData notificationData)
        {
            if (notificationData != null)
            {
                if (notificationData.NeedLocalizer())
                {
                    // 潜在的空对象引用修复
                    if (notificationData.Properties.TryGetValue("title", out object title) && title != null)
                    {
                        var titleObj = JsonConvert.DeserializeObject<LocalizableStringInfo>(title.ToString());
                        notificationData.TrySetData("title", titleObj);
                    }
                    if (notificationData.Properties.TryGetValue("message", out object message) && message != null)
                    {
                        var messageObj = JsonConvert.DeserializeObject<LocalizableStringInfo>(message.ToString());
                        notificationData.TrySetData("message", messageObj);
                    }

                    if (notificationData.Properties.TryGetValue("description", out object description) && description != null)
                    {
                        notificationData.TrySetData("description", JsonConvert.DeserializeObject<LocalizableStringInfo>(description.ToString()));
                    }
                }
            }
            else
            {
                notificationData = new NotificationData();
            }
            return notificationData;
        }
    }
}
