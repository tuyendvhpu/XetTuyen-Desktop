
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
    public partial class frmHistory : frmBase
    {
        bool blnIsDataBinding = true;
       // bool blnIsClosing = false;
        AudidService audidBS = new AudidService();
        private Dictionary<string, string> actionDict;
        #region "Form Events"
        public frmHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvAudid.AutoGenerateColumns = false;

            actionDict = new Dictionary<string, string>();

            actionDict.Add("All", "All");
            //actionDict.Add("Insert", "Insert");
            actionDict.Add("Update", "Update");
            actionDict.Add("Delete", "Delete");
            cmbThaoTac.DataSource = new BindingSource(actionDict, null); ;

            cmbThaoTac.DisplayMember = "value";
            cmbThaoTac.ValueMember = "key";
            cmbThaoTac.SelectedValue = "All";

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
            //ucDataButton1.AddNewVisible = dotXetTuyenBS.IsAuthorized(DotXetTuyenService.DotXetTuyenAction.Insert);
            //ucDataButton1.EditVisible = dotXetTuyenBS.IsAuthorized(DotXetTuyenService.DotXetTuyenAction.Update);
            ucDataButton1.DeleteVisible = audidBS.IsAuthorized(AudidService.AudidAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
            string sql = "Select * From t_Audid";
            sql += string.Format(" Where TableName like N'%{0}%'  AND Changed_By like '%{1}%'", txtTenBang.Text.Trim(),txtNguoiSua.Text.Trim());
            if (cmbThaoTac.SelectedValue.ToString() != "All")
            {
                sql += string.Format("AND  action ='{0}' ", cmbThaoTac.SelectedValue.ToString());
            }
            sql += string.Format(" AND Changed_Date ='{0}'",dtpNgaySua.Value.ToString());
            sql += " Order by Changed_Date DESC";
            dgvAudid.DataSource = audidBS.FinAudid(sql) ;
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
           // txtMaDot.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmMaDot.Name].Value.ToString();
           // txtTenDot.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmTenDot.Name].Value.ToString();
           // txtNam.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
           //dtpStart.Value = (DateTime)dgvDotXetTuyen.SelectedRows[0].Cells[clmNgayBD.Name].Value;
           //dtpEnd.Value = (DateTime)dgvDotXetTuyen.SelectedRows[0].Cells[clmNgaKT.Name].Value;
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            //txtMaDot.Text = string.Empty;
            //txtNam.Text = string.Empty;
            //txtTenDot.Clear();
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            //if (txtMaDot.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Bạn chưa nhập mã đợt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //if (txtNam.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Bạn chưa nhập năm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //else {
            //    if (!clsCommon.IsNumber(txtNam.Text.Trim())) {
            //        MessageBox.Show("Năm phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
           
            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
           // txtTenBang.Enabled = bln;
           // txtNguoiSua.Enabled = bln;
            //dtpNgaySua.Enabled = bln;
            
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                //DataGridViewRow modifiedRow = dgvDotXetTuyen.SelectedRows[0];

                //if (modifiedRow.Cells[clmMaDot.Name].Value.ToString() != txtTenBang.Text.Trim()
                //    || modifiedRow.Cells[clmNam.Name].Value.ToString() != txtNam.Text.Trim())
                //    return true;

            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                //if (txtTenBang.Text.Trim() != string.Empty
                //    || txtNam.Text.Trim() != string.Empty)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {
         

                
           
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

            txtTenBang.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            dtpNgaySua.Enabled = true;
           
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

            //for (int i = 0; i < dgvAudid.SelectedRows.Count; i++)
            //{

            //    //string sMadot = dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
            //    //string sNam = dgvDotXetTuyen.SelectedRows[i].Cells[clmNam.Name].Value.ToString();
            //    //string sql = string.Format("Select * From t_NganhXetTuyen Where Madot = N'{0}' AND Nam = {1}",sMadot,sNam);
            //    //string sql2 = string.Format("Select * From  t_CongThuc Where Madot = N'{0}' AND Nam = {1}", sMadot, sNam);
            //    //if (dotXetTuyenBS.FinDotXetTuyen(sql).Rows.Count > 0 || dotXetTuyenBS.FinDotXetTuyen(sql2).Rows.Count>0)
            //    //{
            //    //    //Admin group is not allowed to delete
            //    //    MessageBox.Show(string.Format("Đợt xét tuyển [{0}] đang được sử dụng không được phép xoá.", dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //    return;
            //    //}
            //}
            Audid objAudid = new Audid();
            for (int i = 0; i < dgvAudid.SelectedRows.Count; i++)
            {
                objAudid.Action = dgvAudid.SelectedRows[i].Cells[clmAction.Name].Value.ToString();
                objAudid.ChangedBy = dgvAudid.SelectedRows[i].Cells[clmChanged_By.Name].Value.ToString();
                objAudid.ChangedDate = (DateTime) dgvAudid.SelectedRows[i].Cells[clmChanged_Date.Name].Value;
                objAudid.ColumnName = dgvAudid.SelectedRows[i].Cells[clmColumnName.Name].Value.ToString();
                objAudid.NewValue = dgvAudid.SelectedRows[i].Cells[clmNew_Value.Name].Value.ToString();
                objAudid.OldValue = dgvAudid.SelectedRows[i].Cells[clmOld_Value.Name].Value.ToString();
                objAudid.RowID = dgvAudid.SelectedRows[i].Cells[clmRow_ID.Name].Value.ToString();
                objAudid.TableName = dgvAudid.SelectedRows[i].Cells[clmTableName.Name].Value.ToString();

                audidBS.Delete(objAudid);
                
                //string sMadot = dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                //int iNam =int.Parse( dgvDotXetTuyen.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                //dotXetTuyenBS.Delete(sMadot, iNam);
            }

            SetDataSource();
            if (dgvAudid.RowCount > 0)
            {
                dgvAudid.CurrentCell = null;

                dgvAudid.CurrentCell = dgvAudid.Rows[0].Cells[1];
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
                if (dgvAudid.SelectedRows.Count > 0)
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
            if (IsDataOK())
            {
                SaveData();

                EnableControls(false);
            }
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
            if (blnIsDataBinding || dgvAudid.SelectedRows.Count == 0) return;

            DisplayText();     
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            blnIsDataBinding = true;
            string sql = "Select * From t_Audid";
            sql += " Order by Changed_Date DESC";
          
            dgvAudid.DataSource = audidBS.FinAudid(sql);
            blnIsDataBinding = false;
        }

                     
    }
}

