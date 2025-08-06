using ClosedXML.Excel;
using StudentGradeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentGradeManagementSystem.Services
{
    public class ExcelService
    {
        public bool ExportStudentsToExcel(List<Student> students, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("学生信息");
                    
                    // 添加标题行
                    worksheet.Cell(1, 1).Value = "学号";
                    worksheet.Cell(1, 2).Value = "姓名";
                    worksheet.Cell(1, 3).Value = "性别";
                    worksheet.Cell(1, 4).Value = "年龄";
                    worksheet.Cell(1, 5).Value = "班级";
                    worksheet.Cell(1, 6).Value = "专业";
                    worksheet.Cell(1, 7).Value = "电话";
                    worksheet.Cell(1, 8).Value = "邮箱";
                    worksheet.Cell(1, 9).Value = "入学时间";
                    worksheet.Cell(1, 10).Value = "创建时间";
                    worksheet.Cell(1, 11).Value = "更新时间";
                    
                    // 添加数据行
                    for (int i = 0; i < students.Count; i++)
                    {
                        var student = students[i];
                        int row = i + 2; // 从第二行开始
                        
                        worksheet.Cell(row, 1).Value = student.student_id;
                        worksheet.Cell(row, 2).Value = student.Name;
                        worksheet.Cell(row, 3).Value = student.Gender;
                        worksheet.Cell(row, 4).Value = student.Age;
                        worksheet.Cell(row, 5).Value = student.Class;
                        worksheet.Cell(row, 6).Value = student.Major;
                        worksheet.Cell(row, 7).Value = student.Phone;
                        worksheet.Cell(row, 8).Value = student.Email;
                        worksheet.Cell(row, 9).Value = student.EnrollmentDate?.ToString("yyyy-MM-dd") ?? "";
                        worksheet.Cell(row, 10).Value = student.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cell(row, 11).Value = student.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    // 自动调整列宽
                    worksheet.Columns().AdjustToContents();
                    
                    // 保存文件
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("导出学生信息到Excel时发生错误: " + ex.Message);
            }
        }
        
        public List<Student> ImportStudentsFromExcel(string filePath)
        {
            var students = new List<Student>();
            
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    
                    // 跳过标题行，从第二行开始读取数据
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue; // 跳过标题行
                        
                        var student = new Student
                        {
                            student_id = row.Cell(1).GetValue<string>() ?? string.Empty,
                            Name = row.Cell(2).GetValue<string>() ?? string.Empty,
                            Gender = row.Cell(3).GetValue<string>() ?? string.Empty,
                            Age = row.Cell(4).GetValue<int>(),
                            Class = row.Cell(5).GetValue<string>() ?? string.Empty,
                            Major = row.Cell(6).GetValue<string>() ?? string.Empty,
                            Phone = row.Cell(7).GetValue<string>() ?? string.Empty,
                            Email = row.Cell(8).GetValue<string>() ?? string.Empty
                        };
                        
                        // 尝试解析入学时间
                        if (DateTime.TryParse(row.Cell(9).GetValue<string>(), out DateTime enrollmentDate))
                        {
                            student.EnrollmentDate = enrollmentDate;
                        }
                        
                        // 尝试解析日期时间
                        if (DateTime.TryParse(row.Cell(10).GetValue<string>(), out DateTime createdAt))
                        {
                            student.CreatedAt = createdAt;
                        }
                        
                        if (DateTime.TryParse(row.Cell(11).GetValue<string>(), out DateTime updatedAt))
                        {
                            student.UpdatedAt = updatedAt;
                        }
                        
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("从Excel导入学生信息时发生错误: " + ex.Message);
            }
            
            return students;
        }
        
        public bool ExportTeachersToExcel(List<Teacher> teachers, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("教师信息");
                    
                    // 添加标题行
                    worksheet.Cell(1, 1).Value = "工号";
                    worksheet.Cell(1, 2).Value = "姓名";
                    worksheet.Cell(1, 3).Value = "性别";
                    worksheet.Cell(1, 4).Value = "年龄";
                    worksheet.Cell(1, 5).Value = "部门";
                    worksheet.Cell(1, 6).Value = "职称";
                    worksheet.Cell(1, 7).Value = "电话";
                    worksheet.Cell(1, 8).Value = "邮箱";
                    worksheet.Cell(1, 9).Value = "创建时间";
                    worksheet.Cell(1, 10).Value = "更新时间";
                    
                    // 添加数据行
                    for (int i = 0; i < teachers.Count; i++)
                    {
                        var teacher = teachers[i];
                        int row = i + 2; // 从第二行开始
                        
                        worksheet.Cell(row, 1).Value = teacher.TeacherId;
                        worksheet.Cell(row, 2).Value = teacher.Name;
                        worksheet.Cell(row, 3).Value = teacher.Gender;
                        worksheet.Cell(row, 4).Value = teacher.Age;
                        worksheet.Cell(row, 5).Value = teacher.Department;
                        worksheet.Cell(row, 6).Value = teacher.Title;
                        worksheet.Cell(row, 7).Value = teacher.Phone;
                        worksheet.Cell(row, 8).Value = teacher.Email;
                        worksheet.Cell(row, 9).Value = teacher.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cell(row, 10).Value = teacher.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    // 自动调整列宽
                    worksheet.Columns().AdjustToContents();
                    
                    // 保存文件
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("导出教师信息到Excel时发生错误: " + ex.Message);
            }
        }
        
        public List<Teacher> ImportTeachersFromExcel(string filePath)
        {
            var teachers = new List<Teacher>();
            
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    
                    // 跳过标题行，从第二行开始读取数据
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue; // 跳过标题行
                        
                        var teacher = new Teacher
                        {
                            TeacherId = row.Cell(1).GetValue<string>() ?? string.Empty,
                            Name = row.Cell(2).GetValue<string>() ?? string.Empty,
                            Gender = row.Cell(3).GetValue<string>() ?? string.Empty,
                            Age = row.Cell(4).GetValue<int>(),
                            Department = row.Cell(5).GetValue<string>() ?? string.Empty,
                            Title = row.Cell(6).GetValue<string>() ?? string.Empty,
                            Phone = row.Cell(7).GetValue<string>() ?? string.Empty,
                            Email = row.Cell(8).GetValue<string>() ?? string.Empty
                        };
                        
                        // 尝试解析日期时间
                        if (DateTime.TryParse(row.Cell(9).GetValue<string>(), out DateTime createdAt))
                        {
                            teacher.CreatedAt = createdAt;
                        }
                        
                        if (DateTime.TryParse(row.Cell(10).GetValue<string>(), out DateTime updatedAt))
                        {
                            teacher.UpdatedAt = updatedAt;
                        }
                        
                        teachers.Add(teacher);
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("从Excel导入教师信息时发生错误: " + ex.Message);
            }
            
            return teachers;
        }
        
        public bool ExportCoursesToExcel(List<Course> courses, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("课程信息");
                    
                    // 添加标题行
                    worksheet.Cell(1, 1).Value = "课程代码";
                    worksheet.Cell(1, 2).Value = "课程名称";
                    worksheet.Cell(1, 3).Value = "授课教师";
                    worksheet.Cell(1, 4).Value = "学分";
                    worksheet.Cell(1, 5).Value = "课程类型";
                    worksheet.Cell(1, 6).Value = "创建时间";
                    worksheet.Cell(1, 7).Value = "更新时间";
                    
                    // 添加数据行
                    for (int i = 0; i < courses.Count; i++)
                    {
                        var course = courses[i];
                        int row = i + 2; // 从第二行开始
                        
                        worksheet.Cell(row, 1).Value = course.course_id;
                        worksheet.Cell(row, 2).Value = course.Name;
                        worksheet.Cell(row, 3).Value = course.TeacherName;
                        worksheet.Cell(row, 4).Value = course.Credit;
                        worksheet.Cell(row, 5).Value = course.Type;
                        worksheet.Cell(row, 6).Value = course.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cell(row, 7).Value = course.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    // 自动调整列宽
                    worksheet.Columns().AdjustToContents();
                    
                    // 保存文件
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("导出课程信息到Excel时发生错误: " + ex.Message);
            }
        }
        
        public List<Course> ImportCoursesFromExcel(string filePath)
        {
            var courses = new List<Course>();
            
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    
                    // 跳过标题行，从第二行开始读取数据
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue; // 跳过标题行
                        
                        var course = new Course
                        {
                            course_id = row.Cell(1).GetValue<string>() ?? string.Empty,
                            Name = row.Cell(2).GetValue<string>() ?? string.Empty,
                            TeacherId = row.Cell(3).GetValue<string>() ?? string.Empty,
                            Credit = row.Cell(4).GetValue<int>(),
                            Type = row.Cell(5).GetValue<string>() ?? string.Empty
                        };
                        
                        // 尝试解析日期时间
                        if (DateTime.TryParse(row.Cell(6).GetValue<string>(), out DateTime createdAt))
                        {
                            course.CreatedAt = createdAt;
                        }
                        
                        if (DateTime.TryParse(row.Cell(7).GetValue<string>(), out DateTime updatedAt))
                        {
                            course.UpdatedAt = updatedAt;
                        }
                        
                        courses.Add(course);
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("从Excel导入课程信息时发生错误: " + ex.Message);
            }
            
            return courses;
        }
        
        public bool ExportScoresToExcel(List<Score> scores, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("成绩信息");
                    
                    // 添加标题行
                    worksheet.Cell(1, 1).Value = "学生学号";
                    worksheet.Cell(1, 2).Value = "学生姓名";
                    worksheet.Cell(1, 3).Value = "课程代码";
                    worksheet.Cell(1, 4).Value = "课程名称";
                    worksheet.Cell(1, 5).Value = "成绩";
                    worksheet.Cell(1, 6).Value = "学期";
                    worksheet.Cell(1, 7).Value = "考试日期";
                    worksheet.Cell(1, 8).Value = "创建时间";
                    worksheet.Cell(1, 9).Value = "更新时间";
                    
                    // 添加数据行
                    for (int i = 0; i < scores.Count; i++)
                    {
                        var score = scores[i];
                        int row = i + 2; // 从第二行开始
                        
                        worksheet.Cell(row, 1).Value = score.student_id;
                        worksheet.Cell(row, 2).Value = score.StudentName;
                        worksheet.Cell(row, 3).Value = score.course_id;
                        worksheet.Cell(row, 4).Value = score.CourseName;
                        worksheet.Cell(row, 5).Value = score.score;
                        worksheet.Cell(row, 6).Value = score.term;
                        worksheet.Cell(row, 7).Value = score.exam_date?.ToString("yyyy-MM-dd") ?? "";
                        worksheet.Cell(row, 8).Value = score.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cell(row, 9).Value = score.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    // 自动调整列宽
                    worksheet.Columns().AdjustToContents();
                    
                    // 保存文件
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("导出成绩信息到Excel时发生错误: " + ex.Message);
            }
        }
        
        public List<Score> ImportScoresFromExcel(string filePath)
        {
            var scores = new List<Score>();
            
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    
                    // 跳过标题行，从第二行开始读取数据
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue; // 跳过标题行
                        
                        var score = new Score
                        {
                            student_id = row.Cell(1).GetValue<string>() ?? string.Empty,
                            StudentName = row.Cell(2).GetValue<string>() ?? string.Empty,
                            course_id = row.Cell(3).GetValue<string>() ?? string.Empty,
                            CourseName = row.Cell(4).GetValue<string>() ?? string.Empty,
                            score = row.Cell(5).GetValue<decimal>(),
                            term = row.Cell(6).GetValue<string>() ?? string.Empty
                        };
                        
                        // 尝试解析考试日期
                        string examDateStr = row.Cell(7).GetValue<string>();
                        if (!string.IsNullOrEmpty(examDateStr) && DateTime.TryParse(examDateStr, out DateTime examDate))
                        {
                            score.exam_date = examDate;
                        }
                        
                        // 尝试解析日期时间
                        if (DateTime.TryParse(row.Cell(8).GetValue<string>(), out DateTime createdAt))
                        {
                            score.CreatedAt = createdAt;
                        }
                        
                        if (DateTime.TryParse(row.Cell(9).GetValue<string>(), out DateTime updatedAt))
                        {
                            score.UpdatedAt = updatedAt;
                        }
                        
                        scores.Add(score);
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("从Excel导入成绩信息时发生错误: " + ex.Message);
            }
            
            return scores;
        }
    }
}