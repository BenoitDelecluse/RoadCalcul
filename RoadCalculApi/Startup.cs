using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadCalculRepository;
using ReadCalculRepository.Interface;
using RoadCalculServices;
using RoadCalculServices.Configuration;
using RoadCalculServices.Interface;
using RoadCalculServiceTest.Services;

namespace RoadCalculApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IServiceCollectionForBusiness serviceCollectionForBusiness)
        {
            Configuration = configuration;
            _serviceCollectionForBusiness = serviceCollectionForBusiness;
        }

        public IConfiguration Configuration { get; }
        private readonly IServiceCollectionForBusiness _serviceCollectionForBusiness;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            var connections = Configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<DBModelContext>(options =>
              options.UseSqlServer(connections));

            services.AddScoped<IRepoCalculDistanceHistorique, RepoCalculDistanceHistorique>();
            services.AddScoped<IRepoSearchHistorique, RepoSearchHistorique>();

            _serviceCollectionForBusiness.RegisterDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
           }); 
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
