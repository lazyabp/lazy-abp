using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.IdentityServer.ApiResources
{
    public class ApiResourceGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
