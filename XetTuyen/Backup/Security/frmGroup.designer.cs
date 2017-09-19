namespace XetTuyen
{
    partial class frmGroup
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
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.clmGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(831, 32);
            this.lblTitle.Text = "Quản Lý Nhóm Người Dùng";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(831, 435);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(831, 34);
            this.ucDataButton1.CancelHandler += new ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.CloseHandler += new ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.InsertHandler += new ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.dgvGroup);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Location = new System.Drawing.Point(0, 99);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(831, 336);
            this.grpList.TabIndex = 3;
            this.grpList.TabStop = false;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmGroupID,
            this.clmGroupName,
            this.clmNote,
            this.clmIsAdmin});
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(3, 18);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(825, 315);
            this.dgvGroup.TabIndex = 0;
            this.dgvGroup.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // clmGroupID
            // 
            this.clmGroupID.DataPropertyName = "GroupID";
            this.clmGroupID.HeaderText = "Group ID";
            this.clmGroupID.Name = "clmGroupID";
            this.clmGroupID.ReadOnly = true;
            this.clmGroupID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmGroupID.Visible = false;
            // 
            // clmGroupName
            // 
            this.clmGroupName.DataPropertyName = "GroupName";
            this.clmGroupName.HeaderText = "Tên nhóm";
            this.clmGroupName.Name = "clmGroupName";
            this.clmGroupName.ReadOnly = true;
            this.clmGroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmGroupName.Width = 300;
            // 
            // clmNote
            // 
            this.clmNote.DataPropertyName = "Note";
            this.clmNote.HeaderText = "Ghi chú";
            this.clmNote.Name = "clmNote";
            this.clmNote.ReadOnly = true;
            this.clmNote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmNote.Width = 280;
            // 
            // clmIsAdmin
            // 
            this.clmIsAdmin.DataPropertyName = "IsAdmin";
            this.clmIsAdmin.HeaderText = "Nhóm quản trị";
            this.clmIsAdmin.Name = "clmIsAdmin";
            this.clmIsAdmin.ReadOnly = true;
            this.clmIsAdmin.Width = 110;
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.txtNote);
            this.grpDetailInfo.Controls.Add(this.txtGroupName);
            this.grpDetailInfo.Controls.Add(this.lblNote);
            this.grpDetailInfo.Controls.Add(this.lblGroupName);
            this.grpDetailInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.grpDetailInfo.Name = "grpDetailInfo";
            this.grpDetailInfo.Size = new System.Drawing.Size(831, 99);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(193, 62);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(521, 22);
            this.txtNote.TabIndex = 3;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(193, 33);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(521, 22);
            this.txtGroupName.TabIndex = 2;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(115, 62);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(52, 16);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Ghi chú";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(30, 33);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(137, 16);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Tên nhóm người dùng";
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(831, 501);
            this.Name = "frmGroup";
            this.Text = "Danh Muc Nhom Nguoi Dung";
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNote;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsAdmin;
    }
}
