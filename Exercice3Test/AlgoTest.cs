using NUnit.Framework;
using Exercice3Library;
using Exercice3Library.Algorithm;
using Exercice3Library.Security;

namespace Exercice3Test
{

    public class AlgoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Crypte()
        {
            var Algo = new TextCrypted();
            var value = "12345";
            var result = Algo.Crypte(value);
            Assert.AreEqual(result, "54321", "expected equals");
        }

        [Test]
        public void UnCrypte()
        {
            var Algo = new TextCrypted();
            var value = "12345";
            var result = Algo.Uncrypte(value);
            Assert.AreEqual(result, "54321", "expected equals");
        }
    }
}