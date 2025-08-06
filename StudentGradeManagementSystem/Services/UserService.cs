using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Data;
using System;
using MySqlConnector;
using BCrypt.Net;

namespace StudentGradeManagementSystem.Services
{
    public class UserService
    {
        private LogRepository _logRepository = new LogRepository();
        
        /// <summary>
        /// 验证用户身份
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>用户对象，如果验证失败则返回null</returns>
        public User? AuthenticateUser(string username, string password)
        {
            // 验证用户凭据
            if (DatabaseHelper.AuthenticateUser(username, password))
            {
                // 获取用户详细信息
                var user = DatabaseHelper.GetUserByUsername(username);
                
                
                return user;
            }
            
            return null;
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>更新是否成功</returns>
        public bool UpdatePassword(int userId, string newPassword)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    
                    var query = "UPDATE users SET password_hash = @password_hash, require_password_change = 0 WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@password_hash", hashedPassword);
                        command.Parameters.AddWithValue("@id", userId);
                        
                        var result = command.ExecuteNonQuery();
                        
                        // 记录密码修改日志
                        if (result > 0)
                        {
                            var user = DatabaseHelper.GetUserById(userId);
                            if (user != null)
                            {
                                var log = new OperationLog
                                {
                                    UserId = userId,
                                    Username = user.Username,
                                    Operation = "修改密码",
                                    Description = $"用户 {user.Username} 修改了登录密码",
                                    IPAddress = NetworkUtils.GetLocalIPAddress(),
                                    UserAgent = Environment.MachineName
                                };
                                _logRepository.AddUserLog(log);
                            }
                        }
                        
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 在实际应用中应该记录日志
                throw new Exception("更新用户密码时发生错误: " + ex.Message);
            }
        }

    }
}