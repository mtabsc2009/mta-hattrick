using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HatTrick.CommonModel;
using System.Collections;

namespace HatTrick.Views.WinformsView
{
    public partial class LeagueCyclesScreen : DefaultForm
    {
        const int SHOW_GAME_COLUMN = 4;

        localhost.CycleGameFinished[] lstGames;
        localhost.Team Team { get; set; }

        public LeagueCyclesScreen()
        {
            InitializeComponent();
            Team = null;
        }

        public LeagueCyclesScreen(localhost.Team _Team) : this()
        {
            Team = _Team;
        }


        private void LeagueCyclesScreen_Load(object sender, EventArgs e)
        {
            RefreshCyclesGrid();
        }


        public void RefreshCyclesGrid()
        {
            if (Team != null)
            {
                groupBox1.Hide();
                groupBox2.Dock = DockStyle.Fill;
                lstGames = Game.GetTeamMatches(this.Team);
                dgCycleGames.AutoGenerateColumns = false;
                ShowMatches();
                this.Text = string.Format("{0}'s Matches", Team.Name);
            }
            else
            {
                DataView dvCycles = Game.GetAllCycles().DefaultView;
                lstGames = Game.CyclesToListFinished(dvCycles.Table);

                dgCycleGames.AutoGenerateColumns = false;
                int nLastCycle = 0;
                lstCycles.Items.Clear();
                foreach (localhost.CycleGame cgCurr in lstGames)
                {
                    if (nLastCycle != cgCurr.CycleNum)
                    {
                        nLastCycle = cgCurr.CycleNum;
                        string strDate = cgCurr.CycleDate.ToShortDateString();

                        if (cgCurr.CycleDate.Year == 1)
                        {
                            strDate = "Not Played";
                        }
                        lstCycles.Items.Add(cgCurr.CycleNum.ToString() + " :\t " + strDate);
                    }
                }
            }
        }

        private void ShowMatches()
        {
            dgCycleGames.Columns[SHOW_GAME_COLUMN].Visible = true;
            dgCycleGames.Columns[3].Visible = true;
            dgCycleGames.Columns[2].Visible = true;
            DataGridViewColumn c = new DataGridViewColumn();
            c.HeaderText = "Date";
            c.Name = "Date";
            c.DataPropertyName = "CycleDate";
            c.Resizable = DataGridViewTriState.True;
            c.Frozen = true;
            c.CellTemplate = dgCycleGames.Columns[1].CellTemplate;
            dgCycleGames.Columns.Insert(0, c);

            DataGridViewColumn d = new DataGridViewColumn();
            d.HeaderText = "Cycle";
            d.Name = "Cycle";
            d.DataPropertyName = "CycleNum";
            d.Resizable = DataGridViewTriState.True;
            d.Frozen = true;
            d.CellTemplate = dgCycleGames.Columns[1].CellTemplate;
            d.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgCycleGames.Columns.Insert(0, d);

            foreach (localhost.CycleGameFinished cgCurr in lstGames)
            {
                if (cgCurr.CycleDate.Year != 1)
                {
                    localhost.GameStory gsNew = Game.GetGameStory(cgCurr.GameID);
                    cgCurr.AwayScore = gsNew.AwayScore;
                    cgCurr.HomeScore = gsNew.HomeScore;
                }
            }

            dgCycleGames.DataSource = lstGames.Where(T => T.CycleDate.Year != 1).ToArray();
        }

        private void lstCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgCycleGames.Columns[SHOW_GAME_COLUMN].Visible = true;
            dgCycleGames.Columns[3].Visible = true;
            dgCycleGames.Columns[2].Visible = true;

            foreach (localhost.CycleGameFinished cgCurr in lstGames.Where(t => t.CycleNum == lstCycles.SelectedIndex + 1))
	        {
                if (cgCurr.CycleDate.Year != 1)
                {
                    localhost.GameStory gsNew = Game.GetGameStory(cgCurr.GameID);
                    cgCurr.AwayScore = gsNew.AwayScore;
                    cgCurr.HomeScore = gsNew.HomeScore;
                }
                else
                {
                    dgCycleGames.Columns[3].Visible = false;
                    dgCycleGames.Columns[2].Visible = false;
                    dgCycleGames.Columns[SHOW_GAME_COLUMN].Visible = false;
                }
	        }

            dgCycleGames.DataSource = lstGames.Where(t => t.CycleNum == lstCycles.SelectedIndex + 1).ToArray();
            
        }

        private void dgCycleGames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgCycleGames.Columns["ShowGame"].Index)
            {
                localhost.CycleGameFinished cgCurr = ((localhost.CycleGameFinished)dgCycleGames.Rows[e.RowIndex].DataBoundItem);
                //CycleGame cgCurr = ((CycleGame)dgCycleGames.Rows[e.RowIndex].DataBoundItem);
                if (cgCurr.CycleDate.Year != 1)
                {
                    localhost.GameStory gsStory = Game.GetGameStory(cgCurr.GameID);

                    GameStoryDisplay frmGameStory = new GameStoryDisplay(gsStory);
                    frmGameStory.MdiParent = this.MdiParent;
                    frmGameStory.Show();
                }
                else
                {
                    MessageBox.Show("Can't show details - Game has not been played");
                }
                
            }
        }
    }
}
