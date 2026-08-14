namespace StudentGradeManagementSystem.Forms
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            btnCancel = new AntdUI.Button();
            btnConfirm = new AntdUI.Button();
            txtConfirmPassword = new AntdUI.TextBox();
            lblConfirmPassword = new AntdUI.Label();
            txtNewPassword = new AntdUI.TextBox();
            lblNewPassword = new AntdUI.Label();
            txtOldPassword = new AntdUI.TextBox();
            lblOldPassword = new AntdUI.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnConfirm);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(lblConfirmPassword);
            panel1.Controls.Add(txtNewPassword);
            panel1.Controls.Add(lblNewPassword);
            panel1.Controls.Add(txtOldPassword);
            panel1.Controls.Add(lblOldPassword);
            panel1.Font = new Font("微软雅黑", 12F);
            panel1.Location = new Point(12, 12);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 280);
            panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("微软雅黑", 12F);
            btnCancel.Location = new Point(231, 199);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "取消";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Font = new Font("微软雅黑", 12F);
            btnConfirm.Location = new Point(90, 199);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "确认";
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("微软雅黑", 12F);
            txtConfirmPassword.Location = new Point(140, 140);
            txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(220, 29);
            txtConfirmPassword.TabIndex = 2;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("微软雅黑", 12F);
            lblConfirmPassword.ForeColor = Color.FromArgb(48, 48, 48);
            lblConfirmPassword.Location = new Point(40, 143);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(100, 23);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "确认密码：";
            lblConfirmPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("微软雅黑", 12F);
            txtNewPassword.Location = new Point(140, 90);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(220, 29);
            txtNewPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Font = new Font("微软雅黑", 12F);
            lblNewPassword.ForeColor = Color.FromArgb(48, 48, 48);
            lblNewPassword.Location = new Point(40, 93);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(100, 23);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "新密码：";
            lblNewPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Font = new Font("微软雅黑", 12F);
            txtOldPassword.Location = new Point(140, 40);
            txtOldPassword.Margin = new Padding(4, 5, 4, 5);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(220, 29);
            txtOldPassword.TabIndex = 0;
            // 
            // lblOldPassword
            // 
            lblOldPassword.Font = new Font("微软雅黑", 12F);
            lblOldPassword.ForeColor = Color.FromArgb(48, 48, 48);
            lblOldPassword.Location = new Point(40, 43);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(100, 23);
            lblOldPassword.TabIndex = 2;
            lblOldPassword.Text = "原密码：";
            lblOldPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ChangePasswordForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(428, 268);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(444, 307);
            MinimizeBox = false;
            MinimumSize = new Size(444, 307);
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "修改密码";
            Load += ChangePasswordForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.TextBox txtOldPassword;
        private AntdUI.Label lblOldPassword;
        private AntdUI.TextBox txtConfirmPassword;
        private AntdUI.Label lblConfirmPassword;
        private AntdUI.TextBox txtNewPassword;
        private AntdUI.Label lblNewPassword;
        private AntdUI.Button btnCancel;
        private AntdUI.Button btnConfirm;
    }
}