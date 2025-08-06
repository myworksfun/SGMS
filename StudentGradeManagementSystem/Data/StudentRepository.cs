using MySqlConnector;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Services;
using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem.Data
{
    public class StudentRepository
    {
        private readonly LoggingService _loggingService;

        public StudentRepository()
        {
            _loggingService = new LoggingService();
        }
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM students ORDER BY id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    student_id = reader["student_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Age = reader["age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["age"]),
                                    Class = reader["class"].ToString() ?? string.Empty,
                                    Major = reader["major"].ToString() ?? string.Empty,
                                    Phone = reader["phone"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
                                    CreatedAt = reader["created_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = reader["updated_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["updated_at"]),
                                    EnrollmentDate = reader["enrollment_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["enrollment_date"])
                                };
                                students.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Retrieval", "获取所有学生数据时发生错误", ex.ToString());
                throw new Exception("获取所有学生数据时发生错误: " + ex.Message);
            }
            
            return students;
        }
        
        public List<Student> GetStudentsByPage(int pageNumber, int pageSize, out int totalRecords, int userId = 0)
        {
            var students = new List<Student>();
            totalRecords = 0;
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 获取总记录数
                    var countQuery = "SELECT COUNT(*) FROM students";
                    using (var countCommand = new MySqlCommand(countQuery, connection))
                    {
                        totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
                    }
                    
                    // 计算偏移量
                    int offset = (pageNumber - 1) * pageSize;
                    
                    // 获取分页数据
                    var query = @"SELECT * FROM students 
                                 ORDER BY id 
                                 LIMIT @limit OFFSET @offset";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", pageSize);
                        command.Parameters.AddWithValue("@offset", offset);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    student_id = reader["student_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Age = reader["age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["age"]),
                                    Class = reader["class"].ToString() ?? string.Empty,
                                    Major = reader["major"].ToString() ?? string.Empty,
                                    Phone = reader["phone"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
                                    CreatedAt = reader["created_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = reader["updated_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["updated_at"]),
                                    EnrollmentDate = reader["enrollment_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["enrollment_date"])
                                };
                                students.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Retrieval", "获取学生分页数据时发生错误", ex.ToString());
            }
            
            return students;
        }
        
        public Student? GetStudentById(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM students WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var student = new Student
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    student_id = reader["student_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Age = reader["age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["age"]),
                                    Class = reader["class"].ToString() ?? string.Empty,
                                    Major = reader["major"].ToString() ?? string.Empty,
                                    Phone = reader["phone"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
                                    CreatedAt = reader["created_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = reader["updated_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["updated_at"]),
                                    EnrollmentDate = reader["enrollment_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["enrollment_date"])
                                };
                                return student;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Retrieval", "根据ID获取学生数据时发生错误", ex.ToString());
                throw new Exception("根据ID获取学生数据时发生错误: " + ex.Message);
            }
            
            return null;
        }
        
        public bool AddStudent(Student student, int currentUserId, string currentUsername)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO students (student_id, name, gender, age, class, major, phone, email, enrollment_date) 
                                 VALUES (@student_id, @name, @gender, @age, @class, @major, @phone, @email, @enrollment_date)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@student_id", student.student_id);
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@gender", student.Gender);
                        command.Parameters.AddWithValue("@age", student.Age);
                        command.Parameters.AddWithValue("@class", student.Class);
                        command.Parameters.AddWithValue("@major", student.Major);
                        command.Parameters.AddWithValue("@phone", student.Phone);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@enrollment_date", student.EnrollmentDate ?? (object)DBNull.Value);
                        
                        var result = command.ExecuteNonQuery();
                        
                        // 记录操作日志
                        if (result > 0)
                        {
                            _loggingService.LogUserAction(
                                currentUserId.ToString(), 
                                currentUsername, 
                                "添加学生", 
                                $"添加学生信息：{student.Name}({student.student_id})"
                            );
                        }
                        
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Creation", "添加学生时发生错误", ex.ToString());
                throw new Exception("添加学生时发生错误: " + ex.Message);
            }
        }
        
        public bool UpdateStudent(Student student, int currentUserId, string currentUsername)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"UPDATE students 
                                 SET name = @name, gender = @gender, age = @age, class = @class, major = @major, 
                                     phone = @phone, email = @email, enrollment_date = @enrollment_date, updated_at = CURRENT_TIMESTAMP()
                                 WHERE student_id = @student_id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@student_id", student.student_id);
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@gender", student.Gender);
                        command.Parameters.AddWithValue("@age", student.Age);
                        command.Parameters.AddWithValue("@class", student.Class);
                        command.Parameters.AddWithValue("@major", student.Major);
                        command.Parameters.AddWithValue("@phone", student.Phone);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@enrollment_date", student.EnrollmentDate ?? (object)DBNull.Value);
                        
                        var result = command.ExecuteNonQuery();
                        
                        // 记录操作日志
                        if (result > 0)
                        {
                            _loggingService.LogUserAction(
                                currentUserId.ToString(), 
                                currentUsername, 
                                "修改学生", 
                                $"修改学生信息：{student.Name}({student.student_id})"
                            );
                        }
                        
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Update", "更新学生信息时发生错误", ex.ToString());
                throw new Exception("更新学生信息时发生错误: " + ex.Message);
            }
        }
        
        public bool DeleteStudent(string studentId, int currentUserId, string currentUsername)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 检查学生是否有成绩记录
                    var checkScoresQuery = "SELECT COUNT(*) FROM scores WHERE student_id = @student_id";
                    using (var checkCommand = new MySqlCommand(checkScoresQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@student_id", studentId);
                        var scoreCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        
                        if (scoreCount > 0)
                        {
                            throw new Exception("无法删除学生，该学生仍有成绩记录。请先删除相关成绩记录再尝试删除学生。");
                        }
                    }
                    
                    // 软删除
                    var query = "UPDATE students SET deleted_at = CURRENT_TIMESTAMP() WHERE student_id = @student_id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@student_id", studentId);
                        
                        var result = command.ExecuteNonQuery();
                        
                        // 记录操作日志
                        if (result > 0)
                        {
                            _loggingService.LogUserAction(
                                currentUserId.ToString(), 
                                currentUsername, 
                                "删除学生", 
                                $"删除学生信息：{studentId}"
                            );
                        }
                        
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Deletion", "删除学生时发生错误", ex.ToString());
                throw new Exception("删除学生时发生错误: " + ex.Message);
            }
        }
        
        public List<Student> SearchStudents(string keyword)
        {
            var students = new List<Student>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var query = @"SELECT * FROM students 
                                 WHERE name LIKE @keyword OR student_id LIKE @keyword OR class LIKE @keyword OR major LIKE @keyword";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var student = new Student
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    student_id = reader["student_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Age = Convert.ToInt32(reader["age"]),
                                    Class = reader["class"].ToString() ?? string.Empty,
                                    Major = reader["major"].ToString() ?? string.Empty,
                                    Phone = reader["phone"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
                                    EnrollmentDate = reader["enrollment_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["enrollment_date"])
                                };
                                students.Add(student);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Student Search", "搜索学生时发生错误", ex.ToString());
                throw new Exception("搜索学生时发生错误: " + ex.Message);
            }
            
            return students;
        }
    }
}