using System;
using DeveloperToolsPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperToolsTests
{
    [TestClass]
    public class TestsForGuid
    {
        [TestMethod]
        public void GetNewGuid()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("newGuid");
            Guid guid;
            Guid.TryParse(result, out guid);
            Assert.AreNotEqual(guid, Guid.Empty);
        }
    }
}
