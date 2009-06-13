using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MtaAddIn.localhost;
using System.Diagnostics;
using HatTrick;
using System.Xml;


namespace MtaAddIn
{
    public partial class GameBord : UserControl
    {
        private static Game m_Game = new Game();
        private static localhost.Team m_Team;
        private Dictionary<string, string> m_FirstTimeHelp = new Dictionary<string, string>();
        private HatTrick.Views.WinformsView.FirstTimeTooTipForm m_FirstTimeTooTipForm;
       // private DefaultForm m_ShowingForm = null;
        private System.Windows.Forms.ErrorProvider errorProvider1 = new System.Windows.Forms.ErrorProvider();
        public GameBord()
        {
            InitializeComponent();
            System.Net.CookieContainer cookies = new System.Net.CookieContainer();

            m_Game = new Game();
            m_Game.CookieContainer = cookies;  
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!LogedIn())
            {
                GoLogin();
                ActivateButtons();
                (sender as Button).Text = "התנתק";
                (sender as Button).Tag = "Logoff";
            }
            else
            {
                DeActivateButtons();
                (sender as Button).Tag = "Login";
                (sender as Button).Text = "התחבר";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        public static localhost.Team Team
        {
            get
            {
                return m_Team;
            }
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

            //m_FirstTimeTooTipForm = new FirstTimeTooTipForm();
            //m_FirstTimeTooTipForm.TopLevel = false;
            //m_FirstTimeTooTipForm.Parent = this;

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
         
            localhost.Team t = Game.getTeam();
            //localhost.Team t1 = Game.MyTeam();
            
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
                       
                        break;
                    }
                case (localhost.TrainingType.DEFENCE):
                    {
                        break;
                    }
                case (localhost.TrainingType.WING):
                    {
                     
                        break;
                    }
                case (localhost.TrainingType.PLAYMAKING):
                    {
                       
                        break;
                    }
                case (localhost.TrainingType.SETPIECES):
                    {
                      
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
            /*Default/**/
            Form f = new /*Default*/Form();
            f.MdiParent = null;//this;
            Label l = new Label();
            // f.Size = splitContainer1.Panel2.Size;
            //l.Size = splitContainer1.Panel2.Size;
            l.Font = new Font("Arial", 20);
            l.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.BackColor = Color.Transparent;
            l.Text = "זהו מסך הפתיחה הראשוני";
            f.Controls.Add(l);
            //    changeScreens(f);
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

       //     LeagueTableDisplay frmLeagueTable = new LeagueTableDisplay(dtvGameLeague);
       //     frmLeagueTable.MdiParent = null;//this;
       //     frmLeagueTable.Show();
        }

        private void ShowBuyPlayersWindow()
        {
       //     BuyPlayer frmBuyPlayer = new BuyPlayer();
       //     frmBuyPlayer.MdiParent = null;//this;
        //    frmBuyPlayer.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void friendlyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Game.get
        }

        private void leagueTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLeagueWindow();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoLogin();
        }

        private bool GoLogin()
        {

            Log_In();
            LoadWelcome();
            return true;
           /*
            if (res == DialogResult.Cancel)
            {
                //Close();
                return false;
            }
            else
            {
                //Show();
               
                //LoadTeams();
                return true;
            }*/
        }

        private void UpdateForms()
        {
            /*foreach (Form frm in this.MdiChildren)
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
            }*/
        }

        private void leagueCyclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game.getLeagueExists())
            {
               // OpenLeagueCyclesScreen();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("There is no league" + Environment.NewLine + "Do you want to create a new league?", "Run cycle", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    Game.CreateNewLeague();
                   // OpenLeagueCyclesScreen();
                }
            }
        }

       /* private void OpenLeagueCyclesScreen()
        {
            LeagueCyclesScreen frmGameStory = new LeagueCyclesScreen();
            frmGameStory.MdiParent = null;//this;
            frmGameStory.Show();
        }*/

        private void buyPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBuyPlayersWindow();
        }

       

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // LeagueCyclesScreen frmMatches = new LeagueCyclesScreen(HattrickGameService.Game.getTeam());
            // frmMatches.MdiParent = null;//this;
            // frmMatches.Show();
        }

        private void cascaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // foreach (Form frm in this.MdiChildren)
            {
                //    frm.Close();
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
                /* if (Game.getTeams().Length % 2 != 0)
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
                 }*/
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

        

        

    /*    private void changeScreens(DefaultForm i_FormToInsert)
        {
            m_ShowingForm = i_FormToInsert;
            m_ShowingForm.FormBorderStyle = FormBorderStyle.None;
            // m_ShowingForm.Size = splitContainer1.Panel2.Size;
            m_ShowingForm.Dock = DockStyle.Fill;
            //splitContainer1.Panel2.Controls.Clear();
            // splitContainer1.Panel2.Controls.Add(m_ShowingForm);
            m_ShowingForm.Show();
        }*/

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

       /* private void button1_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(TeamScreen)))
            {
                TeamScreen frmTeam = new TeamScreen();
                frmTeam.MdiParent = null;//this;
                //   changeScreens(frmTeam);
            }
        }*/

       /* private void button2_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(BuyPlayer)))
            {
                BuyPlayer frmBuyPlayer = new BuyPlayer();
                frmBuyPlayer.MdiParent = null;//this;
                //    changeScreens(frmBuyPlayer);                    
            }
        }*/

      /* private void button5_Click(object sender, EventArgs e)
        {
            if (canShowForm(typeof(ShowMatchesScreen)))
            {
                //  ShowMatchesScreen frmMatches = new ShowMatchesScreen(Game.getTeam());
                //  frmMatches.MdiParent = null;//this;
                //changeScreens(frmMatches);
            }
        }*/

    /*  private void button9_Click(object sender, EventArgs e)
        {
            if (Game.getLeagueExists())
            {
                if (canShowForm(typeof(LeagueCyclesScreen)))
                {
                    LeagueCyclesScreen frmGameStory = new LeagueCyclesScreen();
                    frmGameStory.MdiParent = null;//this;
                    //  changeScreens(frmGameStory);
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
                        frmGameStory.MdiParent = null;//this;
                        //   changeScreens(frmGameStory);
                    }
                }
            }
        }*/

        /*private void button8_Click(object sender, EventArgs e)
        {
            FriendlyMatchScreen fms = new FriendlyMatchScreen();
            fms.ShowDialog();
        }*/

      /*  private void button1_MouseEnter(object sender, EventArgs e)
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
        }*/

      

       

        private void DeActivateButtons()
        {
            button6.Enabled = false;
            button7.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private bool LogedIn()
        {
            return button1.Enabled;
        }

        private void ActivateButtons()
        {
           
            button6.Enabled = true;
            button7.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
        private void Log_In()
        {
            if (txtUsername.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsername, "Username must not be empty");
            }
            else
            {
                errorProvider1.Clear();
                if (txtPassword.Text == string.Empty)
                {
                    errorProvider1.SetError(txtPassword, "Password must not be empty");
                }
                else if (txtTeamName.Visible)
                {
                    if (txtTeamName.Text == string.Empty)
                    {
                        errorProvider1.SetError(txtTeamName, "Team name must not be empty");
                    }
                    else if (Game.UserExists(txtUsername.Text))
                    {
                        errorProvider1.SetError(txtUsername, "Username already exists");
                    }
                    else if (Game.TeamExists(txtTeamName.Text))
                    {
                        errorProvider1.SetError(txtTeamName, "Team name already exists");
                    }
                    else if (!Game.CreateUser(txtUsername.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Unknwon error occured creating your account", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (!CheckLogin(txtUsername.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Unknwon error occured in login", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (Game.CreateTeam(txtTeamName.Text) == null)
                    {
                        MessageBox.Show("Unknwon error occured creating your team", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        PerformLogin();
                    }
                }
                else
                {
                    PerformLogin();
                }
            }
        }

        private bool CheckLogin(string strUsername, string strPassword)
        {
            return (Game.Login(strUsername, strPassword) != null);
        }

        private void PerformLogin()
        {
            if (!CheckLogin(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
              //  this.DialogResult = DialogResult.OK;
            }
        }
        private void dataGridView1_DataBindingComplete()
        {
            try
            {
                dataGridView1.SuspendLayout();
                if (dataGridView1.DataSource is DataView)
                {
                    DataView dtvSource = dataGridView1.DataSource as DataView;
                    foreach (DataGridViewColumn currcol in dataGridView1.Columns)
                    {
                        if (dtvSource.Table.Columns.Contains(currcol.Name))
                        {
                            if (currcol.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
                            {
                                currcol.Visible = false;
                            }
                            else
                            {
                                currcol.DataPropertyName = currcol.Name;
                                currcol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                        else if (currcol.Name != "position")
                        {
                            currcol.Visible = false;
                        }
                    }

                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = this.BackColor;
                    dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridView1.Rows[0].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);

                    foreach (DataGridViewRow currrow in dataGridView1.Rows)
                    {
                        currrow.Cells["position"].Value = currrow.Index + 1;
                        if ((currrow.DataBoundItem as DataRowView)["teamname"].ToString() == Game.getTeam().Name)
                        {
                            try
                            {
                                foreach (DataGridViewCell cell in currrow.Cells)
                                {
                                    cell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold | FontStyle.Italic);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    this.Height = dataGridView1.RowTemplate.Height * dataGridView1.DisplayedRowCount(false) + this.Height + dataGridView1.ColumnHeadersHeight + 40;
                    dataGridView1.ResumeLayout();

                }
            }
            catch
            {
            }

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            DataView dtvGameLeague = Game.GetLeague().DefaultView;
            dataGridView1.DataSource = dtvGameLeague;
            dataGridView1_DataBindingComplete();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TrainingNums tNums = new TrainingNums(m_Game);
            tNums.Show();
        }

        private void PlayCycle()
        {
            Game.PlayNextCycle();
            MessageBox.Show("A new cycle has been played", "Run Cycle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateForms();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            PlayCycle();
            button10_Click_1(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Game.TrainTeam(Game.getTeam());
            MessageBox.Show("Your team was trained", "Your team was trained", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
