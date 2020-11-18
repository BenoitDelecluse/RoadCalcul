using Moq;
using NUnit.Framework;
using ReadCalculRepository.Interface;
using RoadCalculModel.DataBase;
using RoadCalculServices;
using RoadCalculServices.Interface;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RoadCalculTestService
{
    [TestFixture]
    public class UnitTestRouteervice
    {

        private ISearchService Service;
        [SetUp]
        public void Setup()
        {
            Mock<IRepoSearchHistorique> Repo = new Mock<IRepoSearchHistorique>();
            var returnlist = new List<SearchHistorique>();
            var item1 = new SearchHistorique
            { };
            returnlist.Add(item1);
            var item2 = new SearchHistorique
            { };
            returnlist.Add(item2);
            Repo.Setup(r => r.GetAll()).ReturnsAsync(returnlist);
            Repo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(item1);
            Repo.Setup(r => r.Add(It.IsAny<SearchHistorique>())).ReturnsAsync(true);
            Repo.Setup(r => r.Update(It.IsAny<SearchHistorique>())).ReturnsAsync(true);
            Service = new SearchService(Repo.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll()
        {
            var result = await Service.GetAll();
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.Greater(result.Count, 0, "exepected No results");
        }

        [Test]
        public async System.Threading.Tasks.Task Add()
        {
            var item1 = new SearchHistorique
            {
                Querry = "value",
                Time = DateTime.Now,
            };
            var result = await Service.Add(item1);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.IsTrue(result, "exepected true");
        }

        public async System.Threading.Tasks.Task Faildquerry()
        {
            var item1 = new SearchHistorique
            {
                Querry = null,
                Time = DateTime.Now,
            };
            var result = await Service.Add(item1);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.IsFalse(result, "exepected false");
        }

        public async System.Threading.Tasks.Task FaildTime()
        {
            var item1 = new SearchHistorique
            {
                Querry = "value",
            };
            var result = await Service.Add(item1);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.IsFalse(result, "exepected false");
        }
    }
}