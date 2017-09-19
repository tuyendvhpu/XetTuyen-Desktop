using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;
using BusinessService;
using Common;

namespace XetTuyen
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            txtUser.Text = clsCommon.CurrentUser.LoginID;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPass.Clear();
            txtOldPass.Clear();
            txtRePass.Clear();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(IsDataOK())
            {
                    clsCommon.CurrentUser.Password = txtRePass.Text.Trim();
                    if (new UsersService().UpdatePassword(clsCommon.CurrentUser)) {
                        MessageBox.Show("Bạn đã thay dổi mật khẩu thành công");
                        Clear();
                        Application.Restart();
                    }

              }
        }
        private void Clear() {
            txtOldPass.Clear();
            txtNewPass.Clear();
            txtRePass.Clear();
        }
         /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (Utilities.encryptMD5String(txtOldPass.Text.Trim()) != clsCommon.CurrentUser.Password)
            {
                MessageBox.Show("Mật khẩu không đúng với mật khẩu cũ.");
                txtOldPass.Focus();
                return false;
            }
            if (txtNewPass.Text.Trim().Length<=0 )
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.");
                txtNewPass.Focus();
                return false;
            }
            if(txtNewPass.Text.Trim()!=txtRePass.Text.Trim()){
                MessageBox.Show("Mật khẩu xác nhận không đúng.");
                txtRePass.Focus();
                return false;
            }

            return true;
        }
    }
}
