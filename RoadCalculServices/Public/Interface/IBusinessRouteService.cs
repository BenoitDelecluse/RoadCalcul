using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public.Interface
{
    public interface IBusinessRouteService
    {
        //RouteService
        public Task<List<RoadCalculModel.DataBase.CalculDistanceHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        double GetCosumption(double carcosumption, double distance);
    }
}
