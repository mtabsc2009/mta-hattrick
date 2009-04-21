namespace HatTrick.Views.WinformsView
{
    partial class TeamScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamScreen));
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTraining = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.pnlField = new System.Windows.Forms.Panel();
            this.btnPlayer10 = new System.Windows.Forms.Button();
            this.btnPlayer9 = new System.Windows.Forms.Button();
            this.btnPlayer11 = new System.Windows.Forms.Button();
            this.btnPlayer7 = new System.Windows.Forms.Button();
            this.btnPlayer8 = new System.Windows.Forms.Button();
            this.btnPlayer5 = new System.Windows.Forms.Button();
            this.btnPlayer4 = new System.Windows.Forms.Button();
            this.btnPlayer6 = new System.Windows.Forms.Button();
            this.btnPlayer3 = new System.Windows.Forms.Button();
            this.btnPlayer2 = new System.Windows.Forms.Button();
            this.btnPlayer1 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.pnlField.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cmbTraining);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbFormation);
            this.panel3.Controls.Add(this.lstPlayers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(746, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 465);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Training Type";
            // 
            // cmbTraining
            // 
            this.cmbTraining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTraining.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTraining.FormattingEnabled = true;
            this.cmbTraining.Items.AddRange(new object[] {
            "Attack",
            "Defence",
            "Wing",
            "Play Making",
            "Set Pieces"});
            this.cmbTraining.Location = new System.Drawing.Point(6, 67);
            this.cmbTraining.Name = "cmbTraining";
            this.cmbTraining.Size = new System.Drawing.Size(121, 21);
            this.cmbTraining.TabIndex = 5;
            this.cmbTraining.SelectionChangeCommitted += new System.EventHandler(this.cmbTraining_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Formation";
            // 
            // cmbFormation
            // 
            this.cmbFormation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFormation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(6, 22);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(121, 21);
            this.cmbFormation.TabIndex = 2;
            this.cmbFormation.SelectionChangeCommitted += new System.EventHandler(this.cmbFormation_SelectionChangeCommitted);
            // 
            // lstPlayers
            // 
            this.lstPlayers.AllowDrop = true;
            this.lstPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(6, 113);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(121, 316);
            this.lstPlayers.TabIndex = 3;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            this.lstPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlayers_MouseDown);
            this.lstPlayers.SelectedValueChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // pnlField
            // 
            this.pnlField.BackColor = System.Drawing.Color.Transparent;
            this.pnlField.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlField.BackgroundImage")));
            this.pnlField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlField.Controls.Add(this.btnPlayer10);
            this.pnlField.Controls.Add(this.btnPlayer9);
            this.pnlField.Controls.Add(this.btnPlayer11);
            this.pnlField.Controls.Add(this.btnPlayer7);
            this.pnlField.Controls.Add(this.btnPlayer8);
            this.pnlField.Controls.Add(this.btnPlayer5);
            this.pnlField.Controls.Add(this.btnPlayer4);
            this.pnlField.Controls.Add(this.btnPlayer6);
            this.pnlField.Controls.Add(this.btnPlayer3);
            this.pnlField.Controls.Add(this.btnPlayer2);
            this.pnlField.Controls.Add(this.btnPlayer1);
            this.pnlField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlField.Location = new System.Drawing.Point(0, 0);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(746, 465);
            this.pnlField.TabIndex = 8;
            this.pnlField.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            // 
            // btnPlayer10
            // 
            this.btnPlayer10.AllowDrop = true;
            this.btnPlayer10.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer10.FlatAppearance.BorderSize = 0;
            this.btnPlayer10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer10.ForeColor = System.Drawing.Color.White;
            this.btnPlayer10.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer10.Image")));
            this.btnPlayer10.Location = new System.Drawing.Point(160, 255);
            this.btnPlayer10.Name = "btnPlayer10";
            this.btnPlayer10.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer10.TabIndex = 28;
            this.btnPlayer10.Tag = "10";
            this.btnPlayer10.Text = "button2";
            this.btnPlayer10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer10.UseVisualStyleBackColor = false;
            this.btnPlayer10.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer10.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer10.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer9
            // 
            this.btnPlayer9.AllowDrop = true;
            this.btnPlayer9.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer9.FlatAppearance.BorderSize = 0;
            this.btnPlayer9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer9.ForeColor = System.Drawing.Color.White;
            this.btnPlayer9.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer9.Image")));
            this.btnPlayer9.Location = new System.Drawing.Point(499, 191);
            this.btnPlayer9.Name = "btnPlayer9";
            this.btnPlayer9.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer9.TabIndex = 27;
            this.btnPlayer9.Tag = "9";
            this.btnPlayer9.Text = "button2";
            this.btnPlayer9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer9.UseVisualStyleBackColor = false;
            this.btnPlayer9.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer9.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer9.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer11
            // 
            this.btnPlayer11.AllowDrop = true;
            this.btnPlayer11.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer11.FlatAppearance.BorderSize = 0;
            this.btnPlayer11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer11.ForeColor = System.Drawing.Color.White;
            this.btnPlayer11.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer11.Image")));
            this.btnPlayer11.Location = new System.Drawing.Point(321, 268);
            this.btnPlayer11.Name = "btnPlayer11";
            this.btnPlayer11.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer11.TabIndex = 29;
            this.btnPlayer11.Tag = "11";
            this.btnPlayer11.Text = "button2";
            this.btnPlayer11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer11.UseVisualStyleBackColor = false;
            this.btnPlayer11.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer11.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer11.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer7
            // 
            this.btnPlayer7.AllowDrop = true;
            this.btnPlayer7.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer7.FlatAppearance.BorderSize = 0;
            this.btnPlayer7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer7.ForeColor = System.Drawing.Color.White;
            this.btnPlayer7.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer7.Image")));
            this.btnPlayer7.Location = new System.Drawing.Point(138, 191);
            this.btnPlayer7.Name = "btnPlayer7";
            this.btnPlayer7.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer7.TabIndex = 25;
            this.btnPlayer7.Tag = "7";
            this.btnPlayer7.Text = "button2";
            this.btnPlayer7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer7.UseVisualStyleBackColor = false;
            this.btnPlayer7.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer7.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer7.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer8
            // 
            this.btnPlayer8.AllowDrop = true;
            this.btnPlayer8.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer8.FlatAppearance.BorderSize = 0;
            this.btnPlayer8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer8.ForeColor = System.Drawing.Color.White;
            this.btnPlayer8.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer8.Image")));
            this.btnPlayer8.Location = new System.Drawing.Point(516, 279);
            this.btnPlayer8.Name = "btnPlayer8";
            this.btnPlayer8.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer8.TabIndex = 26;
            this.btnPlayer8.Tag = "8";
            this.btnPlayer8.Text = "button2";
            this.btnPlayer8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer8.UseVisualStyleBackColor = false;
            this.btnPlayer8.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer8.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer8.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer5
            // 
            this.btnPlayer5.AllowDrop = true;
            this.btnPlayer5.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer5.FlatAppearance.BorderSize = 0;
            this.btnPlayer5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer5.ForeColor = System.Drawing.Color.White;
            this.btnPlayer5.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer5.Image")));
            this.btnPlayer5.Location = new System.Drawing.Point(479, 70);
            this.btnPlayer5.Name = "btnPlayer5";
            this.btnPlayer5.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer5.TabIndex = 23;
            this.btnPlayer5.Tag = "5";
            this.btnPlayer5.Text = "button2";
            this.btnPlayer5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer5.UseVisualStyleBackColor = false;
            this.btnPlayer5.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer5.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer5.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer4
            // 
            this.btnPlayer4.AllowDrop = true;
            this.btnPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer4.FlatAppearance.BorderSize = 0;
            this.btnPlayer4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer4.ForeColor = System.Drawing.Color.White;
            this.btnPlayer4.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer4.Image")));
            this.btnPlayer4.Location = new System.Drawing.Point(321, 70);
            this.btnPlayer4.Name = "btnPlayer4";
            this.btnPlayer4.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer4.TabIndex = 22;
            this.btnPlayer4.Tag = "4";
            this.btnPlayer4.Text = "button2";
            this.btnPlayer4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer4.UseVisualStyleBackColor = false;
            this.btnPlayer4.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer4.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer4.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer6
            // 
            this.btnPlayer6.AllowDrop = true;
            this.btnPlayer6.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer6.FlatAppearance.BorderSize = 0;
            this.btnPlayer6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer6.ForeColor = System.Drawing.Color.White;
            this.btnPlayer6.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer6.Image")));
            this.btnPlayer6.Location = new System.Drawing.Point(632, 70);
            this.btnPlayer6.Name = "btnPlayer6";
            this.btnPlayer6.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer6.TabIndex = 24;
            this.btnPlayer6.Tag = "6";
            this.btnPlayer6.Text = "button2";
            this.btnPlayer6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer6.UseVisualStyleBackColor = false;
            this.btnPlayer6.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer6.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer6.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer3
            // 
            this.btnPlayer3.AllowDrop = true;
            this.btnPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer3.FlatAppearance.BorderSize = 0;
            this.btnPlayer3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer3.ForeColor = System.Drawing.Color.White;
            this.btnPlayer3.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer3.Image")));
            this.btnPlayer3.Location = new System.Drawing.Point(160, 70);
            this.btnPlayer3.Name = "btnPlayer3";
            this.btnPlayer3.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer3.TabIndex = 21;
            this.btnPlayer3.Tag = "3";
            this.btnPlayer3.Text = "button2";
            this.btnPlayer3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer3.UseVisualStyleBackColor = false;
            this.btnPlayer3.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer3.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer3.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer2
            // 
            this.btnPlayer2.AllowDrop = true;
            this.btnPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer2.FlatAppearance.BorderSize = 0;
            this.btnPlayer2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer2.ForeColor = System.Drawing.Color.White;
            this.btnPlayer2.Image = global::HatTrick.Views.WinformsView.Properties.Resources.soccer_5_48;
            this.btnPlayer2.Location = new System.Drawing.Point(3, 70);
            this.btnPlayer2.Name = "btnPlayer2";
            this.btnPlayer2.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer2.TabIndex = 20;
            this.btnPlayer2.Tag = "2";
            this.btnPlayer2.Text = "button2";
            this.btnPlayer2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer2.UseVisualStyleBackColor = false;
            this.btnPlayer2.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer2.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer2.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer1
            // 
            this.btnPlayer1.AllowDrop = true;
            this.btnPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayer1.FlatAppearance.BorderSize = 0;
            this.btnPlayer1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPlayer1.ForeColor = System.Drawing.Color.White;
            this.btnPlayer1.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayer1.Image")));
            this.btnPlayer1.Location = new System.Drawing.Point(320, 13);
            this.btnPlayer1.Name = "btnPlayer1";
            this.btnPlayer1.Size = new System.Drawing.Size(110, 75);
            this.btnPlayer1.TabIndex = 19;
            this.btnPlayer1.Tag = "1";
            this.btnPlayer1.Text = "button2";
            this.btnPlayer1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayer1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlayer1.UseVisualStyleBackColor = false;
            this.btnPlayer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer1.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // TeamScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 465);
            this.Controls.Add(this.pnlField);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 450);
            this.Name = "TeamScreen";
            this.Text = "Team";
            this.Load += new System.EventHandler(this.TeamScreen_Load);
            this.ResizeEnd += new System.EventHandler(this.TeamScreen_ResizeEnd);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.Button btnPlayer10;
        private System.Windows.Forms.Button btnPlayer9;
        private System.Windows.Forms.Button btnPlayer11;
        private System.Windows.Forms.Button btnPlayer7;
        private System.Windows.Forms.Button btnPlayer8;
        private System.Windows.Forms.Button btnPlayer5;
        private System.Windows.Forms.Button btnPlayer4;
        private System.Windows.Forms.Button btnPlayer6;
        private System.Windows.Forms.Button btnPlayer3;
        private System.Windows.Forms.Button btnPlayer2;
        private System.Windows.Forms.Button btnPlayer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTraining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}