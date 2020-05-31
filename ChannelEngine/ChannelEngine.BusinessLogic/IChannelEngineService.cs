using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngine.Domain;

namespace ChannelEngine.BusinessLogic
{
    public interface IChannelEngineService
    {
        Task<IEnumerable<Product>> GetOrders();
    }
}
