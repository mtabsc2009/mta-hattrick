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
using System.Xml;

namespace HatTrick.Views.WinformsView
{
    public partial class WelcomeScreen : DefaultForm
    {
        private static Game m_Game;
        private static localhost.Team m_Team;

        private Dictionary<string, string> m_FirstTimeHelp = new Dictionary<string, string>();
        private FirstTimeTooTipForm m_FirstTimeTooTipForm;

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

        private void loadFirstTimeHelp()
        {
            XmlTextReader textReader = new XmlTextReader("./ScreensHelpText.xml");
            skipTags(textReader, 3);

            switch (textReader.NodeType)
                {
                case XmlNodeType.Element: 

                    skipTags(textReader, 1);

                    while (textReader.Read())
                    {
                        string screen = textReader.Name;

                        skipTags(textReader, 3);

                        string help = textReader.Value;

                        m_FirstTimeHelp.Add(screen, help);

                        skipTags(textReader, 4);
                    }

                    break;
            }
        }

        private void skipTags(XmlTextReader i_TextReader, int m_NumberOfTagsToSkip)
        {
            for (int i = 0; i < m_NumberOfTagsToSkip; i++)
            {
                i_TextReader.Read();
            }
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            loadFirstTimeHelp();

            m_FirstTimeTooTipForm = new FirstTimeTooTipForm();
            m_FirstTimeTooTipForm.TopLevel = false;
            m_FirstTimeTooTipForm.Parent = this;

            //if (GoLogin())
            //{
            //    m_Team = m_Game.getTeam();
            //    LoadTeams();
            //    //leagueTableToolStripMenuItem_Click(sender, e);
            //    //teamFormationToolStripMenuItem_Click(sender, e);
            //}

            //showFirstTimeHelpScreen();
        }

        //private void LoadTeams()
        //{
        //    foreach (HatTrick.Views.WinformsView.localhost.Team team in Game.getTeams().Where(T => T.Name != Game.getTeam().Name))
        //    {
        //        toolStripComboBox1.Items.Add(team.Name);
        //    }
        //}

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

        private void showFirstTimeHelpScreen()
        {
            DefaultForm f = new DefaultForm();
            f.MdiParent = this;
            Label l = new Label();
            f.Size = splitContainer1.Panel2.Size;
            l.Size = splitContainer1.Panel2.Size;
            l.Font = new Font("Arial", 20);
            l.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.BackColor = Color.Transparent;
            l.Text = "זהו מסך הפתיחה הראשוני";
            f.Controls.Add(l);
            changeScreens(f);
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
                    frmGameStory.ShowDialog();
                }
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoLogin();
        }

        private bool GoLogin()
        {
            //Hide();
            Entrance frmEntrance = new Entrance();
            DialogResult res = frmEntrance.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                Close();
                return false;
            }
            else
            {
                //Show();
                LoadWelcome();
                m_Team = m_Game.getTeam();
                //LoadTeams();
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

        //private void initializeScreenSliderTimer()
        //{
        //    timer2.Tick += clearScreen_Tick;
        //    timer2.Interval = 25;
        //}

        //void clearScreen_Tick(object sender, EventArgs e)
        //{
        //    if (m_ShowingForm.Location.X + m_ShowingForm.Width > m_OriginalPos.X)
        //    {
        //        m_ShowingForm.Location = new Point(m_ShowingForm.Location.X - (int)(m_ShowingForm.Width * (timer2.Interval / 1000.0)), m_ShowingForm.Location.Y);
        //    }
        //    else
        //    {
        //        timer2.Stop();
        //        m_IsSliding = false;
        //        splitContainer1.Panel2.Controls.Remove(m_ShowingForm);
        //        m_ShowingForm.Close();
        //        m_ShowingForm = null;
        //    }                
        //}


        private DefaultForm m_ShowingForm = null;

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (m_SlidingInForm.Location.X > m_OriginalPos.X)
        //    {
        //        if (m_ShowingForm == null)
        //        {
        //            m_SlidingInForm.Location = new Point(m_SlidingInForm.Location.X - (int)(m_SlidingInForm.Width * (timer1.Interval / 1000.0)), m_SlidingInForm.Location.Y);
        //        }
        //        else
        //        {
        //            m_SlidingInForm.Location = new Point(m_SlidingInForm.Location.X - (int)(m_SlidingInForm.Width * (timer1.Interval / 1000.0)), m_SlidingInForm.Location.Y);
        //            m_ShowingForm.Location = new Point(m_ShowingForm.Location.X - (int)(m_SlidingInForm.Width * (timer1.Interval / 1000.0)), m_ShowingForm.Location.Y);
        //        }
        //    }
        //    else
        //    {
        //        timer1.Stop();
        //        m_IsSliding = false;
        //        m_SlidingInForm.Location = m_OriginalPos;
        //        splitContainer1.Panel2.Controls.Remove(m_ShowingForm);
        //        m_ShowingForm = m_SlidingInForm;
        //        m_SlidingInForm = null;
        //    }
        //}

        private bool canShowForm(Type i_Type)
        {
            if (m_ShowingForm == null)
            {
                return true;
            }

            if (i_Type != m_ShowingForm.GetType())
            {
                return true;
            }

            return false;
        }

        private  void changeScreens(DefaultForm i_FormToInsert)
        {
            m_ShowingForm = i_FormToInsert;
            m_ShowingForm.FormBorderStyle = FormBorderStyle.None;
            m_ShowingForm.Size = splitContainer1.Panel2.Size;
            m_ShowingForm.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(m_ShowingForm);
            m_ShowingForm.Show();
        }

        //private void changeScreens(DefaultForm i_FormToInsert)
        //{
        //    m_IsSliding = true;
        //    m_OriginalPos = Point.Empty;
        //    m_SlidingInForm = i_FormToInsert;
        //    m_SlidingInForm.Size = splitContainer1.Panel2.Size;
        //    i_FormToInsert.Dock = DockStyle.Fill;
        //    m_SlidingInForm.Location = new Point(splitContainer1.Panel2.Width, splitContainer1.Panel2.Location.Y);
        //    timer1.Interval = 25;
        //    splitContainer1.Panel2.Controls.Add(i_FormToInsert);
        //    i_FormToInsert.FormBorderStyle = FormBorderStyle.None;
        //    i_FormToInsert.Show();
        //    timer1.Start();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(TeamScreen)))
            {
                TeamScreen frmTeam = new TeamScreen();
                frmTeam.MdiParent = this;
                changeScreens(frmTeam);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(BuyPlayer)))
            {
                BuyPlayer frmBuyPlayer = new BuyPlayer();
                frmBuyPlayer.MdiParent = this;
                changeScreens(frmBuyPlayer);                    
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(ShowMatchesScreen)))
            {
                ShowMatchesScreen frmMatches = new ShowMatchesScreen(Game.getTeam());
                frmMatches.MdiParent = this;
                changeScreens(frmMatches);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            playCycleToolStripMenuItem_Click(sender, e);
            clearScreen();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataView dtvGameLeague = Game.GetLeague().DefaultView;

            if (canShowForm(typeof(LeagueTableDisplay)))
            {
                LeagueTableDisplay frmLeagueTable = new LeagueTableDisplay(dtvGameLeague);
                frmLeagueTable.MdiParent = this;
                changeScreens(frmLeagueTable);                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Game.getLeagueExists())
            {
                if (canShowForm(typeof(LeagueCyclesScreen)))
                {
                    LeagueCyclesScreen frmGameStory = new LeagueCyclesScreen();
                    frmGameStory.MdiParent = this;
                    changeScreens(frmGameStory);
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("There is no league" + Environment.NewLine + "Do you want to create a new league?", "Run cycle", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (canShowForm(typeof(LeagueCyclesScreen)))
                    {
                        Game.CreateNewLeague();
                        LeagueCyclesScreen frmGameStory = new LeagueCyclesScreen();
                        frmGameStory.MdiParent = this;
                        changeScreens(frmGameStory);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FriendlyMatchScreen fms = new FriendlyMatchScreen();
            fms.ShowDialog();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (showTipsToolStripMenuItem.Checked)
            {
                Button b = sender as Button;
                if (b.Tag != null)
                {
                    if (m_FirstTimeHelp.ContainsKey(b.Tag.ToString()))
                    {
                        m_FirstTimeTooTipForm.m_Label.Text = m_FirstTimeHelp[b.Tag.ToString()];
                        m_FirstTimeTooTipForm.Location = b.Location + new Size(b.Width + 5, 0);
                        m_FirstTimeTooTipForm.BringToFront();
                        m_FirstTimeTooTipForm.Visible = true;                        
                    }                    
                }
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (showTipsToolStripMenuItem.Checked)
            {
                m_FirstTimeTooTipForm.Visible = false;
            }
        }

        private void clearScreen()
        {
            if (m_ShowingForm != null)
            {
                m_ShowingForm.Close();
                splitContainer1.Panel2.Controls.Remove(m_ShowingForm);
                m_ShowingForm = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!LogedIn())
            {
                GoLogin();
                ActivateButtons();
                pictureBox1.Visible = false;
                (sender as Button).Text = "התנתק";
                (sender as Button).Tag = "Logoff";
            }
            else
            {
                DeActivateButtons();
                pictureBox1.Visible = true;
                (sender as Button).Tag = "Login";
                (sender as Button).Text = "התחבר";
            }

        }

        private void DeActivateButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private bool LogedIn()
        {
            return button1.Enabled;
        }

        private void ActivateButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
