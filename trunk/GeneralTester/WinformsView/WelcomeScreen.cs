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
                LoadTeams();
                leagueTableToolStripMenuItem_Click(sender, e);
            }
        }

        private void LoadTeams()
        {
            foreach (Team team in Game.Teams.Values.Where(T => T.Name != Game.MyTeam.Name))
            {
                toolStripComboBox1.Items.Add(team);
            }
        }

        private void LoadWelcome()
        {
            DataRowCollection drcAllFormations = Game.GetFormations();
            changeFormationToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow drCurrForamtion in drcAllFormations)
            {
                ToolStripMenuItem tsiFormation = new ToolStripMenuItem(drCurrForamtion[0].ToString(), null, new EventHandler(changeFormationToolStripMenuItem_Click));
                if (drCurrForamtion[0].ToString() == Game.MyTeam.Formation)
                {
                    tsiFormation.Checked = true;
                }
                changeFormationToolStripMenuItem.DropDownItems.Add(tsiFormation);
            }

            switch (Game.MyTeam.TeamTrainingType)
            {
                case (Consts.TrainingType.ATTACK):
                    {
                        attackToolStripMenuItem.Checked = true;
                        break;
                    }
                case (Consts.TrainingType.DEFENCE):
                    {
                        defenceToolStripMenuItem.Checked = true;
                        break;
                    }
                case (Consts.TrainingType.WING):
                    {
                        wingsToolStripMenuItem.Checked = true;
                        break;
                    }
                case (Consts.TrainingType.PLAYMAKING):
                    {
                        playMakingToolStripMenuItem.Checked = true;
                        break;
                    }
                case (Consts.TrainingType.SETPIECES):
                    {
                        setPiecesToolStripMenuItem.Checked = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        void changeFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamFormation(Game.MyTeam, ((ToolStripMenuItem)sender).Text);

            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }

            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void ShowLeagueWindow()
        {
            DataView dtvGameLeague = Game.GetLeague();

            LeagueTableDisplay frmLeagueTable = new LeagueTableDisplay(dtvGameLeague);
            frmLeagueTable.MdiParent = this;
            frmLeagueTable.Show();
        }

        private void ShowBuyPlayersWindow()
        {
            BuyPlayer frmBuyPlayer = new BuyPlayer();
            frmBuyPlayer.MdiParent = this;
            frmBuyPlayer.Show();
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
            if (toolStripComboBox1.Text == string.Empty)
            {
                MessageBox.Show("Choose Team");
            }
            else
            {
                GameStory gsStory = Game.MatchTeams(Game.MyTeam.Name, toolStripComboBox1.Text);
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

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void attackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(attackToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            attackToolStripMenuItem.Checked = true;
        }

        private void defenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(defenceToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            defenceToolStripMenuItem.Checked = true;
        }

        private void wingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(wingsToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            wingsToolStripMenuItem.Checked = true;
        }

        private void playMakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(playMakingToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            playMakingToolStripMenuItem.Checked = true;
        }

        private void setPiecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((Consts.TrainingType)(int.Parse(setPiecesToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            setPiecesToolStripMenuItem.Checked = true;
        }

        private void trainTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrainingNums frmNumOfTraining = new TrainingNums();
            frmNumOfTraining.ShowDialog();
        }

        private void trainMyTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.TrainTeam(Game.MyTeam);
            MessageBox.Show("Your team was trained", "Your team was trained", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void playCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Game.LeagueExists)
            {
                if (DialogResult.Yes == MessageBox.Show("Cannot run a cycle" + Environment.NewLine + "There is no league" + Environment.NewLine + "Do you want to create a new league?", "Run cycle", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Game.CreateNewLeague();
                    PlayCycle();
                }
            }
            else
            {
                PlayCycle();
            }
        }

        private void PlayCycle()
        {
            Game.PlayNextCycle();
            MessageBox.Show("A new cycle has been played", "Run Cycle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateForms();
        }

        private void UpdateForms()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is LeagueTableDisplay)
                {
                    LeagueTableDisplay frml = frm as LeagueTableDisplay;
                    frml.UpdateLeagueTable(Game.GetLeague());
                }
                else if (frm is LeagueCyclesScreen)
                {
                    (frm as LeagueCyclesScreen).RefreshCyclesGrid();
                }
            }
        }

        private void leagueCyclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game.LeagueExists)
            {
                OpenLeagueCyclesScreen();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("There is no league" + Environment.NewLine + "Do you want to create a new league?", "Run cycle", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Game.CreateNewLeague();
                    OpenLeagueCyclesScreen();
                }
            }
        }

        private void OpenLeagueCyclesScreen()
        {
            LeagueCyclesScreen frmGameStory = new LeagueCyclesScreen();
            frmGameStory.MdiParent = this;
            frmGameStory.Show();
        }

        private void buyPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBuyPlayersWindow();
        }

        private void teamFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamScreen frmTeam = new TeamScreen();
            frmTeam.MdiParent = this;
            frmTeam.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LeagueCyclesScreen frmMatches = new LeagueCyclesScreen(Game.MyTeam);
            frmMatches.MdiParent = this;
            frmMatches.Show();
        }

        private void cascaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete the current league and start a new one?",
                "Create new league",
                 MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning,
                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Game.Teams.Count % 2 != 0)
                {
                    MessageBox.Show("Cannot create new league" + Environment.NewLine + "There is an odd number of teams", "Create new league", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Game.CreateNewLeague();
                    UpdateForms();
                    MessageBox.Show("New league has been created", "Create new league", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete the current league?",
                "Delete league",
                 MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning,
                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Game.DeleteLeague();
                MessageBox.Show("The league has been deleted", "Delete league", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
