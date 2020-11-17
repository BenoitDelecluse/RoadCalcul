using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadCalculRepository.Interface
{
    public interface IRepoCalculDistanceHistorique
    {
        public Task<RoadCalculModel.DataBase.CalculDistanceHistorique> Get(int id);
        public Task<List<RoadCalculModel.DataBase.CalculDistanceHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.CalculDistanceHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.CalculDistanceHistorique value);
    }
}
