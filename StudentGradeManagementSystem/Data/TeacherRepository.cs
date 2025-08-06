using MySqlConnector;
using StudentGradeManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem.Data
{
    public class TeacherRepository
    {
        public List<Teacher> GetAllTeachers()
        {
            var teachers = new List<Teacher>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM teachers WHERE deleted_at IS NULL ORDER BY id";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var teacher = new Teacher
                            {
                                Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                TeacherId = reader["teacher_id"] != DBNull.Value ? reader["teacher_id"].ToString() ?? string.Empty : string.Empty,
                                Name = reader["name"] != DBNull.Value ? reader["name"].ToString() ?? string.Empty : string.Empty,
                                Gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() ?? string.Empty : string.Empty,
                                Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : 0,
                                Department = reader["department"] != DBNull.Value ? reader["department"].ToString() ?? string.Empty : string.Empty,
                                Title = reader["title"] != DBNull.Value ? reader["title"].ToString() ?? string.Empty : string.Empty,
                                Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() ?? string.Empty : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() ?? string.Empty : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
                            };
                            
                            teachers.Add(teacher);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取教师列表时发生错误: " + ex.Message);
            }
            
            return teachers;
        }
        
        public List<Teacher> GetTeachersByPage(int pageNumber, int pageSize, out int totalCount)
        {
            var teachers = new List<Teacher>();
            totalCount = 0;
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 先获取总记录数
                    var countQuery = "SELECT COUNT(*) FROM teachers WHERE deleted_at IS NULL";
                    using (var countCommand = new MySqlCommand(countQuery, connection))
                    {
                        totalCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    }
                    
                    // 获取分页数据
                    var offset = (pageNumber - 1) * pageSize;
                    var query = $"SELECT * FROM teachers WHERE deleted_at IS NULL ORDER BY id LIMIT {pageSize} OFFSET {offset}";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var teacher = new Teacher
                            {
                                Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                TeacherId = reader["teacher_id"] != DBNull.Value ? reader["teacher_id"].ToString() ?? string.Empty : string.Empty,
                                Name = reader["name"] != DBNull.Value ? reader["name"].ToString() ?? string.Empty : string.Empty,
                                Gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() ?? string.Empty : string.Empty,
                                Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : 0,
                                Department = reader["department"] != DBNull.Value ? reader["department"].ToString() ?? string.Empty : string.Empty,
                                Title = reader["title"] != DBNull.Value ? reader["title"].ToString() ?? string.Empty : string.Empty,
                                Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() ?? string.Empty : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() ?? string.Empty : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
                            };
                            
                            teachers.Add(teacher);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取教师分页数据时发生错误: " + ex.Message);
            }
            
            return teachers;
        }
        
        public Teacher? GetTeacherById(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM teachers WHERE id = @id AND deleted_at IS NULL";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Teacher
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    TeacherId = reader["teacher_id"].ToString() ?? string.Empty,
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Gender = reader["gender"].ToString() ?? string.Empty,
                                    Age = Convert.ToInt32(reader["age"]),
                                    Department = reader["department"].ToString() ?? string.Empty,
                                    Title = reader["title"].ToString() ?? string.Empty,
                                    Phone = reader["phone"].ToString() ?? string.Empty,
                                    Email = reader["email"].ToString() ?? string.Empty,
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
                throw new Exception("获取教师信息时发生错误: " + ex.Message);
            }
            
            return null;
        }
        
        public bool AddTeacher(Teacher teacher)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO teachers (teacher_id, name, gender, age, department, title, phone, email) 
                                 VALUES (@teacher_id, @name, @gender, @age, @department, @title, @phone, @email)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@teacher_id", teacher.TeacherId);
                        command.Parameters.AddWithValue("@name", teacher.Name);
                        command.Parameters.AddWithValue("@gender", teacher.Gender);
                        command.Parameters.AddWithValue("@age", teacher.Age);
                        command.Parameters.AddWithValue("@department", teacher.Department);
                        command.Parameters.AddWithValue("@title", teacher.Title);
                        command.Parameters.AddWithValue("@phone", teacher.Phone);
                        command.Parameters.AddWithValue("@email", teacher.Email);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加教师时发生错误: " + ex.Message);
            }
        }
        
        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"UPDATE teachers 
                                 SET teacher_id = @teacher_id, name = @name, gender = @gender, age = @age, 
                                     department = @department, title = @title, phone = @phone, email = @email 
                                 WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", teacher.Id);
                        command.Parameters.AddWithValue("@teacher_id", teacher.TeacherId);
                        command.Parameters.AddWithValue("@name", teacher.Name);
                        command.Parameters.AddWithValue("@gender", teacher.Gender);
                        command.Parameters.AddWithValue("@age", teacher.Age);
                        command.Parameters.AddWithValue("@department", teacher.Department);
                        command.Parameters.AddWithValue("@title", teacher.Title);
                        command.Parameters.AddWithValue("@phone", teacher.Phone);
                        command.Parameters.AddWithValue("@email", teacher.Email);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("更新教师信息时发生错误: " + ex.Message);
            }
        }
        
        public bool DeleteTeacher(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 软删除，设置deleted_at字段
                    var query = "UPDATE teachers SET deleted_at = @deleted_at WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@deleted_at", DateTime.Now);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("删除教师时发生错误: " + ex.Message);
            }
        }
    }
}