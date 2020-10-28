using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadCalculRepository.Interface
{
    public interface IRepoSearchHistorique
    {
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> Get(int id);
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.SearchHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.SearchHistorique value);
    }
}
