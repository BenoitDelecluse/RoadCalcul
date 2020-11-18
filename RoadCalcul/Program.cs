using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RoadCalculServices.Configuration;

namespace RoadCalcul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
         //.ConfigureWebHostDefaults(webBuilder =>
         //{
         //    webBuilder.UseStartup<Startup>();

         //});
         .ConfigureServices(services => services.AddTransient<IServiceCollectionForBusiness, ServiceCollectionForBusiness>())
        .UseStartup<Startup>();
    }
}
