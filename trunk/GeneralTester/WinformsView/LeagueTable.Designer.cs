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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.goalsagainst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTeamMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTeam = new System.Windows.Forms.Button();
            this.btnMatches = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmTeamMenu.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.goalsagainst,
            this.Diff,
            this.points});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.cmTeamMenu;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(759, 524);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            // goalsagainst
            // 
            this.goalsagainst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goalsagainst.DefaultCellStyle = dataGridViewCellStyle8;
            this.goalsagainst.HeaderText = "ga";
            this.goalsagainst.Name = "goalsagainst";
            this.goalsagainst.ReadOnly = true;
            this.goalsagainst.Width = 49;
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
            // cmTeamMenu
            // 
            this.cmTeamMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTeamToolStripMenuItem,
            this.showMatchesToolStripMenuItem});
            this.cmTeamMenu.Name = "cmTeamMenu";
            this.cmTeamMenu.Size = new System.Drawing.Size(144, 48);
            // 
            // showTeamToolStripMenuItem
            // 
            this.showTeamToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTeamToolStripMenuItem.Name = "showTeamToolStripMenuItem";
            this.showTeamToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showTeamToolStripMenuItem.Text = "Show Team";
            this.showTeamToolStripMenuItem.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // showMatchesToolStripMenuItem
            // 
            this.showMatchesToolStripMenuItem.Name = "showMatchesToolStripMenuItem";
            this.showMatchesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.showMatchesToolStripMenuItem.Text = "Show Matches";
            this.showMatchesToolStripMenuItem.Click += new System.EventHandler(this.btnMatches_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTeam);
            this.panel1.Controls.Add(this.btnMatches);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnTeam
            // 
            this.btnTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTeam.Location = new System.Drawing.Point(105, 4);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(96, 23);
            this.btnTeam.TabIndex = 2;
            this.btnTeam.Text = "Show Team";
            this.btnTeam.UseVisualStyleBackColor = true;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // btnMatches
            // 
            this.btnMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMatches.Location = new System.Drawing.Point(3, 4);
            this.btnMatches.Name = "btnMatches";
            this.btnMatches.Size = new System.Drawing.Size(96, 23);
            this.btnMatches.TabIndex = 2;
            this.btnMatches.Text = "Show Matches";
            this.btnMatches.UseVisualStyleBackColor = true;
            this.btnMatches.Click += new System.EventHandler(this.btnMatches_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(681, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LeagueTableDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(759, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LeagueTableDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League Table";
            this.Load += new System.EventHandler(this.LeagueTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmTeamMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMatches;
        private System.Windows.Forms.Button btnTeam;
        private System.Windows.Forms.ContextMenuStrip cmTeamMenu;
        private System.Windows.Forms.ToolStripMenuItem showTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMatchesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamname;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchesPlayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn draws;
        private System.Windows.Forms.DataGridViewTextBoxColumn loses;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsagainst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diff;
        private System.Windows.Forms.DataGridViewTextBoxColumn points;
    }
}