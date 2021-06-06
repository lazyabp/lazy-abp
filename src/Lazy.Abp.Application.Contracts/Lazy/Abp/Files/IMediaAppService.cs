using Lazy.Abp.Files.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Files
{
    public interface IMediaAppService : IApplicationService
    {
        Task<MediaDto> GetAsync(Guid id);

        Task<MediaDto> GetByMd5Async(string md5);

        Task<PagedResultDto<MediaDto>> GetListAsync(MediaListRequestDto input);

        Task<MediaDto> CreateAsync(MediaCreateDto input);

        Task DeleteAsync(Guid id);
    }
}
