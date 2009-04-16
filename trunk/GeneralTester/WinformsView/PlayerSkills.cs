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
    public partial class PlayerSkills : DefaultForm
    {
        private Player m_Player;
        private string InitialCost { get; set; }
        public bool IsMyTeam { get; set; }

        public Player Player
        {
            get { return m_Player; }
            set
            {
                if (m_Player != null)
                {
                    SavePlayer();
                }
                m_Player = value;
                InitSkills();
            }
        }

        public PlayerSkills()
        {
            InitializeComponent();
        }

        private void InitSkills()
        {
            lblName.Text = Player.Name;
            lblAge.Text = Player.Age.ToString();
            pbKeeper.Value = (int)Player.KeeperVal;
            pbDefending.Value = (int)Player.DefendingVal;
            pbPlayMaking.Value = (int)Player.PlaymakingVal;
            pbWinger.Value = (int)Player.WingerVal;
            pbPassing.Value = (int)Player.PassingVal;
            pbScoring.Value = (int)Player.ScoringVal;
            pbSetPices.Value = (int)Player.SetPiecesVal;
            chkIsForSale.Checked = Player.IsForSale;
            txtPrice.Text = Player.IsForSale ? Player.PlayerCost.ToString() : string.Empty;
            InitialCost = txtPrice.Text;
        }

        private void chkIsForSale_CheckedChanged(object sender, EventArgs e)
        {
            txtPrice.Enabled = chkIsForSale.Checked;
            if (!txtPrice.Enabled)
            {
                txtPrice.Text = string.Empty;
            }
        }

        private void PlayerSkills_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavePlayer();
        }

        private void SavePlayer()
        {
            if (InitialCost != txtPrice.Text)
            {
                if (chkIsForSale.Checked)
                {
                    int a;
                    if (int.TryParse(txtPrice.Text, out a))
                    {
                        Player.PlayerCost = int.Parse(txtPrice.Text);
                        Game.UpdateSellPlayer(Player.ID.ToString(), int.Parse(txtPrice.Text));
                    }
                }
                else
                {
                    Game.UpdateSellPlayer(Player.ID.ToString(), -1);
                }
                Player.IsForSale = chkIsForSale.Checked;
                InitialCost = txtPrice.Text;
            }
        }

        private void PlayerSkills_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                SavePlayer();
            }
        }

        private void PlayerSkills_Load(object sender, EventArgs e)
        {
            chkIsForSale.Enabled = IsMyTeam;
            txtPrice.Enabled = IsMyTeam && chkIsForSale.Checked;
        }
    }
}
