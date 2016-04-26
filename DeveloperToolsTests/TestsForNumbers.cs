using System;
using DeveloperToolsPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperToolsTests
{
    [TestClass]
    public class TestsForNumbers
    {
        [TestMethod]
        public void Convert100From10To2()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ConvertTo 100 10 2");
            Assert.AreEqual(result, "1100100");
        }

        [TestMethod]
        public void Convert100From10To16()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ConvertTo 100 10 16");
            Assert.AreEqual(result, "64");
        }

        [TestMethod]
        public void ConvertABCDEFrom16To10()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ConvertTo ABCDE 16 10");
            Assert.AreEqual(result, "703710");
        }

        [TestMethod]
        public void ConvertABCDEFGHIJFrom30To10()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ConvertTo ABCDEFGHIJ 30 10");
            Assert.AreEqual(result, "9066498599999");
        }

        [TestMethod]
        public void ConvertABCDEFGHIJFrom17To20()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ConvertTo ABCDEFGHIJ 17 20");
            Assert.AreEqual(result, "29AA9EF9HD");
        }
    }
}
