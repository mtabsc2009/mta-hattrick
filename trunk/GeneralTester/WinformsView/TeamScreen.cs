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
    public partial class TeamScreen : Form
    {
        public Team Team { get; set; }
        public TeamScreen()
        {
            InitializeComponent();
            Team = null;
        }

        public TeamScreen(Team tmTeam) : this()
        {
            Team = tmTeam;
        }

        private void TeamScreen_Load(object sender, EventArgs e)
        {
            this.Text = Team.Name;
        }

    }
}
