using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;
using BusinessService;
using BusinessLogic;
using Common;
using DataAccess;
using System.IO;
using System.Collections.Generic;

namespace XetTuyen
{
	/// <summary>
	/// Summary description for frmCongTy.
	/// </summary>
	public class frmCongTy : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtTen;
		private System.Windows.Forms.TextBox txtCongTy;
		private System.Windows.Forms.TextBox txtDiachi;
		private System.Windows.Forms.TextBox txtDienThoai;
		internal System.Windows.Forms.Button btnDefault;
		internal System.Windows.Forms.Button btnConfirm;
		internal System.Windows.Forms.Button btClose;
        private TextBox txtFax;
        private Label label5;
        private TextBox txtMail;
        private Label label6;
        private Label label7;
        private PictureBox ptbLogo;
        private Button btnChonAnh;
        private OpenFileDialog ofdImages;
        private Label label8;
        private ComboBox cmbSo;
        private Dictionary<string, string> heso;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCongTy()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongTy));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtCongTy = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.ofdImages = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu Đề:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điện Thoại";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa Chỉ:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbSo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnChonAnh);
            this.panel1.Controls.Add(this.ptbLogo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMail);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDienThoai);
            this.panel1.Controls.Add(this.txtDiachi);
            this.panel1.Controls.Add(this.txtCongTy);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 227);
            this.panel1.TabIndex = 4;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(175, 190);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(78, 28);
            this.btnChonAnh.TabIndex = 14;
            this.btnChonAnh.Text = "Chọn Ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // ptbLogo
            // 
            this.ptbLogo.Location = new System.Drawing.Point(112, 191);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(36, 28);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLogo.TabIndex = 13;
            this.ptbLogo.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Logo:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(115, 116);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(216, 20);
            this.txtMail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mail:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(115, 90);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(216, 20);
            this.txtFax.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fax:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(115, 64);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(216, 20);
            this.txtDienThoai.TabIndex = 7;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(115, 141);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(216, 20);
            this.txtDiachi.TabIndex = 6;
            // 
            // txtCongTy
            // 
            this.txtCongTy.Location = new System.Drawing.Point(115, 40);
            this.txtCongTy.Name = "txtCongTy";
            this.txtCongTy.Size = new System.Drawing.Size(216, 20);
            this.txtCongTy.TabIndex = 5;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(115, 16);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(216, 20);
            this.txtTen.TabIndex = 4;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(360, 55);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(72, 24);
            this.btnDefault.TabIndex = 12;
            this.btnDefault.Text = "&Mặc định";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(360, 95);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 24);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Đồ&ng ý";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(360, 143);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(72, 24);
            this.btClose.TabIndex = 10;
            this.btClose.Text = "Đóng";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ofdImages
            // 
            this.ofdImages.Filter = "*.gif|*.jpg|*.ico|*.bimat";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Điểm TB làm tròn:";
            // 
            // cmbSo
            // 
            this.cmbSo.FormattingEnabled = true;
            this.cmbSo.Location = new System.Drawing.Point(115, 165);
            this.cmbSo.Name = "cmbSo";
            this.cmbSo.Size = new System.Drawing.Size(121, 21);
            this.cmbSo.TabIndex = 16;
            // 
            // frmCongTy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(457, 239);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCongTy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công Ty";
            this.Load += new System.EventHandler(this.frmCongTy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmCongTy_Load(object sender, System.EventArgs e)
		{
            heso = new Dictionary<string, string>();
            heso.Add("0", "0");
            heso.Add("1", "1");
            heso.Add("2", "2");
            heso.Add("3", "3");
            cmbSo.DataSource = new BindingSource(heso, null);
            cmbSo.DisplayMember = "value";
            cmbSo.ValueMember = "key";
           
            if(!Utilities.loadCompany())
			{
				DialogResult rs;
				rs = MessageBox.Show("Không thể mở được file cấu hình. Bạn có muốn lấy cấu hình mặc định?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if( rs == DialogResult.Yes)
				{
					Utilities.createDefaulCompany();
				}
				else
				return;				
			}

            txtDiachi.Text = Utilities.acCompConfig.Address;
            txtDienThoai.Text = Utilities.acCompConfig.Phone;
            txtTen.Text = Utilities.acCompConfig.Header;
            txtCongTy.Text = Utilities.acCompConfig.Name;
            txtFax.Text = Utilities.acCompConfig.Fax;
            txtMail.Text = Utilities.acCompConfig.Mail;
          
           cmbSo.SelectedValue= Utilities.acCompConfig.so;
            ptbLogo.ImageLocation = Application.StartupPath + "\\" + Utilities.acCompConfig.Logo;
		}

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			Utilities.acCompConfig.Address = txtDiachi.Text.Trim();
			Utilities.acCompConfig.Phone = txtDienThoai.Text.Trim();
			Utilities.acCompConfig.Header = txtTen.Text.Trim();
			Utilities.acCompConfig.Name = txtCongTy.Text.Trim();
            Utilities.acCompConfig.Fax = txtFax.Text.Trim();
            Utilities.acCompConfig.Mail = txtMail.Text.Trim();
            Utilities.acCompConfig.so = Convert.ToInt16( cmbSo.SelectedValue.ToString());
            
            try
            {
                if (urlIamge != "")
                {
                    if (File.Exists(Application.StartupPath + "\\" + Utilities.acCompConfig.Logo))
                    File.Delete(Application.StartupPath + "\\" + Utilities.acCompConfig.Logo);
                    if (File.Exists(Application.StartupPath + "\\" + nameIamge))
                        File.Delete(Application.StartupPath + "\\" + nameIamge);
                    File.Copy(urlIamge, Application.StartupPath + "\\" + nameIamge);
                    
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, this.Text);
            }
            finally
            {
                
            }
            Utilities.acCompConfig.Logo = nameIamge;
			Utilities.saveCompany(Utilities.acCompConfig);

		}
        private string urlIamge = null;
        private string nameIamge = null;
		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			DialogResult rs;
			rs = MessageBox.Show("Bạn chắc chắn muốn lấy cấu hình mặc định?","Thông báo", MessageBoxButtons.YesNo ,MessageBoxIcon.Question);
			if(	rs == DialogResult.Yes)
			{
				Utilities.createDefaulCompany();
			}
			else
				return;
         
			txtDiachi.Text = Utilities.acCompConfig.Address;
			txtDienThoai.Text = Utilities.acCompConfig.Phone;
			txtTen.Text = Utilities.acCompConfig.Header;
			txtCongTy.Text = Utilities.acCompConfig.Name;
            txtFax.Text = Utilities.acCompConfig.Fax;
            txtMail.Text = Utilities.acCompConfig.Mail;
            cmbSo.SelectedText = "1";
            nameIamge = Utilities.acCompConfig.Logo;
            ptbLogo.ImageLocation =Application.StartupPath + "\\" + Utilities.acCompConfig.Logo;
		}

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (ofdImages.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(ofdImages.SafeFileName);
                urlIamge = ofdImages.FileName;
                nameIamge = ofdImages.SafeFileName;
                ptbLogo.ImageLocation = ofdImages.FileName;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
