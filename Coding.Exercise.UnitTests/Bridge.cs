using Bridge.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Bridge
    {
        [TestMethod]
        public void Test()
        {
            var sq = new Square(new VectorRenderer()).ToString();
            Assert.AreEqual(sq, "Drawing Square as lines","Invalid");
        }
    }
}