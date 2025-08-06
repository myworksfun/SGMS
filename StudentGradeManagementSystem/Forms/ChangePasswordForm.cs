using System;
using System.Windows.Forms;
using StudentGradeManagementSystem.Services;
using StudentGradeManagementSystem.Models;
using StudentGradeManagementSystem.Data;
using MySqlConnector;
// 添加BCrypt引用
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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 密码强度检测
            if (txtNewPassword.Text.Length < 8)
            {
                MessageBox.Show("密码长度至少为8位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

            if (newPassword.Length < 6)
            {
                MessageBox.Show("新密码长度不能少于6位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 获取当前用户
            var currentUser = CurrentUser.GetCurrentUser();
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
                // 使用BCrypt哈希算法保持与系统其他部分一致
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var query = "UPDATE users SET password_hash = @password_hash WHERE id = @user_id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@password_hash", hashedPassword);
                        command.Parameters.AddWithValue("@user_id", currentUser.Id);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
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
            catch (Exception ex)
            {
                MessageBox.Show($"密码修改失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}