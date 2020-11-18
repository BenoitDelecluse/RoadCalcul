using Microsoft.Extensions.DependencyInjection;
using RoadCalculServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadCalculServices.Configuration
{
    public class ServiceCollectionForBusiness : IServiceCollectionForBusiness
    {
        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IBusinessService, BusinessService>();

            services.AddScoped<IserviceFactory, ServiceFactory>();

            services.AddScoped<IBingService, BingService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ISearchService, SearchService>();
    
        }
    }
}
