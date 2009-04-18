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

            lblHomeTeam.Text = GameStory.HomeTeam.Team.Name;
            lblAwayTeam.Text = GameStory.AwayTeam.Team.Name;
            lblScore.Text = string.Format("{0}-{1}", GameStory.HomeScore, GameStory.AwayScore);
            lblScore.Left = (this.Width - lblScore.Width) / 2;
            lblScore.Anchor = AnchorStyles.Left & AnchorStyles.Right;
            if (GameStory.Winner == null)
            {
                lblAwayTeam.ForeColor = Color.Blue;
                lblHomeTeam.ForeColor = Color.Blue;
            }
            else if (GameStory.Winner.Name == GameStory.HomeTeam.Team.Name)
            {
                lblHomeTeam.ForeColor = Color.Green;
                lblAwayTeam.ForeColor = Color.Red;
            }
            else
            {
                lblHomeTeam.ForeColor = Color.Red;
                lblAwayTeam.ForeColor = Color.Green;
            }
            lblHomeTeam.Left = 5;
            lblAwayTeam.Left = panel1.Width - lblAwayTeam.Width - 5;

            this.Text = 
                string.Format("Game Story: {0} - ({1}) - {2}", lblHomeTeam.Text, lblScore.Text, lblAwayTeam.Text);

            SetDataGrid();
        }

        private void SetDataGrid()
        {
            DataTable tblEvents = new DataTable();
            tblEvents.Columns.Add(new DataColumn("Min", typeof(int)));
            tblEvents.Columns.Add(new DataColumn("Event"));
            tblEvents.Columns.Add(new DataColumn("Team"));
            tblEvents.Columns.Add(new DataColumn("Player"));
            tblEvents.Columns.Add(new DataColumn("More"));

            foreach (GameEvent evt in GameStory.GameEvents.Values.Where(T => T.Minute >= 0))
            {
                DataRow r = tblEvents.NewRow();

                r["Min"] = evt.Minute;
                string strEvent = evt.GetType().Name;
                r["Event"] = strEvent.Substring(0, strEvent.IndexOf("Event"));
                r["Team"] = evt.teamAttacking;
                r["Player"] = string.Format("{0} ({1})", evt.Actor.Name, evt.Actor.Position);

                if (evt is PaneltyEvent)
                {
                    r["More"] = string.Format("{0} ({1})",
                        (evt as PaneltyEvent).Shooter.Name, (evt as PaneltyEvent).Shooter.Position);
                }
                else if (evt is FreeKickEvent)
                {
                    string strAddition = string.Empty;
                    if ((evt as FreeKickEvent).bScored != null)
                    {
                        strAddition = "Scored!";
                    }
                    r["More"] = string.Format("{0} ({1}) {2}",
                        (evt as FreeKickEvent).Shooter.Name, (evt as FreeKickEvent).Shooter.Position, strAddition);
                }
                else if (evt is PaneltyEvent)
                {
                    string strAddition = string.Empty;
                    if ((evt as PaneltyEvent).bScored != null)
                    {
                        strAddition = "Scored!";
                    }
                    r["More"] = string.Format("{0} ({1}) {2}",
                        (evt as PaneltyEvent).Shooter.Name, (evt as PaneltyEvent).Shooter.Position, strAddition);
                }
                else if (evt is FouledEvent)
                {
                    FouledEvent f = evt as FouledEvent;
                    string strCard = f.ptCard.ToString().Substring(2);
                    if (f.ptCard == PaneltyCard.ptNone)
                    {
                        strCard = "No";
                    }
                    string strPlayer = string.Format("{0} ({1})", f.Foulist.Name, f.Foulist.Position);
                    r["More"] = string.Format("{0} card to {1}", strCard, strPlayer);
                }

                tblEvents.Rows.Add(r);
            }

            tblEvents.DefaultView.Sort = "Min";
            dataGridView1.DataSource = tblEvents.DefaultView;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                col.Resizable = DataGridViewTriState.True;
                if (col.Name == "More")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else if (col.Name == "Min")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                }
            }
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.RowHeadersVisible = false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox1.Visible = !checkBox1.Checked;
            dataGridView1.Visible = checkBox1.Checked;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Event"].Value != null)
                {
                    if (row.Cells["Event"].Value.ToString() == "Score")
                    {
                        row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (row.Cells["Event"].Value.ToString() == "Panelty")
                    {
                        row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        int nMinute = (int)((row.DataBoundItem as DataRowView)["Min"]);
                        if (GameStory.GameEvents.ContainsKey(-nMinute))
                        {
                            row.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                            row.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }
    }
    [Serializable]
    class a
    {
        public int Minute
        {
            get
            {
                return min;
            }

        }

        private int min;

        public a(int _m)
        {
            min = _m;
        }
    }

}
