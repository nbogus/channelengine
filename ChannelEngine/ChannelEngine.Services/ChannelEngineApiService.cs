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
            var request = new RestRequest("orders?statuses=IN_PROGRESS", Method.GET);
            var restResponse = await CallChannelEngineApi(request);
            var data = JsonConvert.DeserializeObject<OrderCollectionResponse>(restResponse.Content);
            return data;
        }

        public Task SetProductStock()
        {
            throw new NotImplementedException();
        }

        public  Task SetProductStock(string merchantProductNumber, int stock)
        {
            var request = new RestRequest("offer", Method.POST);
            request = CreateProductUpdateRequestBody(merchantProductNumber, stock, request);

            return CallChannelEngineApi(request);
        }

        private RestRequest CreateProductUpdateRequestBody(string merchantProductNumber, int stock, RestRequest request)
        {
            var requestBody = new ProductStockUpdate
            {
                MerchantProductNo = merchantProductNumber,
                Stock = stock
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestBody);
            return request;
        }

        private async Task<IRestResponse> CallChannelEngineApi(IRestRequest request)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            request.AddQueryParameter("apiKey", "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");
            return await _client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
        }
    }
}
