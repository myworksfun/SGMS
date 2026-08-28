using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Data;
using MySqlConnector;
using BCrypt.Net;

namespace StudentGradeManagementSystem.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            Text = "修改密码";
            // 显示密码复杂度要求
            lblPasswordRequirements.Text = "密码要求：至少 8 位，包含大小写字母、数字和特殊字符";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 验证输入
            if (string.IsNullOrEmpty(oldPassword))
            {
                MessageBox.Show("请输入原密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("请输入新密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("请确认新密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("新密码与确认密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
                return;
            }

            // 使用新的密码复杂度验证服务
            var (isValid, errorMessage) = PasswordComplexityService.ValidatePasswordComplexity(newPassword);
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "密码复杂度不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return;
            }

            // 检查密码是否包含用户名
            var currentUser = CurrentUser.GetCurrentUser();
            if (currentUser != null)
            {
                var (isSafe, warningMessage) = PasswordComplexityService.CheckPasswordContainsUsername(newPassword, currentUser.Username);
                if (!isSafe)
                {
                    var result = MessageBox.Show($"{warningMessage}\n是否继续使用此密码？", "安全警告", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        txtNewPassword.Focus();
                        txtNewPassword.SelectAll();
                        return;
                    }
                }
            }

            if (currentUser == null)
            {
                MessageBox.Show("未登录用户", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 验证原密码
            if (!PasswordService.VerifyPassword(oldPassword, currentUser.PasswordHash))
            {
                MessageBox.Show("原密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                txtOldPassword.SelectAll();
                return;
            }

            // 更新密码到数据库
            try
            {
                // 使用 PasswordService 进行哈希（会自动验证复杂度）
                string hashedPassword = PasswordService.HashPassword(newPassword);
                
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var query = "UPDATE users SET password_hash = @password_hash, require_password_change = 0 WHERE id = @user_id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@password_hash", hashedPassword);
                        command.Parameters.AddWithValue("@user_id", currentUser.Id);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // 记录密码修改日志
                            var logRepository = new LogRepository();
                            var log = new OperationLog
                            {
                                UserId = currentUser.Id,
                                Username = currentUser.Username,
                                Operation = "修改密码",
                                Description = $"用户 {currentUser.Username} 修改了登录密码",
                                IPAddress = NetworkUtils.GetLocalIPAddress(),
                                UserAgent = Environment.MachineName
                            };
                            logRepository.AddUserLog(log);

                            MessageBox.Show("密码修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("密码修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"密码不符合要求：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"密码修改失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            // 生成符合复杂度要求的随机密码
            var securePassword = PasswordComplexityService.GenerateSecurePassword(16);
            txtNewPassword.Text = securePassword;
            txtConfirmPassword.Text = securePassword;
            
            MessageBox.Show("已生成强密码，请妥善保管", "密码已生成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
