using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService : 
        ICrudAppService<
            ApiResourceDto,
            Guid,
            ApiResourceGetByPagedInputDto,
            ApiResourceCreateDto,
            ApiResourceUpdateDto>
    {
    }
}
