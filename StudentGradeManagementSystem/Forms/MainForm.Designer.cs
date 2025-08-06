using Sunny.UI;

namespace StudentGradeManagementSystem.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuItemDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemScores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // menuItemDashboard
            // 
            this.menuItemDashboard.Name = "menuItemDashboard";
            this.menuItemDashboard.Size = new System.Drawing.Size(68, 21);
            this.menuItemDashboard.Text = "系统设置";
            // 
            // menuItemStudents
            // 
            this.menuItemStudents.Name = "menuItemStudents";
            this.menuItemStudents.Size = new System.Drawing.Size(68, 21);
            this.menuItemStudents.Text = "学生管理";
            // 
            // menuItemTeachers
            // 
            this.menuItemTeachers.Name = "menuItemTeachers";
            this.menuItemTeachers.Size = new System.Drawing.Size(68, 21);
            this.menuItemTeachers.Text = "教师管理";
            // 
            // menuItemCourses
            // 
            this.menuItemCourses.Name = "menuItemCourses";
            this.menuItemCourses.Size = new System.Drawing.Size(68, 21);
            this.menuItemCourses.Text = "课程管理";
            // 
            // menuItemScores
            // 
            this.menuItemScores.Name = "menuItemScores";
            this.menuItemScores.Size = new System.Drawing.Size(68, 21);
            this.menuItemScores.Text = "成绩管理";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
    this.menuItemDashboard,
    this.menuItemStudents,
    this.menuItemTeachers,
    this.menuItemCourses,
    this.menuItemScores});
    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
    this.menuStrip1.Name = "menuStrip1";
    this.menuStrip1.Size = new System.Drawing.Size(800, 25);
    this.menuStrip1.TabIndex = 0;
    this.menuStrip1.Text = "menuStrip1";

    // 
    // MainForm
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(800, 450);
    this.Controls.Add(this.menuStrip1);
    this.IsMdiContainer = true;
    this.MainMenuStrip = this.menuStrip1;
    this.Name = "MainForm";
    this.Text = "学生成绩管理系统";
    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
    this.Load += new System.EventHandler(this.MainForm_Load);
    this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemDashboard;
        private System.Windows.Forms.ToolStripMenuItem menuItemStudents;
        private System.Windows.Forms.ToolStripMenuItem menuItemTeachers;
        private System.Windows.Forms.ToolStripMenuItem menuItemCourses;
        private System.Windows.Forms.ToolStripMenuItem menuItemScores;
    }
}