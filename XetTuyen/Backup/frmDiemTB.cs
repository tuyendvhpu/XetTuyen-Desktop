
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
    public partial class frmDiemTB : frmBase
    {
        AlertForm alert;
        List<long> lstIDHS;
        HoSoService hoSoBS;
        //private Regex decimalRegex = null;
        private Dictionary<string, string> nganhDict;
        #region "Form Events"
        public frmDiemTB()
        {

            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {

            SetDataSource();

            nganhDict = new Dictionary<string, string>();
            nganhDict.Add("C", "Cao đẳng");
            nganhDict.Add("ĐH", "Đại học");

            cmbHeXetTuyen.DataSource = new BindingSource(nganhDict, null);
            cmbHeXetTuyen.DisplayMember = "value";
            cmbHeXetTuyen.ValueMember = "key";
            cmbHeXetTuyen.SelectedValue = "ĐH";

            LoadData();
            txtNam.Text = DateTime.Now.Year.ToString();
            EnableControls(true);

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
           // ucDataButton1.AddNewVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Insert);
            //ucDataButton1.EditVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Update);
            //ucDataButton1.DeleteVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();
            cmbHeXetTuyen.SelectedValue = 1;
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
           
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
            if (cmbNganh.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn ngành để tính.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
           
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
           
            txtNam.Enabled = bln;
            cmbNganh.Enabled = bln;
            cmbNhomNganh.Enabled = bln;
           
            cmbMaDot.Enabled = bln;
            cmbHeXetTuyen.Enabled = bln;
        }


        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {


            
           
        }
        #endregion

        private void LoadData()
        {



            int nam = DateTime.Now.Year;
            if (txtNam.Text.Length > 0 && clsCommon.IsNumber(txtNam.Text.Trim())) {
                nam =int.Parse( txtNam.Text.Trim());
            }
            DotXetTuyenService dotXetTuyenService = new DotXetTuyenService();

           DataTable dt = dotXetTuyenService.LoadByNam(nam);
            if (dt.Rows.Count > 0)
            {
                cmbMaDot.DataSource = dt;
                cmbMaDot.DisplayMember = "MaDot";
                cmbMaDot.ValueMember = "MaDot";


            }
          

        }

        #region "Button Events"
        /// <summary>
        /// ucDataButton1_InsertHandler
        /// </summary>
        private void ucDataButton1_InsertHandler()
        {
            EnableControls(true);
            ClearText();

            cmbMaDot.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            EnableControls(true);
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
           
            this.Close();
        }
        #endregion

       

        private void cmbHeXetTuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            NhomNganhService nhomNganhService = new NhomNganhService();
            string loaiNganh = " ";
            if (cmbHeXetTuyen.SelectedValue != null)
            {
                loaiNganh = cmbHeXetTuyen.SelectedValue.ToString();
            }
            //string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh =N'{0}' ", loaiNganh);
            DataTable dtNhomNganh = nhomNganhService.LoadByLoaiNganh(loaiNganh);
            DataRow dr1 = dtNhomNganh.NewRow();
            dr1[0] = "ALL"; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = "";
            dtNhomNganh.Rows.Add(dr1);
            if (dtNhomNganh.Rows.Count > 0)
            {

                cmbNhomNganh.DataSource = dtNhomNganh;
                cmbNhomNganh.DisplayMember = "TenNganh";
                cmbNhomNganh.ValueMember = "MaNganh";


            }
            cmbNhomNganh.SelectedValue = "ALL";
        }

        private void cmbNhomNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            string maNganh = "";
            NganhService nganhService = new NganhService();
            if (cmbNhomNganh.SelectedValue != null)
                maNganh = cmbNhomNganh.SelectedValue.ToString();
            //MessageBox.Show(maNganh);
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {



                DataTable dt1 = nganhService.LoadNganh(maNganh, nam);
                ////MessageBox.Show(dt.Rows.Count.ToString());
                DataRow dr1 = dt1.NewRow();
                dr1[0] = "ALL"; dr1[1] = ""; dr1[2] = ""; dr1[3] = nam.ToString(); dr1[4] = "ALL";
                dt1.Rows.Add(dr1);
                cmbNganh.DataSource = dt1;

                cmbNganh.DisplayMember = "TenNganh";
                cmbNganh.ValueMember = "IDNganh";
                cmbNganh.SelectedValue = "ALL";

                

            }
        }

        private void cmbNganh_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }


        // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                bw.CancelAsync();
                // Close the AlertForm
                alert.Close();
            }
        }
        private void btnTinhDiemTB_Click(object sender, EventArgs e)
        {
            if (IsDataOK())
            {
                NganhXetTuyenService nganhXetTuyenBS = new NganhXetTuyenService();
                NhomNganhService nhomNganhBS = new NhomNganhService();
                 hoSoBS = new HoSoService();
                long idHS = 0;
                lstIDHS = new List<long>();

                DataTable dt;
                if (cmbNhomNganh.SelectedValue.ToString() == "ALL")
                {
                    string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh = N'{0}'", cmbHeXetTuyen.SelectedValue.ToString());
                    DataTable dtNhomNganh = nhomNganhBS.FinNhomNganh(sqlNhomNganh);
                    if (dtNhomNganh.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtNhomNganh.Rows.Count; i++)
                        {
                            string sqlHoSo = string.Format("Select idhs From T_NganhXetTuyen Where MaNganh = N'{0}' AND Nam = {1} AND MaDot = N'{2}' ", dtNhomNganh.Rows[i]["MaNganh"].ToString(), txtNam.Text.Trim(), cmbMaDot.SelectedValue.ToString());
                            // MessageBox.Show(sqlHoSo);

                            dt = nganhXetTuyenBS.FinNganhXetTuyen(sqlHoSo);
                            if (dt.Rows.Count > 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    idHS = long.Parse(dt.Rows[j]["idHS"].ToString());

                                    if (!lstIDHS.Contains(idHS))
                                        lstIDHS.Add(idHS);

                                }
                            }

                        }
                    }

                }
                else
                {
                    if (cmbNganh.SelectedValue.ToString() == "ALL")
                    {
                        string sqlHoSo = string.Format("Select idhs From T_NganhXetTuyen Where MaNganh = N'{0}' AND Nam = {1} AND MaDot = N'{2}' ", cmbNhomNganh.SelectedValue.ToString(), txtNam.Text.Trim(), cmbMaDot.SelectedValue.ToString());
                        dt = nganhXetTuyenBS.FinNganhXetTuyen(sqlHoSo);
                        if (dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                idHS = long.Parse(dt.Rows[j]["idHS"].ToString());

                                if (!lstIDHS.Contains(idHS))
                                    lstIDHS.Add(idHS);

                            }
                        }
                    }
                    else
                    {
                        string sqlHoSo = string.Format("Select idhs From T_NganhXetTuyen Where IDNganh = N'{0}' AND Nam = {1} AND MaDot = N'{2}' ", cmbNganh.SelectedValue.ToString(), txtNam.Text.Trim(), cmbMaDot.SelectedValue.ToString());
                        dt = nganhXetTuyenBS.FinNganhXetTuyen(sqlHoSo);
                        if (dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                idHS = long.Parse(dt.Rows[j]["idHS"].ToString());

                                if (!lstIDHS.Contains(idHS))
                                    lstIDHS.Add(idHS);

                            }
                        }
                    }
                }
            if (bw.IsBusy != true)
            {
                // create a new instance of the alert form
                alert = new AlertForm(lstIDHS.Count);
                // event handler for the Cancel button in AlertForm
                alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                alert.Show();
                // Start the asynchronous operation.
                bw.RunWorkerAsync();
            }

           
                
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
         BackgroundWorker worker = sender as BackgroundWorker;


         
         int heso = 2;
         if (Utilities.loadCompany())
         {
             heso = Utilities.acCompConfig.so;
         }
        
        
         for(int w=0;w<lstIDHS.Count;w++)
         {
             if ((worker.CancellationPending == true))
             {
                 e.Cancel = true;
                 break;
             }
             else
             {
                 // Perform a time consuming operation and report progress.
                 hoSoBS.UpdateDiemTB(lstIDHS[w], heso);

                 worker.ReportProgress(w);
                
               
             }
            
         }


         

           
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
          //  labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            alert.Message = "In progress of " + lstIDHS.Count + " records, please wait... " + e.ProgressPercentage.ToString() + " record";
            alert.ProgressValue = e.ProgressPercentage;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Đã thoát!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Có lỗi: "+ e.Error.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đã cập nhật điểm trung bình.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Close the AlertForm
            alert.Close();
        }

        private void frmDiemTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bw.IsBusy == true)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bw.WorkerSupportsCancellation == true)
                    {
                        // Cancel the asynchronous operation.
                        bw.CancelAsync();
                        // Close the AlertForm

                        alert.Close();
                    }
                    e.Cancel = false;
                }
                else {
                    e.Cancel = true;
                }
            }
        }

                     
    }
}

