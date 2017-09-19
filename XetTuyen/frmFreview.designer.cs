namespace XetTuyen
{
    partial class frmPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public static frmPreview _selt = null;
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
            _selt = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crpvPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // crpvPreview
            // 
            this.crpvPreview.ActiveViewIndex = -1;
            this.crpvPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpvPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpvPreview.Location = new System.Drawing.Point(0, 0);
            this.crpvPreview.Name = "crpvPreview";
            this.crpvPreview.SelectionFormula = "";
            this.crpvPreview.ShowGroupTreeButton = false;
            this.crpvPreview.ShowRefreshButton = false;
            this.crpvPreview.Size = new System.Drawing.Size(900, 446);
            this.crpvPreview.TabIndex = 0;
            this.crpvPreview.ViewTimeSelectionFormula = "";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(400, 250);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 446);
            this.Controls.Add(this.crpvPreview);
            this.Name = "frmPreview";
            this.Text = "Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpvPreview;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}