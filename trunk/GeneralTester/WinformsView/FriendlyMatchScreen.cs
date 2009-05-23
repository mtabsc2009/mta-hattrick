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
    public partial class FriendlyMatchScreen : DefaultForm
    {
        public FriendlyMatchScreen()
        {
            InitializeComponent();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Team");
            }
            else
            {
                HatTrick.Views.WinformsView.localhost.GameStory gsStory = Game.MatchTeams(Game.getTeam().Name, listBox1.Items[listBox1.SelectedIndex].ToString());
                if (gsStory == null)
                {
                    MessageBox.Show("No such team");
                }
                else
                {
                    GameStoryDisplay frmGameStory = new GameStoryDisplay(gsStory);
                    frmGameStory.ShowDialog();
                }

                Close(); 
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrainingNums_Load(object sender, EventArgs e)
        {
            loadTeams();

            listBox1.Focus();
        }

        private void loadTeams()
        {
            foreach (HatTrick.Views.WinformsView.localhost.Team team in Game.getTeams().Where(T => T.Name != Game.getTeam().Name))
            {
                listBox1.Items.Add(team.Name);
            }
        }
    }
}
