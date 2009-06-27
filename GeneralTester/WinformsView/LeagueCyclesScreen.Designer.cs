﻿namespace HatTrick.Views.WinformsView
{
    partial class LeagueCyclesScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueCyclesScreen));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstCycles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgCycleGames = new System.Windows.Forms.DataGridView();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowGame = new System.Windows.Forms.DataGridViewLinkColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCycleGames)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(844, 210);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstCycles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 210);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose A League Cycle";
            // 
            // lstCycles
            // 
            this.lstCycles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCycles.FormattingEnabled = true;
            this.lstCycles.Location = new System.Drawing.Point(3, 16);
            this.lstCycles.Name = "lstCycles";
            this.lstCycles.Size = new System.Drawing.Size(156, 186);
            this.lstCycles.TabIndex = 5;
            this.lstCycles.SelectedIndexChanged += new System.EventHandler(this.lstCycles_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgCycleGames);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(678, 210);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chosen Cycle Games";
            // 
            // dgCycleGames
            // 
            this.dgCycleGames.AllowUserToAddRows = false;
            this.dgCycleGames.AllowUserToDeleteRows = false;
            this.dgCycleGames.AllowUserToResizeColumns = false;
            this.dgCycleGames.AllowUserToResizeRows = false;
            this.dgCycleGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCycleGames.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgCycleGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCycleGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HomeTeam,
            this.AwayTeam,
            this.HomeScore,
            this.AwayScore,
            this.ShowGame});
            this.dgCycleGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCycleGames.Location = new System.Drawing.Point(3, 16);
            this.dgCycleGames.Name = "dgCycleGames";
            this.dgCycleGames.ReadOnly = true;
            this.dgCycleGames.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgCycleGames.Size = new System.Drawing.Size(672, 191);
            this.dgCycleGames.TabIndex = 8;
            this.dgCycleGames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCycleGames_CellClick);
            // 
            // HomeTeam
            // 
            this.HomeTeam.DataPropertyName = "HomeTeam";
            this.HomeTeam.Frozen = true;
            this.HomeTeam.HeaderText = "HomeTeam";
            this.HomeTeam.Name = "HomeTeam";
            this.HomeTeam.ReadOnly = true;
            this.HomeTeam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HomeTeam.Width = 87;
            // 
            // AwayTeam
            // 
            this.AwayTeam.DataPropertyName = "AwayTeam";
            this.AwayTeam.Frozen = true;
            this.AwayTeam.HeaderText = "AwayTeam";
            this.AwayTeam.Name = "AwayTeam";
            this.AwayTeam.ReadOnly = true;
            this.AwayTeam.Width = 85;
            // 
            // HomeScore
            // 
            this.HomeScore.DataPropertyName = "HomeScore";
            this.HomeScore.Frozen = true;
            this.HomeScore.HeaderText = "HomeScore";
            this.HomeScore.Name = "HomeScore";
            this.HomeScore.ReadOnly = true;
            this.HomeScore.Width = 88;
            // 
            // AwayScore
            // 
            this.AwayScore.DataPropertyName = "AwayScore";
            this.AwayScore.Frozen = true;
            this.AwayScore.HeaderText = "AwayScore";
            this.AwayScore.Name = "AwayScore";
            this.AwayScore.ReadOnly = true;
            this.AwayScore.Width = 86;
            // 
            // ShowGame
            // 
            this.ShowGame.HeaderText = "Game Story";
            this.ShowGame.Name = "ShowGame";
            this.ShowGame.ReadOnly = true;
            this.ShowGame.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowGame.Text = "Details...";
            this.ShowGame.UseColumnTextForLinkValue = true;
            this.ShowGame.Width = 68;
            // 
            // LeagueCyclesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 210);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LeagueCyclesScreen";
            this.Text = "League Cycles";
            this.Load += new System.EventHandler(this.LeagueCyclesScreen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCycleGames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstCycles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgCycleGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayScore;
        private System.Windows.Forms.DataGridViewLinkColumn ShowGame;



    }
}