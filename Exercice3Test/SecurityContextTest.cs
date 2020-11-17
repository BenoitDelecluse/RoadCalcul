using NUnit.Framework;
using Exercice3Library;
using Exercice3Library.Algorithm;
using Exercice3Library.Security;
using System.Collections.Generic;

namespace Exercice3Test
{

    public class SecurityContextTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckRolesForFileAdmin()
        {
            var context = new SecurityContext(Roletype.Admin);
            var path = "test.txt";
            var result = context.CheckRolesForFile(path);
            Assert.IsTrue(result, "expected true");
        }

        [Test]
        public void CheckRolesForFileOtherBlock()
        {
            var context = new SecurityContext(Roletype.Other);
            var path = "test.txt";
            var result = context.CheckRolesForFile(path);
            Assert.IsFalse(result, "expected true");
        }

        [Test]
        public void CheckRolesForFileOtherAllow()
        {
            var context = new SecurityContext(Roletype.Other, new List<string> { "test.txt" });
            var path = "test.txt";
            var result = context.CheckRolesForFile(path);
            Assert.IsTrue(result, "expected true");
        }
    }
}