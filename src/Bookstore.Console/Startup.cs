using Bookstore.Application;
using Bookstore.Application.Configuration;
using Bookstore.Application.Interfaces;
using Bookstore.Data;
using Bookstore.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Bookstore.Console
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IBookService, BookService>();
            services.Configure<BookConfiguration>(options => Configuration.GetSection("BookCharges").Bind(options));


            services.AddLogging(
                builder =>
                {
                    builder.AddFilter("Microsoft", LogLevel.Warning)
                           .AddFilter("System", LogLevel.Warning)
                           .AddFilter("NToastNotify", LogLevel.Warning)
                           .AddConsole();
                });

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            // Get Service and call method
            var bookService = serviceProvider.GetService<IBookService>();
            bookService.OpenBookStore();
        }
    }
}
