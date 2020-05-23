using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanionRespec.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodNameIndexAnalysis()
        {
            var testName = "Adam";
            var testIndex = 2;
            var testString = testName + Utils.Separator + testIndex;
            (var name, var index) = Utils.NameIndexAnalysis(testString);
            Console.WriteLine($"str: {testString} name: {name} index: {index}");
            Assert.IsTrue(name == testName && index == testIndex - 1);
        }

        [TestMethod]
        public void TestMethodGetAllPerks()
        {
            var perks = Utils.AllPerks;
            Assert.IsTrue(perks.Length > 0);
        }
    }
}

namespace CompanionRespec
{
    internal static partial class Utils { }
}