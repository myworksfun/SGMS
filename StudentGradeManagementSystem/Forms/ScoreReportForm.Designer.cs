namespace StudentGradeManagementSystem.Forms
{
    partial class ScoreReportForm
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
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewScores = new System.Windows.Forms.DataGridView();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.lblPassRate = new System.Windows.Forms.Label();
            this.lblLowestScore = new System.Windows.Forms.Label();
            this.lblHighestScore = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.groupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilter.Controls.Add(this.btnReset);
            this.groupBoxFilter.Controls.Add(this.btnFilter);
            this.groupBoxFilter.Controls.Add(this.cmbStudent);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.cmbCourse);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(784, 60);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "筛选条件";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(697, 23);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(616, 23);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "筛选";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbStudent
            // 
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(343, 25);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(183, 20);
            this.cmbStudent.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "学生：";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(79, 25);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(183, 20);
            this.cmbCourse.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程：";
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.AllowUserToAddRows = false;
            this.dataGridViewScores.AllowUserToDeleteRows = false;
            this.dataGridViewScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.ReadOnly = true;
            this.dataGridViewScores.RowTemplate.Height = 23;
            this.dataGridViewScores.Size = new System.Drawing.Size(784, 260);
            this.dataGridViewScores.TabIndex = 1;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStatistics.Controls.Add(this.lblPassRate);
            this.groupBoxStatistics.Controls.Add(this.lblLowestScore);
            this.groupBoxStatistics.Controls.Add(this.lblHighestScore);
            this.groupBoxStatistics.Controls.Add(this.lblAverageScore);
            this.groupBoxStatistics.Controls.Add(this.lblTotalCount);
            this.groupBoxStatistics.Location = new System.Drawing.Point(12, 344);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(784, 106);
            this.groupBoxStatistics.TabIndex = 2;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "统计信息";
            // 
            // lblPassRate
            // 
            this.lblPassRate.AutoSize = true;
            this.lblPassRate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassRate.Location = new System.Drawing.Point(478, 64);
            this.lblPassRate.Name = "lblPassRate";
            this.lblPassRate.Size = new System.Drawing.Size(87, 21);
            this.lblPassRate.TabIndex = 4;
            this.lblPassRate.Text = "及格率: 0%";
            // 
            // lblLowestScore
            // 
            this.lblLowestScore.AutoSize = true;
            this.lblLowestScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLowestScore.Location = new System.Drawing.Point(283, 64);
            this.lblLowestScore.Name = "lblLowestScore";
            this.lblLowestScore.Size = new System.Drawing.Size(89, 21);
            this.lblLowestScore.TabIndex = 3;
            this.lblLowestScore.Text = "最低分: 0.0";
            // 
            // lblHighestScore
            // 
            this.lblHighestScore.AutoSize = true;
            this.lblHighestScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHighestScore.Location = new System.Drawing.Point(88, 64);
            this.lblHighestScore.Name = "lblHighestScore";
            this.lblHighestScore.Size = new System.Drawing.Size(89, 21);
            this.lblHighestScore.TabIndex = 2;
            this.lblHighestScore.Text = "最高分: 0.0";
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAverageScore.Location = new System.Drawing.Point(283, 29);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(89, 21);
            this.lblAverageScore.TabIndex = 1;
            this.lblAverageScore.Text = "平均分: 0.0";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(88, 29);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(78, 21);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "总记录数: 0";
            // 
            // ScoreReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 462);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.dataGridViewScores);
            this.Controls.Add(this.groupBoxFilter);
            this.Name = "ScoreReportForm";
            this.Text = "成绩统计报表";
            this.Load += new System.EventHandler(this.ScoreReportForm_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewScores;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.Label lblPassRate;
        private System.Windows.Forms.Label lblLowestScore;
        private System.Windows.Forms.Label lblHighestScore;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Label lblTotalCount;
    }
}