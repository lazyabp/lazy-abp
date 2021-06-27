using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Lazy.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.AuditLogging;
using Volo.Abp.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.BackgroundJobs;
using Lazy.Abp.MediaKit;

namespace Lazy.Abp
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(MediaKitDomainSharedModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpPermissionManagementDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule),
        typeof(AbpFeatureManagementDomainSharedModule)
    )]
    public class LazyAbpDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<LazyAbpDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<LazyAbpResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Lazy/Abp/Localization/LazyAbp");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("LazyAbp", typeof(LazyAbpResource));
            });
        }
    }
}
