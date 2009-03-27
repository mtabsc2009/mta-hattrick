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
            gtNew.PlayACycle();
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
        public void TestLoadTeamWithoutLogin()
        {
            Game.Reset();
            Assert.IsNull(DBAccess.LoadTeam(Game.User));

        }
        
        [Test]
        public void TestLoadTeam()
        {
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

            Assert.AreEqual(elad * (elad - 1),DAL.DBAccess.GetNumOfCycles());
        }

        [Test]
        public void PlayACycle()
        {
            DAL.DBAccess.ClearAllCycles();
            Game.CreateNewLeagueCycles();
            Game.PlayNextCycle();

            Assert.AreEqual(Game.CyclesToList(DAL.DBAccess.GetAllCycles()).Where(T => T.GameID != -1).Count(),DAL.DBAccess.GetTeamCount() / 2) ;
        }

        [Test]
        public void BuyPlayer()
        {
            User usr = new User("eyal", "eyal");
            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);

            int eyalTeamBeforeSelling = tMyTeam.TeamCash;

            string playerName = "Shoko Haun";

            DAL.DBAccess.UpdateSellPlayer(playerName, 500);

            User usr2 = new User("q", "q");
            Team tMyTeam2 = DAL.DBAccess.LoadTeam(usr2);

            int qTeamBeforeSelling = tMyTeam2.TeamCash;

            Player playerToBuy = tMyTeam.Players.Where(T => T.Name.Equals(playerName)).First();
            DAL.DBAccess.BuyPlayer(tMyTeam2, playerToBuy);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            int eyalTeamAfterSelling = tMyTeam.TeamCash;

            tMyTeam2 = DAL.DBAccess.LoadTeam(usr2);
            int qTeamAfterSelling = tMyTeam2.TeamCash;

            Assert.AreEqual(eyalTeamBeforeSelling + playerToBuy.PlayerCost, eyalTeamAfterSelling);
            Assert.AreEqual(qTeamBeforeSelling - playerToBuy.PlayerCost, qTeamAfterSelling);

            //reverse
            DAL.DBAccess.UpdateSellPlayer(playerName, 500);

            tMyTeam = DAL.DBAccess.LoadTeam(usr2);
            playerToBuy = tMyTeam.Players.Where(T => T.Name.Equals(playerName)).First();

            Team eaylMyTeam = DAL.DBAccess.LoadTeam(usr);

            DAL.DBAccess.BuyPlayer(eaylMyTeam, playerToBuy);        
        }

        [Test]
        public void ChangeTrainingType()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            Game.ChangeTeamTrainngType(Consts.TrainingType.ATTACK);
            Assert.AreEqual(tMyTeam.TeamTrainingType, Consts.TrainingType.ATTACK);

            tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            Game.ChangeTeamTrainngType(Consts.TrainingType.PLAYMAKING);
            Assert.AreEqual(tMyTeam.TeamTrainingType, Consts.TrainingType.PLAYMAKING);
        }

        [Test]
        public void CheckTraining()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            Game.ChangeTeamTrainngType(Consts.TrainingType.ATTACK);
            Player plrAttacker = (Player)tMyTeam.Players.Where(T => T.Position == 11).First();
            float fLastLevel = plrAttacker.ScoringVal;
            Game.TrainTeam(tMyTeam);
            plrAttacker = (Player)tMyTeam.Players.Where(T => T.Position == 11).First();
            Assert.Greater(plrAttacker.ScoringVal, fLastLevel);
        }

        public void TrainTeamAlot()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            for (int i = 1; i < 200; i++)
            {
                tMyTeam.TeamTrainingType = (Consts.TrainingType.ATTACK);
                Game.TrainTeam(tMyTeam);
                tMyTeam.TeamTrainingType = (Consts.TrainingType.DEFENCE);
                Game.TrainTeam(tMyTeam);
                tMyTeam.TeamTrainingType = (Consts.TrainingType.PLAYMAKING);
                Game.TrainTeam(tMyTeam);
                tMyTeam.TeamTrainingType = (Consts.TrainingType.SETPIECES);
                Game.TrainTeam(tMyTeam);
                tMyTeam.TeamTrainingType = (Consts.TrainingType.WING);
                Game.TrainTeam(tMyTeam);
            }
            DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        public void TrainTeamAttackAlot()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            tMyTeam.TeamTrainingType = (Consts.TrainingType.ATTACK);
            for (int i = 1; i < 200; i++)
            {
                Game.TrainTeam(tMyTeam);
            }
            DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        public void ResetDebugTeamAbilities()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            foreach (Player plrCurr in tMyTeam.Players)
            {
                plrCurr.SetPiecesVal = 1;
                plrCurr.ScoringVal = 1;
                plrCurr.WingerVal = 1;
                plrCurr.PassingVal = 1;
                plrCurr.DefendingVal = 1;
                plrCurr.PlaymakingVal = 1;
                plrCurr.KeeperVal = 1;
            }
            DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        [Test]
        public void TrainAllTeams()
        {
            Game.TrainAllTeams(1);
        }
    }
}
