namespace HatTrick.Views.WinformsView
{
    partial class GameStoryDisplay
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
            this.gameEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblAwayScore = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAwayStrat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAwayFormation = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAwayName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblWeather = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFans = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGameDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHomeStrat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHomeFormation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHomeScore = new System.Windows.Forms.Label();
            this.lblHomeName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameEventBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameEventBindingSource
            // 
            this.gameEventBindingSource.DataSource = typeof(HatTrick.CommonModel.GameEvent);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Details";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblAwayScore);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblAwayStrat);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblAwayFormation);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.lblAwayName);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(381, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(191, 144);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Away Team Details";
            // 
            // lblAwayScore
            // 
            this.lblAwayScore.AutoSize = true;
            this.lblAwayScore.Location = new System.Drawing.Point(74, 53);
            this.lblAwayScore.Name = "lblAwayScore";
            this.lblAwayScore.Size = new System.Drawing.Size(13, 13);
            this.lblAwayScore.TabIndex = 5;
            this.lblAwayScore.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Score:";
            // 
            // lblAwayStrat
            // 
            this.lblAwayStrat.AutoSize = true;
            this.lblAwayStrat.Location = new System.Drawing.Point(74, 104);
            this.lblAwayStrat.Name = "lblAwayStrat";
            this.lblAwayStrat.Size = new System.Drawing.Size(46, 13);
            this.lblAwayStrat.TabIndex = 3;
            this.lblAwayStrat.Text = "Strategy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Strategy:";
            // 
            // lblAwayFormation
            // 
            this.lblAwayFormation.AutoSize = true;
            this.lblAwayFormation.Location = new System.Drawing.Point(74, 78);
            this.lblAwayFormation.Name = "lblAwayFormation";
            this.lblAwayFormation.Size = new System.Drawing.Size(53, 13);
            this.lblAwayFormation.TabIndex = 2;
            this.lblAwayFormation.Text = "Formation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Formation:";
            // 
            // lblAwayName
            // 
            this.lblAwayName.AutoSize = true;
            this.lblAwayName.Location = new System.Drawing.Point(74, 25);
            this.lblAwayName.Name = "lblAwayName";
            this.lblAwayName.Size = new System.Drawing.Size(35, 13);
            this.lblAwayName.TabIndex = 1;
            this.lblAwayName.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblWeather);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblFans);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblGameDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(194, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 144);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Details";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(104, 78);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(46, 13);
            this.lblWeather.TabIndex = 3;
            this.lblWeather.Text = "Strategy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Weather";
            // 
            // lblFans
            // 
            this.lblFans.AutoSize = true;
            this.lblFans.Location = new System.Drawing.Point(104, 52);
            this.lblFans.Name = "lblFans";
            this.lblFans.Size = new System.Drawing.Size(53, 13);
            this.lblFans.TabIndex = 2;
            this.lblFans.Text = "Formation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Number Of Fans";
            // 
            // lblGameDate
            // 
            this.lblGameDate.AutoSize = true;
            this.lblGameDate.Location = new System.Drawing.Point(104, 25);
            this.lblGameDate.Name = "lblGameDate";
            this.lblGameDate.Size = new System.Drawing.Size(35, 13);
            this.lblGameDate.TabIndex = 1;
            this.lblGameDate.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Game Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHomeStrat);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblHomeFormation);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblHomeScore);
            this.groupBox2.Controls.Add(this.lblHomeName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 144);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Home Team Details";
            // 
            // lblHomeStrat
            // 
            this.lblHomeStrat.AutoSize = true;
            this.lblHomeStrat.Location = new System.Drawing.Point(74, 107);
            this.lblHomeStrat.Name = "lblHomeStrat";
            this.lblHomeStrat.Size = new System.Drawing.Size(46, 13);
            this.lblHomeStrat.TabIndex = 3;
            this.lblHomeStrat.Text = "Strategy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Strategy:";
            // 
            // lblHomeFormation
            // 
            this.lblHomeFormation.AutoSize = true;
            this.lblHomeFormation.Location = new System.Drawing.Point(74, 81);
            this.lblHomeFormation.Name = "lblHomeFormation";
            this.lblHomeFormation.Size = new System.Drawing.Size(53, 13);
            this.lblHomeFormation.TabIndex = 2;
            this.lblHomeFormation.Text = "Formation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Formation:";
            // 
            // lblHomeScore
            // 
            this.lblHomeScore.AutoSize = true;
            this.lblHomeScore.Location = new System.Drawing.Point(75, 53);
            this.lblHomeScore.Name = "lblHomeScore";
            this.lblHomeScore.Size = new System.Drawing.Size(13, 13);
            this.lblHomeScore.TabIndex = 1;
            this.lblHomeScore.Text = "1";
            // 
            // lblHomeName
            // 
            this.lblHomeName.AutoSize = true;
            this.lblHomeName.Location = new System.Drawing.Point(74, 25);
            this.lblHomeName.Name = "lblHomeName";
            this.lblHomeName.Size = new System.Drawing.Size(35, 13);
            this.lblHomeName.TabIndex = 1;
            this.lblHomeName.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Score:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAwayTeam);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.lblHomeTeam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 37);
            this.panel1.TabIndex = 3;
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAwayTeam.AutoSize = true;
            this.lblAwayTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAwayTeam.Location = new System.Drawing.Point(510, 7);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(66, 24);
            this.lblAwayTeam.TabIndex = 0;
            this.lblAwayTeam.Text = "label8";
            this.lblAwayTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblScore.Location = new System.Drawing.Point(243, 7);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(66, 24);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "label8";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.AutoSize = true;
            this.lblHomeTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHomeTeam.Location = new System.Drawing.Point(3, 7);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(66, 24);
            this.lblHomeTeam.TabIndex = 0;
            this.lblHomeTeam.Text = "label8";
            this.lblHomeTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBox1
            // 
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.Location = new System.Drawing.Point(0, 37);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(575, 267);
            this.TextBox1.TabIndex = 4;
            this.TextBox1.Text = "";
            // 
            // GameStoryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 467);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GameStoryDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Details";
            this.Load += new System.EventHandler(this.GameStoryDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameEventBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource gameEventBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFans;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGameDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHomeStrat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHomeFormation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHomeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblAwayStrat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAwayFormation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAwayName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAwayScore;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblHomeScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAwayTeam;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.RichTextBox TextBox1;
    }
}