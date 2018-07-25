using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer.Coding.Exercise;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Observer
    {
        [TestMethod]
        public void PlayingByTheRules()
        {
            Assert.AreEqual(typeof(Game).GetFields().Length, 0, "Game has fields");
            Assert.AreEqual(typeof(Game).GetProperties().Length, 0, "Game has properties");
        }

        [TestMethod]
        public void SingleRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            Assert.AreEqual(rat.Attack, 1, "Invalid rat attack");
        }

        [TestMethod]
        public void TwoRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            var rat2 = new Rat(game);
            Assert.AreEqual(rat.Attack, 2, "Invalid rat attack");
            Assert.AreEqual(rat2.Attack, 2, "Invalid rat attack");
        }

        [TestMethod]
        public void ThreeRatsOneDies()
        {
            var msg = "Invalid rat attack";
            var game = new Game();

            var rat = new Rat(game);
            Assert.AreEqual(rat.Attack, 1, msg);

            var rat2 = new Rat(game);
            Assert.AreEqual(rat.Attack, 2, msg);
            Assert.AreEqual(rat2.Attack, 2, msg);

            using (var rat3 = new Rat(game))
            {
                Assert.AreEqual(rat.Attack, 3, msg);
                Assert.AreEqual(rat2.Attack, 3, msg);
                Assert.AreEqual(rat3.Attack, 3, msg);
            }

            Assert.AreEqual(rat.Attack, 2, msg);
            Assert.AreEqual(rat2.Attack, 2, msg);
        }

    }
}