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
    public partial class ShowMatchesScreen : DefaultForm
    {
        const int SHOW_GAME_COLUMN = 4;

        localhost.CycleGameFinished[] lstGames;
        localhost.Team Team { get; set; }

        public ShowMatchesScreen()
        {
            InitializeComponent();
            Team = null;
        }

        public ShowMatchesScreen(localhost.Team _Team)
            : this()
        {
            Team = _Team;
        }


        private void LeagueCyclesScreen_Load(object sender, EventArgs e)
        {
            RefreshCyclesGrid();
        }


        public void RefreshCyclesGrid()
        {
                lstGames = Game.GetTeamMatches(this.Team);
                dgCycleGames.AutoGenerateColumns = false;
                ShowMatches();
                this.Text = string.Format("{0}'s Matches", Team.Name);
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
                    frmGameStory.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Can't show details - Game has not been played");
                }
                
            }
        }
    }
}
