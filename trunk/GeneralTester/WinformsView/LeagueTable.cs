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
    public partial class LeagueTableDisplay : DefaultForm
    {
        private int m_bPositionsSet = 1;
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

        private void LeagueTable_Load(object sender, EventArgs e)
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
                    foreach (DataGridViewRow currrow in dataGridView1.Rows)
                    {
                        currrow.Cells["position"].Value = currrow.Index + 1;
                        if ((currrow.DataBoundItem as DataRowView)["teamname"].ToString() == Game.MyTeam.Name)
                        {
                            try
                            {
                                foreach (DataGridViewCell cell in currrow.Cells)
                                {
                                    cell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    this.Height = dataGridView1.RowTemplate.Height * dataGridView1.DisplayedRowCount(false) + dataGridView1.ColumnHeadersHeight + 40;
                    dataGridView1.ResumeLayout();

                }
            }
            catch
            {
            }

        }
    }
}
