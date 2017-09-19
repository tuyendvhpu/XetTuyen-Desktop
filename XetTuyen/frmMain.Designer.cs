namespace XetTuyen
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAuthorization = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCoQuan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDotXetTuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCongThuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTinhDiemTB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDieuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXetTuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTTXetTuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInGiayBao = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateMenu = new System.Windows.Forms.Button();
            this.mnuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.AutoSize = false;
            this.mnuMain.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mnuMain.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuCatalogue,
            this.mnuProcessing,
            this.mnuStatistic});
            this.mnuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(762, 28);
            this.mnuMain.TabIndex = 150;
            this.mnuMain.Text = "MenuStrip";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSecurity,
            this.mnuChangePassword,
            this.mnuLogOff,
            this.mnuClose});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(72, 24);
            this.mnuSystem.Text = "Hệ thống";
            this.mnuSystem.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuSecurity
            // 
            this.mnuSecurity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUser,
            this.mnuGroup,
            this.mnuAuthorization,
            this.mnuUpdateMenu,
            this.mnuCoQuan,
            this.mnuCauHinh,
            this.mnuHistory});
            this.mnuSecurity.Name = "mnuSecurity";
            this.mnuSecurity.Size = new System.Drawing.Size(175, 22);
            this.mnuSecurity.Text = "Quản lý hệ thống";
            // 
            // mnuUser
            // 
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(277, 22);
            this.mnuUser.Tag = "frmUser";
            this.mnuUser.Text = "Người dùng";
            this.mnuUser.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuGroup
            // 
            this.mnuGroup.Name = "mnuGroup";
            this.mnuGroup.Size = new System.Drawing.Size(277, 22);
            this.mnuGroup.Tag = "frmGroup";
            this.mnuGroup.Text = "Nhóm người dùng";
            this.mnuGroup.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuAuthorization
            // 
            this.mnuAuthorization.Name = "mnuAuthorization";
            this.mnuAuthorization.Size = new System.Drawing.Size(277, 22);
            this.mnuAuthorization.Tag = "frmAuthorization";
            this.mnuAuthorization.Text = "Phân quyền cho nhóm người dùng";
            this.mnuAuthorization.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuUpdateMenu
            // 
            this.mnuUpdateMenu.Name = "mnuUpdateMenu";
            this.mnuUpdateMenu.Size = new System.Drawing.Size(277, 22);
            this.mnuUpdateMenu.Tag = "frmAdminMode";
            this.mnuUpdateMenu.Text = "Cập nhật menu";
            this.mnuUpdateMenu.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuCoQuan
            // 
            this.mnuCoQuan.Name = "mnuCoQuan";
            this.mnuCoQuan.Size = new System.Drawing.Size(277, 22);
            this.mnuCoQuan.Tag = "frmCongTy";
            this.mnuCoQuan.Text = "Cơ quan";
            this.mnuCoQuan.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuCauHinh
            // 
            this.mnuCauHinh.Name = "mnuCauHinh";
            this.mnuCauHinh.Size = new System.Drawing.Size(277, 22);
            this.mnuCauHinh.Tag = "frmConfig";
            this.mnuCauHinh.Text = "Cấu hình kêt nối cơ sở dữ liệu";
            this.mnuCauHinh.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(175, 22);
            this.mnuChangePassword.Tag = "frmChangePassword";
            this.mnuChangePassword.Text = "Đổi mật khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuLogOff
            // 
            this.mnuLogOff.Name = "mnuLogOff";
            this.mnuLogOff.Size = new System.Drawing.Size(175, 22);
            this.mnuLogOff.Tag = "LogOff";
            this.mnuLogOff.Text = "Đăng xuất";
            this.mnuLogOff.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(175, 22);
            this.mnuClose.Tag = "Close";
            this.mnuClose.Text = "Thoát";
            this.mnuClose.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuCatalogue
            // 
            this.mnuCatalogue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDotXetTuyen,
            this.mnuHoSo});
            this.mnuCatalogue.Name = "mnuCatalogue";
            this.mnuCatalogue.Size = new System.Drawing.Size(79, 24);
            this.mnuCatalogue.Text = "Danh mục";
            // 
            // mnuDotXetTuyen
            // 
            this.mnuDotXetTuyen.Name = "mnuDotXetTuyen";
            this.mnuDotXetTuyen.Size = new System.Drawing.Size(156, 22);
            this.mnuDotXetTuyen.Tag = "frmDotXetTuyen";
            this.mnuDotXetTuyen.Text = "Đợt xét tuyển";
            this.mnuDotXetTuyen.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuHoSo
            // 
            this.mnuHoSo.Name = "mnuHoSo";
            this.mnuHoSo.Size = new System.Drawing.Size(156, 22);
            this.mnuHoSo.Tag = "frmHoSo";
            this.mnuHoSo.Text = "Hồ sơ";
            this.mnuHoSo.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuProcessing
            // 
            this.mnuProcessing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCongThuc,
            this.mnuTinhDiemTB,
            this.mnuDieuKien,
            this.mnuXetTuyen,
            this.mnuTTXetTuyen});
            this.mnuProcessing.Name = "mnuProcessing";
            this.mnuProcessing.Size = new System.Drawing.Size(118, 24);
            this.mnuProcessing.Text = "Xử Lý Nghiệp Vụ";
            // 
            // mnuCongThuc
            // 
            this.mnuCongThuc.Name = "mnuCongThuc";
            this.mnuCongThuc.Size = new System.Drawing.Size(193, 22);
            this.mnuCongThuc.Tag = "frmCongThuc";
            this.mnuCongThuc.Text = "Lập công thức";
            this.mnuCongThuc.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuTinhDiemTB
            // 
            this.mnuTinhDiemTB.Name = "mnuTinhDiemTB";
            this.mnuTinhDiemTB.Size = new System.Drawing.Size(193, 22);
            this.mnuTinhDiemTB.Tag = "frmDiemTB";
            this.mnuTinhDiemTB.Text = "Tính điểm trung bình";
            this.mnuTinhDiemTB.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // mnuDieuKien
            // 
            this.mnuDieuKien.Name = "mnuDieuKien";
            this.mnuDieuKien.Size = new System.Drawing.Size(193, 22);
            this.mnuDieuKien.Tag = "frmDieuKien";
            this.mnuDieuKien.Text = "Điều kiện xét tuyển";
            // 
            // mnuXetTuyen
            // 
            this.mnuXetTuyen.Name = "mnuXetTuyen";
            this.mnuXetTuyen.Size = new System.Drawing.Size(193, 22);
            this.mnuXetTuyen.Tag = "frmXetTuyen";
            this.mnuXetTuyen.Text = "Xét tuyển";
            // 
            // mnuTTXetTuyen
            // 
            this.mnuTTXetTuyen.Name = "mnuTTXetTuyen";
            this.mnuTTXetTuyen.Size = new System.Drawing.Size(193, 22);
            this.mnuTTXetTuyen.Tag = "frmTTXetTuyen";
            this.mnuTTXetTuyen.Text = "Thông tin xét tuyển";
            // 
            // mnuStatistic
            // 
            this.mnuStatistic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInGiayBao});
            this.mnuStatistic.Name = "mnuStatistic";
            this.mnuStatistic.Size = new System.Drawing.Size(123, 24);
            this.mnuStatistic.Text = "Thống kê báo cáo";
            // 
            // mnuInGiayBao
            // 
            this.mnuInGiayBao.Name = "mnuInGiayBao";
            this.mnuInGiayBao.Size = new System.Drawing.Size(152, 22);
            this.mnuInGiayBao.Tag = "frmInGiayBao";
            this.mnuInGiayBao.Text = "In giấy báo";
            this.mnuInGiayBao.Click += new System.EventHandler(this.mnuSystem_Click);
            // 
            // btnUpdateMenu
            // 
            this.btnUpdateMenu.Location = new System.Drawing.Point(0, 188);
            this.btnUpdateMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateMenu.Name = "btnUpdateMenu";
            this.btnUpdateMenu.Size = new System.Drawing.Size(57, 36);
            this.btnUpdateMenu.TabIndex = 168;
            this.btnUpdateMenu.Text = "Update Menu";
            this.btnUpdateMenu.UseVisualStyleBackColor = true;
            this.btnUpdateMenu.Click += new System.EventHandler(this.btnUpdateMenu_Click);
            // 
            // mnuHistory
            // 
            this.mnuHistory.Name = "mnuHistory";
            this.mnuHistory.Size = new System.Drawing.Size(277, 22);
            this.mnuHistory.Tag = "frmHistory";
            this.mnuHistory.Text = "Lịch sử người dùng";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 385);
            this.Controls.Add(this.btnUpdateMenu);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuSecurity;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuAuthorization;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOff;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnUpdateMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCoQuan;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinh;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogue;
        private System.Windows.Forms.ToolStripMenuItem mnuDotXetTuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuHoSo;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessing;
        private System.Windows.Forms.ToolStripMenuItem mnuCongThuc;
        private System.Windows.Forms.ToolStripMenuItem mnuTinhDiemTB;
        private System.Windows.Forms.ToolStripMenuItem mnuStatistic;
        private System.Windows.Forms.ToolStripMenuItem mnuInGiayBao;
        private System.Windows.Forms.ToolStripMenuItem mnuDieuKien;
        private System.Windows.Forms.ToolStripMenuItem mnuXetTuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuTTXetTuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuHistory;

    }
}

