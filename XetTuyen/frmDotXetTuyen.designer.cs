namespace XetTuyen
{
    partial class frmDotXetTuyen
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
            this.dgvDotXetTuyen = new System.Windows.Forms.DataGridView();
            this.clmMaDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgayBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgaKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.txtTenDot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtMaDot = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.lblMaDot = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDotXetTuyen)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(656, 32);
            this.lblTitle.Text = "Quản lý đợt xét tuyển";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(656, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(656, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvDotXetTuyen);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 99);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(656, 312);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvDotXetTuyen
            // 
            this.dgvDotXetTuyen.AllowUserToAddRows = false;
            this.dgvDotXetTuyen.AllowUserToDeleteRows = false;
            this.dgvDotXetTuyen.AllowUserToResizeRows = false;
            this.dgvDotXetTuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDotXetTuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaDot,
            this.clmTenDot,
            this.clmNam,
            this.clmNgayBD,
            this.clmNgaKT});
            this.dgvDotXetTuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDotXetTuyen.Location = new System.Drawing.Point(3, 18);
            this.dgvDotXetTuyen.Name = "dgvDotXetTuyen";
            this.dgvDotXetTuyen.ReadOnly = true;
            this.dgvDotXetTuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDotXetTuyen.Size = new System.Drawing.Size(650, 291);
            this.dgvDotXetTuyen.TabIndex = 0;
            this.dgvDotXetTuyen.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // clmMaDot
            // 
            this.clmMaDot.DataPropertyName = "MaDot";
            this.clmMaDot.HeaderText = "Mã đợt";
            this.clmMaDot.Name = "clmMaDot";
            this.clmMaDot.ReadOnly = true;
            this.clmMaDot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmTenDot
            // 
            this.clmTenDot.DataPropertyName = "TenDot";
            this.clmTenDot.HeaderText = "Tên đợt";
            this.clmTenDot.Name = "clmTenDot";
            this.clmTenDot.ReadOnly = true;
            this.clmTenDot.Width = 150;
            // 
            // clmNam
            // 
            this.clmNam.DataPropertyName = "Nam";
            this.clmNam.HeaderText = "Năm";
            this.clmNam.Name = "clmNam";
            this.clmNam.ReadOnly = true;
            this.clmNam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmNgayBD
            // 
            this.clmNgayBD.DataPropertyName = "NgayBD";
            this.clmNgayBD.HeaderText = "Ngày bắt đầu";
            this.clmNgayBD.Name = "clmNgayBD";
            this.clmNgayBD.ReadOnly = true;
            this.clmNgayBD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmNgayBD.Width = 150;
            // 
            // clmNgaKT
            // 
            this.clmNgaKT.DataPropertyName = "NgayKT";
            this.clmNgaKT.HeaderText = "Ngày kết thúc";
            this.clmNgaKT.Name = "clmNgaKT";
            this.clmNgaKT.ReadOnly = true;
            this.clmNgaKT.Width = 150;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.txtTenDot);
            this.grpDetailInfo.Controls.Add(this.label1);
            this.grpDetailInfo.Controls.Add(this.dtpEnd);
            this.grpDetailInfo.Controls.Add(this.lblDateEnd);
            this.grpDetailInfo.Controls.Add(this.dtpStart);
            this.grpDetailInfo.Controls.Add(this.lblDateStart);
            this.grpDetailInfo.Controls.Add(this.txtNam);
            this.grpDetailInfo.Controls.Add(this.txtMaDot);
            this.grpDetailInfo.Controls.Add(this.lblNam);
            this.grpDetailInfo.Controls.Add(this.lblMaDot);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(656, 99);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // txtTenDot
            // 
            this.txtTenDot.Location = new System.Drawing.Point(86, 64);
            this.txtTenDot.Name = "txtTenDot";
            this.txtTenDot.Size = new System.Drawing.Size(286, 22);
            this.txtTenDot.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên đợt";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(515, 62);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(118, 22);
            this.dtpEnd.TabIndex = 14;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.Location = new System.Drawing.Point(405, 67);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(104, 17);
            this.lblDateEnd.TabIndex = 15;
            this.lblDateEnd.Text = "Ngày kết thúc";
            this.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(515, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(118, 22);
            this.dtpStart.TabIndex = 12;
            // 
            // lblDateStart
            // 
            this.lblDateStart.Location = new System.Drawing.Point(402, 32);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(107, 17);
            this.lblDateStart.TabIndex = 13;
            this.lblDateStart.Text = "Ngày bắt đầu";
            this.lblDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(298, 30);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(73, 22);
            this.txtNam.TabIndex = 3;
            // 
            // txtMaDot
            // 
            this.txtMaDot.Location = new System.Drawing.Point(85, 30);
            this.txtMaDot.Name = "txtMaDot";
            this.txtMaDot.Size = new System.Drawing.Size(150, 22);
            this.txtMaDot.TabIndex = 2;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(243, 33);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(37, 16);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Năm";
            // 
            // lblMaDot
            // 
            this.lblMaDot.AutoSize = true;
            this.lblMaDot.Location = new System.Drawing.Point(30, 33);
            this.lblMaDot.Name = "lblMaDot";
            this.lblMaDot.Size = new System.Drawing.Size(49, 16);
            this.lblMaDot.TabIndex = 0;
            this.lblMaDot.Text = "Mã đợt";
            // 
            // frmDotXetTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(656, 477);
            this.Name = "frmDotXetTuyen";
            this.Text = "Danh mục đợt xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDotXetTuyen)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvDotXetTuyen;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblMaDot;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtMaDot;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgayBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgaKT;
        private System.Windows.Forms.TextBox txtTenDot;
        private System.Windows.Forms.Label label1;
    }
}
