using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Collections;
using HatTrick.CommonModel;
using HatTrick.DAL;
using HattrickGameService;

namespace HatTrick
{
    [TestFixture]
    public class GeneralTester
    {
        private Game Game = new Game();

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
            Assert.IsNull(DBAccess.LoadTeam(Game.getUser()));

        }
        
        [Test]
        public void TestLoadTeam()
        {
            Game.Login("etay", "etay");
            Assert.IsNotNull(DBAccess.LoadTeam(Game.getUser()));
            
        }

        [Test]
        public void CheckPlayerPosition()
        {
            User usr = new User("DebugUser", "DebugUser");
            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Player plrNew = tMyTeam.Players[0];

            plrNew.Position = 1;
            Assert.AreEqual(1, plrNew.Position);
            plrNew.Position = 2;
        }

        [Test]
        public void ChangePlayerPosition()
        {
            User usr = new User("DebugUser", "DebugUser");
            
            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Player plrNew = tMyTeam.Players[0];

            int nSavePos = plrNew.Position;

            plrNew.Position = 4;
            Assert.AreEqual(4, plrNew.Position);

            HatTrick.DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(4, plrNew.Position);

            plrNew.Position = nSavePos;

            HatTrick.DAL.DBAccess.UpdatePlayerPosition(plrNew);

            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            plrNew = tMyTeam.Players[0];
            Assert.AreEqual(nSavePos, plrNew.Position);
        }

        [Test]
        public void ChangeTeamFormation()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);

            HatTrick.DAL.DBAccess.ChangeTeamFormation(tMyTeam, "4-4-2");
            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Assert.AreEqual(tMyTeam.Formation, "4-4-2");

            HatTrick.DAL.DBAccess.ChangeTeamFormation(tMyTeam, "4-3-3");
            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Assert.AreEqual(tMyTeam.Formation, "4-3-3");

            usr = new User("DebugUser", "DebugUser");
            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
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

            GameStory gsNewGame2 = Game.GetGameStory(nNewGame);
            
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
            HatTrick.DAL.DBAccess.ClearAllCycles();

            Game.CreateNewLeagueCycles();

            int elad = HatTrick.DAL.DBAccess.GetTeamCount();

            Assert.AreEqual(elad * (elad - 1),HatTrick.DAL.DBAccess.GetNumOfCycles());
        }

        [Test]
        public void PlayACycle()
        {
            HatTrick.DAL.DBAccess.ClearAllCycles();
            Game.CreateNewLeagueCycles();
            Game.PlayNextCycle();

            Assert.AreEqual(Game.CyclesToList(HatTrick.DAL.DBAccess.GetAllCycles()).Where(T => T.GameID != -1).Count(),HatTrick.DAL.DBAccess.GetTeamCount() / 2) ;
        }

        [Test]
        public void BuyPlayer()
        {
            User usr = new User("eyal", "eyal");
            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);

            int eyalTeamBeforeSelling = tMyTeam.TeamCash;

            int playerId = 350;

            HatTrick.DAL.DBAccess.UpdateSellPlayer(playerId.ToString(), 500);

            User usr2 = new User("q", "q");
            Team tMyTeam2 = HatTrick.DAL.DBAccess.LoadTeam(usr2);

            int qTeamBeforeSelling = tMyTeam2.TeamCash;

            Player playerToBuy = tMyTeam.Players.Where(T => T.ID == playerId).First();
            HatTrick.DAL.DBAccess.BuyPlayer(tMyTeam2, playerToBuy);

            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            int eyalTeamAfterSelling = tMyTeam.TeamCash;

            tMyTeam2 = HatTrick.DAL.DBAccess.LoadTeam(usr2);
            int qTeamAfterSelling = tMyTeam2.TeamCash;

            Assert.AreEqual(eyalTeamBeforeSelling + playerToBuy.PlayerCost, eyalTeamAfterSelling);
            Assert.AreEqual(qTeamBeforeSelling - playerToBuy.PlayerCost, qTeamAfterSelling);

            //reverse
            HatTrick.DAL.DBAccess.UpdateSellPlayer(playerId.ToString(), 500);

            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr2);
            playerToBuy = tMyTeam.Players.Where(T => T.ID == playerId).First();

            Team eaylMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);

            HatTrick.DAL.DBAccess.BuyPlayer(eaylMyTeam, playerToBuy);        
        }

        [Test]
        public void ChangeTrainingType()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            Game.ChangeTeamTrainngType(Consts.TrainingType.ATTACK);
            Assert.AreEqual(tMyTeam.TeamTrainingType, Consts.TrainingType.ATTACK);

            tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            Game.ChangeTeamTrainngType(Consts.TrainingType.PLAYMAKING);
            Assert.AreEqual(tMyTeam.TeamTrainingType, Consts.TrainingType.PLAYMAKING);
        }

        [Test]
        public void CheckTraining()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
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

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
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
            HatTrick.DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        public void TrainTeamAttackAlot()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
            Game.MyTeam = tMyTeam;

            tMyTeam.TeamTrainingType = (Consts.TrainingType.ATTACK);
            for (int i = 1; i < 200; i++)
            {
                Game.TrainTeam(tMyTeam);
            }
            HatTrick.DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        public void ResetDebugTeamAbilities()
        {
            User usr = new User("DebugUser", "DebugUser");

            Team tMyTeam = HatTrick.DAL.DBAccess.LoadTeam(usr);
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
            HatTrick.DAL.DBAccess.SaveTeamSkills(tMyTeam);
        }

        [Test]
        public void TrainAllTeams()
        {
            Game.TrainAllTeams(1);
        }
    }
}
