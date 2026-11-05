namespace TimeTracking.Presentation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.panelFortnight = new System.Windows.Forms.Panel();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblFortnight = new System.Windows.Forms.Label();
            this.dgvHours = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTotalHours = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrevFortnight = new System.Windows.Forms.Button();
            this.btnNextFortnight = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelFortnight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 178);
            this.panelHeader.Controls.Add(this.btnSignOut);
            this.panelHeader.Controls.Add(this.btnHelp);
            this.panelHeader.Controls.Add(this.lblCurrentDate);
            this.panelHeader.Controls.Add(this.lblUserName);
            this.panelHeader.Controls.Add(this.lblAppTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignOut.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSignOut.ForeColor = System.Drawing.Color.White;
            this.btnSignOut.Location = new System.Drawing.Point(1000, 20);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(85, 30);
            this.btnSignOut.TabIndex = 4;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(910, 20);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 30);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblCurrentDate.Location = new System.Drawing.Point(200, 40);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(100, 19);
            this.lblCurrentDate.TabIndex = 2;
            this.lblCurrentDate.Text = "Current date";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(200, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 21);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(12, 18);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(170, 30);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "Time Tracking";
            // 
            // panelFortnight
            // 
            this.panelFortnight.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelFortnight.Controls.Add(this.btnAddAccount);
            this.panelFortnight.Controls.Add(this.btnNextFortnight);
            this.panelFortnight.Controls.Add(this.btnPrevFortnight);
            this.panelFortnight.Controls.Add(this.lblFortnight);
            this.panelFortnight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFortnight.Location = new System.Drawing.Point(0, 70);
            this.panelFortnight.Name = "panelFortnight";
            this.panelFortnight.Size = new System.Drawing.Size(1100, 45);
            this.panelFortnight.TabIndex = 1;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAccount.BackColor = System.Drawing.Color.FromArgb(40, 150, 40);
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddAccount.ForeColor = System.Drawing.Color.White;
            this.btnAddAccount.Location = new System.Drawing.Point(940, 8);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(145, 30);
            this.btnAddAccount.TabIndex = 1;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = false;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnPrevFortnight
            // 
            this.btnPrevFortnight.BackColor = System.Drawing.Color.FromArgb(0, 102, 178);
            this.btnPrevFortnight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevFortnight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevFortnight.ForeColor = System.Drawing.Color.White;
            this.btnPrevFortnight.Location = new System.Drawing.Point(15, 8);
            this.btnPrevFortnight.Name = "btnPrevFortnight";
            this.btnPrevFortnight.Size = new System.Drawing.Size(35, 30);
            this.btnPrevFortnight.TabIndex = 2;
            this.btnPrevFortnight.Text = "◀";
            this.btnPrevFortnight.UseVisualStyleBackColor = false;
            this.btnPrevFortnight.Click += new System.EventHandler(this.btnPrevFortnight_Click);
            // 
            // btnNextFortnight
            // 
            this.btnNextFortnight.BackColor = System.Drawing.Color.FromArgb(0, 102, 178);
            this.btnNextFortnight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextFortnight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextFortnight.ForeColor = System.Drawing.Color.White;
            this.btnNextFortnight.Location = new System.Drawing.Point(55, 8);
            this.btnNextFortnight.Name = "btnNextFortnight";
            this.btnNextFortnight.Size = new System.Drawing.Size(35, 30);
            this.btnNextFortnight.TabIndex = 3;
            this.btnNextFortnight.Text = "▶";
            this.btnNextFortnight.UseVisualStyleBackColor = false;
            this.btnNextFortnight.Click += new System.EventHandler(this.btnNextFortnight_Click);
            // 
            // lblFortnight
            // 
            this.lblFortnight.AutoSize = true;
            this.lblFortnight.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFortnight.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblFortnight.Location = new System.Drawing.Point(100, 12);
            this.lblFortnight.Name = "lblFortnight";
            this.lblFortnight.Size = new System.Drawing.Size(150, 20);
            this.lblFortnight.TabIndex = 0;
            this.lblFortnight.Text = "Current fortnight";
            // 
            // dgvHours
            // 
            this.dgvHours.AllowUserToAddRows = false;
            this.dgvHours.AllowUserToDeleteRows = false;
            this.dgvHours.BackgroundColor = System.Drawing.Color.White;
            this.dgvHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHours.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHours.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHours.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvHours.Location = new System.Drawing.Point(0, 115);
            this.dgvHours.Name = "dgvHours";
            this.dgvHours.RowHeadersVisible = false;
            this.dgvHours.Size = new System.Drawing.Size(1100, 430);
            this.dgvHours.TabIndex = 2;
            this.dgvHours.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHours_CellValueChanged);
            this.dgvHours.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvHours_CellValidating);
            this.dgvHours.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvHours_CurrentCellDirtyStateChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalHours});
            this.statusStrip.Location = new System.Drawing.Point(0, 545);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(150, 17);
            this.lblTotalHours.Text = "Fortnight total: 0 hours";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 567);
            this.Controls.Add(this.dgvHours);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelFortnight);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Tracking";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFortnight.ResumeLayout(false);
            this.panelFortnight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Panel panelFortnight;
        private System.Windows.Forms.Label lblFortnight;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnPrevFortnight;
        private System.Windows.Forms.Button btnNextFortnight;
        private System.Windows.Forms.DataGridView dgvHours;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalHours;
    }
}
