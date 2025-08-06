using MySqlConnector;
using StudentGradeManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem.Data
{
    public class LogRepository
    {
        public bool AddUserLog(OperationLog log)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO operation_logs (user_id, username, log_type, operation, description, ip_address, user_agent) 
                                 VALUES (@user_id, @username, @log_type, @operation, @description, @ip_address, @user_agent)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", log.UserId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@username", log.Username);
                        command.Parameters.AddWithValue("@log_type", "USER_ACTION");
                        command.Parameters.AddWithValue("@operation", log.Operation);
                        command.Parameters.AddWithValue("@description", log.Description);
                        command.Parameters.AddWithValue("@ip_address", log.IPAddress);
                        command.Parameters.AddWithValue("@user_agent", log.UserAgent);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加用户日志时发生错误: " + ex.Message);
            }
        }
        
        public bool AddSystemLog(string message)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO operation_logs (log_type, operation, description) 
                                 VALUES (@log_type, @operation, @description)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@log_type", "SYSTEM_EVENT");
                        command.Parameters.AddWithValue("@operation", "System Event");
                        command.Parameters.AddWithValue("@description", message);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加系统日志时发生错误: " + ex.Message);
            }
        }
        
        public bool AddSystemLog(string operation, string message)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"INSERT INTO operation_logs (log_type, operation, description) 
                                 VALUES (@log_type, @operation, @description)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@log_type", "SYSTEM_EVENT");
                        command.Parameters.AddWithValue("@operation", operation);
                        command.Parameters.AddWithValue("@description", message);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("添加系统日志时发生错误: " + ex.Message);
            }
        }
        
        public List<OperationLog> GetUserLogs(int limit = 100)
        {
            var logs = new List<OperationLog>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT * FROM operation_logs 
                                 WHERE log_type = 'USER_ACTION'
                                 ORDER BY created_at DESC 
                                 LIMIT @limit";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var log = new OperationLog
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = reader["user_id"] as int? ?? null,
                                    Username = reader["username"]?.ToString() ?? string.Empty,
                                    LogType = reader["log_type"].ToString() ?? string.Empty,
                                    Operation = reader["operation"]?.ToString() ?? string.Empty,
                                    Description = reader["description"]?.ToString() ?? string.Empty,
                                    IPAddress = reader["ip_address"]?.ToString() ?? string.Empty,
                                    UserAgent = reader["user_agent"]?.ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };
                                
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取用户日志时发生错误: " + ex.Message);
            }
            
            return logs;
        }
        
        public List<OperationLog> GetSystemLogs(int limit = 100)
        {
            var logs = new List<OperationLog>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT * FROM operation_logs 
                                 WHERE log_type = 'SYSTEM_EVENT'
                                 ORDER BY created_at DESC 
                                 LIMIT @limit";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var log = new OperationLog
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = reader["user_id"] as int? ?? null,
                                    Username = reader["username"]?.ToString() ?? string.Empty,
                                    LogType = reader["log_type"].ToString() ?? string.Empty,
                                    Operation = reader["operation"]?.ToString() ?? string.Empty,
                                    Description = reader["description"]?.ToString() ?? string.Empty,
                                    IPAddress = reader["ip_address"]?.ToString() ?? string.Empty,
                                    UserAgent = reader["user_agent"]?.ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };
                                
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取系统日志时发生错误: " + ex.Message);
            }
            
            return logs;
        }
        
        public List<OperationLog> GetAllLogs(int limit = 100)
        {
            var logs = new List<OperationLog>();
            
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT * FROM operation_logs 
                                 ORDER BY created_at DESC 
                                 LIMIT @limit";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var log = new OperationLog
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = reader["user_id"] as int? ?? null,
                                    Username = reader["username"]?.ToString() ?? string.Empty,
                                    LogType = reader["log_type"].ToString() ?? string.Empty,
                                    Operation = reader["operation"]?.ToString() ?? string.Empty,
                                    Description = reader["description"]?.ToString() ?? string.Empty,
                                    IPAddress = reader["ip_address"]?.ToString() ?? string.Empty,
                                    UserAgent = reader["user_agent"]?.ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };
                                
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("获取所有日志时发生错误: " + ex.Message);
            }
            
            return logs;
        }
        
        public bool DeleteLog(int logId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = @"DELETE FROM operation_logs WHERE id = @log_id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@log_id", logId);
                        
                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("删除日志时发生错误: " + ex.Message);
            }
        }
        
        public int DeleteLogs(List<int> logIds)
        {
            if (logIds == null || logIds.Count == 0)
                return 0;
                
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    // 构建参数化查询以防止SQL注入
                    var parameters = logIds.Select((id, index) => $"@log_id{index}").ToList();
                    var parameterPlaceholders = string.Join(",", parameters);
                    var query = $"DELETE FROM operation_logs WHERE id IN ({parameterPlaceholders})";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        for (int i = 0; i < logIds.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@log_id{i}", logIds[i]);
                        }
                        
                        var result = command.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("批量删除日志时发生错误: " + ex.Message);
            }
        }
    }
}