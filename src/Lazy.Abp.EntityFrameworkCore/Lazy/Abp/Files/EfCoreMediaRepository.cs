using Lazy.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Files
{
    public class EfCoreMediaRepository : EfCoreRepository<ILazyAbpDbContext, Media, Guid>,
        IMediaRepository, ITransientDependency
    {
        public EfCoreMediaRepository(
            IDbContextProvider<ILazyAbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Media> GetByMd5Async(string md5, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(q => q.Md5 == md5)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            int? minSize = null,
            int? maxSize = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(minSize, maxSize, creationAfter, creationBefore, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Media>> GetListAsync(
            int? minSize = null,
            int? maxSize = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(minSize, maxSize, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? nameof(Media.CreationTime) + " DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        private async Task<IQueryable<Media>> GetListQuery(
            int? minSize = null,
            int? maxSize = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .WhereIf(minSize.HasValue, q => q.Size >= minSize)
                .WhereIf(maxSize.HasValue, q => q.Size <= maxSize)
                .WhereIf(creationAfter.HasValue, q => q.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, q => q.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrWhiteSpace(),
                    q => false
                    || q.Md5.Contains(filter)
                    || q.Url.Contains(filter)
                );
        }
    }
}
