using System.Threading.Tasks;
using ChannelEngine.Services.Models;

namespace ChannelEngine.Services
{
    public interface IChannelEngineApiService
    {
        Task<OrderCollectionResponse> FetchAllOrdersAsync();
        Task SetProductStock();
    }
}