using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadCalculRepository.Interface;
using RoadCalculModel.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadCalculRepository
{
    public class RepoCalculDistanceHistorique : IRepoCalculDistanceHistorique
    {
        IServiceProvider ServiceProvider;
        public RepoCalculDistanceHistorique(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public Task<List<CalculDistanceHistorique>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoadCalculModel.DataBase.CalculDistanceHistorique>> GetAll()
        {
            var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
            using (var db = new DBModelContext(context))
            {
                var result = await db.CalculDistanceHistoriques.ToListAsync();
                return result;
            }
        }

        public async Task<bool> Add(CalculDistanceHistorique value)
        {
            try
            {
                var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
                using (var db = new DBModelContext(context))
                {
                    value.ID = 0;
                    var result = await db.CalculDistanceHistoriques.AddAsync(value);
                    await db.SaveChangesAsync();
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TODO LOG
                return false;
            }

        }

        public async Task<bool> Update(CalculDistanceHistorique value)
        {
            try
            {
                var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
                using (var db = new DBModelContext(context))
                {
                    var result = db.CalculDistanceHistoriques.Update(value);
                    await db.SaveChangesAsync();
                    if (result != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
