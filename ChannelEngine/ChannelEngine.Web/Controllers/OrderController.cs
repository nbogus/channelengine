using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngine.BusinessLogic;
using ChannelEngine.Web.Mappers;
using ChannelEngine.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IChannelEngineProductService _channelEngineProductService;
        public OrderController(IChannelEngineProductService channelEngineProductService)
        {
            _channelEngineProductService = channelEngineProductService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _channelEngineProductService.GetProductsFromOrders();
            var productToUpdate = products.FirstOrDefault();
            if (productToUpdate != null)
            {
                await _channelEngineProductService.UpdateProductStock(productToUpdate.MerchantProductNo, 25);
            }
           
            var productsViewModel = products.Select(p => p.MapToProductViewModel()).ToList();
            return View(productsViewModel);
        }
    }
}