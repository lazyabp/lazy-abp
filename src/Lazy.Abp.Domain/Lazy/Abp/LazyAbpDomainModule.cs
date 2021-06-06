using Lazy.Abp.Mapper;
using Lazy.Abp.Utils;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.TenantManagement;

namespace Lazy.Abp
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(LazyAbpDomainSharedModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpEmailingModule)
    )]
    public class LazyAbpDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<LazyAbpDomainAutoMapperProfile>(validate: true);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context
                .ServiceProvider
                .GetRequiredService<SnowflakeIdGenerator>()
                .Initialize();
        }
    }
}
