namespace StudentGradeManagementSystem.Forms
{
    partial class StudentManagementForm
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
            dataGridViewStudents = new DataGridView();
            groupBoxStudentList = new GroupBox();
            groupBoxStudentDetails = new GroupBox();
            panelStudentDetails = new TableLayoutPanel();
            label1 = new AntdUI.Label();
            txtStudentId = new AntdUI.TextBox();
            labelRequired1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            txtName = new AntdUI.TextBox();
            labelRequired2 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            cmbGender = new ComboBox();
            labelRequired3 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            numAge = new NumericUpDown();
            labelRequired4 = new AntdUI.Label();
            label9 = new AntdUI.Label();
            dtpEnrollmentDate = new DateTimePicker();
            labelRequired7 = new AntdUI.Label();
            label5 = new AntdUI.Label();
            txtClass = new AntdUI.TextBox();
            labelRequired5 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            txtMajor = new AntdUI.TextBox();
            labelRequired6 = new AntdUI.Label();
            label7 = new AntdUI.Label();
            txtPhone = new AntdUI.TextBox();
            label8 = new AntdUI.Label();
            txtEmail = new AntdUI.TextBox();
            panelButtons = new AntdUI.Panel();
            btnExport = new AntdUI.Button();
            btnCancel = new AntdUI.Button();
            btnRefresh = new AntdUI.Button();
            btnSave = new AntdUI.Button();
            btnDelete = new AntdUI.Button();
            btnEdit = new AntdUI.Button();
            btnAdd = new AntdUI.Button();
            btnImport = new AntdUI.Button();
            paginationControl = new StudentGradeManagementSystem.Controls.PaginationControl();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            groupBoxStudentList.SuspendLayout();
            groupBoxStudentDetails.SuspendLayout();
            panelStudentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AccessibleRole = AccessibleRole.None;
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
            dataGridViewStudents.BackgroundColor = SystemColors.ControlLight;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Dock = DockStyle.Fill;
            dataGridViewStudents.Location = new Point(4, 20);
            dataGridViewStudents.Margin = new Padding(4);
            dataGridViewStudents.MultiSelect = false;
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.RowTemplate.Height = 23;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(907, 316);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
            // 
            // groupBoxStudentList
            // 
            groupBoxStudentList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxStudentList.Controls.Add(dataGridViewStudents);
            groupBoxStudentList.Location = new Point(14, 17);
            groupBoxStudentList.Margin = new Padding(4);
            groupBoxStudentList.Name = "groupBoxStudentList";
            groupBoxStudentList.Padding = new Padding(4);
            groupBoxStudentList.Size = new Size(915, 340);
            groupBoxStudentList.TabIndex = 1;
            groupBoxStudentList.TabStop = false;
            groupBoxStudentList.Text = "学生列表";
            // 
            // groupBoxStudentDetails
            // 
            groupBoxStudentDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxStudentDetails.Controls.Add(panelStudentDetails);
            groupBoxStudentDetails.Enabled = false;
            groupBoxStudentDetails.Location = new Point(18, 426);
            groupBoxStudentDetails.Margin = new Padding(4);
            groupBoxStudentDetails.Name = "groupBoxStudentDetails";
            groupBoxStudentDetails.Padding = new Padding(4);
            groupBoxStudentDetails.Size = new Size(915, 283);
            groupBoxStudentDetails.TabIndex = 0;
            groupBoxStudentDetails.TabStop = false;
            groupBoxStudentDetails.Text = "✍学生信息";
            // 
            // panelStudentDetails
            // 
            panelStudentDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelStudentDetails.ColumnCount = 4;
            panelStudentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            panelStudentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelStudentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 327F));
            panelStudentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelStudentDetails.Controls.Add(label1, 0, 0);
            panelStudentDetails.Controls.Add(txtStudentId, 1, 0);
            panelStudentDetails.Controls.Add(labelRequired1, 1, 0);
            panelStudentDetails.Controls.Add(label2, 0, 1);
            panelStudentDetails.Controls.Add(txtName, 1, 1);
            panelStudentDetails.Controls.Add(labelRequired2, 1, 1);
            panelStudentDetails.Controls.Add(label3, 0, 2);
            panelStudentDetails.Controls.Add(cmbGender, 1, 2);
            panelStudentDetails.Controls.Add(labelRequired3, 1, 2);
            panelStudentDetails.Controls.Add(label4, 0, 3);
            panelStudentDetails.Controls.Add(numAge, 1, 3);
            panelStudentDetails.Controls.Add(labelRequired4, 1, 3);
            panelStudentDetails.Controls.Add(label9, 0, 4);
            panelStudentDetails.Controls.Add(dtpEnrollmentDate, 1, 4);
            panelStudentDetails.Controls.Add(labelRequired7, 1, 4);
            panelStudentDetails.Controls.Add(label5, 2, 1);
            panelStudentDetails.Controls.Add(txtClass, 3, 1);
            panelStudentDetails.Controls.Add(labelRequired5, 3, 1);
            panelStudentDetails.Controls.Add(label6, 2, 2);
            panelStudentDetails.Controls.Add(txtMajor, 3, 2);
            panelStudentDetails.Controls.Add(labelRequired6, 3, 2);
            panelStudentDetails.Controls.Add(label7, 2, 3);
            panelStudentDetails.Controls.Add(txtPhone, 3, 3);
            panelStudentDetails.Controls.Add(label8, 2, 4);
            panelStudentDetails.Controls.Add(txtEmail, 3, 4);
            panelStudentDetails.Location = new Point(6, 28);
            panelStudentDetails.Margin = new Padding(4);
            panelStudentDetails.Name = "panelStudentDetails";
            panelStudentDetails.RowCount = 5;
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelStudentDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelStudentDetails.Size = new Size(901, 280);
            panelStudentDetails.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 42);
            label1.TabIndex = 0;
            label1.Text = "学号：";
            // 
            // txtStudentId
            // 
            txtStudentId.Dock = DockStyle.Fill;
            txtStudentId.Location = new Point(334, 4);
            txtStudentId.Margin = new Padding(4);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(319, 23);
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += txtStudentId_TextChanged;
            // 
            // labelRequired1
            // 
            labelRequired1.AutoSize = true;
            labelRequired1.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired1.ForeColor = Color.Red;
            labelRequired1.Location = new Point(90, 0);
            labelRequired1.Margin = new Padding(4, 0, 4, 0);
            labelRequired1.Name = "labelRequired1";
            labelRequired1.Size = new Size(14, 14);
            labelRequired1.TabIndex = 17;
            labelRequired1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(4, 42);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 42);
            label2.TabIndex = 2;
            label2.Text = "姓名：";
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(334, 46);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 23);
            txtName.TabIndex = 3;
            // 
            // labelRequired2
            // 
            labelRequired2.AutoSize = true;
            labelRequired2.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired2.ForeColor = Color.Red;
            labelRequired2.Location = new Point(90, 42);
            labelRequired2.Margin = new Padding(4, 0, 4, 0);
            labelRequired2.Name = "labelRequired2";
            labelRequired2.Size = new Size(14, 14);
            labelRequired2.TabIndex = 18;
            labelRequired2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(334, 84);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(319, 42);
            label3.TabIndex = 4;
            label3.Text = "性别：";
            // 
            // cmbGender
            // 
            cmbGender.Dock = DockStyle.Fill;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "男", "女" });
            cmbGender.Location = new Point(661, 88);
            cmbGender.Margin = new Padding(4);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(236, 25);
            cmbGender.TabIndex = 5;
            // 
            // labelRequired3
            // 
            labelRequired3.AutoSize = true;
            labelRequired3.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired3.ForeColor = Color.Red;
            labelRequired3.Location = new Point(4, 126);
            labelRequired3.Margin = new Padding(4, 0, 4, 0);
            labelRequired3.Name = "labelRequired3";
            labelRequired3.Size = new Size(14, 14);
            labelRequired3.TabIndex = 19;
            labelRequired3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(4, 172);
            label4.Margin = new Padding(4, 4, 4, 14);
            label4.Name = "label4";
            label4.Size = new Size(78, 24);
            label4.TabIndex = 6;
            label4.Text = "年龄：";
            // 
            // numAge
            // 
            numAge.Dock = DockStyle.Fill;
            numAge.Location = new Point(90, 172);
            numAge.Margin = new Padding(4, 4, 4, 14);
            numAge.Maximum = new decimal(new int[] { 150, 0, 0, 0 });
            numAge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(236, 23);
            numAge.TabIndex = 7;
            numAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // labelRequired4
            // 
            labelRequired4.AutoSize = true;
            labelRequired4.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired4.ForeColor = Color.Red;
            labelRequired4.Location = new Point(334, 168);
            labelRequired4.Margin = new Padding(4, 0, 4, 0);
            labelRequired4.Name = "labelRequired4";
            labelRequired4.Size = new Size(14, 14);
            labelRequired4.TabIndex = 20;
            labelRequired4.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(90, 210);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(236, 20);
            label9.TabIndex = 16;
            label9.Text = "入学日期：";
            // 
            // dtpEnrollmentDate
            // 
            dtpEnrollmentDate.CustomFormat = "yyyy-MM-dd";
            dtpEnrollmentDate.Dock = DockStyle.Fill;
            dtpEnrollmentDate.Format = DateTimePickerFormat.Custom;
            dtpEnrollmentDate.Location = new Point(661, 214);
            dtpEnrollmentDate.Margin = new Padding(4);
            dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            dtpEnrollmentDate.Size = new Size(236, 23);
            dtpEnrollmentDate.TabIndex = 17;
            // 
            // labelRequired7
            // 
            labelRequired7.AutoSize = true;
            labelRequired7.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired7.ForeColor = Color.Red;
            labelRequired7.Location = new Point(334, 210);
            labelRequired7.Margin = new Padding(4, 0, 4, 0);
            labelRequired7.Name = "labelRequired7";
            labelRequired7.Size = new Size(14, 14);
            labelRequired7.TabIndex = 23;
            labelRequired7.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(661, 46);
            label5.Margin = new Padding(4, 4, 4, 14);
            label5.Name = "label5";
            label5.Size = new Size(236, 24);
            label5.TabIndex = 8;
            label5.Text = "班级：";
            // 
            // txtClass
            // 
            txtClass.Dock = DockStyle.Fill;
            txtClass.Location = new Point(90, 88);
            txtClass.Margin = new Padding(4, 4, 4, 14);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(236, 23);
            txtClass.TabIndex = 9;
            // 
            // labelRequired5
            // 
            labelRequired5.AutoSize = true;
            labelRequired5.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired5.ForeColor = Color.Red;
            labelRequired5.Location = new Point(4, 84);
            labelRequired5.Margin = new Padding(4, 0, 4, 0);
            labelRequired5.Name = "labelRequired5";
            labelRequired5.Size = new Size(14, 14);
            labelRequired5.TabIndex = 21;
            labelRequired5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(90, 130);
            label6.Margin = new Padding(4, 4, 4, 14);
            label6.Name = "label6";
            label6.Size = new Size(236, 24);
            label6.TabIndex = 10;
            label6.Text = "专业：";
            // 
            // txtMajor
            // 
            txtMajor.Dock = DockStyle.Fill;
            txtMajor.Location = new Point(661, 130);
            txtMajor.Margin = new Padding(4, 4, 4, 14);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(236, 23);
            txtMajor.TabIndex = 11;
            // 
            // labelRequired6
            // 
            labelRequired6.AutoSize = true;
            labelRequired6.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelRequired6.ForeColor = Color.Red;
            labelRequired6.Location = new Point(334, 126);
            labelRequired6.Margin = new Padding(4, 0, 4, 0);
            labelRequired6.Name = "labelRequired6";
            labelRequired6.Size = new Size(14, 14);
            labelRequired6.TabIndex = 22;
            labelRequired6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(661, 172);
            label7.Margin = new Padding(4, 4, 4, 14);
            label7.Name = "label7";
            label7.Size = new Size(236, 24);
            label7.TabIndex = 12;
            label7.Text = "电话：";
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Location = new Point(4, 214);
            txtPhone.Margin = new Padding(4, 4, 4, 14);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(78, 23);
            txtPhone.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(4, 234);
            label8.Margin = new Padding(4, 4, 4, 14);
            label8.Name = "label8";
            label8.Size = new Size(78, 32);
            label8.TabIndex = 14;
            label8.Text = "邮箱：";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(90, 234);
            txtEmail.Margin = new Padding(4, 4, 4, 14);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(236, 23);
            txtEmail.TabIndex = 15;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnExport);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnRefresh);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnImport);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 742);
            panelButtons.Margin = new Padding(4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(943, 66);
            panelButtons.TabIndex = 3;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(728, 14);
            btnExport.Margin = new Padding(4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(88, 33);
            btnExport.TabIndex = 7;
            btnExport.Text = "导出";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(824, 14);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 33);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(536, 14);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 33);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "刷新🔄";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(283, 14);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(187, 14);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 33);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(95, 14);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(88, 33);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "编辑";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 14);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 33);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(632, 14);
            btnImport.Margin = new Padding(4);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(88, 33);
            btnImport.TabIndex = 1;
            btnImport.Text = "导入";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // paginationControl
            // 
            paginationControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            paginationControl.CurrentPage = 1;
            paginationControl.Location = new Point(14, 363);
            paginationControl.Margin = new Padding(5, 6, 5, 6);
            paginationControl.Name = "paginationControl";
            paginationControl.PageSize = 20;
            paginationControl.Size = new Size(915, 50);
            paginationControl.TabIndex = 4;
            paginationControl.TotalItems = 0;
            paginationControl.Load += paginationControl_Load;
            // 
            // StudentManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 808);
            Controls.Add(paginationControl);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxStudentDetails);
            Controls.Add(groupBoxStudentList);
            Margin = new Padding(4);
            Name = "StudentManagementForm";
            Text = "学生管理";
            Load += StudentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            groupBoxStudentList.ResumeLayout(false);
            groupBoxStudentDetails.ResumeLayout(false);
            panelStudentDetails.ResumeLayout(false);
            panelStudentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.GroupBox groupBoxStudentList;
        private System.Windows.Forms.GroupBox groupBoxStudentDetails;
        private System.Windows.Forms.TableLayoutPanel panelStudentDetails;
        private AntdUI.Label label1;
        private AntdUI.TextBox txtStudentId;
        private AntdUI.Label label2;
        private AntdUI.TextBox txtName;
        private AntdUI.Label label3;
        private System.Windows.Forms.ComboBox cmbGender;
        private AntdUI.Label label4;
        private System.Windows.Forms.NumericUpDown numAge;
        private AntdUI.Label label5;
        private AntdUI.TextBox txtClass;
        private AntdUI.Label label6;
        private AntdUI.TextBox txtMajor;
        private AntdUI.Label label7;
        private AntdUI.TextBox txtPhone;
        private AntdUI.Label label8;
        private AntdUI.TextBox txtEmail;
        private AntdUI.Label labelRequired1;
        private AntdUI.Label labelRequired2;
        private AntdUI.Label labelRequired3;
        private AntdUI.Label labelRequired4;
        private AntdUI.Label labelRequired5;
        private AntdUI.Label labelRequired6;
        private AntdUI.Panel panelButtons;
        private AntdUI.Button btnExport;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnSave;
        private AntdUI.Button btnDelete;
        private AntdUI.Button btnEdit;
        private AntdUI.Button btnAdd;
        private AntdUI.Button btnImport;
        private AntdUI.Button btnRefresh;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControl;
        private System.Windows.Forms.DateTimePicker dtpEnrollmentDate;
        private AntdUI.Label label9;
        private AntdUI.Label labelRequired7;
    }
}