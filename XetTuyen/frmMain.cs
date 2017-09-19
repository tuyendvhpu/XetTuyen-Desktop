using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;
using BusinessService;
using Common;


namespace XetTuyen
{
    public partial class frmMain : Form
    {
        #region "Variables"
        private MenuGroupCollection menuGroupCollection = null;
        private MenuService menuBS;
        private List<BusinessLogic.Menu> lstMenu;
        #endregion
        public frmMain()
        {
            InitializeComponent();
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            // open database connection
            
          

            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["ADMIN_MODE"] != null)
                    SecurityManager.IsDebugMode = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ADMIN_MODE"]);
            }
            catch
            {
                SecurityManager.IsDebugMode = false;
            }

            btnUpdateMenu.Visible = SecurityManager.IsDebugMode;
            if (btnUpdateMenu.Visible == false)
            {
                ShowMenuFromDB();
            }
            
        }

        #region "Menu Item Click & [Update Menu] Button"

        private void mnuSystem_Click(object sender, EventArgs e)
        {
            
            ToolStripMenuItem mnuItem = (ToolStripMenuItem)sender;
            Form frm = null;
            
            switch (mnuItem.Name)
            {
                case "mnuUser":
                   
                    frm = new frmUser();
                    break;
                case "mnuGroup":
                    frm = new frmGroup();
                    break;
                case "mnuAuthorization":
                    frm = new frmAuthorization();
                    break;
                case "mnuUpdateMenu":
                     frm = new frmAdminMode();
                    frm.ShowDialog();
                    return;
                case "mnuCoQuan":
                    frm = new frmCongTy();
                    frm.ShowDialog();
                    return;
                case "mnuCauHinh":
                    frm = new frmConfig();
                    frm.ShowDialog();
                    return;
                case "mnuChangePassword":
                    frm = new frmChangePassword();
                    frm.ShowDialog();
                    return;
                case "mnuLogOff":
                    Application.Restart();
                    return;
                case "mnuClose":
                    this.Close();
                    return;
                case "mnuDotXetTuyen":
                    frm = new frmDotXetTuyen();
                    break;
                case "mnuHoSo":
                    frm = new frmHoSo();
                    break;
                case "mnuCongThuc":
                    frm = new frmCongThuc();
                    break;
                case "mnuTinhDiemTB":
                    frm = new frmDiemTB();
                    frm.ShowDialog();
                    return;
                case "mnuDieuKien":
                    frm = new frmDieuKien();
                    break;
                case "mnuXetTuyen":
                    frm = new frmXetTuyen();
                    break;
                case "mnuTTXetTuyen":
                    frm = new frmTTXetTuyen();
                    break;
                case "mnuInGiayBao":
                    frm = new frmInGiayBao();
                    break;
                case "mnuHistory":
                    frm = new frmHistory();
                    break;
            }

            if (frm != null && mnuItem.Name != "mnuUpdateMenu")
            {
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }
        /// <summary>
        /// btnUpdateMenu_Click
        /// </summary>      
        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
          //  MessageBox.Show(Utilities.sConnStr);
           
            try
            {
                lstMenu = new List<BusinessLogic.Menu>();
                menuBS = new MenuService();

                BusinessLogic.Menu objMenu;
                //Delete all data in table Menu
                //menu.Delete();
                
                foreach (ToolStripMenuItem item in mnuMain.Items)
                {
                    objMenu = new BusinessLogic.Menu();
                    objMenu.MenuID = item.Name;
                    if (item.Tag != null)
                        objMenu.FormName = item.Tag.ToString();
                   
                    objMenu.MenuValue = item.Text;
                  //  MessageBox.Show(item.Text);
                    //Add object menu into List
                    lstMenu.Add(objMenu);

                    //Insert sub menu
                    IterateMenus(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            
            
            //foreach (BusinessLogic.Menu objaam in lstMenu) {
            //    MessageBox.Show(objaam.MenuValue);
            //}
          

            //Update data in DB
            bool bResult = menuBS.UpdateMenu(lstMenu);
            Cursor = Cursors.Default;

            if (bResult)
                clsCommon.SaveSuccessfully();
            else
                clsCommon.SaveNotSuccessfully();
             
        }

        /// <summary>
        /// mnuShutDown_Click
        /// </summary>        
        private void mnuShutDown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "Functions"
        /// <summary>
        /// IterateMenus
        /// </summary>        
        private void IterateMenus(ToolStripMenuItem item)
        {
            BusinessLogic.Menu objMenu;
            foreach (ToolStripMenuItem subMenu in item.DropDownItems)
            {
                objMenu = new BusinessLogic.Menu();

                objMenu.MenuID = subMenu.Name;
                objMenu.MenuValue = subMenu.Text;
                objMenu.MenuFiliationID = item.Name;
                objMenu.FormName = (subMenu.Tag == null ? string.Empty : subMenu.Tag.ToString());

                //Add object menu into List
                lstMenu.Add(objMenu);


                IterateMenus(subMenu);
            }
        }

        /// <summary>
        /// IsAuthorized
        /// </summary>
        /// <param name="sMenuID"></param>
        /// <returns></returns>
        private bool IsAuthorized(string sMenuID)
        {
            foreach (MenuGroup objMenuGroup in menuGroupCollection)
            {
                if (objMenuGroup.MenuID == sMenuID)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// ShowMenuFromDB
        /// </summary>
        private void ShowMenuFromDB()
        {
            mnuMain.Items.Clear();

            List<Guid> lstGroupID = new GroupUserService().GetListGroupIdByUserID(clsCommon.CurrentUser.LoginID.ToLower());
            menuGroupCollection = new MenuGroupService().GetMenuGroupCollectionByGroupID(lstGroupID);

            MenuCollection menuCollection = new MenuService().GetMenuCollection();
            foreach (BusinessLogic.Menu  objMenu in menuCollection)
            {
                if (objMenu.MenuFiliationID == string.Empty)
                {
                    ToolStripMenuItem mnuItem = new ToolStripMenuItem();

                    mnuItem.Name = objMenu.MenuID;
                    mnuItem.Text = objMenu.MenuValue;

                    //Add menu item
                    mnuMain.Items.Add(mnuItem);

                    //Add sub menuItem of this menuItem
                    ShowSubMenu(menuCollection, mnuItem.Name, mnuItem);
                }
            }
        }

        /// <summary>
        /// AddSubMenu
        /// </summary>
        /// <param name="parentMenuName">Parent Menu Name</param>
        /// <param name="menuItem">MenuItem</param>
        private void ShowSubMenu(MenuCollection menuCollection, string sParentMenuName, ToolStripMenuItem menuItem)
        {
            foreach (BusinessLogic.Menu objSubMenu in menuCollection)
            {
                if (objSubMenu.MenuFiliationID == sParentMenuName)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();

                    subItem.Name = objSubMenu.MenuID;
                    subItem.Text = objSubMenu.MenuValue;

                    //Check user can use this menu?
                    if (clsCommon.IsAdminUser || subItem.Name.Equals("mnuClose") || subItem.Name.Equals("mnuLogOff")
                        || subItem.Name.Equals("mnuChangePassword") || subItem.Name.Equals("mnuCoQuan") || subItem.Name.Equals("mnuCauHinh") || IsAuthorized(subItem.Name))
                    {
                        //Set MenuItemChecked event
                        subItem.Click += new System.EventHandler(MenuItem_Click);

                        subItem.Enabled = true;
                        subItem.Tag = objSubMenu.FormName;
                    }
                    else
                    {
                        subItem.Enabled = false;
                    }

                    //Add menu item
                    menuItem.DropDownItems.Add(subItem);

                    //Call ShowSubMenu
                    ShowSubMenu(menuCollection, subItem.Name, subItem);
                }
            }
        }

        /// <summary>
        /// MenuItem_Click
        /// </summary>        
        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag == null) return;
            string frmName = ((ToolStripMenuItem)sender).Tag.ToString();
          
            Form frm = null;
            switch (frmName.ToLower())
            {
                #region "System"
                case "frmuser":
                    //MessageBox.Show("click");
                    frm = new frmUser();
                    break;
                case "frmgroup":
                    frm = new frmGroup();
                    break;

                case "frmauthorization":
                    frm = new frmAuthorization();
                    break;
                case "frmadminmode":
                    //MessageBox.Show(frmName);
                    frm = new frmAdminMode();
                    frm.ShowDialog();
                    return;
                case "frmconfig":
                    //MessageBox.Show(frmName);
                    frm = new frmConfig();
                    frm.ShowDialog();
                    return;
                case "frmcongty":
                    //MessageBox.Show(frmName);
                    frm = new frmCongTy();
                    frm.ShowDialog();
                    return;
                case "frmchangepassword":
                    //MessageBox.Show(frmName);
                    frm = new frmChangePassword();
                    frm.ShowDialog();
                   
                    return;
                case "close":
                    this.Close();
                    break;
                case "logoff":
                    Application.Restart();
                    break;
                #endregion
                #region "Catalog"
                case "frmdotxettuyen":
                    frm = new frmDotXetTuyen();
                    break;
                case "frmhoso":
                    frm = new frmHoSo();
                    break;
                case "frmhistory":
                    frm = new frmHistory();
                    break;
                #endregion
                #region "Processing"
                case "frmcongthuc":
                    frm = new frmCongThuc();
                    break;
                case "frmdiemtb":
                    frm = new frmDiemTB();
                    frm.ShowDialog();
                    return;
                case "frmdieukien":
                    frm = new frmDieuKien();
                    break;
                case "frmxettuyen":
                    frm = new frmXetTuyen();
                    break;
                case "frmttxettuyen":
                    frm = new frmTTXetTuyen();
                    break;
                #endregion
                #region "Statistic"
                case "frmingiaybao":
                    frm = new frmInGiayBao();
                    break;
                #endregion
            }

            if (frm != null)
            {
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
        }
        #endregion    

        

        
    }
}
