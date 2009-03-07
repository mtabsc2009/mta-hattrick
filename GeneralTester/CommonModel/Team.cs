using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.CommonModel
{
    public class Team
    {
        private List<Player> pPlayers;
        public List<Player> Players
        {
            get { return pPlayers; }
            set { pPlayers = value; }
        }

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

        private string strOwner;
        public string Owner
        {
            get { return strOwner; }
            set { strOwner = value; }
        }

        private DateTime dtCreationDate;
        public DateTime CreationDate
        {
            get { return dtCreationDate; }
            set { dtCreationDate = value; }
        }

        public Team() { }
        public Team(int nTeamID, string strTeamName, DateTime dtCreationDate, List<Player> pPlayers, string strOwner)
        {
            this.ID = nTeamID;
            this.Name = strTeamName;
            this.CreationDate = dtCreationDate;
            this.Owner = strOwner;
            this.Players = pPlayers;
        }
    }
}
