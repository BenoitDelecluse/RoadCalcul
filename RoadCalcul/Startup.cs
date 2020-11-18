using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadCalculRepository;
using ReadCalculRepository.Interface;
using RoadCalculServices;
using RoadCalculServices.Configuration;
using RoadCalculServices.Interface;

namespace RoadCalcul
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
