using Localization.Resources.AbpUi;
using Lazy.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Account;
using Volo.Abp.TenantManagement;
using Lazy.Abp.Core;
using Lazy.Abp.Files;

namespace Lazy.Abp
{
    [DependsOn(
        typeof(LazyAbpApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        //typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(LazyAbpCoreModule)
    )]
    public class LazyAbpHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(LazyAbpHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<LazyAbpResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });

            Configure<UploadTokenVerifyOption>(configuration.GetSection("FastDFSProxy:Default"));
        }
    }
}
