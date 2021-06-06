using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Identity
{
    public class OrganizationUnitGetUnaddedRoleByPagedDto : PagedAndSortedResultRequestDto
    {

        public string Filter { get; set; }
    }
}
