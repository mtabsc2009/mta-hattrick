using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.CommonModel
{
    [SerializableAttribute]
    public class Player
    {
        private int nID;
        public int ID
        {
            get { return nID; }
            set { nID = value; }
        }

        private string strName;
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        private int nAge;
        public int Age
        {
            get { return nAge; }
            set { nAge = value; }
        }

        private string strTeamName;
        public string TeamName
        {
            get { return strTeamName; }
            set { strTeamName = value; }
        }

        private Consts.PlayerAbilities paKeeperVal;
        public Consts.PlayerAbilities KeeperVal
        {
            get { return paKeeperVal; }
            set { paKeeperVal = value; }
        }

        private Consts.PlayerAbilities paDefendingVal;
        public Consts.PlayerAbilities DefendingVal
        {
            get { return paDefendingVal; }
            set { paDefendingVal = value; }
        }
        
        private Consts.PlayerAbilities paPlaymakingVal;
        public Consts.PlayerAbilities PlaymakingVal
        {
            get { return paPlaymakingVal; }
            set { paPlaymakingVal = value; }
        }
        
        private Consts.PlayerAbilities paWingerVal;
        public Consts.PlayerAbilities WingerVal
        {
            get { return paWingerVal; }
            set { paWingerVal = value; }
        }
        
        private Consts.PlayerAbilities paPassingVal;
        public Consts.PlayerAbilities PassingVal
        {
            get { return paPassingVal; }
            set { paPassingVal = value; }
        }

        private Consts.PlayerAbilities paScoringVal;
        public Consts.PlayerAbilities ScoringVal
        {
            get { return paScoringVal; }
            set { paScoringVal = value; }
        }
        
        private Consts.PlayerAbilities paSetPiecesVal;
        public Consts.PlayerAbilities SetPiecesVal
        {
            get { return paSetPiecesVal; }
            set { paSetPiecesVal = value; }
        }

        private int nPosition;
        public int Position
        {
            get { return nPosition; }
            set { nPosition = value; }
        }


        /// <summary>
        /// Empty - to create a new player
        /// </summary>
        public Player()
        {
        }

        /// <summary>
        /// Loading an exsisting player
        /// </summary>
        /// <param name="nPlayerID"></param>
        public Player(int nPlayerID, string strPlayerName, DateTime dtBDate, string strTeamName,
                        Consts.PlayerAbilities paKeeperVal,
                        Consts.PlayerAbilities paDefendingVal,
                        Consts.PlayerAbilities paPlaymakingVal,
                        Consts.PlayerAbilities paWingerVal,
                        Consts.PlayerAbilities paPassingVal,
                        Consts.PlayerAbilities paScoringVal,
                        Consts.PlayerAbilities paSetPiecesVal,
                        int nPlayerPosition)
        {
            this.ID = nPlayerID;
            this.Name = strPlayerName;
            this.TeamName = strTeamName;
            this.KeeperVal = paKeeperVal;
            this.DefendingVal = paDefendingVal;
            this.PlaymakingVal = paPlaymakingVal;
            this.WingerVal = paWingerVal;
            this.PassingVal = paPassingVal;
            this.ScoringVal = paScoringVal;
            this.SetPiecesVal = paSetPiecesVal;
            this.Position = nPlayerPosition;

            DateTime comparisonDate = new DateTime(dtBDate.Year, DateTime.Now.Month, DateTime.Now.Day);

            // Get Years diff
            this.Age = (comparisonDate.Date < dtBDate.Date) ?
            DateTime.Now.Year - dtBDate.Year - 1 :
            DateTime.Now.Year - dtBDate.Year;

           /* // Calculate the age
            DateTime comparisonDate = new DateTime(dtBDate.Year, DateTime.Now.Month, DateTime.Now.Day);
            int nTempAge;

            // Get Years diff
            nTempAge = (comparisonDate.Date < dtBDate.Date) ?
            DateTime.Now.Year - dtBDate.Year - 1 :
            DateTime.Now.Year - dtBDate.Year;

            // Get months from years diff
            nTempAge *= 12;
            
            // Add months diff 4 calculation
            int nMonthsDiff;
            nMonthsDiff = DateTime.Now.Month - dtBDate.Month;
            if (nMonthsDiff < 0)
            {
                nMonthsDiff += 12;
            }

            nTempAge += nMonthsDiff;

            // Each year is realty equals to 3 years in the game
            this.Age = nTempAge / 4;*/
        }
    }
}
