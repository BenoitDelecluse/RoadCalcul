using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices.Interface
{
    public interface IRouteService
    {
        public Task<List<RoadCalculModel.DataBase.CalculDistanceHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        double GetCosumption(double carcosumption, double distance);
    }
}
