using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using BusinessService;
using BusinessLogic;
using DataAccess;
namespace XetTuyen
{
    public partial class frmAdminMode : Form
    {
        public frmAdminMode()
        {
            InitializeComponent();
        }

        private void frmAdminMode_Load(object sender, EventArgs e)
        {
            if (SecurityManager.IsDebugMode)
                rdOn.Checked = true;
            else
                rdOff.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SecurityManager.IsDebugMode = rdOn.Checked;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            if (System.Configuration.ConfigurationManager.AppSettings["ADMIN_MODE"] != null)
            {
                config.AppSettings.Settings["ADMIN_MODE"].Value = rdOn.Checked.ToString();
                config.Save(System.Configuration.ConfigurationSaveMode.Full);
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            }            

            this.DialogResult = DialogResult.OK;
        }
    }
}