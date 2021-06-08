using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.EntityFrameworkCore
{
    public class AbpHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpHttpApiHostMigrationsDbContext>
    {
        public AbpHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Abp"));

            return new AbpHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
