using Lazy.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Notifications
{
    public class EfCoreNotificationRepository : EfCoreRepository<ILazyAbpDbContext, Notification, long>,
        INotificationRepository, ITransientDependency
    {
        public EfCoreNotificationRepository(
            IDbContextProvider<ILazyAbpDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task DeleteExpritionAsync(
            int batchCount,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            var batchDeleteNoticeWithIds = await dbSet
                .Where(x => x.ExpirationTime <= DateTime.Now)
                .Take(batchCount)
                .Select(x => new Notification(x.Id))
                .AsNoTracking()
                .ToArrayAsync(GetCancellationToken(cancellationToken));

            dbSet.AttachRange(batchDeleteNoticeWithIds);
            dbSet.RemoveRange(batchDeleteNoticeWithIds);
        }

        public async Task<Notification> GetByIdAsync(
            long notificationId,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(x => x.NotificationId.Equals(notificationId))
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}
