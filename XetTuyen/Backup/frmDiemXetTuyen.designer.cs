namespace XetTuyen
{
    partial class frmDiemXetTuyen
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
            this.dgvDienXetTuyen = new System.Windows.Forms.DataGridView();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.cmbKhoiXT = new System.Windows.Forms.ComboBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiemUTDT = new System.Windows.Forms.TextBox();
            this.txtDiemUTKV = new System.Windows.Forms.TextBox();
            this.txtTongDiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoBaoDanh = new System.Windows.Forms.TextBox();
            this.lblSoBaoDanh = new System.Windows.Forms.Label();
            this.clmIdHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienXetTuyen)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(589, 32);
            this.lblTitle.Text = "Cập nhật điểm xét tuyển";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(589, 606);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 638);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(589, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvDienXetTuyen);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 124);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(589, 482);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvDienXetTuyen
            // 
            this.dgvDienXetTuyen.AllowUserToAddRows = false;
            this.dgvDienXetTuyen.AllowUserToDeleteRows = false;
            this.dgvDienXetTuyen.AllowUserToResizeRows = false;
            this.dgvDienXetTuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDienXetTuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdHS,
            this.clmMaMon,
            this.clmTenMon,
            this.clmDiem,
            this.clmViTri});
            this.dgvDienXetTuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDienXetTuyen.Location = new System.Drawing.Point(3, 18);
            this.dgvDienXetTuyen.Name = "dgvDienXetTuyen";
            this.dgvDienXetTuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDienXetTuyen.Size = new System.Drawing.Size(583, 461);
            this.dgvDienXetTuyen.TabIndex = 0;
            this.dgvDienXetTuyen.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDienXetTuyen_CellValidating);
            this.dgvDienXetTuyen.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.cmbKhoiXT);
            this.grpDetailInfo.Controls.Add(this.lblThongBao);
            this.grpDetailInfo.Controls.Add(this.label7);
            this.grpDetailInfo.Controls.Add(this.label6);
            this.grpDetailInfo.Controls.Add(this.txtDiemUTDT);
            this.grpDetailInfo.Controls.Add(this.txtDiemUTKV);
            this.grpDetailInfo.Controls.Add(this.txtTongDiem);
            this.grpDetailInfo.Controls.Add(this.label5);
            this.grpDetailInfo.Controls.Add(this.txtMaHS);
            this.grpDetailInfo.Controls.Add(this.label4);
            this.grpDetailInfo.Controls.Add(this.label3);
            this.grpDetailInfo.Controls.Add(this.txtDiemTB);
            this.grpDetailInfo.Controls.Add(this.label2);
            this.grpDetailInfo.Controls.Add(this.txtHoTen);
            this.grpDetailInfo.Controls.Add(this.label1);
            this.grpDetailInfo.Controls.Add(this.txtSoBaoDanh);
            this.grpDetailInfo.Controls.Add(this.lblSoBaoDanh);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(589, 124);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // cmbKhoiXT
            // 
            this.cmbKhoiXT.FormattingEnabled = true;
            this.cmbKhoiXT.Location = new System.Drawing.Point(107, 86);
            this.cmbKhoiXT.Name = "cmbKhoiXT";
            this.cmbKhoiXT.Size = new System.Drawing.Size(105, 24);
            this.cmbKhoiXT.TabIndex = 24;
            this.cmbKhoiXT.SelectedIndexChanged += new System.EventHandler(this.cmbKhoiXT_SelectedIndexChanged);
            this.cmbKhoiXT.SelectedValueChanged += new System.EventHandler(this.cmbKhoiXT_SelectedValueChanged);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblThongBao.Location = new System.Drawing.Point(3, 105);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 16);
            this.lblThongBao.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Điểm UTĐT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Điểm UTKV";
            // 
            // txtDiemUTDT
            // 
            this.txtDiemUTDT.Enabled = false;
            this.txtDiemUTDT.Location = new System.Drawing.Point(509, 86);
            this.txtDiemUTDT.Name = "txtDiemUTDT";
            this.txtDiemUTDT.Size = new System.Drawing.Size(72, 22);
            this.txtDiemUTDT.TabIndex = 20;
            // 
            // txtDiemUTKV
            // 
            this.txtDiemUTKV.Enabled = false;
            this.txtDiemUTKV.Location = new System.Drawing.Point(510, 59);
            this.txtDiemUTKV.Name = "txtDiemUTKV";
            this.txtDiemUTKV.Size = new System.Drawing.Size(72, 22);
            this.txtDiemUTKV.TabIndex = 18;
            // 
            // txtTongDiem
            // 
            this.txtTongDiem.Enabled = false;
            this.txtTongDiem.Location = new System.Drawing.Point(345, 86);
            this.txtTongDiem.Name = "txtTongDiem";
            this.txtTongDiem.Size = new System.Drawing.Size(79, 22);
            this.txtTongDiem.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tổng điểm xét tuyển";
            // 
            // txtMaHS
            // 
            this.txtMaHS.Enabled = false;
            this.txtMaHS.Location = new System.Drawing.Point(107, 29);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(118, 22);
            this.txtMaHS.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã hồ sơ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Khối";
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Enabled = false;
            this.txtDiemTB.Location = new System.Drawing.Point(345, 58);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(79, 22);
            this.txtDiemTB.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Điểm trung bình";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(345, 31);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(236, 22);
            this.txtHoTen.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Họ tên";
            // 
            // txtSoBaoDanh
            // 
            this.txtSoBaoDanh.Enabled = false;
            this.txtSoBaoDanh.Location = new System.Drawing.Point(107, 59);
            this.txtSoBaoDanh.Name = "txtSoBaoDanh";
            this.txtSoBaoDanh.Size = new System.Drawing.Size(118, 22);
            this.txtSoBaoDanh.TabIndex = 6;
            // 
            // lblSoBaoDanh
            // 
            this.lblSoBaoDanh.AutoSize = true;
            this.lblSoBaoDanh.Location = new System.Drawing.Point(22, 61);
            this.lblSoBaoDanh.Name = "lblSoBaoDanh";
            this.lblSoBaoDanh.Size = new System.Drawing.Size(85, 16);
            this.lblSoBaoDanh.TabIndex = 5;
            this.lblSoBaoDanh.Text = "Số báo danh";
            // 
            // clmIdHS
            // 
            this.clmIdHS.DataPropertyName = "IDHS";
            this.clmIdHS.HeaderText = "MaHS";
            this.clmIdHS.Name = "clmIdHS";
            this.clmIdHS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmIdHS.Visible = false;
            this.clmIdHS.Width = 200;
            // 
            // clmMaMon
            // 
            this.clmMaMon.DataPropertyName = "MaMon";
            this.clmMaMon.HeaderText = "Mã môn";
            this.clmMaMon.Name = "clmMaMon";
            this.clmMaMon.ReadOnly = true;
            this.clmMaMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmMaMon.Visible = false;
            // 
            // clmTenMon
            // 
            this.clmTenMon.DataPropertyName = "TenMon";
            this.clmTenMon.HeaderText = "Tên môn";
            this.clmTenMon.Name = "clmTenMon";
            this.clmTenMon.ReadOnly = true;
            this.clmTenMon.Width = 200;
            // 
            // clmDiem
            // 
            this.clmDiem.DataPropertyName = "Diem";
            this.clmDiem.HeaderText = "Điểm";
            this.clmDiem.Name = "clmDiem";
            this.clmDiem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDiem.Width = 150;
            // 
            // clmViTri
            // 
            this.clmViTri.DataPropertyName = "ViTri";
            this.clmViTri.HeaderText = "Vị trí";
            this.clmViTri.Name = "clmViTri";
            this.clmViTri.ReadOnly = true;
            this.clmViTri.Visible = false;
            // 
            // frmDiemXetTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(589, 672);
            this.Name = "frmDiemXetTuyen";
            this.Text = "Danh mục điểm xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDienXetTuyen)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvDienXetTuyen;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.TextBox txtSoBaoDanh;
        private System.Windows.Forms.Label lblSoBaoDanh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemUTKV;
        private System.Windows.Forms.TextBox txtDiemUTDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.ComboBox cmbKhoiXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmViTri;
    }
}
