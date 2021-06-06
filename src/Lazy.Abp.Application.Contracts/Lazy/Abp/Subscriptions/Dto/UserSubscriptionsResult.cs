namespace Lazy.Abp.Subscriptions
{
    public class UserSubscriptionsResult
    {
        public bool IsSubscribed { get; }

        public UserSubscriptionsResult(bool isSubscribed)
        {
            IsSubscribed = isSubscribed;
        }

        public static UserSubscriptionsResult Subscribed()
        {
            return new UserSubscriptionsResult(true);
        }

        public static UserSubscriptionsResult UnSubscribed()
        {
            return new UserSubscriptionsResult(false);
        }
    }
}
