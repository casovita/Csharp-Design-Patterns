using ChainOfResponsibility.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class ChainOfResponsibility
    {
        [TestMethod]
        public void Test()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);

            Assert.AreEqual(goblin.Attack, 1);
            Assert.AreEqual(goblin.Defense, 1);

            var goblin2 = new Goblin(game);
            game.Creatures.Add(goblin2);

            Assert.AreEqual(goblin.Attack, 1);
            Assert.AreEqual(goblin.Defense, 2);

            var goblin3 = new GoblinKing(game);
            game.Creatures.Add(goblin3);

            Assert.AreEqual(goblin.Attack, 2);
            Assert.AreEqual(goblin.Defense, 3);
        }
    }
}