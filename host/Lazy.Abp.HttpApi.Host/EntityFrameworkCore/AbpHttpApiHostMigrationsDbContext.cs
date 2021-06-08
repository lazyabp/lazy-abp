using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.EntityFrameworkCore
{
    public class AbpHttpApiHostMigrationsDbContext : AbpDbContext<AbpHttpApiHostMigrationsDbContext>
    {
        public AbpHttpApiHostMigrationsDbContext(DbContextOptions<AbpHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureLazyAbp();
        }
    }
}
