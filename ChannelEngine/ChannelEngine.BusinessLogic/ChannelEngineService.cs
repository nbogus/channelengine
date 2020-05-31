using System;
using System.Collections.Generic;
using System.Text;
using ChannelEngine.Services;

namespace ChannelEngine.BusinessLogic
{
    public class ChannelEngineService: IChannelEngineService
    {
        private readonly IChannelEngineApiService _channelEngineApiService;
        public ChannelEngineService(IChannelEngineApiService channelEngineApiService)
        {
            _channelEngineApiService = channelEngineApiService;
        }

        public void GetOrders()
        {
           var orders = _channelEngineApiService.FetchAllOrdersAsync();
        }
    }
}
