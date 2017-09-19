namespace XetTuyen
{
    partial class frmInGiayBao
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
            this.cmlSoQD = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.rdoTHPT = new System.Windows.Forms.RadioButton();
            this.rdbDH = new System.Windows.Forms.RadioButton();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.btnSaveParra = new System.Windows.Forms.Button();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.txtSoEnd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSoStart = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grbSapXep = new System.Windows.Forms.GroupBox();
            this.rdoMaHS = new System.Windows.Forms.RadioButton();
            this.rdoSoQD = new System.Windows.Forms.RadioButton();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoBaoDanh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoHoSo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSoSanh = new System.Windows.Forms.ComboBox();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLocDL = new System.Windows.Forms.Button();
            this.cmbHeXetTuyen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.objdsTuyenSinh = new XetTuyen.dsTuyenSinh();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.grbSapXep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objdsTuyenSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1250, 32);
            this.lblTitle.Text = "In giấy báo nhập học";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(1250, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.CancelVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.EditVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.SaveVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(1250, 34);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.PrintHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_PrintHandler);
            this.ucDataButton1.ExcelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_ExcelHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDataButton1_PreviewKeyDown);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvHoSo);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 151);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1250, 260);
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
            this.cmlSoQD,
            this.clmSoBaoDanh,
            this.clmSoCMTND,
            this.clmHoTen,
            this.clmNganhSinh,
            this.clmGioiTinh,
            this.cmlDienThoai,
            this.clmHoKhau,
            this.clmTenNganh,
            this.cmlMaKhoi,
            this.clmDiemTB});
            this.dgvHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoSo.Location = new System.Drawing.Point(3, 18);
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.ReadOnly = true;
            this.dgvHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoSo.Size = new System.Drawing.Size(1244, 239);
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
            // cmlSoQD
            // 
            this.cmlSoQD.DataPropertyName = "SoQD";
            this.cmlSoQD.HeaderText = "Số QĐ";
            this.cmlSoQD.Name = "cmlSoQD";
            this.cmlSoQD.ReadOnly = true;
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
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.rdoTHPT);
            this.grpDetailInfo.Controls.Add(this.rdbDH);
            this.grpDetailInfo.Controls.Add(this.grbThongTin);
            this.grpDetailInfo.Controls.Add(this.txtSoEnd);
            this.grpDetailInfo.Controls.Add(this.label14);
            this.grpDetailInfo.Controls.Add(this.txtSoStart);
            this.grpDetailInfo.Controls.Add(this.label13);
            this.grpDetailInfo.Controls.Add(this.txtHoTen);
            this.grpDetailInfo.Controls.Add(this.label11);
            this.grpDetailInfo.Controls.Add(this.grbSapXep);
            this.grpDetailInfo.Controls.Add(this.txtMaHS);
            this.grpDetailInfo.Controls.Add(this.label10);
            this.grpDetailInfo.Controls.Add(this.txtSoBaoDanh);
            this.grpDetailInfo.Controls.Add(this.label9);
            this.grpDetailInfo.Controls.Add(this.txtSoHoSo);
            this.grpDetailInfo.Controls.Add(this.label7);
            this.grpDetailInfo.Controls.Add(this.cmbSoSanh);
            this.grpDetailInfo.Controls.Add(this.txtDiemTB);
            this.grpDetailInfo.Controls.Add(this.label4);
            this.grpDetailInfo.Controls.Add(this.btnLocDL);
            this.grpDetailInfo.Controls.Add(this.cmbHeXetTuyen);
            this.grpDetailInfo.Controls.Add(this.label5);
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
            this.grpDetailInfo.Size = new System.Drawing.Size(1250, 151);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // rdoTHPT
            // 
            this.rdoTHPT.AutoSize = true;
            this.rdoTHPT.Checked = true;
            this.rdoTHPT.Location = new System.Drawing.Point(789, 80);
            this.rdoTHPT.Name = "rdoTHPT";
            this.rdoTHPT.Size = new System.Drawing.Size(70, 20);
            this.rdoTHPT.TabIndex = 46;
            this.rdoTHPT.TabStop = true;
            this.rdoTHPT.Text = "Học bạ";
            this.rdoTHPT.UseVisualStyleBackColor = true;
            // 
            // rdbDH
            // 
            this.rdbDH.AutoSize = true;
            this.rdbDH.Location = new System.Drawing.Point(709, 79);
            this.rdbDH.Name = "rdbDH";
            this.rdbDH.Size = new System.Drawing.Size(74, 20);
            this.rdbDH.TabIndex = 45;
            this.rdbDH.Text = "3 Chung";
            this.rdbDH.UseVisualStyleBackColor = true;
            // 
            // grbThongTin
            // 
            this.grbThongTin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grbThongTin.Controls.Add(this.btnSaveParra);
            this.grbThongTin.Controls.Add(this.txtDiaDiem);
            this.grbThongTin.Controls.Add(this.label6);
            this.grbThongTin.Controls.Add(this.label12);
            this.grbThongTin.Controls.Add(this.txtThoiGian);
            this.grbThongTin.Location = new System.Drawing.Point(868, 11);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(373, 140);
            this.grbThongTin.TabIndex = 44;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin hồ sơ";
            // 
            // btnSaveParra
            // 
            this.btnSaveParra.Location = new System.Drawing.Point(319, 15);
            this.btnSaveParra.Name = "btnSaveParra";
            this.btnSaveParra.Size = new System.Drawing.Size(48, 30);
            this.btnSaveParra.TabIndex = 47;
            this.btnSaveParra.Text = "Lưu";
            this.btnSaveParra.UseVisualStyleBackColor = true;
            this.btnSaveParra.Click += new System.EventHandler(this.btnSaveParra_Click);
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(28, 61);
            this.txtDiaDiem.Multiline = true;
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(314, 73);
            this.txtDiaDiem.TabIndex = 41;
            this.txtDiaDiem.Text = "trường Đại học Dân lập Hải Phòng, số 36 Đường Dân Lập - Phường Dư Hàng Kênh - Quậ" +
    "n Lê Chân - Tp Hải Phòng ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "Địa điểm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "Thời gian nhập học";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Location = new System.Drawing.Point(153, 16);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(163, 22);
            this.txtThoiGian.TabIndex = 39;
            this.txtThoiGian.Text = "16/8/2014 từ 7h30\' - 17h00\'";
            // 
            // txtSoEnd
            // 
            this.txtSoEnd.Location = new System.Drawing.Point(682, 50);
            this.txtSoEnd.Name = "txtSoEnd";
            this.txtSoEnd.Size = new System.Drawing.Size(54, 22);
            this.txtSoEnd.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(647, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 16);
            this.label14.TabIndex = 42;
            this.label14.Text = "đến";
            // 
            // txtSoStart
            // 
            this.txtSoStart.Location = new System.Drawing.Point(587, 50);
            this.txtSoStart.Name = "txtSoStart";
            this.txtSoStart.Size = new System.Drawing.Size(54, 22);
            this.txtSoStart.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(508, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "Số hồ sơ từ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(248, 107);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(228, 22);
            this.txtHoTen.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(194, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Họ tên";
            // 
            // grbSapXep
            // 
            this.grbSapXep.Controls.Add(this.rdoMaHS);
            this.grbSapXep.Controls.Add(this.rdoSoQD);
            this.grbSapXep.Location = new System.Drawing.Point(741, 11);
            this.grbSapXep.Name = "grbSapXep";
            this.grbSapXep.Size = new System.Drawing.Size(121, 61);
            this.grbSapXep.TabIndex = 35;
            this.grbSapXep.TabStop = false;
            this.grbSapXep.Text = "Sắp xếp theo";
            // 
            // rdoMaHS
            // 
            this.rdoMaHS.AutoSize = true;
            this.rdoMaHS.Checked = true;
            this.rdoMaHS.Location = new System.Drawing.Point(4, 17);
            this.rdoMaHS.Name = "rdoMaHS";
            this.rdoMaHS.Size = new System.Drawing.Size(81, 20);
            this.rdoMaHS.TabIndex = 33;
            this.rdoMaHS.TabStop = true;
            this.rdoMaHS.Text = "Mã hồ sơ";
            this.rdoMaHS.UseVisualStyleBackColor = true;
            // 
            // rdoSoQD
            // 
            this.rdoSoQD.AutoSize = true;
            this.rdoSoQD.Location = new System.Drawing.Point(4, 39);
            this.rdoSoQD.Name = "rdoSoQD";
            this.rdoSoQD.Size = new System.Drawing.Size(107, 20);
            this.rdoSoQD.TabIndex = 34;
            this.rdoSoQD.Text = "Số quyết định";
            this.rdoSoQD.UseVisualStyleBackColor = true;
            // 
            // txtMaHS
            // 
            this.txtMaHS.Location = new System.Drawing.Point(587, 106);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(107, 22);
            this.txtMaHS.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(513, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Mã hố sơ";
            // 
            // txtSoBaoDanh
            // 
            this.txtSoBaoDanh.Location = new System.Drawing.Point(587, 78);
            this.txtSoBaoDanh.Name = "txtSoBaoDanh";
            this.txtSoBaoDanh.Size = new System.Drawing.Size(107, 22);
            this.txtSoBaoDanh.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Số CMTND";
            // 
            // txtSoHoSo
            // 
            this.txtSoHoSo.Enabled = false;
            this.txtSoHoSo.Location = new System.Drawing.Point(71, 21);
            this.txtSoHoSo.Name = "txtSoHoSo";
            this.txtSoHoSo.Size = new System.Drawing.Size(79, 22);
            this.txtSoHoSo.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Số hồ sơ:";
            // 
            // cmbSoSanh
            // 
            this.cmbSoSanh.FormattingEnabled = true;
            this.cmbSoSanh.Location = new System.Drawing.Point(588, 20);
            this.cmbSoSanh.Name = "cmbSoSanh";
            this.cmbSoSanh.Size = new System.Drawing.Size(51, 24);
            this.cmbSoSanh.TabIndex = 19;
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Location = new System.Drawing.Point(645, 20);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(91, 22);
            this.txtDiemTB.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Điểm trung bình";
            // 
            // btnLocDL
            // 
            this.btnLocDL.Location = new System.Drawing.Point(720, 103);
            this.btnLocDL.Name = "btnLocDL";
            this.btnLocDL.Size = new System.Drawing.Size(142, 28);
            this.btnLocDL.TabIndex = 16;
            this.btnLocDL.Text = "Tìm kiếm";
            this.btnLocDL.UseVisualStyleBackColor = true;
            this.btnLocDL.Click += new System.EventHandler(this.btnLocDL_Click);
            // 
            // cmbHeXetTuyen
            // 
            this.cmbHeXetTuyen.FormattingEnabled = true;
            this.cmbHeXetTuyen.Location = new System.Drawing.Point(71, 107);
            this.cmbHeXetTuyen.Name = "cmbHeXetTuyen";
            this.cmbHeXetTuyen.Size = new System.Drawing.Size(110, 24);
            this.cmbHeXetTuyen.TabIndex = 15;
            this.cmbHeXetTuyen.SelectedValueChanged += new System.EventHandler(this.cmbHeXetTuyen_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hệ";
            // 
            // cmbMaKhoi
            // 
            this.cmbMaKhoi.FormattingEnabled = true;
            this.cmbMaKhoi.Location = new System.Drawing.Point(248, 77);
            this.cmbMaKhoi.Name = "cmbMaKhoi";
            this.cmbMaKhoi.Size = new System.Drawing.Size(90, 24);
            this.cmbMaKhoi.TabIndex = 9;
            this.cmbMaKhoi.SelectedValueChanged += new System.EventHandler(this.cmbMaKhoi_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khối";
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(248, 47);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(228, 24);
            this.cmbNganh.TabIndex = 7;
            this.cmbNganh.SelectedIndexChanged += new System.EventHandler(this.cmbNganh_SelectedIndexChanged);
            this.cmbNganh.SelectedValueChanged += new System.EventHandler(this.cmbNganh_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngành";
            // 
            // cmbNhomNganh
            // 
            this.cmbNhomNganh.FormattingEnabled = true;
            this.cmbNhomNganh.Location = new System.Drawing.Point(248, 20);
            this.cmbNhomNganh.Name = "cmbNhomNganh";
            this.cmbNhomNganh.Size = new System.Drawing.Size(228, 24);
            this.cmbNhomNganh.TabIndex = 5;
            this.cmbNhomNganh.SelectedValueChanged += new System.EventHandler(this.cmbNhomNganh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm ngành";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(71, 48);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(79, 22);
            this.txtNam.TabIndex = 3;
            this.txtNam.TextChanged += new System.EventHandler(this.txtNam_TextChanged);
            // 
            // cmbMaDot
            // 
            this.cmbMaDot.FormattingEnabled = true;
            this.cmbMaDot.Location = new System.Drawing.Point(70, 77);
            this.cmbMaDot.Name = "cmbMaDot";
            this.cmbMaDot.Size = new System.Drawing.Size(111, 24);
            this.cmbMaDot.TabIndex = 2;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(26, 50);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(37, 16);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Năm";
            // 
            // lblMaDot
            // 
            this.lblMaDot.AutoSize = true;
            this.lblMaDot.Location = new System.Drawing.Point(15, 81);
            this.lblMaDot.Name = "lblMaDot";
            this.lblMaDot.Size = new System.Drawing.Size(49, 16);
            this.lblMaDot.TabIndex = 0;
            this.lblMaDot.Text = "Mã đợt";
            // 
            // objdsTuyenSinh
            // 
            this.objdsTuyenSinh.DataSetName = "dsTuyenSinh";
            this.objdsTuyenSinh.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmInGiayBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1250, 477);
            this.Name = "frmInGiayBao";
            this.Text = "In giấy báo nhập học";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.grbSapXep.ResumeLayout(false);
            this.grbSapXep.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbHeXetTuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLocDL;
        private dsTuyenSinh objdsTuyenSinh;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSoSanh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoHoSo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoBaoDanh;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoSoQD;
        private System.Windows.Forms.RadioButton rdoMaHS;
        private System.Windows.Forms.GroupBox grbSapXep;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSoEnd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoTHPT;
        private System.Windows.Forms.RadioButton rdbDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmlSoQD;
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
        private System.Windows.Forms.Button btnSaveParra;
    }
}
