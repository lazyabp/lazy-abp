using JetBrains.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Files
{
    /// <summary>
    /// Go-FastDfs struct
    /// </summary>
    public class Media : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [NotNull]
        public string Url { get; private set; }

        [NotNull]
        [MaxLength(MediaConsts.MaxMd5Length)]
        public string Md5 { get; private set; }

        public string MimeType { get; private set; }

        public string Path { get; private set; }

        public string Domain { get; private set; }

        public string Scene { get; private set; }

        public int Size { get; private set; }

        public int Mtime { get; private set; }

        public string Scenes { get; private set; }

        public string Src { get; private set; }

        public Media(
            Guid id,
            Guid? tenantId,
            [NotNull] string url,
            [NotNull] string md5,
            string mimeType,
            string path,
            string domain,
            string scene,
            int size,
            int mtime,
            string scenes,
            string src
        ) : base(id)
        {
            TenantId = tenantId;
            Url = Check.NotNullOrWhiteSpace(url, nameof(url));
            Md5 = Check.NotNullOrWhiteSpace(md5, nameof(md5));
            MimeType = mimeType;
            Path = path;
            Domain = domain;
            Scene = scene;
            Size = size;
            Mtime = mtime;
            Scenes = scenes;
            Src = src;
        }
    }
}
