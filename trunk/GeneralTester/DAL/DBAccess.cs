using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using HatTrick.CommonModel;

namespace DAL
{
    static public class DBAccess
    {
        private static OleDbConnection m_cnConnection;

        static DBAccess()
        {
            m_cnConnection = new OleDbConnection();
            m_cnConnection.ConnectionString = Properties.Settings.Default.HtTrickConnectionString;
        }

        static private void Connect()
        {
            if (m_cnConnection.State != System.Data.ConnectionState.Open)
            {
                m_cnConnection.Open();
            }
        }

        static private void Close()
        {
            if (m_cnConnection.State == System.Data.ConnectionState.Open)
            {
                m_cnConnection.Close();
            }
        }

        static public bool InsertUser(User usrUser)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            cmdCommand.CommandText = string.Format(
            "INSERT INTO Users(UserName, UserPass) Values(\"{0}\", \"{1}\")", usrUser.Username, usrUser.Password);

            Connect();
            try
            {
                cmdCommand.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Close();
            }
        }

        static public User GetUser(string strUsername, string strPassword)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            cmdCommand.CommandText = string.Format(
            "SELECT count(*) FROM Users " +
            "WHERE  Username = \"{0}\" AND userpass = \"{1}\"", strUsername, strPassword);

            Connect();
            int n = (int)cmdCommand.ExecuteScalar();
            Close();

            if (n == 0)
            {
                return null;
            }
            else
            {
                return new User(strUsername, strPassword);
            }
        }

        public static void ResetDebugUser()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            cmdCommand.CommandText = string.Format(
            "DELETE FROM Users " +
            "WHERE  Username = \"{0}\" AND userpass = \"{1}\"", "DebugUser", "DebugUser");

            try
            {

                Connect();
                int n = (int)cmdCommand.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                Close();
            }
        }

        public static Team LoadTeam(User usrCurrentUser)
        {
            return null;
        }

        public static Team CreateTeam(User usrCurrentUser, string strTeamName)
        {
            OleDbTransaction trTrans;
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            cmdCommand.CommandText = string.Format(
            "INSERT INTO Teams(TeamName, Owner, AU_CreationDate) Values(\"{0}\", \"{1}\", \"{2}\")", strTeamName, usrCurrentUser.Username, DateTime.Now);

            Connect();
            trTrans = m_cnConnection.BeginTransaction();
            cmdCommand.Transaction = trTrans;
            try
            {
                cmdCommand.ExecuteNonQuery();
                CreateNewTeamPlayers(strTeamName, trTrans);

                trTrans.Commit();
                return null;
            }
            catch
            {
                trTrans.Rollback();
                return null;
            }
            finally
            {
                Close();
            }

        }

        private static void CreateNewTeamPlayers(string strTeamName, OleDbTransaction trCurrTrans)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            cmdCommand.Transaction = trCurrTrans;

            for (int nCurrPlayer = 0; nCurrPlayer < 18; nCurrPlayer++)
            {
                // Get First Names amount
                cmdCommand.CommandText = string.Format(
                "SELECT max(ID) FROM FirstNames");
                int nFirstNamesAmount = (int)cmdCommand.ExecuteScalar();

                // Get last Names amount
                cmdCommand.CommandText = string.Format(
                "SELECT max(ID) FROM LastNames");
                int nLastNamesAmount = (int)cmdCommand.ExecuteScalar();

                // Get First Name
                cmdCommand.CommandText = string.Format(
                "SELECT FirstName FROM FirstNames WHERE id = {0}",  Consts.GameRandom.Next(1,nFirstNamesAmount));
                string strFirstName = (string)cmdCommand.ExecuteScalar();

                // Get Last Name
                cmdCommand.CommandText = string.Format(
                "SELECT LastName FROM LastNames WHERE id = {0}", Consts.GameRandom.Next(1, nLastNamesAmount));
                string strLastName = (string)cmdCommand.ExecuteScalar();

                DateTime dtBDate = new DateTime(DateTime.Now.Year - Consts.GameRandom.Next(18, 30),
                    Consts.GameRandom.Next(1, 12),
                    Consts.GameRandom.Next(1, 28));

                cmdCommand.CommandText = string.Format(
                "INSERT INTO Players(PlayerName, Birth_date, KeeperSkill, DefendingSkill, PlaymakingSkill, WingerSkill, " +
                "PassingSkill, ScoringSkill, SetPiecesSkill, PlayerTeam)" +
                "Values(\"{0} {1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\")",
                strFirstName, strLastName, dtBDate.ToShortDateString(), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), strTeamName);

                cmdCommand.ExecuteNonQuery();
            }
        }

    }
}
