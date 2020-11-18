using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RoadCalculTestService")]
namespace RoadCalculServices.Interface
{
    internal interface ISearchService
    {
        public Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAll();
        public Task<bool> Add(RoadCalculModel.DataBase.SearchHistorique value);
        public Task<bool> Update(RoadCalculModel.DataBase.SearchHistorique value);
    }
}
