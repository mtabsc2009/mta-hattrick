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

            lblHomeName.Text = GameStory.HomeTeam.Team.Name;
            lblHomeScore.Text = GameStory.HomeScore.ToString();
            lblHomeFormation.Text = GameStory.HomeTeam.Team.Formation;
            lblHomeStrat.Text = GameStory.HomeTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings";

            lblAwayName.Text = GameStory.AwayTeam.Team.Name;
            lblAwayScore.Text = GameStory.AwayScore.ToString();
            lblAwayFormation.Text = GameStory.AwayTeam.Team.Formation;
            lblAwayStrat.Text = GameStory.AwayTeam.IsTeamMiddleMethod == true ? "Middle Field" : "Wings";

            lblGameDate.Text = GameStory.GameDate.ToShortDateString();
            lblFans.Text = GameStory.Watchers.ToString();
            lblWeather.Text = GameStory.Weather;
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
            TextBox1.AppendText(strLine + Environment.NewLine);
        }

        private void PrintGameStory()
        {
            GameStory gsGameStory = GameStory;

            int nStartChange = TextBox1.Text.Length;
            AddLine("Game Summary");
            AddLine("=================================");
            int nEndChange = TextBox1.Text.Length;
            TextBox1.Select(nStartChange, nEndChange);
            TextBox1.SelectionColor = Color.Green;
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

            nStartChange = TextBox1.Text.Length;

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
            nEndChange = TextBox1.Text.Length;
            TextBox1.Select(nStartChange, nEndChange);
            TextBox1.SelectionColor = Color.Blue;

            AddLine();
            nStartChange = TextBox1.Text.Length;

            AddLine("Game Events:");
            AddLine("===================================:");
            AddLine();
            AddLine("First Half:");
            AddLine("-----------");
            nEndChange = TextBox1.Text.Length;
            TextBox1.Select(nStartChange, nEndChange);
            TextBox1.SelectionColor = Color.Green;

            bool bIsFirstHalf = true;
            foreach (KeyValuePair<int, GameEvent> evtCurr in gsGameStory.GameEvents)
            {
                if (bIsFirstHalf && evtCurr.Value.Minute > 45)
                {
                    nStartChange = TextBox1.Text.Length;

                    AddLine();
                    AddLine("Second Half:");
                    AddLine("-----------");
                    bIsFirstHalf = false;
                    nEndChange = TextBox1.Text.Length;
                    TextBox1.Select(nStartChange, nEndChange);
                    TextBox1.SelectionColor = Color.Green;
                }
                if ((evtCurr.Value is ScoreEvent))
                {
                    if ((evtCurr.Value as ScoreEvent).bShowInSummary)
                    {
                        nStartChange = TextBox1.Text.Length;
                        AddLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                        nEndChange = TextBox1.Text.Length;
                        TextBox1.Select(nStartChange, nEndChange);
                        TextBox1.SelectionColor = Color.Blue;
                    }
                }
                else if (evtCurr.Value is FouledEvent)
                {
                    if ((evtCurr.Value as FouledEvent).bScored != null)
                    {
                        nStartChange = TextBox1.Text.Length;
                        AddLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                        nEndChange = TextBox1.Text.Length;
                        TextBox1.Select(nStartChange, nEndChange);
                        TextBox1.SelectionColor = Color.Blue;
                    }
                }
                else
                {
                    AddLine("(Min {0}) {1}", evtCurr.Value.Minute.ToString(), evtCurr.Value.ToString());
                }
                AddLine();
            }

            AddLine();
        }
    }
}
