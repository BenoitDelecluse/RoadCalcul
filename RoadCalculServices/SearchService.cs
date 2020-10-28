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
    public class SearchService : ISearchService
    {
        private readonly IRepoSearchHistorique RepoSearchHistorique;

        public SearchService(IRepoSearchHistorique repoSearchHistorique)
        {
            this.RepoSearchHistorique = repoSearchHistorique;
        }
        public async Task<bool> Add(SearchHistorique value)
        {
            if (IsSearchHistorique(value))
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
            if (IsSearchHistorique(value))
            {
                return await RepoSearchHistorique.Update(value);
            }
            return false;
        }

        private bool IsSearchHistorique(SearchHistorique value)
        {
            if (value.ID < 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(value.Querry))
            {
                return false;
            }
           
            return true;
        }
    }
}
