using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XetTuyen
{
	/// <summary>
	/// Summary description for frmConnecting.
	/// </summary>
	public class frmConnecting : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblWait;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmConnecting()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnecting));
            this.lblWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWait
            // 
            this.lblWait.Location = new System.Drawing.Point(72, 32);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(144, 16);
            this.lblWait.TabIndex = 3;
            this.lblWait.Text = "Đang kết nối cơ sở dữ liệu...";
            // 
            // frmConnecting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 77);
            this.Controls.Add(this.lblWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConnecting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối";
            this.ResumeLayout(false);

		}
		#endregion
	}
}
