using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RoadCalculServices.Configuration
{
    public interface IServiceCollectionForBusiness
    {        void RegisterDependencies(IConfiguration configuration, IServiceCollection services);
    }
}
