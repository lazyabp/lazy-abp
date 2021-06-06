using AutoMapper;
using Lazy.Abp.Notifications;
using Lazy.Abp.Subscriptions;

namespace Lazy.Abp.Mapper
{
    public class LazyAbpDomainAutoMapperProfile : Profile
    {
        public LazyAbpDomainAutoMapperProfile()
        {
            CreateMap<Notification, NotificationInfo>()
                .ConvertUsing<NotificationTypeConverter>();

            CreateMap<UserSubscribe, NotificationSubscriptionInfo>();
        }
    }
}
