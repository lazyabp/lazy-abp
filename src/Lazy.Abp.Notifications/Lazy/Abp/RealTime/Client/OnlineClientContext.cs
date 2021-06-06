using System;

namespace Lazy.Abp.RealTime.Client
{
    public class OnlineClientContext
    {
        public Guid? TenantId { get; }

        public Guid UserId { get; }

        public OnlineClientContext(Guid? tenantId, Guid userId)
        {
            TenantId = tenantId;
            UserId = userId;
        }
    }
}
