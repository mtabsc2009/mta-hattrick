using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HatTrick
{
    [TestFixture]
    public class GeneralTester
    {
        static void Main(string[] args)
        {
            GeneralTester tester = new GeneralTester();

            tester.TestGameStart();
            tester.TestUserCreation();
        }

        [Test]
        public void TestGameStart()
        {
            NUnit.Framework.Assert.IsTrue(Game.Start());
        }

        [Test]
        public void TestUserCreation()
        {
            NUnit.Framework.Assert.IsTrue(Game.CreateUser("Oron", "oron"));
        }
    }
}
