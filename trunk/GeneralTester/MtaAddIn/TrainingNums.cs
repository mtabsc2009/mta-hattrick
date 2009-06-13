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

namespace MtaAddIn
{
    public partial class TrainingNums : Form
    {
        private static Game m_Game = null;
        public TrainingNums(Game game)
        {
            m_Game = game;
            InitializeComponent();
        }
       
        private void TrainingNums_Load(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
        }

        private void btnTrain_Click_1(object sender, EventArgs e)
        {
            m_Game.TrainAllTeams(int.Parse(numericUpDown1.Value.ToString()));
            MessageBox.Show(String.Format("All teams were trained {0} times", numericUpDown1.Value.ToString()), "All teams were trained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
