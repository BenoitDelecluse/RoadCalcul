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
    internal class SearchService : ISearchService
    {
        private readonly IRepoSearchHistorique RepoSearchHistorique;

        public SearchService(IRepoSearchHistorique repoSearchHistorique)
        {
            this.RepoSearchHistorique = repoSearchHistorique;
        }
        public async Task<bool> Add(SearchHistorique value)
        {
            if (IsSearchHistorique(value,true))
            {
                return await RepoSearchHistorique.Add(value);
            }
            return false;
        }

        public async Task<List<SearchHistorique>> GetAll()
        {
            return await RepoSearchHistorique.GetAll();
        }

        public async Task<bool> Update(SearchHistorique value)
        {
            if (IsSearchHistorique(value,false))
            {
                return await RepoSearchHistorique.Update(value);
            }
            return false;
        }

        private bool IsSearchHistorique(SearchHistorique value,bool isadd)
        {
            if (!isadd)
            {
                if (value.ID < 1)
                {
                    return false;
                }
            }
           
            if (string.IsNullOrEmpty(value.Querry))
            {
                return false;
            }

            if (value.Time == null)
            {
                return false;
            }

            return true;
        }
    }
}
