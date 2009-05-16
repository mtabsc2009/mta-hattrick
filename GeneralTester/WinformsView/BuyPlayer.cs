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
    public partial class BuyPlayer : DefaultForm
    {
        public BuyPlayer()
        {
            InitializeComponent();
        }

        private void BuyPlayer_Load(object sender, EventArgs e)
        {
            DataView dvPlayers = Game.GetPlayerForSell(Game.MyTeam.Name);
            
            dgvPlayers.DataSource = dvPlayers;
            dgvPlayers.Columns["PlayerPos"].Visible = false;
            dgvPlayers.Columns["IsForSale"].Visible = false;
            lblTeamCash.Text = "Your team has " + Game.MyTeam.TeamCash + "$";
        }


        private void dgvPlayers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (e.RowIndex >= 0))
            {
                int nMoneyNeeded;

                if (dgvPlayers[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    dgvPlayers[e.ColumnIndex, e.RowIndex].Value = true;
                    nMoneyNeeded = int.Parse(lblMoney.Text.Substring(0, lblMoney.Text.Length - 1)) + int.Parse(dgvPlayers["PlayerCost", e.RowIndex].Value.ToString());
                }
                else
                {
                    dgvPlayers[e.ColumnIndex, e.RowIndex].Value = (!(bool)(dgvPlayers[e.ColumnIndex, e.RowIndex].Value));
                    if (((bool)dgvPlayers[e.ColumnIndex, e.RowIndex].Value))
                    {
                        nMoneyNeeded = int.Parse(lblMoney.Text.Substring(0, lblMoney.Text.Length - 1)) + int.Parse(dgvPlayers["PlayerCost", e.RowIndex].Value.ToString());
                    }
                    else
                    {
                        nMoneyNeeded = int.Parse(lblMoney.Text.Substring(0, lblMoney.Text.Length - 1)) - int.Parse(dgvPlayers["PlayerCost", e.RowIndex].Value.ToString()); 
                    }
                }
                lblMoney.Text = nMoneyNeeded.ToString() + "$";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Game.MyTeam.TeamCash < int.Parse(lblMoney.Text.Substring(0, lblMoney.Text.Length - 1)))
            {
                MessageBox.Show("You dont have emough money to buy the selected player/s", "Buy players", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int nNumOfPlayersBought = 0;
                for (int nCurrPlayer =0; nCurrPlayer < dgvPlayers.Rows.Count; ++nCurrPlayer)
                {
                    if (dgvPlayers.Rows[nCurrPlayer].Cells["SelectPlayer"].Value != null)
                    {
                        if (((bool)dgvPlayers.Rows[nCurrPlayer].Cells["SelectPlayer"].Value))
                        {
                            nNumOfPlayersBought++;
                            Game.buyPlayer(Game.GetPlayerByID(int.Parse(dgvPlayers.Rows[nCurrPlayer].Cells["PlayerID"].Value.ToString())));
                        }
                    }
                }

                if (nNumOfPlayersBought > 1)
                {
                    MessageBox.Show("Congratulation! you bought " + nNumOfPlayersBought.ToString() + " players", "Buy players", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (nNumOfPlayersBought > 0)
                {
                    MessageBox.Show("Congratulation! you bought one player", "Buy players", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("You didnt selected any player to buy", "Buy players", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
                }
            }
        }
    }
}
