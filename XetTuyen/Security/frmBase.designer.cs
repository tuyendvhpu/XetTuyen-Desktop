namespace XetTuyen
{
    partial class frmBase
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ucDataButton1 = new XetTuyen.ucDataButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Lavender;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(895, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucDataButton1
            // 
            this.ucDataButton1.AddNewVisible = true;
            this.ucDataButton1.CancelVisible = true;
            this.ucDataButton1.DataMode = Common.DataState.View;
            this.ucDataButton1.DeleteVisible = true;
            this.ucDataButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDataButton1.EditVisible = true;
            this.ucDataButton1.ExcelVisible = true;
            this.ucDataButton1.IsContitnue = true;
            this.ucDataButton1.Location = new System.Drawing.Point(0, 467);
            this.ucDataButton1.MaximumSize = new System.Drawing.Size(0, 34);
            this.ucDataButton1.MinimumSize = new System.Drawing.Size(500, 34);
            this.ucDataButton1.Name = "ucDataButton1";
            this.ucDataButton1.PrintVisible = true;
            this.ucDataButton1.ReportVisible = true;
            this.ucDataButton1.SaveVisible = true;
            this.ucDataButton1.Size = new System.Drawing.Size(895, 34);
            this.ucDataButton1.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 32);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(895, 435);
            this.pnlMain.TabIndex = 8;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 501);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ucDataButton1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmBase";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnlMain;
        public XetTuyen.ucDataButton  ucDataButton1;
    }
}