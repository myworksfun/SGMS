using System;
using StudentGradeManagementSystem.Data;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem.Services
{
    public class LoggingService
    {
        private readonly LogRepository _logRepository;

        public LoggingService()
        {
            _logRepository = new LogRepository();
        }

        public void LogUserAction(string username, string role, string action, string details)
        {
            try
            {
                string ip = NetworkUtils.GetLocalIPAddress();
                var log = new OperationLog
                {
                    Username = username,
                    LogType = "USER_ACTION",
                    Operation = action,
                    Description = details,
                    IPAddress = ip,
                    UserAgent = string.Empty
                };
                _logRepository.AddUserLog(log);
            }
            catch (Exception ex)
            {
                // 即使日志记录失败，也不应该影响主流程
                Console.WriteLine($"记录用户操作日志失败: {ex.Message}");
            }
        }

        public void LogSystemEvent(string eventType, string details)
        {
            try
            {
                _logRepository.AddSystemLog(eventType, details);
            }
            catch (Exception ex)
            {
                // 即使日志记录失败，也不应该影响主流程
                Console.WriteLine($"记录系统事件日志失败: {ex.Message}");
            }
        }

        public void LogError(string errorType, string errorMessage, string stackTrace = "")
        {
            try
            {
                string ip = NetworkUtils.GetLocalIPAddress();
                _logRepository.AddSystemLog($"ERROR: {errorType}", $"{errorMessage}\nStack Trace: {stackTrace}");
            }
            catch (Exception ex)
            {
                // 即使日志记录失败，也不应该影响主流程
                Console.WriteLine($"记录错误日志失败: {ex.Message}");
            }
        }
    }
}