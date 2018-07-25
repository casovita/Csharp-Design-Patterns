using System;
using Builder.Coding.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coding.Exercise.UnitTests
{
    [TestClass]
    public class Bulder
    {
        private static string Preprocess(string s)
        {
            return s.Trim().Replace("\r\n", "\n");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var cb = new CodeBuilder("Foo");
            Assert.AreEqual<string>(Preprocess(cb.ToString()), "public class Foo\n{\n}");
        }

        [TestMethod]
        public void PersonTest()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Assert.AreEqual<string>(Preprocess(cb.ToString()),

                  @"public class Person
                   {
                     public string Name;
                     public int Age;
                   }"
                );
        }
    }
}
