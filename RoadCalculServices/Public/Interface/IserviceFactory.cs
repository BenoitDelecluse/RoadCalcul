using RoadCalculServices.Interface;

namespace RoadCalculServices.Public.Interface
{
    internal interface IserviceFactory
    {
        IBingService CreateBingService();
        IRouteService CreateRouteService();
        ISearchService CreateSearchService();
    }
}
