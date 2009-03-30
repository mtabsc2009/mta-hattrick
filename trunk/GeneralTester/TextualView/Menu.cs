using System;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using System.Data;
using System.Linq;

namespace HatTrick.TextualView
{
    internal static class Menu
    {
        public static string ShowMain()
        {
            Console.WriteLine("Welcome to HatTrick");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("Select youre choice:");
            Console.WriteLine(" 1. Login");
            Console.WriteLine(" 2. Create Account");
            Console.WriteLine(" 3. Exit");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3")
            {
               Console.WriteLine("Invalid choice, choose again:");
               strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static void ShowLogin(out string strUsername, out string strPassword)
        {
            Console.WriteLine("Login to HatTrick:");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter your username: ");
            strUsername = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            strPassword = Console.ReadLine();
        }

        public static string ShowWelcome(User m_usrCurrent)
        {
            Console.WriteLine(string.Format("Welcome {0}!", m_usrCurrent.Username));
            Console.WriteLine("----------------------");
            Console.WriteLine("Select your choice:");
            Console.WriteLine(" 1. Manage Team");
            Console.WriteLine(" 2. Check Games");
            Console.WriteLine(" 3. League");
            Console.WriteLine(" 4. Sign out");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4")
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;

        }

        public static string ShowManageTeam(User m_usrCurrent)
        {
            int iChoise = 0;
            Console.WriteLine(string.Format("Hi {0}", m_usrCurrent.Username));
            Console.WriteLine("----------------------");
            Console.WriteLine("Select your choice:");
            Console.WriteLine(" 1. View players");
            Console.WriteLine(" 2. Update player position");
            Console.WriteLine(" 3. Change team formation ");
            Console.WriteLine(" 4. View team formation ");
            Console.WriteLine(" 5. Transfers");
            Console.WriteLine(" 6. Set team training type ");
            Console.WriteLine(" 7. Back to team menu");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (!int.TryParse(strChoice, out iChoise) && iChoise > 0 && iChoise < 8)
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static void ShowPrintPlayers(Team tMyTeam)
        {
            Console.Clear();
            Console.WriteLine("Welcome " + tMyTeam.Owner);
            Console.WriteLine("Team name: " + tMyTeam.Name);
            Console.WriteLine("Created: " + tMyTeam.CreationDate.ToShortDateString());
            Console.WriteLine("Current formation: " + tMyTeam.Formation);
            Console.WriteLine();
            Console.WriteLine("Players: ");
            Console.WriteLine();
            Console.WriteLine("ID  Pos\tName(Age)\tKeeping   Defending  PlayMaking Winger     Passing   Scoring    SetPieces ");
            Console.WriteLine("====================================================================================================");
            Console.WriteLine();


            for (int nCurrPlayer = 1; nCurrPlayer <= tMyTeam.Players.Count; ++nCurrPlayer)
            {
                Player plrCurr = (Player)tMyTeam.Players.Where(T => T.Position == nCurrPlayer).First();
                if (nCurrPlayer == 12)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }

                int nLength = plrCurr.Name.Length;
                Console.Write("{0} {1} \t{2}({3})\t", 
                    plrCurr.ID.ToString(),
                    plrCurr.Position,
                    plrCurr.Name.Substring(0, nLength < 11 ? nLength : 11),
                    plrCurr.Age);
                //if ((plrCurr.ID.ToString().Length + nLength) < 15)
                //{
                //    Console.Write("\t");
                //}
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.KeeperVal, 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.DefendingVal, 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.PlaymakingVal, 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.WingerVal, 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.PassingVal, 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.ScoringVal, 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)plrCurr.SetPiecesVal, 11);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to return");
            Console.ReadLine();


        }

        public static void ShowChangePlayerPos(Team tMyTeam, out int n, out Player plrToChange, out Player plrChangedPos)
        {
            string strPlayerID;
            Console.WriteLine("Please choose player id");
            strPlayerID = Console.ReadLine();
            plrToChange = null;


            bool bDoesExists = false;
            n = 0;
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

            plrChangedPos = (Player)tMyTeam.Players.Where(T => T.Position == int.Parse(strPos)).First();
            plrChangedPos.Position = plrToChange.Position;
            plrToChange.Position = int.Parse(strPos);
        }


        private static int PrintSingleSkill(Team tMyTeam, int nCurrPlayer, int nCurrSkillVal, int nCompletion)
        {
            int nSkillPrint = nCurrSkillVal;
            if (nCurrSkillVal > 10)
            {
                nSkillPrint = 6;
            }
            int nSkill;
            for (nSkill = 0; nSkill < nSkillPrint; ++nSkill)
            {
                Console.Write("*");
            }
            if (nCurrSkillVal > 10)
            {
                Console.Write("({0}) ", nCurrSkillVal);
            }
            else
            {
                PrintRest(nCompletion - nCurrSkillVal);
            }
            return nSkill;
        }

        private static void PrintRest(int nRest)
        {
            if (nRest > 0)
            {
                for (int i = 1; i <= nRest; i++)
                {
                    Console.Write(" ");
                }
            }
        }

        public static void ShowPrintPlayersOld(Team tMyTeam)
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

        public static string ShowTeamFormation(User m_usrCurrent, DataRowCollection drFormations)
        {
            Console.Clear();
            Console.WriteLine(string.Format("Hi {0}", m_usrCurrent.Username));
            Console.WriteLine("----------------------");
            Console.WriteLine("Select your choice:");

            int nCurrIndex = 1;

            foreach (DataRow dr in drFormations)
            {
                Console.WriteLine("{0}. {1} ", nCurrIndex, dr[0].ToString());
                nCurrIndex++;
            }

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (int.Parse(strChoice) <= 0 || int.Parse(strChoice) > nCurrIndex - 1)
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return drFormations[int.Parse(strChoice)-1][0].ToString();
        }

        public static void ShowCreateNewTeam(out string strTeamName)
        {
            Console.Clear();
            Console.WriteLine("Please choose your team name");
            strTeamName = Console.ReadLine();
        }

        public static void ShowCreateAcouunt(out string strUsername, out string strPassword)
        {
            Console.WriteLine("Welcome to HatTrick!");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter your new username: ");
            strUsername = Console.ReadLine();
            Console.WriteLine("Enter your new password: ");
            strPassword = Console.ReadLine();

            Console.WriteLine("Confirm youre password: ");
            string strRePassword = Console.ReadLine();

            while (strPassword != strRePassword)
            {
                Console.WriteLine("Passwords dont match, enter again:");
                Console.WriteLine("Enter your new password: ");
                strPassword = Console.ReadLine();

                Console.WriteLine("Confirm youre password: ");
                strRePassword = Console.ReadLine();
            }
        }

        public static void ShowErrorNewUser()
        {
            Console.WriteLine("Error creating new user, choose a username that does not exist.");
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowErrorLogin()
        {
            Console.WriteLine("Error loging in. User doest not exist or password incorrect.");
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowMyFormation(Team tMyTeam)
        {
            int nDefence = int.Parse(tMyTeam.Formation.Split('-')[0]);
            int nMidField = int.Parse(tMyTeam.Formation.Split('-')[1]);
            int nAttack = int.Parse(tMyTeam.Formation.Split('-')[2]);

            Console.Clear();
            Console.WriteLine("Hello coach!");
            Console.WriteLine("Your formation is {0}", tMyTeam.Formation);

            Player pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == 1)).First());

            PrintBuffer(1);

            CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
            PrintBuffer(nDefence);

            for (int i = 2; i <= nDefence + 1; i++)
            {
                pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
                CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
            }

            PrintBuffer(nMidField);

            for (int i = nDefence + 2; i <= nMidField + nDefence + 1; i++)
            {
                pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
                CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
            }

            PrintBuffer(nAttack);

            for (int i = nMidField + nDefence + 2; i <= 11; i++)
            {
                pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
                CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
            }

            PrintBuffer(1);

            Console.WriteLine("Sitting on the bench: ");
            for (int i = 12; i < tMyTeam.Players.Count + 1; i++)
            {
                pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
                CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
                Console.WriteLine();
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Press any key to return");
            Console.ReadLine();

        }

        private static void PrintBuffer(int nPos)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            if (nPos == 3)
            {
                PrintExact(20);
            }
            else if (nPos == 4)
            {
                PrintExact(5);
            }
            else if (nPos == 2)
            {
                PrintExact(30);
            }
            else if (nPos == 1)
            {
                PrintExact(40);
            }
        }

        private static void CompleteToTen(string strPlayerName)
        {
            Console.Write(strPlayerName);

            for (int nCurr = strPlayerName.Length; nCurr <= 20; ++nCurr)
            {
                Console.Write(" ");
            }
        }

        private static void PrintExact(int nExact)
        {
            for (int nCurr = 0; nCurr < nExact; ++nCurr)
            {
                Console.Write(" ");
            }
        }

        public static string ShowLeague(User m_usrCurrent)
        {
            Console.WriteLine("Welcome to your league:");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Select your choice:");
            Console.WriteLine(" 1. Play a friendly match");
            Console.WriteLine(" 2. Show League Cycles");
            Console.WriteLine(" 3. Run  League Next cycle");
            Console.WriteLine(" 4. Train all teams");
            Console.WriteLine(" 5. Show League Table");
            Console.WriteLine(" 6. Exit");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4" && strChoice != "5" && strChoice != "6")
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;

        }

        public static void ShowStartMatch(out string strAwayTeam)
        {
            Console.Clear();
            Console.WriteLine("Chose the you'r opponent team:");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Enter away team:");
            strAwayTeam = GetNoneEmptyString();
        }

        private static string GetNoneEmptyString()
        {
            string strReturn = string.Empty;
            while (strReturn == string.Empty)
            {
                strReturn = Console.ReadLine();
            }
            return strReturn;
        }

        public static void ShowGameStory(GameStory gsGameStory)
        {
            Console.Clear();
            Console.WriteLine("Game Summary");
            Console.WriteLine("=================================");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-us");
            Console.WriteLine(string.Format("{0} hosted the game against {1} at {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.AwayTeam.Team.Name, gsGameStory.GameDate.ToLongDateString()));
            Console.WriteLine("{0} sport's fans watched the game in a {1} weather", gsGameStory.Watchers, gsGameStory.Weather);
            Console.WriteLine("");
            Console.WriteLine(string.Format("{0} played the game with {1} formation playing mostly through the {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.HomeTeam.Formation, 
                (gsGameStory.HomeTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));

            Console.WriteLine(string.Format("visitors {0} chose the {1} formation using the {2}",
                gsGameStory.AwayTeam.Team.Name, gsGameStory.AwayTeam.Formation,
                (gsGameStory.AwayTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));
            Console.WriteLine();
            if (gsGameStory.Winner == null)
            {
                string strDesc = "a";
                if (gsGameStory.HomeScore <= 1) strDesc = "a boring";
                else if (gsGameStory.HomeScore > 2) strDesc = "a dramatic";
                Console.WriteLine("The game ended with {0} tie of {1} each.",strDesc, gsGameStory.HomeScore);
            }
            else
            {
                string strDesc = "a";
                int nDiff = Math.Abs(gsGameStory.HomeScore - gsGameStory.AwayScore);
                if ( nDiff == 1) strDesc = "a close";
                else if (nDiff > 2) strDesc = "a staggering";

                Console.WriteLine("{0} won the game with {1} score of {2}-{3}", gsGameStory.Winner, strDesc, gsGameStory.HomeScore, gsGameStory.AwayScore);
            }
            Console.WriteLine();

            Console.WriteLine("Game Events:");
            Console.WriteLine("===================================:");
            Console.WriteLine();
            Console.WriteLine("First Half:");
            Console.WriteLine("-----------");
            bool bIsFirstHalf = true;
            foreach (KeyValuePair<int, GameEvent> evtCurr in gsGameStory.GameEvents)
            {
                if (bIsFirstHalf && evtCurr.Value.Minute > 45)
                {
                    Console.WriteLine();
                    Console.WriteLine("Second Half:");
                    Console.WriteLine("-----------");
                    bIsFirstHalf = false;
                }
                if (evtCurr.Value is ScoreEvent)
                {
                    if ((evtCurr.Value as ScoreEvent).bShowInSummary)
                    {
                        Console.WriteLine("(Min {0}) {1}",evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to return...");
            Console.ReadLine();
        }

        public static void ShowMatchError()
        {
            Console.WriteLine("There has been an error starting the match.");
        }

        public static void PrintPlayers(List<Player> players)
        {
            Console.WriteLine("Players:");
            Console.WriteLine();
            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }
        }

        public static void ShowFormationChanged()
        {
            Console.WriteLine("Formation changed");
            Console.ReadLine();
        }



        public static string ShowTransafersMenu()
        {
            Console.Clear();
            Console.WriteLine("Transfer Players:");
            Console.WriteLine("-----------------");
            Console.WriteLine("Select your choice:");
            Console.WriteLine(" 1. Sell a player");
            Console.WriteLine(" 2. Buy a player");
            Console.WriteLine(" 3. Exit");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3")
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static string ShowTrainingTypes(Team tMyTeam)
        {
            Console.Clear();
            Console.WriteLine("Your current training type is: " + tMyTeam.TeamTrainingType.ToString());

            Console.WriteLine("Select The training of your team:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defence");
            Console.WriteLine("3. Wings");
            Console.WriteLine("4. PlayMaking");
            Console.WriteLine("5. SetPieces");


            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (int.Parse(strChoice) <= 0 || int.Parse(strChoice) > 5)
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static int ShowGetNumOfTrains()
        {
            Console.Clear();
            Console.WriteLine("Insert the number of trainings:");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            int nChoice;
            bool b = int.TryParse(strChoice, out nChoice);
            while (!b || nChoice <= 0)
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
                b = int.TryParse(strChoice, out nChoice);
            }

            return nChoice;
        }

        public static void ShowLeagueTable(DataView dvLeagueTable)
        {
            Console.Clear();
            int nTeamIndex = 1;
            Console.WriteLine("#  Team Name Matches Wins Draws Losts GoalsDiff Points");
            Console.WriteLine("-- --------- ------- ---- ----- ----- --------- ------");

            foreach (DataRowView drvCurrTeam in dvLeagueTable)
            {
                Console.Write(nTeamIndex.ToString());
                for (int n = nTeamIndex.ToString().Length; n < 4; n++)
                {
                    Console.Write(" ");
                }
                nTeamIndex++;
                Console.Write(drvCurrTeam["TeamName"].ToString());
                for (int n = drvCurrTeam["TeamName"].ToString().Length; n <= 9; n++)
                {
                    Console.Write(" ");
                }
                
                Console.Write(drvCurrTeam["MatchesPlayed"].ToString());
                for (int n = drvCurrTeam["MatchesPlayed"].ToString().Length; n <= 7; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["Wins"].ToString());
                for (int n = drvCurrTeam["Wins"].ToString().Length; n <= 4; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["Draws"].ToString());
                for (int n = drvCurrTeam["Draws"].ToString().Length; n <= 5; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["Loses"].ToString());
                for (int n = drvCurrTeam["Loses"].ToString().Length; n <= 5; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["GoalsFor"].ToString() + "-" +drvCurrTeam["GoalsAgainst"].ToString());
                for (int n = (drvCurrTeam["GoalsFor"].ToString() + "-" + drvCurrTeam["GoalsAgainst"].ToString()).Length; n < 9; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["Points"].ToString());
                for (int n = drvCurrTeam["Points"].ToString().Length; n < 6; n++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowPlayers(DataView dvLeagueTable)
        {
            Console.Clear();
            Console.WriteLine("ID  Pos\tName(Age)\tKeeping   Defending  PlayMaking Winger     Passing   Scoring    SetPieces ");
            Console.WriteLine("====================================================================================================");
            Console.WriteLine();
            int nCurrPlayer = 1;
            foreach (DataRowView drvCurr in dvLeagueTable)
            {
                DateTime dtBDate = DateTime.Parse(drvCurr["Birth_date"].ToString());
                DateTime comparisonDate = new DateTime(dtBDate.Year, DateTime.Now.Month, DateTime.Now.Day);
                int age = (comparisonDate.Date < dtBDate.Date) ?          
                    DateTime.Now.Year - dtBDate.Year - 1 : DateTime.Now.Year - dtBDate.Year;

                int nLength = drvCurr["PlayerName"].ToString().Length;
                Console.Write("{0} {1} \t{2}({3})\t",
                    drvCurr["PlayerID"],
                    drvCurr["PlayerPos"].ToString(),
                    drvCurr["PlayerName"].ToString().Substring(0, nLength < 11 ? nLength : 11),
                    age);
                Team tMyTeam = new Team();
                //(, int nCurrPlayer, int nCurrSkillVal, int nCompletion)

                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["KeeperSkill"].ToString()), 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["DefendingSkill"].ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["PlaymakingSkill"].ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["WingerSkill"].ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["PassingSkill"].ToString()), 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["ScoringSkill"].ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(drvCurr["SetPiecesSkill"].ToString()), 11);
                Console.WriteLine();
                nCurrPlayer++;
            }


        }
    }
}
