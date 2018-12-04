using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullObject.Coding.Excercise;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    class NullObject
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var a = new Account(new NullLog());
            a.SomeOperation();


            for (int i = 0; i < 100; ++i)
                a.SomeOperation();
        }
    }
}
