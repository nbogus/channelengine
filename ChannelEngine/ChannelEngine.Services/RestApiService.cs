using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ChannelEngine.Services
{
    public class RestApiService: IRestApiService
    {
        private readonly RestClient _client; 
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        public RestApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(_configuration["Settings:ChannelEngineUrl"]);
            _apiKey = _configuration["Settings:ChannelEngineApiKey"];
        }

        public  Task<IRestResponse> ExecuteApiCall(RestRequest request)
        {
            var cancellationTokenSource = new CancellationTokenSource();
           
            request.AddQueryParameter("apiKey", _apiKey);
            return _client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
        }
    }
}
