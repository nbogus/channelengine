using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngine.BusinessLogic;
using ChannelEngine.Domain;
using ChannelEngine.Services;

namespace ChannelEngine.ConsoleApp
{
    public class ChannelEngineConsoleService: IChannelEngineConsoleService
    {
        private readonly IConsoleService _consoleService;
        private readonly IChannelEngineProductService _channelEngineProductService;
        public ChannelEngineConsoleService(IConsoleService consoleService, IChannelEngineProductService channelEngineProductService)
        {
            _consoleService = consoleService;
            _channelEngineProductService = channelEngineProductService;
        }
        public async Task Execute()
        {
           var products =  await _channelEngineProductService.GetProductsFromOrders();
           await UpdateProduct(products);

           _consoleService.Display($"EAN  MerchantProductNo  Quantity");
            foreach (var product in products)
           {
               _consoleService.Display($"{product.EAN} {product.MerchantProductNo} {product.Quantity}");
           }
           _consoleService.ReadKey();
        }

        private async Task UpdateProduct(IList<Product> products)
        {
            var productToUpdate = products.FirstOrDefault();
            if (productToUpdate != null)
            {
                await _channelEngineProductService.UpdateProductStock(productToUpdate.MerchantProductNo, 25);
            }
        }
    }
}
