using System;
using System.Threading;
using System.Threading.Tasks;
using ChannelEngine.Services.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ChannelEngine.Services
{
    public class ChannelEngineApiService: IChannelEngineApiService
    {   
        private readonly RestClient _client = new RestClient("https://api-dev.channelengine.net/api/v2/");
        public ChannelEngineApiService()
        {
            
        }

        public async Task<OrderCollectionResponse> FetchAllOrdersAsync()
        {
            var request = new RestRequest("orders?statuses=IN_PROGRESS&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322", Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse = await _client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            var data = JsonConvert.DeserializeObject<OrderCollectionResponse>(restResponse.Content);
            return data;
        }

        public async Task SetProductStock()
        {
            var request = new RestRequest("offer", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse = await _client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
        }
    }
}
