namespace XetTuyen
{
    partial class ucDataButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDataButton));
            this.actionList1 = new CDiese.Actions.ActionList(this.components);
            this.acAdd = new CDiese.Actions.Action(this.components);
            this.acEdit = new CDiese.Actions.Action(this.components);
            this.acDelete = new CDiese.Actions.Action(this.components);
            this.acSave = new CDiese.Actions.Action(this.components);
            this.acCancel = new CDiese.Actions.Action(this.components);
            this.acClose = new CDiese.Actions.Action(this.components);
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdLanguage = new System.Windows.Forms.Button();
            this.cmdExcel = new System.Windows.Forms.Button();
            this.cmdReport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionList1
            // 
            this.actionList1.Actions.AddRange(new CDiese.Actions.Action[] {
            this.acAdd,
            this.acEdit,
            this.acDelete,
            this.acSave,
            this.acCancel,
            this.acClose});
            this.actionList1.ImageList = null;
            this.actionList1.ShowTextOnToolBar = false;
            this.actionList1.Tag = null;
            // 
            // acAdd
            // 
            this.acAdd.Checked = false;
            this.acAdd.Enabled = true;
            this.acAdd.Hint = null;
            this.acAdd.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acAdd.Tag = null;
            this.acAdd.Text = "&Thêm";
            this.acAdd.Visible = true;
            this.acAdd.Execute += new System.EventHandler(this.acInsert_Execute);
            this.acAdd.Update += new System.EventHandler(this.acInsert_Update);
            // 
            // acEdit
            // 
            this.acEdit.Checked = false;
            this.acEdit.Enabled = true;
            this.acEdit.Hint = null;
            this.acEdit.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acEdit.Tag = null;
            this.acEdit.Text = "&Sửa";
            this.acEdit.Visible = true;
            this.acEdit.Execute += new System.EventHandler(this.acEdit_Execute);
            this.acEdit.Update += new System.EventHandler(this.acEdit_Update);
            // 
            // acDelete
            // 
            this.acDelete.Checked = false;
            this.acDelete.Enabled = true;
            this.acDelete.Hint = null;
            this.acDelete.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acDelete.Tag = null;
            this.acDelete.Text = "&Xóa";
            this.acDelete.Visible = true;
            this.acDelete.Execute += new System.EventHandler(this.acDelete_Execute);
            this.acDelete.Update += new System.EventHandler(this.acDelete_Update);
            // 
            // acSave
            // 
            this.acSave.Checked = false;
            this.acSave.Enabled = true;
            this.acSave.Hint = null;
            this.acSave.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acSave.Tag = null;
            this.acSave.Text = "&Lưu";
            this.acSave.Visible = true;
            this.acSave.Execute += new System.EventHandler(this.acSave_Execute);
            this.acSave.Update += new System.EventHandler(this.acSave_Update);
            // 
            // acCancel
            // 
            this.acCancel.Checked = false;
            this.acCancel.Enabled = true;
            this.acCancel.Hint = null;
            this.acCancel.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acCancel.Tag = null;
            this.acCancel.Text = "&Bỏ qua";
            this.acCancel.Visible = true;
            this.acCancel.Execute += new System.EventHandler(this.acCancel_Execute);
            this.acCancel.Update += new System.EventHandler(this.acCancel_Update);
            // 
            // acClose
            // 
            this.acClose.Checked = false;
            this.acClose.Enabled = true;
            this.acClose.Hint = null;
            this.acClose.Shortcut = System.Windows.Forms.Shortcut.None;
            this.acClose.Tag = null;
            this.acClose.Text = "Đó&ng";
            this.acClose.Visible = true;
            this.acClose.Execute += new System.EventHandler(this.acClose_Execute);
            // 
            // cmdClose
            // 
            this.actionList1.SetAction(this.cmdClose, this.acClose);
            this.cmdClose.Image = global::XetTuyen.Properties.Resources.img_shutDown;
            this.cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.Location = new System.Drawing.Point(399, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdClose.Size = new System.Drawing.Size(62, 28);
            this.cmdClose.TabIndex = 6;
            this.cmdClose.Text = "Đó&ng";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.actionList1.SetAction(this.cmdCancel, this.acCancel);
            this.cmdCancel.Image = global::XetTuyen.Properties.Resources.Cancel;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(321, 3);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 28);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "&Bỏ qua";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.actionList1.SetAction(this.cmdDelete, this.acDelete);
            this.cmdDelete.Image = global::XetTuyen.Properties.Resources.delete16161;
            this.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDelete.Location = new System.Drawing.Point(165, 3);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(72, 28);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "&Xóa";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // cmdEdit
            // 
            this.actionList1.SetAction(this.cmdEdit, this.acEdit);
            this.cmdEdit.Image = global::XetTuyen.Properties.Resources.Edit;
            this.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEdit.Location = new System.Drawing.Point(87, 3);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(72, 28);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = "&Sửa";
            this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEdit.UseVisualStyleBackColor = true;
            // 
            // cmdAdd
            // 
            this.actionList1.SetAction(this.cmdAdd, this.acAdd);
            this.cmdAdd.Image = global::XetTuyen.Properties.Resources.add;
            this.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAdd.Location = new System.Drawing.Point(9, 3);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(72, 28);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "&Thêm";
            this.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmdLanguage);
            this.flowLayoutPanel1.Controls.Add(this.cmdExcel);
            this.flowLayoutPanel1.Controls.Add(this.cmdReport);
            this.flowLayoutPanel1.Controls.Add(this.cmdPrint);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 34);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Image = global::XetTuyen.Properties.Resources.Printer;
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.Location = new System.Drawing.Point(257, 3);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(71, 28);
            this.cmdPrint.TabIndex = 3;
            this.cmdPrint.Text = "In";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmdClose);
            this.flowLayoutPanel2.Controls.Add(this.cmdCancel);
            this.flowLayoutPanel2.Controls.Add(this.cmdSave);
            this.flowLayoutPanel2.Controls.Add(this.cmdDelete);
            this.flowLayoutPanel2.Controls.Add(this.cmdEdit);
            this.flowLayoutPanel2.Controls.Add(this.cmdAdd);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(349, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(464, 34);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // cmdSave
            // 
            this.actionList1.SetAction(this.cmdSave, this.acSave);
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(243, 3);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(72, 28);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "&Lưu";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // cmdLanguage
            // 
            this.cmdLanguage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdLanguage.Image = ((System.Drawing.Image)(resources.GetObject("cmdLanguage.Image")));
            this.cmdLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLanguage.Location = new System.Drawing.Point(3, 3);
            this.cmdLanguage.Name = "cmdLanguage";
            this.cmdLanguage.Size = new System.Drawing.Size(75, 28);
            this.cmdLanguage.TabIndex = 0;
            this.cmdLanguage.Text = "Ngôn ngữ";
            this.cmdLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLanguage.UseVisualStyleBackColor = true;
            this.cmdLanguage.Click += new System.EventHandler(this.cmdLanguage_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Image = global::XetTuyen.Properties.Resources.Excel;
            this.cmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExcel.Location = new System.Drawing.Point(84, 3);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(75, 28);
            this.cmdExcel.TabIndex = 1;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExcel.UseVisualStyleBackColor = true;
            this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
            // 
            // cmdReport
            // 
            this.cmdReport.Image = global::XetTuyen.Properties.Resources.Statistics_icon;
            this.cmdReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdReport.Location = new System.Drawing.Point(165, 3);
            this.cmdReport.Name = "cmdReport";
            this.cmdReport.Size = new System.Drawing.Size(86, 28);
            this.cmdReport.TabIndex = 2;
            this.cmdReport.Text = "Báo cáo";
            this.cmdReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdReport.UseVisualStyleBackColor = true;
            this.cmdReport.Click += new System.EventHandler(this.cmdReport_Click);
            // 
            // ucDataButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(0, 34);
            this.MinimumSize = new System.Drawing.Size(500, 34);
            this.Name = "ucDataButton";
            this.Size = new System.Drawing.Size(813, 34);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CDiese.Actions.ActionList actionList1;
        private CDiese.Actions.Action acAdd;
        private CDiese.Actions.Action acEdit;
        private CDiese.Actions.Action acDelete;
        private CDiese.Actions.Action acSave;
        private CDiese.Actions.Action acCancel;
        private CDiese.Actions.Action acClose;
        public System.Windows.Forms.Button cmdPrint;
        public System.Windows.Forms.Button cmdReport;
        public System.Windows.Forms.Button cmdExcel;
        public System.Windows.Forms.Button cmdLanguage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button cmdAdd;
        public System.Windows.Forms.Button cmdEdit;
        public System.Windows.Forms.Button cmdDelete;
        public System.Windows.Forms.Button cmdSave;
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
