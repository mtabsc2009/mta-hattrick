using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HatTrick.CommonModel;

namespace HatTrick.Views.WinformsView
{
    public partial class MatchesScreen : Form
    {
        public Team Team { get; set; }
        public int CycleNo { get; set; }

        public MatchesScreen()
        {
            InitializeComponent();
            Team = null;
            CycleNo = -1;
        }

        public MatchesScreen(int nCycleNo) :  this()
        {
            CycleNo = nCycleNo;
        }

        public MatchesScreen(Team tmTeam) : this()
        {
            Team = tmTeam;
        }
    }
}
