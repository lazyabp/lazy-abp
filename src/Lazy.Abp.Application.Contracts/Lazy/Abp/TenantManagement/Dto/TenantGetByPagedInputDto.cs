using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.TenantManagement
{
    public class TenantGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}