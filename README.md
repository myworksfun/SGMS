# Student Grade Management System (SGMS)

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


