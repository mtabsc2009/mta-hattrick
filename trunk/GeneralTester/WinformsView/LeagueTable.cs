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
    public partial class LeagueTableDisplay : Form
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

        private void LeagueTable_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LeagueTable;
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
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
                            }
                        }
                        else if (currcol.Name != "position")
                        {
                            currcol.Visible = false;
                        }
                    }

                    foreach (DataGridViewRow currrow in dataGridView1.Rows)
                    {
                        currrow.Cells["position"].Value = currrow.Index;
                    }

                }
            }
            catch
            {
            }
        }
    }
}
