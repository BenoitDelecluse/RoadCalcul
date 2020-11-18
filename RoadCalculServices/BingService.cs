using BingMapsRESTToolkit;
using RoadCalculModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoadCalculServices.Interface;

namespace RoadCalculServices
{
    internal class BingService : IBingService
    {
        static string BingKey = "AqzmFAGLwVbp1qsByMJ4Prh4rXTjqWBjrHtzjuwWP4PUdmrfqv9K8L1fc7WkDTaM";
        public async Task<List<DistanceMatrix>> DistanceMatrixAsync(RoadCalculModel.Route criteira)
        {
            //Create a request.
            var request = new DistanceMatrixRequest()
            {
                BingMapsKey = BingKey,
                DistanceUnits = DistanceUnitType.Kilometers,
                TimeUnits = TimeUnitType.Minute,
                Origins = new List<SimpleWaypoint>
                    {
                        new SimpleWaypoint(new Coordinate(criteira.origin.Latitude, criteira.origin.Longiture))
                    },
                Destinations = new List<SimpleWaypoint>
                    {
                        new SimpleWaypoint(new Coordinate(criteira.Destination.Latitude, criteira.Destination.Longiture))
                    },
                TravelMode = TravelModeType.Driving,
                VehicleSpec = new VehicleSpec
                {
                    VehicleLength = 4.5,
                    VehicleWeight = 1500
                }
            };

            var response = await request.Execute();
            var result = new List<DistanceMatrix>();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                foreach (var resources in response.ResourceSets[0].Resources)
                {
                    var item = resources as BingMapsRESTToolkit.DistanceMatrix;
                    result.Add(item);
                }
                //Do something with the result.
            }
            return result;
        }

        public async Task<List<Location>> GetLocationAsync(string querrylocation)
        {
            //Create a request.
            var request = new GeocodeRequest()
            {
                Query = querrylocation,
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
                BingMapsKey = BingKey
            };

            //Process the request by using the ServiceManager.
            var response = await request.Execute();
            var result = new List<Location>();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                foreach (var resources in response.ResourceSets[0].Resources)
                {
                    var item = resources as BingMapsRESTToolkit.Location;
                    result.Add(item);
                }
                //Do something with the result.
            }
            return result;
        }
    }
}
