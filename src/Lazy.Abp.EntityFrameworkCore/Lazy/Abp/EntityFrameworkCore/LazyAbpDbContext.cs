using Lazy.Abp.Files;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.EntityFrameworkCore
{
    [ConnectionStringName(LazyAbpDbProperties.ConnectionStringName)]
    public class LazyAbpDbContext : AbpDbContext<LazyAbpDbContext>, ILazyAbpDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public LazyAbpDbContext(DbContextOptions<LazyAbpDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureLazyAbp();
        }
    }
}