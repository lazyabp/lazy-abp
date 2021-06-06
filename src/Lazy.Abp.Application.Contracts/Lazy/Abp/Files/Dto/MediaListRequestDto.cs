using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Files.Dto
{
    public class MediaListRequestDto : PagedAndSortedResultRequestDto
    {
        public DateTime? CreationStart { get; set; }

        public DateTime? CreationEnd { get; set; }

        public int? MinSize { get; set; }

        public int? MaxSize { get; set; }

        public string Filter { get; set; }
    }
}
