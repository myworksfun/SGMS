namespace StudentGradeManagementSystem.Forms
{
    partial class LoginForm
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
                // 清理用户服务资源
                // 注意：由于_userService是局部变量，这里无法直接清理
                // 但可以通过将引用设置为null来帮助垃圾回收
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            lblVersion = new Label();
            chkRememberMe = new CheckBox();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(58, 71);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(44, 17);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "用户名";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(117, 67);
            txtUsername.Margin = new Padding(4, 4, 4, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(233, 23);
            txtUsername.TabIndex = 1;
            txtUsername.KeyPress += txtUsername_KeyPress;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(72, 128);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(32, 17);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "密码";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(117, 123);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(233, 23);
            txtPassword.TabIndex = 2;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(117, 212);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(88, 33);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(262, 212);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(13, 257);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(44, 17);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "版本：";
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(117, 170);
            chkRememberMe.Margin = new Padding(4, 4, 4, 4);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(123, 21);
            chkRememberMe.TabIndex = 3;
            chkRememberMe.Text = "记住用户名和密码";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 283);
            Controls.Add(lblVersion);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(chkRememberMe);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学生成绩管理系统 - 用户登录";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkRememberMe;
    }
}