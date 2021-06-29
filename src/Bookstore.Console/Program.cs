using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Bookstore.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                new Startup(hostBuilderContext.Configuration).ConfigureServices(serviceCollection));
    }
}
