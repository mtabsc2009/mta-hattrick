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
                        Menu.ShowTeamManagement();
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

        #endregion
    }
}
