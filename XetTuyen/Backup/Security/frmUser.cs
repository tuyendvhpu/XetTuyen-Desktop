using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using DataAccess;
using BusinessLogic;
using BusinessService;
namespace XetTuyen
{
    public partial class frmUser : frmBase
    {
        #region "Variables"
        private UsersService userBS;
        private GroupsService groupBS;
        private Users objSelectedUser;
        private UserCollection userCollection;
        private GroupUserService groupUserBS;
        private List<GroupUser> lstInitialGroupUser = new List<GroupUser>();
        private List<GroupUser> lstAddedGroupUser = new List<GroupUser>();
        private List<GroupUser> lstDeletedGroupUser = new List<GroupUser>();

        private bool bIsBindingData = true;
        private bool bIsClosed = false;
        private DateTime dtmNow;
        private DateTime dtmMaxDate = new DateTime(9999, 12, 31);
        #endregion
        #region "Form's Events"
        public frmUser()
        {
            InitializeComponent();
        }
       

        private void frmUser_Load(object sender, EventArgs e)
        {
            userBS = new UsersService();
            groupBS = new GroupsService();
            groupUserBS = new GroupUserService();
            grdUserList.AutoGenerateColumns = false;
            
            SetGridViewDataSource();
            SetDataForCheckListGroup();
            EnableControls(false);
            SetAuthorization();
        }

        /// <summary>
        /// frmUser_AfterChangeLanguageHandler
        /// </summary>        
        private void frmUser_AfterChangeLanguageHandler(object sender, EventArgs e)
        {
            chkLstGroup.Items.Clear();
            SetDataForCheckListGroup();
            SetCheckedGroupsForSelectedUser();
        }


        /// <summary>
        /// frmUser_Shown
        /// </summary>        
        private void frmUser_Shown(object sender, EventArgs e)
        {
            bIsBindingData = false;
            EnableControls(false);

            if (grdUserList.RowCount > 0)
            {
                grdUserList.ClearSelection();
                grdUserList.Rows[0].Selected = true;
            }
        }
        #endregion

        #region "Functions"
        /// <summary>
        /// SetGridViewDataSource
        /// </summary>
        private void SetGridViewDataSource()
        {
            userCollection = userBS.GetListUser();
            grdUserList.DataSource = userCollection;
        }
        /// <summary>
        /// SetAuthorization
        /// </summary>
        private void SetAuthorization()
        {
            ucDataButton1.AddNewVisible = userBS.IsAuthorized(UsersService.UserAction.Insert);
            ucDataButton1.EditVisible = userBS.IsAuthorized(UsersService.UserAction.Update);
            ucDataButton1.DeleteVisible = userBS.IsAuthorized(UsersService.UserAction.Delete);
           //ucDataButton1.MultiLanguageVisible = userBS.IsAuthorized(clsUserBS.UserAction.MultilangUI);
        }

        /// <summary>
        /// Set Data For CheckList Group
        /// </summary>
        private void SetDataForCheckListGroup()
        {
            string sText = string.Empty;
            GroupCollection groupCollection = groupBS.GetListGroup();
            foreach (Groups group in groupCollection)
            {
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Text = group.GroupName;
                item.Tag = group;
                chkLstGroup.Items.Add(item);

                if (sText.Length < item.Text.Length)
                    sText = item.Text;
            }

            SizeF stringSize = new SizeF();
            Graphics g = this.CreateGraphics();
            stringSize = g.MeasureString(sText, chkLstGroup.Font);
            chkLstGroup.ColumnWidth = (int)stringSize.Width + 20;
        }
        /// <summary>
        /// ClearCheckedGroups
        /// </summary>
        private void ClearCheckedGroups()
        {
            for (int i = 0; i < chkLstGroup.Items.Count; i++)
                chkLstGroup.SetItemChecked(i, false);
        }

        /// <summary>
        /// Set Checked Groups For Selected User
        /// </summary>
        private void SetCheckedGroupsForSelectedUser()
        {
            ClearCheckedGroups();
            for (int i = 0; i < lstInitialGroupUser.Count; i++)
            {
                for (int j = 0; j < chkLstGroup.Items.Count; j++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.Items[j];

                    if (((Groups)item.Tag).GroupID == lstInitialGroupUser[i].GroupID)
                    {
                        chkLstGroup.SetItemChecked(j, true);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// GetSelectedUser
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        private Users GetSelectedUser(string sLoginID)
        {
            foreach (Users objUser in userCollection)
            {
                if (objUser.LoginID == sLoginID)
                    return objUser;
            }

            return null;
        }

        /// <summary>
        /// IsUserNameExists
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        private bool IsUserNameExists(string sLoginID)
        {
            foreach (Users objUser in userCollection)
            {
                if (objUser.LoginID.ToLower() == sLoginID)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
            if (objSelectedUser != null)
            {
                txtUserName.Text = objSelectedUser.LoginID;
                txtPassword.Text = objSelectedUser.Password;
                txtEmployeeName.Text = objSelectedUser.FullName;
                txtEmail.Text = objSelectedUser.Email;
                chkLocked.Checked = objSelectedUser.LockedUser;
                txtLockedReason.Text = objSelectedUser.LockedReason;
                dtpBrithDay.Value = objSelectedUser.BirthDay;
                cmbGender.Text = objSelectedUser.Gender;

                if (objSelectedUser.DeadlineOfUsing == dtmMaxDate)
                    dtpEndDate.Checked = false;
                else
                {
                    dtpEndDate.Checked = true;
                    dtpEndDate.Value = objSelectedUser.DeadlineOfUsing;
                }
            }
            else
                ClearText();
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText(string sUserName)
        {
            objSelectedUser = GetSelectedUser(sUserName);
            
            DisplayText();
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            chkLocked.Checked = false;
            txtLockedReason.Text = string.Empty;
            dtpEndDate.Checked = false;
        }

        /// <summary>
        /// EnableControls
        /// </summary>
        /// <param name="bIsEnabled"></param>
        private void EnableControls(bool bIsEnabled)
        {
            if (ucDataButton1.DataMode != DataState.Edit)
                txtUserName.Enabled = bIsEnabled;
            txtPassword.Enabled = bIsEnabled;
            txtEmployeeName.Enabled = bIsEnabled;
            txtEmail.Enabled = bIsEnabled;
            chkLocked.Enabled = bIsEnabled;
            txtLockedReason.Enabled = (bIsEnabled && chkLocked.Checked);
            cmbGender.Enabled = bIsEnabled;
            dtpBrithDay.Enabled = bIsEnabled;
            dtpEndDate.Enabled = bIsEnabled;
            chkLstGroup.Enabled = bIsEnabled;
            chkLstGroup.ClearSelected();

            if (bIsEnabled)
                chkLstGroup.BackColor = Color.White;
            else
                chkLstGroup.BackColor = Color.FromName("Control");
        }

        /// <summary>
        /// Check list of initial group has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsGroupListChanged()
        {
            Groups objGroup;
            //1.1. Update Inserted Group-User List
            for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
            {
                bool bIsExists = false;
                CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                objGroup = (Groups)item.Tag;

                for (int j = 0; j < lstInitialGroupUser.Count; j++)
                {
                    if (lstInitialGroupUser[j].GroupID == objGroup.GroupID)
                    {
                        bIsExists = true;
                        break;
                    }
                }

                if (!bIsExists)
                    return true;
            }

            //1.2 Update Deleted Group-UserID List
            for (int i = 0; i < lstInitialGroupUser.Count; i++)
            {
                bool bIsExists = false;
                for (int j = 0; j < chkLstGroup.CheckedItems.Count; j++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[j];
                    objGroup = (Groups)item.Tag;
                    if (lstInitialGroupUser[i].GroupID == objGroup.GroupID)
                    {
                        bIsExists = true;
                        break;
                    }
                }

                if (!bIsExists)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check data has been changed when user close Form ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Insert)
            {
                if (txtUserName.Text.Trim().Length > 0 || txtPassword.Text.Trim().Length > 0)
                    return true;
                else
                    return false;
            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                if (objSelectedUser.Password != txtPassword.Text.Trim()
                    || objSelectedUser.FullName != txtEmployeeName.Text.Trim()
                    || objSelectedUser.Email != txtEmail.Text.Trim()
                    || objSelectedUser.LockedUser != chkLocked.Checked
                    || objSelectedUser.Gender != (string)cmbGender.SelectedItem
                    || objSelectedUser.BirthDay != dtpBrithDay.Value.Date
                    || objSelectedUser.LockedReason != txtLockedReason.Text.Trim()
                    || (dtpEndDate.Checked && objSelectedUser.DeadlineOfUsing.Date == dtpEndDate.Value.Date)
                    || (!dtpEndDate.Checked && objSelectedUser.DeadlineOfUsing.Date != dtmMaxDate.Date)
                    || IsGroupListChanged())
                    return true;
                else
                    return false;

            }

            return false;
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng.");
                txtUserName.Focus();
                return false;
            }
            if (ucDataButton1.DataMode == DataState.Insert && IsUserNameExists(txtUserName.Text.ToLower()))
            {
                MessageBox.Show("Tài khoản này đã tồn tại.");
                txtUserName.Focus();
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu.");
                txtPassword.Focus();
                return false;
            }
            if (txtEmployeeName.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên.");
                txtEmployeeName.Focus();
                return false;
            }
            if (txtEmail.Text.Trim().Length > 0 && !clsCommon.CheckEmailAddress(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Dia chi email khong hop le.");
                txtEmail.Focus();
                return false;
            }
            if (((string)cmbGender.SelectedItem ).Length==0)
            {
                MessageBox.Show("Ban hãy chọn giới tính người dùng!");
                cmbGender.Focus();
                return false;
            }
            if (chkLstGroup.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhóm người dùng.");
                chkLstGroup.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Save data into DB
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            if (IsDataOK() == false) return false;

            bool bResult = true;
            dtmNow = Utilities.GetServerTime();

            Groups objGroup;
           GroupUser objGroupUser;
            List<GroupUser> lstInsertedGroupUser = new List<GroupUser>();

            if (ucDataButton1.DataMode == DataState.Insert)
            {
                Users objUser = new Users();

                objUser.LoginID = txtUserName.Text.Trim();
                objUser.Password = txtPassword.Text.Trim();
                objUser.FullName = txtEmployeeName.Text.Trim();
                objUser.Email = txtEmail.Text.Trim();
                objUser.LockedReason = txtLockedReason.Text;
                objUser.LockedUser = chkLocked.Checked;
                objUser.CreatedDate = dtmNow;
                objUser.Gender = (string)cmbGender.SelectedItem;
                objUser.BirthDay = dtpBrithDay.Value.Date;
                if (dtpEndDate.Checked)
                    objUser.DeadlineOfUsing = dtpEndDate.Value.Date;
                else
                    objUser.DeadlineOfUsing = dtmMaxDate.Date;

                //Add User-Group                
                for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
                {
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                    objGroup = (Groups)item.Tag;

                    objGroupUser = new GroupUser();                    
                    objGroupUser.LoginID = txtUserName.Text.Trim();
                    objGroupUser.GroupID = objGroup.GroupID;                    

                    lstInsertedGroupUser.Add(objGroupUser);
                }

                bResult = userBS.Insert(objUser, lstInsertedGroupUser);
            }
            else
            {
                //1. Update List of Deleted Group-User and Inserted Group-User                
                lstAddedGroupUser.Clear();
                lstDeletedGroupUser.Clear();

                //1.1. Update Inserted Group-User List
                for (int i = 0; i < chkLstGroup.CheckedItems.Count; i++)
                {
                    bool bIsExists = false;
                    CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[i];
                    objGroup = (Groups)item.Tag;

                    for (int j = 0; j < lstInitialGroupUser.Count; j++)
                    {
                        if (lstInitialGroupUser[j].GroupID == objGroup.GroupID)
                        {
                            bIsExists = true;
                            break;
                        }
                    }

                    if (!bIsExists)
                    {
                        objGroupUser = new GroupUser();
                        objGroupUser.LoginID = txtUserName.Text.Trim();
                        objGroupUser.GroupID = objGroup.GroupID;                        

                        lstInsertedGroupUser.Add(objGroupUser);
                    }
                }

                //1.2 Update Deleted Group-UserID List
                for (int i = 0; i < lstInitialGroupUser.Count; i++)
                {
                    bool bIsExists = false;
                    for (int j = 0; j < chkLstGroup.CheckedItems.Count; j++)
                    {
                        CheckedListBoxItem item = (CheckedListBoxItem)chkLstGroup.CheckedItems[j];
                        objGroup = (Groups)item.Tag;
                        if (lstInitialGroupUser[i].GroupID == objGroup.GroupID)
                        {
                            bIsExists = true;
                            break;
                        }
                    }

                    if (!bIsExists)
                        lstDeletedGroupUser.Add(lstInitialGroupUser[i]);
                }

                //2. Update User
                objSelectedUser = userBS.GetUserByID(objSelectedUser.LoginID);
                objSelectedUser.Password = txtPassword.Text.Trim();
                objSelectedUser.FullName = txtEmployeeName.Text.Trim();
                objSelectedUser.Email = txtEmail.Text.Trim();
                objSelectedUser.LockedUser = chkLocked.Checked;
                objSelectedUser.Gender = (string)cmbGender.SelectedItem;
                objSelectedUser.BirthDay = dtpBrithDay.Value.Date;
                if (chkLocked.Checked)
                    objSelectedUser.LockedReason = txtLockedReason.Text;
                else
                    objSelectedUser.LockedReason = string.Empty;

                if (dtpEndDate.Checked)
                    objSelectedUser.DeadlineOfUsing = dtpEndDate.Value.Date;
                else
                    objSelectedUser.DeadlineOfUsing = dtmMaxDate.Date;

                bResult = userBS.Update(objSelectedUser, lstInsertedGroupUser, lstDeletedGroupUser);
            }

            if (bResult)
            {
                if (bIsClosed == false)
                {
                    bIsBindingData = true;

                    SetGridViewDataSource();

                    //Refresh lstInitialGroupUserID
                    lstInitialGroupUser = groupUserBS.GetListGroupUserByUserID(txtUserName.Text.Trim());

                    for (int i = 0; i < grdUserList.RowCount; i++)
                    {
                        if (grdUserList.Rows[i].Cells[clmUserName.Name].Value.ToString() == txtUserName.Text)
                        {
                            grdUserList.CurrentCell = grdUserList.Rows[i].Cells[0];
                            break;
                        }
                    }

                    bIsBindingData = false;
                }

                clsCommon.SaveSuccessfully();
                ucDataButton1.DataMode = DataState.View;
                ucDataButton1.SetInsertFocus();
                EnableControls(false);
            }
            else
                clsCommon.SaveNotSuccessfully();

            return bResult;
        }
        #endregion

        #region "Buttons"
        /// <summary>
        /// ucDataButton1_InsertHandler
        /// </summary>
        private void ucDataButton1_InsertHandler()
        {
            ClearText();
            ClearCheckedGroups();
            EnableControls(true);
            txtUserName.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            if (grdUserList.SelectedRows == null && grdUserList.SelectedRows.Count == 0) return;

            EnableControls(true);
            txtPassword.Focus();

            if (grdUserList.SelectedRows.Count > 1)
            {
                for (int i = 1; i < grdUserList.SelectedRows.Count; i++)
                    grdUserList.SelectedRows[i].Selected = false;
            }
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (grdUserList.SelectedRows.Count > 0)
            {
                if (clsCommon.ConfirmDeletion() == DialogResult.Yes)
                {
                    List<string> lstDeletedUserName = new List<string>();
                    List<GroupUser> lstGroupUser=new List<GroupUser>();
                    Users objUser;
                    DataGridViewSelectedRowCollection nRow = grdUserList.SelectedRows;
                    foreach (DataGridViewRow row in nRow)
                    {
                        //Add deleted user
                        objUser = userBS.GetUserByID(row.Cells[clmUserName.Name].Value.ToString());
                        if (clsCommon.CurrentUser != null && objUser.FullName == clsCommon.CurrentUser.FullName)
                        {
                            MessageBox.Show("Khong duoc xoa nguoi dung [" + objUser.LoginID + "].","Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        lstDeletedUserName.Add(objUser.LoginID);

                        //Add deleted Group-User object                        
                        lstGroupUser = groupUserBS.GetListGroupUserByUserID(objUser.LoginID);                        
                    }

                    int nIndex = grdUserList.SelectedRows[0].Index;
                    if (userBS.Delete(lstDeletedUserName, lstGroupUser))
                    {
                        bIsBindingData = true;
                        SetGridViewDataSource();
                        bIsBindingData = false;

                        //Set selected Row
                        if (grdUserList.RowCount > 0)
                        {
                            if (nRow.Count > 1)
                                nIndex = 0;
                            else if (grdUserList.RowCount <= nIndex)
                                nIndex--;

                            grdUserList.ClearSelection();
                            grdUserList.CurrentCell = grdUserList.Rows[nIndex].Cells[1];
                        }
                        else
                            objSelectedUser = null;

                        clsCommon.DeleteSuccessfully();
                    }
                    else
                        clsCommon.DeleteNotSuccessfully();
                }
            }
        }

        /// <summary>
        /// ucDataButton1_CancelHandler
        /// </summary>
        private void ucDataButton1_CancelHandler()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                DisplayText();

                SetCheckedGroupsForSelectedUser();
            }
            else
            {
                if (grdUserList.SelectedRows.Count > 0)
                {
                    DisplayText();
                    SetCheckedGroupsForSelectedUser();
                }
                else
                {
                    ClearText();
                    ClearCheckedGroups();
                }
            }

            EnableControls(false);
            ucDataButton1.DataMode = DataState.View;
        }

        /// <summary>
        /// ucDataButton1_SaveHandler
        /// </summary>
        private void ucDataButton1_SaveHandler()
        {
            SaveData();
        }

        /// <summary>
        /// ucDataButton1_CloseHandler
        /// </summary>
        private void ucDataButton1_CloseHandler()
        {
            if (IsChangedData())
            {
                if (clsCommon.ConfirmChangedData() == DialogResult.Yes)
                {
                    bIsClosed = true;
                    if (SaveData() == false)
                        return;
                }
            }



            this.Close();
        }
        #endregion

        #region "GridView and TextBoxes Events"
        /// <summary>
        /// grdUserList_SelectionChanged
        /// </summary>        
        private void grdUserList_SelectionChanged(object sender, EventArgs e)
        {
            if (bIsBindingData || grdUserList.SelectedRows.Count == 0) return;

            if (ucDataButton1.DataMode == DataState.Insert)
            {
                ucDataButton1.DataMode = DataState.View;
                EnableControls(false);
            }

            DisplayText(grdUserList.SelectedRows[0].Cells[clmUserName.Name].Value.ToString());

            //Get data from DB
            lstInitialGroupUser = groupUserBS.GetListGroupUserByUserID(txtUserName.Text.Trim());

            //Set checked for CheckedListBox
            SetCheckedGroupsForSelectedUser();
        }

        /// <summary>
        /// grdUserList_CellFormatting
        /// </summary>        
        private void grdUserList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 1 && e.Value != null)
            //    e.Value = new String('*', e.Value.ToString().Length);
        }

      
        #endregion

        /// <summary>
        /// chkLocked_CheckedChanged
        /// </summary>        
        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            if (ucDataButton1.DataMode != DataState.View)
                txtLockedReason.Enabled = chkLocked.Checked;
        }        
    }
}
