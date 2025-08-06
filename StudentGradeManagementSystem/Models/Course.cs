using System.Text.RegularExpressions;
using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string course_id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string TeacherId { get; set; } = string.Empty; // 关联教师ID
        public string TeacherName { get; set; } = string.Empty;
        public int Credit { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 验证课程信息是否有效
        /// </summary>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public (bool isValid, string errorMessage) Validate()
        {
            // 验证必填字段
            if (string.IsNullOrWhiteSpace(course_id))
                return (false, "课程代码不能为空");

            if (string.IsNullOrWhiteSpace(Name))
                return (false, "课程名称不能为空");

            if (Credit <= 0)
                return (false, "学分必须大于0");

            if (string.IsNullOrWhiteSpace(Type))
                return (false, "课程类型不能为空");

            // 验证课程代码格式（字母加数字的组合，总长度不超过20个）
            if (!System.Text.RegularExpressions.Regex.IsMatch(course_id, @"^[A-Za-z0-9]{1,20}$"))
                return (false, "课程代码只能包含字母和数字，长度不超过20位");

            // 验证学分范围（通常课程学分为1-10）
            if (Credit < 1 || Credit > 10)
                return (false, "学分必须在1-10之间");

            return (true, string.Empty);
        }
    }
}