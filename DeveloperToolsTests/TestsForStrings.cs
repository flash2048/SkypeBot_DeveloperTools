using DeveloperToolsPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperToolsTests
{
    [TestClass]
    public class TestsForStrings
    {
        [TestMethod]
        public void ToUpperTest()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ToUpper test");
            Assert.AreEqual(result, "TEST");
        }
        [TestMethod]
        public void ToUpperTestWithSpace()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ToUpper test test test");
            Assert.AreEqual(result, "TEST TEST TEST");
        }

        [TestMethod]
        public void ToLowerTest()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("tolower TEST");
            Assert.AreEqual(result, "test");
        }

        [TestMethod]
        public void FromBase64_test1()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("frombase64 VGhpcyBpcyB0ZXh0");
            Assert.AreEqual(result, "This is text");
        }

        [TestMethod]
        public void FromBase64_test2()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("FromBase64 SGVsbG8sIHdvcmxkIQ==");
            Assert.AreEqual(result, "Hello, world!");
        }

        [TestMethod]
        public void FromBase64_test3()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("FromBase64 Rmxhc2gyMDQ4LmNvbQ==");
            Assert.AreEqual(result, "Flash2048.com");
        }



        [TestMethod]
        public void ToBase64_test1()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("Tobase64 This is text");
            Assert.AreEqual(result, "VGhpcyBpcyB0ZXh0");
        }

        [TestMethod]
        public void ToBase64_test2()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ToBase64 Hello, world!");
            Assert.AreEqual(result, "SGVsbG8sIHdvcmxkIQ==");
        }

        [TestMethod]
        public void ToBase64_test3()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("ToBase64 Flash2048.com");
            Assert.AreEqual(result, "Rmxhc2gyMDQ4LmNvbQ==");
        }

        [TestMethod]
        public void GenerateNewPassword()
        {
            var developerTools = new DeveloperTools();
            var result = developerTools.Run("password 21");
            Assert.AreEqual(result.Length, 21);
        }
    }
}
