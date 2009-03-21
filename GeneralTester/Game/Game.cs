using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using HatTrick.TextualView;
using System.Collections;
using System.Diagnostics;
using TextualView;

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
        public static Team MyTeam
        {
            get { return Game.tMyTeam; }
            set { Game.tMyTeam = value; }
        }


        private static IGameView m_ConsoleGameView = new ConsoleGameView();

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
            while (strChoice != "5")
            {
                switch (strChoice)
                {
                    case "1":
                        StartMatch();
                        break;
                    case "2":
                        ShowCycles();
                        break;
                    case "3":
                        PlayNextCycle();
                        break;
                    case "4":
                        ShowTrainAllTeams();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowLeague(m_usrCurrent);
            }
        }

        private static void HandleManageTeam()
        {
            Console.Clear();
            string strChoice = Menu.ShowManageTeam(m_usrCurrent);

            while (strChoice != "7")
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
                    case "5":
                        HandleTransaferPlayers();
                        break;
                    case "6":
                        ShowTrainingTypes(tMyTeam);
                        break;
                }

                Console.Clear();
                strChoice = Menu.ShowManageTeam(m_usrCurrent);
            }
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

        public static void PlayNextCycle()
        {
            DataView dvAllCycles = DAL.DBAccess.GetAllCycles();

            List<CycleGame> lstCycleGames = CyclesToList(dvAllCycles);

            int nMin = (lstCycleGames.Where(T => T.GameID == -1)).Min(T => T.CycleNum);

            foreach (CycleGame gmCurr in (lstCycleGames.Where(T=>T.CycleNum == nMin)))
            {
                // Run Game
                GameStory gsNewGame = Game.MatchTeams(gmCurr.HomeTeam, gmCurr.AwayTeam);
                gmCurr.GameID = DAL.DBAccess.SaveStoryToDB(gsNewGame);
                gmCurr.CycleDate = DateTime.Now;
                DAL.DBAccess.UpdateCycleData(gmCurr);
            }
        }

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

        public static void ShowCycles()
        {
            if (DAL.DBAccess.CheckShouldCreateNewLeague())
            {
                Console.WriteLine("Creating new league cycles, press any key to contiue");
                CreateLeagueTable();                
                CreateNewLeagueCycles();
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                DataView dvAllCycles = DAL.DBAccess.GetAllCycles();

                string strGameID;

                Console.WriteLine("Game#\tHome Team\tAway Team");
                Console.WriteLine("===============================================================");
                Console.WriteLine();

                int nCycleNo = 1;
                foreach (DataRowView drvCurr in dvAllCycles)
                {
                    if ((int.Parse((string)drvCurr["CycleNum"]) != nCycleNo))
                    {
                        nCycleNo = (int.Parse((string)drvCurr["CycleNum"]));
                        Console.WriteLine("------------------------------------------------------(C{0})-----", nCycleNo-1);
                    }
                    if (drvCurr["GameId"].ToString().Trim() == "")
                    {
                        strGameID = "N\\A";
                    }
                    else
                    {
                        strGameID = drvCurr["GameId"].ToString();
                    }
                    Console.WriteLine("{2}\t{0}\t\t{1}", drvCurr["HomeTeam"], drvCurr["AwayTeam"],strGameID);
                }
                Console.WriteLine("------------------------------------------------------(C{0})-----", nCycleNo - 1);
                Console.WriteLine();

                Console.WriteLine("Please choose a game id to view, or press 0 to return");
                int nGameToShow = 0;

                try
                {
                    // It's ok to error here..
                    string str = Console.ReadLine();
                    if (str != "")
                    {
                        nGameToShow = int.Parse(str);
                    }
                }
                catch
                {

                }

                if (nGameToShow != 0)
                {
                    try
                    {
                        GameStory gsToShow = LoadGameStory(nGameToShow);
                        Menu.ShowGameStory(gsToShow);
                    }
                    catch
                    {
                        Console.WriteLine("Game doesn't exists...");
                    }
                }
            }
        }

        private static void CreateLeagueTable()
        {
            DAL.DBAccess.CreateLeagueEmptyTable();
        }

        public static void CreateNewLeagueCycles()
        {
            if (DAL.DBAccess.CheckShouldCreateNewLeague())
            {
                DataView alTeams;
                ArrayList alCycles = new ArrayList();
                alTeams = DAL.DBAccess.GetAllTeams();

                for (int nHomeTeam = 0; nHomeTeam < alTeams.Count; nHomeTeam++)
                {
                    for (int nAwayTeam = 0; nAwayTeam < alTeams.Count; nAwayTeam++)
                    {
                        if (nHomeTeam != nAwayTeam)
                        {
                            CycleGame cgNew = new CycleGame();
                            cgNew.HomeTeam = (string)alTeams[nHomeTeam]["TeamName"];
                            cgNew.AwayTeam = (string)alTeams[nAwayTeam]["TeamName"];
                            alCycles.Add(cgNew);
                        }
                    }
                }

                ArrayList alCurrCycle = new ArrayList();
                alCurrCycle.Add(alCycles[0]);
                ((CycleGame)alCycles[0]).CycleNum = 1;
                alCycles.RemoveAt(0);

                bool bWasGameFound;
                bool bAreTeamsExists;
                int nTeamCount = DAL.DBAccess.GetTeamCount();
                int nLastAddition = 0;
                int nCycleNum = 1;

                while (alCycles.Count > 0)
                {

                    while (alCurrCycle.Count < nTeamCount / 2)
                    {
                        bWasGameFound = false;
                        for (int nAllGames = nLastAddition; nAllGames < alCycles.Count && !bWasGameFound; nAllGames++)
                        {

                            bAreTeamsExists = false;
                            for (int nCurrCycleGame = 0; nCurrCycleGame < alCurrCycle.Count; nCurrCycleGame++)
                            {
                                if ((((CycleGame)alCycles[nAllGames]).HomeTeam == ((CycleGame)alCurrCycle[nCurrCycleGame]).HomeTeam) ||
                                    (((CycleGame)alCycles[nAllGames]).HomeTeam == ((CycleGame)alCurrCycle[nCurrCycleGame]).AwayTeam) ||
                                    (((CycleGame)alCycles[nAllGames]).AwayTeam == ((CycleGame)alCurrCycle[nCurrCycleGame]).HomeTeam) ||
                                    (((CycleGame)alCycles[nAllGames]).AwayTeam == ((CycleGame)alCurrCycle[nCurrCycleGame]).AwayTeam))
                                {
                                    bAreTeamsExists = true;
                                    break;
                                }
                            }

                            if (!bAreTeamsExists)
                            {
                                bWasGameFound = true;
                                ((CycleGame)alCycles[nAllGames]).CycleNum = nCycleNum;
                                //Debug.Print(((CycleGame)alCycles[nAllGames]).HomeTeam + " - " + ((CycleGame)alCycles[nAllGames]).AwayTeam);
                                alCurrCycle.Add(alCycles[nAllGames]);

                                alCycles.RemoveAt(nAllGames);
                                nLastAddition = nAllGames;
                            }
                        }

                        if (!bWasGameFound)
                        {
                            nLastAddition = 0;
                        }
                    }

                    // Save to DB
                    DAL.DBAccess.SaveCycleToDB(alCurrCycle);
                    alCurrCycle.Clear();
                    nCycleNum++;

                    if (alCycles.Count > 0)
                    {
                        if (nLastAddition == alCycles.Count)
                        {
                            nLastAddition = 0;
                        }

                        ((CycleGame)alCycles[nLastAddition]).CycleNum = nCycleNum;
                        alCurrCycle.Add(alCycles[nLastAddition]);
                        alCycles.RemoveAt(nLastAddition);
                    }
                }
            }
        }

        private static void StartMatch()
        {
            string strHomeTeam, strAwayTeam;
            Console.Clear();
            Menu.ShowStartMatch(out strAwayTeam);

            if (tMyTeam == null)
            {
                tMyTeam = DAL.DBAccess.LoadTeam(m_usrCurrent);
            }

            strHomeTeam = Game.tMyTeam.Name;

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

        private static void ShowTrainAllTeams()
        {
            int nNumOfTrains = Menu.ShowGetNumOfTrains();
            TrainAllTeams(nNumOfTrains);
        }

        private static void ShowTrainingTypes(Team tMyTeam)
        {
            string strChoice = Menu.ShowTrainingTypes(tMyTeam);
            Game.tMyTeam = tMyTeam;
            ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(strChoice)));
            DAL.DBAccess.ChangeTeamTrainingType(tMyTeam);
            Console.WriteLine("Training type changed");
            Console.ReadLine();
        }

        #endregion

        #region Game Enging

        public static void Reset()
        {
            DAL.DBAccess.ResetDebugUser();
            Game.m_usrCurrent = null;
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

        private static void HandleTransaferPlayers()
        {

            Console.Clear();
            string strChoice = Menu.ShowTransafersMenu();

            while (strChoice != "3")
            {
                switch (strChoice)
                {
                    case "1":
                        ShowSellPlayers(tMyTeam);
                        break;
                    case "2":
                        List<Player> playersForSale = DAL.DBAccess.GetPlayersForSale(tMyTeam);
                        if (playersForSale.Count > 0)
                        {
                            m_ConsoleGameView.PrintLine("You Have " + tMyTeam.TeamCash + " Cash to buy players. you them wizely! :)");
                            PrintPlayers(playersForSale);
                            Player playerToBuy = GetPlayerByID(playersForSale);
                            if (BuyPlayer(playerToBuy))
                            {
                                m_ConsoleGameView.PrintLine("Player " + playerToBuy.Name + " was trasfered to you team!.");                                                            
                            }
                            else
                            {
                                m_ConsoleGameView.PrintLine("Cannot buy player..");                            
                            }
                        }
                        else
                        {
                            m_ConsoleGameView.PrintLine("No players for sale at this time.");                            
                        }

                        m_ConsoleGameView.PrintLine("Press enter to return");
                        m_ConsoleGameView.ReadLine();
                        break;
                }
                Console.Clear();

                strChoice = Menu.ShowTransafersMenu();
            }
        }

        private static bool BuyPlayer(Player playerToBuy)
        {
            try
            {
                if(TeamHasEnoughMoneyToBuyPlayer(playerToBuy))
                {
                    DAL.DBAccess.BuyPlayer(tMyTeam, playerToBuy);
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

        private static Player GetPlayerByID(List<Player> i_Players)
        {
            int n;

            m_ConsoleGameView.PrintLine("Please choose player id");
            string strPlayerID;
            Player player = null;

            strPlayerID = Console.ReadLine();

            bool bDoesExists = false;

            while (!bDoesExists)
            {
                if (int.TryParse(strPlayerID, out n))
                {
                    IEnumerable<Player> enumerable = i_Players.Where(T => T.ID == int.Parse(strPlayerID));
                    if (enumerable.Count() == 1)
                    {
                        player = enumerable.First();
                        bDoesExists = true;
                    }
                    else
                    {
                        m_ConsoleGameView.PrintLine("Please choose player id");
                        strPlayerID = m_ConsoleGameView.ReadLine();
                    }
                }
                else
                {
                    m_ConsoleGameView.PrintLine("Please choose player id");
                    strPlayerID = m_ConsoleGameView.ReadLine();
                }
            }

            return player;
        }

        private static void PrintPlayers(List<Player> players)
        {
            m_ConsoleGameView.PrintLine("Players:");
            m_ConsoleGameView.PrintLine(string.Empty);
            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }
        }

        private static void ShowSellPlayers(Team tMyTeam)
        {
            String strPlayerName = String.Empty;
            String strPlayerCost = String.Empty;
            int intCost = -1;
        
            DataView dtNew = DAL.DBAccess.GetNotForSellTeamPlayers(tMyTeam.Name);
            Console.Clear();
            Console.WriteLine("Chose What Player you want to sell:");
            foreach (DataRowView drvCurr in dtNew)
            {
                Console.WriteLine(" {0}", drvCurr["PlayerName"]);
            }
            while (dtNew.Count > 0)
            {    
                Console.Write("Sell Player:");
                strPlayerName = Console.ReadLine();
                if (DAL.DBAccess.CanISellPlayer(strPlayerName, tMyTeam))
                {
                    while (true)
                    {
                        Console.WriteLine("Enter {0} cost:", strPlayerName);
                        strPlayerCost = Console.ReadLine();
                        if (int.TryParse(strPlayerCost, out intCost) && intCost > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("YOU MAST ENTER A NUMBER!!!");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("you can not sell this player!!!");    
                }

            }
            if (strPlayerName.Length > 0)
            {
                DAL.DBAccess.UpdateSellPlayer(strPlayerName, intCost);
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
            Menu.ShowPrintPlayers(tMyTeam);
            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        private static void ChangePlayerPosition()
        {
            Menu.ShowPrintPlayers(tMyTeam);

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
                    try
                    {
                        plrToChange = (Player)tMyTeam.Players.Where(T => T.ID == int.Parse(strPlayerID)).First();
                    }
                    catch
                    {
                        plrToChange = null;
                    }

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

        public static GameStory LoadGameStory(int nStoryID)
        {
            return DAL.DBAccess.LoadGameStory(nStoryID);
        }


        public static int SaveStoryToDB(GameStory gsNewGame)
        {
            return DAL.DBAccess.SaveStoryToDB(gsNewGame);
        }

        public static void ChangeTeamTrainngType(Consts.TrainingType ttTeamTrainingType)
        {
            tMyTeam.TeamTrainingType = ttTeamTrainingType;
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
            allTeams = DAL.DBAccess.GetAllTeams();
            foreach (DataRowView drTeam in allTeams)
            {
                Team tCurrTeam = DAL.DBAccess.LoadTeam(drTeam["TeamName"].ToString());
                for (int nCurrTrain = 0; nCurrTrain < nNumOfTrainings; ++nCurrTrain)
                {
                    TrainTeam(tCurrTeam);
                }
                DAL.DBAccess.SaveTeamSkills(tCurrTeam);
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
    }
}
