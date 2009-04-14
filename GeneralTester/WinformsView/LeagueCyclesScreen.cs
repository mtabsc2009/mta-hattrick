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

        List<CycleGameFinished> lstGames;

        public LeagueCyclesScreen()
        {
            InitializeComponent();
        }

        private void LeagueCyclesScreen_Load(object sender, EventArgs e)
        {
            DataView dvCycles = Game.GetAllCycles();
            lstGames = Game.CyclesToListFinished(dvCycles);

            dgCycleGames.AutoGenerateColumns = false;
            int nLastCycle = 0;

            foreach (CycleGame cgCurr in lstGames)
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

        private void lstCycles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgCycleGames.Columns[SHOW_GAME_COLUMN].Visible = true;
            dgCycleGames.Columns[3].Visible = true;
            dgCycleGames.Columns[2].Visible = true;

            foreach (CycleGameFinished cgCurr in lstGames.Where(t => t.CycleNum == lstCycles.SelectedIndex + 1))
	        {
                if (cgCurr.CycleDate.Year != 1)
                {
                    GameStory gsNew = Game.GetGameStory(cgCurr.GameID);
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
            if (e.ColumnIndex == SHOW_GAME_COLUMN)
            {
                CycleGame cgCurr = ((CycleGame)dgCycleGames.Rows[e.RowIndex].DataBoundItem);
                if (cgCurr.CycleDate.Year != 1)
                {
                    GameStory gsStory = Game.GetGameStory(cgCurr.GameID);

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
