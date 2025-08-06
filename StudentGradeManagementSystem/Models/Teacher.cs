using System.Text.RegularExpressions;
using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// 验证教师信息是否有效
        /// </summary>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public (bool isValid, string errorMessage) Validate()
        {
            // 验证工号
            var (isTeacherIdValid, teacherIdErrorMessage) = ValidationService.ValidateTeacherId(TeacherId);
            if (!isTeacherIdValid)
                return (false, teacherIdErrorMessage);

            if (string.IsNullOrWhiteSpace(Name))
                return (false, "姓名不能为空");

            if (string.IsNullOrWhiteSpace(Gender))
                return (false, "性别不能为空");

            // 使用通用验证服务验证年龄 (20-100岁)
            var (isAgeValid, ageErrorMessage) = ValidationService.ValidateAge(Age, 20, 100);
            if (!isAgeValid)
                return (false, ageErrorMessage);

            if (string.IsNullOrWhiteSpace(Department))
                return (false, "部门不能为空");

            if (string.IsNullOrWhiteSpace(Title))
                return (false, "职称不能为空");

            // 使用通用验证服务验证电话号码格式
            var (isPhoneValid, phoneErrorMessage) = ValidationService.ValidatePhoneNumber(Phone);
            if (!isPhoneValid)
                return (false, phoneErrorMessage);

            // 使用通用验证服务验证邮箱格式
            var (isEmailValid, emailErrorMessage) = ValidationService.ValidateEmail(Email);
            if (!isEmailValid)
                return (false, emailErrorMessage);

            // 验证姓名长度
            if (Name.Length > 50)
                return (false, "姓名长度不能超过50个字符");

            // 验证部门名称长度
            if (Department.Length > 100)
                return (false, "部门名称长度不能超过100个字符");

            // 验证职称长度
            if (Title.Length > 50)
                return (false, "职称长度不能超过50个字符");

            // 验证性别值
            if (Gender != "男" && Gender != "女")
                return (false, "性别只能是男或女");

            return (true, string.Empty);
        }
    }
}