using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HatTrick.CommonModel;
using DAL;

namespace HatTrick
{
    [TestFixture]
    public class GeneralTester
    {
        public static void Main(string[] args)
        {
            GeneralTester gtNew = new GeneralTester();
            gtNew.ChangeTeamFormation();
        }
            
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
        public void TestLoadTeam()
        {
            Assert.IsNull(DBAccess.LoadTeam(Game.User));
            Game.Login("etay", "etay");
            Assert.IsNotNull(DBAccess.LoadTeam(Game.User));
            
        }

        [Test]
        public void CheckPlayerPosition()
        {
            User usr = new User("DebugUser", "DebugUser");
            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Player plrNew = tMyTeam.Players[0];

            plrNew.Position = 1;
            Assert.AreEqual(1, plrNew.Position);
            plrNew.Position = 2;
        }

        [Test]
        public void ChangePlayerPosition()
        {
            User usr = new User("DebugUser", "DebugUser");
            
            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Player plrNew = tMyTeam.Players[0];

            plrNew.Position = 1;
            Assert.AreEqual(1, plrNew.Position);

            DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(1, plrNew.Position);

            plrNew.Position = 2;

            DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(2, plrNew.Position);
        }

        [Test]
        public void ChangeTeamFormation()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);

            DAL.DBAccess.ChangeTeamFormation(tMyTeam, "4-4-2");
            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Assert.AreEqual(tMyTeam.Formation, "4-4-2");

            DAL.DBAccess.ChangeTeamFormation(tMyTeam, "4-3-3");
            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Assert.AreEqual(tMyTeam.Formation, "4-3-3");

            usr = new User("DebugUser", "DebugUser");
            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Assert.AreEqual(tMyTeam.Formation, "4-3-3");

        }
    }
}
