namespace HatTrick.Views.WinformsView
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
            this.lstCycles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgCycleGames = new System.Windows.Forms.DataGridView();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowGame = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCycleGames)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCycles
            // 
            this.lstCycles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCycles.FormattingEnabled = true;
            this.lstCycles.Location = new System.Drawing.Point(3, 16);
            this.lstCycles.Name = "lstCycles";
            this.lstCycles.Size = new System.Drawing.Size(143, 186);
            this.lstCycles.TabIndex = 5;
            this.lstCycles.SelectedIndexChanged += new System.EventHandler(this.lstCycles_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstCycles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 212);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose A League Cycle";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgCycleGames);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(165, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 212);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chosen Cycle Games";
            // 
            // dgCycleGames
            // 
            this.dgCycleGames.AllowUserToAddRows = false;
            this.dgCycleGames.AllowUserToDeleteRows = false;
            this.dgCycleGames.AllowUserToResizeColumns = false;
            this.dgCycleGames.AllowUserToResizeRows = false;
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
            this.dgCycleGames.Size = new System.Drawing.Size(547, 193);
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
            // 
            // AwayTeam
            // 
            this.AwayTeam.DataPropertyName = "AwayTeam";
            this.AwayTeam.Frozen = true;
            this.AwayTeam.HeaderText = "AwayTeam";
            this.AwayTeam.Name = "AwayTeam";
            this.AwayTeam.ReadOnly = true;
            // 
            // HomeScore
            // 
            this.HomeScore.DataPropertyName = "HomeScore";
            this.HomeScore.Frozen = true;
            this.HomeScore.HeaderText = "HomeScore";
            this.HomeScore.Name = "HomeScore";
            this.HomeScore.ReadOnly = true;
            // 
            // AwayScore
            // 
            this.AwayScore.DataPropertyName = "AwayScore";
            this.AwayScore.Frozen = true;
            this.AwayScore.HeaderText = "AwayScore";
            this.AwayScore.Name = "AwayScore";
            this.AwayScore.ReadOnly = true;
            // 
            // ShowGame
            // 
            this.ShowGame.HeaderText = "Game Story";
            this.ShowGame.Name = "ShowGame";
            this.ShowGame.ReadOnly = true;
            this.ShowGame.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowGame.Text = "Details...";
            this.ShowGame.UseColumnTextForLinkValue = true;
            // 
            // LeagueCyclesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 212);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LeagueCyclesScreen";
            this.Text = "League Cycles";
            this.Load += new System.EventHandler(this.LeagueCyclesScreen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCycleGames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCycles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgCycleGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayScore;
        private System.Windows.Forms.DataGridViewLinkColumn ShowGame;
    }
}