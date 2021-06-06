using System.Threading.Tasks;

namespace Lazy.Abp.RealTime.Client
{
    public interface IClient
    {
        Task OnConnectedAsync(IOnlineClient client);
        Task OnDisconnectedAsync(IOnlineClient client);
    }
}
