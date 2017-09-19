namespace XetTuyen
{
    partial class frmUser
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
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.dtpBrithDay = new System.Windows.Forms.DateTimePicker();
            this.lblBrithDay = new System.Windows.Forms.Label();
            this.chkLstGroup = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtLockedReason = new System.Windows.Forms.TextBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblLockedReason = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grpUserList = new System.Windows.Forms.GroupBox();
            this.grdUserList = new System.Windows.Forms.DataGridView();
            this.clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBrithDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLockedUser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlMain.SuspendLayout();
            this.grpUserInfo.SuspendLayout();
            this.grpUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpUserList);
            this.pnlMain.Controls.Add(this.grpUserInfo);
            this.pnlMain.Size = new System.Drawing.Size(895, 464);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 496);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.CloseHandler += new ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.cmbGender);
            this.grpUserInfo.Controls.Add(this.lblGender);
            this.grpUserInfo.Controls.Add(this.dtpBrithDay);
            this.grpUserInfo.Controls.Add(this.lblBrithDay);
            this.grpUserInfo.Controls.Add(this.chkLstGroup);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.dtpEndDate);
            this.grpUserInfo.Controls.Add(this.txtLockedReason);
            this.grpUserInfo.Controls.Add(this.chkLocked);
            this.grpUserInfo.Controls.Add(this.txtEmail);
            this.grpUserInfo.Controls.Add(this.txtEmployeeName);
            this.grpUserInfo.Controls.Add(this.txtPassword);
            this.grpUserInfo.Controls.Add(this.txtUserName);
            this.grpUserInfo.Controls.Add(this.lblEndDate);
            this.grpUserInfo.Controls.Add(this.lblLockedReason);
            this.grpUserInfo.Controls.Add(this.lblEmail);
            this.grpUserInfo.Controls.Add(this.lblEmployeeID);
            this.grpUserInfo.Controls.Add(this.lblPassword);
            this.grpUserInfo.Controls.Add(this.lblUserName);
            this.grpUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserInfo.Location = new System.Drawing.Point(0, 0);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(895, 294);
            this.grpUserInfo.TabIndex = 1;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Thông tin người dùng";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cmbGender.Location = new System.Drawing.Point(610, 47);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 24);
            this.cmbGender.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AllowDrop = true;
            this.lblGender.Location = new System.Drawing.Point(438, 55);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(169, 16);
            this.lblGender.TabIndex = 13;
            this.lblGender.Text = "Giới tính";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBrithDay
            // 
            this.dtpBrithDay.CustomFormat = "dd/MM/yyyy";
            this.dtpBrithDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBrithDay.Location = new System.Drawing.Point(613, 16);
            this.dtpBrithDay.Name = "dtpBrithDay";
            this.dtpBrithDay.ShowUpDown = true;
            this.dtpBrithDay.Size = new System.Drawing.Size(118, 22);
            this.dtpBrithDay.TabIndex = 4;
            // 
            // lblBrithDay
            // 
            this.lblBrithDay.Location = new System.Drawing.Point(438, 21);
            this.lblBrithDay.Name = "lblBrithDay";
            this.lblBrithDay.Size = new System.Drawing.Size(169, 16);
            this.lblBrithDay.TabIndex = 11;
            this.lblBrithDay.Text = "Ngày sinh";
            this.lblBrithDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLstGroup
            // 
            this.chkLstGroup.CheckOnClick = true;
            this.chkLstGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLstGroup.FormattingEnabled = true;
            this.chkLstGroup.Location = new System.Drawing.Point(229, 233);
            this.chkLstGroup.MultiColumn = true;
            this.chkLstGroup.Name = "chkLstGroup";
            this.chkLstGroup.Size = new System.Drawing.Size(544, 55);
            this.chkLstGroup.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nhóm người dùng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(229, 205);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(118, 22);
            this.dtpEndDate.TabIndex = 8;
            // 
            // txtLockedReason
            // 
            this.txtLockedReason.Location = new System.Drawing.Point(229, 157);
            this.txtLockedReason.Multiline = true;
            this.txtLockedReason.Name = "txtLockedReason";
            this.txtLockedReason.Size = new System.Drawing.Size(544, 42);
            this.txtLockedReason.TabIndex = 7;
            // 
            // chkLocked
            // 
            this.chkLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLocked.Location = new System.Drawing.Point(55, 131);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(188, 20);
            this.chkLocked.TabIndex = 6;
            this.chkLocked.Text = "Khóa người dùng";
            this.chkLocked.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(230, 103);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(234, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(230, 75);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(157, 22);
            this.txtEmployeeName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(230, 47);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(230, 20);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 22);
            this.txtUserName.TabIndex = 0;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(75, 205);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(146, 16);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "Hạn sử dụng";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLockedReason
            // 
            this.lblLockedReason.Location = new System.Drawing.Point(78, 157);
            this.lblLockedReason.Name = "lblLockedReason";
            this.lblLockedReason.Size = new System.Drawing.Size(146, 16);
            this.lblLockedReason.TabIndex = 7;
            this.lblLockedReason.Text = "Lý do khóa";
            this.lblLockedReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(78, 106);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(146, 16);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Địa chỉ email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(78, 75);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(146, 16);
            this.lblEmployeeID.TabIndex = 2;
            this.lblEmployeeID.Text = "Nhân viên";
            this.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(72, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(149, 16);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Mật khẩu";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(52, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(169, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Tên đăng nhập";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpUserList
            // 
            this.grpUserList.Controls.Add(this.grdUserList);
            this.grpUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserList.Location = new System.Drawing.Point(0, 294);
            this.grpUserList.Name = "grpUserList";
            this.grpUserList.Size = new System.Drawing.Size(895, 170);
            this.grpUserList.TabIndex = 3;
            this.grpUserList.TabStop = false;
            this.grpUserList.Text = "Danh sách người dùng";
            // 
            // grdUserList
            // 
            this.grdUserList.AllowUserToAddRows = false;
            this.grdUserList.AllowUserToDeleteRows = false;
            this.grdUserList.AllowUserToResizeRows = false;
            this.grdUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUserName,
            this.clmGender,
            this.clmBrithDay,
            this.clmEmployeeName,
            this.clmEmail,
            this.clmEndDate,
            this.clmLockedUser});
            this.grdUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserList.Location = new System.Drawing.Point(3, 18);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ReadOnly = true;
            this.grdUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUserList.Size = new System.Drawing.Size(889, 149);
            this.grdUserList.TabIndex = 0;
            this.grdUserList.TabStop = false;
            this.grdUserList.SelectionChanged += new System.EventHandler(this.grdUserList_SelectionChanged);
            // 
            // clmUserName
            // 
            this.clmUserName.DataPropertyName = "LoginID";
            this.clmUserName.HeaderText = "Tên đăng nhập";
            this.clmUserName.Name = "clmUserName";
            this.clmUserName.ReadOnly = true;
            this.clmUserName.Width = 150;
            // 
            // clmGender
            // 
            this.clmGender.DataPropertyName = "Gender";
            this.clmGender.HeaderText = "Giới tính";
            this.clmGender.Name = "clmGender";
            this.clmGender.ReadOnly = true;
            // 
            // clmBrithDay
            // 
            this.clmBrithDay.DataPropertyName = "BirthDay";
            this.clmBrithDay.HeaderText = "Ngày sinh";
            this.clmBrithDay.Name = "clmBrithDay";
            this.clmBrithDay.ReadOnly = true;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.DataPropertyName = "FullName";
            this.clmEmployeeName.HeaderText = "Nhân viên";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 150;
            // 
            // clmEmail
            // 
            this.clmEmail.DataPropertyName = "Email";
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.ReadOnly = true;
            this.clmEmail.Width = 230;
            // 
            // clmEndDate
            // 
            this.clmEndDate.DataPropertyName = "DeadlineOfUsing";
            this.clmEndDate.HeaderText = "Hạn sử dụng";
            this.clmEndDate.Name = "clmEndDate";
            this.clmEndDate.ReadOnly = true;
            this.clmEndDate.Width = 120;
            // 
            // clmLockedUser
            // 
            this.clmLockedUser.DataPropertyName = "LockedUser";
            this.clmLockedUser.HeaderText = "Khóa";
            this.clmLockedUser.Name = "clmLockedUser";
            this.clmLockedUser.ReadOnly = true;
            this.clmLockedUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmLockedUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 530);
            this.Name = "frmUser";
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.Shown += new System.EventHandler(this.frmUser_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.grpUserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUserList;
        private System.Windows.Forms.DataGridView grdUserList;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.CheckedListBox chkLstGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtLockedReason;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblLockedReason;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.DateTimePicker dtpBrithDay;
        private System.Windows.Forms.Label lblBrithDay;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBrithDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEndDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmLockedUser;
    }
}