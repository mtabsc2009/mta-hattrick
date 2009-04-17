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
    public partial class TeamScreen : DefaultForm
    {
        PlayerSkills frmPlayerSkills;
        public Team Team { get; set; }
        private bool bIsMyTeam
        {
            get
            {
                return (Team.Name == Game.MyTeam.Name);
            }
        }

        public TeamScreen()
        {
            InitializeComponent();
            this.Team = Game.MyTeam;
            frmPlayerSkills = new PlayerSkills();
            frmPlayerSkills.MdiParent = this.MdiParent;
            frmPlayerSkills.IsMyTeam = bIsMyTeam;
            
        }

        public TeamScreen(Team tmTeam) : this()
        {
            Team = tmTeam;
            frmPlayerSkills.IsMyTeam = bIsMyTeam;
        }

        private void TeamScreen_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}'s Team Management", Team.Name);
            this.SetPlayersName();

            // Setting formation types
            DataRowCollection drcAllFormations = Game.GetFormations();
            List<string> lFormations = new List<string>();


            foreach (DataRow drCurrForamtion in drcAllFormations)
            {
                lFormations.Add(drCurrForamtion[0].ToString());
            }
            cmbFormation.Items.Clear();
            cmbFormation.DataSource = lFormations;

            cmbFormation.SelectedItem = Team.Formation;
            cmbTraining.SelectedIndex = ((int)Team.TeamTrainingType) - 1;
            SetFormationView();
            RefreshSubs();

            bool IsMyTeam = bIsMyTeam;
            if (!IsMyTeam)
            {
                cmbFormation.Enabled = false;
                cmbTraining.Enabled = false;
                lstPlayers.AllowDrop = false;
                foreach (Control ctlCurr in panel1.Controls)
                {
                    if (ctlCurr is Button)
                    {
                        Button btnCurr = ctlCurr as Button;
                        btnCurr.AllowDrop = false;
                    }
                }
            }
        }

        private void RefreshSubs()
        {
            BindingList<Player> l = new BindingList<Player>(Team.Players.Where(T => T.Position > 11).ToList<Player>());
            lstPlayers.DataSource = l;
            lstPlayers.DisplayMember = "Name";
        }

        private void SetPlayersName()
        {
            foreach (Control ctlCurr in panel1.Controls)
            {
                if (ctlCurr is Button)
                {
                    Button btnCurr = ctlCurr as Button;

                    int nPos = Convert.ToInt32(btnCurr.Tag);
                    Player plrCurr = Team.Players.Where(T => T.Position == nPos).First();
                    btnCurr.Tag = plrCurr;
                    btnCurr.Text = plrCurr.Name;
                }
            }
            //this.btnPlayer1.Text = Team.Players[0].Name;
            //this.btnPlayer2.Text = Team.Players[1].Name;
            //this.btnPlayer3.Text = Team.Players[2].Name;
            //this.btnPlayer4.Text = Team.Players[3].Name;
            //this.btnPlayer5.Text = Team.Players[4].Name;
            //this.btnPlayer6.Text = Team.Players[5].Name;
            //this.btnPlayer7.Text = Team.Players[6].Name;
            //this.btnPlayer8.Text = Team.Players[7].Name;
            //this.btnPlayer9.Text = Team.Players[8].Name;
            //this.btnPlayer10.Text = Team.Players[9].Name;
            //this.btnPlayer11.Text = Team.Players[10].Name;

            //this.btnPlayer1.Tag = Team.Players[0];
            //this.btnPlayer2.Tag = Team.Players[1];
            //this.btnPlayer3.Tag = Team.Players[2];
            //this.btnPlayer4.Tag = Team.Players[3];
            //this.btnPlayer5.Tag = Team.Players[4];
            //this.btnPlayer6.Tag = Team.Players[5];
            //this.btnPlayer7.Tag = Team.Players[6];
            //this.btnPlayer8.Tag = Team.Players[7];
            //this.btnPlayer9.Tag = Team.Players[8];
            //this.btnPlayer10.Tag = Team.Players[9];
            //this.btnPlayer11.Tag = Team.Players[10];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void cmbFormation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetFormationView();
            Game.ChangeTeamFormation(Team, cmbFormation.SelectedItem.ToString());
        }

        private void SetFormationView()
        {
            switch (cmbFormation.SelectedItem.ToString())
            {
                case "4-4-2":
                    {
                        btnPlayer2.Location = new Point(41, 70);
                        btnPlayer3.Location = new Point(217, 70);
                        btnPlayer4.Location = new Point(401, 70);
                        btnPlayer5.Location = new Point(586, 70);
                        btnPlayer6.Location = new Point(41, 185);
                        btnPlayer7.Location = new Point(217, 185);
                        btnPlayer8.Location = new Point(401, 185);
                        btnPlayer9.Location = new Point(586, 185);
                        btnPlayer10.Location = new Point(138, 306);
                        btnPlayer11.Location = new Point(469, 306);
                        break;
                    }
                case "5-3-2":
                    {
                        btnPlayer2.Location = new Point(3, 70);
                        btnPlayer3.Location = new Point(160, 70);
                        btnPlayer4.Location = new Point(321, 70);
                        btnPlayer5.Location = new Point(479, 70);
                        btnPlayer6.Location = new Point(632, 70);
                        btnPlayer7.Location = new Point(138, 191);
                        btnPlayer8.Location = new Point(321, 191);
                        btnPlayer9.Location = new Point(499, 191);
                        btnPlayer10.Location = new Point(231, 300);
                        btnPlayer11.Location = new Point(409, 300);
                        break;
                    }
                case "5-4-1":
                    {
                        btnPlayer2.Location = new Point(3, 70);
                        btnPlayer3.Location = new Point(160, 70);
                        btnPlayer4.Location = new Point(321, 70);
                        btnPlayer5.Location = new Point(479, 70);
                        btnPlayer6.Location = new Point(632, 70);
                        btnPlayer7.Location = new Point(41, 191);
                        btnPlayer8.Location = new Point(217, 191);
                        btnPlayer9.Location = new Point(401, 191);
                        btnPlayer10.Location = new Point(586, 191);
                        btnPlayer11.Location = new Point(321, 300);
                        break;
                    }
                case "4-3-3":
                    {
                        btnPlayer2.Location = new Point(41, 70);
                        btnPlayer3.Location = new Point(217, 70);
                        btnPlayer4.Location = new Point(401, 70);
                        btnPlayer5.Location = new Point(586, 70);
                        btnPlayer6.Location = new Point(136, 191);
                        btnPlayer7.Location = new Point(312, 191);
                        btnPlayer8.Location = new Point(499, 191);
                        btnPlayer9.Location = new Point(138, 300);
                        btnPlayer10.Location = new Point(316, 300);
                        btnPlayer11.Location = new Point(499, 300);
                        break;
                    }
                case "4-5-1":
                    {
                        btnPlayer2.Location = new Point(41, 70);
                        btnPlayer3.Location = new Point(217, 70);
                        btnPlayer4.Location = new Point(401, 70);
                        btnPlayer5.Location = new Point(586, 70);
                        btnPlayer6.Location = new Point(3, 191);
                        btnPlayer7.Location = new Point(160, 191);
                        btnPlayer8.Location = new Point(321, 191);
                        btnPlayer9.Location = new Point(479, 191);
                        btnPlayer10.Location = new Point(632, 191);
                        btnPlayer11.Location = new Point(321, 300);
                        break;
                    }
                case "3-5-2":
                    {
                        btnPlayer2.Location = new Point(138, 70);
                        btnPlayer3.Location = new Point(321, 70);
                        btnPlayer4.Location = new Point(499, 70);
                        btnPlayer5.Location = new Point(3, 191);
                        btnPlayer6.Location = new Point(160, 191);
                        btnPlayer7.Location = new Point(321, 191);
                        btnPlayer8.Location = new Point(479, 191);
                        btnPlayer9.Location = new Point(632, 191);
                        btnPlayer10.Location = new Point(231, 300);
                        btnPlayer11.Location = new Point(409, 300);
                        break;
                    }
                case "3-4-3":
                    {
                        btnPlayer2.Location = new Point(138, 70);
                        btnPlayer3.Location = new Point(321, 70);
                        btnPlayer4.Location = new Point(499, 70);
                        btnPlayer5.Location = new Point(41, 191);
                        btnPlayer6.Location = new Point(217, 191);
                        btnPlayer7.Location = new Point(401, 191);
                        btnPlayer8.Location = new Point(586, 191);
                        btnPlayer9.Location = new Point(138, 300);
                        btnPlayer10.Location = new Point(316, 300);
                        btnPlayer11.Location = new Point(499, 300);
                        break;
                    }
            }
        }

        private void btnPlayer_MouseHover(object sender, EventArgs e)
        {
            int offest = -4;
            Button bPlayer = sender as Button;
            frmPlayerSkills.Player = Team.Players.Where(T => T.Name == bPlayer.Text).First();
            Point p = this.PointToScreen(bPlayer.Location);
            frmPlayerSkills.Location = new Point(p.X + bPlayer.Width + offest, p.Y + bPlayer.Height + offest);
            frmPlayerSkills.Show();
        }

        private void btnPlayer_MouseLeave(object sender, EventArgs e)
        {
            frmPlayerSkills.Hide();
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int offest = -4;
            Player bPlayer = lstPlayers.SelectedItem as Player;
            frmPlayerSkills.Player = Team.Players.Where(T => T.Name == bPlayer.Name).First();
            Point p = panel3.PointToScreen(lstPlayers.Location);
            frmPlayerSkills.Location = new Point(p.X - frmPlayerSkills.Width + offest, p.Y + offest);
            frmPlayerSkills.Show();
            frmPlayerSkills.BringToFront();
        }

        private void btnPlayer1_DragDrop(object sender, DragEventArgs e)
        {
            Button btnTo = sender as Button;
            Button btnFrom = e.Data.GetData(typeof(Button)) as Button;
            string strTo = btnTo.Text;
            Player plrTo = btnTo.Tag as Player;
            Player plrFrom = btnFrom.Tag as Player;
            int nPosTo = plrTo.Position;
            bool bFromSubs = (plrFrom.Position > 11);

            plrTo.Position = plrFrom.Position;
            btnTo.Text = btnFrom.Text;
            btnTo.Tag = btnFrom.Tag;

            plrFrom.Position = nPosTo;
            btnFrom.Text = strTo;
            btnFrom.Tag = plrTo;

            Game.ChangePlayerPosition(plrTo, plrFrom);

            if (bFromSubs)
            {
                RefreshSubs();
            }
        }

        private void btnPlayer4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button b = sender as Button;
                b.DoDragDrop(b, DragDropEffects.Link);
            }
        }

        private void btnPlayer1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void lstPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Player plr = lstPlayers.SelectedItem as Player;
                Button b = new Button();
                b.Text = plr.Name;
                b.Tag = plr;
                lstPlayers.DoDragDrop(b, DragDropEffects.Link);
                lstPlayers_SelectedIndexChanged(sender, e);
            }
        }

        private void cmbTraining_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int nTrainingType = cmbTraining.SelectedIndex + 1;
            Game.ChangeTeamTrainngType(((Consts.TrainingType)(nTrainingType)));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
