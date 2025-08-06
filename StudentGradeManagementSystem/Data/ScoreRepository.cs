using MySqlConnector;
using StudentGradeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentGradeManagementSystem.Data
{
    public class ScoreRepository
    {
        #region 成绩相关操作

        public List<Score> GetAllScores()
        {
            var scores = new List<Score>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT s.*, st.name as student_name, c.name as course_name 
                                 FROM scores s 
                                 LEFT JOIN students st ON s.student_id = st.student_id 
                                 LEFT JOIN courses c ON s.course_id = c.course_id 
                                 ORDER BY s.id";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scores.Add(CreateScoreFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取成绩列表时发生错误: " + ex.Message);
            }
            
            return scores;
        }
        
        public List<Score> GetScoresByPage(int pageNumber, int pageSize, out int totalCount)
        {
            var scores = new List<Score>();
            totalCount = 0;
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 先获取总记录数
                    var countQuery = @"SELECT COUNT(*) FROM scores s 
                                      LEFT JOIN students st ON s.student_id = st.student_id 
                                      LEFT JOIN courses c ON s.course_id = c.course_id";
                    using (var countCommand = new MySqlCommand(countQuery, connection))
                    {
                        totalCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    }
                    
                    // 获取分页数据
                    var offset = (pageNumber - 1) * pageSize;
                    var query = @"SELECT s.*, st.name as student_name, c.name as course_name 
                                  FROM scores s 
                                  LEFT JOIN students st ON s.student_id = st.student_id 
                                  LEFT JOIN courses c ON s.course_id = c.course_id 
                                  ORDER BY s.id 
                                  LIMIT @limit OFFSET @offset";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", pageSize);
                        command.Parameters.AddWithValue("@offset", offset);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scores.Add(CreateScoreFromReader(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取成绩分页数据时发生错误: " + ex.Message);
            }
            
            return scores;
        }
        
        public async Task<List<Score>> GetAllScoresAsync()
        {
            var scores = new List<Score>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    
                    var query = @"SELECT s.*, st.name as student_name, c.name as course_name 
                                 FROM scores s 
                                 LEFT JOIN students st ON s.student_id = st.student_id 
                                 LEFT JOIN courses c ON s.course_id = c.course_id 
                                 ORDER BY s.id";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            scores.Add(CreateScoreFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取成绩列表时发生错误: " + ex.Message);
            }
            
            return scores;
        }
        
        public Score? GetScoreById(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT s.*, st.name as student_name, c.name as course_name 
                                 FROM scores s 
                                 LEFT JOIN students st ON s.student_id = st.student_id 
                                 LEFT JOIN courses c ON s.course_id = c.course_id 
                                 WHERE s.id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return CreateScoreFromReader(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取成绩信息时发生错误: " + ex.Message);
            }
            
            return null;
        }
        
        public async Task<Score?> GetScoreByIdAsync(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    
                    var query = @"SELECT s.*, st.name as student_name, c.name as course_name 
                                 FROM scores s 
                                 LEFT JOIN students st ON s.student_id = st.student_id 
                                 LEFT JOIN courses c ON s.course_id = c.course_id 
                                 WHERE s.id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return CreateScoreFromReader(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取成绩信息时发生错误: " + ex.Message);
            }
            
            return null;
        }
        
        public bool AddScore(Score score)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO scores (student_id, course_id, score, term, exam_date) 
                                 VALUES (@student_id, @course_id, @score, @term, @exam_date)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@student_id", score.student_id);
                        command.Parameters.AddWithValue("@course_id", score.course_id);
                        command.Parameters.AddWithValue("@score", score.score);
                        command.Parameters.AddWithValue("@term", score.term);
                        command.Parameters.AddWithValue("@exam_date", score.exam_date ?? (object)DBNull.Value);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加成绩时发生错误: " + ex.Message);
            }
        }
        
        public async Task<bool> AddScoreAsync(Score score)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    
                    var query = @"INSERT INTO scores (student_id, course_id, score, term, exam_date) 
                                 VALUES (@student_id, @course_id, @score, @term, @exam_date)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@student_id", score.student_id);
                        command.Parameters.AddWithValue("@course_id", score.course_id);
                        command.Parameters.AddWithValue("@score", score.score);
                        command.Parameters.AddWithValue("@term", score.term);
                        command.Parameters.AddWithValue("@exam_date", score.exam_date ?? (object)DBNull.Value);
                        
                        var result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加成绩时发生错误: " + ex.Message);
            }
        }
        
        public bool UpdateScore(Score score)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"UPDATE scores 
                                 SET student_id = @student_id, course_id = @course_id, score = @score, 
                                     term = @term, exam_date = @exam_date 
                                 WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", score.Id);
                        command.Parameters.AddWithValue("@student_id", score.student_id);
                        command.Parameters.AddWithValue("@course_id", score.course_id);
                        command.Parameters.AddWithValue("@score", score.score);
                        command.Parameters.AddWithValue("@term", score.term);
                        command.Parameters.AddWithValue("@exam_date", score.exam_date ?? (object)DBNull.Value);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("更新成绩信息时发生错误: " + ex.Message);
            }
        }
        
        public async Task<bool> UpdateScoreAsync(Score score)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    
                    var query = @"UPDATE scores 
                                 SET student_id = @student_id, course_id = @course_id, score = @score, 
                                     term = @term, exam_date = @exam_date 
                                 WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", score.Id);
                        command.Parameters.AddWithValue("@student_id", score.student_id);
                        command.Parameters.AddWithValue("@course_id", score.course_id);
                        command.Parameters.AddWithValue("@score", score.score);
                        command.Parameters.AddWithValue("@term", score.term);
                        command.Parameters.AddWithValue("@exam_date", score.exam_date ?? (object)DBNull.Value);
                        
                        var result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("更新成绩信息时发生错误: " + ex.Message);
            }
        }
        
        public bool DeleteScore(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "DELETE FROM scores WHERE id = @id";
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
                throw new Exception("删除成绩时发生错误: " + ex.Message);
            }
        }
        
        public async Task<bool> DeleteScoreAsync(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    
                    var query = "DELETE FROM scores WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        
                        var result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("删除成绩时发生错误: " + ex.Message);
            }
        }

        #endregion

        #region 学生相关操作

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
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student
                            {
                                Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                                student_id = reader["student_id"] != DBNull.Value ? reader["student_id"].ToString() ?? string.Empty : string.Empty,
                                Name = reader["name"] != DBNull.Value ? reader["name"].ToString() ?? string.Empty : string.Empty,
                                Gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() ?? string.Empty : string.Empty,
                                Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : 0,
                                Class = reader["class"] != DBNull.Value ? reader["class"].ToString() ?? string.Empty : string.Empty,
                                Major = reader["major"] != DBNull.Value ? reader["major"].ToString() ?? string.Empty : string.Empty,
                                Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() ?? string.Empty : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() ?? string.Empty : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
                            };
                            
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取学生列表时发生错误: " + ex.Message);
            }
            
            return students;
        }

        #endregion

        #region 课程相关操作

        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM courses ORDER BY id";
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
                                TeacherName = reader["teacher_name"] != DBNull.Value ? reader["teacher_name"]?.ToString() ?? string.Empty : string.Empty,
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

        #endregion

        #region 私有方法

        /// <summary>
        /// 从IDataReader创建Score对象
        /// </summary>
        private Score CreateScoreFromReader(MySqlDataReader reader)
        {
            return new Score
            {
                Id = reader.GetOrdinal("id") >= 0 && reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                student_id = reader.GetOrdinal("student_id") >= 0 ? (reader["student_id"] != DBNull.Value ? reader["student_id"].ToString() ?? string.Empty : string.Empty) : string.Empty,
                StudentName = reader.GetOrdinal("student_name") >= 0 ? (reader["student_name"] != DBNull.Value ? reader["student_name"]?.ToString() ?? string.Empty : string.Empty) : string.Empty,
                course_id = reader.GetOrdinal("course_id") >= 0 ? (reader["course_id"] != DBNull.Value ? reader["course_id"].ToString() ?? string.Empty : string.Empty) : string.Empty,
                CourseName = reader.GetOrdinal("course_name") >= 0 ? (reader["course_name"] != DBNull.Value ? reader["course_name"]?.ToString() ?? string.Empty : string.Empty) : string.Empty,
                score = reader.GetOrdinal("score") >= 0 && reader["score"] != DBNull.Value ? Convert.ToDecimal(reader["score"]) : 0,
                term = reader.GetOrdinal("term") >= 0 ? (reader["term"] != DBNull.Value ? reader["term"].ToString() ?? string.Empty : string.Empty) : string.Empty,
                exam_date = reader.GetOrdinal("exam_date") >= 0 && reader["exam_date"] != DBNull.Value ? Convert.ToDateTime(reader["exam_date"]) : (DateTime?)null,
                CreatedAt = reader.GetOrdinal("created_at") >= 0 && reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.Now,
                UpdatedAt = reader.GetOrdinal("updated_at") >= 0 && reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.Now
            };
        }

        #endregion
    }
}