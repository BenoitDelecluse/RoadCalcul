using Moq;
using NUnit.Framework;
using ReadCalculRepository.Interface;
using RoadCalculModel.DataBase;
using RoadCalculServices;
using RoadCalculServices.Interface;
using System.Collections.Generic;
using System.Threading;

namespace RoadCalculTestService
{
    [TestFixture]
    public class UnitTestRouteervice
    {
        private IRouteService RouteService;
        [SetUp]
        public void Setup()
        {
            Mock<IRepoCalculDistanceHistorique> Repo = new Mock<IRepoCalculDistanceHistorique>();
            var returnlist = new List<CalculDistanceHistorique>();
            var item1 = new CalculDistanceHistorique
            { };
            returnlist.Add(item1);
            var item2 = new CalculDistanceHistorique
            { };
            returnlist.Add(item2);
            Repo.Setup(r => r.GetAll()).ReturnsAsync(returnlist);
            Repo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(item1);
            Repo.Setup(r => r.Add(It.IsAny<CalculDistanceHistorique>())).ReturnsAsync(true);
            Repo.Setup(r => r.Update(It.IsAny<CalculDistanceHistorique>())).ReturnsAsync(true);
            RouteService = new RouteService(Repo.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll()
        {
            var result = await RouteService.GetAll();
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.Greater(result.Count, 0, "exepected No results");
        }

        [Test]
        public async System.Threading.Tasks.Task Add()
        {
            var item1 = new CalculDistanceHistorique
            {
                CarConsumption = 1,
                DestinationLat = 50,
                DestinationLong = 3,
                DestinationName = "Test name Dest",
                DestinationType = "Road",
                OriginLat = 51,
                OriginLong = 4,
                OriginName = "Test name Origin",
                OriginType = "Adress"
            };
            var result = await RouteService.Add(item1);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.IsTrue(result,"exepected true");
        }

        [TestCase(0, 50, 3, 51 , 4)]
        [TestCase(-134, 50, 3, 51 , 4)]
        [TestCase(1, 0, 3, 51 , 4)]
        [TestCase(1, 50, 0, 51 , 4)]
        [TestCase(1, 50, 3, 0 , 4)]
        [TestCase(1, 50, 3, 51 , 0)]
        public async System.Threading.Tasks.Task Faild(double carConsumption, double destinationLat, double destinationLong, double originLat, double originLong)
        {
            var item1 = new CalculDistanceHistorique
            {
                CarConsumption = carConsumption,
                DestinationLat = destinationLat,
                DestinationLong = destinationLong,
                DestinationName = "Test name Dest",
                DestinationType = "Road",
                OriginLat = originLat,
                OriginLong = originLong,
                OriginName = "Test name Origin",
                OriginType = "Adress"
            };
            var result = await RouteService.Add(item1);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.IsFalse(result, "exepected false");
        }

        [TestCase(1, 100, 1)]
        [TestCase(2, 100, 2)]
        [TestCase(2, 50, 1)]
        [TestCase(1, 50, 0.5)]
        public void TestCalculConsumption(double carcosum, double distance, double expectedresult)
        {
            var result = RouteService.GetCosumption(carcosum,distance);
            Assert.AreEqual(result, expectedresult, "exepected " + expectedresult);
        }
    }
}