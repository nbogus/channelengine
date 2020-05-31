using System.Threading.Tasks;
using RestSharp;

namespace ChannelEngine.Services
{
    public interface IRestApiService
    {
        Task<IRestResponse> ExecuteApiCall(RestRequest request);
    }
}
