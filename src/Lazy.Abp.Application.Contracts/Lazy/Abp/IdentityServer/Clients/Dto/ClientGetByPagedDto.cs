using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.IdentityServer.Clients
{
    public class ClientGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
