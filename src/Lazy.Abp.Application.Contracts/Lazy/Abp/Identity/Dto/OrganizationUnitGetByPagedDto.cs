using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Identity
{
    public class OrganizationUnitGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
