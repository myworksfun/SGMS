using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Data;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace StudentGradeManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private UserService _userService = new UserService();
        private string credentialsFile = "credentials.dat";
        private static readonly byte[] entropy = Encoding.UTF8.GetBytes("StudentGradeManagementSystem2025");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = "学生成绩管理系统 - 用户登录";
            lblVersion.Text = "版本: 1.0.0";
            
            txtUsername.Text = "请输入用户名";
            txtPassword.Text = "请输入密码";
            txtUsername.ForeColor = System.Drawing.Color.Gray;
            txtPassword.ForeColor = System.Drawing.Color.Gray;
            
            LoadSavedCredentials();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "请输入用户名") txtUsername.Text = "";
            if (txtPassword.Text == "请输入密码") txtPassword.Text = "";
            
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                var user = _userService.AuthenticateUser(username, password);
                if (user != null)
                {
                    CurrentUser.SetCurrentUser(user);
                    
                    if (chkRememberMe.Checked)
                    {
                        SaveCredentials(username, password);
                    }
                    else
                    {
                        DeleteSavedCredentials();
                    }

                    var logRepository = new LogRepository();
                    var log = new OperationLog
                    {
                        UserId = user.Id,
                        Username = user.Username,
                        Operation = "User Login",
                        Description = $"用户 {user.Username} 登录系统",
                        IPAddress = NetworkUtils.GetLocalIPAddress(),
                        UserAgent = Environment.MachineName
                    };
                    logRepository.AddUserLog(log);

                    Hide();
                    var mainForm = new MainForm();
                    mainForm.FormClosed += MainForm_FormClosed;
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录过程中发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMainForm()
        {
            var mainForm = new MainForm();
            mainForm.FormClosed += MainForm_FormClosed;
            mainForm.Show();
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // 检查是否是注销操作（用户不为null表示正常退出）
            if (CurrentUser.GetCurrentUser() != null)
            {
                // 用户正常退出应用
                Application.Exit();
            }
            else
            {
                // 用户注销，重新显示登录窗口
                this.Show();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        // 保存用户名和密码到本地文件
        private void SaveCredentials(string username, string password)
        {
            try
            {
                // 使用更安全的加密方法
                string encryptedUsername = EncryptString(username);
                string encryptedPassword = EncryptString(password);
                
                // 保存到文件
                string content = $"{encryptedUsername}|{encryptedPassword}";
                File.WriteAllText(credentialsFile, content);
            }
            catch (Exception ex)
            {
                // 静默处理错误，不影响登录流程
                Console.WriteLine($"保存凭据时出错: {ex.Message}");
            }
        }
        
        // 加载保存的用户名和密码
        private void LoadSavedCredentials()
        {
            try
            {
                if (File.Exists(credentialsFile))
                {
                    string content = File.ReadAllText(credentialsFile);
                    string[] parts = content.Split('|');
                    
                    if (parts.Length == 2)
                    {
                        string decryptedUsername = DecryptString(parts[0]);
                        string decryptedPassword = DecryptString(parts[1]);
                        
                        txtUsername.Text = decryptedUsername;
                        txtPassword.Text = decryptedPassword;
                        chkRememberMe.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // 静默处理错误，不影响登录流程
                Console.WriteLine($"加载凭据时出错: {ex.Message}");
            }
        }
        
        // 删除保存的凭据
        private void DeleteSavedCredentials()
        {
            try
            {
                if (File.Exists(credentialsFile))
                {
                    File.Delete(credentialsFile);
                }
            }
            catch (Exception ex)
            {
                // 静默处理错误
                Console.WriteLine($"删除凭据时出错: {ex.Message}");
            }
        }
        
        // 更安全的加密方法
        private string EncryptString(string text)
        {
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(text);
            byte[] encryptedBytes = ProtectedData.Protect(plaintextBytes, entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedBytes);
        }
        
        // 更安全的解密方法
        private string DecryptString(string encryptedText)
        {
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] plaintextBytes = ProtectedData.Unprotect(encryptedBytes, entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plaintextBytes);
            }
            catch
            {
                // 解密失败，返回空字符串
                return string.Empty;
            }
        }
    }

    public static class CurrentUser
    {
        private static User? _currentUser;

        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public static User? GetCurrentUser()
        {
            return _currentUser;
        }

        public static bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        public static bool IsAdmin()
        {
            return _currentUser?.Role == "管理员";
        }
    }
}