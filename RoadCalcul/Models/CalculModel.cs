using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadCalcul.Models
{
    public class CalculModel
    {
        public Location Destination { get; set; }
        public Location Departure { get; set; }
        public List<DistanceMatrix> Distances { get; set; }
    }
}
