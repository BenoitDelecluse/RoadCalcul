using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadCalculRepository;
using ReadCalculRepository.Interface;
using RoadCalculServices.Interface;
using RoadCalculServices.Public;
using RoadCalculServices.Public.Interface;

namespace RoadCalculServices.Configuration
{
    public class ServiceCollectionForBusiness : IServiceCollectionForBusiness
    {
        public void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            var connections = configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<DBModelContext>(options =>
              options.UseSqlServer(connections));

            services.AddScoped<IRepoCalculDistanceHistorique, RepoCalculDistanceHistorique>();
            services.AddScoped<IRepoSearchHistorique, RepoSearchHistorique>();

            //public
            services.AddScoped<IBusinessBingService, BusinessBingService>();
            services.AddScoped<IBusinessRouteService, BusinessRouteService>();
            services.AddScoped<IBusinessSearchService, BusinessSearchService>();

            services.AddScoped<IBusinessService, BusinessService>();

            services.AddScoped<IserviceFactory, ServiceFactory>();


            services.AddScoped<IBingService, BingService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ISearchService, SearchService>();

         

        }
    }
}
