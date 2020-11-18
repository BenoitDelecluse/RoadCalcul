using BingMapsRESTToolkit;
using RoadCalculServices.Public.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public
{
    internal class BusinessBingService : IBusinessBingService
    {
        private readonly IserviceFactory _serviceFactory;

        public BusinessBingService(IserviceFactory services)
        {
            _serviceFactory = services;
        }
        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira)
        {
            var service = _serviceFactory.CreateBingService();
            return service.DistanceMatrixAsync(criteira);
        }

        public Task<List<Location>> GetLocationAsync(string querrylocation)
        {
            var service = _serviceFactory.CreateBingService();
            return service.GetLocationAsync(querrylocation);
        }
    }
}
