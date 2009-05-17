using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HatTrick.CommonModel;
using System.Diagnostics;
using HatTrick.Views.WinformsView.localhost;

namespace HatTrick.Views.WinformsView
{
    public partial class WelcomeScreen : DefaultForm
    {
        private static Game m_Game;
        private static localhost.Team m_Team;
        static WelcomeScreen()
        {
            System.Net.CookieContainer cookies = new System.Net.CookieContainer();

            m_Game = new Game();
            m_Game.CookieContainer = cookies;
        }
        public static localhost.Team Team 
        {
            get
            {
                return m_Team;
            }
        }
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        public static Game Game
        {
            get
            {
                return m_Game;
            }
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            if (GoLogin())
            {
                m_Team = m_Game.getTeam();
                LoadTeams();
                leagueTableToolStripMenuItem_Click(sender, e);
                teamFormationToolStripMenuItem_Click(sender, e);
            }
        }

        private void LoadTeams()
        {
            foreach (HatTrick.Views.WinformsView.localhost.Team team in Game.getTeams().Where(T => T.Name != Game.getTeam().Name))
            {
                toolStripComboBox1.Items.Add(team.Name);
            }
        }

        private void LoadWelcome()
        {
            DataTable drcAllFormations = Game.GetFormations();
            changeFormationToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow drCurrForamtion in drcAllFormations.Rows)
            {
                ToolStripMenuItem tsiFormation = new ToolStripMenuItem(drCurrForamtion[0].ToString(), null, new EventHandler(changeFormationToolStripMenuItem_Click));
                localhost.Team team = Game.getTeam();
                if (drCurrForamtion[0].ToString() == team.Formation)
                {
                    tsiFormation.Checked = true;
                }
                changeFormationToolStripMenuItem.DropDownItems.Add(tsiFormation);
            }

            localhost.Team t = Game.getTeam();
            if (!Game.getIsUserInLeague())
            {
                DialogResult dr = MessageBox.Show(
                    "You'r team is not part of the current league" + Environment.NewLine +
                    "Would you like to create a new league?",
                    "Welcome",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    resetToolStripMenuItem_Click(this, new EventArgs());
                }
            }

            switch (((localhost.TrainingType)(Game.getTeam().TeamTrainingType)))
            {
                case (localhost.TrainingType.ATTACK):
                    {
                        attackToolStripMenuItem.Checked = true;
                        break;
                    }
                case (localhost.TrainingType.DEFENCE):
                    {
                        defenceToolStripMenuItem.Checked = true;
                        break;
                    }
                case (localhost.TrainingType.WING):
                    {
                        wingsToolStripMenuItem.Checked = true;
                        break;
                    }
                case (localhost.TrainingType.PLAYMAKING):
                    {
                        playMakingToolStripMenuItem.Checked = true;
                        break;
                    }
                case (localhost.TrainingType.SETPIECES):
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
            Game.ChangeTeamFormation(Game.getTeam(), ((ToolStripMenuItem)sender).Text);

            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }

            ((ToolStripMenuItem)sender).Checked = true;
        }

        private void ShowLeagueWindow()
        {
            DataView dtvGameLeague = Game.GetLeague().DefaultView;

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
                HatTrick.Views.WinformsView.localhost.GameStory gsStory = Game.MatchTeams(Game.getTeam().Name, toolStripComboBox1.Text);
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
            GoLogin();
        }

        private bool GoLogin()
        {
            Hide();
            Entrance frmEntrance = new Entrance();
            DialogResult res = frmEntrance.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                Close();
                return false;
            }
            else
            {
                Show();
                LoadWelcome();
                return true;
            }
        }

        private void attackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((localhost.TrainingType)(int.Parse(attackToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            attackToolStripMenuItem.Checked = true;
        }

        private void defenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((localhost.TrainingType)(int.Parse(defenceToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            defenceToolStripMenuItem.Checked = true;
        }

        private void wingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((localhost.TrainingType)(int.Parse(wingsToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            wingsToolStripMenuItem.Checked = true;
        }

        private void playMakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((localhost.TrainingType)(int.Parse(playMakingToolStripMenuItem.Tag.ToString())));
            foreach (ToolStripMenuItem tsi in ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems)
            {
                tsi.Checked = false;
            }
            playMakingToolStripMenuItem.Checked = true;
        }

        private void setPiecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.ChangeTeamTrainngType((localhost.TrainingType)(int.Parse(setPiecesToolStripMenuItem.Tag.ToString())));
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
            Game.TrainTeam(Game.getTeam());
            MessageBox.Show("Your team was trained", "Your team was trained", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void playCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Game.getLeagueExists())
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
                    frml.UpdateLeagueTable(Game.GetLeague().DefaultView);
                }
                else if (frm is LeagueCyclesScreen)
                {
                    (frm as LeagueCyclesScreen).RefreshCyclesGrid();
                }
            }
        }

        private void leagueCyclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game.getLeagueExists())
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
            LeagueCyclesScreen frmMatches = new LeagueCyclesScreen(Game.getTeam());
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
                if (Game.getTeams().Length % 2 != 0)
                {
                    string strBaseMessage = "Cannot create new league" + Environment.NewLine + "There is an odd number of teams";
                    string strAddition;
                    string strMessage;

                    bool bComputerTeamExists = Game.DoesComputerTeamExist();
                    if (bComputerTeamExists)
                    {
                        strAddition = "There is a computer-dummy team, would you like to delete it and create the new league?";
                    }
                    else
                    {
                        strAddition = "Would you like to create a new computer-dummy team and create the new league?";
                    }
                    strMessage = strBaseMessage + Environment.NewLine + strAddition;
                    DialogResult dr = MessageBox.Show(strMessage, "Create new league", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (bComputerTeamExists)
                        {
                            Game.DeleteComputerTeam();
                        }
                        else
                        {
                            Game.CreateComputerTeam();
                        }

                        CreateEmptyLeague();
                    }
                }
                else
                {
                    CreateEmptyLeague();
                }
            }
        }

        private void CreateEmptyLeague()
        {
            Game.CreateNewLeague();
            UpdateForms();
            MessageBox.Show("New league has been created", "Create new league", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GettingStartedForm gs = new GettingStartedForm();
                gs.Show();
            }
            catch
            {
                MessageBox.Show("Cannot find Getting Started file", "Getting Started", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
