using ChannelEngine.BusinessLogic;
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

        public IActionResult Index()
        {
            _channelEngineService.GetOrders();
            return View();
        }
    }
}