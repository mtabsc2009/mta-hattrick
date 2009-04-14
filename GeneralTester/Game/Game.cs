using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using HatTrick.CommonModel;


namespace HatTrick
{
    public class Game
    {
        private static User m_usrCurrent = null;

        private static Team tMyTeam = null;
        private static bool[] m_barrTakenMinutes = new bool[90];
        private static Dictionary<string, Team> m_dicTeams = null;

        public static Team MyTeam
        {
            get { return Game.tMyTeam; }
            set { Game.tMyTeam = value; }
        }
        public static User User
        {
            get { return Game.m_usrCurrent; }
        }
        public static Dictionary<string, Team> Teams
        {
            get
            {
                if (m_dicTeams == null)
                {
                    DataView dtvTeams = DAL.DBAccess.GetAllTeams();
                    m_dicTeams = new Dictionary<string, Team>(dtvTeams.Count);
                    foreach (DataRowView row in dtvTeams)
                    {
                        Team tmNewTeam = new Team();
                        tmNewTeam.Name = (string)row["TeamName"];
                        tmNewTeam.Owner = (string)row["Owner"];
                        tmNewTeam.CreationDate = (DateTime)row["AU_CreationDate"];
                        tmNewTeam.TeamTrainingType = (Consts.TrainingType)((int)row["TeamTrainingType"]);
                        tmNewTeam.TeamCash = (int)row["TeamCash"];
                        tmNewTeam.Formation = row["TeamPos"].ToString();
                        tmNewTeam.Players = DAL.DBAccess.LoadPlayers(tmNewTeam.Name);
                        m_dicTeams.Add(tmNewTeam.Name, tmNewTeam);
                    }
                }

                return m_dicTeams;
            }
        }

        #region Game Enging

        public static List<CycleGame> CyclesToList(DataView dvAllCycles)
        {
            List<CycleGame> lstCycleGames = new List<CycleGame>();

            foreach (DataRowView item in dvAllCycles)
            {
                if (item["GameId"].ToString() != "")
                {
                    lstCycleGames.Add(new CycleGame(int.Parse(item["CycleNum"].ToString()),
                                                item["HomeTeam"].ToString(),
                                                item["AwayTeam"].ToString(),
                                                int.Parse(item["GameId"].ToString()),
                                                DateTime.Parse(item["CycleDate"].ToString())));
                }
                else
                {
                    lstCycleGames.Add(new CycleGame(int.Parse(item["CycleNum"].ToString()),
                                                item["HomeTeam"].ToString(),
                                                item["AwayTeam"].ToString()));
                }
            }
            return lstCycleGames;
        }

        public static List<CycleGameFinished> CyclesToListFinished(DataView dvAllCycles)
        {
            List<CycleGameFinished> lstCycleGames = new List<CycleGameFinished>();

            foreach (DataRowView item in dvAllCycles)
            {
                if (item["GameId"].ToString() != "")
                {
                    lstCycleGames.Add(new CycleGameFinished(int.Parse(item["CycleNum"].ToString()),
                                                item["HomeTeam"].ToString(),
                                                item["AwayTeam"].ToString(),
                                                int.Parse(item["GameId"].ToString()),
                                                DateTime.Parse(item["CycleDate"].ToString())));
                }
                else
                {
                    lstCycleGames.Add(new CycleGameFinished(int.Parse(item["CycleNum"].ToString()),
                                                item["HomeTeam"].ToString(),
                                                item["AwayTeam"].ToString()));
                }
            }
            return lstCycleGames;
        }

        public static Team CreateTeam(string strTeamName)
        {
            tMyTeam = DAL.DBAccess.CreateTeam(User, strTeamName);
            return tMyTeam;
        }


        private static void CreateLeagueTable()
        {
            HatTrick.DAL.DBAccess.CreateLeagueEmptyTable();
        }

        public static void CreateNewLeagueCycles()
        {
            if (HatTrick.DAL.DBAccess.CheckShouldCreateNewLeague())
            {
                DataView alTeams;
                ArrayList alFixedTeams = new ArrayList();
                alTeams = HatTrick.DAL.DBAccess.GetAllTeams();
                ArrayList alAllCycles = new ArrayList();

                for (int nCurrTeam = 0; nCurrTeam < alTeams.Count / 2; nCurrTeam++)
                {
                    alFixedTeams.Add(alTeams[nCurrTeam]["TeamName"]);
                }

                for (int nCurrTeam = alTeams.Count / 2; nCurrTeam < alTeams.Count; nCurrTeam++)
                {
                    alFixedTeams.Add(alTeams[(alTeams.Count - 1) - (nCurrTeam - alTeams.Count / 2)]["TeamName"]);
                }

                for (int nCycles = 1; nCycles <= alTeams.Count - 1; ++nCycles)
                {
                    ArrayList arCurrCycle = new ArrayList();
                    arCurrCycle = SetGamesForCycle(alFixedTeams, nCycles);
                    alAllCycles.Add(arCurrCycle);
                    HatTrick.DAL.DBAccess.SaveCycleToDB(arCurrCycle);
                    RotateTeams(alFixedTeams, 1);
                }

                foreach (ArrayList alCycle in alAllCycles)
                {
                    foreach (CycleGame cgGame in alCycle)
                    {
                        string strTempName = cgGame.AwayTeam;
                        cgGame.AwayTeam = cgGame.HomeTeam;
                        cgGame.HomeTeam = strTempName;
                        cgGame.CycleNum += alTeams.Count - 1;
                    }

                    HatTrick.DAL.DBAccess.SaveCycleToDB(alCycle);
                }
            }
        }

        private static void RotateTeams(ArrayList alFixedTeams, int nFixedTeam)
        {
            int nMid = (alFixedTeams.Count / 2);
            string nTemp = alFixedTeams[1].ToString();

            string nOldTemp;

            for (int i = 1; i < alFixedTeams.Count - 1; i++)
            {
                int nIndex = alFixedTeams.Count - (i - nMid) - 1;
                int nNextIndex = nIndex - 1;

                if (i + 1 < nMid)
                {
                    nIndex = i;
                    nNextIndex = i + 1;
                }

                nOldTemp = nTemp;
                nTemp = alFixedTeams[nNextIndex].ToString();
                alFixedTeams[nNextIndex] = nOldTemp;

            }

            alFixedTeams[1] = nTemp;

        }

        private static ArrayList SetGamesForCycle(ArrayList alRotatedTeams, int nCycleNum)
        {
            ArrayList alNewCycleGames = new ArrayList();

            for (int nCurrGame = 0; nCurrGame < alRotatedTeams.Count / 2; nCurrGame++)
            {
                CycleGame cgNew = new CycleGame();

                if ((CommonModel.Consts.GameRandom.Next(0, 10) % 2) == 0)
                {
                    cgNew.HomeTeam = alRotatedTeams[nCurrGame].ToString();
                    cgNew.AwayTeam = (alRotatedTeams[nCurrGame + alRotatedTeams.Count / 2]).ToString();
                }
                else
                {
                    cgNew.AwayTeam = alRotatedTeams[nCurrGame].ToString();
                    cgNew.HomeTeam = (alRotatedTeams[nCurrGame + alRotatedTeams.Count / 2]).ToString();
                }

                cgNew.CycleNum = nCycleNum;
                alNewCycleGames.Add(cgNew);
            }

            return (alNewCycleGames);
        }

        public static DataView GetLeague()
        {
            int nCurrLeague = DAL.DBAccess.GetMaxLeagueID();
            DataView dtvLeague = DAL.DBAccess.LoadLeagueTable(nCurrLeague);
            dtvLeague.Sort = "points desc, diff desc";
            return dtvLeague;
        }

        public static void PlayNextCycle()
        {
            DataView dvAllCycles = GetAllCycles();

            List<CycleGame> lstCycleGames = CyclesToList(dvAllCycles);

            int nMin = (lstCycleGames.Where(T => T.GameID == -1)).Min(T => T.CycleNum);

            foreach (CycleGame gmCurr in (lstCycleGames.Where(T => T.CycleNum == nMin)))
            {
                // Run Game
                GameStory gsNewGame = Game.MatchTeams(gmCurr.HomeTeam, gmCurr.AwayTeam);
                gmCurr.GameID = HatTrick.DAL.DBAccess.SaveStoryToDB(gsNewGame);
                gmCurr.CycleDate = DateTime.Now;
                HatTrick.DAL.DBAccess.UpdateCycleData(gmCurr);
                HatTrick.DAL.DBAccess.UpdateGameLeagueStatus(gsNewGame);
            }
        }

        public static void Reset()
        {
            HatTrick.DAL.DBAccess.ResetDebugUser();
            Game.m_usrCurrent = null;
        }

        public static bool CreateUser(string strName, string strPass)
        {
            User usrUser = new User(strName, strPass);

            return HatTrick.DAL.DBAccess.InsertUser(usrUser);
        }

        public static User Login(string strUsername, string strPassword)
        {
            m_usrCurrent = HatTrick.DAL.DBAccess.GetUser(strUsername, strPassword);
            MyTeam = HatTrick.DAL.DBAccess.LoadTeam(User);
            return m_usrCurrent;
        }


        //private static void HandleBuyPlayer()
        //{
        //    List<Player> playersForSale = DAL.DBAccess.GetPlayersForSale(tMyTeam);
        //    List<Player> dwPlayersToBuy = DAL.DBAccess.GetPlayersForSale(tMyTeam);
        //    Player playerToBuy = ChoosePlayerByID(playersForSale);
        //    tMyTeam = DAL.DBAccess.LoadTeam(tMyTeam.Name);

        //    Menu.HandleBuyPlayer(tMyTeam, playersForSale, playerToBuy);
        //}



        public static bool buyPlayer(Player playerToBuy)
        {
            try
            {
                if(TeamHasEnoughMoneyToBuyPlayer(playerToBuy))
                {
                    HatTrick.DAL.DBAccess.BuyPlayer(tMyTeam, playerToBuy);
                    tMyTeam.Players.Add(playerToBuy);
                    return true;
                }
                
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool TeamHasEnoughMoneyToBuyPlayer(Player playerToBuy)
        {
            return tMyTeam.TeamCash >= playerToBuy.PlayerCost;
        }
  
        //private static void ShowMyFormation(Team tMyTeam)
        //{
        //    int nDefence = int.Parse(tMyTeam.Formation.Split('-')[0]);
        //    int nMidField = int.Parse(tMyTeam.Formation.Split('-')[1]);
        //    int nAttack = int.Parse(tMyTeam.Formation.Split('-')[2]);

        //    Console.Clear();
        //    Console.WriteLine("Hello coach!");
        //    Console.WriteLine("Your formation is {0}", tMyTeam.Formation);

        //    Player pCurrPlayer = ((Player)( tMyTeam.Players.Where(T => T.Position == 0)).First());

        //    PrintBuffer(1);

        //    CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
        //    PrintBuffer(nDefence);

        //    for (int i = 1; i <= nDefence; i++)
        //    {
        //        pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
        //        CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
        //    }

        //    PrintBuffer(nMidField);

        //    for (int i = nDefence + 1; i <= nMidField + nDefence; i++)
        //    {
        //        pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
        //        CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
        //    }

        //    PrintBuffer(nAttack);

        //    for (int i = nMidField + nDefence + 1; i < 11; i++)
        //    {
        //        pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
        //        CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
        //    }

        //    PrintBuffer(1);

        //    Console.WriteLine("Sitting on the bench: ");
        //    for (int i = 11; i < tMyTeam.Players.Count; i++)
        //    {
        //        pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
        //        CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine("");
        //    Console.WriteLine("");
        //    Console.WriteLine("");
        //    Console.WriteLine("");

        //    Console.WriteLine("Press any key to return");
        //    Console.ReadLine();
            
        //}

        //private static void PrintBuffer(int nPos)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine();

        //    if (nPos == 3)
        //    {
        //        PrintExact(20);
        //    }
        //    else if (nPos == 4)
        //    {
        //        PrintExact(5);
        //    }
        //    else if (nPos == 2)
        //    {
        //        PrintExact(30);
        //    }
        //    else if (nPos == 1)
        //    {
        //        PrintExact(40);
        //    }
        //}

        //private static void CompleteToTen(string strPlayerName)
        //{
        //    Console.Write(strPlayerName);

        //    for (int nCurr = strPlayerName.Length; nCurr <= 20; ++nCurr)
        //    {
        //        Console.Write(" ");
        //    }
        //}

        //private static void PrintExact(int nExact)
        //{
        //    for (int nCurr = 0; nCurr < nExact; ++nCurr)
        //    {
        //        Console.Write(" ");
        //    }
        //}



        public static void ChangeTeamFormation(Team tMyTeam, string strFormation)
        {
            HatTrick.DAL.DBAccess.ChangeTeamFormation(tMyTeam, strFormation);
        }


        public static void ChangePlayerPosition(Player plrToChange, Player plrChangedPos)
        {
            HatTrick.DAL.DBAccess.UpdatePlayerPosition(plrChangedPos);
            HatTrick.DAL.DBAccess.UpdatePlayerPosition(plrToChange);
        }


        public static GameStory MatchTeams(string strHomeTeam, string strAwayTeam)
        {
            GameStory gsGameStory = null;
            Team tmHomeTeam, tmAwayTeam;

            tmAwayTeam = HatTrick.DAL.DBAccess.LoadTeam(strAwayTeam);
            tmHomeTeam = HatTrick.DAL.DBAccess.LoadTeam(strHomeTeam);

            // Teams are OK
            if ((tmHomeTeam != null) && (tmAwayTeam != null))
            {
                // Set Teams
                gsGameStory = new GameStory();
                gsGameStory.AwayTeam.Team = tmAwayTeam;
                gsGameStory.HomeTeam.Team = tmHomeTeam;

                // Set General Data
                GameStorySetWatchers(gsGameStory);
                GameStorySetWeather(gsGameStory);
                GameStorySetTeamFormation(gsGameStory, tmHomeTeam, tmAwayTeam);
                GameStorySetTeamFormationMethod(gsGameStory, tmHomeTeam, tmAwayTeam);

                // Create events
                int nTotalEvents = Consts.GameRandom.Next(GameStory.MinEvents, GameStory.MaxEvents);
                int nHomeTeamEvents = CalculateHomeTeamEvents(gsGameStory, nTotalEvents);
                gsGameStory.TotalEvents = nTotalEvents;
                gsGameStory.HomeTeamEvents = nHomeTeamEvents;
                GameStoryCreateEvents(gsGameStory);
                GameStoryDetermineScore(gsGameStory);
            }
            
            return gsGameStory;
        }

        private static void GameStoryDetermineScore(GameStory gsGameStory)
        {
            foreach (GameEvent evtCurr in gsGameStory.GameEvents.Values)
            {
                if (evtCurr is ScoreEvent)
                {
                    if (evtCurr.teamAttacking.Name == gsGameStory.HomeTeam.Team.Name)
                    {
                        gsGameStory.HomeScore++;
                    }
                    else
                    {
                        gsGameStory.AwayScore++;
                    }
                }
            }
        }

        private static void GameStoryCreateEvents(GameStory gsGameStory)
        {
            int nCurrNumOfEvents = gsGameStory.HomeTeamEvents;
            TeamGameData datCurrTeam = gsGameStory.HomeTeam;

            GameStoryClacPowers(gsGameStory.HomeTeam);
            GameStoryClacPowers(gsGameStory.AwayTeam);
            
            GameStoryResetMinutes();
            GameStoryCreateEventsForTeam(gsGameStory, gsGameStory.HomeTeam, gsGameStory.AwayTeam, gsGameStory.HomeTeamEvents);
            GameStoryCreateEventsForTeam(gsGameStory, gsGameStory.AwayTeam, gsGameStory.HomeTeam, gsGameStory.AwayTeamEvents);
        }

        private static void GameStoryResetMinutes()
        {
            for (int i = 0; i < m_barrTakenMinutes.GetUpperBound(0); i++)
            {
                m_barrTakenMinutes[i] = false;
            }
        }

        private static void GameStoryClacPowers(TeamGameData teamGameData)
        {
            //Player pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == 1)).First());
            
            Player pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == teamGameData.Team.Players.Min(J=>J.Position))).First());
            teamGameData.KeepingGrade = (int)pCurrPlayer.KeeperVal;

            for (int i = 2; i <= teamGameData.Formation.Defence + 1; i++)
            {
                pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == i)).First());
                teamGameData.DefenceGrade += (int)pCurrPlayer.DefendingVal;
            }

            // Clac Kishur
            /*for (int i = nDefence + 2; i <= nMidField + nDefence + 1; i++)
            {
                pCurrPlayer = ((Player)(teamGameData.Players.Where(T => T.Position == i)).First());
                
            }*/

            for (int i = teamGameData.Formation.MiddleField + teamGameData.Formation.Defence + 2; i <= 11; i++)
            {
                pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == i)).First());
                teamGameData.OffenceGrade += (int)pCurrPlayer.ScoringVal;
            }


            for (int i = 1; i <= 11; i++)
            {
                pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == i)).First());
                teamGameData.SetPiecesGrade = Math.Max((int)pCurrPlayer.SetPiecesVal, teamGameData.SetPiecesGrade);
            }

        }

        private static void GameStoryCreateEventsForTeam(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam, int nNumOfEvents)
        {
            for (int i = 1; i <= nNumOfEvents; i++)
            {
                int nMinute = GameStoryGetEventMinute(gsGameStory, i, nNumOfEvents, datAttackingTeam);
                GameEvent evtMain = GameStoryCreateMainEvent(gsGameStory, datAttackingTeam, datDefendingTeam, nMinute);
                gsGameStory.AddEvent(evtMain);
            }
        }

        private static int GameStoryGetEventMinute(GameStory gsGameStory, int i, int nNumOfEvents, TeamGameData datAttackingTeam)
        {
            int nEventSpan = (90 / nNumOfEvents);
            int nMinute = Consts.GameRandom.Next((i - 1) * nEventSpan + 1, i * nEventSpan);
            bool bIsMinuteTaken = GameStoryIsMinuteTaken(nMinute, datAttackingTeam.Team.Name == gsGameStory.HomeTeam.Team.Name);
            while (bIsMinuteTaken)
            {
                nMinute = Consts.GameRandom.Next((i - 1) * nEventSpan + 1, i * nEventSpan);
                bIsMinuteTaken = GameStoryIsMinuteTaken(nMinute, datAttackingTeam.Team.Name == gsGameStory.HomeTeam.Team.Name);
            }
            MarkMinuteAsTaken(nMinute, datAttackingTeam.Team.Name == gsGameStory.HomeTeam.Team.Name);
            return nMinute;
        }

        private static void MarkMinuteAsTaken(int nMinute, bool bIsHomeTeam)
        {
            m_barrTakenMinutes[nMinute] = true;
        }

        private static bool GameStoryIsMinuteTaken(int nMinute, bool bIsHomeTeam)
        {
            return m_barrTakenMinutes[nMinute];
        }

        private static GameEvent GameStoryCreateMainEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam, int nMinute)
        {
            int nAttackGrade = datAttackingTeam.OffenceGrade * 1;
            int nDefenceGrade = datDefendingTeam.DefenceGrade * 3;

            bool bIsAttackBetter = nAttackGrade > nDefenceGrade;
            int nTotalGrades = nAttackGrade + nDefenceGrade;
            float fRatio = !bIsAttackBetter ? (float)nAttackGrade / nTotalGrades : (float)nDefenceGrade / nTotalGrades;
            GameEvent evtNewEvent;

            fRatio *= 100;
            int nEventRnd = Consts.GameRandom.Next(1, 100);
            
            if (bIsAttackBetter)
            {
                // Defence < 50 = ratio
                fRatio *= (float)0.6;
                if (nEventRnd <= fRatio)
                {
                    int nMissedRnd = Consts.GameRandom.Next(1, 100);
                    if (nMissedRnd <= 40)
                    {
                        evtNewEvent = GameStoryCreateFailedEvent(gsGameStory, datAttackingTeam, datDefendingTeam, (int)fRatio, nMinute);
                    }
                    else
                    {
                        evtNewEvent = GameStoryCreateFouledEvent(gsGameStory, datAttackingTeam, datDefendingTeam, nMinute);
                    }
                }
                else
                {
                    int nScorerPos = Consts.GameRandom.Next(11 - datAttackingTeam.Formation.Offence + 1, 11);
                    Player pActor = ((Player)(datAttackingTeam.Team.Players.Where(T => T.Position == nScorerPos)).First());
                    evtNewEvent = new ScoreEvent(datAttackingTeam.Team, nMinute, true, pActor);
                }
            }
            else
            {
                // attack < 50 = ratio
                if (nEventRnd <= fRatio)
                {
                    int nScorerPos = Consts.GameRandom.Next(11 - datAttackingTeam.Formation.Offence + 1, 11);
                    Player pActor = ((Player)(datAttackingTeam.Team.Players.Where(T => T.Position == nScorerPos)).First());
                    evtNewEvent = new ScoreEvent(datAttackingTeam.Team, nMinute, true, pActor);
                }
                else
                {
                    int nMissedRnd = Consts.GameRandom.Next(1, 100);
                    if (nMissedRnd <= 40)
                    {
                        evtNewEvent = GameStoryCreateFouledEvent(gsGameStory, datAttackingTeam, datDefendingTeam, nMinute);
                    }
                    else
                    {
                        evtNewEvent = GameStoryCreateFailedEvent(gsGameStory, datAttackingTeam, datDefendingTeam, (int)(100 - fRatio), nMinute);
                    }
                }                
            }
            return evtNewEvent;
        }

        private static GameEvent GameStoryCreateFouledEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam, int nMinute)
        {
            FouledEvent evtFoul;
            int nMissedRnd = Consts.GameRandom.Next(1, 100);

            // Create a panelty event
            // Create the player names
            // Create the attacker name
            int nAttacker = Consts.GameRandom.Next(11 - datAttackingTeam.Formation.Offence + 1, 11);
            Player pAttacker = ((Player)(datAttackingTeam.Team.Players.Where(T => T.Position == nAttacker)).First());
            // create the foulist name
            int nFoulist = Consts.GameRandom.Next(1, datDefendingTeam.Formation.Defence + 1);
            Player pFouslist = ((Player)(datDefendingTeam.Team.Players.Where(T => T.Position == nFoulist)).First());

            // Panelty shoot is due
            if (nMissedRnd <= 10)
            {
                Player pShooter = ((Player)(datAttackingTeam.Team.Players.Where(T => T.WholeSetPiecesVal == (int)(datAttackingTeam.SetPiecesGrade))).First());
                evtFoul = new PaneltyEvent(datAttackingTeam.Team, nMinute, pAttacker, pFouslist, pShooter);

                // Check if a card was shown
                int nCardRnd = Consts.GameRandom.Next(1, 100);
                evtFoul.ptCard = nCardRnd <= 10 ? PaneltyCard.ptRed : PaneltyCard.ptYellow;

                // Check if the panelty shot was scored
                int nTotalChance = 9*datAttackingTeam.SetPiecesGrade + datDefendingTeam.KeepingGrade;
                bool bAttackIsBetter = 9*datAttackingTeam.SetPiecesGrade > datDefendingTeam.KeepingGrade;
                float fRatio = bAttackIsBetter ? (float)(9 * datAttackingTeam.SetPiecesGrade) / nTotalChance : (float)datDefendingTeam.KeepingGrade / nTotalChance;
                int nScoreRnd = Consts.GameRandom.Next(1, nTotalChance);

                if (bAttackIsBetter) evtFoul.bScored = nScoreRnd > datDefendingTeam.KeepingGrade ? datAttackingTeam.Team : null;
                else evtFoul.bScored = nScoreRnd > 9*datDefendingTeam.SetPiecesGrade ? datAttackingTeam.Team : null;

                // if it was a goal, also add the score event
                if (evtFoul.bScored != null) gsGameStory.AddEvent(new ScoreEvent(datAttackingTeam.Team, nMinute, false, pAttacker));
            }
            // Not panelty - free kick from after the 16 meters
            else if (nMissedRnd <= 75)
            {
                int OffenceGrade = datAttackingTeam.SetPiecesGrade;
                
                // set the player to the free kicker
                Player pShooter = ((Player)(datAttackingTeam.Team.Players.Where(T => T.WholeSetPiecesVal == OffenceGrade)).First());
                evtFoul = new FreeKickEvent(datAttackingTeam.Team, nMinute, pAttacker, pFouslist, pShooter);

                // check if a card was shown
                int nCardRnd = Consts.GameRandom.Next(1, 100);
                if (nCardRnd <= 5) evtFoul.ptCard = PaneltyCard.ptRed;
                else evtFoul.ptCard = nCardRnd <= 30 ? PaneltyCard.ptYellow : PaneltyCard.ptNone;

                // calculate score
                int DefendingGrade = (datDefendingTeam.KeepingGrade + datDefendingTeam.DefenceGrade) / 2;
                int nTotalChance = 4 * datAttackingTeam.SetPiecesGrade + 6*DefendingGrade;
                bool bAttackIsBetter = 4 * OffenceGrade > 6*DefendingGrade;
                float fRatio = bAttackIsBetter ? (float)(4 * OffenceGrade) / nTotalChance : (float)(6*DefendingGrade)/ nTotalChance;
                int nScoreRnd = nTotalChance - Consts.GameRandom.Next(1, nTotalChance) + 1;

                if (bAttackIsBetter) evtFoul.bScored = nScoreRnd > 6*DefendingGrade ? datAttackingTeam.Team : null;
                else evtFoul.bScored = nScoreRnd < 4 * OffenceGrade ? datAttackingTeam.Team : null;

                if (evtFoul.bScored != null) gsGameStory.AddEvent(new ScoreEvent(datAttackingTeam.Team, nMinute, false, pShooter));
            }
            else
            {
                evtFoul = new MissedFouledEvent(datAttackingTeam.Team, nMinute, pAttacker, pFouslist);
            }
            return evtFoul;
        }

        private static GameEvent GameStoryCreateFailedEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam, int nDefenceRatio, int nMinute)
        {
            int nFailedRnd = Consts.GameRandom.Next(1, 100);
            
            // Create the attacker name
            int nAttacker = Consts.GameRandom.Next(11 - datAttackingTeam.Formation.Offence + 1, 11);
            Player pAttacker = ((Player)(datAttackingTeam.Team.Players.Where(T => T.Position == nAttacker)).First());

            if (nFailedRnd <= nDefenceRatio)
            {
                return new StoppedEvent(datAttackingTeam.Team, nMinute, pAttacker);
            }
            else
            {
                return new MissedEvent(datAttackingTeam.Team, nMinute, pAttacker);
            }
        }

        static int CalculateHomeTeamEvents(GameStory gsGameStory, int nTotalEvents)
        {
            int nHomeMidFieldPower;
            int nAwayMidFieldPower;

            nHomeMidFieldPower = CalculateMidFieldPower(gsGameStory.HomeTeam);
            nAwayMidFieldPower = CalculateMidFieldPower(gsGameStory.AwayTeam);

            bool bIsHomeLarger = nHomeMidFieldPower > nAwayMidFieldPower;
            float fLargerPower = bIsHomeLarger == true ? (float)nHomeMidFieldPower : (float)nAwayMidFieldPower;
            float fLowerPower = bIsHomeLarger == false ? (float)nHomeMidFieldPower : (float)nAwayMidFieldPower;

            float fRatio = fLowerPower / fLargerPower;
            int nLargerEvents = nTotalEvents - (int)(fRatio * nTotalEvents);
            return bIsHomeLarger ? nLargerEvents : nTotalEvents - nLargerEvents;
        }

        private static int CalculateMidFieldPower(TeamGameData tmCurrTeam)
        {
            int nHomeMidFieldPower = 0;
            TeamFormation tfCurrFormation = tmCurrTeam.Formation;
            // Run on Home playmakers
            for (int i = tfCurrFormation.Defence + 2; i <= tfCurrFormation.MiddleField + tfCurrFormation.Defence + 1; i++)
            {
                Player pCurrPlayer = ((Player)(tmCurrTeam.Team.Players.Where(T => T.Position == i)).First());
                nHomeMidFieldPower += (int)pCurrPlayer.PlaymakingVal * 40;
                nHomeMidFieldPower += (int)pCurrPlayer.WingerVal * 40;
                nHomeMidFieldPower += (int)pCurrPlayer.PassingVal * 20;
            }
            return nHomeMidFieldPower;
        }

        private static void GameStorySetTeamFormationMethod(GameStory gsGameStory, Team tmHomeTeam, Team tmAwayTeam)
        {
            int nDefenceHome = int.Parse(tmHomeTeam.Formation.Split('-')[0]);
            int nMidFieldHome = int.Parse(tmHomeTeam.Formation.Split('-')[1]);
            int nDefenceAway = int.Parse(tmAwayTeam.Formation.Split('-')[0]);
            int nMidFieldAway = int.Parse(tmAwayTeam.Formation.Split('-')[1]);

            int nHomeTeamPlayMaking = 0;
            int nAwayTeamPlayMaking = 0;
            int nHomeTeamWings = 0;
            int nAwayTeamWings = 0;

            SumTeamMethod(tmHomeTeam, nDefenceHome, nMidFieldHome, ref nHomeTeamPlayMaking, ref nHomeTeamWings);
            SumTeamMethod(tmAwayTeam, nDefenceAway, nMidFieldAway, ref nAwayTeamPlayMaking, ref nAwayTeamWings);

            gsGameStory.HomeTeam.IsTeamMiddleMethod = nHomeTeamPlayMaking >= nHomeTeamWings;
            gsGameStory.AwayTeam.IsTeamMiddleMethod  = nAwayTeamPlayMaking >= nAwayTeamWings;

        }

        private static void SumTeamMethod(Team tmHomeTeam, int nDefenceHome, int nMidFieldHome, ref int nHomeTeamPlayMaking, ref int nHomeTeamWings)
        {
            // Run on Home defence playrs
            for (int i = 2; i <= nDefenceHome + 1; i++)
            {
                Player pCurrPlayer = ((Player)(tmHomeTeam.Players.Where(T => T.Position == i)).First());
                nHomeTeamPlayMaking += (int)pCurrPlayer.PlaymakingVal;
                nHomeTeamWings += (int)pCurrPlayer.WingerVal;
            }

            // Run on Home playmakers
            for (int i = nDefenceHome + 2; i <= nMidFieldHome + nDefenceHome + 1; i++)
            {
                Player pCurrPlayer = ((Player)(tmHomeTeam.Players.Where(T => T.Position == i)).First());
                nHomeTeamPlayMaking += (int)pCurrPlayer.PlaymakingVal;
                nHomeTeamWings += (int)pCurrPlayer.WingerVal;
            }
        }

        private static void GameStorySetTeamFormation(GameStory gsGameStory, Team tmHomeTeam, Team tmAwayTeam)
        {
            gsGameStory.AwayTeam.Formation = new TeamFormation(tmAwayTeam.Formation);
            gsGameStory.HomeTeam.Formation = new TeamFormation(tmHomeTeam.Formation);
        }

        private static void GameStorySetWeather(GameStory gsGameStory)
        {
            gsGameStory.Weather = Weather.GetRandomWeather();
        }

        private static void GameStorySetWatchers(GameStory gsGameStory)
        {
            int nWatchers = Consts.GameRandom.Next(GameStory.MinWatchers, GameStory.MaxWatchers);
            gsGameStory.Watchers = nWatchers;
        }

        public static int SaveStoryToDB(GameStory gsNewGame)
        {
            return HatTrick.DAL.DBAccess.SaveStoryToDB(gsNewGame);
        }

        public static void ChangeTeamTrainngType(Consts.TrainingType ttTeamTrainingType)
        {
            tMyTeam.TeamTrainingType = ttTeamTrainingType;
            DAL.DBAccess.ChangeTeamTrainingType(tMyTeam);
        }

        public static void TrainTeam(Team tmTeamToTrain)
        {
            TeamFormation tmFormation = new TeamFormation(tmTeamToTrain.Formation);
            Consts.TrainingType trType = tmTeamToTrain.TeamTrainingType;
            float[] nChances = { 0, 0, 0 };
            switch (trType)
            {
                case Consts.TrainingType.ATTACK:
                    {
                        nChances[0] = (0.2F);
                        nChances[1] = (0.45F);
                        nChances[2] = (1F);
                    }
                    break;
                case Consts.TrainingType.DEFENCE:
                    {
                        nChances[0] = (1F);
                        nChances[1] = (0.6F);
                        nChances[2] = (0.2F);
                    }

                    break;
                case Consts.TrainingType.WING:
                    {
                        nChances[0] = (0.6F);
                        nChances[1] = (0.8F);
                        nChances[2] = (0.7F);
                    }

                    break;
                case Consts.TrainingType.PLAYMAKING:
                    nChances[0] = (0.4F);
                    nChances[1] = (1F);
                    nChances[2] = (0.5F);

                    break;
                case Consts.TrainingType.SETPIECES:
                    nChances[0] = (1F);
                    nChances[1] = (1F);
                    nChances[2] = (1F);

                    break;
                default:
                    break;
            }
            Player plrKeeper = (Player)tmTeamToTrain.Players.Where(T => T.Position == 1).First();
            plrKeeper.KeeperVal = AdvancePlayerSkill(plrKeeper, 0.25F, 1F, plrKeeper.KeeperVal);
            for (int i = 2; i <= 11; i++)
            {
                Player plrToTrain = (Player)tmTeamToTrain.Players.Where(T => T.Position == i).First();

                if (i <= tmFormation.Defence + 1)
                {
                    TrainPlayer(trType, plrToTrain, nChances[0]);
                }
                else if (i <= tmFormation.MiddleField + tmFormation.Defence + 1)
                {
                    TrainPlayer(trType, plrToTrain, nChances[1]);
                }
                else
                {
                    TrainPlayer(trType, plrToTrain, nChances[2]);
                }
            }
        }

        public static void TrainAllTeams(int nNumOfTrainings)
        {
            DataView allTeams;
            allTeams = HatTrick.DAL.DBAccess.GetAllTeams();
            foreach (DataRowView drTeam in allTeams)
            {
                Team tCurrTeam = HatTrick.DAL.DBAccess.LoadTeam(drTeam["TeamName"].ToString());
                for (int nCurrTrain = 0; nCurrTrain < nNumOfTrainings; ++nCurrTrain)
                {
                    TrainTeam(tCurrTeam);
                }
                HatTrick.DAL.DBAccess.SaveTeamSkills(tCurrTeam);
            }
        }

        private static void TrainPlayer(Consts.TrainingType trType, Player plrToTrain, float fAdvancedLevel)
        {

            switch (trType)
            {
                case Consts.TrainingType.ATTACK:
                    float fCurrentSkillAdvance = 1F;
                    plrToTrain.ScoringVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.ScoringVal);

                    fCurrentSkillAdvance = 0.3F;
                    plrToTrain.SetPiecesVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.SetPiecesVal);

                    fCurrentSkillAdvance = 0.5F;
                    plrToTrain.WingerVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.WingerVal);
                    break;

                case Consts.TrainingType.DEFENCE:
                    fCurrentSkillAdvance = 1F;
                    plrToTrain.DefendingVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.DefendingVal);

                    break;
                case Consts.TrainingType.WING:
                    fCurrentSkillAdvance = 1F;
                    plrToTrain.WingerVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.WingerVal);

                    fCurrentSkillAdvance = 0.5F;
                    plrToTrain.PassingVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.PassingVal);
                    break;
                case Consts.TrainingType.PLAYMAKING:
                    fCurrentSkillAdvance = 1F;
                    plrToTrain.PlaymakingVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.PlaymakingVal);
                    plrToTrain.PassingVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.PassingVal);

                    fCurrentSkillAdvance = 0.5F;
                    plrToTrain.WingerVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.WingerVal);

                    break;
                case Consts.TrainingType.SETPIECES:
                    fCurrentSkillAdvance = 1F;
                    plrToTrain.SetPiecesVal = AdvancePlayerSkill(plrToTrain, fAdvancedLevel, fCurrentSkillAdvance, plrToTrain.SetPiecesVal);
                    break;
                default:
                    break;
            }
        }

        private static float AdvancePlayerSkill(Player plrToTrain, float fAdvancedLevel, float fCurrentSkillAdvance, float fCurrentSkill)
        {
            int nPlayerWholeLevel;
            float fAdvancePower;

            nPlayerWholeLevel = (int)fCurrentSkill;
            if (nPlayerWholeLevel < 20)
            {
                fAdvancePower = 1F / (Consts.fTrainPeroid[nPlayerWholeLevel - 1] * Consts.nTrainsPerMonth);
                fCurrentSkill += fAdvancePower * fAdvancedLevel * fCurrentSkillAdvance;
            }
            else
            {
                fCurrentSkill = 20F;
            }
            return fCurrentSkill;
        }
        #endregion

        private static DataRowCollection arrdrFormations = null;

        public static DataRowCollection GetFormations()
        {
            if (arrdrFormations == null)
            {
                arrdrFormations = DAL.DBAccess.GetFormations();
            }
            return arrdrFormations;
        }

        public static bool TeamExists(string strTeamName)
        {
            return DAL.DBAccess.DoesTeamExist(strTeamName);
        }

        public static DataView GetAllCycles()
        {
            if (DAL.DBAccess.CheckShouldCreateNewLeague())
            {
                CreateLeagueTable();
                CreateNewLeagueCycles();
            }

            return DAL.DBAccess.GetAllCycles();
        }

        public static int GetNumOfCycles()
        {
            return DAL.DBAccess.GetNumOfCycles();
        }
        public static GameStory GetGameStory(string strGameID)
        {
            return GetGameStory(int.Parse(strGameID));
        }

        public static GameStory GetGameStory(int nGameToShow)
        {
            return DAL.DBAccess.LoadGameStory(nGameToShow);
        }

        public static bool UserExists(string strUsername)
        {
            return DAL.DBAccess.DoesUserExist(strUsername);
        }

        public static List<Player> GetPlayerNotForSell(Team tMyTeam)
        {
            return DAL.DBAccess.GetNotForSellTeamPlayers(tMyTeam);           
        }

        public static List<Player> GetPlayerForSell(Team tMyTeam)
        {
            return DAL.DBAccess.GetPlayersForSale(tMyTeam);
        }

        public static bool CanISellPlayer(String iD)
        {
            return DAL.DBAccess.CanISellPlayer(iD, Game.MyTeam);
        }
        public static void UpdateSellPlayer(String strPlayerId, int intCost)
        {
            DAL.DBAccess.UpdateSellPlayer(strPlayerId, intCost);
        }
    }
}
