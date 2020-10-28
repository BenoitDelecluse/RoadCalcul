using BingMapsRESTToolkit;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace RoadCalculServiceTest.Services
{
    public static class BingTest
    {
        static string BingKey = "AqzmFAGLwVbp1qsByMJ4Prh4rXTjqWBjrHtzjuwWP4PUdmrfqv9K8L1fc7WkDTaM";

        public static async Task<Location> TestGeoCodeRequestAsync()
        {
            //Create a request.
            var request = new GeocodeRequest()
            {
                Query = "Rue de la culture 5, Tournai",
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
                BingMapsKey = BingKey
            };

            //Process the request by using the ServiceManager.
            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                return result;
                //Do something with the result.
            }
            return null;
        }

        public static async Task<Location> TestGeoCodeRequest2Async()
        {
            //Create a request.
            var request = new GeocodeRequest()
            {
                Query = "Leuze en Hainaut",
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
                BingMapsKey = BingKey
            };

            //Process the request by using the ServiceManager.
            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                return result;
                //Do something with the result.
            }
            return null;
        }

        public static async Task<DistanceMatrix> TestDistanceMatrixRequestAsync(double originlatitude, double originlongitude, double destlatitude, double destlongitude)
        {
            //Create a request.
            var request = new DistanceMatrixRequest()
            {
                BingMapsKey = BingKey,
                Origins = new List<SimpleWaypoint>
                    {
                        new SimpleWaypoint(new Coordinate(originlatitude, originlongitude))
                    },
                Destinations = new List<SimpleWaypoint>
                    {
                        new SimpleWaypoint(new Coordinate(destlatitude, destlongitude))
                    },
                TravelMode = TravelModeType.Driving,
                VehicleSpec = new VehicleSpec
                {
                    VehicleLength = 16.5,
                    VehicleWeight = 20000
                }
            };

            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.DistanceMatrix;
                return result;
                //Do something with the result.
            }
            return null;
        }

        public static async Task<Location> TestElevationRequestAsync()
        {
            //Create a request.
            var request = new ElevationRequest()
            {
                //Query = "New York, NY",
                //IncludeIso2 = true,
                //IncludeNeighborhood = true,
                //MaxResults = 25,
                BingMapsKey = BingKey
            };

            //Process the request by using the ServiceManager.
            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                return result;
                //Do something with the result.
            }
            return null;
        }

    }
}
