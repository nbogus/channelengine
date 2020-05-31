using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngine.Domain;
using ChannelEngine.Services;
using ChannelEngine.Services.Models;

namespace ChannelEngine.BusinessLogic
{
    public class ChannelEngineProductService: IChannelEngineProductService
    {
        private readonly IChannelEngineApiService _channelEngineApiService;
        public ChannelEngineProductService(IChannelEngineApiService channelEngineApiService)
        {
            _channelEngineApiService = channelEngineApiService;
        }

        public async Task<IEnumerable<Product>> GetProductsFromOrders()
        {
           var ordersResponse = await _channelEngineApiService.FetchAllOrdersAsync();
           if (!ordersResponse.Success) throw new ApplicationException("Error during getting data from api.");
           var orders = ordersResponse.Content;
           var orderedProducts = GetProductsFromOrders(orders);
           var productToUpdate = orderedProducts.FirstOrDefault();
           if (productToUpdate != null)
           {
               await  UpdateProductStock(productToUpdate.MerchantProductNo, 25);
           }
              
           return orderedProducts;
        }

        public async Task UpdateProductStock(string merchantProductNo, int stock)
        {
            await _channelEngineApiService.UpdateProductStock(merchantProductNo, stock);
        }

        private IList<Product> GetProductsFromOrders(IEnumerable<Order> orders)
        {
            var productsFromOrders = orders.SelectMany(o => o.Lines.Select(l =>
                new
                {
                    EAN = l.Gtin,
                    l.Quantity,
                    l.MerchantProductNo
                }
            )).GroupBy(p => p.MerchantProductNo).Select(p => new Product
            {
                EAN = p.FirstOrDefault()?.EAN,
                Quantity = p.Sum(s => int.Parse(s.Quantity)),
                MerchantProductNo = p.Key
            }).ToList();

            var orderedProducts = productsFromOrders.OrderByDescending(p => p.Quantity).Take(5).ToList();
            return orderedProducts;
        }
    }
}
