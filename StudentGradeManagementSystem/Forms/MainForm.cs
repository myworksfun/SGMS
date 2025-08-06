using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private Panel? welcomePanel;
        private Label? welcomeLabel;
        private StatusStrip? statusStrip;
        private ToolStripStatusLabel? statusLabel;
        private ToolStripStatusLabel? copyrightLabel;
        private ToolStripStatusLabel? timeLabel;
        private System.Windows.Forms.Timer? timeTimer;
        
        public MainForm()
        {
            InitializeComponent();
            CreateWelcomePanel();
            CreateStatusBar();
            InitializeTimeUpdater();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var user = CurrentUser.GetCurrentUser();
            if (user != null)
            {
                Text = $"学生成绩管理系统 - 欢迎，{user.Username} ({user.Role})";
                if (statusLabel != null)
                {
                    statusLabel.Text = $"当前用户: {user.Username} ({user.Role})";
                }
                
                // 用户登录日志已在登录表单中记录，此处不再重复记录
            }
            
            // 初始化菜单
            InitializeMenu();
            
            // 启动时间更新
            timeTimer?.Start();
            
            // 记录主窗体加载系统日志
            try
            {
                var logRepository = new Data.LogRepository();
                logRepository.AddSystemLog("Main Form Load", "主窗体加载完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine("记录主窗体加载日志时发生错误: " + ex.Message);
            }
        }
        
        private void CreateStatusBar()
        {
            statusStrip = new StatusStrip();
            statusStrip.Dock = DockStyle.Bottom;
            
            statusLabel = new ToolStripStatusLabel();
            statusLabel.Text = "就绪";
            statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            timeLabel = new ToolStripStatusLabel();
            timeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + GetDayOfWeekCN(DateTime.Now.DayOfWeek);
            timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            timeLabel.Spring = true;
            
            copyrightLabel = new ToolStripStatusLabel();
            copyrightLabel.Text = "© 2025 学生成绩管理系统 - 版权所有";
            copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            statusStrip.Items.Add(statusLabel);
            statusStrip.Items.Add(timeLabel);
            statusStrip.Items.Add(copyrightLabel);
            
            this.Controls.Add(statusStrip);
        }
        
        private void CreateWelcomePanel()
        {
            welcomePanel = new Panel();
            welcomePanel.Dock = DockStyle.Fill;
            welcomePanel.BackColor = System.Drawing.Color.White;
            
            welcomeLabel = new Label();
            welcomeLabel.Text = "欢迎使用学生成绩管理系统";
            welcomeLabel.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            welcomeLabel.AutoSize = false;
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Dock = DockStyle.Fill;
            
            welcomePanel.Controls.Add(welcomeLabel);
            this.Controls.Add(welcomePanel);
        }
        
        private string GetDayOfWeekCN(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "星期一";
                case DayOfWeek.Tuesday: return "星期二";
                case DayOfWeek.Wednesday: return "星期三";
                case DayOfWeek.Thursday: return "星期四";
                case DayOfWeek.Friday: return "星期五";
                case DayOfWeek.Saturday: return "星期六";
                case DayOfWeek.Sunday: return "星期日";
                default: return "";
            }
        }
        
        private void InitializeTimeUpdater()
        {
            timeTimer = new System.Windows.Forms.Timer();
            timeTimer.Interval = 1000;
            timeTimer.Tick += (sender, e) => UpdateTime();
            
            UpdateTime();
        }
        
        private void UpdateTime()
        {
            if (timeLabel != null)
            {
                DateTime localTime = DateTime.Now;
                timeLabel.Text = "当前时间: " + localTime.ToString("yyyy-MM-dd HH:mm:ss") + " " + GetDayOfWeekCN(localTime.DayOfWeek);
            }
        }
        
        private void InitializeMenu()
        {
            // 为系统设置菜单添加子菜单项
            var changePasswordItem = new ToolStripMenuItem("修改密码");
            changePasswordItem.Click += tsmiChangePassword_Click;
            
            var logManagementItem = new ToolStripMenuItem("系统日志");
            logManagementItem.Click += tsmiLogManagement_Click;
            
            var exitItem = new ToolStripMenuItem("退出");
            exitItem.Click += tsmiLogout_Click;
            
            menuItemDashboard.DropDownItems.Add(changePasswordItem);
            menuItemDashboard.DropDownItems.Add(logManagementItem);
            menuItemDashboard.DropDownItems.Add(new ToolStripSeparator());
            menuItemDashboard.DropDownItems.Add(exitItem);

            // 为学生管理菜单添加子菜单项
            var studentManagementItem = new ToolStripMenuItem("学生信息管理");
            studentManagementItem.Click += tsmiStudentManagement_Click;
            
            menuItemStudents.DropDownItems.Add(studentManagementItem);
            // 默认也绑定主菜单项点击事件，确保点击主菜单项时也能打开学生管理窗体
            menuItemStudents.Click += tsmiStudentManagement_Click;

            // 为教师管理菜单添加子菜单项
            var teacherManagementItem = new ToolStripMenuItem("教师信息管理");
            teacherManagementItem.Click += tsmiTeacherManagement_Click;
            
            menuItemTeachers.DropDownItems.Add(teacherManagementItem);
            // 默认也绑定主菜单项点击事件，确保点击主菜单项时也能打开教师管理窗体
            menuItemTeachers.Click += tsmiTeacherManagement_Click;

            // 为课程管理菜单添加子菜单项
            var courseManagementItem = new ToolStripMenuItem("课程信息管理");
            courseManagementItem.Click += tsmiCourseManagement_Click;
            
            menuItemCourses.DropDownItems.Add(courseManagementItem);
            // 默认也绑定主菜单项点击事件，确保点击主菜单项时也能打开课程管理窗体
            menuItemCourses.Click += tsmiCourseManagement_Click;

            // 为成绩管理菜单添加子菜单项
            var scoreManagementItem = new ToolStripMenuItem("成绩信息管理");
            scoreManagementItem.Click += tsmiScoreManagement_Click;
            
            var scoreAnalysisItem = new ToolStripMenuItem("成绩统计报表");
            scoreAnalysisItem.Click += tsmiScoreReport_Click;
            
            menuItemScores.DropDownItems.Add(scoreManagementItem);
            menuItemScores.DropDownItems.Add(new ToolStripSeparator());
            menuItemScores.DropDownItems.Add(scoreAnalysisItem);
            // 默认也绑定主菜单项点击事件，确保点击主菜单项时也能打开成绩管理窗体
            menuItemScores.Click += tsmiScoreManagement_Click;
        }

        private void tsmiChangePassword_Click(object? sender, EventArgs e)
        {
            // 显示修改密码对话框
            var changePasswordForm = new ChangePasswordForm();
            if (changePasswordForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiLogManagement_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了日志管理窗体
            foreach (Form form in MdiChildren)
            {
                if (form is LogManagementForm)
                {
                    form.Activate();
                    form.BringToFront(); // 确保窗体显示在前面
                    return;
                }
            }
            
            // 打开日志管理窗体
            var logManagementForm = new LogManagementForm();
            logManagementForm.MdiParent = this;
            logManagementForm.WindowState = FormWindowState.Maximized;
            logManagementForm.Show();
            logManagementForm.BringToFront(); // 确保新窗体显示在前面
            
            // 隐藏欢迎面板（与其他窗体保持一致）
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }

        private void tsmiLogout_Click(object? sender, EventArgs e)
        {
            // 注销登录
            CurrentUser.SetCurrentUser(null!);
            
            // 关闭所有子窗体
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            // 停止定时器
            timeTimer?.Stop();
            
            // 关闭主窗体，触发FormClosed事件
            this.Close();
        }

        private void tsmiStudentManagement_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了学生管理窗体
            foreach (Form form in MdiChildren)
            {
                if (form is StudentManagementForm)
                {
                    form.Activate();
                    return;
                }
            }
            
            // 打开学生管理窗体
            var studentManagementForm = new StudentManagementForm();
            studentManagementForm.MdiParent = this;
            studentManagementForm.WindowState = FormWindowState.Maximized;
            studentManagementForm.Show();
            
            // 隐藏欢迎面板
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }

        private void tsmiTeacherManagement_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了教师管理窗体
            foreach (Form form in MdiChildren)
            {
                if (form is TeacherManagementForm)
                {
                    form.Activate();
                    return;
                }
            }
            
            // 打开教师管理窗体
            var teacherManagementForm = new TeacherManagementForm();
            teacherManagementForm.MdiParent = this;
            teacherManagementForm.WindowState = FormWindowState.Maximized;
            teacherManagementForm.Show();
            
            // 隐藏欢迎面板
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }

        private void tsmiCourseManagement_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了课程管理窗体
            foreach (Form form in MdiChildren)
            {
                if (form is CourseManagementForm)
                {
                    form.Activate();
                    return;
                }
            }
            
            // 打开课程管理窗体
            var courseManagementForm = new CourseManagementForm();
            courseManagementForm.MdiParent = this;
            courseManagementForm.WindowState = FormWindowState.Maximized;
            courseManagementForm.Show();
            
            // 隐藏欢迎面板
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }

        private void tsmiScoreManagement_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了成绩管理窗体
            foreach (Form form in MdiChildren)
            {
                if (form is ScoreManagementForm)
                {
                    form.Activate();
                    return;
                }
            }
            
            // 打开成绩管理窗体
            var scoreManagementForm = new ScoreManagementForm();
            scoreManagementForm.MdiParent = this;
            scoreManagementForm.WindowState = FormWindowState.Maximized;
            scoreManagementForm.Show();
            
            // 隐藏欢迎面板
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }
        
        private void tsmiScoreReport_Click(object? sender, EventArgs e)
        {
            // 检查是否已经打开了成绩统计报表窗体
            foreach (Form form in MdiChildren)
            {
                if (form is ScoreReportForm)
                {
                    form.Activate();
                    return;
                }
            }
            
            // 打开成绩统计报表窗体
            var scoreReportForm = new ScoreReportForm();
            scoreReportForm.MdiParent = this;
            scoreReportForm.WindowState = FormWindowState.Maximized;
            scoreReportForm.Show();
            
            // 隐藏欢迎面板
            if (welcomePanel != null)
            {
                welcomePanel.Visible = false;
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 清理资源
                timeTimer?.Stop();
                timeTimer?.Dispose();
                
                // 清理状态栏控件
                statusStrip?.Dispose();
                statusLabel?.Dispose();
                timeLabel?.Dispose();
                copyrightLabel?.Dispose();
                
                // 清理欢迎面板控件
                welcomeLabel?.Dispose();
                welcomePanel?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}