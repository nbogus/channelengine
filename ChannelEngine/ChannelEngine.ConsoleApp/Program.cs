using System.Threading.Tasks;

namespace ChannelEngine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = ChannelEngineCompositionRoot.Create();
            app.Execute().GetAwaiter().GetResult();
        }
    }
}
