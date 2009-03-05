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
    }
}
