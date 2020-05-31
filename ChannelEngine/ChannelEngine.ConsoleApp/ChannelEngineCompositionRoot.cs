using System.IO;
using ChannelEngine.BusinessLogic;
using ChannelEngine.Services;
using Microsoft.Extensions.Configuration;

namespace ChannelEngine.ConsoleApp
{
    public class ChannelEngineCompositionRoot
    {
       public static IChannelEngineConsoleService Create()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var service = new ChannelEngineConsoleService(new ConsoleService(), new ChannelEngineProductService(new ChannelEngineApiService(new RestApiService(config))));
            return service;
        }
    }
}
