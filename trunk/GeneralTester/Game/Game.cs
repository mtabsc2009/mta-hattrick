using System;
using System.Collections.Generic;
using System.Text;
using HatTrick.CommonModel;
using HatTrick.TextualView;

namespace HatTrick
{
    public class Game
    {
        private static User m_usrCurrent = null;
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

                    case "2":
                        Console.WriteLine("These functions arent available yet..");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("These functions arent available yet..");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
                strChoice = Menu.ShowWelcome(m_usrCurrent);
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
                tMyTeam = DAL.DBAccess.CreateTeam(m_usrCurrent, strTeamName);
            }
            ShowMyTeam(tMyTeam);

            return tMyTeam;
        }

        private static void ShowMyTeam(Team tMyTeam)
        {
            Console.Clear();
            Console.WriteLine("Welcome " + tMyTeam.Owner);
            Console.WriteLine("Team name: " + tMyTeam.Name);
            Console.WriteLine("Created: " + tMyTeam.CreationDate.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine("Players: " );
            Console.WriteLine();
            for (int nCurrPlayer = 0; nCurrPlayer < tMyTeam.Players.Count; ++nCurrPlayer)
            {
                Console.WriteLine("ID:   " + tMyTeam.Players[nCurrPlayer].ID.ToString());
                Console.WriteLine("Name: " + tMyTeam.Players[nCurrPlayer].Name);
                Console.WriteLine("Age:  " + tMyTeam.Players[nCurrPlayer].Age);
                Console.WriteLine("Skills:   ");
                Console.Write(    "Keeping:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].KeeperVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "Defending:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].DefendingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "Playmaking: ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PlaymakingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "Winger:     ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].WingerVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "Passing:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].PassingVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "Scoring:    ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].ScoringVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write(    "SetPieces:  ");
                for (int nSkill = 0; nSkill < (int)tMyTeam.Players[nCurrPlayer].SetPiecesVal; ++nSkill)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();                
            }
            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }
        #endregion
    }
}
