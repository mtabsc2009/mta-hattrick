using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.CommonModel
{
    public class GameStory
    {
        public static int MaxWatchers = 40000;
        public static int MinWatchers = 0;
        public static int MaxEvents = 16;
        public static int MinEvents = 12;

        public GameStory()
        {
            m_dtGameDate = DateTime.Now;
            m_datHomeTeam = new TeamGameData();
            m_datAwayTeam = new TeamGameData();
        }

        private DateTime m_dtGameDate;
        private int m_nWatchers;
        private string m_strWeather;
        private TeamGameData m_datHomeTeam;
        private TeamGameData m_datAwayTeam;
        private int m_nTotalEvents;
        private int m_nHomeTeamEvents;
        private List<GameEvent> m_lstGameEvents = new List<GameEvent>();
        private int m_nHomeScore = 0;
        private int m_nAwayScore = 0;

        public Team Winner
        {
            get
            {
                if (HomeScore < AwayScore) return AwayTeam.Team;
                else if (AwayScore < HomeScore) return HomeTeam.Team;
                else return null;
            }
        }

        public int AwayScore
        {
            get { return m_nAwayScore; }
            set { m_nAwayScore = value; }
        }

        public int HomeScore
        {
            get { return m_nHomeScore; }
            set { m_nHomeScore = value; }
        }

        public List<GameEvent> GameEvents
        {
            get { return m_lstGameEvents; }
        }

        public int TotalEvents
        {
            get { return m_nTotalEvents; }
            set { m_nTotalEvents = value; }
        }

        public int HomeTeamEvents
        {
            get { return m_nHomeTeamEvents; }
            set { m_nHomeTeamEvents = value; }
        }

        public int AwayTeamEvents
        {
            get { return TotalEvents - HomeTeamEvents; } 
        }

        public TeamGameData HomeTeam
        {
            get { return m_datHomeTeam; }
            set { m_datHomeTeam = value; }
        }

        public TeamGameData AwayTeam
        {
            get { return m_datAwayTeam; }
            set { m_datAwayTeam = value; }
        }
        //private TeamFormation m_tfHomeFormation;
        //private TeamFormation m_tfAwayFormation;
        //private bool m_bIsAwayTeamMiddleMethod;
        //private bool m_bIsHomeTeamMiddleMethod;
        //private Team m_tmHomeTeam;
        //private Team m_tmAwayTeam;


        public DateTime GameDate
        {
            get { return m_dtGameDate; }
        }
        public int Watchers
        {
            get { return m_nWatchers; }
            set { m_nWatchers = value; }
        }
        public string Weather
        {
            get { return m_strWeather; }
            set { m_strWeather = value; }
        }
        //public TeamFormation HomeFormation
        //{
        //    get { return m_tfHomeFormation; }
        //    set { m_tfHomeFormation = value; }
        //}
        //public TeamFormation AwayFormation
        //{
        //    get { return m_tfAwayFormation; }
        //    set { m_tfAwayFormation = value; }
        //}
        //public bool IsHomeTeamMiddleMethod
        //{
        //    get { return m_bIsHomeTeamMiddleMethod; }
        //    set { m_bIsHomeTeamMiddleMethod = value; }
        //}
        //public bool IsAwayTeamMiddleMethod
        //{
        //    get { return m_bIsAwayTeamMiddleMethod; }
        //    set { m_bIsAwayTeamMiddleMethod = value; }
        //}
        //public Team HomeTeam
        //{
        //    get { return m_tmHomeTeam; }
        //    set { m_tmHomeTeam = value; }
        //}
        //public Team AwayTeam
        //{
        //    get { return m_tmAwayTeam; }
        //    set { m_tmAwayTeam = value; }
        //}

        public void AddEvent(GameEvent evtMain)
        {
            m_lstGameEvents.Add(evtMain);
        }
    }

    public class TeamGameData
    {
        public Team Team;
        public bool IsTeamMiddleMethod;
        public TeamFormation Formation;
        public int OffenceGrade = 0;
        public int MidFieldGrade = 0;
        public int DefenceGrade = 0;
        public int KeepingGrade = 0;
        public int SetPiecesGrade = 0;
    }
}
