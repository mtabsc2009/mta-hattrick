using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HatTrick.CommonModel;

namespace HatTrick
{
    [TestFixture]
    public class GeneralTester
    {
        [Test]
        public void TestUserLoginSuccess()
        {
            User usrUser = Game.Login("Oron", "oron");
            Assert.AreEqual("Oron", usrUser.Username);
            Assert.AreEqual("oron", usrUser.Password);
        }

        [Test]
        public void TestUserCreationFailure()
        {
            Game.Reset();
            Game.CreateUser("DebugUser", "DebugUser");
            Assert.IsFalse(Game.CreateUser("DebugUser", "DebugUser"));
            Game.Reset();
        }

        [Test]
        public void TestUserLoginFailure()
        {
            Assert.IsNull(Game.Login("Oron", "elad"));
        }

        [Test]
        public void TestUserCreationSuccess()
        {
            Game.Reset();
            Assert.IsTrue(Game.CreateUser("DebugUser", "DebugUser"));
        }

        [Test]
        public void TestManageTeam()
        {
            Game.Login("etay", "etay");
            Assert.IsNotNull(Game.ManageTeam());
        }
    }
}
