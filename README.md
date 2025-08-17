# Student Grade Management System (SGMS)

# 学生成绩管理系统 (SGMS)

## English Version

### Introduction

Student Grade Management System (SGMS) is a comprehensive desktop application built with C# WinForms for managing student academic records. This system provides a complete solution for educational institutions to efficiently handle student information, course data, teacher details, and academic scores.

### Key Features

- Student information management (add, edit, delete, search)
- Course management
- Teacher information management
- Academic score recording and management
- Score reporting and analytics
- User authentication and access control
- Data import/export functionality (Excel)
- Comprehensive logging system

### Technologies and Dependencies

- **Language**: C# (.NET 8.0)
- **UI Framework**: WinForms
- **Database**: MySQL or MariaDB
- **Key Libraries**:
  - MySqlConnector - For MySQL database connectivity
  - ClosedXML - For Excel import/export functionality
  - BCrypt.Net - For password hashing and security
  - System.Text.Json - For JSON handling

### Installation and Setup

1. Install MySQL Server or MariaDB server (version 8.0 or later recommended)
2. Create a MySQL database for the application
3. Update the `dbconfig.ini` file with your database connection details
4. Build and run the application using Visual Studio or the .NET CLI

### Database Configuration

Update the `dbconfig.ini` file in the application root directory with your MySQL server details:

```ini
server=localhost
user=your_username
password=your_password
database=student_grade_db
```

### Usage

1. Run the application
2. Login with default credentials:
   - Username: admin
   - Password: admin123
3. Navigate through the menu to access different modules
4. Use the import/export features to manage data in Excel format

### Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

### License

This project is licensed under the MIT License - see the LICENSE.txt file for details.

### Acknowledgments

- Thanks to the open-source community for providing excellent libraries and tools
- Special thanks to all contributors and users who have helped improve this system
- Inspired by educational management needs in academic institutions

---

## 中文版本

### 简介

学生成绩管理系统(SGMS)是一个基于C# WinForms开发的综合性桌面应用程序，用于管理学生的学术记录。该系统为教育机构提供了一个完整的解决方案，可以高效地处理学生信息、课程数据、教师详情和学习成绩。

### 主要功能

- 学生信息管理（添加、编辑、删除、搜索）
- 课程管理
- 教师信息管理
- 学术成绩记录和管理
- 成绩报告和分析
- 用户认证和访问控制
- 数据导入/导出功能（Excel）
- 全面的日志系统

### 技术和依赖

- **语言**: C# (.NET 8.0)
- **UI框架**: WinForms
- **数据库**: MySQL
- **主要库**:
  - MySqlConnector - 用于MySQL数据库连接
  - ClosedXML - 用于Excel导入/导出功能
  - BCrypt.Net - 用于密码哈希和安全保护
  - System.Text.Json - 用于JSON处理

### 安装和设置

1. 安装MySQL/MariaDB服务器（推荐8.0或更高版本）
2. 为应用程序创建MySQL数据库
3. 使用您的数据库连接详情更新`dbconfig.ini`文件
4. 使用Visual Studio或.NET CLI构建并运行应用程序

### 数据库配置

在应用程序根目录中更新`dbconfig.ini`文件，填入您的MySQL服务器详细信息：

```ini
server=localhost
user=your_username
password=your_password
database=student_grade_db
```

### 使用方法

1. 运行应用程序
2. 使用默认凭据登录：
   - 用户名：admin
   - 密码：admin123
3. 通过菜单导航访问不同模块
4. 使用导入/导出功能以Excel格式管理数据

### 贡献

欢迎贡献！请随时提交Pull Request。

### 许可证

该项目根据MIT许可证授权 - 详情请参见LICENSE.txt文件。

### 致谢

- 感谢开源社区提供了优秀的库和工具
- 特别感谢所有帮助改进此系统的贡献者和用户
- 灵感来源于学术机构的教育管理需求
