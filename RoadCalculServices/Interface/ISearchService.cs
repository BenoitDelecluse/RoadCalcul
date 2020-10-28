using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices.Interface
{
    public interface ISearchService
    {
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.SearchHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.SearchHistorique value);
    }
}
