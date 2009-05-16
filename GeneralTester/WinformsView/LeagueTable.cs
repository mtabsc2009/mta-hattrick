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
    public partial class LeagueTableDisplay : DefaultForm
    {
        public DataView LeagueTable { get; set; }
        public LeagueTableDisplay()
        {
            InitializeComponent();
        }

        public LeagueTableDisplay(DataView dtvLeagueTable)
        {
            this.LeagueTable = dtvLeagueTable;
            InitializeComponent();
        }

        public void UpdateLeagueTable(DataView leagueTable)
        {
            LeagueTable = leagueTable;
            UpdateTableGrid();
        }

        private void LeagueTable_Load(object sender, EventArgs e)
        {
            UpdateTableGrid();
        }

        private void UpdateTableGrid()
        {
            dataGridView1.DataSource = LeagueTable;
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.SuspendLayout();
                if (dataGridView1.DataSource is DataView)
                {
                    DataView dtvSource = dataGridView1.DataSource as DataView;
                    foreach (DataGridViewColumn currcol in dataGridView1.Columns)
                    {
                        if (dtvSource.Table.Columns.Contains(currcol.Name))
                        {
                            if (currcol.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet)
                            {
                                currcol.Visible = false;
                            }
                            else
                            {
                                currcol.DataPropertyName = currcol.Name;
                                currcol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                        else if (currcol.Name != "position")
                        {
                            currcol.Visible = false;
                        }
                    }

                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = this.BackColor;
                    dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridView1.Rows[0].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);

                    foreach (DataGridViewRow currrow in dataGridView1.Rows)
                    {
                        currrow.Cells["position"].Value = currrow.Index + 1;
                        if ((currrow.DataBoundItem as DataRowView)["teamname"].ToString() == Game.getTeam().Name)
                        {
                            try
                            {
                                foreach (DataGridViewCell cell in currrow.Cells)
                                {
                                    cell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold | FontStyle.Italic);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    this.Height = dataGridView1.RowTemplate.Height * dataGridView1.DisplayedRowCount(false) + this.panel1.Height + dataGridView1.ColumnHeadersHeight + 40;
                    dataGridView1.ResumeLayout();

                }
            }
            catch
            {
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMatches_Click(object sender, EventArgs e)
        {
            LeagueCyclesScreen frmMatches = new LeagueCyclesScreen(SelectedTeam);
            frmMatches.MdiParent = this.MdiParent;
            frmMatches.Show();
        }

        private localhost.Team SelectedTeam
        {
            get
            {
                localhost.Team tmSelected = null;

                if (dataGridView1.SelectedRows.Count == 1)
                {
                    string strTeamName = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView)["teamname"].ToString();
                    tmSelected = Game.getTeams().Where(T => T.Name == strTeamName).First();
                }

                return tmSelected;
            }
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            TeamScreen frmTeam = new TeamScreen(SelectedTeam);
            frmTeam.MdiParent = this.MdiParent;
            frmTeam.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTeam_Click(sender, e as EventArgs);
        }
    }
}
