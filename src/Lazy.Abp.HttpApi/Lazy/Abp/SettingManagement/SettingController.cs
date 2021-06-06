﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.SettingManagement
{
    [RemoteService(Name = AbpSettingManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("settingManagement")]
    [Route("api/setting-management/settings")]
    public class SettingController : AbpController, ISettingAppService
    {
        private readonly ISettingAppService _settingAppService;
        public SettingController(ISettingAppService settingAppService)
        {
            _settingAppService = settingAppService;
        }

        [HttpPut]
        [Route("change-current-tenant")]
        public virtual async Task SetCurrentTenantAsync(UpdateSettingsDto input)
        {
            await _settingAppService.SetCurrentTenantAsync(input);
        }

        [HttpPut]
        [Route("change-global")]
        public virtual async Task SetGlobalAsync(UpdateSettingsDto input)
        {
            await _settingAppService.SetGlobalAsync(input);
        }

        [HttpGet]
        [Route("by-global")]
        public virtual async Task<ListResultDto<SettingGroupDto>> GetAllForGlobalAsync()
        {
            return await _settingAppService.GetAllForGlobalAsync();
        }

        [HttpGet]
        [Route("by-current-tenant")]
        public virtual async Task<ListResultDto<SettingGroupDto>> GetAllForCurrentTenantAsync()
        {
            return await _settingAppService.GetAllForCurrentTenantAsync();
        }
    }
}
