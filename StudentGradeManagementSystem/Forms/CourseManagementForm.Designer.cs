namespace StudentGradeManagementSystem.Forms
{
    partial class CourseManagementForm
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
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.groupBoxCourseList = new System.Windows.Forms.GroupBox();
            this.groupBoxCourseDetails = new System.Windows.Forms.GroupBox();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numCredit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelRequired1 = new System.Windows.Forms.Label();
            this.labelRequired2 = new System.Windows.Forms.Label();
            this.labelRequired3 = new System.Windows.Forms.Label();
            this.labelRequired4 = new System.Windows.Forms.Label();
            this.labelRequired5 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.paginationControl = new StudentGradeManagementSystem.Controls.PaginationControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.groupBoxCourseList.SuspendLayout();
            this.groupBoxCourseDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCredit)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCourses.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewCourses.MultiSelect = false;
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.RowTemplate.Height = 23;
            this.dataGridViewCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCourses.Size = new System.Drawing.Size(778, 244);
            this.dataGridViewCourses.TabIndex = 0;
            this.dataGridViewCourses.SelectionChanged += new System.EventHandler(this.dataGridViewCourses_SelectionChanged);
            // 
            // txtCourseId
            // 
            this.txtCourseId.Location = new System.Drawing.Point(55, 22);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.Size = new System.Drawing.Size(200, 21);
            this.txtCourseId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "代码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 21);
            this.txtName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "名称：";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(55, 75);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(200, 21);
            this.txtType.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "类型：";
            // 
            // numCredit
            // 
            this.numCredit.Location = new System.Drawing.Point(55, 103);
            this.numCredit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCredit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCredit.Name = "numCredit";
            this.numCredit.Size = new System.Drawing.Size(200, 21);
            this.numCredit.TabIndex = 7;
            this.numCredit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "学分：";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(330, 48);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 20);
            this.cmbTeacher.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "教师：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(330, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "描述：";
            // 
            // labelRequired1
            // 
            this.labelRequired1.AutoSize = true;
            this.labelRequired1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired1.ForeColor = System.Drawing.Color.Red;
            this.labelRequired1.Location = new System.Drawing.Point(260, 25);
            this.labelRequired1.Name = "labelRequired1";
            this.labelRequired1.Size = new System.Drawing.Size(14, 14);
            this.labelRequired1.TabIndex = 14;
            this.labelRequired1.Text = "*";
            // 
            // labelRequired2
            // 
            this.labelRequired2.AutoSize = true;
            this.labelRequired2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired2.ForeColor = System.Drawing.Color.Red;
            this.labelRequired2.Location = new System.Drawing.Point(260, 51);
            this.labelRequired2.Name = "labelRequired2";
            this.labelRequired2.Size = new System.Drawing.Size(14, 14);
            this.labelRequired2.TabIndex = 15;
            this.labelRequired2.Text = "*";
            // 
            // labelRequired3
            // 
            this.labelRequired3.AutoSize = true;
            this.labelRequired3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired3.ForeColor = System.Drawing.Color.Red;
            this.labelRequired3.Location = new System.Drawing.Point(260, 78);
            this.labelRequired3.Name = "labelRequired3";
            this.labelRequired3.Size = new System.Drawing.Size(14, 14);
            this.labelRequired3.TabIndex = 16;
            this.labelRequired3.Text = "*";
            // 
            // labelRequired4
            // 
            this.labelRequired4.AutoSize = true;
            this.labelRequired4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired4.ForeColor = System.Drawing.Color.Red;
            this.labelRequired4.Location = new System.Drawing.Point(260, 105);
            this.labelRequired4.Name = "labelRequired4";
            this.labelRequired4.Size = new System.Drawing.Size(14, 14);
            this.labelRequired4.TabIndex = 17;
            this.labelRequired4.Text = "*";
            // 
            // labelRequired5
            // 
            this.labelRequired5.AutoSize = true;
            this.labelRequired5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired5.ForeColor = System.Drawing.Color.Red;
            this.labelRequired5.Location = new System.Drawing.Point(535, 51);
            this.labelRequired5.Name = "labelRequired5";
            this.labelRequired5.Size = new System.Drawing.Size(14, 14);
            this.labelRequired5.TabIndex = 18;
            this.labelRequired5.Text = "*";
            // 
            // groupBoxCourseList
            // 
            this.groupBoxCourseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCourseList.Controls.Add(this.dataGridViewCourses);
            this.groupBoxCourseList.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCourseList.Name = "groupBoxCourseList";
            this.groupBoxCourseList.Size = new System.Drawing.Size(784, 230);
            this.groupBoxCourseList.TabIndex = 1;
            this.groupBoxCourseList.TabStop = false;
            this.groupBoxCourseList.Text = "课程列表";
            // 
            // groupBoxCourseDetails
            // 
            this.groupBoxCourseDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCourseDetails.Controls.Add(this.cmbTeacher);
            this.groupBoxCourseDetails.Controls.Add(this.txtDescription);
            this.groupBoxCourseDetails.Controls.Add(this.txtType);
            this.groupBoxCourseDetails.Controls.Add(this.label7);
            this.groupBoxCourseDetails.Controls.Add(this.numCredit);
            this.groupBoxCourseDetails.Controls.Add(this.label6);
            this.groupBoxCourseDetails.Controls.Add(this.txtName);
            this.groupBoxCourseDetails.Controls.Add(this.label5);
            this.groupBoxCourseDetails.Controls.Add(this.txtCourseId);
            this.groupBoxCourseDetails.Controls.Add(this.label4);
            this.groupBoxCourseDetails.Controls.Add(this.label8);
            this.groupBoxCourseDetails.Controls.Add(this.label9);
            this.groupBoxCourseDetails.Controls.Add(this.labelRequired1);
            this.groupBoxCourseDetails.Controls.Add(this.labelRequired2);
            this.groupBoxCourseDetails.Controls.Add(this.labelRequired3);
            this.groupBoxCourseDetails.Controls.Add(this.labelRequired4);
            this.groupBoxCourseDetails.Controls.Add(this.labelRequired5);
            this.groupBoxCourseDetails.Enabled = false;
            this.groupBoxCourseDetails.Location = new System.Drawing.Point(12, 285);
            this.groupBoxCourseDetails.Name = "groupBoxCourseDetails";
            this.groupBoxCourseDetails.Size = new System.Drawing.Size(784, 150);
            this.groupBoxCourseDetails.TabIndex = 0;
            this.groupBoxCourseDetails.TabStop = false;
            this.groupBoxCourseDetails.Text = "课程信息";
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Location = new System.Drawing.Point(12, 440);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 45);
            this.panelButtons.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(489, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(327, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(60, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // paginationControl
            // 
            this.paginationControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paginationControl.CurrentPage = 1;
            this.paginationControl.Location = new System.Drawing.Point(12, 248);
            this.paginationControl.Name = "paginationControl";
            this.paginationControl.PageSize = 20;
            this.paginationControl.Size = new System.Drawing.Size(784, 35);
            this.paginationControl.TabIndex = 4;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 520);
            this.Controls.Add(this.paginationControl);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxCourseDetails);
            this.Controls.Add(this.groupBoxCourseList);
            this.Name = "CourseManagementForm";
            this.Text = "课程管理";
            this.Load += new System.EventHandler(this.CourseManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.groupBoxCourseList.ResumeLayout(false);
            this.groupBoxCourseDetails.ResumeLayout(false);
            this.groupBoxCourseDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCredit)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.GroupBox groupBoxCourseList;
        private System.Windows.Forms.GroupBox groupBoxCourseDetails;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numCredit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRequired1;
        private System.Windows.Forms.Label labelRequired2;
        private System.Windows.Forms.Label labelRequired3;
        private System.Windows.Forms.Label labelRequired4;
        private System.Windows.Forms.Label labelRequired5;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControl;
    }
}