using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Coding.Execise;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Prototype
    {
        [TestMethod]
        public void TestMethod1()
        {
            var line1 = new Line(new Point(3, 3), new Point(10, 10));

            var line2 = line1.DeepCopy();

            line1._Start.X = line1._End.X = line1._Start.Y = line1._End.Y = 0;

            var message = "Not Equal";
            Assert.AreEqual(line2._Start.X, 3, message);
            Assert.AreEqual(line2._Start.Y, 3, message);
            Assert.AreEqual(line2._End.X, 10, message);
            Assert.AreEqual(line2._End.Y, 10, message);
        }
    }
}