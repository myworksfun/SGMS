namespace StudentGradeManagementSystem.Forms
{
    partial class LogManagementForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUserLogs = new System.Windows.Forms.TabPage();
            this.dataGridViewUserLogs = new System.Windows.Forms.DataGridView();
            this.tabPageSystemLogs = new System.Windows.Forms.TabPage();
            this.dataGridViewSystemLogs = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.paginationControlUserLogs = new StudentGradeManagementSystem.Controls.PaginationControl();
            this.paginationControlSystemLogs = new StudentGradeManagementSystem.Controls.PaginationControl();
            this.tabControl1.SuspendLayout();
            this.tabPageUserLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserLogs)).BeginInit();
            this.tabPageSystemLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystemLogs)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageUserLogs);
            this.tabControl1.Controls.Add(this.tabPageSystemLogs);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageUserLogs
            // 
            this.tabPageUserLogs.Controls.Add(this.paginationControlUserLogs);
            this.tabPageUserLogs.Controls.Add(this.dataGridViewUserLogs);
            this.tabPageUserLogs.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserLogs.Name = "tabPageUserLogs";
            this.tabPageUserLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserLogs.Size = new System.Drawing.Size(776, 411);
            this.tabPageUserLogs.TabIndex = 0;
            this.tabPageUserLogs.Text = "用户日志";
            this.tabPageUserLogs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUserLogs
            // 
            this.dataGridViewUserLogs.AllowUserToAddRows = false;
            this.dataGridViewUserLogs.AllowUserToDeleteRows = false;
            this.dataGridViewUserLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserLogs.Dock = System.Windows.Forms.DockStyle.None;
            this.dataGridViewUserLogs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewUserLogs.MultiSelect = true;
            this.dataGridViewUserLogs.Name = "dataGridViewUserLogs";
            this.dataGridViewUserLogs.ReadOnly = true;
            this.dataGridViewUserLogs.RowTemplate.Height = 23;
            this.dataGridViewUserLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserLogs.Size = new System.Drawing.Size(770, 350);
            this.dataGridViewUserLogs.TabIndex = 0;
            // 
            // tabPageSystemLogs
            // 
            this.tabPageSystemLogs.Controls.Add(this.paginationControlSystemLogs);
            this.tabPageSystemLogs.Controls.Add(this.dataGridViewSystemLogs);
            this.tabPageSystemLogs.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystemLogs.Name = "tabPageSystemLogs";
            this.tabPageSystemLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystemLogs.Size = new System.Drawing.Size(776, 411);
            this.tabPageSystemLogs.TabIndex = 1;
            this.tabPageSystemLogs.Text = "系统日志";
            this.tabPageSystemLogs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSystemLogs
            // 
            this.dataGridViewSystemLogs.AllowUserToAddRows = false;
            this.dataGridViewSystemLogs.AllowUserToDeleteRows = false;
            this.dataGridViewSystemLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSystemLogs.Dock = System.Windows.Forms.DockStyle.None;
            this.dataGridViewSystemLogs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSystemLogs.MultiSelect = true;
            this.dataGridViewSystemLogs.Name = "dataGridViewSystemLogs";
            this.dataGridViewSystemLogs.ReadOnly = true;
            this.dataGridViewSystemLogs.RowTemplate.Height = 23;
            this.dataGridViewSystemLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSystemLogs.Size = new System.Drawing.Size(770, 350);
            this.dataGridViewSystemLogs.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Location = new System.Drawing.Point(12, 455);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 45);
            this.panelButtons.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(616, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(535, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(697, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(808, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // paginationControlUserLogs
            // 
            this.paginationControlUserLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paginationControlUserLogs.CurrentPage = 1;
            this.paginationControlUserLogs.Location = new System.Drawing.Point(3, 356);
            this.paginationControlUserLogs.Name = "paginationControlUserLogs";
            this.paginationControlUserLogs.PageSize = 30;
            this.paginationControlUserLogs.Size = new System.Drawing.Size(770, 35);
            this.paginationControlUserLogs.TabIndex = 1;
            // 
            // paginationControlSystemLogs
            // 
            this.paginationControlSystemLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paginationControlSystemLogs.CurrentPage = 1;
            this.paginationControlSystemLogs.Location = new System.Drawing.Point(3, 356);
            this.paginationControlSystemLogs.Name = "paginationControlSystemLogs";
            this.paginationControlSystemLogs.PageSize = 30;
            this.paginationControlSystemLogs.Size = new System.Drawing.Size(770, 35);
            this.paginationControlSystemLogs.TabIndex = 1;
            // 
            // LogManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 512);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.tabControl1);
            this.Name = "LogManagementForm";
            this.Text = "日志管理";
            this.Load += new System.EventHandler(this.LogManagementForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUserLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserLogs)).EndInit();
            this.tabPageSystemLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystemLogs)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUserLogs;
        private System.Windows.Forms.DataGridView dataGridViewUserLogs;
        private System.Windows.Forms.TabPage tabPageSystemLogs;
        private System.Windows.Forms.DataGridView dataGridViewSystemLogs;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnDelete;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControlUserLogs;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControlSystemLogs;
    }
}