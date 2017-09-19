
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
    public partial class frmDotXetTuyen : frmBase
    {
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        DotXetTuyenService dotXetTuyenBS = new DotXetTuyenService();

        #region "Form Events"
        public frmDotXetTuyen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvDotXetTuyen.AutoGenerateColumns = false;

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
            ucDataButton1.AddNewVisible = dotXetTuyenBS.IsAuthorized(DotXetTuyenService.DotXetTuyenAction.Insert);
            ucDataButton1.EditVisible = dotXetTuyenBS.IsAuthorized(DotXetTuyenService.DotXetTuyenAction.Update);
            ucDataButton1.DeleteVisible = dotXetTuyenBS.IsAuthorized(DotXetTuyenService.DotXetTuyenAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
            DotXetTuyenCollection dotXetTuyenCollection = dotXetTuyenBS.GetListDotXetTuyen() ;
            dgvDotXetTuyen.DataSource = dotXetTuyenCollection;
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
            txtMaDot.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmMaDot.Name].Value.ToString();
            txtTenDot.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmTenDot.Name].Value.ToString();
            txtNam.Text = dgvDotXetTuyen.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
           dtpStart.Value = (DateTime)dgvDotXetTuyen.SelectedRows[0].Cells[clmNgayBD.Name].Value;
           dtpEnd.Value = (DateTime)dgvDotXetTuyen.SelectedRows[0].Cells[clmNgaKT.Name].Value;
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            txtMaDot.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtTenDot.Clear();
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            if (txtMaDot.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã đợt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNam.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập năm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else {
                if (!clsCommon.IsNumber(txtNam.Text.Trim())) {
                    MessageBox.Show("Năm phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
           
            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
            txtMaDot.Enabled = bln;
            txtNam.Enabled = bln;
            dtpEnd.Enabled = bln;
            dtpStart.Enabled = bln;
            txtTenDot.Enabled = bln;
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                DataGridViewRow modifiedRow = dgvDotXetTuyen.SelectedRows[0];

                if (modifiedRow.Cells[clmMaDot.Name].Value.ToString() != txtMaDot.Text.Trim()
                    || modifiedRow.Cells[clmNam.Name].Value.ToString() != txtNam.Text.Trim())
                    return true;

            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                if (txtMaDot.Text.Trim() != string.Empty
                    || txtNam.Text.Trim() != string.Empty)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {
         

                DotXetTuyen objDotXetTuyen = new DotXetTuyen();
                string madot = "";
                bool blnResult = false;

                objDotXetTuyen.MaDot = txtMaDot.Text.Trim();
                objDotXetTuyen.Nam = Int32.Parse(txtNam.Text.Trim());
                objDotXetTuyen.NgayBD = dtpStart.Value;
                objDotXetTuyen.NgayKT = dtpEnd.Value;
                objDotXetTuyen.TenDot = txtTenDot.Text.Trim();

                if (ucDataButton1.DataMode == DataState.Insert)
                {


                    blnResult = dotXetTuyenBS.Insert(objDotXetTuyen);
                }
                else
                {
                    DataGridViewRow modifiedRow = dgvDotXetTuyen.SelectedRows[0];
                    madot = modifiedRow.Cells[clmMaDot.Name].Value.ToString();
                    objDotXetTuyen.MaDot = madot;
                    objDotXetTuyen.Nam = Int32.Parse(modifiedRow.Cells[clmNam.Name].Value.ToString());


                    blnResult = dotXetTuyenBS.Update(objDotXetTuyen);
                }

                if (blnResult)
                {
                    clsCommon.SaveSuccessfully();

                    //If user is closing form.
                    if (blnIsClosing) return;

                    SetDataSource();

                    //Set selected row
                    for (int i = 0; i < dgvDotXetTuyen.RowCount; i++)
                    {
                        if (dgvDotXetTuyen.Rows[i].Cells[clmMaDot.Name].Value.ToString() == madot)
                        {
                            dgvDotXetTuyen.CurrentCell = dgvDotXetTuyen.Rows[i].Cells[1];
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

            txtMaDot.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            dtpStart.Enabled = true;
            dtpEnd.Enabled = true;
            txtTenDot.Enabled = true;
            txtTenDot.Focus();
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

            for (int i = 0; i < dgvDotXetTuyen.SelectedRows.Count; i++)
            {

                string sMadot = dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                string sNam = dgvDotXetTuyen.SelectedRows[i].Cells[clmNam.Name].Value.ToString();
                string sql = string.Format("Select * From t_NganhXetTuyen Where Madot = N'{0}' AND Nam = {1}",sMadot,sNam);
                string sql2 = string.Format("Select * From  t_CongThuc Where Madot = N'{0}' AND Nam = {1}", sMadot, sNam);
                if (dotXetTuyenBS.FinDotXetTuyen(sql).Rows.Count > 0 || dotXetTuyenBS.FinDotXetTuyen(sql2).Rows.Count>0)
                {
                    //Admin group is not allowed to delete
                    MessageBox.Show(string.Format("Đợt xét tuyển [{0}] đang được sử dụng không được phép xoá.", dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            for (int i = 0; i < dgvDotXetTuyen.SelectedRows.Count; i++)
            {
                string sMadot = dgvDotXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                int iNam =int.Parse( dgvDotXetTuyen.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                dotXetTuyenBS.Delete(sMadot, iNam);
            }

            SetDataSource();
            if (dgvDotXetTuyen.RowCount > 0)
            {
                dgvDotXetTuyen.CurrentCell = null;

                dgvDotXetTuyen.CurrentCell = dgvDotXetTuyen.Rows[0].Cells[1];
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
                if (dgvDotXetTuyen.SelectedRows.Count > 0)
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
            if (blnIsDataBinding || dgvDotXetTuyen.SelectedRows.Count == 0) return;

            DisplayText();     
        }

      

                     
    }
}

