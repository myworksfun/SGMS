using StudentGradeManagementSystem.Forms;
using StudentGradeManagementSystem.Data;
using System;
using System.Windows.Forms;

namespace StudentGradeManagementSystem;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        DatabaseHelper.InitializeDatabase();
        
        try
        {
            var logRepository = new Data.LogRepository();
            logRepository.AddSystemLog("Application Start", "学生成绩管理系统启动");
        }
        catch (Exception ex)
        {
            Console.WriteLine("记录系统启动日志时发生错误: " + ex.Message);
        }
        
        Application.Run(new LoginForm());
    }
}