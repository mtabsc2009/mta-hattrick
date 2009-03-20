using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.OleDb;
using HatTrick.CommonModel;
using System.Data;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.IO;

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
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            Connect();
            try
            {
                cmdCommand.CommandText = string.Format(
                "SELECT * FROM Teams WHERE Owner = \"{0}\"", usrCurrentUser.Username);
                OleDbDataReader drTeam;
                drTeam = cmdCommand.ExecuteReader();
                drTeam.Read();
                string strFormation = drTeam["TeamPos"].ToString();
                return (new Team(drTeam["TeamName"].ToString(), (DateTime)drTeam["AU_CreationDate"], LoadPlayers(drTeam["TeamName"].ToString()), usrCurrentUser.Username, strFormation));
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
        }


        public static Team LoadTeam(string strTeamName)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            Connect();
            try
            {
                cmdCommand.CommandText = string.Format(
                "SELECT * FROM Teams WHERE TeamName = \"{0}\"", strTeamName);
                OleDbDataReader drTeam;
                drTeam = cmdCommand.ExecuteReader();
                drTeam.Read();
                string strFormation = drTeam["TeamPos"].ToString();
                return(new Team(drTeam["TeamName"].ToString(), (DateTime)drTeam["AU_CreationDate"], LoadPlayers(drTeam["TeamName"].ToString()), null, strFormation));
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
        }



        private static List<Player> LoadPlayers(string strTeamName)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            List<Player> pPlayers = new List<Player>();

            try
            {
                cmdCommand.CommandText = string.Format(
                "SELECT * FROM Players WHERE PlayerTeam = \"{0}\"", strTeamName);
                Connect();
                OleDbDataReader drPlayers; 
                    
                drPlayers = cmdCommand.ExecuteReader();
                
                while (drPlayers.Read())
                {
                    Player pCurrPlayer = new Player(int.Parse(drPlayers["PlayerID"].ToString()), drPlayers["PlayerName"].ToString(),
                    Convert.ToDateTime(drPlayers["Birth_date"].ToString()),
                    strTeamName,
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["KeeperSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["DefendingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["PlaymakingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["WingerSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["PassingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["ScoringSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["SetPiecesSkill"].ToString())))), int.Parse(drPlayers["PlayerPos"].ToString()));
                    pPlayers.Add(pCurrPlayer);
                }
                return (pPlayers);
                
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }            
        }

        private static List<Player> LoadPlayers(string strTeamName, OleDbTransaction trTrans)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            List<Player> pPlayers = new List<Player>();
            
            try
            {
                Connect();
                cmdCommand.Transaction = trTrans;
                cmdCommand.CommandText = string.Format(
                "SELECT * FROM Players WHERE PlayerTeam = \"{0}\"", strTeamName);
                OleDbDataReader drPlayers;

                drPlayers = cmdCommand.ExecuteReader();

                while (drPlayers.Read())
                {
                    Player pCurrPlayer = new Player(int.Parse(drPlayers["PlayerID"].ToString()), drPlayers["PlayerName"].ToString(),
                    Convert.ToDateTime(drPlayers["Birth_date"]),
                    strTeamName,
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["KeeperSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["DefendingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["PlaymakingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["WingerSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["PassingSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["ScoringSkill"].ToString())))),
                    ((Consts.PlayerAbilities)Enum.Parse(typeof(Consts.PlayerAbilities), Enum.GetName(typeof(Consts.PlayerAbilities), int.Parse(drPlayers["SetPiecesSkill"].ToString())))),int.Parse(drPlayers["PlayerPos"].ToString()));
                    pPlayers.Add(pCurrPlayer);

                }
                return (pPlayers);

            }
            catch
            {
                return null;
            }
        }

        public static Team CreateTeam(User usrCurrentUser, string strTeamName)
        {
            OleDbTransaction trTrans;
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
            DateTime dtCurrDate = DateTime.Now;
            cmdCommand.CommandText = string.Format(
            "INSERT INTO Teams(TeamName, Owner, AU_CreationDate, TeamPos) Values(\"{0}\", \"{1}\", \"{2}\", \"{3}\")", strTeamName, usrCurrentUser.Username, dtCurrDate.ToString(), "4-4-2");

            Connect();
            trTrans = m_cnConnection.BeginTransaction();
            cmdCommand.Transaction = trTrans;
            try
            {
                cmdCommand.ExecuteNonQuery();
                CreateNewTeamPlayers(strTeamName, trTrans);

                Team tmMyTeam = new Team(strTeamName, dtCurrDate, LoadPlayers(strTeamName,trTrans), usrCurrentUser.Username,"4-4-2");

                trTrans.Commit();
                return tmMyTeam;
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
                "INSERT INTO Players " +
                "(PlayerName, Birth_date, KeeperSkill, DefendingSkill, PlaymakingSkill, WingerSkill, " +
                "PassingSkill, ScoringSkill, SetPiecesSkill, PlayerTeam, PlayerPos) " +
                "Values(\"{0} {1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\")",
                strFirstName, strLastName, dtBDate.ToShortDateString(), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), strTeamName, nCurrPlayer + 1);

                cmdCommand.ExecuteNonQuery();
            }
        }

        public static void UpdatePlayerPosition(Player plrToUpdate)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("UPDATE players SET PlayerPos = {0} WHERE players.PlayerID = {1}", plrToUpdate.Position, plrToUpdate.ID);
                cmdCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }

        public static bool DoesTeamExist(string strTeamName)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT count(*) from teams where teamname = \"{0}\"", strTeamName);
                int nCount = int.Parse(cmdCommand.ExecuteScalar().ToString());

                return (nCount == 1);
            }
            finally
            {
                Close();
            }
        }

        public static DataRowCollection GetFormations()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT PosDisplay from positions");
                DataTable dtNew = new DataTable();
                OleDbDataAdapter oldba = new OleDbDataAdapter(cmdCommand);
                oldba.Fill(dtNew);

                return dtNew.Rows;
            }
            finally
            {
                Close();
            }
        }

        public static void ChangeTeamFormation(Team tmToChange, string strNewFormation)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("UPDATE teams SET teampos = \"{0}\" WHERE teamname = \"{1}\"", strNewFormation, tmToChange.Name);
                cmdCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }

        }

        public static int SaveStoryToDB(GameStory gsNewGame)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            System.IO.MemoryStream msEvents = new System.IO.MemoryStream(10000);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(msEvents, gsNewGame);
            byte[] bt =  msEvents.GetBuffer();

            cmdCommand.CommandText = string.Format("INSERT INTO games (HOMETEAM,AwayTeam,gamedate,homescore,awayscore,gamestory) values (\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\")", gsNewGame.HomeTeam.Team.Name, gsNewGame.AwayTeam.Team.Name, gsNewGame.GameDate.ToString(), gsNewGame.HomeScore, gsNewGame.AwayScore, Convert.ToBase64String(bt));



            try
            {
                Connect();

                cmdCommand.ExecuteNonQuery();
                cmdCommand.CommandText = "SELECT MAX(ID) FROM games";

                return (int)cmdCommand.ExecuteScalar();
            }
            finally
            {
                Close();
            }
        }

        public static GameStory LoadGameStory(int nStoryID)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            cmdCommand.CommandText = string.Format("SELECT * from games  where id = {0}", nStoryID);

            try
            {
                Connect();

                GameStory gsToReturn = new GameStory();

                DataTable dtNew = new DataTable();
                OleDbDataAdapter oldba = new OleDbDataAdapter(cmdCommand);
                oldba.Fill(dtNew);

                byte[] bt = Convert.FromBase64String(dtNew.Rows[0]["GameStory"].ToString());
                
                System.IO.MemoryStream msEvents2 = new System.IO.MemoryStream(bt);

                BinaryFormatter bf = new BinaryFormatter();
                gsToReturn = (GameStory)bf.Deserialize(msEvents2);

                return gsToReturn;

            }
            finally
            {
                Close();
            }
        }

        public static int GetTeamCount()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();

                cmdCommand.CommandText = "SELECT count(*) FROM teams";

                return (int)cmdCommand.ExecuteScalar();
            }
            finally
            {
                Close();
            }
        }

        public static DataView GetAllTeams()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT * from teams");
                DataTable dtNew = new DataTable();
                OleDbDataAdapter oldba = new OleDbDataAdapter(cmdCommand);
                oldba.Fill(dtNew);

                return dtNew.DefaultView;
            }
            finally
            {
                Close();
            }
        }

        public static void SaveCycleToDB(ArrayList alCurrCycle)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();

                for (int nCurr = 0; nCurr < alCurrCycle.Count; nCurr++)
                {
                    cmdCommand.CommandText = string.Format("INSERT into cycles (CYCLENUM, HomeTeam, AwayTeam) VALUES (\"{0}\", \"{1}\", \"{2}\")", 
                                                          ((CycleGame)alCurrCycle[nCurr]).CycleNum, ((CycleGame)alCurrCycle[nCurr]).HomeTeam, ((CycleGame)alCurrCycle[nCurr]).AwayTeam);
                    cmdCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                Close();
            }
        }

        public static bool CheckShouldCreateNewLeague()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT count(*) from cycles where gameid is null");
                return ((int)cmdCommand.ExecuteScalar() == 0);
            }
            finally
            {
                Close();
            }
        }

        public static int GetNumOfCycles()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT count(*) from cycles");
                return ((int)cmdCommand.ExecuteScalar());
            }
            finally
            {
                Close();
            }
        }

        public static int ClearAllCycles()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("Delete from cycles");
                return ((int)cmdCommand.ExecuteNonQuery());
            }
            finally
            {
                Close();
            }
        }

        public static DataView GetAllCycles()
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("SELECT * from cycles");
                DataTable dtNew = new DataTable();
                OleDbDataAdapter oldba = new OleDbDataAdapter(cmdCommand);
                oldba.Fill(dtNew);

                return dtNew.DefaultView;
            }
            finally
            {
                Close();
            }
        }

        public static void UpdateCycleData(CycleGame gmCurr)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();

                cmdCommand.CommandText = string.Format("UPDATE cycles  SET gameid = {2} , cycledate = \"{3}\" where cyclenum = \"{0}\" AND homeTeam = \"{1}\"",
                                                       gmCurr.CycleNum, gmCurr.HomeTeam, gmCurr.GameID, gmCurr.CycleDate.ToString());
                                                      
                cmdCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }
    }
}
