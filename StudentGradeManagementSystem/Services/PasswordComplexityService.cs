using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace StudentGradeManagementSystem.Services
{
    /// <summary>
    /// 密码复杂度验证服务
    /// </summary>
    public static class PasswordComplexityService
    {
        /// <summary>
        /// 密码复杂度要求
        /// </summary>
        public class PasswordRequirements
        {
            public int MinLength { get; set; } = 8;
            public bool RequireUpperCase { get; set; } = true;
            public bool RequireLowerCase { get; set; } = true;
            public bool RequireDigit { get; set; } = true;
            public bool RequireSpecialChar { get; set; } = true;
            public int MinUniqueChars { get; set; } = 4;
        }

        private static readonly PasswordRequirements DefaultRequirements = new PasswordRequirements();

        /// <summary>
        /// 验证密码复杂度
        /// </summary>
        public static (bool isValid, string errorMessage) ValidatePasswordComplexity(string password, PasswordRequirements? requirements = null)
        {
            requirements ??= DefaultRequirements;

            if (string.IsNullOrEmpty(password))
            {
                return (false, "密码不能为空");
            }

            if (password.Length < requirements.MinLength)
            {
                return (false, $"密码长度至少为 {requirements.MinLength} 个字符");
            }

            if (requirements.RequireUpperCase && !password.Any(char.IsUpper))
            {
                return (false, "密码必须包含至少一个大写字母");
            }

            if (requirements.RequireLowerCase && !password.Any(char.IsLower))
            {
                return (false, "密码必须包含至少一个小写字母");
            }

            if (requirements.RequireDigit && !password.Any(char.IsDigit))
            {
                return (false, "密码必须包含至少一个数字");
            }

            if (requirements.RequireSpecialChar && !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return (false, "密码必须包含至少一个特殊字符");
            }

            var uniqueChars = new HashSet<char>(password);
            if (uniqueChars.Count < requirements.MinUniqueChars)
            {
                return (false, $"密码必须包含至少 {requirements.MinUniqueChars} 个不同的字符");
            }

            var weakPasswords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "admin123", "password", "123456", "12345678", "qwerty",
                "abc123", "password123", "admin", "letmein", "welcome"
            };

            if (weakPasswords.Contains(password))
            {
                return (false, "密码过于简单，请使用更复杂的密码");
            }

            return (true, string.Empty);
        }

        /// <summary>
        /// 生成符合复杂度要求的随机密码
        /// </summary>
        public static string GenerateSecurePassword(int length = 12)
        {
            if (length < 8) length = 12;

            const string upperCase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijkmnopqrstuvwxyz";
            const string digits = "23456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            var allChars = upperCase + lowerCase + digits + specialChars;
            var passwordChars = new char[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                var randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                passwordChars[0] = upperCase[randomBytes[0] % upperCase.Length];
                passwordChars[1] = lowerCase[randomBytes[1] % lowerCase.Length];
                passwordChars[2] = digits[randomBytes[2] % digits.Length];
                passwordChars[3] = specialChars[randomBytes[3] % specialChars.Length];

                for (int i = 4; i < length; i++)
                {
                    passwordChars[i] = allChars[randomBytes[i] % allChars.Length];
                }

                for (int i = 0; i < length; i++)
                {
                    var swapIndex = randomBytes[i] % length;
                    var temp = passwordChars[i];
                    passwordChars[i] = passwordChars[swapIndex];
                    passwordChars[swapIndex] = temp;
                }
            }

            return new string(passwordChars);
        }

        /// <summary>
        /// 检查密码是否包含用户名
        /// </summary>
        public static (bool isSafe, string warningMessage) CheckPasswordContainsUsername(string password, string username)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return (true, string.Empty);
            }

            if (password.ToLower().Contains(username.ToLower()))
            {
                return (false, "密码不应包含用户名，这会降低安全性");
            }

            return (true, string.Empty);
        }
    }
}
