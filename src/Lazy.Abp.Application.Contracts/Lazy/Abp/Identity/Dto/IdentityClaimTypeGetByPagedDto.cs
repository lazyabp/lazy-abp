using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Identity
{
    public class IdentityClaimTypeGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
