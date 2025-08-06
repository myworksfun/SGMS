namespace StudentGradeManagementSystem.Controls
{
    partial class PaginationControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panelPagination = new Panel();
            lblTotalCount = new Label();
            btnFirstPage = new Button();
            btnPreviousPage = new Button();
            btnNextPage = new Button();
            btnLastPage = new Button();
            lblPageSize = new Label();
            txtPageSize = new TextBox();
            lblPageSeparator = new Label();
            txtPageNumber = new TextBox();
            lblPage = new Label();
            label1 = new Label();
            panelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // panelPagination
            // 
            panelPagination.Controls.Add(label1);
            panelPagination.Controls.Add(lblTotalCount);
            panelPagination.Controls.Add(btnFirstPage);
            panelPagination.Controls.Add(btnPreviousPage);
            panelPagination.Controls.Add(btnNextPage);
            panelPagination.Controls.Add(btnLastPage);
            panelPagination.Controls.Add(lblPageSize);
            panelPagination.Controls.Add(txtPageSize);
            panelPagination.Controls.Add(lblPageSeparator);
            panelPagination.Controls.Add(txtPageNumber);
            panelPagination.Controls.Add(lblPage);
            panelPagination.Dock = DockStyle.Fill;
            panelPagination.Location = new Point(0, 0);
            panelPagination.Margin = new Padding(4, 4, 4, 4);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(915, 50);
            panelPagination.TabIndex = 0;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(571, 20);
            lblTotalCount.Margin = new Padding(4, 0, 4, 0);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(93, 17);
            lblTotalCount.TabIndex = 11;
            lblTotalCount.Text = "🔔: 共 0 条记录";
            lblTotalCount.TextAlign = ContentAlignment.MiddleCenter;
            lblTotalCount.Visible = false;
            lblTotalCount.Click += lblTotalCount_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Location = new Point(12, 11);
            btnFirstPage.Margin = new Padding(4, 4, 4, 4);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(58, 33);
            btnFirstPage.TabIndex = 5;
            btnFirstPage.Text = "首页";
            btnFirstPage.UseVisualStyleBackColor = true;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(82, 11);
            btnPreviousPage.Margin = new Padding(4, 4, 4, 4);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(70, 33);
            btnPreviousPage.TabIndex = 6;
            btnPreviousPage.Text = "◀ 上一页";
            btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(163, 11);
            btnNextPage.Margin = new Padding(4, 4, 4, 4);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(70, 33);
            btnNextPage.TabIndex = 7;
            btnNextPage.Text = "下一页 ▶";
            btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnLastPage
            // 
            btnLastPage.Location = new Point(245, 11);
            btnLastPage.Margin = new Padding(4, 4, 4, 4);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(58, 33);
            btnLastPage.TabIndex = 8;
            btnLastPage.Text = "末页";
            btnLastPage.UseVisualStyleBackColor = true;
            // 
            // lblPageSize
            // 
            lblPageSize.AutoSize = true;
            lblPageSize.Location = new Point(321, 20);
            lblPageSize.Margin = new Padding(4, 0, 4, 0);
            lblPageSize.Name = "lblPageSize";
            lblPageSize.Size = new Size(35, 17);
            lblPageSize.TabIndex = 3;
            lblPageSize.Text = "每页:";
            // 
            // txtPageSize
            // 
            txtPageSize.Location = new Point(356, 17);
            txtPageSize.Margin = new Padding(4, 4, 4, 4);
            txtPageSize.Name = "txtPageSize";
            txtPageSize.Size = new Size(47, 23);
            txtPageSize.TabIndex = 4;
            txtPageSize.Text = "20";
            txtPageSize.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPageSeparator
            // 
            lblPageSeparator.AutoSize = true;
            lblPageSeparator.Location = new Point(450, 20);
            lblPageSeparator.Margin = new Padding(4, 0, 4, 0);
            lblPageSeparator.Name = "lblPageSeparator";
            lblPageSeparator.Size = new Size(20, 17);
            lblPageSeparator.TabIndex = 1;
            lblPageSeparator.Text = "第";
            // 
            // txtPageNumber
            // 
            txtPageNumber.Location = new Point(473, 15);
            txtPageNumber.Margin = new Padding(4, 4, 4, 4);
            txtPageNumber.Name = "txtPageNumber";
            txtPageNumber.Size = new Size(34, 23);
            txtPageNumber.TabIndex = 2;
            txtPageNumber.Text = "1";
            txtPageNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(514, 20);
            lblPage.Margin = new Padding(4, 0, 4, 0);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(20, 17);
            lblPage.TabIndex = 0;
            lblPage.Text = "页";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(408, 20);
            label1.Name = "label1";
            label1.Size = new Size(20, 17);
            label1.TabIndex = 12;
            label1.Text = "条";
            label1.Click += label1_Click;
            // 
            // PaginationControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPagination);
            Margin = new Padding(4, 4, 4, 4);
            Name = "PaginationControl";
            Size = new Size(915, 50);
            panelPagination.ResumeLayout(false);
            panelPagination.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Label lblPageSeparator;
        private System.Windows.Forms.Label lblPage;
        private Label label1;
    }
}