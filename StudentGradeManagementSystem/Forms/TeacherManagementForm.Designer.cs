namespace StudentGradeManagementSystem.Forms
{
    partial class TeacherManagementForm
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
            this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
            this.groupBoxTeacherList = new System.Windows.Forms.GroupBox();
            this.groupBoxTeacherDetails = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeacherId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRequired1 = new System.Windows.Forms.Label();
            this.labelRequired2 = new System.Windows.Forms.Label();
            this.labelRequired3 = new System.Windows.Forms.Label();
            this.labelRequired4 = new System.Windows.Forms.Label();
            this.labelRequired5 = new System.Windows.Forms.Label();
            this.labelRequired6 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.paginationControl = new StudentGradeManagementSystem.Controls.PaginationControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
            this.groupBoxTeacherList.SuspendLayout();
            this.groupBoxTeacherDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTeachers
            // 
            this.dataGridViewTeachers.AllowUserToAddRows = false;
            this.dataGridViewTeachers.AllowUserToDeleteRows = false;
            this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTeachers.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewTeachers.MultiSelect = false;
            this.dataGridViewTeachers.Name = "dataGridViewTeachers";
            this.dataGridViewTeachers.ReadOnly = true;
            this.dataGridViewTeachers.RowTemplate.Height = 23;
            this.dataGridViewTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeachers.Size = new System.Drawing.Size(778, 244);
            this.dataGridViewTeachers.TabIndex = 0;
            this.dataGridViewTeachers.SelectionChanged += new System.EventHandler(this.dataGridViewTeachers_SelectionChanged);
            // 
            // groupBoxTeacherList
            // 
            this.groupBoxTeacherList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTeacherList.Controls.Add(this.dataGridViewTeachers);
            this.groupBoxTeacherList.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTeacherList.Name = "groupBoxTeacherList";
            this.groupBoxTeacherList.Size = new System.Drawing.Size(784, 230);
            this.groupBoxTeacherList.TabIndex = 0;
            this.groupBoxTeacherList.TabStop = false;
            this.groupBoxTeacherList.Text = "教师列表";
            // 
            // groupBoxTeacherDetails
            // 
            this.groupBoxTeacherDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired6);
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired5);
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired4);
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired3);
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired2);
            this.groupBoxTeacherDetails.Controls.Add(this.labelRequired1);
            this.groupBoxTeacherDetails.Controls.Add(this.txtEmail);
            this.groupBoxTeacherDetails.Controls.Add(this.label8);
            this.groupBoxTeacherDetails.Controls.Add(this.txtPhone);
            this.groupBoxTeacherDetails.Controls.Add(this.label7);
            this.groupBoxTeacherDetails.Controls.Add(this.txtTitle);
            this.groupBoxTeacherDetails.Controls.Add(this.label6);
            this.groupBoxTeacherDetails.Controls.Add(this.txtDepartment);
            this.groupBoxTeacherDetails.Controls.Add(this.label5);
            this.groupBoxTeacherDetails.Controls.Add(this.numAge);
            this.groupBoxTeacherDetails.Controls.Add(this.label4);
            this.groupBoxTeacherDetails.Controls.Add(this.cmbGender);
            this.groupBoxTeacherDetails.Controls.Add(this.label3);
            this.groupBoxTeacherDetails.Controls.Add(this.txtName);
            this.groupBoxTeacherDetails.Controls.Add(this.label2);
            this.groupBoxTeacherDetails.Controls.Add(this.txtTeacherId);
            this.groupBoxTeacherDetails.Controls.Add(this.label1);
            this.groupBoxTeacherDetails.Enabled = false;
            this.groupBoxTeacherDetails.Location = new System.Drawing.Point(12, 285);
            this.groupBoxTeacherDetails.Name = "groupBoxTeacherDetails";
            this.groupBoxTeacherDetails.Size = new System.Drawing.Size(784, 150);
            this.groupBoxTeacherDetails.TabIndex = 2;
            this.groupBoxTeacherDetails.TabStop = false;
            this.groupBoxTeacherDetails.Text = "教师详情";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(445, 75);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 21);
            this.txtEmail.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "邮箱：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(445, 48);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 21);
            this.txtPhone.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "电话：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(445, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 21);
            this.txtTitle.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "职称：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(55, 129);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(200, 21);
            this.txtDepartment.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "部门：";
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(55, 102);
            this.numAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(200, 21);
            this.numAge.TabIndex = 7;
            this.numAge.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "年龄：";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cmbGender.Location = new System.Drawing.Point(55, 75);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 20);
            this.cmbGender.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 21);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // txtTeacherId
            // 
            this.txtTeacherId.Location = new System.Drawing.Point(55, 20);
            this.txtTeacherId.Name = "txtTeacherId";
            this.txtTeacherId.Size = new System.Drawing.Size(200, 21);
            this.txtTeacherId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工号：";
            // 
            // labelRequired1
            // 
            this.labelRequired1.AutoSize = true;
            this.labelRequired1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired1.ForeColor = System.Drawing.Color.Red;
            this.labelRequired1.Location = new System.Drawing.Point(260, 25);
            this.labelRequired1.Name = "labelRequired1";
            this.labelRequired1.Size = new System.Drawing.Size(14, 14);
            this.labelRequired1.TabIndex = 17;
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
            this.labelRequired2.TabIndex = 18;
            this.labelRequired2.Text = "*";
            // 
            // labelRequired3
            // 
            this.labelRequired3.AutoSize = true;
            this.labelRequired3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired3.ForeColor = System.Drawing.Color.Red;
            this.labelRequired3.Location = new System.Drawing.Point(260, 79);
            this.labelRequired3.Name = "labelRequired3";
            this.labelRequired3.Size = new System.Drawing.Size(14, 14);
            this.labelRequired3.TabIndex = 19;
            this.labelRequired3.Text = "*";
            // 
            // labelRequired4
            // 
            this.labelRequired4.AutoSize = true;
            this.labelRequired4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired4.ForeColor = System.Drawing.Color.Red;
            this.labelRequired4.Location = new System.Drawing.Point(260, 107);
            this.labelRequired4.Name = "labelRequired4";
            this.labelRequired4.Size = new System.Drawing.Size(14, 14);
            this.labelRequired4.TabIndex = 20;
            this.labelRequired4.Text = "*";
            // 
            // labelRequired5
            // 
            this.labelRequired5.AutoSize = true;
            this.labelRequired5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired5.ForeColor = System.Drawing.Color.Red;
            this.labelRequired5.Location = new System.Drawing.Point(260, 134);
            this.labelRequired5.Name = "labelRequired5";
            this.labelRequired5.Size = new System.Drawing.Size(14, 14);
            this.labelRequired5.TabIndex = 21;
            this.labelRequired5.Text = "*";
            // 
            // labelRequired6
            // 
            this.labelRequired6.AutoSize = true;
            this.labelRequired6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired6.ForeColor = System.Drawing.Color.Red;
            this.labelRequired6.Location = new System.Drawing.Point(650, 24);
            this.labelRequired6.Name = "labelRequired6";
            this.labelRequired6.Size = new System.Drawing.Size(14, 14);
            this.labelRequired6.TabIndex = 22;
            this.labelRequired6.Text = "*";
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
            this.paginationControl.Location = new System.Drawing.Point(12, 288);
            this.paginationControl.Name = "paginationControl";
            this.paginationControl.PageSize = 20;
            this.paginationControl.Size = new System.Drawing.Size(784, 35);
            this.paginationControl.TabIndex = 4;
            // 
            // TeacherManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 520);
            this.Controls.Add(this.paginationControl);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxTeacherDetails);
            this.Controls.Add(this.groupBoxTeacherList);
            this.Name = "TeacherManagementForm";
            this.Text = "教师管理";
            this.Load += new System.EventHandler(this.TeacherManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
            this.groupBoxTeacherList.ResumeLayout(false);
            this.groupBoxTeacherDetails.ResumeLayout(false);
            this.groupBoxTeacherDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTeachers;
        private System.Windows.Forms.GroupBox groupBoxTeacherList;
        private System.Windows.Forms.GroupBox groupBoxTeacherDetails;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeacherId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRequired1;
        private System.Windows.Forms.Label labelRequired2;
        private System.Windows.Forms.Label labelRequired3;
        private System.Windows.Forms.Label labelRequired4;
        private System.Windows.Forms.Label labelRequired5;
        private System.Windows.Forms.Label labelRequired6;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControl;
    }
}