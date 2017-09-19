using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Common;

namespace XetTuyen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Utilities.getConnection())
            {
                Utilities.conDBConnection.Close();
                clsCommon.sConnectionString = Utilities.sConnStr;
                frmLogin frm = new frmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {


                    Application.Run(new frmMain());
                }
                else
                    Application.Exit();
            }
            else
                Application.Exit();
            
        }
    }
}
