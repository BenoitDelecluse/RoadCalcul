using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Text.Json;
using BingMapsRESTToolkit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoadCalcul.Models;
using RoadCalculServices.Interface;
using Microsoft.AspNetCore.Http;

namespace RoadCalcul.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBingService BingService;
        private readonly ISearchService SearchService;
        private readonly IRouteService RouteService;

        public HomeController(ILogger<HomeController> logger, IBingService bingService, ISearchService searchService, IRouteService routeService)
        {
            _logger = logger;
            this.BingService = bingService;
            this.SearchService = searchService;
            this.RouteService = routeService;
        }

        public IActionResult Index()
        {
            return View("Index", new IndexModel());
        }

        public IActionResult IndexWithParams(string query)
        {
            var model = new IndexModel();
            model.Departure.Querry = query;
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult IndexAction(IndexModel model, string IndexButon)
        {
            if (ModelState.IsValid)
            {
                //desirialise json list
                string jsonDep = TempData["DepartureResults"]?.ToString();
                string jsonDest = TempData["DestinationResults"]?.ToString();
                if (!string.IsNullOrEmpty(jsonDep))
                {
                    model.DepartureResults = JsonSerializer.Deserialize<List<Location>>(jsonDep);
                }
                if (!string.IsNullOrEmpty(jsonDest))
                {
                    model.DestinationResults = JsonSerializer.Deserialize<List<Location>>(jsonDest);
                }
                //serialise json and register in tempdata.
                switch (IndexButon)
                {
                    case "SearchDeparture":
                        var DepLocations = GetLocationAsync(model.Departure.Querry);
                        var DepLocJson = JsonSerializer.Serialize(DepLocations);
                        TempData["DepartureResults"] = DepLocJson;
                        model.DepartureResults = DepLocations;
                        break;
                    case "SearchDestination":
                        var DestLocations = GetLocationAsync(model.Destination.Querry);
                        var DestLocJson = JsonSerializer.Serialize(DestLocations);
                        TempData["DestinationResults"] = DestLocJson;
                        model.DestinationResults = DestLocations;
                        break;
                    case "Calcul":
                        GoToCalcul(model);
                        break;
                }
            }
            //persiste data
            TempData.Keep("DepartureResults");
            TempData.Keep("DestinationResults");

            return View("Index", model);
        }

        public void GoToCalcul(IndexModel model)
        {
            var DepartureLoc = model.DepartureResults.Where(D => D.Name == model.SelectDeparture).FirstOrDefault();
            var DestinationLoc = model.DestinationResults.Where(D => D.Name == model.SelectDestination).FirstOrDefault();
            if (!string.IsNullOrEmpty(model.SelectDeparture) && DepartureLoc != null)
            {
                if (!string.IsNullOrEmpty(model.SelectDestination) && DestinationLoc != null)
                {
                    var DepLocJson = JsonSerializer.Serialize(DepartureLoc);
                    var DesLocJson = JsonSerializer.Serialize(DestinationLoc);
                    TempData["Departure"] = DepLocJson;
                    TempData["Destination"] = DesLocJson;
                    TempData.Keep("Departure");
                    TempData.Keep("Destination");
                    Response.Redirect("/Home/Calcul");
                }
                else
                {

                }
            }
            else
            {

            }

        }
        public List<Location> GetLocationAsync(string query)
        {
            try
            {
                var result = BingService.GetLocationAsync(query);
                SearchService.Add(new RoadCalculModel.DataBase.SearchHistorique
                {
                    Querry = query,
                    Time = DateTime.Now
                });
                return result.Result;
            }
            catch (Exception ex)
            {
                return new List<Location>();
            }
        }

        public IActionResult Calcul()
        {
            string jsonDep = TempData["Departure"]?.ToString();
            string jsonDest = TempData["Destination"]?.ToString();
            var Departure = JsonSerializer.Deserialize<Location>(jsonDep);
            var Destination = JsonSerializer.Deserialize<Location>(jsonDest);
            TempData.Keep("Departure");
            TempData.Keep("Destination");
            var model = new CalculModel();
            model.Departure = Departure;
            model.Destination = Destination;
            model.Distances = GetDistances(Departure, Destination);

            return View("Calcul", model);
        }

        public IActionResult CalculWithParams(double DestLat, double DestLong, double DepLat, double DepLong)
        {
            double[] DestCoordonates = { DestLat, DestLong };
            double[] DepCoordonates = { DepLat, DepLong };
            var model = new CalculModel();
            model.Departure = new Location
            {
                Point = new Point
                {
                    Coordinates = DestCoordonates
                }
            };
            model.Destination = new Location
            {
                Point = new Point
                {
                    Coordinates = DepCoordonates
                }
            };
            model.Distances = GetDistances(model.Departure, model.Destination);

            return View("Calcul", model);
        }

        public List<DistanceMatrix> GetDistances(Location Departure, Location Destination)
        {
            try
            {
                var criteria = new RoadCalculModel.Route();
                criteria.Destination = new RoadCalculModel.Parking
                {
                    Latitude = Destination.Point.Coordinates[0],
                    Longiture = Destination.Point.Coordinates[1]
                };
                criteria.origin = new RoadCalculModel.Parking
                {
                    Latitude = Departure.Point.Coordinates[0],
                    Longiture = Departure.Point.Coordinates[1]
                };
                var result = BingService.DistanceMatrixAsync(criteria);
                RouteService.Add(new RoadCalculModel.DataBase.CalculDistanceHistorique
                {
                    DestinationLat = criteria.Destination.Latitude,
                    DestinationLong = criteria.Destination.Longiture,
                    OriginLat = criteria.origin.Latitude,
                    OriginLong = criteria.origin.Longiture,
                    Time = DateTime.Now
                });

                return result.Result;
            }
            catch (Exception ex)
            {
                return new List<DistanceMatrix>();
            }
        }

        public IActionResult Report()
        {
            var model = new ReportModel();
            model.SearchHistoriques = SearchService.GetAll().Result;
            model.CalculDistanceHistoriques = RouteService.GetAll().Result;
            var SearchHisto = JsonSerializer.Serialize(model.SearchHistoriques);
            var DistanceHisto = JsonSerializer.Serialize(model.CalculDistanceHistoriques);
            TempData["HistoriquesSearch"] = SearchHisto;
            TempData["HistoriquesDistance"] = DistanceHisto;
            TempData.Keep("HistoriquesSearch");
            TempData.Keep("HistoriquesDistance");
            return View("Report", model);
        }

        [HttpPost]
        public ActionResult EditSearchAction(ReportModel model, string ReportButon)
        {
            string JsonSearchHisto = TempData["HistoriquesSearch"]?.ToString();
            var SearchHisto = JsonSerializer.Deserialize<List<RoadCalculModel.DataBase.SearchHistorique>>(JsonSearchHisto);
            var Histo = SearchHisto.Where(sh => sh.ID.ToString() == ReportButon).FirstOrDefault();
            return RedirectToAction("IndexWithParams", "Home", new { query = Histo.Querry });
        }

        [HttpPost]
        public ActionResult EditCalculAction(ReportModel model, string ReportButon)
        {
            string JsonDistanceHisto = TempData["HistoriquesDistance"]?.ToString();
            var DistanceHisto = JsonSerializer.Deserialize<List<RoadCalculModel.DataBase.CalculDistanceHistorique>>(JsonDistanceHisto);
            var Distance = DistanceHisto.Where(sh => sh.ID.ToString() == ReportButon).FirstOrDefault();

            return RedirectToAction("CalculWithParams", new
            {
                DestLat = Distance.DestinationLat,
                DestLong = Distance.DestinationLong,
                DepLat = Distance.OriginLat,
                DepLong = Distance.OriginLong
            });
        }
    }
}
