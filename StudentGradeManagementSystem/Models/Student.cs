using System.Text.RegularExpressions;
using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string student_id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Class { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 验证学生信息是否有效
        /// </summary>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public (bool isValid, string errorMessage) Validate()
        {
            // 验证必填字段
            var (isStudentIdValid, studentIdErrorMessage) = ValidationService.ValidateStudentId(student_id);
            if (!isStudentIdValid)
                return (false, studentIdErrorMessage);

            if (string.IsNullOrWhiteSpace(Name))
                return (false, "姓名不能为空");

            if (string.IsNullOrWhiteSpace(Gender))
                return (false, "性别不能为空");

            // 使用通用验证服务验证年龄 (5-100岁)
            var (isAgeValid, ageErrorMessage) = ValidationService.ValidateAge(Age, 5, 100);
            if (!isAgeValid)
                return (false, ageErrorMessage);

            if (string.IsNullOrWhiteSpace(Class))
                return (false, "班级不能为空");

            if (string.IsNullOrWhiteSpace(Major))
                return (false, "专业不能为空");

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

            // 验证班级格式
            if (Class.Length > 50)
                return (false, "班级名称长度不能超过50个字符");

            // 验证专业名称长度
            if (Major.Length > 100)
                return (false, "专业名称长度不能超过100个字符");

            // 验证性别值
            if (Gender != "男" && Gender != "女")
                return (false, "性别只能是男或女");

            // 验证入学时间不能是未来日期
            if (EnrollmentDate.HasValue && EnrollmentDate.Value > DateTime.Now)
                return (false, "入学时间不能是未来日期");

            return (true, string.Empty);
        }
    }
}