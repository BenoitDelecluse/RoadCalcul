using BingMapsRESTToolkit;
using RoadCalculModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RoadCalculTestService")]
namespace RoadCalculServices.Interface
{
    internal interface IBingService
    {
        public Task<List<Location>> GetLocationAsync(string querrylocation);

        public Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira);

    }
}
