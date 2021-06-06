using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Identity
{
    public class OrganizationUnitGetUnaddedUserByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
