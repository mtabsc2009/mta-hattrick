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
    public partial class WelcomeScreen : DefaultForm
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }
        
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            Hide();
            Entrance frmEntrance = new Entrance();
            DialogResult res = frmEntrance.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                Close();
            }
            else
            {
                Show();
                LoadWelcome();
            }

        }

        private void LoadWelcome()
        {
            ShowLeagueWindow();
        }

        private void ShowLeagueWindow()
        {
            DataView dtvGameLeague = Game.GetLeague();

            LeagueTableDisplay frmLeagueTable = new LeagueTableDisplay(dtvGameLeague);
            frmLeagueTable.MdiParent = this;
            frmLeagueTable.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void friendlyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Game.get
        }

        private void leagueTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLeagueWindow();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (againstToolStripMenuItem.TextBox.Text == string.Empty)
            {
                MessageBox.Show("Enter team name");
            }
            else
            {
                GameStory gsStory = Game.MatchTeams(Game.MyTeam.Name, againstToolStripMenuItem.TextBox.Text);
                if (gsStory == null)
                {
                    MessageBox.Show("No such team");
                }
                else
                {
                    GameStoryDisplay frmGameStory = new GameStoryDisplay(gsStory);
                    frmGameStory.MdiParent = this;
                    frmGameStory.Show();
                }
            }
        }
    }
}
