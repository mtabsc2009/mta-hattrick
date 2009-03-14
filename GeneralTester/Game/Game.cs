using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using HatTrick.TextualView;

namespace HatTrick
{
    public class Game
    {
        private static User m_usrCurrent = null;

        public static User User
        {
            get { return Game.m_usrCurrent; }
        }
        private static Team tMyTeam = null;
        

        #region Game Presentation Flow

        public static bool Start()
        {
            Console.Clear();
            string strChoice = Menu.ShowMain();

            while (strChoice != "3")
            {
                Console.Clear();
                switch (strChoice)
                {
                    case "1":
                        ShowLogin();
                        break;
                    case "2":
                        ShowCreateUser();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowMain();
            }

            return true;
        }

        private static void ShowCreateUser()
        {
            string strUsername, strPassword;
            Console.Clear();
            Menu.ShowCreateAcouunt(out strUsername, out strPassword);
            if (!CreateUser(strUsername, strPassword))
            {
                Menu.ShowErrorNewUser();
            }
            else
            {
                ShowLoginAttempt(strUsername, strPassword);
            }
        }

        private static void ShowLogin()
        {
            string strUsername, strPassword;
            Menu.ShowLogin(out strUsername, out strPassword);
            ShowLoginAttempt(strUsername, strPassword);
        }

        private static void ShowLoginAttempt(string strUsername, string strPassword)
        {
            if (Login(strUsername, strPassword) != null)
            {
                HandleWelcome();
            }
            else
            {
                Menu.ShowErrorLogin();
            }
        }

        private static void HandleWelcome()
        {
            Console.Clear();
            string strChoice = Menu.ShowWelcome(m_usrCurrent);

            while (strChoice != "4")
            {
                switch (strChoice)
                {
                    case "1":
                        ManageTeam();
                        break;

                    case "2": // check games
                        Console.WriteLine("These functions arent available yet..");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "3": // league
                        HandleLeague();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowWelcome(m_usrCurrent);
            }
        }

        private static void HandleLeague()
        {
            Console.Clear();
            string strChoice = Menu.ShowLeague(m_usrCurrent);
            while (strChoice != "2")
            {
                switch (strChoice)
                {
                    case "1":
                        StartMatch();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowLeague(m_usrCurrent);
            }
        }

        private static void StartMatch()
        {
            string strHomeTeam, strAwayTeam;
            Console.Clear();
            Menu.ShowStartMatch(out strHomeTeam, out strAwayTeam);
            GameStory gsGameStory = Game.MatchTeams(strHomeTeam, strAwayTeam);
            if (gsGameStory != null)
            {
                Menu.ShowGameStory(gsGameStory);
            }
            else
            {
                Menu.ShowMatchError();
            }
        }

        #endregion

        #region Game Enging

        public static void Reset()
        {
            DAL.DBAccess.ResetDebugUser();
        }

        public static bool CreateUser(string strName, string strPass)
        {
            User usrUser = new User(strName, strPass);

            return DAL.DBAccess.InsertUser(usrUser);
        }

        public static User Login(string strUsername, string strPassword)
        {
            m_usrCurrent = DAL.DBAccess.GetUser(strUsername, strPassword);
            return m_usrCurrent;
        }

        public static Team ManageTeam()
        {
            tMyTeam = DAL.DBAccess.LoadTeam(m_usrCurrent);
            if (tMyTeam == null)
            {
                string strTeamName;
                Console.Clear();
                Menu.ShowCreateNewTeam(out strTeamName);
                
                while (DAL.DBAccess.DoesTeamExist(strTeamName))
                {
                    Console.WriteLine("Team already exists");
                    Menu.ShowCreateNewTeam(out strTeamName);
                }

                tMyTeam = DAL.DBAccess.CreateTeam(m_usrCurrent, strTeamName);
            }

            HandleManageTeam();

            return tMyTeam;
        }

        private static void HandleManageTeam()
        {
            Console.Clear();
            string strChoice = Menu.ShowManageTeam(m_usrCurrent);

            while (strChoice != "5")
            {
                switch (strChoice)
                {
                    case "1":
                        ShowMyTeam(tMyTeam);
                        break;

                    case "2":
                        ChangePlayerPosition();
                        break;

                    case "3":
                        ChangeTeamFomation();
                        break;
                    case "4":
                        Menu.ShowMyFormation(tMyTeam);
                        break;
                        
                }
                Console.Clear();
                strChoice = Menu.ShowManageTeam(m_usrCurrent);
            }
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

        private static void ChangeTeamFomation()
        {
            DataRowCollection drColFormations = DAL.DBAccess.GetFormations();
            string strChoice = Menu.ShowTeamFormation(m_usrCurrent, drColFormations);
            tMyTeam.Formation = strChoice;
            DAL.DBAccess.ChangeTeamFormation(tMyTeam, strChoice);

            Console.WriteLine("Formation changed");
            Console.ReadLine();
        }

        private static void ShowMyTeam(Team tMyTeam)
        {
            PrintPlayers(tMyTeam);
            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        private static void ChangePlayerPosition()
        {
            PrintPlayers(tMyTeam);

            int n; 

            Console.WriteLine("Please choose player id");
            string strPlayerID;
            Player plrToChange = null;

            strPlayerID = Console.ReadLine();

            bool bDoesExists = false;

            while (!bDoesExists)
            {
                if (int.TryParse(strPlayerID, out n))
                {
                    plrToChange = (Player)tMyTeam.Players.Where(T => T.ID == int.Parse(strPlayerID)).First();

                    if (plrToChange != null)
                    {
                        bDoesExists = true;
                    }
                    else
                    {
                        Console.WriteLine("Please choose player id");
                        strPlayerID = Console.ReadLine();
                    }
                }
            }

            Console.WriteLine("Please choose a position for player {0}", plrToChange.Name);
            string strPos = Console.ReadLine();
            
            Player plrChangedPos = (Player)tMyTeam.Players.Where(T => T.Position == int.Parse(strPos)).First();
            plrChangedPos.Position = plrToChange.Position;
            plrToChange.Position = int.Parse(strPos);
            DAL.DBAccess.UpdatePlayerPosition(plrChangedPos);
            DAL.DBAccess.UpdatePlayerPosition(plrToChange);
            Console.WriteLine("The new player position is {0}", plrToChange.Position.ToString());
            Console.ReadLine();
        }

        private static void PrintPlayers(Team tMyTeam)
        {
            Console.Clear();
            Console.WriteLine("Welcome " + tMyTeam.Owner);
            Console.WriteLine("Team name: " + tMyTeam.Name);
            Console.WriteLine("Created: " + tMyTeam.CreationDate.ToShortDateString());
            Console.WriteLine("Current formation: " + tMyTeam.Formation);
            Console.WriteLine();
            Console.WriteLine("Players: ");
            Console.WriteLine();
            for (int nCurrPlayer = 0; nCurrPlayer < tMyTeam.Players.Count; ++nCurrPlayer)
            {
                Console.WriteLine("ID:   " + tMyTeam.Players[nCurrPlayer].ID.ToString());
                Console.WriteLine("Name: " + tMyTeam.Players[nCurrPlayer].Name);
                Console.WriteLine("Age:  " + tMyTeam.Players[nCurrPlayer].Age);
                Console.WriteLine("Position:  " + tMyTeam.Players[nCurrPlayer].Position);
                Console.WriteLine("Skills:   ");
                Console.Write("Keeping:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].KeeperVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("Defending:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].DefendingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("Playmaking: ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PlaymakingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("Winger:     ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].WingerVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("Passing:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PassingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("Scoring:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].ScoringVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("SetPieces:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].SetPiecesVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static GameStory MatchTeams(string strHomeTeam, string strAwayTeam)
        {
            GameStory gsGameStory = null;
            Team tmHomeTeam, tmAwayTeam;

            tmAwayTeam = DAL.DBAccess.LoadTeam(strAwayTeam);
            tmHomeTeam = DAL.DBAccess.LoadTeam(strHomeTeam);

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
            foreach (GameEvent evtCurr in gsGameStory.GameEvents)
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

            GameStoryCreateEventsForTeam(gsGameStory, gsGameStory.HomeTeam, gsGameStory.AwayTeam, gsGameStory.HomeTeamEvents);
            GameStoryCreateEventsForTeam(gsGameStory, gsGameStory.AwayTeam, gsGameStory.HomeTeam, gsGameStory.AwayTeamEvents);
        }

        private static void GameStoryClacPowers(TeamGameData teamGameData)
        {
            Player pCurrPlayer = ((Player)(teamGameData.Team.Players.Where(T => T.Position == 1)).First());
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
                GameEvent evtMain = GameStoryCreateMainEvent(gsGameStory, datAttackingTeam, datDefendingTeam);
                gsGameStory.AddEvent(evtMain);
            }
        }

        private static GameEvent GameStoryCreateMainEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam)
        {
            int nAttackGrade = datAttackingTeam.OffenceGrade * 1;
            int nDefenceGrade = datDefendingTeam.DefenceGrade * 3;

            bool bIsAttackBetter = nAttackGrade > nDefenceGrade;
            int nTotalGrades = nAttackGrade + nDefenceGrade;
            float fRatio = !bIsAttackBetter ? (float)nAttackGrade / nTotalGrades : (float)nDefenceGrade / nTotalGrades;
            fRatio *= (float)0.6;
            GameEvent evtNewEvent;

            fRatio *= 100;
            int nEventRnd = Consts.GameRandom.Next(1, 100);
            
            if (bIsAttackBetter)
            {
                // Defence < 50 = ratio
                if (nEventRnd <= fRatio)
                {
                    int nMissedRnd = Consts.GameRandom.Next(1, 100);
                    if (nMissedRnd <= 40)
                    {
                        evtNewEvent = GameStoryCreateFailedEvent(gsGameStory, datAttackingTeam, datDefendingTeam, (int)fRatio);
                    }
                    else
                    {
                        evtNewEvent = GameStoryCreateFouledEvent(gsGameStory, datAttackingTeam, datDefendingTeam);
                    }
                }
                else
                {
                    evtNewEvent = new ScoreEvent(datAttackingTeam.Team, true);
                }
            }
            else
            {
                // attack < 50 = ratio
                if (nEventRnd <= fRatio)
                {
                    evtNewEvent = new ScoreEvent(datAttackingTeam.Team, true);
                }
                else
                {
                    int nMissedRnd = Consts.GameRandom.Next(1, 100);
                    if (nMissedRnd <= 40)
                    {
                        evtNewEvent = GameStoryCreateFouledEvent(gsGameStory, datAttackingTeam, datDefendingTeam);
                    }
                    else
                    {
                        evtNewEvent = GameStoryCreateFailedEvent(gsGameStory, datAttackingTeam, datDefendingTeam, (int)(100 - fRatio));
                    }
                }                
            }
            return evtNewEvent;
        }

        private static GameEvent GameStoryCreateFouledEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam)
        {
            FouledEvent evtFoul;
            int nMissedRnd = Consts.GameRandom.Next(1, 100);
            if (nMissedRnd <= 10)
            {
                evtFoul = new PaneltyEvent(datAttackingTeam.Team);
                int nCardRnd = Consts.GameRandom.Next(1, 100);
                evtFoul.ptCard = nCardRnd <= 10 ? PaneltyCard.ptRed : PaneltyCard.ptYellow;

                int nTotalChance = 9*datAttackingTeam.SetPiecesGrade + datDefendingTeam.KeepingGrade;
                bool bAttackIsBetter = 9*datAttackingTeam.SetPiecesGrade > datDefendingTeam.KeepingGrade;
                float fRatio = bAttackIsBetter ? (float)(9 * datAttackingTeam.SetPiecesGrade) / nTotalChance : (float)datDefendingTeam.KeepingGrade / nTotalChance;
                int nScoreRnd = Consts.GameRandom.Next(1, nTotalChance);

                if (bAttackIsBetter) evtFoul.bScored = nScoreRnd > datDefendingTeam.KeepingGrade ? datAttackingTeam.Team : null;
                else evtFoul.bScored = nScoreRnd > 9*datDefendingTeam.SetPiecesGrade ? datAttackingTeam.Team : null;

                if (evtFoul.bScored != null) gsGameStory.AddEvent(new ScoreEvent(datAttackingTeam.Team, false));
            }
            else if (nMissedRnd <= 75)
            {
                evtFoul = new FreeKickEvent(datAttackingTeam.Team);
                int nCardRnd = Consts.GameRandom.Next(1, 100);
                if (nCardRnd <= 5) evtFoul.ptCard = PaneltyCard.ptRed;
                else evtFoul.ptCard = nCardRnd <= 30 ? PaneltyCard.ptYellow : PaneltyCard.ptNone;

                int DefendingGrade = (datDefendingTeam.KeepingGrade + datDefendingTeam.DefenceGrade) / 2;
                int OffenceGrade = datAttackingTeam.SetPiecesGrade;

                int nTotalChance = 4 * datAttackingTeam.SetPiecesGrade + 6*DefendingGrade;
                bool bAttackIsBetter = 4 * OffenceGrade > 6*DefendingGrade;
                float fRatio = bAttackIsBetter ? (float)(4 * OffenceGrade) / nTotalChance : (float)(6*DefendingGrade)/ nTotalChance;
                int nScoreRnd = Consts.GameRandom.Next(1, nTotalChance);

                if (bAttackIsBetter) evtFoul.bScored = nScoreRnd > 6*DefendingGrade ? datAttackingTeam.Team : null;
                else evtFoul.bScored = nScoreRnd > 4 * OffenceGrade ? datAttackingTeam.Team : null;

                if (evtFoul.bScored != null) gsGameStory.AddEvent(new ScoreEvent(datAttackingTeam.Team, false));
            }
            else
            {
                evtFoul = new MissedFouledEvent(datAttackingTeam.Team);
            }
            return evtFoul;
        }

        private static GameEvent GameStoryCreateFailedEvent(GameStory gsGameStory, TeamGameData datAttackingTeam, TeamGameData datDefendingTeam, int nDefenceRatio)
        {
            int nFailedRnd = Consts.GameRandom.Next(1, 100);
            if (nFailedRnd <= nDefenceRatio)
            {
                return new StoppedEvent(datAttackingTeam.Team);
            }
            else
            {
                return new MissedEvent(datAttackingTeam.Team);
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

        #endregion
    }
}
