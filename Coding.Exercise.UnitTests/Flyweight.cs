using Flyweight.Coding.Exercise;
using NUnit.Framework;

namespace Coding.Exercise.UnitTests
{
    [TestFixture]
    public class Flyweight
    {
        [Test]
        public void Test()
        {
            var s = new Sentence("alpha beta gamma");
            s[1].Capitalize = true;
            Assert.That(s.ToString(),
                Is.EqualTo("alpha BETA gamma"));
        }
    }
}