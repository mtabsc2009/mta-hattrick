﻿using System;
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

        private string strFormation;
        private TeamFormation m_tfTeamFormation;
        public string Formation
        {
            get { return strFormation; }
            set 
            { 
                strFormation = value;
                if (strFormation != string.Empty)
                {
                    m_tfTeamFormation = new TeamFormation(value);
                }
            }
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
        public Team(string strTeamName, DateTime dtCreationDate, List<Player> pPlayers, string strOwner, string strNewFor)
        {
            this.Name = strTeamName;
            this.CreationDate = dtCreationDate;
            this.Owner = strOwner;
            this.Players = pPlayers;
            this.strFormation = strNewFor;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }

    public class TeamFormation
    {
        public int Defence;
        public int MiddleField;
        public int Offence;

        public TeamFormation(string strFormation)
        {
            try
            {
                string[] strFormations = strFormation.Split('-');
                Defence = int.Parse(strFormations[0]);
                MiddleField = int.Parse(strFormations[1]);
                Offence = int.Parse(strFormations[2]);
            }
            catch
            {
                Defence = 4;
                MiddleField = 4;
                Offence = 2;

            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Defence, MiddleField, Offence);
        }
    }
}
