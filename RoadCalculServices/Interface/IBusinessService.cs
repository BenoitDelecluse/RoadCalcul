using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices.Interface
{
    public interface IBusinessService
    {
        //BingService
        public Task<List<Location>> GetLocationAsync(string querrylocation);
        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira);
        //RouteService
        public Task<List<RoadCalculModel.DataBase.CalculDistanceHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        double GetCosumption(double carcosumption, double distance);

        //SearchService
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAllSearch();
        public Task<bool> Add(RoadCalculModel.DataBase.SearchHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.SearchHistorique value);
    }
}
