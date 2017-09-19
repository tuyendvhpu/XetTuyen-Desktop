namespace XetTuyen
{
    partial class frmTTXetTuyen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtHeSo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.clmSoQD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLoginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(796, 32);
            this.lblTitle.Text = "Danh mục thông tin xét tuyển";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(796, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.CancelVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.EditVisible = false;
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.SaveVisible = false;
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
            this.grpList.Location = new System.Drawing.Point(0, 43);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(796, 368);
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
            this.clmSoQD,
            this.clmStatus,
            this.clmLoginID,
            this.clmDateCreate});
            this.dgvCongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongThuc.Location = new System.Drawing.Point(3, 18);
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(790, 347);
            this.dgvCongThuc.TabIndex = 0;
            this.dgvCongThuc.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.btnTimKiem);
            this.grpDetailInfo.Controls.Add(this.txtHeSo);
            this.grpDetailInfo.Controls.Add(this.label4);
            this.grpDetailInfo.Controls.Add(this.cmbTrangThai);
            this.grpDetailInfo.Controls.Add(this.lblMon);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(796, 43);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(505, 15);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(142, 28);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtHeSo
            // 
            this.txtHeSo.Location = new System.Drawing.Point(62, 18);
            this.txtHeSo.Name = "txtHeSo";
            this.txtHeSo.Size = new System.Drawing.Size(215, 22);
            this.txtHeSo.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Số QĐ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new System.Drawing.Point(354, 16);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(145, 24);
            this.cmbTrangThai.TabIndex = 11;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(280, 19);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(68, 16);
            this.lblMon.TabIndex = 10;
            this.lblMon.Text = "Trạng thái";
            // 
            // clmSoQD
            // 
            this.clmSoQD.DataPropertyName = "SoQD";
            this.clmSoQD.HeaderText = "Số QĐ";
            this.clmSoQD.Name = "clmSoQD";
            this.clmSoQD.ReadOnly = true;
            this.clmSoQD.Width = 150;
            // 
            // clmStatus
            // 
            this.clmStatus.DataPropertyName = "Status";
            this.clmStatus.HeaderText = "Trạng thái";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 150;
            // 
            // clmLoginID
            // 
            this.clmLoginID.DataPropertyName = "LoginID";
            this.clmLoginID.HeaderText = "Người tạo";
            this.clmLoginID.Name = "clmLoginID";
            this.clmLoginID.ReadOnly = true;
            // 
            // clmDateCreate
            // 
            this.clmDateCreate.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.clmDateCreate.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmDateCreate.HeaderText = "Ngày tạo";
            this.clmDateCreate.Name = "clmDateCreate";
            this.clmDateCreate.ReadOnly = true;
            // 
            // frmTTXetTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(796, 477);
            this.Name = "frmTTXetTuyen";
            this.Text = "Thông tin xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
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
        private System.Windows.Forms.TextBox txtHeSo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoQD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLoginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDateCreate;
    }
}
