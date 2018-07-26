using Adapter.Coding.Execise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Adapter
    {
        [TestMethod]
        public void Test()
        {
            var sq = new Square {Side = 11};
            var adapter = new SquareToRectangleAdapter(sq);
            Assert.AreEqual(adapter.Area(),121,"fails");
        }
    }
}