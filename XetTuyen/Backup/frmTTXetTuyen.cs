
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
using System.Text.RegularExpressions;
namespace XetTuyen
{
    public partial class frmTTXetTuyen : frmBase
    {
       
        bool blnIsDataBinding = true;
        
        string sql = "Select * From t_ThongTinXetTuyen";
        private Dictionary<string, string> nganhDict;
        #region "Form Events"
        public frmTTXetTuyen()
        {

            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvCongThuc.AutoGenerateColumns = false;

            SetDataSource();

            nganhDict = new Dictionary<string, string>();
            nganhDict.Add("Add", "Add");
            nganhDict.Add("Change", "Change");
            cmbTrangThai.DataSource = new BindingSource(nganhDict, null); ;
            cmbTrangThai.DisplayMember = "value";
            cmbTrangThai.ValueMember = "key";
            cmbTrangThai.SelectedIndex = 1;
           
            LoadData( sql);
            //EnableControls(false);

           // SetAuthorization();
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
            
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
           
          
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
            if (dgvCongThuc.RowCount > 0)
            {
                
            }
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            
            
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
           
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
           
            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {


           
        }
        #endregion

        private void LoadData(string sql)
        {



            ThongTinXetTuyenService TTXetTuyenBS = new ThongTinXetTuyenService();
             
            dgvCongThuc.DataSource = TTXetTuyenBS.FinThongTinXetTuyen(sql);





        }

        #region "Button Events"
        /// <summary>
        /// ucDataButton1_InsertHandler
        /// </summary>
        private void ucDataButton1_InsertHandler()
        {
            EnableControls(true);
            ClearText();

            
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
           // EnableControls(true);
            txtHeSo.Enabled = true;
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            
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
                if (dgvCongThuc.SelectedRows.Count > 0)
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
            if (blnIsDataBinding || dgvCongThuc.SelectedRows.Count == 0) return;

            DisplayText();     
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            sql = "Select * From t_ThongTinXetTuyen";
            if (cmbTrangThai.SelectedValue != null)
                sql += string.Format(" Where status = N'{0}' ", cmbTrangThai.SelectedValue.ToString());
            if (txtHeSo.Text.Length > 0) {
                sql += string.Format(" AND SoQD like N'%{0}%' ", txtHeSo.Text.Trim());
            }
            LoadData(sql);
        }

      
    }
}

