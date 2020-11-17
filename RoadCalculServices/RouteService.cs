using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadCalculRepository;
using ReadCalculRepository.Interface;
using RoadCalculModel.DataBase;
using RoadCalculServices.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadCalculServices
{
    public class RouteService : IRouteService
    {
        private readonly IRepoCalculDistanceHistorique RepoCalculDistanceHistorique;

        public RouteService(IRepoCalculDistanceHistorique repoCalculDistanceHistorique)
        {
            this.RepoCalculDistanceHistorique = repoCalculDistanceHistorique;
        }

        public async Task<bool> Add(CalculDistanceHistorique value)
        {
            if (IsValidCalCulDistanctHistorique(value,true))
            {
                return await RepoCalculDistanceHistorique.Add(value);
            }
            return false;
        }

        public async Task<List<CalculDistanceHistorique>> GetAll()
        {
            return await RepoCalculDistanceHistorique.GetAll();
        }

        public async Task<bool> Update(CalculDistanceHistorique value)
        {
            if (IsValidCalCulDistanctHistorique(value,false))
            {
                return await RepoCalculDistanceHistorique.Update(value);
            }
            return false;
        }

        public double GetCosumption(double carcosumption, double distance)
        {
            var cosumperKM = carcosumption / 100;
            var FullCosum = cosumperKM * distance;
            return FullCosum;
        }

        private bool IsValidCalCulDistanctHistorique(CalculDistanceHistorique value, bool isadd)
        {
            if (!isadd)
            {
                if (value.ID < 1)
                {
                    return false;
                }
            }
            if (value.CarConsumption <= 0)
            {
                return false;
            }
            if (value.OriginLat == 0)
            {
                return false;
            }
            if (value.DestinationLong == 0)
            {
                return false;
            }
            if (value.OriginLong == 0)
            {
                return false;
            }
            if (value.DestinationLat == 0)
            {
                return false;
            }
            return true;
        }
    }
}
