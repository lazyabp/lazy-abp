using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.IdentityServer.ApiScopes
{
    public class GetApiScopeInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
