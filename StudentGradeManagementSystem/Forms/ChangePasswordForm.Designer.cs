using Sunny.UI;

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
            uiPanel1 = new UIPanel();
            btnCancel = new UIButton();
            btnConfirm = new UIButton();
            txtConfirmPassword = new UITextBox();
            lblConfirmPassword = new UILabel();
            txtNewPassword = new UITextBox();
            lblNewPassword = new UILabel();
            txtOldPassword = new UITextBox();
            lblOldPassword = new UILabel();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(btnCancel);
            uiPanel1.Controls.Add(btnConfirm);
            uiPanel1.Controls.Add(txtConfirmPassword);
            uiPanel1.Controls.Add(lblConfirmPassword);
            uiPanel1.Controls.Add(txtNewPassword);
            uiPanel1.Controls.Add(lblNewPassword);
            uiPanel1.Controls.Add(txtOldPassword);
            uiPanel1.Controls.Add(lblOldPassword);
            uiPanel1.Font = new Font("微软雅黑", 12F);
            uiPanel1.Location = new Point(12, 12);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(420, 280);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("微软雅黑", 12F);
            btnCancel.Location = new Point(231, 199);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "取消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Font = new Font("微软雅黑", 12F);
            btnConfirm.Location = new Point(90, 199);
            btnConfirm.MinimumSize = new Size(1, 1);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "确认";
            btnConfirm.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Cursor = Cursors.IBeam;
            txtConfirmPassword.Font = new Font("微软雅黑", 12F);
            txtConfirmPassword.Location = new Point(140, 140);
            txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPassword.MinimumSize = new Size(1, 1);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(5);
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.ShowText = false;
            txtConfirmPassword.Size = new Size(220, 29);
            txtConfirmPassword.TabIndex = 2;
            txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtConfirmPassword.Watermark = "";
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
            txtNewPassword.Cursor = Cursors.IBeam;
            txtNewPassword.Font = new Font("微软雅黑", 12F);
            txtNewPassword.Location = new Point(140, 90);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.MinimumSize = new Size(1, 1);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(5);
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.ShowText = false;
            txtNewPassword.Size = new Size(220, 29);
            txtNewPassword.TabIndex = 1;
            txtNewPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtNewPassword.Watermark = "";
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
            txtOldPassword.Cursor = Cursors.IBeam;
            txtOldPassword.Font = new Font("微软雅黑", 12F);
            txtOldPassword.Location = new Point(140, 40);
            txtOldPassword.Margin = new Padding(4, 5, 4, 5);
            txtOldPassword.MinimumSize = new Size(1, 1);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(5);
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.ShowText = false;
            txtOldPassword.Size = new Size(220, 29);
            txtOldPassword.TabIndex = 0;
            txtOldPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtOldPassword.Watermark = "";
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
            Controls.Add(uiPanel1);
            MaximizeBox = false;
            MaximumSize = new Size(444, 307);
            MinimizeBox = false;
            MinimumSize = new Size(444, 307);
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "修改密码";
            Load += ChangePasswordForm_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private UIPanel uiPanel1;
        private UITextBox txtOldPassword;
        private UILabel lblOldPassword;
        private UITextBox txtConfirmPassword;
        private UILabel lblConfirmPassword;
        private UITextBox txtNewPassword;
        private UILabel lblNewPassword;
        private UIButton btnCancel;
        private UIButton btnConfirm;
    }
}