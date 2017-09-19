using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessLogic;
using DataAccess;
using Common;
using BusinessService;

namespace XetTuyen
{
    public partial class frmLogin : Form
    {
        #region "Variables"
        private UsersService userBS = new UsersService();                
        private int m_PrevX;
        private int m_PrevY;
        #endregion

        #region "Form's Events"
        public frmLogin()
        {
            InitializeComponent();
           // txtUserName.Text = Utilities.encryptMD5String("123");
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// frmLogin
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public frmLogin(int x, int y)
        {
            InitializeComponent();
            this.Location = new Point(x, y);
            
        }        

        /// <summary>
        /// frmLogin_MouseMove
        /// </summary>        
        public void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Left = Left + (e.X - m_PrevX);
            Top = Top + (e.Y - m_PrevY);

        }

        /// <summary>
        /// frmLogin_MouseDown
        /// </summary>        
        public void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            m_PrevX = e.X;
            m_PrevY = e.Y;
        }
        #endregion

        #region "Language Menu"        

        /// <summary>
        /// MenuItemClicked
        /// </summary>       
        private void MenuItemClicked(object sender, EventArgs e)
        {
             
        }
        
        #endregion

        

        /// <summary>
        /// tsBtnExit_Click
        /// </summary>        
        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// btnOK_Click
        /// </summary>        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Utilities.sConnStr);
            if (IsDataOK() == false)
                return;

            string sMessage = string.Empty;
            UserStatus status = UserStatus.NotExists;            
            Users objUser = userBS.CheckUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(), ref status);
           
            switch (status)
            {
                case UserStatus.NotExists:
                    sMessage = "Nguoi dung hoac mat khau khong dung";
                    break;
                case UserStatus.Locked:
                    sMessage = "Nguoi dung nay da bi khoa.";
                    break;
                case UserStatus.ExpiredDate:
                    sMessage = "Nguoi dung nay da het han su dung";
                    break;
                case UserStatus.OK:
                    clsCommon.CurrentUser = objUser;

                    //MessageBox.Show(clsCommon.IsAdminUser.ToString());
                    this.DialogResult = DialogResult.OK;
                    return;
            }            
            MessageBox.Show(sMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtUserName.Focus();
        }              

        /// <summary>
        /// Check data which user inputs OK or not
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban chua nhap ten nguoi dung", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban chua nhap mat khau", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Application.Exit();
        }


                
    }
}