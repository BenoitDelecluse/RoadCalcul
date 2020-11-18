using BingMapsRESTToolkit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices.Public.Interface
{
    public interface IBusinessBingService
    {
        public Task<List<Location>> GetLocationAsync(string querrylocation);
        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira);
    }
}
