using BingMapsRESTToolkit;
using Microsoft.Extensions.DependencyInjection;
using RoadCalculModel.DataBase;
using RoadCalculServices.Public.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices.Public
{
    internal class BusinessService : IBusinessService
    {
        IServiceProvider ServiceProvider;

        public BusinessService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public IBusinessBingService Bing => ServiceProvider.GetRequiredService<IBusinessBingService>();

        public IBusinessRouteService Route => ServiceProvider.GetRequiredService<IBusinessRouteService>();

        public IBusinessSearchService Search => ServiceProvider.GetRequiredService<IBusinessSearchService>();
    }
}
