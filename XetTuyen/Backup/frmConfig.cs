using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DataAccess;
using Common;
using BusinessLogic;
using BusinessService;

namespace XetTuyen
{
	/// <summary>
	/// Summary description for frmConfig.
	/// </summary>
	public class frmConfig : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.LinkLabel llbHelp;
		internal System.Windows.Forms.Button btnDefault;
		internal System.Windows.Forms.Button btnConfirm;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.TextBox txtDBUser;
		internal System.Windows.Forms.TextBox txtDBName;
		internal System.Windows.Forms.TextBox txtDBServer;
		internal System.Windows.Forms.CheckBox chkTrusted;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmConfig()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.llbHelp = new System.Windows.Forms.LinkLabel();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.chkTrusted = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // llbHelp
            // 
            this.llbHelp.Location = new System.Drawing.Point(296, 24);
            this.llbHelp.Name = "llbHelp";
            this.llbHelp.Size = new System.Drawing.Size(88, 16);
            this.llbHelp.TabIndex = 10;
            this.llbHelp.TabStop = true;
            this.llbHelp.Text = "Trợ giúp";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(296, 56);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(88, 24);
            this.btnDefault.TabIndex = 9;
            this.btnDefault.Text = "&Mặc định";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(296, 104);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 24);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Đồ&ng ý";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtPassword);
            this.GroupBox1.Controls.Add(this.txtDBUser);
            this.GroupBox1.Controls.Add(this.txtDBName);
            this.GroupBox1.Controls.Add(this.txtDBServer);
            this.GroupBox1.Controls.Add(this.chkTrusted);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(16, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(264, 152);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Kết nối cơ sở dữ liệu";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 8;
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(88, 96);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(160, 20);
            this.txtDBUser.TabIndex = 7;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(88, 48);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(160, 20);
            this.txtDBName.TabIndex = 6;
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(88, 24);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(160, 20);
            this.txtDBServer.TabIndex = 5;
            // 
            // chkTrusted
            // 
            this.chkTrusted.Location = new System.Drawing.Point(88, 72);
            this.chkTrusted.Name = "chkTrusted";
            this.chkTrusted.Size = new System.Drawing.Size(144, 16);
            this.chkTrusted.TabIndex = 4;
            this.chkTrusted.Text = "Trusted connection";
            this.chkTrusted.CheckedChanged += new System.EventHandler(this.chkTrusted_CheckedChanged);
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(16, 120);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 16);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Password:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(16, 96);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 16);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "User:";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(16, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Database:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(16, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "SQL Server:";
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(296, 136);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(88, 24);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "Đóng";
            // 
            // frmConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(400, 173);
            this.Controls.Add(this.llbHelp);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmConfig_Load(object sender, System.EventArgs e)
		{
			if(!Utilities.loadConfig())
			{
				DialogResult rs;
				rs = MessageBox.Show("Không thể mở được file cấu hình. Bạn có muốn lấy cấu hình mặc định?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if( rs == DialogResult.Yes)
				{
						Utilities.createDefaultConfig();
				}
				else
					return;				
			}
			
        
            txtDBServer.Text = Utilities.acAppConfig .sDBServer;
            txtDBName.Text = Utilities.acAppConfig .sDBDatabase;
            chkTrusted.Checked = Utilities.acAppConfig .bDBTrustedConnection;
            txtDBUser.Text = Utilities.acAppConfig .sDBUserName;
            txtPassword.Text = Utilities.acAppConfig .sDBPassword;
        }

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
            Utilities.acAppConfig.sDBServer = txtDBServer.Text;
            Utilities.acAppConfig.sDBDatabase = txtDBName.Text;
            Utilities.acAppConfig.bDBTrustedConnection = chkTrusted.Checked;
            Utilities.acAppConfig.sDBUserName = txtDBUser.Text;
            Utilities.acAppConfig.sDBPassword = txtPassword.Text;
          //  Utilities.loadConfig();
			Utilities.saveConfig(Utilities.acAppConfig);
           
		}

		private void chkTrusted_CheckedChanged(object sender, System.EventArgs e)
		{
			txtDBUser.Enabled = !chkTrusted.Checked;
			txtPassword.Enabled = !chkTrusted.Checked;
		}

		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			DialogResult rs;
			rs = MessageBox.Show("Bạn chắc chắn muốn lấy cấu hình mặc định?","Thông báo", MessageBoxButtons.YesNo ,MessageBoxIcon.Question);
			if(	rs == DialogResult.Yes)
			{
				Utilities.createDefaultConfig();
			}
			else
				return;
         
            txtDBServer.Text = Utilities.acAppConfig.sDBServer;
            txtDBName.Text = Utilities.acAppConfig.sDBDatabase;
            chkTrusted.Checked = Utilities.acAppConfig.bDBTrustedConnection;
            txtDBUser.Text = Utilities.acAppConfig.sDBUserName;
            txtPassword.Text = Utilities.acAppConfig.sDBPassword;
        }
	}
}
