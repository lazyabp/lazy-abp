﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.TenantManagement
{
    [RemoteService(Name = LazyAbpServiceConsts.RemoteServiceName)]
    [Area("tenant-management")]
    [Route("api/tenant-management/tenants")]
    public class TenantController : AbpController, ITenantAppService //TODO: Throws exception on validation if we inherit from Controller
    {
        protected ITenantAppService TenantAppService { get; }

        public TenantController(ITenantAppService tenantAppService)
        {
            TenantAppService = tenantAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TenantDto> GetAsync(Guid id)
        {
            return TenantAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TenantDto>> GetListAsync(TenantGetByPagedInputDto input)
        {
            return TenantAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            ValidateModel();
            return TenantAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
        {
            return TenantAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return TenantAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}/connection-string/{name}")]
        public virtual Task<TenantConnectionStringDto> GetConnectionStringAsync(TenantConnectionGetByNameInputDto tenantConnectionGetByName)
        {
            return TenantAppService.GetConnectionStringAsync(tenantConnectionGetByName);
        }

        [HttpGet]
        [Route("{id}/connection-string")]
        public virtual Task<ListResultDto<TenantConnectionStringDto>> GetConnectionStringAsync(Guid id)
        {
            return TenantAppService.GetConnectionStringAsync(id);
        }

        [HttpPut]
        [Route("{id}/connection-string")]
        public virtual Task<TenantConnectionStringDto> SetConnectionStringAsync(Guid id, TenantConnectionStringCreateOrUpdateDto tenantConnectionStringCreateOrUpdate)
        {
            return TenantAppService.SetConnectionStringAsync(id, tenantConnectionStringCreateOrUpdate);
        }

        [HttpDelete]
        [Route("{id}/connection-string/{name}")]
        public virtual Task DeleteConnectionStringAsync(TenantConnectionGetByNameInputDto tenantConnectionGetByName)
        {
            return TenantAppService.DeleteConnectionStringAsync(tenantConnectionGetByName);
        }

        [HttpGet]
        [Route("name/{name}")]
        public virtual Task<TenantDto> GetAsync(TenantGetByNameInputDto tenantGetByNameInput)
        {
            return TenantAppService.GetAsync(tenantGetByNameInput);
        }
    }
}
