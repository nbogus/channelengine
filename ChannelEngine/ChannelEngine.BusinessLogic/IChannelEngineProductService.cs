using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngine.Domain;

namespace ChannelEngine.BusinessLogic
{
    public interface IChannelEngineProductService
    {
        Task<IEnumerable<Product>> GetProductsFromOrders();
    }
}
