using System;
using DeveloperToolsPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperToolsTests
{
    [TestClass]
    public class TestsForDateTime
    {
        [TestMethod]
        public void FromUnixTime1456839000()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("FromUnixTime 1456839000");
            Assert.AreEqual(result, "01.03.2016 13:30:00");
        }

        [TestMethod]
        public void ToUnixTime01_03_2016__13_30_00()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ToUnixTime 01.03.2016 13:30:00");
            Assert.AreEqual(result, "1456839000");
        }
    }
}
