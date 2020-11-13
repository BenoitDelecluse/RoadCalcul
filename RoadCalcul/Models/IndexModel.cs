using BingMapsRESTToolkit;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadCalcul.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            DepartureResults = new List<Location>();
            DestinationResults = new List<Location>();
            Departure = new ParkingSearch();
            Destination = new ParkingSearch();
        }
        public double CarConsumption { get; set; }
        public ParkingSearch Departure { get; set; }

        List<Location> _DepartureResults;
        public List<Location> DepartureResults
        {
            get { return _DepartureResults; }
            set
            {
                if (value == null)
                {
                    _DepartureResults = new List<Location>();
                }
                else
                {
                    _DepartureResults = value;
                }
            }
        }
        public string SelectDeparture { get; set; }
        public ParkingSearch Destination { get; set; }
        List<Location> _DestinationResults;
        public List<Location> DestinationResults
        {
            get { return _DestinationResults; }
            set
            {
                if (value == null)
                {
                    _DestinationResults = new List<Location>();
                }
                else
                {
                    _DestinationResults = value;
                }
            }
        }
        public string SelectDestination { get; set; }
    }
}
