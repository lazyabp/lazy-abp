﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.TenantManagement
{
    public interface ITenantAppService : ICrudAppService<TenantDto, Guid, TenantGetByPagedInputDto, TenantCreateDto, TenantUpdateDto>
    {
        Task<TenantDto> GetAsync(TenantGetByNameInputDto tenantGetByNameInput);

        Task<TenantConnectionStringDto> GetConnectionStringAsync(TenantConnectionGetByNameInputDto tenantConnectionGetByName);

        Task<ListResultDto<TenantConnectionStringDto>> GetConnectionStringAsync(Guid id);

        Task<TenantConnectionStringDto> SetConnectionStringAsync(Guid id, TenantConnectionStringCreateOrUpdateDto tenantConnectionStringCreateOrUpdate);

        Task DeleteConnectionStringAsync(TenantConnectionGetByNameInputDto tenantConnectionGetByName);
    }
}
