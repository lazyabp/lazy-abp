﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Auditing.Logging
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultDto<AuditLogDto>> GetListAsync(AuditLogGetByPagedDto input);

        Task<AuditLogDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
