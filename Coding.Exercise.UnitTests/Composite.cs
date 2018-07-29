using System.Collections.Generic;
using Composite.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Composite
    {
        [TestMethod]
        public void Test()
        {
            var singleValue = new SingleValue {Value = 11};
            var otherValues = new ManyValues();
            otherValues.Add(22);
            otherValues.Add(33);
            Assert.AreEqual(new List<IValueContainer> {singleValue, otherValues}.Sum(), 66);
        }
    }
}