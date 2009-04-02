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
    public partial class GameStoryDisplay : DefaultForm
    {
        public GameStory GameStory { get; set; }
        private StringBuilder strBuilder = new StringBuilder();
        public GameStoryDisplay()
        {
            InitializeComponent();
        }

        public GameStoryDisplay(GameStory gsStory)
        {
            InitializeComponent();
            GameStory = gsStory;
        }

        private void GameStoryDisplay_Load(object sender, EventArgs e)
        {
            PrintGameStory();
        }

        private void AddLine(string strFormat, params object[] args)
        {
            AddLine(string.Format(strFormat, args));
        }
        private void AddLine()
        {
            AddLine(string.Empty);
        }
        private void AddLine(string strLine)
        {
            strBuilder.AppendLine(strLine);
        }

        private void PrintGameStory()
        {
            GameStory gsGameStory = GameStory;
            strBuilder = new StringBuilder();

            AddLine("Game Summary");
            AddLine("=================================");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-us");
            AddLine(string.Format("{0} hosted the game against {1} at {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.AwayTeam.Team.Name, gsGameStory.GameDate.ToLongDateString()));
            AddLine("{0} sport's fans watched the game in a {1} weather", gsGameStory.Watchers, gsGameStory.Weather);
            AddLine("");
            AddLine(string.Format("{0} played the game with {1} formation playing mostly through the {2}",
                gsGameStory.HomeTeam.Team.Name, gsGameStory.HomeTeam.Formation,
                (gsGameStory.HomeTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));

            AddLine(string.Format("visitors {0} chose the {1} formation using the {2}",
                gsGameStory.AwayTeam.Team.Name, gsGameStory.AwayTeam.Formation,
                (gsGameStory.AwayTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings")));
            AddLine();
            if (gsGameStory.Winner == null)
            {
                string strDesc = "a";
                if (gsGameStory.HomeScore <= 1) strDesc = "a boring";
                else if (gsGameStory.HomeScore > 2) strDesc = "a dramatic";
                AddLine("The game ended with {0} tie of {1} each.", strDesc, gsGameStory.HomeScore);
            }
            else
            {
                string strDesc = "a";
                int nDiff = Math.Abs(gsGameStory.HomeScore - gsGameStory.AwayScore);
                if (nDiff == 1) strDesc = "a close";
                else if (nDiff > 2) strDesc = "a staggering";

                AddLine("{0} won the game with {1} score of {2}-{3}", gsGameStory.Winner, strDesc, gsGameStory.HomeScore, gsGameStory.AwayScore);
            }
            AddLine();

            AddLine("Game Events:");
            AddLine("===================================:");
            AddLine();
            AddLine("First Half:");
            AddLine("-----------");
            bool bIsFirstHalf = true;
            foreach (KeyValuePair<int, GameEvent> evtCurr in gsGameStory.GameEvents)
            {
                if (bIsFirstHalf && evtCurr.Value.Minute > 45)
                {
                    AddLine();
                    AddLine("Second Half:");
                    AddLine("-----------");
                    bIsFirstHalf = false;
                }
                if (evtCurr.Value is ScoreEvent)
                {
                    if ((evtCurr.Value as ScoreEvent).bShowInSummary)
                    {
                        AddLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                    }
                }
                else
                {
                    AddLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                }
                AddLine();
            }

            AddLine();
            textBox1.Text = strBuilder.ToString();
            //dataGridView1.DataSource = GameStory.GameEvents.Values;
            //dataGridView1.Columns[0].DataPropertyName = "Minute";
            //dataGridView1.Columns[1].DataPropertyName = "Actor";
            //dataGridView1.Columns[2].DataPropertyName = "ToString";
            //gameEventBindingSource.DataSource = GameStory.GameEvents.Values;
            //dataGridView2.DataSource = this.gameEventBindingSource;
        }

    }
}
