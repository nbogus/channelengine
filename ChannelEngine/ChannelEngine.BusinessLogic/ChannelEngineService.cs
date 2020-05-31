using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelEngine.Domain;
using ChannelEngine.Services;
using ChannelEngine.Services.Models;

namespace ChannelEngine.BusinessLogic
{
    public class ChannelEngineService: IChannelEngineService
    {
        private readonly IChannelEngineApiService _channelEngineApiService;
        public ChannelEngineService(IChannelEngineApiService channelEngineApiService)
        {
            _channelEngineApiService = channelEngineApiService;
        }

        public async Task<IEnumerable<Product>> GetOrders()
        {
           var ordersResponse = await _channelEngineApiService.FetchAllOrdersAsync();
           if (ordersResponse.Success)
           {
               var orders = ordersResponse.Content;
               var orderedProducts = GetProductsFromOrders(orders);
               return orderedProducts;
           }

           return null;
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
