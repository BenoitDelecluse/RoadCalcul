using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadCalcul.Models
{
    public class ReportModel
    {
        public List<RoadCalculModel.DataBase.SearchHistorique> SearchHistoriques { get; set; }
        public List<RoadCalculModel.DataBase.CalculDistanceHistorique> CalculDistanceHistoriques { get; set; }
    }
}
