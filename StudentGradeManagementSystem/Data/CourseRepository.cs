using MySqlConnector;
using StudentGradeManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem.Data
{
    public class CourseRepository
    {
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT c.*, t.name as teacher_name 
                                 FROM courses c 
                                 LEFT JOIN teachers t ON c.teacher_id = t.teacher_id 
                                 ORDER BY c.id";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course
                            {
                                Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                course_id = reader["course_id"] != DBNull.Value ? reader["course_id"].ToString() ?? string.Empty : string.Empty,
                                Name = reader["name"] != DBNull.Value ? reader["name"].ToString() ?? string.Empty : string.Empty,
                                TeacherId = reader["teacher_id"] != DBNull.Value ? reader["teacher_id"].ToString() ?? string.Empty : string.Empty,
                                TeacherName = reader["teacher_name"] != DBNull.Value ? reader["teacher_name"].ToString() ?? string.Empty : string.Empty,
                                Credit = reader["credit"] != DBNull.Value ? Convert.ToInt32(reader["credit"]) : 0,
                                Type = reader["type"] != DBNull.Value ? reader["type"].ToString() ?? string.Empty : string.Empty,
                                Description = reader["description"] != DBNull.Value ? reader["description"].ToString() ?? string.Empty : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
                            };
                            
                            courses.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取课程列表时发生错误: " + ex.Message);
            }
            
            return courses;
        }
        
        public Course? GetCourseById(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT c.*, t.name as teacher_name 
                                 FROM courses c 
                                 LEFT JOIN teachers t ON c.teacher_id = t.teacher_id 
                                 WHERE c.id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Course
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    course_id = reader["course_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    TeacherId = reader["teacher_id"]?.ToString() ?? string.Empty,
                                    TeacherName = reader["teacher_name"]?.ToString() ?? string.Empty,
                                    Credit = Convert.ToInt32(reader["credit"]),
                                    Type = reader["type"].ToString() ?? string.Empty,
                                    Description = reader["description"].ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取课程信息时发生错误: " + ex.Message);
            }
            
            return null;
        }
        
        public bool AddCourse(Course course)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO courses (course_id, name, teacher_id, credit, type, description) 
                                 VALUES (@course_id, @name, @teacher_id, @credit, @type, @description)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@course_id", course.course_id);
                        command.Parameters.AddWithValue("@name", course.Name);
                        command.Parameters.AddWithValue("@teacher_id", course.TeacherId);
                        command.Parameters.AddWithValue("@credit", course.Credit);
                        command.Parameters.AddWithValue("@type", course.Type);
                        command.Parameters.AddWithValue("@description", course.Description);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加课程时发生错误: " + ex.Message);
            }
        }
        
        public bool UpdateCourse(Course course)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"UPDATE courses 
                                 SET course_id = @course_id, name = @name, teacher_id = @teacher_id, 
                                     credit = @credit, type = @type, description = @description 
                                 WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", course.Id);
                        command.Parameters.AddWithValue("@course_id", course.course_id);
                        command.Parameters.AddWithValue("@name", course.Name);
                        command.Parameters.AddWithValue("@teacher_id", course.TeacherId);
                        command.Parameters.AddWithValue("@credit", course.Credit);
                        command.Parameters.AddWithValue("@type", course.Type);
                        command.Parameters.AddWithValue("@description", course.Description);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("更新课程时发生错误: " + ex.Message);
            }
        }
        
        public bool DeleteCourse(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 检查是否有成绩记录关联到该课程
                    var scoreQuery = "SELECT COUNT(*) FROM scores WHERE course_id = (SELECT course_id FROM courses WHERE id = @id)";
                    using (var scoreCommand = new MySqlCommand(scoreQuery, connection))
                    {
                        scoreCommand.Parameters.AddWithValue("@id", id);
                        var scoreCount = Convert.ToInt32(scoreCommand.ExecuteScalar());
                        
                        if (scoreCount > 0)
                        {
                            throw new Exception("无法删除课程，因为存在关联的成绩记录");
                        }
                    }
                    
                    // 执行删除操作
                    var query = "DELETE FROM courses WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("删除课程时发生错误: " + ex.Message);
            }
        }
        
        public List<Course> SearchCourses(string keyword)
        {
            var courses = new List<Course>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT c.*, t.name as teacher_name 
                                 FROM courses c 
                                 LEFT JOIN teachers t ON c.teacher_id = t.teacher_id 
                                 WHERE c.course_id LIKE @keyword OR c.name LIKE @keyword
                                 ORDER BY c.id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var course = new Course
                                {
                                    Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                    course_id = reader["course_id"] != DBNull.Value ? reader["course_id"].ToString() ?? string.Empty : string.Empty,
                                    Name = reader["name"] != DBNull.Value ? reader["name"].ToString() ?? string.Empty : string.Empty,
                                    TeacherId = reader["teacher_id"] != DBNull.Value ? reader["teacher_id"].ToString() ?? string.Empty : string.Empty,
                                    TeacherName = reader["teacher_name"] != DBNull.Value ? reader["teacher_name"].ToString() ?? string.Empty : string.Empty,
                                    Credit = reader["credit"] != DBNull.Value ? Convert.ToInt32(reader["credit"]) : 0,
                                    Type = reader["type"] != DBNull.Value ? reader["type"].ToString() ?? string.Empty : string.Empty,
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() ?? string.Empty : string.Empty,
                                    CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                                    UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
                                };
                                
                                courses.Add(course);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("搜索课程时发生错误: " + ex.Message);
            }
            
            return courses;
        }
    }
}