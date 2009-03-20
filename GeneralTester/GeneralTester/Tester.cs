using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HatTrick.CommonModel;
using DAL;
using System.Collections;

namespace HatTrick
{
    [TestFixture]
    public class GeneralTester
    {
        public static void Main(string[] args)
        {
            GeneralTester gtNew = new GeneralTester();

            gtNew.ChangePlayerPosition();
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

            int nSavePos = plrNew.Position;

            plrNew.Position = 4;
            Assert.AreEqual(4, plrNew.Position);

            DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(4, plrNew.Position);

            plrNew.Position = nSavePos;

            DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(nSavePos, plrNew.Position);
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

        [Test]
        public void MatchTeamsSuccessfully()
        {
            Assert.IsNotNull(Game.MatchTeams("oron", "Monery"));
        }

        [Test]
        public void MatchTeamsFailure()
        {
            Assert.IsNull(Game.MatchTeams("oron1", "Monery"));
        }

        [Test]
        public void GameSavedInDB()
        {

            GameStory gsNewGame = Game.MatchTeams("oron", "Monery");
            
            int nNewGame = Game.SaveStoryToDB(gsNewGame);

            GameStory gsNewGame2 = Game.LoadGameStory(nNewGame);
            
            Assert.AreEqual(gsNewGame.AwayScore, gsNewGame2.AwayScore);
            Assert.AreEqual(gsNewGame.HomeScore, gsNewGame2.HomeScore);
            Assert.AreEqual(gsNewGame.HomeTeam.Team.Name, gsNewGame2.HomeTeam.Team.Name);
            Assert.AreEqual(gsNewGame.AwayTeam.Team.Name, gsNewGame2.AwayTeam.Team.Name);
            Assert.AreEqual(gsNewGame.GameDate.Millisecond, gsNewGame2.GameDate.Millisecond);
        }

        [Test]
        public void CheckCreateLeague()
        {

            // CLEARS ALL CYCLES!!!
            DAL.DBAccess.ClearAllCycles();

            Game.CreateNewLeagueCycles();

            int elad = DAL.DBAccess.GetTeamCount();

            Assert.AreEqual(DAL.DBAccess.GetNumOfCycles(), elad * (elad - 1));
        }

        [Test]
        public void PlayACycle()
        {
            DAL.DBAccess.ClearAllCycles();
            Game.CreateNewLeagueCycles();
            Game.PlayNextCycle();

            Assert.AreEqual(Game.CyclesToList(DAL.DBAccess.GetAllCycles()).Where(T => T.GameID != -1).Count(),DAL.DBAccess.GetTeamCount() / 2) ;
        }
    }
}
