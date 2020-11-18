using System;
using System.Collections.Generic;
using System.Text;

namespace RoadCalculServices.Interface
{
    internal interface IserviceFactory
    {
        IBingService CreateBingService();
        IRouteService CreateRouteService();
        ISearchService CreateSearchService();
    }
}
