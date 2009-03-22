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

        private float paKeeperVal;
        public float KeeperVal
        {
            get { return paKeeperVal; }
            set { paKeeperVal = value; }
        }

        private float paDefendingVal;
        public float DefendingVal
        {
            get { return paDefendingVal; }
            set { paDefendingVal = value; }
        }
        
        private float paPlaymakingVal;
        public float PlaymakingVal
        {
            get { return paPlaymakingVal; }
            set { paPlaymakingVal = value; }
        }
        
        private float paWingerVal;
        public float WingerVal
        {
            get { return paWingerVal; }
            set { paWingerVal = value; }
        }
        
        private float paPassingVal;
        public float PassingVal
        {
            get { return paPassingVal; }
            set { paPassingVal = value; }
        }

        private float paScoringVal;
        public float ScoringVal
        {
            get { return paScoringVal; }
            set { paScoringVal = value; }
        }
        
        private float paSetPiecesVal;
        public float SetPiecesVal
        {
            get { return paSetPiecesVal; }
            set { paSetPiecesVal = value; }
        }
        public int WholeSetPiecesVal 
        {
            get { return (int)SetPiecesVal; }
        }

        private int nPosition;
        public int Position
        {
            get { return nPosition; }
            set { nPosition = value; }
        }

        public int? PlayerCost { get; set; }
        public bool IsForSale { get; set; }

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
                        float paKeeperVal,
                        float paDefendingVal,
                        float paPlaymakingVal,
                        float paWingerVal,
                        float paPassingVal,
                        float paScoringVal,
                        float paSetPiecesVal,
                        int nPlayerPosition,
                        int? playerCost,
                        bool isForSale)
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
            PlayerCost = playerCost;
            IsForSale = isForSale;

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

        public override string ToString()
        {
            string ans = "";
            ans += "ID:   " + ID + "\n";
            ans += "Name: " + Name + "\n";
            ans += "Age:  " + Age + "\n";
            ans += "Position:  " + Position + "\n";

            if (IsForSale)
            {
                ans += "Player is for sale at Cost: " + PlayerCost + "\n";
            }

            ans += "Skills:   " + "\n";
            ans += "Keeping:    ";
            for (int nSkill = 0; nSkill < (int)KeeperVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";

            ans += "Defending:  ";
            for (int nSkill = 0; nSkill < (int)DefendingVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "Playmaking: ";
            for (int nSkill = 0; nSkill < (int)PlaymakingVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "Winger:     ";
            for (int nSkill = 0; nSkill < (int)WingerVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "Passing:    ";
            for (int nSkill = 0; nSkill < (int)PassingVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "Scoring:    ";
            for (int nSkill = 0; nSkill < (int)ScoringVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "SetPieces:  ";
            for (int nSkill = 0; nSkill < (int)SetPiecesVal; ++nSkill)
            {
                ans += "*";
            }

            ans += "\n";
            ans += "\n";
            ans += "\n";

            return ans;
        }
    }
}
