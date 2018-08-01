using Decorator.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Decorator
    {
        [TestMethod]
        public void DecoratorTest()
        {
            var msg = "fail";
            var dragon = new Dragon();

            Assert.AreEqual(dragon.Fly(), "flying",msg);
            Assert.AreEqual(dragon.Crawl(), "too young",msg);

            dragon.Age = 20;

            Assert.AreEqual(dragon.Fly(), "too old",msg);
            Assert.AreEqual(dragon.Crawl(), "crawling",msg);
        }
    }
}