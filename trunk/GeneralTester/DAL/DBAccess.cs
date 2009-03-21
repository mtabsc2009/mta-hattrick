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
                int teamCash = Convert.ToInt32(drTeam["TeamCash"]);
                return (new Team(drTeam["TeamName"].ToString(), (DateTime)drTeam["AU_CreationDate"], LoadPlayers(drTeam["TeamName"].ToString()), usrCurrentUser.Username, strFormation, teamCash));
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
                int teamCash = Convert.ToInt32(drTeam["TeamCash"].ToString());
                return(new Team(drTeam["TeamName"].ToString(), (DateTime)drTeam["AU_CreationDate"], LoadPlayers(drTeam["TeamName"].ToString()), null, strFormation, teamCash));
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
                    float.Parse(drPlayers["KeeperSkill"].ToString()),
                    float.Parse(drPlayers["DefendingSkill"].ToString()),
                    float.Parse(drPlayers["PlaymakingSkill"].ToString()),
                    float.Parse(drPlayers["WingerSkill"].ToString()),
                    float.Parse(drPlayers["PassingSkill"].ToString()),
                    float.Parse(drPlayers["ScoringSkill"].ToString()),
                    float.Parse(drPlayers["SetPiecesSkill"].ToString()), int.Parse(drPlayers["PlayerPos"].ToString()),
                    Convert.ToInt32(drPlayers["PlayerCost"]),
                    Convert.ToBoolean(drPlayers["IsForSale"]));
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
                    float.Parse(drPlayers["KeeperSkill"].ToString()),
                    float.Parse(drPlayers["DefendingSkill"].ToString()),
                    float.Parse(drPlayers["PlaymakingSkill"].ToString()),
                    float.Parse(drPlayers["WingerSkill"].ToString()),
                    float.Parse(drPlayers["PassingSkill"].ToString()),
                    float.Parse(drPlayers["ScoringSkill"].ToString()),
                    float.Parse(drPlayers["SetPiecesSkill"].ToString()), int.Parse(drPlayers["PlayerPos"].ToString()),
                    Convert.ToInt32(drPlayers["PlayerCost"]),
                    Convert.ToBoolean(drPlayers["IsForSale"]));
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
            "INSERT INTO Teams(TeamName, Owner, AU_CreationDate, TeamPos, TeamCash) Values(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\")", strTeamName, usrCurrentUser.Username, dtCurrDate.ToString(), "4-4-2", 1000000);

            Connect();
            trTrans = m_cnConnection.BeginTransaction();
            cmdCommand.Transaction = trTrans;
            try
            {
                cmdCommand.ExecuteNonQuery();
                CreateNewTeamPlayers(strTeamName, trTrans);

                Team tmMyTeam = new Team(strTeamName, dtCurrDate, LoadPlayers(strTeamName,trTrans), usrCurrentUser.Username,"4-4-2", 1000000);

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
                "PassingSkill, ScoringSkill, SetPiecesSkill, PlayerTeam, PlayerPos, IsForSale, PlayerCost) " +
                "Values(\"{0} {1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\", \"{12}\", \"{13}\")",
                strFirstName, strLastName, dtBDate.ToShortDateString(), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4), Consts.GameRandom.Next(1, 4),
                Consts.GameRandom.Next(1, 4), strTeamName, nCurrPlayer + 1, 0, -1);

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

       public static void UpdateSellPlayer(String playerName, int cost)
       {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("UPDATE players  SET PlayerCost = {1} , IsForSale = \"1\" where PlayerName = \"{0}\"",
                                                       playerName, cost);
                cmdCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
       }
         
       public static void UpdateTransfersPlayer(String playerName, String newTeam)
       {
           OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

           try
           {
               Connect();
               cmdCommand.CommandText = string.Format("UPDATE players  SET PlayerTeam = {1} , IsForSale = \"0\" where PlayerName = \"{0}\"",
                                                      playerName, newTeam);
               cmdCommand.ExecuteNonQuery();
           }
           finally
           {
               Close();
           }
       }

       public static DataView GetNotForSellTeamPlayers(String TeamName)
       {
           OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

           try
           {
               Connect();
               cmdCommand.CommandText = string.Format("SELECT PlayerName From players  where PlayerTeam like \'{0}\' and IsForSale = 0", TeamName);
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


       public static bool CanISellPlayer(string strPlayerName, Team tMyTeam)
       {
           OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
           try
           {
               Connect();
               cmdCommand.CommandText = string.Format("SELECT PlayerName From players  where PlayerTeam like \'{0}\' and PlayerName like \'{1}\'",
                                                      tMyTeam.Name, strPlayerName);
               DataTable dtNew = new DataTable();
               OleDbDataAdapter oldba = new OleDbDataAdapter(cmdCommand);
               oldba.Fill(dtNew);
               return dtNew.Rows.Count == 1;
           }
           finally
           {
               Close();
           }
       }

       public static List<Player> GetPlayersForSale(Team i_Team)
       {
           OleDbCommand cmdCommand = m_cnConnection.CreateCommand();
           List<Player> pPlayers = new List<Player>();

           try
           {
               Connect();

               cmdCommand.CommandText = "SELECT * FROM Players WHERE IsForSale = 1 and PlayerTeam <> '" + i_Team.Name + "'";
               OleDbDataReader drPlayers;

               drPlayers = cmdCommand.ExecuteReader();

               while (drPlayers.Read())
               {
                   Player pCurrPlayer = new Player(int.Parse(drPlayers["PlayerID"].ToString()), drPlayers["PlayerName"].ToString(),
                   Convert.ToDateTime(drPlayers["Birth_date"]),
                   drPlayers["PlayerTeam"].ToString(),
                    float.Parse(drPlayers["KeeperSkill"].ToString()),
                    float.Parse(drPlayers["DefendingSkill"].ToString()),
                    float.Parse(drPlayers["PlaymakingSkill"].ToString()),
                    float.Parse(drPlayers["WingerSkill"].ToString()),
                    float.Parse(drPlayers["PassingSkill"].ToString()),
                    float.Parse(drPlayers["ScoringSkill"].ToString()),
                    float.Parse(drPlayers["SetPiecesSkill"].ToString()), int.Parse(drPlayers["PlayerPos"].ToString()),
                   int.Parse(drPlayers["PlayerCost"].ToString()),
                   Convert.ToBoolean(drPlayers["IsForSale"]));
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

       public static void BuyPlayer(Team tMyTeam, Player playerToBuy)
       {
           OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

           try
           {
               Connect();

               changePlayerTeams(cmdCommand, playerToBuy, tMyTeam);

               decreaseCashForTeamThatBoughtThePlayer(cmdCommand, playerToBuy, tMyTeam);

               payTeamThatSold(cmdCommand, playerToBuy);
           }
           catch(Exception)
           {               
           }
           finally
           {
               Close();
           }
       }

        private static void changePlayerTeams(OleDbCommand cmdCommand, Player playerToBuy, Team tMyTeam)
        {
            cmdCommand.CommandText = string.Format("UPDATE players  SET PlayerTeam = \"{1}\" , IsForSale = \"0\" where PlayerName = \"{0}\"",
                                                   playerToBuy.Name, tMyTeam.Name);
            cmdCommand.ExecuteNonQuery();
        }

        private static void decreaseCashForTeamThatBoughtThePlayer(OleDbCommand cmdCommand, Player playerToBuy, Team tMyTeam)
        {
            cmdCommand.CommandText = string.Format("UPDATE teams  SET TeamCash = \"{0}\" where TeamName = \"{1}\"",
                                                   (tMyTeam.TeamCash - playerToBuy.PlayerCost), tMyTeam.Name);
            cmdCommand.ExecuteNonQuery();
        }

        private static void payTeamThatSold(OleDbCommand cmdCommand, Player playerToBuy)
        {
            cmdCommand.CommandText = string.Format(
                "SELECT * FROM Teams WHERE TeamName = \"{0}\"", playerToBuy.TeamName);
            OleDbDataReader drTeam;
            drTeam = cmdCommand.ExecuteReader();
            drTeam.Read();
            string owner = drTeam["Owner"].ToString();
            string strFormation = drTeam["TeamPos"].ToString();
            int teamCash = Convert.ToInt32(drTeam["TeamCash"]);
            Team teamThatSoldThePlayer = new Team(drTeam["TeamName"].ToString(), (DateTime)drTeam["AU_CreationDate"], LoadPlayers(drTeam["TeamName"].ToString()), owner, strFormation, teamCash);

            drTeam.Close();

            Connect();

            cmdCommand.CommandText = string.Format("UPDATE teams  SET TeamCash = \"{0}\" where TeamName = \"{1}\"",
                                                   (teamThatSoldThePlayer.TeamCash + playerToBuy.PlayerCost), teamThatSoldThePlayer.Name);

            cmdCommand.ExecuteNonQuery();
        }


        public static void ChangeTeamTrainingType(Team tmToChange)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                cmdCommand.CommandText = string.Format("UPDATE teams SET teamtrainingType = {0} WHERE teamname = \"{1}\"", ((int)tmToChange.TeamTrainingType), tmToChange.Name);
                cmdCommand.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }

        public static void SaveTeamSkills(Team tmTeamToTrain)
        {
            OleDbCommand cmdCommand = m_cnConnection.CreateCommand();

            try
            {
                Connect();
                foreach (Player plrCurr in tmTeamToTrain.Players)
                {
                    cmdCommand.CommandText = string.Format(
                        "UPDATE players SET " +
                        "KeeperSkill = {1}, " +
                        "DefendingSkill = {2}, PlaymakingSkill = {3}, WingerSkill = {4}, PassingSkill = {5}, ScoringSkill = {6}, SetPiecesSkill = {7} " +
                        "WHERE players.PlayerID = {0}", plrCurr.ID,
                        plrCurr.KeeperVal,
                        plrCurr.DefendingVal,
                        plrCurr.PlaymakingVal,
                        plrCurr.WingerVal,
                        plrCurr.PassingVal,
                        plrCurr.ScoringVal,
                        plrCurr.SetPiecesVal);
                    cmdCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                Close();
            }
        }
    
    }
}
