using System.Linq;
using System.Threading.Tasks;
using ChannelEngine.BusinessLogic;
using ChannelEngine.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IChannelEngineService _channelEngineService;
        public OrderController(IChannelEngineService channelEngineService)
        {
            _channelEngineService = channelEngineService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _channelEngineService.GetOrders();
            var productsViewModel = products.Select(p => p.MapToProductViewModel()).ToList();
            return View(productsViewModel);
        }
    }
}