using Lazy.Abp.Core.Proxy;
using Lazy.Abp.Files.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Files
{
    [RemoteService(Name = LazyAbpServiceConsts.RemoteServiceName)]
    [Area("media")]
    [Route("api/media")]
    public class MediaController : LazyAbpController, IMediaAppService
    {
        private readonly IMediaAppService _service;

        public MediaController(
            IMediaAppService service
        )
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<MediaDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("by-md5/{md5}")]
        public Task<MediaDto> GetByMd5Async(string md5)
        {
            return _service.GetByMd5Async(md5);
        }

        [HttpGet]
        public Task<PagedResultDto<MediaDto>> GetListAsync(MediaListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<MediaDto> CreateAsync(MediaCreateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
