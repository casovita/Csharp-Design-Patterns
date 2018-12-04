using Command.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    
namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Test()
        {
            var a = new Account();

            var command = new Command.Coding.Exercise.Command{Amount = 100, TheAction = Command.Coding.Exercise.Command.Action.Deposit};
            a.Process(command);

            Assert.AreEqual(a.Balance, 100);
            Assert.IsTrue(command.Success);

            command = new Command.Coding.Exercise.Command{Amount = 50, TheAction = Command.Coding.Exercise.Command.Action.Withdraw};
            a.Process(command);

            Assert.AreEqual(a.Balance, 50);
            Assert.IsTrue(command.Success);

            command = new Command.Coding.Exercise.Command { Amount = 150, TheAction = Command.Coding.Exercise.Command.Action.Withdraw };
            a.Process(command);

            Assert.AreEqual(a.Balance, 50);
            Assert.IsFalse(command.Success);
        }
        
    }
}