using DeveloperToolsPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperToolsTests
{
    [TestClass]
    public class TestsBase
    {
        [TestMethod]
        public void EmptyString()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("");
            Assert.AreEqual(result, "Please input a string");
        }

        [TestMethod]
        public void CommandQweNotFount()
        {
            var developerTools = new DeveloperTools("telegram");
            var result = developerTools.Run("/qwe this is text");
            Assert.AreEqual(result, "Command \"**/qwe**\" not found. See \"**/help**\" command.");
        }

        [TestMethod]
        public void CommandQwe2NotFount()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("qwe");
            Assert.AreEqual(result, "Command \"**qwe**\" not found. See \"**help**\" command.");
        }
    }
}
