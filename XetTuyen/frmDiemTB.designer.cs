namespace XetTuyen
{
    partial class frmDiemTB
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
            this.grpDetailInfo = new System.Windows.Forms.GroupBox();
            this.btnTinhDiemTB = new System.Windows.Forms.Button();
            this.cmbHeXetTuyen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.grpDetailInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(586, 32);
            this.lblTitle.Text = "Tính điểm trung bình";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpDetailInfo);
            this.pnlMain.Size = new System.Drawing.Size(586, 147);
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = false;
            this.ucDataButton1.CancelVisible = false;
            this.ucDataButton1.DeleteVisible = false;
            this.ucDataButton1.EditVisible = false;
            this.ucDataButton1.ExcelVisible = false;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 179);
            this.ucDataButton1.MultiLanguageVisible = false;
            this.ucDataButton1.PrintVisible = false;
            this.ucDataButton1.ReportVisible = false;
            this.ucDataButton1.SaveVisible = false;
            this.ucDataButton1.Size = new System.Drawing.Size(586, 34);
            this.ucDataButton1.CloseHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CloseHandler);
            this.ucDataButton1.CancelHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_CancelHandler);
            this.ucDataButton1.SaveHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_SaveHandler);
            this.ucDataButton1.DeleteHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_DeleteHandler);
            this.ucDataButton1.InsertHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_InsertHandler);
            this.ucDataButton1.EditHandler += new XetTuyen.ucDataButton.DataHandler(this.ucDataButton1_EditHandler);
            // 
            // grpDetailInfo
            // 
            this.grpDetailInfo.Controls.Add(this.btnTinhDiemTB);
            this.grpDetailInfo.Controls.Add(this.cmbHeXetTuyen);
            this.grpDetailInfo.Controls.Add(this.label5);
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
            this.grpDetailInfo.Size = new System.Drawing.Size(586, 138);
            this.grpDetailInfo.TabIndex = 2;
            this.grpDetailInfo.TabStop = false;
            this.grpDetailInfo.Text = "Thông tin chi tiết";
            // 
            // btnTinhDiemTB
            // 
            this.btnTinhDiemTB.Location = new System.Drawing.Point(310, 92);
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
            this.cmbHeXetTuyen.Location = new System.Drawing.Point(77, 85);
            this.cmbHeXetTuyen.Name = "cmbHeXetTuyen";
            this.cmbHeXetTuyen.Size = new System.Drawing.Size(110, 24);
            this.cmbHeXetTuyen.TabIndex = 15;
            this.cmbHeXetTuyen.SelectedValueChanged += new System.EventHandler(this.cmbHeXetTuyen_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hệ";
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(310, 62);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(269, 24);
            this.cmbNganh.TabIndex = 7;
            this.cmbNganh.SelectedValueChanged += new System.EventHandler(this.cmbNganh_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngành";
            // 
            // cmbNhomNganh
            // 
            this.cmbNhomNganh.FormattingEnabled = true;
            this.cmbNhomNganh.Location = new System.Drawing.Point(310, 29);
            this.cmbNhomNganh.Name = "cmbNhomNganh";
            this.cmbNhomNganh.Size = new System.Drawing.Size(242, 24);
            this.cmbNhomNganh.TabIndex = 5;
            this.cmbNhomNganh.SelectedValueChanged += new System.EventHandler(this.cmbNhomNganh_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 37);
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
            // frmDiemTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(586, 213);
            this.Name = "frmDiemTB";
            this.Text = "Hệ số công thức xét tuyển";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.Shown += new System.EventHandler(this.frmGroup_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDiemTB_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.grpDetailInfo.ResumeLayout(false);
            this.grpDetailInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDetailInfo;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblMaDot;
        private System.Windows.Forms.ComboBox cmbMaDot;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.ComboBox cmbNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNhomNganh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHeXetTuyen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTinhDiemTB;
        private System.ComponentModel.BackgroundWorker bw;
    }
}
