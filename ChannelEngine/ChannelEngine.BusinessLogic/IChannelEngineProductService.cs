using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngine.Domain;

namespace ChannelEngine.BusinessLogic
{
    public interface IChannelEngineProductService
    {
        Task<IList<Product>> GetProductsFromOrders();
        Task UpdateProductStock(string merchantProductNo, int stock);
    }
}
