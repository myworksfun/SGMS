using System.Security.Cryptography;
using System.Text;
// 添加BCrypt引用
using BCrypt.Net;

namespace StudentGradeManagementSystem.Services
{
    public static class PasswordService
    {
        private const string ApplicationSalt = "StudentGradeManagementSystem2025";

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("密码不能为空", nameof(password));

            // 使用BCrypt算法进行哈希，保持与系统其他部分一致
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (string.IsNullOrEmpty(hashedPassword))
                return false;

            // 使用BCrypt验证密码
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private static bool TimeSafeEquals(string a, string b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}