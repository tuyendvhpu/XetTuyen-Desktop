namespace XetTuyen
{
    partial class frmCongThuc
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
            this.clmMaKhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHeSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.btnTinhDiemTB = new System.Windows.Forms.Button();
            this.cmbHeXetTuyen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeSo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMaMon = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
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
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(796, 32);
            this.lblTitle.Text = "Danh mục hệ số xét tuyển";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(796, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(796, 34);
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
            this.grpList.Location = new System.Drawing.Point(0, 120);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(796, 291);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvCongThuc
            // 
            this.dgvCongThuc.AllowUserToAddRows = false;
            this.dgvCongThuc.AllowUserToDeleteRows = false;
            this.dgvCongThuc.AllowUserToResizeRows = false;
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaDot,
            this.clmNam,
            this.clmMaNganh,
            this.clmIDNganh,
            this.clmMaKhoi,
            this.clmMaMon,
            this.clmHeSo});
            this.dgvCongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongThuc.Location = new System.Drawing.Point(3, 18);
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(790, 270);
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
            // 
            // clmIDNganh
            // 
            this.clmIDNganh.DataPropertyName = "IDNganh";
            this.clmIDNganh.HeaderText = "Ma chuyên ngành";
            this.clmIDNganh.Name = "clmIDNganh";
            this.clmIDNganh.ReadOnly = true;
            // 
            // clmMaKhoi
            // 
            this.clmMaKhoi.DataPropertyName = "MaKhoi";
            this.clmMaKhoi.HeaderText = "Mã Khối";
            this.clmMaKhoi.Name = "clmMaKhoi";
            this.clmMaKhoi.ReadOnly = true;
            this.clmMaKhoi.Width = 150;
            // 
            // clmMaMon
            // 
            this.clmMaMon.DataPropertyName = "MaMon";
            this.clmMaMon.HeaderText = "Mã môn";
            this.clmMaMon.Name = "clmMaMon";
            this.clmMaMon.ReadOnly = true;
            this.clmMaMon.Width = 150;
            // 
            // clmHeSo
            // 
            this.clmHeSo.DataPropertyName = "HeSo";
            this.clmHeSo.HeaderText = "Hệ số";
            this.clmHeSo.Name = "clmHeSo";
            this.clmHeSo.ReadOnly = true;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.btnTinhDiemTB);
            this.grpDetailInfo.Controls.Add(this.cmbHeXetTuyen);
            this.grpDetailInfo.Controls.Add(this.label5);
            this.grpDetailInfo.Controls.Add(this.txtHeSo);
            this.grpDetailInfo.Controls.Add(this.label4);
            this.grpDetailInfo.Controls.Add(this.cmbMaMon);
            this.grpDetailInfo.Controls.Add(this.lblMon);
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
            this.grpDetailInfo.Size = new System.Drawing.Size(796, 120);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // btnTinhDiemTB
            // 
            this.btnTinhDiemTB.Location = new System.Drawing.Point(642, 89);
            this.btnTinhDiemTB.Name = "btnTinhDiemTB";
            this.btnTinhDiemTB.Size = new System.Drawing.Size(142, 28);
            this.btnTinhDiemTB.TabIndex = 16;
            this.btnTinhDiemTB.Text = "Tính điểm trung bình";
            this.btnTinhDiemTB.UseVisualStyleBackColor = true;
            this.btnTinhDiemTB.Click += new System.EventHandler(this.btnTinhDiemTB_Click);
            // 
            // cmbHeXetTuyen
            // 
            this.cmbHeXetTuyen.FormattingEnabled = true;
            this.cmbHeXetTuyen.Location = new System.Drawing.Point(310, 23);
            this.cmbHeXetTuyen.Name = "cmbHeXetTuyen";
            this.cmbHeXetTuyen.Size = new System.Drawing.Size(110, 24);
            this.cmbHeXetTuyen.TabIndex = 15;
            this.cmbHeXetTuyen.SelectedValueChanged += new System.EventHandler(this.cmbHeXetTuyen_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hệ";
            // 
            // txtHeSo
            // 
            this.txtHeSo.Location = new System.Drawing.Point(76, 88);
            this.txtHeSo.Name = "txtHeSo";
            this.txtHeSo.Size = new System.Drawing.Size(100, 22);
            this.txtHeSo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hệ số";
            // 
            // cmbMaMon
            // 
            this.cmbMaMon.FormattingEnabled = true;
            this.cmbMaMon.Location = new System.Drawing.Point(642, 60);
            this.cmbMaMon.Name = "cmbMaMon";
            this.cmbMaMon.Size = new System.Drawing.Size(145, 24);
            this.cmbMaMon.TabIndex = 11;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(602, 65);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(34, 16);
            this.lblMon.TabIndex = 10;
            this.lblMon.Text = "Môn";
            // 
            // cmbMaKhoi
            // 
            this.cmbMaKhoi.FormattingEnabled = true;
            this.cmbMaKhoi.Location = new System.Drawing.Point(642, 25);
            this.cmbMaKhoi.Name = "cmbMaKhoi";
            this.cmbMaKhoi.Size = new System.Drawing.Size(99, 24);
            this.cmbMaKhoi.TabIndex = 9;
            this.cmbMaKhoi.SelectedValueChanged += new System.EventHandler(this.cmbMaKhoi_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khối";
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(310, 88);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(269, 24);
            this.cmbNganh.TabIndex = 7;
            this.cmbNganh.SelectedValueChanged += new System.EventHandler(this.cmbNganh_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngành";
            // 
            // cmbNhomNganh
            // 
            this.cmbNhomNganh.FormattingEnabled = true;
            this.cmbNhomNganh.Location = new System.Drawing.Point(310, 53);
            this.cmbNhomNganh.Name = "cmbNhomNganh";
            this.cmbNhomNganh.Size = new System.Drawing.Size(242, 24);
            this.cmbNhomNganh.TabIndex = 5;
            this.cmbNhomNganh.SelectedValueChanged += new System.EventHandler(this.cmbNhomNganh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 60);
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
            this.cmbMaDot.Size = new System.Drawing.Size(138, 24);
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
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            // 
            // frmCongThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(796, 477);
            this.Name = "frmCongThuc";
            this.Text = "Hệ số công thức xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCongThuc_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDNganh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaKhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHeSo;
        private System.Windows.Forms.ComboBox cmbMaDot;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.ComboBox cmbNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNhomNganh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaMon;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cmbMaKhoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeSo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHeXetTuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTinhDiemTB;
        private System.ComponentModel.BackgroundWorker bw;
    }
}
