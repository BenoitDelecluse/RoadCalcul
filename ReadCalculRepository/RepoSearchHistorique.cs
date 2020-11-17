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
    public class RepoSearchHistorique : IRepoSearchHistorique
    {
        IServiceProvider ServiceProvider;
        public RepoSearchHistorique(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public Task<SearchHistorique> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoadCalculModel.DataBase.SearchHistorique>> GetAll()
        {
            var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
            using (var db = new DBModelContext(context))
            {
                var result = await db.SearchHistoriques.ToListAsync();
                return result;
            }
        }

        public async Task<bool> Add(SearchHistorique value)
        {
            try
            {
                var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
                using (var db = new DBModelContext(context))
                {
                    value.ID = 0;
                    var result = await db.SearchHistoriques.AddAsync(value);
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

        public async Task<bool> Update(SearchHistorique value)
        {
            try
            {
                var context = ServiceProvider.GetRequiredService<DbContextOptions<DBModelContext>>();
                using (var db = new DBModelContext(context))
                {
                    var result = db.SearchHistoriques.Update(value);
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
