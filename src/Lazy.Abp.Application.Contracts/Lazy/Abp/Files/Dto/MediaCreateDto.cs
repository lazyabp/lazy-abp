using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Files.Dto
{
    public class MediaCreateDto
    {
        public string Url { get; set; }

        public string Md5 { get; set; }

        public string MimeType { get; set; }

        public string Path { get; set; }

        public string Domain { get; set; }

        public string Scene { get; set; }

        public int Size { get; set; }

        public int Mtime { get; set; }

        public string Scenes { get; set; }

        public string Src { get; set; }
    }
}
