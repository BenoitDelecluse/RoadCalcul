using RoadCalculModel.DataBase;
using RoadCalculServices.Public.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public
{
    internal class BusinessRouteService : IBusinessRouteService
    {
        private readonly IserviceFactory _serviceFactory;

        public BusinessRouteService(IserviceFactory services)
        {
            _serviceFactory = services;
        }
        public Task<bool> Update(CalculDistanceHistorique value)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.Update(value);
        }

        public double GetCosumption(double carcosumption, double distance)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.GetCosumption(carcosumption, distance);
        }

        public Task<List<CalculDistanceHistorique>> GetAll()
        {
            var service = _serviceFactory.CreateRouteService();
            return service.GetAll();
        }

        public Task<bool> Add(CalculDistanceHistorique value)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.Add(value);
        }
    }
}
