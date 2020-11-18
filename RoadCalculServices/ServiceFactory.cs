using Microsoft.Extensions.DependencyInjection;
using RoadCalculServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadCalculServices
{
    internal class ServiceFactory : IserviceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBingService CreateBingService()
        {
            var service = _serviceProvider.GetService<IBingService>();
            return service;
        }

        public IRouteService CreateRouteService()
        {
            var service = _serviceProvider.GetService<IRouteService>();
            return service;
        }

        public ISearchService CreateSearchService()
        {
            var service = _serviceProvider.GetService<ISearchService>();
            return service;
        }
    }
}
