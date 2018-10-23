using HelloWorldApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUnitTests
{
    [TestClass]
    public class HelloControllerGetTests
    {
        private HelloController _controller;

        [TestInitialize]
        public void Arrange()
        {
            _controller = new HelloController();
        }

        public string Act()
        {
            return _controller.Get();
        }

        [TestMethod]
        public void ShouldReturnString()
        {
            var result = Act();

            Assert.AreEqual(result.GetType(), typeof(string));
        }

        [TestMethod]
        public void StringShouldReadAsExpected()
        {
            var result = Act();

            Assert.AreEqual(result, "Hello World!");
        }
    }
}
