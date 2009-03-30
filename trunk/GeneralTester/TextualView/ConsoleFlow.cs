using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HatTrick.CommonModel;
using System.Data;

namespace HatTrick.TextualView
{
    public class ConsoleFlow
    {
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

        private static void StartMatch()
        {
            string strHomeTeam, strAwayTeam;
            Menu.ShowStartMatch(out strAwayTeam);

            strHomeTeam = Game.MyTeam.Name;

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


        private static void ShowCreateUser()
        {
            string strUsername, strPassword;
            Console.Clear();
            Menu.ShowCreateAcouunt(out strUsername, out strPassword);
            if (!Game.CreateUser(strUsername, strPassword))
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
            if (Game.Login(strUsername, strPassword) != null)
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
            string strChoice = Menu.ShowWelcome(Game.User);

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
                strChoice = Menu.ShowWelcome(Game.User);
            }
        }

        private static void HandleLeague()
        {
            Console.Clear();
            string strChoice = Menu.ShowLeague(Game.User);
            while (strChoice != "6")
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
                        Game.PlayNextCycle();
                        break;
                    case "4":
                        ShowTrainAllTeams();
                        break;
                    case "5":
                        ShowLeagueTable();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowLeague(Game.User);
            }
        }

        private static void ShowLeagueTable()
        {
            Menu.ShowLeagueTable(Game.GetLeague());
        }

        private static void HandleManageTeam()
        {
            Console.Clear();
            string strChoice = Menu.ShowManageTeam(Game.User);

            while (strChoice != "7")
            {
                switch (strChoice)
                {
                    case "1":
                        ShowMyTeam(Game.MyTeam);
                        break;

                    case "2":
                        ChangePlayerPosition();
                        break;

                    case "3":
                        ChangeTeamFomation();
                        break;
                    case "4":
                        Menu.ShowMyFormation(Game.MyTeam);
                        break;
                    case "5":
                        HandleTransaferPlayers();
                        break;
                    case "6":
                        ShowTrainingTypes(Game.MyTeam);
                        break;
                }

                Console.Clear();
                strChoice = Menu.ShowManageTeam(Game.User);
            }
        }

        public static void ShowMyTeam(Team tMyTeam)
        {
            Menu.ShowPrintPlayers(tMyTeam);
        }


        public static void ChangePlayerPosition()
        {
            Menu.ShowPrintPlayers(Game.MyTeam);

            int n;

            Player plrToChange;
            Player plrChangedPos;
            Menu.ShowChangePlayerPos(Game.MyTeam, out n, out plrToChange, out plrChangedPos);
            Game.ChangePlayerPosition(plrToChange, plrChangedPos);
        }



        public static void ChangeTeamFomation()
        {
            DataRowCollection drColFormations = Game.GetFormations();
            string strChoice = Menu.ShowTeamFormation(Game.User, drColFormations);
            Game.MyTeam.Formation = strChoice;
            Game.ChangeTeamFormation(Game.MyTeam, strChoice);
            Menu.ShowFormationChanged();
        }

        public static Player ChoosePlayerByID(List<Player> i_Players)
        {
            int n;

            Console.WriteLine("Please choose player id");
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
                        Console.WriteLine("Please choose player id");
                        strPlayerID = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please choose player id");
                    strPlayerID = Console.ReadLine();
                }
            }

            return player;
        }




        public static void HandleBuyPlayer(Team tMyTeam, List<Player> playersForSale, Player playerToBuy)
        {
            if (playersForSale.Count > 0)
            {
                Console.WriteLine("You Have " + tMyTeam.TeamCash + " Cash to buy players.");
                if (Game.buyPlayer(playerToBuy))
                {
                    Console.WriteLine("Player " + playerToBuy.Name + " was trasfered to you team!.");
                }
                else
                {
                    Console.WriteLine("Cannot buy player..");
                }
            }
            else
            {
                Console.WriteLine("No players for sale at this time.");
            }

            Console.WriteLine("Press enter to return");
            Console.ReadLine();

        }

        public static void ManageTeam()
        {
            if (Game.MyTeam == null)
            {
                string strTeamName;
                Menu.ShowCreateNewTeam(out strTeamName);
                
                while (Game.TeamExists(strTeamName))
                {
                    Menu.ShowCreateNewTeam(out strTeamName);
                }

                Game.CreateTeam(strTeamName);
            }

            HandleManageTeam();
        }

        public static void ShowCycles()
        {
            Console.Clear();
            DataView dvAllCycles = Game.GetAllCycles();

            string strGameID;

            Console.WriteLine("Game#\tHome Team\tAway Team\tScore");
            Console.WriteLine("===============================================================");
            Console.WriteLine();

            int nCycleNo = 1;
            GameStory gsStory = null;
            foreach (DataRowView drvCurr in dvAllCycles)
            {
                if ((int.Parse((string)drvCurr["CycleNum"]) != nCycleNo))
                {
                    nCycleNo = (int.Parse((string)drvCurr["CycleNum"]));
                    Console.WriteLine("------------------------------------------------------(C{0})-----", nCycleNo - 1);
                }
                if (drvCurr["GameId"].ToString().Trim() == "")
                {
                    strGameID = "N\\A";
                    gsStory = null;
                }
                else
                {
                    strGameID = drvCurr["GameId"].ToString();
                    try
                    {
                        gsStory = Game.GetGameStory(strGameID);
                    }
                    catch
                    {
                        gsStory = null;
                    }

                }
                Console.WriteLine("{2}\t{0}\t\t{1}\t\t {3}-{4}", drvCurr["HomeTeam"], drvCurr["AwayTeam"], strGameID,
                    gsStory == null ? " " : gsStory.HomeScore.ToString(),
                    gsStory == null ? string.Empty : gsStory.AwayScore.ToString()
                    );
            }
            Console.WriteLine("------------------------------------------------------(C{0})-----", nCycleNo);
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
                    GameStory gsToShow = Game.GetGameStory(nGameToShow);
                    Menu.ShowGameStory(gsToShow);
                }
                catch
                {
                    Console.WriteLine("Game doesn't exists...");
                }
            }
        }

        private static void ShowTrainAllTeams()
        {
            int nNumOfTrains = Menu.ShowGetNumOfTrains();
            Game.TrainAllTeams(nNumOfTrains);
        }

        private static void ShowTrainingTypes(Team tMyTeam)
        {
            string strChoice = Menu.ShowTrainingTypes(tMyTeam);
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(strChoice)));
            Console.WriteLine("Training type changed");
            Console.ReadLine();
        }

        private static void HandleTransaferPlayers()
        {

            string strChoice = Menu.ShowTransafersMenu();

            while (strChoice != "3")
            {
                //switch (strChoice)
                //{
                //    case "1":
                //        ShowSellPlayers(tMyTeam);
                //        break;
                //    case "2":
                //        showBuyPlayer();
                //        break;
                //}
                //Console.Clear();

                strChoice = Menu.ShowTransafersMenu();
            }
        }

    }
}
