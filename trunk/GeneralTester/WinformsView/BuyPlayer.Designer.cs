namespace HatTrick.Views.WinformsView
{
    partial class BuyPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyPlayer));
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.SelectPlayer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTeamCash = new System.Windows.Forms.Label();
            this.lblMoneyNeeded = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToResizeColumns = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlayers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectPlayer});
            this.dgvPlayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPlayers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlayers.Location = new System.Drawing.Point(0, 0);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(906, 279);
            this.dgvPlayers.TabIndex = 0;
            this.dgvPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellClick_1);
            // 
            // SelectPlayer
            // 
            this.SelectPlayer.HeaderText = "#";
            this.SelectPlayer.Name = "SelectPlayer";
            this.SelectPlayer.ReadOnly = true;
            this.SelectPlayer.Width = 20;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(12, 340);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 1;
            this.btnBuy.Text = "Buy Players!";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(819, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTeamCash
            // 
            this.lblTeamCash.AutoSize = true;
            this.lblTeamCash.Location = new System.Drawing.Point(12, 297);
            this.lblTeamCash.Name = "lblTeamCash";
            this.lblTeamCash.Size = new System.Drawing.Size(35, 13);
            this.lblTeamCash.TabIndex = 3;
            this.lblTeamCash.Text = "label1";
            // 
            // lblMoneyNeeded
            // 
            this.lblMoneyNeeded.AutoSize = true;
            this.lblMoneyNeeded.Location = new System.Drawing.Point(12, 324);
            this.lblMoneyNeeded.Name = "lblMoneyNeeded";
            this.lblMoneyNeeded.Size = new System.Drawing.Size(195, 13);
            this.lblMoneyNeeded.TabIndex = 4;
            this.lblMoneyNeeded.Text = "Money needed to buy selected players: ";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMoney.Location = new System.Drawing.Point(202, 324);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(21, 13);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Text = "0$";
            // 
            // BuyPlayer
            // 
            this.AcceptButton = this.btnBuy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(906, 369);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.lblMoneyNeeded);
            this.Controls.Add(this.lblTeamCash);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.dgvPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuyPlayer";
            this.Text = "Players for sale";
            this.Load += new System.EventHandler(this.BuyPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectPlayer;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTeamCash;
        private System.Windows.Forms.Label lblMoneyNeeded;
        private System.Windows.Forms.Label lblMoney;
    }
}