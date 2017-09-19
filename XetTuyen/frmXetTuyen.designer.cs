namespace XetTuyen
{
    partial class frmXetTuyen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvHoSo = new System.Windows.Forms.DataGridView();
            this.clmSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoBaoDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoCMTND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNganhSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmlDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmlMaKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.cmbHe = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCapNhap = new System.Windows.Forms.Button();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.btnHienAll = new System.Windows.Forms.Button();
            this.txtSoEnd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoStart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbKhoiTK = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNganhTK = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNhonNganhTK = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cmbMaDot = new System.Windows.Forms.ComboBox();
            this.lblMaDot = new System.Windows.Forms.Label();
            this.cmbHeTK = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoBaoDanh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMaKhoi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNganh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNhomNganh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.objdsTuyenSinh = new XetTuyen.dsTuyenSinh();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objdsTuyenSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1208, 32);
            this.lblTitle.Text = "Xét tuyển hồ sơ";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(1208, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.CancelVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.EditVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.SaveVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(1208, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.PrintHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_PrintHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDataButton1_PreviewKeyDown);
            this.ucDataButton1.ExcelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_ExcelHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvHoSo);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 145);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1208, 266);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvHoSo
            // 
            this.dgvHoSo.AllowUserToAddRows = false;
            this.dgvHoSo.AllowUserToDeleteRows = false;
            this.dgvHoSo.AllowUserToResizeRows = false;
            this.dgvHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoSo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSTT,
            this.clmMaHS,
            this.clmMaDot,
            this.clmSoBaoDanh,
            this.clmSoCMTND,
            this.clmHoTen,
            this.clmNganhSinh,
            this.clmGioiTinh,
            this.cmlDienThoai,
            this.clmHoKhau,
            this.clmTenNganh,
            this.cmlMaKhoi,
            this.clmDiemTB,
            this.clmMaNganh,
            this.clmHe});
            this.dgvHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoSo.Location = new System.Drawing.Point(3, 18);
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.ReadOnly = true;
            this.dgvHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoSo.Size = new System.Drawing.Size(1202, 245);
            this.dgvHoSo.TabIndex = 0;
            this.dgvHoSo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvHoSo_RowPrePaint);
            this.dgvHoSo.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // clmSTT
            // 
            this.clmSTT.HeaderText = "STT";
            this.clmSTT.Name = "clmSTT";
            this.clmSTT.ReadOnly = true;
            this.clmSTT.Width = 75;
            // 
            // clmMaHS
            // 
            this.clmMaHS.DataPropertyName = "MaHS";
            this.clmMaHS.HeaderText = "Mã hồ sơ";
            this.clmMaHS.Name = "clmMaHS";
            this.clmMaHS.ReadOnly = true;
            // 
            // clmMaDot
            // 
            this.clmMaDot.DataPropertyName = "MaDot";
            this.clmMaDot.HeaderText = "Mã đợt";
            this.clmMaDot.Name = "clmMaDot";
            this.clmMaDot.ReadOnly = true;
            // 
            // clmSoBaoDanh
            // 
            this.clmSoBaoDanh.DataPropertyName = "SoBaoDanh";
            this.clmSoBaoDanh.HeaderText = "Số báo danh";
            this.clmSoBaoDanh.Name = "clmSoBaoDanh";
            this.clmSoBaoDanh.ReadOnly = true;
            this.clmSoBaoDanh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmSoCMTND
            // 
            this.clmSoCMTND.DataPropertyName = "SoCMTND";
            this.clmSoCMTND.HeaderText = "Số CMTND";
            this.clmSoCMTND.Name = "clmSoCMTND";
            this.clmSoCMTND.ReadOnly = true;
            this.clmSoCMTND.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSoCMTND.Width = 90;
            // 
            // clmHoTen
            // 
            this.clmHoTen.DataPropertyName = "HoTen";
            this.clmHoTen.HeaderText = "Họ tên";
            this.clmHoTen.Name = "clmHoTen";
            this.clmHoTen.ReadOnly = true;
            this.clmHoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmHoTen.Width = 150;
            // 
            // clmNganhSinh
            // 
            this.clmNganhSinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.clmNganhSinh.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmNganhSinh.HeaderText = "Ngày sinh";
            this.clmNganhSinh.Name = "clmNganhSinh";
            this.clmNganhSinh.ReadOnly = true;
            // 
            // clmGioiTinh
            // 
            this.clmGioiTinh.DataPropertyName = "GioiTinh";
            this.clmGioiTinh.HeaderText = "Giới tính";
            this.clmGioiTinh.Name = "clmGioiTinh";
            this.clmGioiTinh.ReadOnly = true;
            this.clmGioiTinh.Width = 90;
            // 
            // cmlDienThoai
            // 
            this.cmlDienThoai.DataPropertyName = "DienThoai";
            this.cmlDienThoai.HeaderText = "Điện thoại";
            this.cmlDienThoai.Name = "cmlDienThoai";
            this.cmlDienThoai.ReadOnly = true;
            // 
            // clmHoKhau
            // 
            this.clmHoKhau.DataPropertyName = "HoKhau";
            this.clmHoKhau.HeaderText = "Hộ khẩu";
            this.clmHoKhau.Name = "clmHoKhau";
            this.clmHoKhau.ReadOnly = true;
            this.clmHoKhau.Width = 250;
            // 
            // clmTenNganh
            // 
            this.clmTenNganh.DataPropertyName = "TenNganh";
            this.clmTenNganh.HeaderText = "Tên ngành";
            this.clmTenNganh.Name = "clmTenNganh";
            this.clmTenNganh.ReadOnly = true;
            // 
            // cmlMaKhoi
            // 
            this.cmlMaKhoi.DataPropertyName = "MaKhoi";
            this.cmlMaKhoi.HeaderText = "Khối";
            this.cmlMaKhoi.Name = "cmlMaKhoi";
            this.cmlMaKhoi.ReadOnly = true;
            // 
            // clmDiemTB
            // 
            this.clmDiemTB.DataPropertyName = "DiemTB";
            this.clmDiemTB.HeaderText = "Điểm TB";
            this.clmDiemTB.Name = "clmDiemTB";
            this.clmDiemTB.ReadOnly = true;
            // 
            // clmMaNganh
            // 
            this.clmMaNganh.DataPropertyName = "MaNganh";
            this.clmMaNganh.HeaderText = "MaNganh";
            this.clmMaNganh.Name = "clmMaNganh";
            this.clmMaNganh.ReadOnly = true;
            this.clmMaNganh.Visible = false;
            // 
            // clmHe
            // 
            this.clmHe.DataPropertyName = "LoaiNganh";
            this.clmHe.HeaderText = "Hệ";
            this.clmHe.Name = "clmHe";
            this.clmHe.ReadOnly = true;
            this.clmHe.Visible = false;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.cmbHe);
            this.grpDetailInfo.Controls.Add(this.label13);
            this.grpDetailInfo.Controls.Add(this.btnCapNhap);
            this.grpDetailInfo.Controls.Add(this.grbTimKiem);
            this.grpDetailInfo.Controls.Add(this.txtHoTen);
            this.grpDetailInfo.Controls.Add(this.label11);
            this.grpDetailInfo.Controls.Add(this.txtMaHS);
            this.grpDetailInfo.Controls.Add(this.label10);
            this.grpDetailInfo.Controls.Add(this.txtSoBaoDanh);
            this.grpDetailInfo.Controls.Add(this.label9);
            this.grpDetailInfo.Controls.Add(this.cmbMaKhoi);
            this.grpDetailInfo.Controls.Add(this.label3);
            this.grpDetailInfo.Controls.Add(this.cmbNganh);
            this.grpDetailInfo.Controls.Add(this.label2);
            this.grpDetailInfo.Controls.Add(this.cmbNhomNganh);
            this.grpDetailInfo.Controls.Add(this.label1);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(1208, 145);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            this.grpDetailInfo.Enter += new System.EventHandler(this.grpDetailInfo_Enter);
            // 
            // cmbHe
            // 
            this.cmbHe.Enabled = false;
            this.cmbHe.FormattingEnabled = true;
            this.cmbHe.Location = new System.Drawing.Point(86, 104);
            this.cmbHe.Name = "cmbHe";
            this.cmbHe.Size = new System.Drawing.Size(107, 24);
            this.cmbHe.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "Hệ";
            // 
            // btnCapNhap
            // 
            this.btnCapNhap.Location = new System.Drawing.Point(491, 99);
            this.btnCapNhap.Name = "btnCapNhap";
            this.btnCapNhap.Size = new System.Drawing.Size(103, 34);
            this.btnCapNhap.TabIndex = 39;
            this.btnCapNhap.Text = "Cập nhật";
            this.btnCapNhap.UseVisualStyleBackColor = true;
            this.btnCapNhap.Click += new System.EventHandler(this.btnCapNhap_Click);
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grbTimKiem.Controls.Add(this.btnHienAll);
            this.grbTimKiem.Controls.Add(this.txtSoEnd);
            this.grbTimKiem.Controls.Add(this.label12);
            this.grbTimKiem.Controls.Add(this.txtSoStart);
            this.grbTimKiem.Controls.Add(this.label8);
            this.grbTimKiem.Controls.Add(this.cmbKhoiTK);
            this.grbTimKiem.Controls.Add(this.label7);
            this.grbTimKiem.Controls.Add(this.cmbNganhTK);
            this.grbTimKiem.Controls.Add(this.label6);
            this.grbTimKiem.Controls.Add(this.cmbNhonNganhTK);
            this.grbTimKiem.Controls.Add(this.label4);
            this.grbTimKiem.Controls.Add(this.btnTimKiem);
            this.grbTimKiem.Controls.Add(this.cmbMaDot);
            this.grbTimKiem.Controls.Add(this.lblMaDot);
            this.grbTimKiem.Controls.Add(this.cmbHeTK);
            this.grbTimKiem.Controls.Add(this.label5);
            this.grbTimKiem.Controls.Add(this.txtNam);
            this.grbTimKiem.Controls.Add(this.lblNam);
            this.grbTimKiem.Location = new System.Drawing.Point(600, 17);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(596, 116);
            this.grbTimKiem.TabIndex = 38;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Tìm kiếm";
            // 
            // btnHienAll
            // 
            this.btnHienAll.Location = new System.Drawing.Point(462, 71);
            this.btnHienAll.Name = "btnHienAll";
            this.btnHienAll.Size = new System.Drawing.Size(99, 28);
            this.btnHienAll.TabIndex = 27;
            this.btnHienAll.Text = "Hiện hết";
            this.btnHienAll.UseVisualStyleBackColor = true;
            this.btnHienAll.Click += new System.EventHandler(this.btnHienAll_Click);
            // 
            // txtSoEnd
            // 
            this.txtSoEnd.Location = new System.Drawing.Point(509, 45);
            this.txtSoEnd.Name = "txtSoEnd";
            this.txtSoEnd.Size = new System.Drawing.Size(64, 22);
            this.txtSoEnd.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "Đến";
            // 
            // txtSoStart
            // 
            this.txtSoStart.Location = new System.Drawing.Point(509, 14);
            this.txtSoStart.Name = "txtSoStart";
            this.txtSoStart.Size = new System.Drawing.Size(64, 22);
            this.txtSoStart.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Số hồ sơ từ";
            // 
            // cmbKhoiTK
            // 
            this.cmbKhoiTK.FormattingEnabled = true;
            this.cmbKhoiTK.Location = new System.Drawing.Point(243, 75);
            this.cmbKhoiTK.Name = "cmbKhoiTK";
            this.cmbKhoiTK.Size = new System.Drawing.Size(99, 24);
            this.cmbKhoiTK.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Khối";
            // 
            // cmbNganhTK
            // 
            this.cmbNganhTK.FormattingEnabled = true;
            this.cmbNganhTK.Location = new System.Drawing.Point(243, 45);
            this.cmbNganhTK.Name = "cmbNganhTK";
            this.cmbNganhTK.Size = new System.Drawing.Size(218, 24);
            this.cmbNganhTK.TabIndex = 20;
            this.cmbNganhTK.SelectedIndexChanged += new System.EventHandler(this.cmbNganhTK_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ngành";
            // 
            // cmbNhonNganhTK
            // 
            this.cmbNhonNganhTK.FormattingEnabled = true;
            this.cmbNhonNganhTK.Location = new System.Drawing.Point(243, 15);
            this.cmbNhonNganhTK.Name = "cmbNhonNganhTK";
            this.cmbNhonNganhTK.Size = new System.Drawing.Size(180, 24);
            this.cmbNhonNganhTK.TabIndex = 18;
            this.cmbNhonNganhTK.SelectedIndexChanged += new System.EventHandler(this.cmbNhonNganhTK_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nhóm ngành";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(348, 71);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(99, 28);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm hồ sơ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnLocDL_Click);
            // 
            // cmbMaDot
            // 
            this.cmbMaDot.FormattingEnabled = true;
            this.cmbMaDot.Location = new System.Drawing.Point(64, 49);
            this.cmbMaDot.Name = "cmbMaDot";
            this.cmbMaDot.Size = new System.Drawing.Size(110, 24);
            this.cmbMaDot.TabIndex = 2;
            // 
            // lblMaDot
            // 
            this.lblMaDot.AutoSize = true;
            this.lblMaDot.Location = new System.Drawing.Point(9, 53);
            this.lblMaDot.Name = "lblMaDot";
            this.lblMaDot.Size = new System.Drawing.Size(49, 16);
            this.lblMaDot.TabIndex = 0;
            this.lblMaDot.Text = "Mã đợt";
            // 
            // cmbHeTK
            // 
            this.cmbHeTK.FormattingEnabled = true;
            this.cmbHeTK.Location = new System.Drawing.Point(64, 79);
            this.cmbHeTK.Name = "cmbHeTK";
            this.cmbHeTK.Size = new System.Drawing.Size(110, 24);
            this.cmbHeTK.TabIndex = 15;
            this.cmbHeTK.SelectedIndexChanged += new System.EventHandler(this.cmbHeTK_SelectedIndexChanged);
            this.cmbHeTK.SelectedValueChanged += new System.EventHandler(this.cmbHeXetTuyen_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hệ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(64, 21);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(64, 22);
            this.txtNam.TabIndex = 3;
            this.txtNam.TextChanged += new System.EventHandler(this.txtNam_TextChanged);
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(19, 23);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(37, 16);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Năm";
            this.lblNam.Click += new System.EventHandler(this.lblNam_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(85, 17);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(181, 22);
            this.txtHoTen.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Họ tên";
            // 
            // txtMaHS
            // 
            this.txtMaHS.Enabled = false;
            this.txtMaHS.Location = new System.Drawing.Point(85, 45);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(105, 22);
            this.txtMaHS.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Mã hố sơ";
            // 
            // txtSoBaoDanh
            // 
            this.txtSoBaoDanh.Enabled = false;
            this.txtSoBaoDanh.Location = new System.Drawing.Point(86, 73);
            this.txtSoBaoDanh.Name = "txtSoBaoDanh";
            this.txtSoBaoDanh.Size = new System.Drawing.Size(129, 22);
            this.txtSoBaoDanh.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Số CMTND";
            // 
            // cmbMaKhoi
            // 
            this.cmbMaKhoi.Enabled = false;
            this.cmbMaKhoi.FormattingEnabled = true;
            this.cmbMaKhoi.Location = new System.Drawing.Point(356, 79);
            this.cmbMaKhoi.Name = "cmbMaKhoi";
            this.cmbMaKhoi.Size = new System.Drawing.Size(99, 24);
            this.cmbMaKhoi.TabIndex = 9;
            this.cmbMaKhoi.SelectedValueChanged += new System.EventHandler(this.cmbMaKhoi_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khối";
            // 
            // cmbNganh
            // 
            this.cmbNganh.Enabled = false;
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(356, 49);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(239, 24);
            this.cmbNganh.TabIndex = 7;
            this.cmbNganh.SelectedValueChanged += new System.EventHandler(this.cmbNganh_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngành";
            // 
            // cmbNhomNganh
            // 
            this.cmbNhomNganh.Enabled = false;
            this.cmbNhomNganh.FormattingEnabled = true;
            this.cmbNhomNganh.Location = new System.Drawing.Point(356, 18);
            this.cmbNhomNganh.Name = "cmbNhomNganh";
            this.cmbNhomNganh.Size = new System.Drawing.Size(217, 24);
            this.cmbNhomNganh.TabIndex = 5;
            this.cmbNhomNganh.SelectedIndexChanged += new System.EventHandler(this.cmbNhomNganh_SelectedIndexChanged);
            this.cmbNhomNganh.SelectedValueChanged += new System.EventHandler(this.cmbNhomNganh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm ngành";
            // 
            // objdsTuyenSinh
            // 
            this.objdsTuyenSinh.DataSetName = "dsTuyenSinh";
            this.objdsTuyenSinh.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            // 
            // frmXetTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1208, 477);
            this.Name = "frmXetTuyen";
            this.Text = "Xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmXetTuyen_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objdsTuyenSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvHoSo;
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
        private System.Windows.Forms.ComboBox cmbHeTK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimKiem;
        private dsTuyenSinh objdsTuyenSinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoBaoDanh;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.TextBox txtSoEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbKhoiTK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbNganhTK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNhonNganhTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCapNhap;
        private System.Windows.Forms.ComboBox cmbHe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnHienAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoBaoDanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoCMTND;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNganhSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmlDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmlMaKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiemTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHe;
        private System.ComponentModel.BackgroundWorker bw;
    }
}
