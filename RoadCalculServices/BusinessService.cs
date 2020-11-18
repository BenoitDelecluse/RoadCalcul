using BingMapsRESTToolkit;
using RoadCalculModel.DataBase;
using RoadCalculServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices
{
    internal class BusinessService : IBusinessService
    {
        private readonly IserviceFactory _serviceFactory;

        public BusinessService(IserviceFactory services)
        {
            _serviceFactory = services;
        }

        public Task<bool> Add(CalculDistanceHistorique value)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.Add(value);
        }

        public Task<bool> Add(SearchHistorique value)
        {
            var service = _serviceFactory.CreateSearchService();
            return service.Add(value);
        }

        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira)
        {
            var service = _serviceFactory.CreateBingService();
            return service.DistanceMatrixAsync(criteira);
        }

        public Task<List<CalculDistanceHistorique>> GetAll()
        {
            var service = _serviceFactory.CreateRouteService();
            return service.GetAll();
        }

        public Task<List<SearchHistorique>> GetAllSearch()
        {
            var service = _serviceFactory.CreateSearchService();
            return service.GetAll();
        }

        public double GetCosumption(double carcosumption, double distance)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.GetCosumption(carcosumption, distance);
        }

        public Task<List<Location>> GetLocationAsync(string querrylocation)
        {
            var service = _serviceFactory.CreateBingService();
            return service.GetLocationAsync(querrylocation);
        }

        public Task<bool> Update(CalculDistanceHistorique value)
        {
            var service = _serviceFactory.CreateRouteService();
            return service.Update(value);
        }

        public Task<bool> Update(SearchHistorique value)
        {
            var service = _serviceFactory.CreateSearchService();
            return service.Update(value);
        }
    }
}
