using System.Text.RegularExpressions;

namespace StudentGradeManagementSystem.Services
{
    /// <summary>
    /// 通用验证服务类，提供各种数据验证功能
    /// </summary>
    public static class ValidationService
    {
        /// <summary>
        /// 验证电话号码格式
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public static (bool isValid, string errorMessage) ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return (true, string.Empty); // 允许为空

            // 支持手机号码格式（纯数字，长度不超过15位）
            // 支持座机号码格式（如：021-12345678 或 +86（021）3456789）
            var phoneRegex = new Regex(@"^(\d{1,15}|(\+86)?[\(\s]*\d{3,4}[\)\s]*[-\s]?\d{7,8}|\d{3,4}-\d{7,8})$");
            if (!phoneRegex.IsMatch(phone))
                return (false, "电话号码格式不正确，支持手机号码或座机号码（如：13812345678、021-12345678、+86(021)3456789）");

            return (true, string.Empty);
        }

        /// <summary>
        /// 验证邮箱格式
        /// </summary>
        /// <param name="email">邮箱地址</param>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public static (bool isValid, string errorMessage) ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return (true, string.Empty); // 允许为空

            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailRegex.IsMatch(email))
                return (false, "邮箱格式不正确");

            return (true, string.Empty);
        }

        /// <summary>
        /// 验证年龄范围
        /// </summary>
        /// <param name="age">年龄</param>
        /// <param name="minAge">最小年龄</param>
        /// <param name="maxAge">最大年龄</param>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public static (bool isValid, string errorMessage) ValidateAge(int age, int minAge = 5, int maxAge = 100)
        {
            if (age < minAge || age > maxAge)
                return (false, $"年龄必须在{minAge}-{maxAge}之间");

            return (true, string.Empty);
        }
        
        /// <summary>
        /// 验证学号格式
        /// </summary>
        /// <param name="studentId">学号</param>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public static (bool isValid, string errorMessage) ValidateStudentId(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
                return (false, "学号不能为空");

            // 学号应该包含数字和字母，长度不超过8位
            if (!Regex.IsMatch(studentId, @"^[0-9A-Za-z]{1,8}$"))
                return (false, "学号只能包含数字和字母，长度不超过8位");

            return (true, string.Empty);
        }
        
        /// <summary>
        /// 验证工号格式
        /// </summary>
        /// <param name="teacherId">工号</param>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public static (bool isValid, string errorMessage) ValidateTeacherId(string teacherId)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                return (false, "工号不能为空");

            // 工号长度为3-18位
            if (teacherId.Length < 3 || teacherId.Length > 18)
                return (false, "工号长度必须为3-18位");

            return (true, string.Empty);
        }
    }
}