using System.Threading.Tasks;
using ChannelEngine.Services.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ChannelEngine.Services
{
    public class ChannelEngineApiService: IChannelEngineApiService
    {
        private readonly IRestApiService _restApiService;
        public ChannelEngineApiService(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public async Task<OrderCollectionResponse> FetchAllOrdersAsync()
        {
            var request = new RestRequest("orders?statuses=IN_PROGRESS", Method.GET);
            var restResponse = await _restApiService.ExecuteApiCall(request);
            var data = JsonConvert.DeserializeObject<OrderCollectionResponse>(restResponse.Content);
            return data;
        }

        public async  Task UpdateProductStock(string merchantProductNumber, int stock)
        {
            var request = new RestRequest("offer", Method.PUT);
            request = CreateProductUpdateRequestBody(merchantProductNumber, stock, request);
            var response = await _restApiService.ExecuteApiCall(request);
        }

        private RestRequest CreateProductUpdateRequestBody(string merchantProductNumber, int stock, RestRequest request)
        {
            var requestBody = new ProductStockUpdate
            {
                MerchantProductNo = merchantProductNumber,
                Stock = stock
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new[] {requestBody});
            return request;
        }

       
    }
}
