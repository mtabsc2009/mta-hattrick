using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.CommonModel
{
    [SerializableAttribute]
    public class CycleGame
    {
        private int nCycleNum;
        private string strHomeTeam;
        private string strAwayTeam;
        private int nGameID;
        private DateTime dtCycleDate;

        public CycleGame()
        {
        }

        public CycleGame(int nCNum, string strHome, string strAway, int nGmId, DateTime dtCycle)
        {
            CycleNum = nCNum;
            HomeTeam = strHome;
            AwayTeam = strAway;
            GameID = nGmId;
            CycleDate = dtCycle;

        }

        public CycleGame(int nCNum, string strHome, string strAway)
        {
            CycleNum = nCNum;
            HomeTeam = strHome;
            AwayTeam = strAway;
            GameID = -1;
        }

        public int CycleNum
        {
            get { return nCycleNum; }
            set { nCycleNum = value; }
        }

        public string HomeTeam
        {
            get { return strHomeTeam; }
            set { strHomeTeam = value; }
        }

        public string AwayTeam
        {
            get { return strAwayTeam; }
            set { strAwayTeam = value; }
        }

        public int GameID
        {
            get { return nGameID; }
            set { nGameID = value; }
        }

        public DateTime CycleDate
        {
            get { return dtCycleDate; }
            set { dtCycleDate = value; }
        }


    }

    public class CycleGameFinished : CycleGame
    {
        private int nHomeScore;

        public int HomeScore
        {
            get { return nHomeScore; }
            set { nHomeScore = value; }
        }

        private int nAwayScore;

        public int AwayScore
        {
            get { return nAwayScore; }
            set { nAwayScore = value; }
        }

        public CycleGameFinished()
        {

        }

        public CycleGameFinished(int nCNum, string strHome, string strAway, int nGmId, DateTime dtCycle)
        {
            CycleNum = nCNum;
            HomeTeam = strHome;
            AwayTeam = strAway;
            GameID = nGmId;
            CycleDate = dtCycle;

        }

        public CycleGameFinished(int nCNum, string strHome, string strAway)
        {
            CycleNum = nCNum;
            HomeTeam = strHome;
            AwayTeam = strAway;
            GameID = -1;
        }
    }
}
