using NUnit.Framework;
using RoadCalculServices;
using RoadCalculServices.Interface;
using System.Threading;

namespace RoadCalculTestService
{
    [TestFixture]
    public class UnitTestBingService
    {
        private IBingService Service;
        [SetUp]
        public void Setup()
        {
            Service = new BingService();
        }

        [Test]
        public async System.Threading.Tasks.Task GetLocationAsync()
        {
            Thread.Sleep(1000); //service accepte only 1 call per sec.
            var result = await Service.GetLocationAsync("Rue de la culture 5, Tournai");
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.Greater(result.Count, 0, "exepected No results");
        }

        [Test]
        public async System.Threading.Tasks.Task GetLocationAsyncFaild()
        {
            Thread.Sleep(1000); //service accepte only 1 call per sec.
            var result = await Service.GetLocationAsync("blablabla");
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.AreEqual(result.Count, 0, "execpted Result count is zero");
        }

        [Test]
        public async System.Threading.Tasks.Task DistanceMatrixAsyncFaild()
        {
            var criteria = new RoadCalculModel.Route
            {
                Destination = new RoadCalculModel.Parking(),
                origin = new RoadCalculModel.Parking(),
            };
            Thread.Sleep(1000); //service accepte only 1 call per sec.
            var result = await Service.DistanceMatrixAsync(criteria);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.AreEqual(result.Count, 1, "Result count must equals 1");
            Assert.IsNotNull(result[0].Results, "Call service faild");
            Assert.IsNotNull(result[0].Results[0], "Call service faild");
            Assert.AreEqual(result[0].Results[0].TravelDistance,0, "Call service faild");
            Assert.AreEqual(result[0].Results[0].TravelDuration,0, "Call service faild");
        }

        [Test]
        public async System.Threading.Tasks.Task DistanceMatrixAsync()
        {
            var criteria = new RoadCalculModel.Route
            {
                Destination = new RoadCalculModel.Parking 
                {
                     Latitude = 50,
                     Longiture = 3,
                },
                origin = new RoadCalculModel.Parking
                {
                    Latitude = 51,
                    Longiture = 4,
                },
            };
            Thread.Sleep(1000); //service accepte only 1 call per sec.
            var result = await Service.DistanceMatrixAsync(criteria);
            Assert.IsNotNull(result, "Call service faild");
            //Assert.IsNull(result.Result, "Call service faild");
            Assert.AreEqual(result.Count, 1, "Result count must equals 1");
            Assert.IsNotNull(result[0].Results, "Call service faild");
            Assert.IsNotNull(result[0].Results[0], "Call service faild");
            Assert.IsNotNull(result[0].Results[0].TravelDistance, "Call service faild");
            Assert.IsNotNull(result[0].Results[0].TravelDuration, "Call service faild");
        }
    }
}