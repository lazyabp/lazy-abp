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

namespace Lazy.Abp.Subscriptions
{
    public class EfCoreUserSubscribeRepository : EfCoreRepository<ILazyAbpDbContext, UserSubscribe, long>,
        IUserSubscribeRepository, ITransientDependency
    {
        public EfCoreUserSubscribeRepository(
            IDbContextProvider<ILazyAbpDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public virtual async Task<List<UserSubscribe>> GetUserSubscribesAsync(
            string notificationName, 
            IEnumerable<Guid> userIds = null,
            CancellationToken cancellationToken = default)
        {
            var userSubscribes = await (await GetDbSetAsync())
                .Distinct()
                .Where(x => x.NotificationName.Equals(notificationName))
                .WhereIf(userIds != null, x => userIds.Contains(x.UserId))
                .AsNoTracking()
                .ToListAsync(GetCancellationToken(cancellationToken));

            return userSubscribes;
        }

        public virtual async Task<UserSubscribe> GetUserSubscribeAsync(
            string notificationName, 
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            var userSubscribe = await (await GetDbSetAsync())
                .Where(x => x.UserId.Equals(userId) && x.NotificationName.Equals(notificationName))
                .AsNoTracking()
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            return userSubscribe;
        }

        public virtual async Task<List<string>> GetUserSubscribesAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            var userSubscribeNames = await (await GetDbSetAsync())
                .Distinct()
                .Where(x => x.UserId.Equals(userId))
                .Select(x => x.NotificationName)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return userSubscribeNames;
        }

        public virtual async Task<List<UserSubscribe>> GetUserSubscribesByNameAsync(
            string userName,
            CancellationToken cancellationToken = default)
        {
            var userSubscribeNames = await (await GetDbSetAsync())
                .Distinct()
                .Where(x => x.UserName.Equals(userName))
                .AsNoTracking()
                .ToListAsync(GetCancellationToken(cancellationToken));

            return userSubscribeNames;
        }

        public virtual async Task<List<Guid>> GetUserSubscribesAsync(
            string notificationName,
            CancellationToken cancellationToken = default)
        {
            var subscribeUsers = await (await GetDbSetAsync())
                .Distinct()
                .Where(x => x.NotificationName.Equals(notificationName))
                .Select(x => x.UserId)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return subscribeUsers;
        }

        public virtual async Task InsertUserSubscriptionAsync(
            IEnumerable<UserSubscribe> userSubscribes,
            CancellationToken cancellationToken = default)
        {
            await (await GetDbSetAsync()).AddRangeAsync(userSubscribes, GetCancellationToken(cancellationToken));
        }

        public virtual async Task DeleteUserSubscriptionAsync(
            string notificationName,
            CancellationToken cancellationToken = default)
        {
            var userSubscribes = await (await GetDbSetAsync()).Where(x => x.NotificationName.Equals(notificationName))
                .ToListAsync(GetCancellationToken(cancellationToken));
            (await GetDbSetAsync()).RemoveRange(userSubscribes);
        }

        public virtual async Task DeleteUserSubscriptionAsync(
            IEnumerable<UserSubscribe> userSubscribes,
            CancellationToken cancellationToken = default)
        {
            await DeleteManyAsync(userSubscribes);
        }

        public virtual async Task DeleteUserSubscriptionAsync(
            string notificationName, 
            IEnumerable<Guid> userIds,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync(usr => usr.NotificationName == notificationName && userIds.Contains(usr.UserId),
                false,
                GetCancellationToken(cancellationToken));
        }

        public virtual async Task<bool> UserSubscribeExistsAysnc(
            string notificationName, 
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .AnyAsync(x => x.UserId.Equals(userId) && x.NotificationName.Equals(notificationName),
                    GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<UserSubscribe>> GetUserSubscribesAsync(
            Guid userId, 
            string sorting = "Id", 
            int skipCount = 1,
            int maxResultCount = 10,
            CancellationToken cancellationToken = default)
        {
            var userSubscribes = await (await GetDbSetAsync())
                 .Distinct()
                 .Where(x => x.UserId.Equals(userId))
                 .OrderBy(sorting ?? nameof(UserSubscribe.Id))
                 .Page(skipCount, maxResultCount)
                 .AsNoTracking()
                 .ToListAsync(GetCancellationToken(cancellationToken));

            return userSubscribes;
        }

        public virtual async Task<long> GetCountAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            var userSubscribedCount = await (await GetDbSetAsync())
                 .Distinct()
                 .Where(x => x.UserId.Equals(userId))
                 .LongCountAsync(GetCancellationToken(cancellationToken));

            return userSubscribedCount;
        }
    }
}
