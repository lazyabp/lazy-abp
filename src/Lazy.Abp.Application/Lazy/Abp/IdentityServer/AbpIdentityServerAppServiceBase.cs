﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.IdentityServer.Localization;

namespace Lazy.Abp.IdentityServer
{
    public abstract class AbpIdentityServerAppServiceBase : ApplicationService
    {
        protected IPermissionChecker PermissionChecker => LazyServiceProvider.LazyGetRequiredService<IPermissionChecker>();
        protected AbpIdentityServerAppServiceBase()
        {
            LocalizationResource = typeof(AbpIdentityServerResource);
        }

        protected virtual async Task<bool> IsGrantAsync(string policy)
        {
            return await PermissionChecker.IsGrantedAsync(policy);
        }
    }
}
