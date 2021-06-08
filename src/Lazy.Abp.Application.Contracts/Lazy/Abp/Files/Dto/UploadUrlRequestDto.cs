using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Files.Dto
{
    public class UploadUrlRequestDto
    {
        public string Url { get; set; }
    }

    public class UploadUrlsRequestDto
    {
        public IList<string> Urls { get; set; }
    }
}
