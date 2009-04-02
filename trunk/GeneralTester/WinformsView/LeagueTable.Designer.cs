namespace HatTrick.Views.WinformsView
{
    partial class LeagueTableDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchesPlayed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.draws = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsagains = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 32;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.position,
            this.teamname,
            this.MatchesPlayed,
            this.wins,
            this.draws,
            this.loses,
            this.goalsfor,
            this.goalsagains,
            this.Diff,
            this.points});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(759, 524);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // position
            // 
            this.position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.position.HeaderText = " ";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Width = 37;
            // 
            // teamname
            // 
            this.teamname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.teamname.DefaultCellStyle = dataGridViewCellStyle2;
            this.teamname.HeaderText = "Team Name";
            this.teamname.Name = "teamname";
            this.teamname.ReadOnly = true;
            // 
            // MatchesPlayed
            // 
            this.MatchesPlayed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MatchesPlayed.DefaultCellStyle = dataGridViewCellStyle3;
            this.MatchesPlayed.HeaderText = "Matches";
            this.MatchesPlayed.Name = "MatchesPlayed";
            this.MatchesPlayed.ReadOnly = true;
            this.MatchesPlayed.Width = 88;
            // 
            // wins
            // 
            this.wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.wins.DefaultCellStyle = dataGridViewCellStyle4;
            this.wins.HeaderText = "w";
            this.wins.Name = "wins";
            this.wins.ReadOnly = true;
            this.wins.Width = 44;
            // 
            // draws
            // 
            this.draws.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.draws.DefaultCellStyle = dataGridViewCellStyle5;
            this.draws.HeaderText = "d";
            this.draws.Name = "draws";
            this.draws.ReadOnly = true;
            this.draws.Width = 41;
            // 
            // loses
            // 
            this.loses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loses.DefaultCellStyle = dataGridViewCellStyle6;
            this.loses.HeaderText = "l";
            this.loses.Name = "loses";
            this.loses.ReadOnly = true;
            this.loses.Width = 36;
            // 
            // goalsfor
            // 
            this.goalsfor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goalsfor.DefaultCellStyle = dataGridViewCellStyle7;
            this.goalsfor.HeaderText = "gf";
            this.goalsfor.Name = "goalsfor";
            this.goalsfor.ReadOnly = true;
            this.goalsfor.Width = 46;
            // 
            // goalsagains
            // 
            this.goalsagains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goalsagains.DefaultCellStyle = dataGridViewCellStyle8;
            this.goalsagains.HeaderText = "ga";
            this.goalsagains.Name = "goalsagains";
            this.goalsagains.ReadOnly = true;
            this.goalsagains.Width = 49;
            // 
            // Diff
            // 
            this.Diff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Diff.DefaultCellStyle = dataGridViewCellStyle9;
            this.Diff.HeaderText = "+-";
            this.Diff.Name = "Diff";
            this.Diff.ReadOnly = true;
            this.Diff.Width = 50;
            // 
            // points
            // 
            this.points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.points.DefaultCellStyle = dataGridViewCellStyle10;
            this.points.HeaderText = "pts";
            this.points.Name = "points";
            this.points.ReadOnly = true;
            this.points.Width = 54;
            // 
            // LeagueTableDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 524);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LeagueTableDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League Table";
            this.Load += new System.EventHandler(this.LeagueTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchesPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn draws;
        private System.Windows.Forms.DataGridViewTextBoxColumn loses;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsagains;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diff;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
    }
}