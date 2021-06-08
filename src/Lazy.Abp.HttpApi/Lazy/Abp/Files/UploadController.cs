using Lazy.Abp.Core.Proxy;
using Lazy.Abp.Core.Proxy.Dtos;
using Lazy.Abp.Files.Dto;
using Lazy.Abp.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly UploadTokenVerifyOption _uploadTokenVerifyOption;

        public UploadController(
            IMediaAppService service,
            IFastDFSProxyService fastDFSService,
            IOptions<UploadTokenVerifyOption> options
        )
        {
            _service = service;
            _fastDFSService = fastDFSService;

            _uploadTokenVerifyOption = options.Value;
        }

        [HttpPost]
        [Route("url")]
        public async Task<MediaDto> UploadUrlAsync(UploadUrlRequestDto input)
        {
            await AuthorizationService.CheckAsync(LazyAbpPermissions.Media.Create);

            var file = await _fastDFSService.UploadUrlAsync(input.Url);

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
        public async Task<List<MediaDto>> UploadUrlsAsync(UploadUrlsRequestDto input)
        {
            await AuthorizationService.CheckAsync(LazyAbpPermissions.Media.Create);

            var response = await _fastDFSService.UploadUrlsAsync(input.Urls);
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
        public async Task<MediaDto> UploadStreamAsync(IFormFile file)
        {
            await AuthorizationService.CheckAsync(LazyAbpPermissions.Media.Create);

            var fileCollection = new FormFileCollection();
            fileCollection.Add(file);

            var response = await _fastDFSService.UploadStreamAsync(file);

            return await _service.CreateAsync(new MediaCreateDto
            {
                Url = response.Data.Url,
                Md5 = response.Data.Md5,
                MimeType = file.ContentType,
                Path = response.Data.Path,
                Domain = response.Data.Domain,
                Scene = response.Data.Scene,
                Size = response.Data.Size,
                Mtime = response.Data.MTime,
                Scenes = response.Data.Scenes,
                Src = response.Data.Src
            });
        }

        [HttpPost]
        [Route("base64")]
        public async Task<MediaDto> UploadBase64Async(FastDFSFileBase64RequestDto input)
        {
            await AuthorizationService.CheckAsync(LazyAbpPermissions.Media.Create);

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

        [HttpGet]
        [Route("token-verify")]
        public ActionResult TokenVerify()
        {
            var state = Request.Query.TryGetValue("auth_token", out Microsoft.Extensions.Primitives.StringValues authToken);
            if (state)
            {
                var input = $"{_uploadTokenVerifyOption.Username}.{_uploadTokenVerifyOption.Password}";
                var md5 = Lazy.Abp.Core.Helpers.CommonHelper.Md5(input);

                var verify = md5.Equals(authToken);
                if (verify)
                    return Ok("ok");
                else
                    return BadRequest("failed");
            }
            else
            {
                return BadRequest("failed");
            }
        }
    }
}
