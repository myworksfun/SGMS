using MySqlConnector;
using System;
using System.Collections.Generic;
using BCrypt.Net;
using System.IO;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Models;

namespace StudentGradeManagementSystem.Data
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = ReadConnectionString();
        private static readonly string BaseConnectionString = ReadBaseConnectionString();
        
        // 日志服务实例
        private static readonly LoggingService _loggingService = new LoggingService();
        
        private static string ReadConnectionString()
        {
            try
            {
                var config = ReadConfig();
                
                // 优先从环境变量读取密码（安全性更高）
                string password = Environment.GetEnvironmentVariable("SGMS_DB_PASSWORD");
                if (string.IsNullOrEmpty(password))
                {
                    // 如果环境变量未设置，则从配置文件读取
                    password = config.ContainsKey("password") ? config["password"] : "";
                }
                
                // 构建连接字符串，添加连接池配置
                return $"server={config["server"]};user={config["user"]};password={password};database={config["database"]};charset=utf8mb4;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;Connection Lifetime=180";
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Read Connection String", "读取数据库配置失败，使用默认连接字符串", ex.ToString());
                // 如果配置文件读取失败，使用默认连接字符串（仅用于开发环境）
                return "server=localhost;user=root;password=123;database=student_grade_db;charset=utf8mb4;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;Connection Lifetime=180";
            }
        }
        
        private static string ReadBaseConnectionString()
        {
            try
            {
                var config = ReadConfig();
                
                // 优先从环境变量读取密码（安全性更高）
                string password = Environment.GetEnvironmentVariable("SGMS_DB_PASSWORD");
                if (string.IsNullOrEmpty(password))
                {
                    // 如果环境变量未设置，则从配置文件读取
                    password = config.ContainsKey("password") ? config["password"] : "";
                }
                
                // 构建连接字符串，添加连接池配置
                return $"server={config["server"]};user={config["user"]};password={password};charset=utf8mb4;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;Connection Lifetime=180";
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Read Base Connection String", "读取数据库配置失败，使用默认连接字符串", ex.ToString());
                // 如果配置文件读取失败，使用默认连接字符串（仅用于开发环境）
                return "server=localhost;user=root;password=123;charset=utf8mb4;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;Connection Lifetime=180";
            }
        }
        
        /// <summary>
        /// 读取数据库配置文件
        /// </summary>
        /// <returns>配置字典</returns>
        private static Dictionary<string, string> ReadConfig()
        {
            var lines = File.ReadAllLines("dbconfig.ini");
            var config = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                // 跳过注释行和空行
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("#"))
                {
                    continue;
                }
                
                if (line.Contains("="))
                {
                    var parts = line.Split('=', 2); // 限制分割次数，避免值中包含等号
                    if (parts.Length == 2)
                    {
                        config[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            return config;
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Database Connection", "测试数据库连接时发生错误", ex.ToString());
                return false;
            }
        }

        public static void CreateDatabaseIfNotExists()
        {
            try
            {
                using (var connection = new MySqlConnection(BaseConnectionString))
                {
                    connection.Open();
                    
                    var createDatabase = "CREATE DATABASE IF NOT EXISTS student_grade_db " +
                                       "CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci";
                    new MySqlCommand(createDatabase, connection).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Database Creation", "创建数据库失败", ex.ToString());
                throw new Exception("创建数据库失败: " + ex.Message);
            }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static void InitializeDatabase()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    
                    // 创建用户表
                    var createUsersTable = @"CREATE TABLE IF NOT EXISTS users (
                                            id INT AUTO_INCREMENT PRIMARY KEY,
                                            username VARCHAR(50) UNIQUE NOT NULL,
                                            password_hash VARCHAR(255) NOT NULL,
                                            role_id INT,
                                            failed_login_attempts INT DEFAULT 0,
                                            locked_until DATETIME NULL,
                                            require_password_change BOOLEAN DEFAULT FALSE,
                                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                            FOREIGN KEY (role_id) REFERENCES roles(id) ON DELETE SET NULL
                                        )";
                    new MySqlCommand(createUsersTable, connection).ExecuteNonQuery();
                    
                    // 创建角色表
                    var createRolesTable = @"CREATE TABLE IF NOT EXISTS roles (
                                            id INT AUTO_INCREMENT PRIMARY KEY,
                                            name VARCHAR(50) UNIQUE NOT NULL,
                                            description TEXT
                                        )";
                    new MySqlCommand(createRolesTable, connection).ExecuteNonQuery();
                    
                    // 创建操作日志表
                    var createOperationLogsTable = @"CREATE TABLE IF NOT EXISTS operation_logs (
                                                    id INT AUTO_INCREMENT PRIMARY KEY,
                                                    user_id INT NULL,
                                                    username VARCHAR(50) NULL,
                                                    log_type VARCHAR(20) NOT NULL DEFAULT 'USER_ACTION',
                                                    operation VARCHAR(100) NULL,
                                                    description TEXT NULL,
                                                    ip_address VARCHAR(45) NULL,
                                                    user_agent TEXT NULL,
                                                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                                                )";
                    new MySqlCommand(createOperationLogsTable, connection).ExecuteNonQuery();
                    
                    // 创建学生表（带索引优化）
                    var createStudentsTable = @"CREATE TABLE IF NOT EXISTS students (
                                               id INT AUTO_INCREMENT PRIMARY KEY,
                                               student_id VARCHAR(20) UNIQUE NOT NULL,
                                               name VARCHAR(50) NOT NULL,
                                               gender VARCHAR(10) NOT NULL,
                                               age INT NOT NULL,
                                               class VARCHAR(50) NOT NULL,
                                               major VARCHAR(100) NOT NULL,
                                               phone VARCHAR(20),
                                               email VARCHAR(100),
                                               enrollment_date DATE,
                                               created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                               updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                                               deleted_at DATETIME NULL,
                                               INDEX idx_student_id (student_id),
                                               INDEX idx_name (name),
                                               INDEX idx_deleted_at (deleted_at)
                                           )";
                    new MySqlCommand(createStudentsTable, connection).ExecuteNonQuery();
                    
                    // 创建教师表（带索引优化）
                    var createTeachersTable = @"CREATE TABLE IF NOT EXISTS teachers (
                                               id INT AUTO_INCREMENT PRIMARY KEY,
                                               teacher_id VARCHAR(20) UNIQUE NOT NULL,
                                               name VARCHAR(50) NOT NULL,
                                               gender VARCHAR(10) NOT NULL,
                                               age INT NOT NULL,
                                               department VARCHAR(100) NOT NULL,
                                               title VARCHAR(50) NOT NULL,
                                               phone VARCHAR(20),
                                               email VARCHAR(100),
                                               created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                               updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                                               deleted_at DATETIME NULL,
                                               INDEX idx_teacher_id (teacher_id),
                                               INDEX idx_name (name),
                                               INDEX idx_deleted_at (deleted_at)
                                           )";
                    new MySqlCommand(createTeachersTable, connection).ExecuteNonQuery();
                    
                    // 创建课程表（带索引优化）
                    var createCoursesTable = @"CREATE TABLE IF NOT EXISTS courses (
                                              id INT AUTO_INCREMENT PRIMARY KEY,
                                              course_id VARCHAR(20) UNIQUE NOT NULL,
                                              name VARCHAR(100) NOT NULL,
                                              teacher_id VARCHAR(20),
                                              credit INT NOT NULL,
                                              type VARCHAR(50) NOT NULL,
                                              description TEXT,
                                              created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                              updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                                              deleted_at DATETIME NULL,
                                              INDEX idx_course_id (course_id),
                                              INDEX idx_teacher_id (teacher_id),
                                              INDEX idx_deleted_at (deleted_at),
                                              FOREIGN KEY (teacher_id) REFERENCES teachers(teacher_id) ON DELETE SET NULL
                                          )";
                    new MySqlCommand(createCoursesTable, connection).ExecuteNonQuery();
                    
                    // 创建成绩表（带索引优化）
                    var createScoresTable = @"CREATE TABLE IF NOT EXISTS scores (
                                             id INT AUTO_INCREMENT PRIMARY KEY,
                                             student_id VARCHAR(20) NOT NULL,
                                             course_id VARCHAR(20) NOT NULL,
                                             score DECIMAL(5,2) NOT NULL,
                                             term VARCHAR(20) NOT NULL,
                                             exam_date DATE,
                                             created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                                             updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                                             INDEX idx_student_id (student_id),
                                             INDEX idx_course_id (course_id),
                                             INDEX idx_term (term),
                                             FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE,
                                             FOREIGN KEY (course_id) REFERENCES courses(course_id) ON DELETE CASCADE
                                         )";
                    new MySqlCommand(createScoresTable, connection).ExecuteNonQuery();
                    
                    // 更新操作日志表结构，添加log_type字段（如果不存在）
                    var addLogTypeColumn = @"ALTER TABLE operation_logs 
                                             ADD COLUMN IF NOT EXISTS log_type VARCHAR(20) NOT NULL DEFAULT 'USER_ACTION'";
                    new MySqlCommand(addLogTypeColumn, connection).ExecuteNonQuery();
                    
                    // 初始化默认角色和用户
                    InitializeDefaultRolesAndUsers(connection);
                    
                    // 记录系统初始化日志
                    _loggingService.LogSystemEvent("Database Initialization", "数据库初始化完成");
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Database Initialization", "初始化数据库时发生错误", ex.ToString());
                throw new Exception("数据库初始化失败: " + ex.Message);
            }
        }

        /// <summary>
        /// 初始化默认角色和用户
        /// </summary>
        /// <param name="connection">数据库连接</param>
        private static void InitializeDefaultRolesAndUsers(MySqlConnection connection)
        {
            try
            {
                // 检查并创建默认角色
                var checkRoleQuery = "SELECT COUNT(*) FROM roles WHERE name = '管理员'";
                using (var command = new MySqlCommand(checkRoleQuery, connection))
                {
                    var roleCount = Convert.ToInt32(command.ExecuteScalar());
                    if (roleCount == 0)
                    {
                        var insertRoleQuery = "INSERT INTO roles (name, description) VALUES ('管理员', '系统管理员角色')";
                        new MySqlCommand(insertRoleQuery, connection).ExecuteNonQuery();
                    }
                }

                // 检查并创建默认管理员用户
                var checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = 'admin'";
                using (var command = new MySqlCommand(checkUserQuery, connection))
                {
                    var userCount = Convert.ToInt32(command.ExecuteScalar());
                    if (userCount == 0)
                    {
                        // 生成安全的随机密码（16 位），替代弱密码 admin123
                        string securePassword = PasswordComplexityService.GenerateSecurePassword(16);
                        var passwordHash = BCrypt.Net.BCrypt.HashPassword(securePassword);
                        var insertUserQuery = "INSERT INTO users (username, password_hash, role_id, require_password_change) VALUES ('admin', @password_hash, 1, TRUE)";
                        using (var command2 = new MySqlCommand(insertUserQuery, connection))
                        {
                            command2.Parameters.AddWithValue("@password_hash", passwordHash);
                            command2.ExecuteNonQuery();
                        }
                        
                        // 记录初始密码到日志（实际应用中应通过更安全的方式告知管理员）
                        _loggingService.LogSystemEvent("Initial Admin Password", 
                            $"初始管理员密码已生成：{securePassword}\n" +
                            $"请注意：此密码仅显示一次，请妥善保管。首次登录时必须修改密码。");
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("Default Roles and Users Initialization", "初始化默认角色和用户时发生错误", ex.ToString());
            }
        }
        
        /// <summary>
        /// 验证用户凭据
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>如果验证成功返回true，否则返回false</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    
                    var query = "SELECT password_hash FROM users WHERE username = @username";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        
                        var hashedPassword = command.ExecuteScalar() as string;
                        if (hashedPassword != null)
                        {
                            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("User Authentication", "验证用户凭据时发生错误", ex.ToString());
            }
            
            return false;
        }
        
        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户对象</returns>
        public static Models.User? GetUserById(int userId)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT u.*, r.name as role_name 
                                 FROM users u 
                                 LEFT JOIN roles r ON u.role_id = r.id 
                                 WHERE u.id = @user_id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_id", userId);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Models.User
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Username = reader["username"].ToString() ?? string.Empty,
                                    PasswordHash = reader["password_hash"].ToString() ?? string.Empty,
                                    Role = reader["role_name"].ToString() ?? string.Empty,
                                    FailedLoginAttempts = Convert.ToInt32(reader["failed_login_attempts"]),
                                    LockedUntil = reader["locked_until"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["locked_until"]),
                                    RequirePasswordChange = Convert.ToBoolean(reader["require_password_change"]),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("User Retrieval", "获取用户信息时发生错误", ex.ToString());
            }
            
            return null;
        }
        
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户对象</returns>
        public static Models.User? GetUserByUsername(string username)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    
                    var query = @"SELECT u.*, r.name as role_name 
                                 FROM users u 
                                 LEFT JOIN roles r ON u.role_id = r.id 
                                 WHERE u.username = @username";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Models.User
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Username = reader["username"].ToString() ?? string.Empty,
                                    PasswordHash = reader["password_hash"].ToString() ?? string.Empty,
                                    Role = reader["role_name"].ToString() ?? string.Empty,
                                    FailedLoginAttempts = Convert.ToInt32(reader["failed_login_attempts"]),
                                    LockedUntil = reader["locked_until"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["locked_until"]),
                                    RequirePasswordChange = Convert.ToBoolean(reader["require_password_change"]),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _loggingService.LogError("User Retrieval", "根据用户名获取用户信息时发生错误", ex.ToString());
            }
            
            return null;
        }
    }
}