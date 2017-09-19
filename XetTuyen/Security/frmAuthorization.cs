using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using BusinessLogic;
using BusinessService;
using DataAccess;

namespace XetTuyen
{
    public partial class frmAuthorization : frmBase
    {
        #region "Declare Variables and Properties"
        //private bool bIsMultilangData = false;
        List<Guid> listAuthID = new List<Guid>();
        List<Guid> listDeletedAuthID = new List<Guid>();
        List<Guid> listNewAuthID = new List<Guid>();

        private ModuleService moduleBS = new ModuleService();
        private GroupAuthorizationService groupAuthorizationBS = new GroupAuthorizationService();
        private GroupAuthorizationCollection currentGroupAuthorizationCollection = new GroupAuthorizationCollection();
        private int mainPanelWidth;

        TreeNode tnGroupSelectedNode = null;
        TreeNode tnFunctionGroupSelectedNode = null;

        private bool isProgrammingCheckedListView = true;
        private bool isProgrammingSelectedTreeNode = true;


        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        #endregion

        #region "Form"
        public frmAuthorization()
        {
            InitializeComponent();

        }

        /// <summary>
        /// frmAuthorization_Load
        /// </summary>        
        private void frmAuthorization_Load(object sender, EventArgs e)
        {
            menuStrip2.Items.Clear();
            isProgrammingSelectedTreeNode = true;

            InitData();

            mainPanelWidth = splitContainer2.Panel1.Width;
            VisibleButtons(false);

            InitMenuSection();


            //Set Authorization
            ucDataButton1.EditVisible = new AuthorizationsService().IsAuthorized(AuthorizationsService.Action.Update);
        }

        //2008/10/20
        private const string sSpace = "      ";//6
        private bool bIsAutoCheck = false;
        private bool bIsClickCheckAll = false;
        private int nCheckedItemsCount = 0;
        private void frmAuthorization_SetHeaderTextHandler()
        {
            clmItemDescription.Text = sSpace + clmItemDescription.Text.Trim();
        }
        //END

        /// <summary>
        /// Init Data for controls on Form
        /// </summary>
        private void InitData()
        {
            DisplayGroups();
            DisplayFunctionGroups();

            txtGroupName.Left = lblGroupName.Left + lblGroupName.Width;
            lblNumber.Left = lblAuthorizationCount.Left + lblAuthorizationCount.Width;
            txtGroupName.Width = pnlAuthorization.Width - (lblGroupName.Width + 15);
        }        

        /// <summary>
        /// Find Selected Note before Change Language
        /// </summary>
        private TreeNode FindSelectedNote(bool bIsGroup)
        {
            if (bIsGroup)
            {
                Guid selectedGroupID = (Guid)tnGroupSelectedNode.Tag;
                foreach (TreeNode node in treGroup.Nodes)
                {
                    if ((Guid)node.Tag == selectedGroupID)
                        return node;
                }
            }

            return null;
        }

        /// <summary>
        /// frmAuthorization_Shown
        /// </summary>        
        private void frmAuthorization_Shown(object sender, EventArgs e)
        {
            isProgrammingSelectedTreeNode = false;
            if (treGroup.Nodes.Count > 0)
            {
                treGroup.SelectedNode = null;
                treGroup.SelectedNode = treGroup.Nodes[0];

                //Mark MenuItem
                MarkMenuItem();
            }
        }
        #endregion

        #region "ListView MethodDescription Functions"
        /// <summary>
        /// IsCheckedMethod
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="authID"></param>
        /// <returns></returns>
        private bool IsCheckedMethod(Guid groupID, Guid authID)
        {
            foreach (GroupAuthorization authRole in currentGroupAuthorizationCollection)
            {
                if (authRole.GroupID == groupID && authRole.AuthorizationID == authID)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// DisplayMethodDesc
        /// </summary>
        private void DisplayMethodDescription()
        {
            if (tnGroupSelectedNode == null || tnFunctionGroupSelectedNode == null) return;

            lstMethod.Items.Clear();

            isProgrammingCheckedListView = true;

            //2008/10/20
            nCheckedItemsCount = 0;
            //END

            //AuthorizationCollection authCollection = clsAuthorization.GetAuthorizationCollectionByTitle((ModuleType)tnFunctionGroupSelectedNode.Parent.Tag, tnFunctionGroupSelectedNode.Text);
            Modules objModule = (Modules)tnFunctionGroupSelectedNode.Parent.Tag;
            AuthorizationCollection authCollection = AuthorizationsService.GetAuthorizationCollectionByTitle((ModuleType)objModule.ModuleID, tnFunctionGroupSelectedNode.Text);
            foreach (Authorizations auth in authCollection)
            {
                ListViewItem item = new ListViewItem();
                item.Text = auth.Description;
                item.Tag = auth.AuthorizationID;

                item.Checked = IsCheckedMethod((Guid)tnGroupSelectedNode.Tag, auth.AuthorizationID);
                if (item.Checked)
                    nCheckedItemsCount++;

                lstMethod.Items.Add(item);
            }
            isProgrammingCheckedListView = false;
        }

        /// <summary>
        /// UpdateCurrentAuthorizationRole
        /// </summary>        
        private void UpdateCurrentAuthorizationRole(Guid groupID, Guid authorizationID, bool isDeleted)
        {
            if (isDeleted)
            {
                foreach (GroupAuthorization groupAuthorization in currentGroupAuthorizationCollection)
                {
                    if (groupAuthorization.GroupID == groupID
                        && groupAuthorization.AuthorizationID == authorizationID)
                    {
                        currentGroupAuthorizationCollection.Remove(groupAuthorization);
                        break;
                    }
                }
            }
            else
            {
                GroupAuthorization groupAuthorization = new GroupAuthorization();
                groupAuthorization.GroupID = groupID;
                groupAuthorization.AuthorizationID = authorizationID;

                //Add new AuthorizationRole for displaying only
                currentGroupAuthorizationCollection.Add(groupAuthorization);
            }

            UpdateAuthorizationCount();
        }

        /// <summary>
        /// lstMethod_ItemChecked
        /// </summary>        
        private void lstMethod_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isProgrammingCheckedListView) return;

            Guid authID = (Guid)e.Item.Tag;

            if (e.Item.Checked)
            {

                if (IsNewItem(e.Item) && listNewAuthID.Contains(authID) == false)
                    listNewAuthID.Add(authID);
                else
                    listDeletedAuthID.Remove(authID);

                //Add new AuthorizarionRole into Current Collection
                UpdateCurrentAuthorizationRole((Guid)tnGroupSelectedNode.Tag, authID, false);

                //2008/10/20
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount++;
                //END
            }
            else
            {
                if (IsDeletedItem(e.Item) && listDeletedAuthID.Contains(authID) == false)
                    listDeletedAuthID.Add(authID);
                else
                    listNewAuthID.Remove(authID);

                //Remove delete AuthorizationRole for displaying only
                UpdateCurrentAuthorizationRole((Guid)tnGroupSelectedNode.Tag, authID, true);

                //2008/10/20
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount--;
                //END
            }

            if (bIsClickCheckAll == false)
            {
                bIsAutoCheck = true;
                if (nCheckedItemsCount < lstMethod.Items.Count)
                    chkAll.Checked = false;
                else
                    chkAll.Checked = true;
                bIsAutoCheck = false;
            }
        }

        #endregion

        #region "TreeView Groups"
        /// <summary>
        /// DisplayGroups
        /// </summary>
        private void DisplayGroups()
        {
            treGroup.Nodes.Clear();
            GroupCollection groupCollection = new GroupsService().GetListGroup();
            foreach (Groups objGroup in groupCollection)
            {
                TreeNode tnGroup = new TreeNode(objGroup.GroupName);
                tnGroup.ImageIndex = 0;
                tnGroup.Tag = objGroup.GroupID;
                treGroup.Nodes.Add(tnGroup);
            }
        }

        /// <summary>
        /// treAuth_AfterSelect
        /// </summary>        
        private void treGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isProgrammingSelectedTreeNode) return;

            if (treGroup.SelectedNode != null)
            {
                groupID = (Guid)treGroup.SelectedNode.Tag;

                tnGroupSelectedNode = treGroup.SelectedNode;
                txtGroupName.Text = tnGroupSelectedNode.Text;

                currentGroupAuthorizationCollection = new GroupAuthorizationService().GetGroupAuthorizationCollectionByGroupID(groupID);

                //Menu Section                
                MarkMenuItem();
                //End
            }
            else
                currentGroupAuthorizationCollection = new GroupAuthorizationCollection();

            UpdateAuthorizationCount();

            //Clear ListViewItem
            treFunctionGroup.SelectedNode = null;
            lstMethod.Items.Clear();
        }

        #endregion

        #region "TreeView Function Groups"
        private void DisplayFunctionGroups()
        {
            treFunctionGroup.Nodes.Clear();
            //clsModuleCollection moduleCollection = clsModuleBS.GetModulesByLanguageID(clsCommonBS.CurrentLanguageID);
            ModulesCollection moduleCollection = moduleBS.GetAllModules();
            if (moduleCollection.Count > 0)
            {
                foreach (Modules module in moduleCollection)
                    AddModuleTypeNode((ModuleType)module.ModuleID, module);
            }
            else
            {
                foreach (ModuleType moduleType in Enum.GetValues(typeof(ModuleType)))
                    AddModuleTypeNode(moduleType, null);
            }

            treFunctionGroup.ExpandAll();
        }

        /// <summary>
        /// AddModuleTypeNode
        /// </summary>
        /// <param name="moduleType"></param>
        private void AddModuleTypeNode(ModuleType moduleType, Modules module)
        {
            if (module == null)
            {
                //module = clsModuleBS.GetModuleByModuleTypeAndLanguageCode(moduleType, clsCommonBS.CurrentLanguageID);
                module = new Modules();
                module.ModuleID = (int)moduleType;
                module.ModuleName = GetModuleTypeName.GetString(moduleType);
            }

            
            TreeNode tnModule = new TreeNode(module.ModuleName);
            tnModule.ImageIndex = 0;
            tnModule.Tag = module;

            treFunctionGroup.Nodes.Add(tnModule);

            //Add functions belong to this node
            AddAuthorizationInModuleType(tnModule, moduleType);
        }

        /// <summary>
        /// AddAuthorizationInModuleType
        /// </summary>
        /// <param name="tnModule"></param>
        /// <param name="moduleType"></param>
        private void AddAuthorizationInModuleType(TreeNode tnModule, ModuleType moduleType)
        {
            TreeNode tnAuth = null;
            List<string> lstTitle = new List<string>();

            AuthorizationCollection authCollection = new AuthorizationCollection();
            authCollection = AuthorizationsService.GetAuthorizationCollectionByModuleType(moduleType);

            foreach (Authorizations auth in authCollection)
            {
                if (!lstTitle.Contains(auth.Title))
                {
                    lstTitle.Add(auth.Title);
                    tnAuth = new TreeNode(auth.Title);
                    tnAuth.Tag = auth.AuthorizationID;
                    tnAuth.ImageIndex = 1;
                    tnAuth.SelectedImageIndex = 2;
                    tnModule.Nodes.Add(tnAuth);
                }
            }
        }

        /// <summary>
        /// treFunctionGroup_AfterSelect
        /// </summary>        
        private void treFunctionGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treFunctionGroup.SelectedNode.Parent != null)
            {
                tnFunctionGroupSelectedNode = treFunctionGroup.SelectedNode;
                DisplayMethodDescription();

                //2008/10/20                         
                bIsAutoCheck = true;

                bool bIsCheckAll = true;
                for (int i = 0; i < lstMethod.Items.Count; i++)
                {
                    if (lstMethod.Items[i].Checked == false)
                    {
                        bIsCheckAll = false;
                        break;
                    }
                }

                chkAll.Checked = bIsCheckAll;

                bIsAutoCheck = false;
                //END
            }
            else
            {
                lstMethod.Items.Clear();
            }
        }

        /// <summary>
        /// treFunctionGroup_NodeMouseDoubleClick
        /// </summary>        
        private void treFunctionGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (bIsMultilangData && e.Node.Parent != null)
            //{
                /*
                frmAuthorizationLanguage frm = new frmAuthorizationLanguage();

                frm.m_Module = (Module)e.Node.Parent.Tag;
                frm.AuthorizationID = (Guid)e.Node.Tag;
                frm.Title = e.Node.Text.Trim();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    e.Node.Text = frm.Title;
                    e.Node.Parent.Text = frm.m_Module.ModuleName;

                    //Refresh Collection
                    tnFunctionGroupSelectedNode.Text = frm.Title;
                    clsAuthorization.AuthorizationCollection = null;
                    treFunctionGroup_AfterSelect(sender, null);
                }
                */
            //}
        }

        #endregion

        #region "Common Functions"
        /// <summary>
        /// SetAuthorization
        /// </summary>
        private void SetAuthorization()
        {
            AuthorizationsService authorizationBS = new AuthorizationsService();
            ucDataButton1.EditVisible = authorizationBS.IsAuthorized(AuthorizationsService.Action.Update);
            //ucDataButton1.MultiLanguageVisible = authorizationBS.IsAuthorized(clsAuthorizationBS.Action.MultilangUI);
            //bIsMultilangData = authorizationBS.IsAuthorized(clsAuthorizationBS.Action.MultilangData);
        }

        /// <summary>
        /// VisibleGenerateButton
        /// </summary>        

        /// <summary>
        /// VisibleButtons
        /// </summary>
        /// <param name="isVisibled"></param>
        private void VisibleButtons(bool bIsVisibled)
        {
            //btnGenerate.Visible = bIsVisibled;

            lstMethod.Enabled = bIsVisibled;
            chkAll.Enabled = bIsVisibled;

            //SplitContainer1.Panel1
            //tsMain.Visible = !(isVisibled);
            //treGroup.Visible = tsMain.Visible;
            treGroup.Visible = !bIsVisibled;


            if (bIsVisibled)
            {
                splitContainer2.SplitterDistance = 0;
                splitContainer2.IsSplitterFixed = true;
            }
            else
            {
                splitContainer2.SplitterDistance = mainPanelWidth;
                splitContainer2.IsSplitterFixed = false;
            }

            clmItemDescription.Width = lstMethod.Width - 10;

            //For Menu Section                        
            isProgrammingCheckedMenu = !bIsVisibled;
            SetMenuItemReadOnlyMode(bIsVisibled);
            //End                       
        }

        /// <summary>
        /// IsNewItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool IsNewItem(ListViewItem item)
        {
            if (listAuthID.Contains((Guid)item.Tag) == false)
                return true;
            return false;
        }

        /// <summary>
        /// IsDeletedItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool IsDeletedItem(ListViewItem item)
        {
            if (listAuthID.Contains((Guid)item.Tag))
                return true;
            return false;
        }

        /// <summary>
        /// ClearLists
        /// </summary>
        private void ClearLists()
        {
            listAuthID.Clear();
            listNewAuthID.Clear();
            listDeletedAuthID.Clear();
        }

        /// <summary>
        /// UpdateAuthorizationCount
        /// </summary>
        private void UpdateAuthorizationCount()
        {
            lblNumber.Text = "[" + currentGroupAuthorizationCollection.Count + "]";
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsDataChanged()
        {
            if (listDeletedAuthID.Count > 0 || listNewAuthID.Count > 0
                || addedMenuGroupCollection.Count > 0 || deletedMenuGroupCollection.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Update data in DB
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            List<GroupAuthorization> lstAddedGroupAuthorization = new List<GroupAuthorization>();
            List<GroupAuthorization> lstDeletedGroupAuthorization = new List<GroupAuthorization>();

            GroupAuthorization objGroupAuthorization;

            //1. GroupAuthorization
            //Deleted Objects
            for (int intIndex = 0; intIndex < listDeletedAuthID.Count; intIndex++)
            {
                //objGroupAuthorization = groupAuthorizationBS.GetGroupAuthorizationByID(groupID, listDeletedAuthID[intIndex]);
                objGroupAuthorization = new GroupAuthorization(groupID, listDeletedAuthID[intIndex]);
                if (objGroupAuthorization != null)
                    lstDeletedGroupAuthorization.Add(objGroupAuthorization);
            }

            //Added Objects
            for (int intIndex = 0; intIndex < listNewAuthID.Count; intIndex++)
            {
                objGroupAuthorization = new GroupAuthorization(groupID, listNewAuthID[intIndex]);                       
                lstAddedGroupAuthorization.Add(objGroupAuthorization);
            }

            //2. MenuGroup
            List<MenuGroup> lstAddedMenuGroup = new List<MenuGroup>();
            List<MenuGroup> lstDeletedMenuGroup = new List<MenuGroup>();
            foreach (MenuGroup objAddedMenuGroup in addedMenuGroupCollection)
                lstAddedMenuGroup.Add(objAddedMenuGroup);
            foreach (MenuGroup objDeletedMenuGroup in deletedMenuGroupCollection)
                lstDeletedMenuGroup.Add(objDeletedMenuGroup);
         //   MessageBox.Show(lstAddedMenuGroup.Count.ToString());
            //UPDATE DATA IN DB
            bool bResult = groupAuthorizationBS.UpdateData(lstAddedGroupAuthorization, lstDeletedGroupAuthorization, lstAddedMenuGroup, lstDeletedMenuGroup);
                                                           
            if (bResult)
            {
                clsCommon.SaveSuccessfully();

                //1. GroupAuthorization
                //Refresh GroupAuthorizationCollection
                GroupAuthorizationService.GroupAuthorizationCollection = null;
                //END

                currentGroupAuthorizationCollection = new GroupAuthorizationService().GetGroupAuthorizationCollectionByGroupID(groupID);
                UpdateAuthorizationCount();

                //2. MenuGroup
                addedMenuGroupCollection.Clear();
                deletedMenuGroupCollection.Clear();
                menuGroupCollection = menuGroupBS.GetMenuGroupCollection();

                //Controls on Forms
                VisibleButtons(false);
                ucDataButton1.DataMode = DataState.View;
            }
            else
                clsCommon.SaveNotSuccessfully();

            return bResult;
        }

        #endregion

        #region "Menu Section"

        private Guid groupID;
        private bool isProgrammingCheckedMenu = false;

        private MenuGroupService menuGroupBS;
        private MenuGroupCollection menuGroupCollection;
        private MenuGroupCollection deletedMenuGroupCollection = new MenuGroupCollection();
        private MenuGroupCollection addedMenuGroupCollection = new MenuGroupCollection();

        /// <summary>
        /// InitMenuSection
        /// </summary>
        private void InitMenuSection()
        {
            ShowMenuFromDB();

            menuGroupBS = new MenuGroupService();
            menuGroupCollection = menuGroupBS.GetMenuGroupCollection();
        }

        /// <summary>
        /// SetSubMenuItemReadOnlyMode
        /// </summary>
        /// <param name="parentMenuItem"></param>
        /// <param name="isReadOnly"></param>
        private void SetSubMenuItemReadOnlyMode(ToolStripMenuItem parentMenuItem, bool isReadOnly)
        {
            for (int intIndex = 0; intIndex < parentMenuItem.DropDownItems.Count; intIndex++)
            {
                ((ToolStripMenuItem)parentMenuItem.DropDownItems[intIndex]).CheckOnClick = isReadOnly;

                SetSubMenuItemReadOnlyMode((ToolStripMenuItem)parentMenuItem.DropDownItems[intIndex], isReadOnly);
            }
        }

        /// <summary>
        /// SetMenuItemReadOnlyMode
        /// </summary>
        /// <param name="isReadOnly"></param>
        private void SetMenuItemReadOnlyMode(bool isReadOnly)
        {
            for (int intIndex = 0; intIndex < menuStrip2.Items.Count; intIndex++)
                SetSubMenuItemReadOnlyMode((ToolStripMenuItem)(ToolStripMenuItem)menuStrip2.Items[intIndex], isReadOnly);
        }

        /// <summary>
        /// AddMenuRole
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        private void AddMenuRole(string sMenuID)
        {
            foreach (MenuGroup objTmpMenuGroup in menuGroupCollection)
            {
                if (objTmpMenuGroup.MenuID == sMenuID && objTmpMenuGroup.GroupID == groupID)
                    return;
            }

            //Check Added MenuRole
            foreach (MenuGroup objTmpAddMenuRole in addedMenuGroupCollection)
            {
                if (objTmpAddMenuRole.MenuID == sMenuID && objTmpAddMenuRole.GroupID == groupID)
                    return;
            }

            //Update MenuRoleCollection
            MenuGroup objAddMenuRole = new MenuGroup();
            objAddMenuRole.GroupID = groupID;
            objAddMenuRole.MenuID = sMenuID;
            addedMenuGroupCollection.Add(objAddMenuRole);
            //End
        }

        /// <summary>
        /// DeleteMenuGroup
        /// </summary>
        /// <param name="sMenuID"></param>        
        private void DeleteMenuGroup(string sMenuID)
        {
            foreach (MenuGroup objMenuGroup in menuGroupCollection)
            {
                if (objMenuGroup.MenuID == sMenuID && objMenuGroup.GroupID == groupID)
                {
                    //Check Deleted MenuRole
                    foreach (MenuGroup objTmpMenuGroup in deletedMenuGroupCollection)
                    {
                        if (objTmpMenuGroup.MenuID == sMenuID && objTmpMenuGroup.GroupID == groupID)
                            return;
                    }

                    deletedMenuGroupCollection.Add(objMenuGroup);
                    //End

                    return;
                }
            }
        }

        /// <summary>
        /// IsAuthorizedMenu
        /// </summary>
        /// <param name="sMenuID"></param>
        /// <returns></returns>
        private bool IsAuthorizedMenu(string sMenuID)
        {
            foreach (MenuGroup objTmpMenuRole in menuGroupCollection)
            {
                if (objTmpMenuRole.MenuID == sMenuID && objTmpMenuRole.GroupID == groupID)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// MarkSubMenuItem
        /// </summary>
        /// <param name="parentMenuItem">Parent MenuItem</param>
        private void MarkSubMenuItem(ToolStripMenuItem parentMenuItem)
        {
            isProgrammingCheckedMenu = true;

            //if (parentMenuItem.OwnerItem != null)
            //   parentMenuItem.Checked = IsCheckedMenu(parentMenuItem.Name, (Guid)treGroup.SelectedNode.Tag);
            for (int intIndex = 0; intIndex < parentMenuItem.DropDownItems.Count; intIndex++)
            {
                ToolStripMenuItem subItem = (ToolStripMenuItem)parentMenuItem.DropDownItems[intIndex];
                subItem.Checked = IsAuthorizedMenu(subItem.Name);
                if (subItem.HasDropDownItems)
                {
                    MarkSubMenuItem(subItem);
                }
            }
            isProgrammingCheckedMenu = false;
        }

        /// <summary>
        /// MarkMenuItem
        /// </summary>
        private void MarkMenuItem()
        {
            for (int intIndex = 0; intIndex < menuStrip2.Items.Count; intIndex++)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)menuStrip2.Items[intIndex];
                if (item.HasDropDownItems)
                {
                    MarkSubMenuItem(item);
                }
            }
        }

        /// <summary>
        /// ShowMenuFromDB
        /// </summary>
        private void ShowMenuFromDB()
        {
            menuStrip2.Items.Clear();
            MenuCollection menuCollection = new MenuService().GetMenuCollection();
            foreach (BusinessLogic.Menu objMenu in menuCollection)
            {
                if (objMenu.MenuFiliationID == string.Empty)
                {
                    ToolStripMenuItem mnuItem = new ToolStripMenuItem();

                    //Set MenuText, MenuName and Checked for new MenuItem
                    mnuItem.Name = objMenu.MenuID;
                    mnuItem.Text = objMenu.MenuValue;

                    if (mnuItem.Name.ToLower() == "mnumultilanguage")
                    {
                        mnuItem.Tag = objMenu.FormName;
                        mnuItem.Alignment = ToolStripItemAlignment.Right;
                        mnuItem.Click += new System.EventHandler(MenuItem_Click);
                    }

                    //Add menu item                 
                    menuStrip2.Items.Add(mnuItem);

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

                    //Set MenuItemChecked event
                    subItem.Click += new System.EventHandler(MenuItem_Click);
                    //subItem.CheckOnClick = true;

                    subItem.Name = objSubMenu.MenuID;
                    subItem.Text = objSubMenu.MenuValue;

                    //Add menu item
                    menuItem.DropDownItems.Add(subItem);

                    //Call ShowSubMenu
                    ShowSubMenu(menuCollection, subItem.Name, subItem);
                }
            }
        }

        /// <summary>
        /// MenuItem_Checked
        /// </summary>
        /// <param name="menuItem">MenuItem</param>
        /// <param name="isChecked">Checked status</param>
        /// <param name="isParent">Is Finding Parent Level Menu</param>
        private void MenuItem_Checked(ToolStripMenuItem menuItem, bool bIsChecked, bool bIsParent)
        {
            if (bIsParent)
            {
                //Call recursion to find parent MenuItems
                if (menuItem.Checked != bIsChecked)
                {
                    menuItem.Checked = bIsChecked;

                    //Update MenuRoleCollection
                    if (bIsChecked)
                        AddMenuRole(menuItem.Name);
                    else
                    {
                        DeleteMenuGroup(menuItem.Name);

                        //2008/09/10 - Remove object from addMenuCollection
                        foreach (MenuGroup objMenuGroup in addedMenuGroupCollection)
                        {
                            if (objMenuGroup.MenuID == menuItem.Name)
                            {
                                addedMenuGroupCollection.Remove(objMenuGroup);
                                break;
                            }
                        }
                        //End
                    }
                    //End

                    if (menuItem.OwnerItem != null)
                    {
                        int countChecked = 0;
                        ToolStripMenuItem parentMenu = (ToolStripMenuItem)menuItem.OwnerItem;
                        for (int intIndex = 0; intIndex < parentMenu.DropDownItems.Count; intIndex++)
                        {
                            ToolStripMenuItem currentItem = (ToolStripMenuItem)parentMenu.DropDownItems[intIndex];
                            if (currentItem.Checked && currentItem.Name != menuItem.Name)
                                countChecked++;
                        }

                        //Count == 0 mean there is only 1 its parent has been checked => Call Recursion to find more.
                        //Count > 0 mean besides its parent has been checked there are more above level MenuItems have been checked, too => Stop
                        if (countChecked == 0)
                            MenuItem_Checked(parentMenu, bIsChecked, true);
                    }
                }
            }
            else
            {
                //Update MenuRoleCollection
                if (bIsChecked)
                    AddMenuRole(menuItem.Name);
                else
                {
                    DeleteMenuGroup(menuItem.Name);

                    //2008/09/10 - Remove object from addMenuCollection
                    foreach (MenuGroup objMenuGroup in addedMenuGroupCollection)
                    {
                        if (objMenuGroup.MenuID == menuItem.Name)
                        {
                            addedMenuGroupCollection.Remove(objMenuGroup);
                            break;
                        }
                    }
                    //End
                }
                //End

                //Call recursion to find sub MenuItems
                if (menuItem.HasDropDownItems)
                {
                    for (int intIndex = 0; intIndex < menuItem.DropDownItems.Count; intIndex++)
                    {
                        ToolStripMenuItem currentItem = (ToolStripMenuItem)menuItem.DropDownItems[intIndex];
                        currentItem.Checked = bIsChecked;

                        //Update MenuRoleCollection
                        if (bIsChecked)
                            AddMenuRole(menuItem.Name);
                        else
                            DeleteMenuGroup(menuItem.Name);
                        //End

                        MenuItem_Checked(currentItem, bIsChecked, false);
                    }
                }
            }
        }

        /// <summary>
        /// MenuItem_Click
        /// </summary>        
        private void MenuItem_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;            

            if (isProgrammingCheckedMenu || ucDataButton1.DataMode == DataState.View) return;
            bool bIsChecked = menuItem.Checked;

            //1. Find parent MenuItems to mark it checked or unchecked
            if (menuItem.OwnerItem != null)
            {
                //Update MenuRoleCollection
                if (bIsChecked)
                    AddMenuRole(menuItem.Name);
                else
                {
                    DeleteMenuGroup(menuItem.Name);

                    //Remove object from addMenuCollection
                    foreach (MenuGroup objMenuGroup in addedMenuGroupCollection)
                    {
                        if (objMenuGroup.MenuID == menuItem.Name)
                        {
                            addedMenuGroupCollection.Remove(objMenuGroup);
                            break;
                        }
                    }
                }
                //End

                int countCheckedItem = 0;
                ToolStripMenuItem parentMenu = (ToolStripMenuItem)menuItem.OwnerItem;
                for (int intIndex = 0; intIndex < parentMenu.DropDownItems.Count; intIndex++)
                {
                    ToolStripMenuItem currentItem = (ToolStripMenuItem)parentMenu.DropDownItems[intIndex];
                    if (currentItem.Checked && currentItem.Name != menuItem.Name)
                        countCheckedItem++;
                }

                //Count == 0 means there is only 1 its parent has been checked => Call Recursion to find more.
                //Count > 0 means besides its parent has been checked there are more above level MenuItems have been checked, too => Stop
                if (countCheckedItem == 0)
                    MenuItem_Checked(parentMenu, bIsChecked, true);
            }

            //2. Find sub MenuItems to mark it checked or unchecked
            if (menuItem.HasDropDownItems && menuItem.OwnerItem != null)
            {
                for (int intIndex = 0; intIndex < menuItem.DropDownItems.Count; intIndex++)
                {
                    ToolStripMenuItem currentItem = (ToolStripMenuItem)menuItem.DropDownItems[intIndex];

                    currentItem.Checked = bIsChecked;
                    MenuItem_Checked(currentItem, bIsChecked, false);
                }
            }
        }

        /// <summary>
        /// CancelMenu
        /// </summary>        
        private void CancelMenu()
        {
            //Clear temp MenuRoleCollection
            addedMenuGroupCollection.Clear();
            deletedMenuGroupCollection.Clear();

            //Reset menuItem's checked state before modifying.
            MarkMenuItem();
        }

        /// <summary>
        /// ClearSubMenuItem
        /// </summary>
        /// <param name="parentMenuItem">parent MenuItem</param>
        private void ClearSubMenuItem(ToolStripMenuItem parentMenuItem)
        {
            for (int intIndex = 0; intIndex < parentMenuItem.DropDownItems.Count; intIndex++)
            {
                ((ToolStripMenuItem)parentMenuItem.DropDownItems[intIndex]).Checked = false;

                ClearSubMenuItem((ToolStripMenuItem)parentMenuItem.DropDownItems[intIndex]);
            }
        }

        /// <summary>
        /// ClearMenuItem
        /// </summary>
        private void ClearMenuItem()
        {
            //Set isProgrammingCheckedMenu=true to avoid the code is executed in eventMenuItem_Click event
            isProgrammingCheckedMenu = true;

            for (int intIndex = 0; intIndex < menuStrip2.Items.Count; intIndex++)
                ClearSubMenuItem((ToolStripMenuItem)(ToolStripMenuItem)menuStrip2.Items[intIndex]);

            isProgrammingCheckedMenu = false;
        }
        #endregion

        #region "UCDataButton & Button Generate"
        /// <summary>
        /// btnGenerate_Click
        /// </summary>        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bool bResult = true;
            try
            {
                //1. Update Module                 
                ModulesCollection moduleCollection = new ModulesCollection();
                ModuleService moduleBS = new ModuleService();
                foreach (ModuleType moduleType in Enum.GetValues(typeof(ModuleType)))
                {
                    Modules objModule = new Modules();
                    objModule.ModuleID = (int)moduleType;                    
                    objModule.ModuleName = GetModuleTypeName.GetString(moduleType);

                    moduleCollection.Add(objModule);
                    //moduleBS.InsertOrUpdate(objModule);
                }
                //End

                //2. Update Authorization
                //bResult = clsSecurityManager.CheckAllAssemblies();
                bResult = SecurityManager.CheckAllAssemblies(moduleCollection);

                //Refresh Authorization Collection by setting is null
                AuthorizationsService.AuthorizationCollection = null;

                //Refresh Functions List
                treFunctionGroup.Nodes.Clear();
                DisplayFunctionGroups();
                DisplayMethodDescription();
            }
            catch
            {
                bResult = false;
            }

            Cursor = Cursors.Default;
            if (bResult)                
                clsCommon.SaveSuccessfully();
            else
                //MessageBoxExLib.MessageBoxEx.Show(ResourceManager.GetString("Common", "UpdateFailed"), MessageBoxButtons.OK, MessageBoxExLib.MessageBoxExIcon.Error);
                clsCommon.SaveNotSuccessfully();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {            
            if (tnGroupSelectedNode == null) return;

            //Clear ListView
            ClearLists();

            VisibleButtons(true);

            //Store currentAuthRoleCollection in List to check the changes during modifying mode
            foreach (GroupAuthorization authRole in currentGroupAuthorizationCollection)
                listAuthID.Add(authRole.AuthorizationID);

            //Get groupID
            groupID = (Guid)treGroup.SelectedNode.Tag;

            //If application in DEBUG Mode => Show Generate button
            btnGenerate.Visible = clsCommon.IsAdminUser && SecurityManager.IsDebugMode;

            //test
            btnGenerate.Visible = true;
        }

        /// <summary>
        /// ucDataButton1_SaveHandler
        /// </summary>
        private void ucDataButton1_SaveHandler()
        {
            if (IsDataChanged())
                SaveData();
            else
                ucDataButton1.DataMode = DataState.View;

            //2008/10/20
            btnGenerate.Visible = false;
            //End
        }

        /// <summary>
        /// ucDataButton1_CancelHandler
        /// </summary>
        private void ucDataButton1_CancelHandler()
        {
            VisibleButtons(false);

            //2008/10/20
            btnGenerate.Visible = false;
            //End

            ucDataButton1.DataMode = DataState.View;

            //Refresh Current AuthorizationCollection
            currentGroupAuthorizationCollection = new GroupAuthorizationService().GetGroupAuthorizationCollectionByGroupID((Guid)tnGroupSelectedNode.Tag);
            UpdateAuthorizationCount();

            //Set CurrentRolID in case of New Mode
            groupID = (Guid)tnGroupSelectedNode.Tag;

            //Restore ListView's state
            isProgrammingCheckedListView = true;
            for (int intIndex = 0; intIndex < lstMethod.Items.Count; intIndex++)
                lstMethod.Items[intIndex].Checked = IsCheckedMethod(groupID, (Guid)lstMethod.Items[intIndex].Tag);
            isProgrammingCheckedListView = false;

            //Cancel Menu
            CancelMenu();
            //End
        }

        /// <summary>
        /// ucDataButton1_CloseHandler
        /// </summary>
        private void ucDataButton1_CloseHandler()
        {            
            this.Close();
        }

        /// <summary>
        /// btnMultiLanguage_Click
        /// </summary>        
        private void btnMultiLanguage_Click(object sender, EventArgs e)
        {            
        }
        #endregion

        /// <summary>
        /// chkAll_CheckedChanged
        /// </summary>        
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (bIsAutoCheck) return;

            bIsClickCheckAll = true;
            if (chkAll.Checked)
                nCheckedItemsCount = lstMethod.Items.Count;
            else
                nCheckedItemsCount = 0;

            for (int i = 0; i < lstMethod.Items.Count; i++)
            {
                lstMethod.Items[i].Checked = chkAll.Checked;
            }

            bIsClickCheckAll = false;
        }
    }
}

