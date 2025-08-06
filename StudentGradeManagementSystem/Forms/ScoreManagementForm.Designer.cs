namespace StudentGradeManagementSystem.Forms
{
    partial class ScoreManagementForm
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
            this.dataGridViewScores = new System.Windows.Forms.DataGridView();
            this.groupBoxScoreList = new System.Windows.Forms.GroupBox();
            this.groupBoxScoreDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRequired1 = new System.Windows.Forms.Label();
            this.labelRequired2 = new System.Windows.Forms.Label();
            this.labelRequired3 = new System.Windows.Forms.Label();
            this.labelRequired4 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.paginationControl = new StudentGradeManagementSystem.Controls.PaginationControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.groupBoxScoreList.SuspendLayout();
            this.groupBoxScoreDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.AllowUserToAddRows = false;
            this.dataGridViewScores.AllowUserToDeleteRows = false;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScores.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewScores.MultiSelect = false;
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.ReadOnly = true;
            this.dataGridViewScores.RowTemplate.Height = 23;
            this.dataGridViewScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScores.Size = new System.Drawing.Size(778, 244);
            this.dataGridViewScores.TabIndex = 0;
            // 
            // groupBoxScoreList
            // 
            this.groupBoxScoreList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScoreList.Controls.Add(this.dataGridViewScores);
            this.groupBoxScoreList.Location = new System.Drawing.Point(12, 12);
            this.groupBoxScoreList.Name = "groupBoxScoreList";
            this.groupBoxScoreList.Size = new System.Drawing.Size(784, 230);
            this.groupBoxScoreList.TabIndex = 1;
            this.groupBoxScoreList.TabStop = false;
            this.groupBoxScoreList.Text = "成绩列表";
            // 
            // groupBoxScoreDetails
            // 
            this.groupBoxScoreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScoreDetails.Controls.Add(this.labelRequired4);
            this.groupBoxScoreDetails.Controls.Add(this.dtpExamDate);
            this.groupBoxScoreDetails.Controls.Add(this.label6);
            this.groupBoxScoreDetails.Controls.Add(this.txtSemester);
            this.groupBoxScoreDetails.Controls.Add(this.label5);
            this.groupBoxScoreDetails.Controls.Add(this.numScore);
            this.groupBoxScoreDetails.Controls.Add(this.label4);
            this.groupBoxScoreDetails.Controls.Add(this.cmbCourse);
            this.groupBoxScoreDetails.Controls.Add(this.label3);
            this.groupBoxScoreDetails.Controls.Add(this.cmbStudent);
            this.groupBoxScoreDetails.Controls.Add(this.label2);
            this.groupBoxScoreDetails.Controls.Add(this.labelRequired1);
            this.groupBoxScoreDetails.Controls.Add(this.labelRequired2);
            this.groupBoxScoreDetails.Controls.Add(this.labelRequired3);
            this.groupBoxScoreDetails.Enabled = false;
            this.groupBoxScoreDetails.Location = new System.Drawing.Point(12, 285);
            this.groupBoxScoreDetails.Name = "groupBoxScoreDetails";
            this.groupBoxScoreDetails.Size = new System.Drawing.Size(784, 150);
            this.groupBoxScoreDetails.TabIndex = 0;
            this.groupBoxScoreDetails.TabStop = false;
            this.groupBoxScoreDetails.Text = "成绩信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学生：";
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(55, 22);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(200, 20);
            this.cmbStudent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "课程：";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(330, 22);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(200, 20);
            this.cmbCourse.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "成绩：";
            // 
            // numScore
            // 
            this.numScore.DecimalPlaces = 1;
            this.numScore.Location = new System.Drawing.Point(55, 52);
            this.numScore.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numScore.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(200, 21);
            this.numScore.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "学期：";
            // 
            // txtSemester
            // 
            this.txtSemester.Location = new System.Drawing.Point(55, 79);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(200, 21);
            this.txtSemester.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "考试日期：";
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.Location = new System.Drawing.Point(350, 79);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(180, 21);
            this.dtpExamDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(55, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "格式示例：2023-2024-1";
            // 
            // labelRequired1
            // 
            this.labelRequired1.AutoSize = true;
            this.labelRequired1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRequired1.ForeColor = System.Drawing.Color.Red;
            this.labelRequired1.Location = new System.Drawing.Point(255, 25);
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
            this.labelRequired2.Location = new System.Drawing.Point(535, 25);
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
            this.labelRequired3.Location = new System.Drawing.Point(255, 55);
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
            this.labelRequired4.Location = new System.Drawing.Point(255, 82);
            this.labelRequired4.Name = "labelRequired4";
            this.labelRequired4.Size = new System.Drawing.Size(14, 14);
            this.labelRequired4.TabIndex = 20;
            this.labelRequired4.Text = "*";
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnImport);
            this.panelButtons.Location = new System.Drawing.Point(12, 431);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 45);
            this.panelButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(280, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(246, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // paginationControl
            // 
            this.paginationControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paginationControl.CurrentPage = 1;
            this.paginationControl.Location = new System.Drawing.Point(12, 260);
            this.paginationControl.Name = "paginationControl";
            this.paginationControl.PageSize = 20;
            this.paginationControl.Size = new System.Drawing.Size(784, 35);
            this.paginationControl.TabIndex = 4;
            this.paginationControl.PageChanged += new StudentGradeManagementSystem.Controls.PaginationControl.PageChangedEventHandler(this.PaginationControl_PageChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ScoreManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 520);
            this.Controls.Add(this.paginationControl);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxScoreDetails);
            this.Controls.Add(this.groupBoxScoreList);
            this.Name = "ScoreManagementForm";
            this.Text = "成绩管理";
            this.Load += new System.EventHandler(this.ScoreManagementForm_Load);
            this.Shown += new System.EventHandler(this.ScoreManagementForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.groupBoxScoreList.ResumeLayout(false);
            this.groupBoxScoreDetails.ResumeLayout(false);
            this.groupBoxScoreDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScore)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScores;
        private System.Windows.Forms.GroupBox groupBoxScoreList;
        private System.Windows.Forms.GroupBox groupBoxScoreDetails;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRequired1;
        private System.Windows.Forms.Label labelRequired2;
        private System.Windows.Forms.Label labelRequired3;
        private System.Windows.Forms.Label labelRequired4;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private StudentGradeManagementSystem.Controls.PaginationControl paginationControl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
    }
}