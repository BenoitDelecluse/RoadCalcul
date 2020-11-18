using RoadCalculModel.DataBase;
using RoadCalculServices.Public.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public
{
    internal class BusinessSearchService : IBusinessSearchService
    {
        private readonly IserviceFactory _serviceFactory;

        public BusinessSearchService(IserviceFactory services)
        {
            _serviceFactory = services;
        }
        public Task<bool> Update(SearchHistorique value)
        {
            var service = _serviceFactory.CreateSearchService();
            return service.Update(value);
        }

        public Task<bool> Add(SearchHistorique value)
        {
            var service = _serviceFactory.CreateSearchService();
            return service.Add(value);
        }

        public Task<List<SearchHistorique>> GetAllSearch()
        {
            var service = _serviceFactory.CreateSearchService();
            return service.GetAll();
        }
    }
}
