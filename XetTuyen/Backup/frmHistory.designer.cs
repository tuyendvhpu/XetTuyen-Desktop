namespace XetTuyen
{
    partial class frmHistory
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
            this.dgvAudid = new System.Windows.Forms.DataGridView();
            this.clmTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRow_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChanged_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChanged_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOld_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNew_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cmbThaoTac = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNguoiSua = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgaySua = new System.Windows.Forms.DateTimePicker();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.txtTenBang = new System.Windows.Forms.TextBox();
            this.lblMaDot = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudid)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1020, 32);
            this.lblTitle.Text = "LỊCH SỬ THAO TÁC CƠ SỞ DỮ LIỆU";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(1020, 411);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.CancelVisible = false;
            this.ucDataButton1.EditVisible = false;
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 443);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.SaveVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(1020, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvAudid);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 65);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(1020, 346);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvAudid
            // 
            this.dgvAudid.AllowUserToAddRows = false;
            this.dgvAudid.AllowUserToDeleteRows = false;
            this.dgvAudid.AllowUserToResizeRows = false;
            this.dgvAudid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTableName,
            this.clmColumnName,
            this.clmRow_ID,
            this.clmChanged_Date,
            this.clmChanged_By,
            this.clmOld_Value,
            this.clmNew_Value,
            this.clmAction});
            this.dgvAudid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAudid.Location = new System.Drawing.Point(3, 18);
            this.dgvAudid.Name = "dgvAudid";
            this.dgvAudid.ReadOnly = true;
            this.dgvAudid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudid.Size = new System.Drawing.Size(1014, 325);
            this.dgvAudid.TabIndex = 0;
            this.dgvAudid.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // clmTableName
            // 
            this.clmTableName.DataPropertyName = "TableName";
            this.clmTableName.HeaderText = "Tên bảng";
            this.clmTableName.Name = "clmTableName";
            this.clmTableName.ReadOnly = true;
            // 
            // clmColumnName
            // 
            this.clmColumnName.DataPropertyName = "ColumnName";
            this.clmColumnName.HeaderText = "Tên cột";
            this.clmColumnName.Name = "clmColumnName";
            this.clmColumnName.ReadOnly = true;
            this.clmColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmColumnName.Width = 130;
            // 
            // clmRow_ID
            // 
            this.clmRow_ID.DataPropertyName = "Row_ID";
            this.clmRow_ID.HeaderText = "Row_ID";
            this.clmRow_ID.Name = "clmRow_ID";
            this.clmRow_ID.ReadOnly = true;
            this.clmRow_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmChanged_Date
            // 
            this.clmChanged_Date.DataPropertyName = "Changed_Date";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = "null";
            this.clmChanged_Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmChanged_Date.HeaderText = "Ngày sửa";
            this.clmChanged_Date.Name = "clmChanged_Date";
            this.clmChanged_Date.ReadOnly = true;
            // 
            // clmChanged_By
            // 
            this.clmChanged_By.DataPropertyName = "Changed_By";
            this.clmChanged_By.HeaderText = "Người sửa";
            this.clmChanged_By.Name = "clmChanged_By";
            this.clmChanged_By.ReadOnly = true;
            // 
            // clmOld_Value
            // 
            this.clmOld_Value.DataPropertyName = "Old_Value";
            this.clmOld_Value.HeaderText = "Dữ liệu cũ";
            this.clmOld_Value.Name = "clmOld_Value";
            this.clmOld_Value.ReadOnly = true;
            this.clmOld_Value.Width = 190;
            // 
            // clmNew_Value
            // 
            this.clmNew_Value.DataPropertyName = "New_Value";
            this.clmNew_Value.HeaderText = "Dữ liệu mới";
            this.clmNew_Value.Name = "clmNew_Value";
            this.clmNew_Value.ReadOnly = true;
            this.clmNew_Value.Width = 190;
            // 
            // clmAction
            // 
            this.clmAction.DataPropertyName = "Action";
            this.clmAction.HeaderText = "Thao tác";
            this.clmAction.Name = "clmAction";
            this.clmAction.ReadOnly = true;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.btnAll);
            this.grpDetailInfo.Controls.Add(this.btnTim);
            this.grpDetailInfo.Controls.Add(this.cmbThaoTac);
            this.grpDetailInfo.Controls.Add(this.label2);
            this.grpDetailInfo.Controls.Add(this.txtNguoiSua);
            this.grpDetailInfo.Controls.Add(this.label1);
            this.grpDetailInfo.Controls.Add(this.dtpNgaySua);
            this.grpDetailInfo.Controls.Add(this.lblDateStart);
            this.grpDetailInfo.Controls.Add(this.txtTenBang);
            this.grpDetailInfo.Controls.Add(this.lblMaDot);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(1020, 65);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(830, 30);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 29);
            this.btnTim.TabIndex = 18;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // cmbThaoTac
            // 
            this.cmbThaoTac.FormattingEnabled = true;
            this.cmbThaoTac.Location = new System.Drawing.Point(703, 31);
            this.cmbThaoTac.Name = "cmbThaoTac";
            this.cmbThaoTac.Size = new System.Drawing.Size(121, 24);
            this.cmbThaoTac.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Thao tác";
            // 
            // txtNguoiSua
            // 
            this.txtNguoiSua.Location = new System.Drawing.Point(318, 32);
            this.txtNguoiSua.Name = "txtNguoiSua";
            this.txtNguoiSua.Size = new System.Drawing.Size(128, 22);
            this.txtNguoiSua.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Người sửa";
            // 
            // dtpNgaySua
            // 
            this.dtpNgaySua.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySua.Location = new System.Drawing.Point(539, 31);
            this.dtpNgaySua.Name = "dtpNgaySua";
            this.dtpNgaySua.ShowUpDown = true;
            this.dtpNgaySua.Size = new System.Drawing.Size(91, 22);
            this.dtpNgaySua.TabIndex = 12;
            // 
            // lblDateStart
            // 
            this.lblDateStart.Location = new System.Drawing.Point(464, 34);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(69, 19);
            this.lblDateStart.TabIndex = 13;
            this.lblDateStart.Text = "Ngày sửa";
            this.lblDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenBang
            // 
            this.txtTenBang.Location = new System.Drawing.Point(85, 30);
            this.txtTenBang.Name = "txtTenBang";
            this.txtTenBang.Size = new System.Drawing.Size(146, 22);
            this.txtTenBang.TabIndex = 2;
            // 
            // lblMaDot
            // 
            this.lblMaDot.AutoSize = true;
            this.lblMaDot.Location = new System.Drawing.Point(17, 33);
            this.lblMaDot.Name = "lblMaDot";
            this.lblMaDot.Size = new System.Drawing.Size(66, 16);
            this.lblMaDot.TabIndex = 0;
            this.lblMaDot.Text = "Tên bảng";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(911, 31);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 29);
            this.btnAll.TabIndex = 19;
            this.btnAll.Text = "Hiện hết";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1020, 477);
            this.Name = "frmHistory";
            this.Text = "Danh mục đợt xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudid)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvAudid;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblMaDot;
        private System.Windows.Forms.TextBox txtTenBang;
        private System.Windows.Forms.DateTimePicker dtpNgaySua;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.TextBox txtNguoiSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbThaoTac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRow_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChanged_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChanged_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOld_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNew_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAction;
        private System.Windows.Forms.Button btnAll;
    }
}
