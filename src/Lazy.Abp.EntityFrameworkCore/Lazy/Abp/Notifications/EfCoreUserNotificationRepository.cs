﻿using Lazy.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Notifications
{
    public class EfCoreUserNotificationRepository : EfCoreRepository<ILazyAbpDbContext, UserNotification, long>,
        IUserNotificationRepository, ITransientDependency
    {
        public EfCoreUserNotificationRepository(
            IDbContextProvider<ILazyAbpDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> AnyAsync(
            Guid userId, 
            long notificationId,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .AnyAsync(x => x.NotificationId.Equals(notificationId) && x.UserId.Equals(userId),
                    GetCancellationToken(cancellationToken));
        }

        public virtual async Task InsertUserNotificationsAsync(
            IEnumerable<UserNotification> userNotifications,
            CancellationToken cancellationToken = default)
        {
            await (await GetDbSetAsync()).AddRangeAsync(userNotifications, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<UserNotification> GetByIdAsync(
            Guid userId,
            long notificationId,
            CancellationToken cancellationToken = default)
        {
            var userNofitication = await (await GetDbSetAsync())
                .Where(x => x.NotificationId.Equals(notificationId) && x.UserId.Equals(userId))
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            return userNofitication;
        }

        public virtual async Task<List<Notification>> GetNotificationsAsync(
            Guid userId,
            NotificationReadState? readState = null,
            int maxResultCount = 10,
            CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var userNotifilerQuery = dbContext.Set<UserNotification>()
                                              .Where(x => x.UserId == userId)
                                              .WhereIf(readState.HasValue, x => x.ReadStatus == readState.Value);

            var notifilerQuery = from un in userNotifilerQuery
                                 join n in dbContext.Set<Notification>()
                                         on un.NotificationId equals n.NotificationId
                                 select n;

            return await notifilerQuery
                .OrderBy(nameof(Notification.CreationTime) + " DESC")
                .Take(maxResultCount)
                .AsNoTracking()
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<int> GetCountAsync(
            Guid userId, 
            string filter = "",
            NotificationReadState? readState = null,
            CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            var userNotifilerQuery = dbContext.Set<UserNotification>()
                                              .Where(x => x.UserId == userId)
                                              .WhereIf(readState.HasValue, x => x.ReadStatus == readState.Value);

            var notifilerQuery = from un in userNotifilerQuery
                                 join n in dbContext.Set<Notification>()
                                         on un.NotificationId equals n.NotificationId
                                 select n;

            return await notifilerQuery
                .WhereIf(!filter.IsNullOrWhiteSpace(), nf =>
                    nf.NotificationName.Contains(filter) ||
                    nf.NotificationTypeName.Contains(filter))
                .CountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Notification>> GetListAsync(
            Guid userId, 
            string filter = "",
            string sorting = nameof(Notification.CreationTime),
            bool reverse = true,
            NotificationReadState? readState = null,
            int skipCount = 1,
            int maxResultCount = 10,
            CancellationToken cancellationToken = default)
        {
            sorting ??= nameof(Notification.CreationTime);
            sorting = reverse ? sorting + " DESC" : sorting;

            var dbContext = await GetDbContextAsync();
            var userNotifilerQuery = dbContext.Set<UserNotification>()
                                              .Where(x => x.UserId == userId)
                                              .WhereIf(readState.HasValue, x => x.ReadStatus == readState.Value);

            var notifilerQuery = from un in userNotifilerQuery
                                 join n in dbContext.Set<Notification>()
                                         on un.NotificationId equals n.NotificationId
                                 select n;

            return await notifilerQuery
                .WhereIf(!filter.IsNullOrWhiteSpace(), nf =>
                    nf.NotificationName.Contains(filter) ||
                    nf.NotificationTypeName.Contains(filter))
                .OrderBy(sorting)
                .PageBy(skipCount, maxResultCount)
                .AsNoTracking()
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
