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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
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
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 393);
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
            this.panel3.Size = new System.Drawing.Size(130, 423);
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
            this.lstPlayers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(6, 111);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(121, 277);
            this.lstPlayers.TabIndex = 3;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            this.lstPlayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlayers_MouseDown);
            this.lstPlayers.SelectedValueChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.btnPlayer10);
            this.panel1.Controls.Add(this.btnPlayer9);
            this.panel1.Controls.Add(this.btnPlayer11);
            this.panel1.Controls.Add(this.btnPlayer7);
            this.panel1.Controls.Add(this.btnPlayer8);
            this.panel1.Controls.Add(this.btnPlayer5);
            this.panel1.Controls.Add(this.btnPlayer4);
            this.panel1.Controls.Add(this.btnPlayer6);
            this.panel1.Controls.Add(this.btnPlayer3);
            this.panel1.Controls.Add(this.btnPlayer2);
            this.panel1.Controls.Add(this.btnPlayer1);
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton9);
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Controls.Add(this.radioButton10);
            this.panel1.Controls.Add(this.radioButton14);
            this.panel1.Controls.Add(this.radioButton13);
            this.panel1.Controls.Add(this.radioButton12);
            this.panel1.Controls.Add(this.radioButton11);
            this.panel1.Controls.Add(this.radioButton8);
            this.panel1.Controls.Add(this.radioButton7);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 423);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(361, 130);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(276, 50);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(191, 5);
            this.panel9.TabIndex = 32;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(462, -1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 55);
            this.panel8.TabIndex = 32;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(276, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 55);
            this.panel7.TabIndex = 31;
            // 
            // btnPlayer10
            // 
            this.btnPlayer10.AllowDrop = true;
            this.btnPlayer10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer10.Location = new System.Drawing.Point(160, 255);
            this.btnPlayer10.Name = "btnPlayer10";
            this.btnPlayer10.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer10.TabIndex = 28;
            this.btnPlayer10.Tag = "10";
            this.btnPlayer10.Text = "button2";
            this.btnPlayer10.UseVisualStyleBackColor = true;
            this.btnPlayer10.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer10.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer10.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer9
            // 
            this.btnPlayer9.AllowDrop = true;
            this.btnPlayer9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer9.Location = new System.Drawing.Point(499, 191);
            this.btnPlayer9.Name = "btnPlayer9";
            this.btnPlayer9.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer9.TabIndex = 27;
            this.btnPlayer9.Tag = "9";
            this.btnPlayer9.Text = "button2";
            this.btnPlayer9.UseVisualStyleBackColor = true;
            this.btnPlayer9.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer9.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer9.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer11
            // 
            this.btnPlayer11.AllowDrop = true;
            this.btnPlayer11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer11.Location = new System.Drawing.Point(321, 268);
            this.btnPlayer11.Name = "btnPlayer11";
            this.btnPlayer11.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer11.TabIndex = 29;
            this.btnPlayer11.Tag = "11";
            this.btnPlayer11.Text = "button2";
            this.btnPlayer11.UseVisualStyleBackColor = true;
            this.btnPlayer11.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer11.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer11.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer7
            // 
            this.btnPlayer7.AllowDrop = true;
            this.btnPlayer7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer7.Location = new System.Drawing.Point(138, 191);
            this.btnPlayer7.Name = "btnPlayer7";
            this.btnPlayer7.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer7.TabIndex = 25;
            this.btnPlayer7.Tag = "7";
            this.btnPlayer7.Text = "button2";
            this.btnPlayer7.UseVisualStyleBackColor = true;
            this.btnPlayer7.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer7.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer7.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer8
            // 
            this.btnPlayer8.AllowDrop = true;
            this.btnPlayer8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer8.Location = new System.Drawing.Point(516, 279);
            this.btnPlayer8.Name = "btnPlayer8";
            this.btnPlayer8.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer8.TabIndex = 26;
            this.btnPlayer8.Tag = "8";
            this.btnPlayer8.Text = "button2";
            this.btnPlayer8.UseVisualStyleBackColor = true;
            this.btnPlayer8.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer8.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer8.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer5
            // 
            this.btnPlayer5.AllowDrop = true;
            this.btnPlayer5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer5.Location = new System.Drawing.Point(479, 70);
            this.btnPlayer5.Name = "btnPlayer5";
            this.btnPlayer5.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer5.TabIndex = 23;
            this.btnPlayer5.Tag = "5";
            this.btnPlayer5.Text = "button2";
            this.btnPlayer5.UseVisualStyleBackColor = true;
            this.btnPlayer5.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer5.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer5.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer4
            // 
            this.btnPlayer4.AllowDrop = true;
            this.btnPlayer4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer4.Location = new System.Drawing.Point(321, 70);
            this.btnPlayer4.Name = "btnPlayer4";
            this.btnPlayer4.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer4.TabIndex = 22;
            this.btnPlayer4.Tag = "4";
            this.btnPlayer4.Text = "button2";
            this.btnPlayer4.UseVisualStyleBackColor = true;
            this.btnPlayer4.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer4.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer4.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer6
            // 
            this.btnPlayer6.AllowDrop = true;
            this.btnPlayer6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer6.Location = new System.Drawing.Point(632, 70);
            this.btnPlayer6.Name = "btnPlayer6";
            this.btnPlayer6.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer6.TabIndex = 24;
            this.btnPlayer6.Tag = "6";
            this.btnPlayer6.Text = "button2";
            this.btnPlayer6.UseVisualStyleBackColor = true;
            this.btnPlayer6.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer6.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer6.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer3
            // 
            this.btnPlayer3.AllowDrop = true;
            this.btnPlayer3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer3.Location = new System.Drawing.Point(160, 70);
            this.btnPlayer3.Name = "btnPlayer3";
            this.btnPlayer3.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer3.TabIndex = 21;
            this.btnPlayer3.Tag = "3";
            this.btnPlayer3.Text = "button2";
            this.btnPlayer3.UseVisualStyleBackColor = true;
            this.btnPlayer3.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer3.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer3.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer2
            // 
            this.btnPlayer2.AllowDrop = true;
            this.btnPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer2.Location = new System.Drawing.Point(3, 70);
            this.btnPlayer2.Name = "btnPlayer2";
            this.btnPlayer2.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer2.TabIndex = 20;
            this.btnPlayer2.Tag = "2";
            this.btnPlayer2.Text = "button2";
            this.btnPlayer2.UseVisualStyleBackColor = true;
            this.btnPlayer2.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer2.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer2.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // btnPlayer1
            // 
            this.btnPlayer1.AllowDrop = true;
            this.btnPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayer1.Location = new System.Drawing.Point(320, 13);
            this.btnPlayer1.Name = "btnPlayer1";
            this.btnPlayer1.Size = new System.Drawing.Size(107, 29);
            this.btnPlayer1.TabIndex = 19;
            this.btnPlayer1.Tag = "1";
            this.btnPlayer1.Text = "button2";
            this.btnPlayer1.UseVisualStyleBackColor = true;
            this.btnPlayer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragDrop);
            this.btnPlayer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlayer4_MouseDown);
            this.btnPlayer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnPlayer1_DragEnter);
            this.btnPlayer1.MouseEnter += new System.EventHandler(this.btnPlayer_MouseHover);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton5.Location = new System.Drawing.Point(361, 199);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(14, 13);
            this.radioButton5.TabIndex = 9;
            this.radioButton5.UseVisualStyleBackColor = false;
            this.radioButton5.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton9.Location = new System.Drawing.Point(351, 199);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(14, 13);
            this.radioButton9.TabIndex = 13;
            this.radioButton9.UseVisualStyleBackColor = false;
            this.radioButton9.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton6.Location = new System.Drawing.Point(370, 199);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(14, 13);
            this.radioButton6.TabIndex = 10;
            this.radioButton6.UseVisualStyleBackColor = false;
            this.radioButton6.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton10.Location = new System.Drawing.Point(342, 197);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(14, 13);
            this.radioButton10.TabIndex = 14;
            this.radioButton10.UseVisualStyleBackColor = false;
            this.radioButton10.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton14.Location = new System.Drawing.Point(405, 175);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(14, 13);
            this.radioButton14.TabIndex = 18;
            this.radioButton14.UseVisualStyleBackColor = false;
            this.radioButton14.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton14.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton13.Location = new System.Drawing.Point(403, 180);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(14, 13);
            this.radioButton13.TabIndex = 17;
            this.radioButton13.UseVisualStyleBackColor = false;
            this.radioButton13.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton13.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton12.Location = new System.Drawing.Point(397, 186);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(14, 13);
            this.radioButton12.TabIndex = 16;
            this.radioButton12.UseVisualStyleBackColor = false;
            this.radioButton12.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton12.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton11.Location = new System.Drawing.Point(334, 193);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(14, 13);
            this.radioButton11.TabIndex = 15;
            this.radioButton11.UseVisualStyleBackColor = false;
            this.radioButton11.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton11.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton8.Location = new System.Drawing.Point(390, 193);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(14, 13);
            this.radioButton8.TabIndex = 12;
            this.radioButton8.UseVisualStyleBackColor = false;
            this.radioButton8.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton7.Location = new System.Drawing.Point(381, 197);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(14, 13);
            this.radioButton7.TabIndex = 11;
            this.radioButton7.UseVisualStyleBackColor = false;
            this.radioButton7.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton4.Location = new System.Drawing.Point(327, 188);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(14, 13);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton4.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton3.Location = new System.Drawing.Point(320, 181);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.Control;
            this.radioButton2.Location = new System.Drawing.Point(317, 175);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.MouseEnter += new System.EventHandler(this.btnPlayer_MouseLeave);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(113, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 172);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(624, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 176);
            this.panel5.TabIndex = 31;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(113, 170);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(515, 5);
            this.panel6.TabIndex = 31;
            // 
            // TeamScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeamScreen";
            this.Text = "Team";
            this.Load += new System.EventHandler(this.TeamScreen_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTraining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
    }
}