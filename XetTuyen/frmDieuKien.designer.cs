namespace XetTuyen
{
    partial class frmDieuKien
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
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.clmMaDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIDNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.cmbDotTK = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoTHPT = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdbDH = new System.Windows.Forms.RadioButton();
            this.bntHienAll = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cmbKhoiTK = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbHeTK = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiemSan = new System.Windows.Forms.TextBox();
            this.cmbHeXetTuyen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiemChuan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMaKhoi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNganh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNhomNganh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.cmbMaDot = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.lblMaDot = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.grbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1138, 32);
            this.lblTitle.Text = "Danh mục điều kiện xét tuyển";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(1138, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(1138, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvCongThuc);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 117);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1138, 294);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvCongThuc
            // 
            this.dgvCongThuc.AllowUserToAddRows = false;
            this.dgvCongThuc.AllowUserToDeleteRows = false;
            this.dgvCongThuc.AllowUserToOrderColumns = true;
            this.dgvCongThuc.AllowUserToResizeRows = false;
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaDot,
            this.clmNam,
            this.clmMaNganh,
            this.clmIDNganh,
            this.clmTenNganh,
            this.clmMaKhoi,
            this.clmDiemChuan,
            this.clmDiemSan});
            this.dgvCongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongThuc.Location = new System.Drawing.Point(3, 18);
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(1132, 273);
            this.dgvCongThuc.TabIndex = 0;
            this.dgvCongThuc.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // clmMaDot
            // 
            this.clmMaDot.DataPropertyName = "MaDot";
            this.clmMaDot.HeaderText = "Mã đợt";
            this.clmMaDot.Name = "clmMaDot";
            this.clmMaDot.ReadOnly = true;
            this.clmMaDot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmNam
            // 
            this.clmNam.DataPropertyName = "Nam";
            this.clmNam.HeaderText = "Năm";
            this.clmNam.Name = "clmNam";
            this.clmNam.ReadOnly = true;
            this.clmNam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmNam.Width = 50;
            // 
            // clmMaNganh
            // 
            this.clmMaNganh.DataPropertyName = "MaNganh";
            this.clmMaNganh.HeaderText = "Mã nhóm ngành";
            this.clmMaNganh.Name = "clmMaNganh";
            this.clmMaNganh.ReadOnly = true;
            this.clmMaNganh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMaNganh.Visible = false;
            this.clmMaNganh.Width = 150;
            // 
            // clmIDNganh
            // 
            this.clmIDNganh.DataPropertyName = "IDNganh";
            this.clmIDNganh.HeaderText = "Mã chuyên ngành";
            this.clmIDNganh.Name = "clmIDNganh";
            this.clmIDNganh.ReadOnly = true;
            this.clmIDNganh.Width = 159;
            // 
            // clmTenNganh
            // 
            this.clmTenNganh.DataPropertyName = "TenNganh";
            this.clmTenNganh.HeaderText = "Tên ngành";
            this.clmTenNganh.Name = "clmTenNganh";
            this.clmTenNganh.ReadOnly = true;
            this.clmTenNganh.Width = 300;
            // 
            // clmMaKhoi
            // 
            this.clmMaKhoi.DataPropertyName = "MaKhoi";
            this.clmMaKhoi.HeaderText = "Mã Khối";
            this.clmMaKhoi.Name = "clmMaKhoi";
            this.clmMaKhoi.ReadOnly = true;
            this.clmMaKhoi.Width = 150;
            // 
            // clmDiemChuan
            // 
            this.clmDiemChuan.DataPropertyName = "DiemChuan";
            this.clmDiemChuan.HeaderText = "Điểm chuẩn";
            this.clmDiemChuan.Name = "clmDiemChuan";
            this.clmDiemChuan.ReadOnly = true;
            this.clmDiemChuan.Width = 150;
            // 
            // clmDiemSan
            // 
            this.clmDiemSan.DataPropertyName = "DiemSan";
            this.clmDiemSan.HeaderText = "Điểm xét";
            this.clmDiemSan.Name = "clmDiemSan";
            this.clmDiemSan.ReadOnly = true;
            this.clmDiemSan.Width = 159;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.grbTimKiem);
            this.grpDetailInfo.Controls.Add(this.label6);
            this.grpDetailInfo.Controls.Add(this.txtDiemSan);
            this.grpDetailInfo.Controls.Add(this.cmbHeXetTuyen);
            this.grpDetailInfo.Controls.Add(this.label5);
            this.grpDetailInfo.Controls.Add(this.txtDiemChuan);
            this.grpDetailInfo.Controls.Add(this.label4);
            this.grpDetailInfo.Controls.Add(this.cmbMaKhoi);
            this.grpDetailInfo.Controls.Add(this.label3);
            this.grpDetailInfo.Controls.Add(this.cmbNganh);
            this.grpDetailInfo.Controls.Add(this.label2);
            this.grpDetailInfo.Controls.Add(this.cmbNhomNganh);
            this.grpDetailInfo.Controls.Add(this.label1);
            this.grpDetailInfo.Controls.Add(this.txtNam);
            this.grpDetailInfo.Controls.Add(this.cmbMaDot);
            this.grpDetailInfo.Controls.Add(this.lblNam);
            this.grpDetailInfo.Controls.Add(this.lblMaDot);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(1138, 117);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbTimKiem.Controls.Add(this.cmbDotTK);
            this.grbTimKiem.Controls.Add(this.label9);
            this.grbTimKiem.Controls.Add(this.rdoTHPT);
            this.grbTimKiem.Controls.Add(this.rdoAll);
            this.grbTimKiem.Controls.Add(this.rdbDH);
            this.grbTimKiem.Controls.Add(this.bntHienAll);
            this.grbTimKiem.Controls.Add(this.btnTimKiem);
            this.grbTimKiem.Controls.Add(this.cmbKhoiTK);
            this.grbTimKiem.Controls.Add(this.label8);
            this.grbTimKiem.Controls.Add(this.cmbHeTK);
            this.grbTimKiem.Controls.Add(this.label7);
            this.grbTimKiem.Location = new System.Drawing.Point(716, 13);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(330, 99);
            this.grbTimKiem.TabIndex = 18;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Tìm kiếm";
            // 
            // cmbDotTK
            // 
            this.cmbDotTK.FormattingEnabled = true;
            this.cmbDotTK.Location = new System.Drawing.Point(65, 13);
            this.cmbDotTK.Name = "cmbDotTK";
            this.cmbDotTK.Size = new System.Drawing.Size(101, 24);
            this.cmbDotTK.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Mã đợt";
            // 
            // rdoTHPT
            // 
            this.rdoTHPT.AutoSize = true;
            this.rdoTHPT.Location = new System.Drawing.Point(142, 74);
            this.rdoTHPT.Name = "rdoTHPT";
            this.rdoTHPT.Size = new System.Drawing.Size(70, 20);
            this.rdoTHPT.TabIndex = 24;
            this.rdoTHPT.Text = "Học bạ";
            this.rdoTHPT.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(10, 76);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(49, 20);
            this.rdoAll.TabIndex = 23;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "ALL";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdbDH
            // 
            this.rdbDH.AutoSize = true;
            this.rdbDH.Location = new System.Drawing.Point(65, 74);
            this.rdbDH.Name = "rdbDH";
            this.rdbDH.Size = new System.Drawing.Size(74, 20);
            this.rdbDH.TabIndex = 22;
            this.rdbDH.Text = "3 Chung";
            this.rdbDH.UseVisualStyleBackColor = true;
            // 
            // bntHienAll
            // 
            this.bntHienAll.Location = new System.Drawing.Point(170, 43);
            this.bntHienAll.Name = "bntHienAll";
            this.bntHienAll.Size = new System.Drawing.Size(75, 29);
            this.bntHienAll.TabIndex = 21;
            this.bntHienAll.Text = "Hiện hết";
            this.bntHienAll.UseVisualStyleBackColor = true;
            this.bntHienAll.Click += new System.EventHandler(this.bntHienAll_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(249, 43);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 29);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cmbKhoiTK
            // 
            this.cmbKhoiTK.FormattingEnabled = true;
            this.cmbKhoiTK.Location = new System.Drawing.Point(210, 12);
            this.cmbKhoiTK.Name = "cmbKhoiTK";
            this.cmbKhoiTK.Size = new System.Drawing.Size(99, 24);
            this.cmbKhoiTK.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Khối";
            // 
            // cmbHeTK
            // 
            this.cmbHeTK.FormattingEnabled = true;
            this.cmbHeTK.Location = new System.Drawing.Point(65, 44);
            this.cmbHeTK.Name = "cmbHeTK";
            this.cmbHeTK.Size = new System.Drawing.Size(99, 24);
            this.cmbHeTK.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hệ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Điểm xét";
            // 
            // txtDiemSan
            // 
            this.txtDiemSan.Location = new System.Drawing.Point(610, 62);
            this.txtDiemSan.Name = "txtDiemSan";
            this.txtDiemSan.Size = new System.Drawing.Size(100, 22);
            this.txtDiemSan.TabIndex = 16;
            // 
            // cmbHeXetTuyen
            // 
            this.cmbHeXetTuyen.FormattingEnabled = true;
            this.cmbHeXetTuyen.Location = new System.Drawing.Point(76, 88);
            this.cmbHeXetTuyen.Name = "cmbHeXetTuyen";
            this.cmbHeXetTuyen.Size = new System.Drawing.Size(110, 24);
            this.cmbHeXetTuyen.TabIndex = 15;
            this.cmbHeXetTuyen.SelectedValueChanged += new System.EventHandler(this.cmbHeXetTuyen_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hệ";
            // 
            // txtDiemChuan
            // 
            this.txtDiemChuan.Location = new System.Drawing.Point(610, 29);
            this.txtDiemChuan.Name = "txtDiemChuan";
            this.txtDiemChuan.Size = new System.Drawing.Size(100, 22);
            this.txtDiemChuan.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Điểm chuẩn";
            // 
            // cmbMaKhoi
            // 
            this.cmbMaKhoi.FormattingEnabled = true;
            this.cmbMaKhoi.Location = new System.Drawing.Point(281, 85);
            this.cmbMaKhoi.Name = "cmbMaKhoi";
            this.cmbMaKhoi.Size = new System.Drawing.Size(99, 24);
            this.cmbMaKhoi.TabIndex = 9;
            this.cmbMaKhoi.SelectedValueChanged += new System.EventHandler(this.cmbMaKhoi_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khối";
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(281, 55);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(242, 24);
            this.cmbNganh.TabIndex = 7;
            this.cmbNganh.SelectedIndexChanged += new System.EventHandler(this.cmbNganh_SelectedIndexChanged);
            this.cmbNganh.SelectedValueChanged += new System.EventHandler(this.cmbNganh_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngành";
            // 
            // cmbNhomNganh
            // 
            this.cmbNhomNganh.FormattingEnabled = true;
            this.cmbNhomNganh.Location = new System.Drawing.Point(281, 25);
            this.cmbNhomNganh.Name = "cmbNhomNganh";
            this.cmbNhomNganh.Size = new System.Drawing.Size(210, 24);
            this.cmbNhomNganh.TabIndex = 5;
            this.cmbNhomNganh.SelectedValueChanged += new System.EventHandler(this.cmbNhomNganh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm ngành";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(77, 29);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(100, 22);
            this.txtNam.TabIndex = 3;
            // 
            // cmbMaDot
            // 
            this.cmbMaDot.FormattingEnabled = true;
            this.cmbMaDot.Location = new System.Drawing.Point(76, 58);
            this.cmbMaDot.Name = "cmbMaDot";
            this.cmbMaDot.Size = new System.Drawing.Size(101, 24);
            this.cmbMaDot.TabIndex = 2;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(32, 26);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(37, 16);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Năm";
            // 
            // lblMaDot
            // 
            this.lblMaDot.AutoSize = true;
            this.lblMaDot.Location = new System.Drawing.Point(21, 62);
            this.lblMaDot.Name = "lblMaDot";
            this.lblMaDot.Size = new System.Drawing.Size(49, 16);
            this.lblMaDot.TabIndex = 0;
            this.lblMaDot.Text = "Mã đợt";
            // 
            // frmDieuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1138, 477);
            this.Name = "frmDieuKien";
            this.Text = "Thiết lập điều kiện xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblMaDot;
        private System.Windows.Forms.ComboBox cmbMaDot;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.ComboBox cmbNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNhomNganh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaKhoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiemChuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHeXetTuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiemSan;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.Button bntHienAll;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cmbKhoiTK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbHeTK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoTHPT;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdbDH;
        private System.Windows.Forms.ComboBox cmbDotTK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemChuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemSan;
    }
}
