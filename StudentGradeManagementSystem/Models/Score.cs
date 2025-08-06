using StudentGradeManagementSystem.Services;

namespace StudentGradeManagementSystem.Models
{
    /// <summary>
    /// 成绩模型
    /// </summary>
    public class Score
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        public string student_id { get; set; } = string.Empty;

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; } = string.Empty;

        /// <summary>
        /// 课程ID
        /// </summary>
        public string course_id { get; set; } = string.Empty;

        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; } = string.Empty;

        /// <summary>
        /// 分数值 (0-300)
        /// </summary>
        public decimal score { get; set; }

        /// <summary>
        /// 学期
        /// </summary>
        public string term { get; set; } = string.Empty;

        /// <summary>
        /// 考试日期 (可为空)
        /// </summary>
        public DateTime? exam_date { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 验证成绩信息是否有效
        /// </summary>
        /// <returns>验证结果元组，包含是否有效和错误信息</returns>
        public (bool isValid, string errorMessage) Validate()
        {
            // 验证必填字段
            if (string.IsNullOrWhiteSpace(student_id))
                return (false, "学生不能为空");

            if (string.IsNullOrWhiteSpace(course_id))
                return (false, "课程不能为空");

            if (string.IsNullOrWhiteSpace(term))
                return (false, "学期不能为空");

            // 验证成绩范围 (0-300)
            if (score < 0 || score > 300)
                return (false, "成绩必须在0-300之间");

            // 验证学期格式（应该为类似 2023-2024-1 或 2023秋 的格式）
            if (!System.Text.RegularExpressions.Regex.IsMatch(term, @"^(\d{4}-\d{4}-[12]|\d{4}(春|夏|秋|冬))$"))
                return (false, "学期格式不正确，应为类似 2023-2024-1 或 2023秋 的格式");

            // 验证考试日期不能是未来日期
            if (exam_date.HasValue && exam_date.Value > DateTime.Now)
                return (false, "考试日期不能是未来日期");

            return (true, string.Empty);
        }
    }
}