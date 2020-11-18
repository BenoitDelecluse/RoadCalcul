using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public.Interface
{
    public interface IBusinessSearchService
    {
        //SearchService
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAllSearch();
        public Task<bool> Add(RoadCalculModel.DataBase.SearchHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.SearchHistorique value);
    }
}
