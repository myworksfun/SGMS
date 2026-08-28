using System.Security.Cryptography;
using System.Text;
using System.Linq;
using BCrypt.Net;

namespace StudentGradeManagementSystem.Services
{
    public static class PasswordService
    {
        private const string ApplicationSalt = "StudentGradeManagementSystem2025";

        /// <summary>
        /// 哈希密码，使用 BCrypt 算法并验证密码复杂度
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("密码不能为空", nameof(password));

            // 验证密码复杂度
            var (isValid, errorMessage) = PasswordComplexityService.ValidatePasswordComplexity(password);
            if (!isValid)
            {
                throw new ArgumentException(errorMessage, nameof(password));
            }

            // 使用 BCrypt 算法进行哈希，work factor 设为 12 以增强安全性
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (string.IsNullOrEmpty(hashedPassword))
                return false;

            // 使用 BCrypt 验证密码
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
