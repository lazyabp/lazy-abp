using Lazy.Abp.Core.Proxy;
using Lazy.Abp.Core.Proxy.Dtos;
using Lazy.Abp.Files.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Lazy.Abp.Files
{
    [RemoteService(Name = LazyAbpServiceConsts.RemoteServiceName)]
    [Area("media")]
    [Route("api/media/upload")]
    public class UploadController : LazyAbpController
    {
        private readonly IMediaAppService _service;
        private readonly IFastDFSProxyService _fastDFSService;

        public UploadController(
            IMediaAppService service,
            IFastDFSProxyService fastDFSService
        )
        {
            _service = service;
            _fastDFSService = fastDFSService;
        }

        [HttpPost]
        [Route("url")]
        public async Task<MediaDto> UploadUrlAsync(FastDFSFileUrlRequestDto input)
        {
            var file = await _fastDFSService.UploadUrlAsync(input);

            return await _service.CreateAsync(new MediaCreateDto
            {
                Url = file.Data.Url,
                Md5 = file.Data.Md5,
                MimeType = "",
                Path = file.Data.Path,
                Domain = file.Data.Domain,
                Scene = file.Data.Scene,
                Size = file.Data.Size,
                Mtime = file.Data.MTime,
                Scenes = file.Data.Scenes,
                Src = file.Data.Src
            });
        }

        [HttpPost]
        [Route("bulk-urls")]
        public async Task<List<MediaDto>> UploadUrlsAsync(FastDFSFileUrlsRequestDto input)
        {
            var response = await _fastDFSService.UploadUrlsAsync(input);
            var result = new List<MediaDto>();

            foreach(var file in response.Data)
            {
                var media = await _service.CreateAsync(new MediaCreateDto
                {
                    Url = file.Url,
                    Md5 = file.Md5,
                    MimeType = "",
                    Path = file.Path,
                    Domain = file.Domain,
                    Scene = file.Scene,
                    Size = file.Size,
                    Mtime = file.MTime,
                    Scenes = file.Scenes,
                    Src = file.Src
                });

                result.Add(media);
            }

            return result;
        }

        [HttpPost]
        [Route("stream")]
        public async Task<MediaDto> UploadStreamAsync([FromForm] IFormCollection formCollection)
        {
            var file = await _fastDFSService.UploadStreamAsync(formCollection);

            return await _service.CreateAsync(new MediaCreateDto
            {
                Url = file.Data.Url,
                Md5 = file.Data.Md5,
                MimeType = "",
                Path = file.Data.Path,
                Domain = file.Data.Domain,
                Scene = file.Data.Scene,
                Size = file.Data.Size,
                Mtime = file.Data.MTime,
                Scenes = file.Data.Scenes,
                Src = file.Data.Src
            });
        }

        [HttpPost]
        [Route("base64")]
        public async Task<MediaDto> UploadBase64Async(FastDFSFileBase64RequestDto input)
        {
            var file = await _fastDFSService.UploadBase64Async(input);

            return await _service.CreateAsync(new MediaCreateDto
            {
                Url = file.Data.Url,
                Md5 = file.Data.Md5,
                MimeType = input.MediaType,
                Path = file.Data.Path,
                Domain = file.Data.Domain,
                Scene = file.Data.Scene,
                Size = file.Data.Size,
                Mtime = file.Data.MTime,
                Scenes = file.Data.Scenes,
                Src = file.Data.Src
            });
        }
    }
}
