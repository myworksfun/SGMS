namespace StudentGradeManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockedUntil { get; set; }
        public bool RequirePasswordChange { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}