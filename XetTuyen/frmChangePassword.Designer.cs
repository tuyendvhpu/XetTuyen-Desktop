namespace XetTuyen
{
    partial class frmChangePassword
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtRePass = new System.Windows.Forms.TextBox();
            this.lblRePass = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(33, 24);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tài khoản";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(102, 21);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(181, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(102, 48);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(181, 20);
            this.txtOldPass.TabIndex = 3;
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Location = new System.Drawing.Point(31, 51);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(61, 13);
            this.lblMatKhauCu.TabIndex = 2;
            this.lblMatKhauCu.Text = "Mật cẩu cũ";
            this.lblMatKhauCu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(102, 75);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(181, 20);
            this.txtNewPass.TabIndex = 5;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(27, 78);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(71, 13);
            this.lblNewPass.TabIndex = 4;
            this.lblNewPass.Text = "Mật khẩu mới";
            this.lblNewPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRePass
            // 
            this.txtRePass.Location = new System.Drawing.Point(103, 102);
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.PasswordChar = '*';
            this.txtRePass.Size = new System.Drawing.Size(181, 20);
            this.txtRePass.TabIndex = 7;
            // 
            // lblRePass
            // 
            this.lblRePass.AutoSize = true;
            this.lblRePass.Location = new System.Drawing.Point(7, 105);
            this.lblRePass.Name = "lblRePass";
            this.lblRePass.Size = new System.Drawing.Size(87, 13);
            this.lblRePass.TabIndex = 6;
            this.lblRePass.Text = "Ngõ lại mật khẩu";
            this.lblRePass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(36, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Xóa";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(154, 140);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(112, 30);
            this.btnChange.TabIndex = 9;
            this.btnChange.Text = "Đổi mật khẩu";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 188);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRePass);
            this.Controls.Add(this.lblRePass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblMatKhauCu);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.MaximizeBox = false;
            this.Name = "frmChangePassword";
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtRePass;
        private System.Windows.Forms.Label lblRePass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChange;
    }
}