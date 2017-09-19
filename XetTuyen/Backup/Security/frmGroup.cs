
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
    public partial class frmGroup : frmBase
    {
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        GroupsService groupBS = new GroupsService();

        #region "Form Events"
        public frmGroup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvGroup.AutoGenerateColumns = false;

            SetDataSource();
            
            EnableControls(false);

            SetAuthorization();
        }

        /// <summary>
        /// frmGroup_Shown
        /// </summary>        
        private void frmGroup_Shown(object sender, EventArgs e)
        {
            //blnIsDataBinding = false;
        }
        #endregion

        #region "Functions"
        /// <summary>
        /// SetAuthorization
        /// </summary>
        private void SetAuthorization()
        {
            ucDataButton1.AddNewVisible = groupBS.IsAuthorized(GroupsService.GroupAction.Insert);
            ucDataButton1.EditVisible = groupBS.IsAuthorized(GroupsService.GroupAction.Update);
            ucDataButton1.DeleteVisible = groupBS.IsAuthorized(GroupsService.GroupAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
            GroupCollection groupCollection = groupBS.GetListGroup();
            dgvGroup.DataSource = groupCollection;
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
            txtGroupName.Text = dgvGroup.SelectedRows[0].Cells[clmGroupName.Name].Value.ToString();
            txtNote.Text = dgvGroup.SelectedRows[0].Cells[clmNote.Name].Value.ToString();
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            txtGroupName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtGroupName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập nhóm người dùng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
            txtGroupName.Enabled = bln;
            txtNote.Enabled = bln;            
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                DataGridViewRow modifiedRow = dgvGroup.SelectedRows[0];

                if (modifiedRow.Cells[clmGroupName.Name].Value.ToString() != txtGroupName.Text.Trim()
                    || modifiedRow.Cells[clmNote.Name].Value.ToString() != txtNote.Text.Trim())
                    return true;

            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                if (txtGroupName.Text.Trim() != string.Empty
                    || txtNote.Text.Trim() != string.Empty)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {
            if (IsDataOK() == false) return;

            Groups objGroup = new Groups();
            Guid groupID;
            bool blnResult = false;

            objGroup.GroupName = txtGroupName.Text.Trim();
            objGroup.Note = txtNote.Text.Trim();

            if (ucDataButton1.DataMode == DataState.Insert)
            {
                groupID = Guid.NewGuid();
                objGroup.GroupID = groupID;
                objGroup.IsAdmin = false;

                blnResult = groupBS.Insert(objGroup);
            }
            else
            {
                DataGridViewRow modifiedRow = dgvGroup.SelectedRows[0];

                groupID = (Guid)modifiedRow.Cells[clmGroupID.Name].Value;
                objGroup.GroupID = groupID;
                objGroup.IsAdmin = (bool)modifiedRow.Cells[clmIsAdmin.Name].Value; ;

                blnResult = groupBS.Update(objGroup);
            }

            if (blnResult)
            {                
                clsCommon.SaveSuccessfully();

                //If user is closing form.
                if (blnIsClosing) return;

                SetDataSource();

                //Set selected row
                for (int i = 0; i < dgvGroup.RowCount; i++)
                {
                    if ((Guid)dgvGroup.Rows[i].Cells[clmGroupID.Name].Value == groupID)
                    {
                        dgvGroup.CurrentCell = dgvGroup.Rows[i].Cells[1];
                        break;
                    }
                }

                ucDataButton1.DataMode = DataState.View;
               
            }
            else
            {
                clsCommon.SaveNotSuccessfully();
                return;
            }
        }
        #endregion

        #region "Button Events"
        /// <summary>
        /// ucDataButton1_InsertHandler
        /// </summary>
        private void ucDataButton1_InsertHandler()
        {
            EnableControls(true);
            ClearText();

            txtGroupName.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            EnableControls(true);            

            txtGroupName.Focus();
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

            for (int i = 0; i < dgvGroup.SelectedRows.Count; i++)
            {
                if((bool)dgvGroup.SelectedRows[i].Cells[clmIsAdmin.Name].Value)
                {
                    //Admin group is not allowed to delete
                    MessageBox.Show(string.Format("Nhóm [{0}] là nhóm quản trị bạn không được phép xoá.", dgvGroup.SelectedRows[i].Cells[clmGroupName.Name].Value.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            for (int i = 0; i < dgvGroup.SelectedRows.Count; i++)
            {
                groupBS.Delete((Guid)dgvGroup.SelectedRows[i].Cells[clmGroupID.Name].Value);
            }

            SetDataSource();
            if (dgvGroup.RowCount > 0)
            {
                dgvGroup.CurrentCell = null;

                dgvGroup.CurrentCell = dgvGroup.Rows[0].Cells[1];
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
            }
            else
            {
                if (dgvGroup.SelectedRows.Count > 0)
                    DisplayText();
                else
                    ClearText();
            }

            EnableControls(false); 
        }

        /// <summary>
        /// ucDataButton1_SaveHandler
        /// </summary>
        private void ucDataButton1_SaveHandler()
        {
            SaveData();

            EnableControls(false);
        }

        /// <summary>
        /// ucDataButton1_CloseHandler
        /// </summary>
        private void ucDataButton1_CloseHandler()
        {
            if (IsChangedData() && clsCommon.ConfirmChangedData() == DialogResult.Yes)
            {
                SaveData();
            }

            this.Close();
        }
        #endregion

        /// <summary>
        /// dgvGroup_SelectionChanged
        /// </summary>        
        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (blnIsDataBinding || dgvGroup.SelectedRows.Count == 0) return;

            DisplayText();     
        }

                     
    }
}

