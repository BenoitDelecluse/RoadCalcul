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
        private readonly IBusinessService Service;

        public HomeController( IBusinessService service)
        {
            this.Service = service;
        }

        public IActionResult Index()
        {
            return View("Index", new IndexModel());
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
                        var calculmodel = GetCalculModel(model);
                        if (calculmodel != null)
                        {
                            calculmodel.Distances = GetDistances(calculmodel.Departure, calculmodel.Destination, calculmodel.CarConsumption);
                            calculmodel.DistanceConsumption = Service.GetCosumption(calculmodel.Distances[0].Results[0].TravelDistance, model.CarConsumption);
                            return View("Calcul", calculmodel);
                        }
                        break;
                       
                }
            }
            //persiste data
            TempData.Keep("DepartureResults");
            TempData.Keep("DestinationResults");

            return View("Index", model);
        }

        public CalculModel GetCalculModel(IndexModel model)
        {
            var modelCalul = new CalculModel();
            var DepartureLoc = model.DepartureResults.Where(D => D.Name == model.SelectDeparture).FirstOrDefault();
            var DestinationLoc = model.DestinationResults.Where(D => D.Name == model.SelectDestination).FirstOrDefault();
            if (model.CarConsumption > 0)
            {
                if (!string.IsNullOrEmpty(model.SelectDeparture) && DepartureLoc != null)
                {
                    if (!string.IsNullOrEmpty(model.SelectDestination) && DestinationLoc != null)
                    {
                        modelCalul.CarConsumption = model.CarConsumption;
                        modelCalul.Departure = DepartureLoc;
                        modelCalul.Destination = DestinationLoc;
                        return modelCalul;
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            { 
            
            }
            return null;
        }
        public List<Location> GetLocationAsync(string query)
        {
            try
            {
                var result = Service.GetLocationAsync(query);
                Service.Add(new RoadCalculModel.DataBase.SearchHistorique
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

        public IActionResult Calcul(CalculModel model)
        {
            model.Distances = GetDistances(model.Departure, model.Destination, model.CarConsumption);
            model.DistanceConsumption = Service.GetCosumption(model.Distances[0].Results[0].TravelDistance, model.CarConsumption);
            return View("Calcul", model);
        }

        public List<DistanceMatrix> GetDistances(Location Departure, Location Destination, double carcosumption)
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
                var result = Service.DistanceMatrixAsync(criteria);
                Service.Add(new RoadCalculModel.DataBase.CalculDistanceHistorique
                {
                    DestinationName = Destination.Name,
                    DestinationType = Destination.EntityType,
                    DestinationLat = criteria.Destination.Latitude,
                    DestinationLong = criteria.Destination.Longiture,
                    OriginName = Departure.Name,
                    OriginType = Departure.EntityType,
                    OriginLat = criteria.origin.Latitude,
                    OriginLong = criteria.origin.Longiture,
                    CarConsumption = carcosumption,
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
            model.SearchHistoriques = Service.GetAllSearch().Result;
            var SearchHisto = JsonSerializer.Serialize(model.SearchHistoriques);
            TempData["HistoriquesSearch"] = SearchHisto;
            TempData.Keep("HistoriquesSearch");
            return View("Report", model);
        }

        public IActionResult ReportCalcul()
        {
            var model = new ReportModel();
            model.CalculDistanceHistoriques = Service.GetAll().Result;
            var DistanceHisto = JsonSerializer.Serialize(model.CalculDistanceHistoriques);
            TempData["HistoriquesDistance"] = DistanceHisto;
            TempData.Keep("HistoriquesDistance");
            return View("ReportCalcul", model);
        }

        [HttpPost]
        public ActionResult EditSearchAction(ReportModel model, string ReportButon)
        {
            string JsonSearchHisto = TempData["HistoriquesSearch"]?.ToString();
            var SearchHisto = JsonSerializer.Deserialize<List<RoadCalculModel.DataBase.SearchHistorique>>(JsonSearchHisto);
            var Histo = SearchHisto.Where(sh => sh.ID.ToString() == ReportButon).FirstOrDefault();
            var indexmodel = new IndexModel();
            indexmodel.Departure.Querry = Histo.Querry;
            return View("Index", indexmodel);
        }

        [HttpPost]
        public ActionResult CalculCalculAction(ReportModel model, string ReportButon)
        {
            string JsonDistanceHisto = TempData["HistoriquesDistance"]?.ToString();
            var DistanceHisto = JsonSerializer.Deserialize<List<RoadCalculModel.DataBase.CalculDistanceHistorique>>(JsonDistanceHisto);
            var Distance = DistanceHisto.Where(sh => sh.ID.ToString() == ReportButon).FirstOrDefault();

            var modelcalcul = new CalculModel();
            double[] DestCoordonates = { Distance.DestinationLat, Distance.DestinationLong };
            double[] DepCoordonates = { Distance.OriginLat, Distance.OriginLong };
            modelcalcul.Departure = new Location
            {
                Name = Distance.OriginName,
                EntityType = Distance.OriginType,
                Point = new Point
                {
                    Coordinates = DestCoordonates
                }
            };
            modelcalcul.Destination = new Location
            {
                Name = Distance.DestinationName,
                EntityType = Distance.DestinationType,
                Point = new Point
                {
                    Coordinates = DepCoordonates
                }
            };
            modelcalcul.CarConsumption = Distance.CarConsumption;
            modelcalcul.Distances = GetDistances(modelcalcul.Departure, modelcalcul.Destination, Distance.CarConsumption);
            modelcalcul.DistanceConsumption = Service.GetCosumption(modelcalcul.Distances[0].Results[0].TravelDistance, modelcalcul.CarConsumption);
            return View("Calcul", modelcalcul);
        }

        [HttpPost]
        public ActionResult EditCalculAction(ReportModel model, string ReportButon)
        {
            string JsonDistanceHisto = TempData["HistoriquesDistance"]?.ToString();
            var DistanceHisto = JsonSerializer.Deserialize<List<RoadCalculModel.DataBase.CalculDistanceHistorique>>(JsonDistanceHisto);
            var Distance = DistanceHisto.Where(sh => sh.ID.ToString() == ReportButon).FirstOrDefault();

            var indexmodel = new IndexModel();
            indexmodel.Departure.Querry = Distance.OriginName;
            indexmodel.Destination.Querry = Distance.DestinationName;
            indexmodel.CarConsumption = Distance.CarConsumption;
            return View("Index", indexmodel);
        }
    }
}
