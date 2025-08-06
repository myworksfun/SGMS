namespace StudentGradeManagementSystem.Models
{
    public class OperationLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; } // 可空，系统日志可能没有用户ID
        public string Username { get; set; } = string.Empty;
        public string LogType { get; set; } = string.Empty; // USER_ACTION or SYSTEM_EVENT
        public string Operation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}