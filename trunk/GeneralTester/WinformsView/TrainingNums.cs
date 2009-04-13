using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HatTrick.Views.WinformsView
{
    public partial class TrainingNums : DefaultForm
    {
        public TrainingNums()
        {
            InitializeComponent();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            Game.TrainAllTeams(int.Parse(numericUpDown1.Value.ToString()));
            MessageBox.Show(String.Format("All teams were trained {0} times", numericUpDown1.Value.ToString()), "All teams were trained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrainingNums_Load(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
        }
    }
}
