using BingMapsRESTToolkit;
using RoadCalculModel;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RoadCalculServices.Interface
{
    public interface IBingService
    {
        public Task<List<Location>> GetLocationAsync(string querrylocation);

        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira);

    }
}
