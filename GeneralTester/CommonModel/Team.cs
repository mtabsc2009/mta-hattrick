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
        public Team(string strTeamName, DateTime dtCreationDate, List<Player> pPlayers, string strOwner)
        {
            this.Name = strTeamName;
            this.CreationDate = dtCreationDate;
            this.Owner = strOwner;
            this.Players = pPlayers;
        }
    }
}
