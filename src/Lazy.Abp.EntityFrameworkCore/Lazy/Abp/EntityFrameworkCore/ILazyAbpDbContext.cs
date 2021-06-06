using Lazy.Abp.Files;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.EntityFrameworkCore
{
    [ConnectionStringName(LazyAbpDbProperties.ConnectionStringName)]
    public interface ILazyAbpDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Media> Medias { get; }
    }
}