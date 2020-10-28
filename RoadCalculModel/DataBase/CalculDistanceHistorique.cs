using System;
using System.Collections.Generic;
using System.Text;

namespace RoadCalculModel.DataBase
{
    public class CalculDistanceHistorique
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public double OriginLat { get; set; }
        public double OriginLong { get; set; }
        public double DestinationLat { get; set; }
        public double DestinationLong { get; set; }
    }
}
