using System;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using System.Data;
using System.Linq;


namespace MtaAddIn
{
    delegate String GetUserText();
    internal static class Menu
    {
       // static GetUserText = 
        public static string ShowMain()
        {
            String menus = String.Empty;
            menus += ("Welcome to HatTrick");
            menus += ("--------------------");
            menus += ("");
            menus += ("Select youre choice:");
            menus += (" 1. Login");
            menus += (" 2. Create Account");
            menus += (" 3. Exit");

            string strChoice = string.Empty;
            
           // strChoice = get//Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3")
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static void ShowLogin(out string strUsername, out string strPassword)
        {
            String menus = String.Empty;
            menus += ("Login to HatTrick:");
            menus += ("--------------------");
            menus += ("");
            menus += ("Enter your username: ");
            strUsername = Console.ReadLine();
            menus +=("Enter your password: ");
            strPassword = Console.ReadLine();
        }

        public static string ShowWelcome(User m_usrCurrent)
        {
            String menus = String.Empty;
            menus += (string.Format("Welcome {0}!", m_usrCurrent.Username));
            menus += ("----------------------");
            menus += ("Select your choice:");
            menus += (" 1. Manage Team");
            menus += (" 2. Check Games");
            menus += (" 3. League");
            menus += (" 4. Sign out");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4")
            {
                menus += ("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;

        }

        public static string ShowManageTeam(User m_usrCurrent)
        {
            int iChoise = 0;
            String menus = String.Empty;
            menus += (string.Format("Hi {0}", m_usrCurrent.Username));
            menus += ("----------------------");
            menus += ("Select your choice:");
            menus += (" 1. View players");
            menus += (" 2. Update player position");
            menus += (" 3. Change team formation ");
            menus += (" 4. View team formation ");
            menus += (" 5. Transfers");
            menus += (" 6. Set team training type ");
            menus += (" 7. Back to team menu");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (!int.TryParse(strChoice, out iChoise) && iChoise > 0 && iChoise < 8)
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static void ShowPrintPlayers(Team tMyTeam)
        {
            
            String menus = String.Empty;
            menus += ("Welcome " + tMyTeam.Owner);
            menus += ("Team name: " + tMyTeam.Name);
            menus += ("Created: " + tMyTeam.CreationDate.ToShortDateString());
            menus += ("Current formation: " + tMyTeam.Formation);
            menus += "\n";
            menus += ("Players: ");
            menus += "\n";
            menus += ("ID  Pos\tName(Age)\tKeeping   Defending  PlayMaking Winger     Passing   Scoring    SetPieces ");
            menus += ("====================================================================================================");
            menus += "\n";

            for (int nCurrPlayer = 1; nCurrPlayer <= tMyTeam.Players.Count; ++nCurrPlayer)
            {
                Player plrCurr = (Player)tMyTeam.Players.Where( T => T.Position == nCurrPlayer).First();
                if (nCurrPlayer == 12)
                {
                    menus +=("----------------------------------------------------------------------------------------------------");
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
                menus +=("\n");
            }

            menus += ("Press any key to return");
            Console.ReadLine();


        }

        public static void ShowChangePlayerPos(Team tMyTeam, out int n, out Player plrToChange, out Player plrChangedPos)
        {
            string strPlayerID;
            String menus = String.Empty;
            menus += ("Please choose player id");
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
                        menus += ("Please choose player id");
                        strPlayerID = Console.ReadLine();
                    }
                }
            }

            menus += String.Format("Please choose a position for player {0}", plrToChange.Name);
            string strPos = Console.ReadLine();

            plrChangedPos = (Player)tMyTeam.Players.Where(T => T.Position == int.Parse(strPos)).First();
            plrChangedPos.Position = plrToChange.Position;
            plrToChange.Position = int.Parse(strPos);
        }


        private static int PrintSingleSkill(Team tMyTeam, int nCurrPlayer, int nCurrSkillVal, int nCompletion)
        {
            int nSkillPrint = nCurrSkillVal;
            String menus = String.Empty;
            if (nCurrSkillVal > 10)
            {
                nSkillPrint = 6;
            }
            int nSkill;
            for (nSkill = 0; nSkill < nSkillPrint; ++nSkill)
            {
                menus += ("*");
            }
            if (nCurrSkillVal > 10)
            {
                menus += String.Format("({0}) ", nCurrSkillVal);
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
            String menus = String.Empty;
            menus += ("Welcome " + tMyTeam.Owner);
            menus += ("Team name: " + tMyTeam.Name);
            menus += ("Created: " + tMyTeam.CreationDate.ToShortDateString());
            menus += ("Current formation: " + tMyTeam.Formation);
            menus += "\n";
            menus += ("Players: ");
            menus += "\n";
            for (int nCurrPlayer = 0; nCurrPlayer < tMyTeam.Players.Count; ++nCurrPlayer)
            {
                menus += ("ID:   " + tMyTeam.Players[nCurrPlayer].ID.ToString());
                menus += ("Name: " + tMyTeam.Players[nCurrPlayer].Name);
                menus += ("Age:  " + tMyTeam.Players[nCurrPlayer].Age);
                menus += ("Position:  " + tMyTeam.Players[nCurrPlayer].Position);
                menus += ("Skills:   ");
                Console.Write("Keeping:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].KeeperVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("Defending:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].DefendingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("Playmaking: ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PlaymakingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("Winger:     ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].WingerVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("Passing:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PassingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("Scoring:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].ScoringVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                Console.Write("SetPieces:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].SetPiecesVal; ++nSkill)
                {
                    Console.Write("*");
                }
                menus += "\n";
                menus += "\n";
                menus += "\n";
            }

        }

        public static string ShowTeamFormation(User m_usrCurrent, DataRowCollection drFormations)
        {
            String menus = String.Empty;
            menus += (string.Format("Hi {0}", m_usrCurrent.Username));
            menus += ("----------------------");
            menus += ("Select your choice:");

            int nCurrIndex = 1;

            foreach (DataRow dr in drFormations)
            {
                menus += String.Format("{0}. {1} ", nCurrIndex, dr[0].ToString());
                nCurrIndex++;
            }

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (int.Parse(strChoice) <= 0 || int.Parse(strChoice) > nCurrIndex - 1)
            {
                menus += ("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return drFormations[int.Parse(strChoice) - 1][0].ToString();
        }

        public static void ShowCreateNewTeam(out string strTeamName)
        {
            String menus = String.Empty;
            menus += ("Please choose your team name");
            strTeamName = Console.ReadLine();
        }

        public static void ShowCreateAcouunt(out string strUsername, out string strPassword)
        {
            String menus = String.Empty;
            menus += ("Welcome to HatTrick!");
            menus += ("--------------------");
            menus += ("");
            menus += ("Enter your new username: ");
            strUsername = Console.ReadLine();
            menus += ("Enter your new password: ");
            strPassword = Console.ReadLine();

            menus += ("Confirm youre password: ");
            string strRePassword = Console.ReadLine();

            while (strPassword != strRePassword)
            {
                menus += ("Passwords dont match, enter again:");
                menus += ("Enter your new password: ");
                strPassword = Console.ReadLine();

                menus += ("Confirm youre password: ");
                strRePassword = Console.ReadLine();
            }
        }

        public static void ShowErrorNewUser()
        {
            String menus = String.Empty;
            menus += ("Error creating new user, choose a username that does not exist.");
            menus += ("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowErrorLogin()
        {
            String menus = String.Empty;
            menus += ("Error loging in. User doest not exist or password incorrect.");
            menus += ("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowMyFormation(Team tMyTeam)
        {
            int nDefence = int.Parse(tMyTeam.Formation.Split('-')[0]);
            int nMidField = int.Parse(tMyTeam.Formation.Split('-')[1]);
            int nAttack = int.Parse(tMyTeam.Formation.Split('-')[2]);

            String menus = String.Empty;
            menus += ("Hello coach!");
            menus += String.Format("Your formation is {0}", tMyTeam.Formation);

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

            menus += ("Sitting on the bench: ");
            for (int i = 12; i < tMyTeam.Players.Count + 1; i++)
            {
                pCurrPlayer = ((Player)(tMyTeam.Players.Where(T => T.Position == i)).First());
                CompleteToTen(pCurrPlayer.Position.ToString() + "." + pCurrPlayer.Name);
                menus += ("\n");
            }

            menus += ("\n");
            menus += ("\n");
            menus += ("\n");
            menus += ("\n");

            menus += ("Press any key to return");
            Console.ReadLine();

        }

        private static void PrintBuffer(int nPos)
        {
            String menus = String.Empty;
            menus += "\n";
            menus += "\n";
            menus += "\n";
            menus += "\n";

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
            String menus = String.Empty;
            menus +=("Welcome to your league:");
            menus +=("-------------------------");
            menus +=("Select your choice:");
            menus +=(" 1. Play a friendly match");
            menus +=(" 2. Show League Cycles");
            menus +=(" 3. Run  League Next cycle");
            menus +=(" 4. Train all teams");
            menus +=(" 5. Show League Table");
            menus +=(" 6. Exit");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4" && strChoice != "5" && strChoice != "6")
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }
            return strChoice;
        }

        public static void ShowStartMatch(out string strAwayTeam)
        {
            String menus = String.Empty;
            menus +=("Chose the you'r opponent team:");
            menus +=("-------------------------");

            menus +=("Enter away team:");
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
            String menus = String.Empty;
            menus +=("Game Summary");
            menus +=("=================================");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-us");
            menus +=(string.Format("{0} hosted the game against {1} at {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.AwayTeam.Team.Name, gsGameStory.GameDate.ToLongDateString()));
            menus += String.Format("{0} sport's fans watched the game in a {1} weather", gsGameStory.Watchers, gsGameStory.Weather);
            menus +=("\n");
            menus +=(string.Format("{0} played the game with {1} formation playing mostly through the {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.HomeTeam.Formation,
                (gsGameStory.HomeTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));

            menus +=(string.Format("visitors {0} chose the {1} formation using the {2}",
                gsGameStory.AwayTeam.Team.Name, gsGameStory.AwayTeam.Formation,
                (gsGameStory.AwayTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));
            menus +=("\n");
            if (gsGameStory.Winner == null)
            {
                string strDesc = "a";
                if (gsGameStory.HomeScore <= 1) strDesc = "a boring";
                else if (gsGameStory.HomeScore > 2) strDesc = "a dramatic";
                menus += String.Format("The game ended with {0} tie of {1} each.", strDesc, gsGameStory.HomeScore);
            }
            else
            {
                string strDesc = "a";
                int nDiff = Math.Abs(gsGameStory.HomeScore - gsGameStory.AwayScore);
                if (nDiff == 1) strDesc = "a close";
                else if (nDiff > 2) strDesc = "a staggering";

                menus += String.Format("{0} won the game with {1} score of {2}-{3}", gsGameStory.Winner, strDesc, gsGameStory.HomeScore, gsGameStory.AwayScore);
            }
            menus +="\n";

            menus +=("Game Events:");
            menus +=("===================================:");
            menus +="\n";
            menus +=("First Half:");
            menus +=("-----------");
            bool bIsFirstHalf = true;
            foreach (KeyValuePair<int, GameEvent> evtCurr in gsGameStory.GameEvents)
            {
                if (bIsFirstHalf && evtCurr.Value.Minute > 45)
                {
                    menus +=("\n");
                    menus +=("Second Half:");
                    menus +=("-----------");
                    bIsFirstHalf = false;
                }
                if (evtCurr.Value is ScoreEvent)
                {
                    if ((evtCurr.Value as ScoreEvent).bShowInSummary)
                    {
                        menus += String.Format("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                    }
                }
                else
                {
                    menus += String.Format("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                }
                menus +=("\n");
            }

            menus +=("\n");
            menus +=("Press ENTER to return...");
            Console.ReadLine();
        }

        public static void ShowMatchError()
        {
            String menus = String.Empty;
            menus +=("There has been an error starting the match.");
        }

        public static void PrintPlayers(List<Player> players)
        {
            String menus = String.Empty;
            menus +=("Players:");
            menus +=("\n");
            foreach (Player player in players)
            {
                menus +=(player);
            }
        }

        public static void ShowFormationChanged()
        {
            String menus = String.Empty;
            menus +=("Formation changed");
            Console.ReadLine();
        }



        public static string ShowTransafersMenu()
        {
            String menus = String.Empty;
            menus +=("Transfer Players:");
            menus +=("-----------------");
            menus +=("Select your choice:");
            menus +=(" 1. Sell a player");
            menus +=(" 2. Buy a player");
            menus +=(" 3. Exit");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3")
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static string ShowTrainingTypes(Team tMyTeam)
        {
            String menus = String.Empty; 
            menus += ("Your current training type is: " + tMyTeam.TeamTrainingType.ToString());

            menus +=("Select The training of your team:");
            menus +=("---------------------------------");
            menus +=("1. Attack");
            menus +=("2. Defence");
            menus +=("3. Wings");
            menus +=("4. PlayMaking");
            menus +=("5. SetPieces");


            string strChoice = string.Empty;
            strChoice = Console.ReadLine();

            while (int.Parse(strChoice) <= 0 || int.Parse(strChoice) > 5)
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
        }

        public static int ShowGetNumOfTrains()
        {
            String menus = String.Empty; 
            menus += ("Insert the number of trainings:");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            int nChoice;
            bool b = int.TryParse(strChoice, out nChoice);
            while (!b || nChoice <= 0)
            {
                menus +=("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
                b = int.TryParse(strChoice, out nChoice);
            }

            return nChoice;
        }

        public static void ShowLeagueTable(DataView dvLeagueTable)
        {
            String menus = String.Empty;
            int nTeamIndex = 1;
            menus +=("#  Team Name Matches Wins Draws Losts GoalsDiff Points");
            menus +=("-- --------- ------- ---- ----- ----- --------- ------");

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

                Console.Write(drvCurrTeam["GoalsFor"].ToString() + "-" + drvCurrTeam["GoalsAgainst"].ToString());
                for (int n = (drvCurrTeam["GoalsFor"].ToString() + "-" + drvCurrTeam["GoalsAgainst"].ToString()).Length; n < 9; n++)
                {
                    Console.Write(" ");
                }

                Console.Write(drvCurrTeam["Points"].ToString());
                for (int n = drvCurrTeam["Points"].ToString().Length; n < 6; n++)
                {
                    Console.Write(" ");
                }

                menus +=("\n");
            }

            menus +=("\n");
            menus +=("Press enter to return");
            Console.ReadLine();
        }

        public static void ShowPlayers(List<Player> players)
        {
            String menus = String.Empty;
            menus +=("ID  Pos\tName(Age)\tKeeping   Defending  PlayMaking Winger     Passing   Scoring    SetPieces ");
            menus +=("====================================================================================================");
            menus +=("\n");
            int nCurrPlayer = 1;
            foreach (Player player in players)
            {
                int age = player.Age;
                int nLength = player.Name.Length;
                Console.Write("{0} {1} \t{2}({3})\t",
                    player.ID,
                    player.Position.ToString(),
                    player.Name.Substring(0, nLength < 11 ? nLength : 11),
                    age);
                Team tMyTeam = new Team();
                //(, int nCurrPlayer, int nCurrSkillVal, int nCompletion)

                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.KeeperVal.ToString()), 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.DefendingVal.ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.PlaymakingVal.ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.WingerVal.ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.PassingVal.ToString()), 10);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.ScoringVal.ToString()), 11);
                PrintSingleSkill(tMyTeam, nCurrPlayer, (int)double.Parse(player.PassingVal.ToString()), 11);
                menus +=("\n");
                nCurrPlayer++;
            }


        }
    }
}
