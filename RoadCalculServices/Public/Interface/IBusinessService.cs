using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadCalculServices.Public.Interface
{
    public interface IBusinessService
    {
        IBusinessBingService Bing { get; }
        IBusinessRouteService Route { get; }
        IBusinessSearchService Search { get; }       
    }

   

   

   
}
