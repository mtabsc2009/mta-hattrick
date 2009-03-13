using System;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using System.Data;
using System.Linq;

namespace HatTrick.TextualView
{
    public static class Menu
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
            Console.WriteLine(string.Format("Hi {0}", m_usrCurrent.Username));
            Console.WriteLine("----------------------");
            Console.WriteLine("Select your choice:");
            Console.WriteLine(" 1. View players");
            Console.WriteLine(" 2. Update player position");
            Console.WriteLine(" 3. Change team formation ");
            Console.WriteLine(" 4. View team formation ");
            Console.WriteLine(" 5. Back to team menu");

            string strChoice = string.Empty;
            strChoice = Console.ReadLine();
            while (strChoice != "1" && strChoice != "2" && strChoice != "3" && strChoice != "4" && strChoice != "5")
            {
                Console.WriteLine("Invalid choice, choose again:");
                strChoice = Console.ReadLine();
            }

            return strChoice;
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
    }
}
