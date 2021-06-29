using Bookstore.Data;
using Bookstore.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Console
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IBookRepository, BookRepository>();
        }
    }
}
