
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
    public partial class frmCongThuc : frmBase
    {
        AlertForm alert;
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        CongThucCollection congThucCollection;
        CongThucService congThucBS = new CongThucService();
        private Regex decimalRegex = null;
        private Dictionary<string, string> nganhDict;
        #region "Form Events"
        public frmCongThuc()
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
            nganhDict.Add("C", "Cao đẳng");
            nganhDict.Add("ĐH", "Đại học");


            cmbHeXetTuyen.DataSource = new BindingSource(nganhDict, null);
            cmbHeXetTuyen.DisplayMember = "value";
            cmbHeXetTuyen.ValueMember = "key";
            cmbHeXetTuyen.SelectedIndex = 1;
           
            LoadData();
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
            ucDataButton1.AddNewVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Insert);
            ucDataButton1.EditVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Update);
            ucDataButton1.DeleteVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
            CongThucCollection congThucCollection = congThucBS.GetListCongThuc() ;
            dgvCongThuc.DataSource = congThucCollection;
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
            if (dgvCongThuc.RowCount > 0)
            {
                cmbMaDot.SelectedValue = dgvCongThuc.SelectedRows[0].Cells[clmMaDot.Name].Value.ToString();
                txtNam.Text = dgvCongThuc.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
                cmbNhomNganh.SelectedValue = dgvCongThuc.SelectedRows[0].Cells[clmMaNganh.Name].Value;
                cmbNganh.SelectedValue = dgvCongThuc.SelectedRows[0].Cells[clmIDNganh.Name].Value;
                cmbMaKhoi.SelectedValue = dgvCongThuc.SelectedRows[0].Cells[clmMaKhoi.Name].Value;
                cmbMaMon.SelectedValue = dgvCongThuc.SelectedRows[0].Cells[clmMaMon.Name].Value;
                txtHeSo.Text = dgvCongThuc.SelectedRows[0].Cells[clmHeSo.Name].Value.ToString();
            }
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();
            txtHeSo.Text = "1";
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
            if (txtHeSo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập hệ số.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
                if (!decimalRegex.IsMatch(txtHeSo.Text.Trim()))
                {
                    MessageBox.Show("Hệ số phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            string dot = "";
            string idNganh = "";
           
            string khoi = "";
            string mon = "";
            int nam = Convert.ToInt32(txtNam.Text.Trim());
            if(cmbMaDot.SelectedValue!=null)
             dot = cmbMaDot.SelectedValue.ToString();
           
            if (cmbNganh.SelectedValue != null)
                idNganh = cmbNganh.SelectedValue.ToString();
            if (cmbMaKhoi.SelectedValue != null)
                khoi = cmbMaKhoi.SelectedValue.ToString();
            if (cmbMaMon.SelectedValue != null)
                mon = cmbMaMon.SelectedValue.ToString();
            DataTable dt = new DataTable();
            string sqlCongThuc = string.Format("Select * From t_CongThuc Where idNganh = N'{0}' And MaDot = N'{1}' And MaKhoi = N'{2}' And MaMon ={3} And Nam ={4}", idNganh, dot, khoi, mon, nam);
            dt = congThucBS.FinCongThuc(sqlCongThuc);
            if (dt.Rows.Count > 0 && ucDataButton1.DataMode == DataState.Insert)
            {
                MessageBox.Show("Ngành và khối này đã có!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
            txtHeSo.Enabled = bln;
            txtNam.Enabled = bln;
            cmbNganh.Enabled = bln;
            cmbNhomNganh.Enabled = bln;
            cmbMaMon.Enabled = bln;
            cmbMaKhoi.Enabled = bln;
            cmbMaDot.Enabled = bln;
            cmbHeXetTuyen.Enabled = bln;
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                DataGridViewRow modifiedRow = dgvCongThuc.SelectedRows[0];

                if (modifiedRow.Cells[clmMaDot.Name].Value.ToString() != cmbMaDot.SelectedValue.ToString().Trim()
                    || modifiedRow.Cells[clmNam.Name].Value.ToString() != txtNam.Text.Trim())
                    return true;

            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                if (cmbMaDot.SelectedValue != null
                    || cmbMaKhoi.SelectedValue != null)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {


            CongThuc objCongThuc = new CongThuc();
                string madot = "";
                bool blnResult = false;

                objCongThuc.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
                objCongThuc.Nam = Int32.Parse(txtNam.Text.Trim());
                objCongThuc.MaNganh = cmbNhomNganh.SelectedValue.ToString().Trim();
                objCongThuc.IDNganh = cmbNganh.SelectedValue.ToString().Trim();
                objCongThuc.MaKHoi = cmbMaKhoi.SelectedValue.ToString().Trim();
                objCongThuc.MaMon = cmbMaMon.SelectedValue.ToString().Trim();
                objCongThuc.HeSo =double.Parse(txtHeSo.Text.Trim());
                if (ucDataButton1.DataMode == DataState.Insert)
                {

                    //MessageBox.Show(objCongThuc.MaDot +"-"+ objCongThuc.MaKHoi +"-" +objCongThuc.MaMon +"-"+ objCongThuc.MaNganh +"-"+ objCongThuc.Nam.ToString() + "hs"+ objCongThuc.HeSo.ToString());
                    blnResult = congThucBS.Insert(objCongThuc);
                }
                else
                {
                    DataGridViewRow modifiedRow = dgvCongThuc.SelectedRows[0];
                    madot = modifiedRow.Cells[clmMaDot.Name].Value.ToString();



                    blnResult = congThucBS.Update(objCongThuc);
                }

                if (blnResult)
                {
                    clsCommon.SaveSuccessfully();

                    //If user is closing form.
                    if (blnIsClosing) return;

                    SetDataSource();

                    //Set selected row
                    for (int i = 0; i < dgvCongThuc.RowCount; i++)
                    {
                        if (dgvCongThuc.Rows[i].Cells[clmMaDot.Name].Value.ToString() == madot)
                        {
                            dgvCongThuc.CurrentCell = dgvCongThuc.Rows[i].Cells[1];
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
        NhomNganhService nhomNganhSV = new NhomNganhService();
            string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh =N'{0}' ", cmbHeXetTuyen.SelectedValue.ToString());
          cmbNhomNganh.DataSource = nhomNganhSV.FinNhomNganh(sqlNhomNganh);
          cmbNhomNganh.DisplayMember = "TenNganh";
          cmbNhomNganh.ValueMember = "MaNganh";





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
           // EnableControls(true);
            txtHeSo.Enabled = true;
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

                   

            for (int i = 0; i < dgvCongThuc.SelectedRows.Count; i++)
            {
                string manganh = dgvCongThuc.SelectedRows[i].Cells[clmMaNganh.Name].Value.ToString();
                string idNganh= dgvCongThuc.SelectedRows[i].Cells[clmIDNganh.Name].Value.ToString();
                string makhoi = dgvCongThuc.SelectedRows[i].Cells[clmMaKhoi.Name].Value.ToString();
                string mamon = dgvCongThuc.SelectedRows[i].Cells[clmMaMon.Name].Value.ToString();
                string madot = dgvCongThuc.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                int iNam =int.Parse( dgvCongThuc.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                congThucBS.Delete(manganh, mamon,makhoi,iNam,idNganh,madot);
            }

            SetDataSource();
            ucDataButton1.DataMode = DataState.View;
            if (dgvCongThuc.RowCount > 0)
            {
                dgvCongThuc.CurrentCell = null;

                dgvCongThuc.CurrentCell = dgvCongThuc.Rows[0].Cells[1];
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

        private void cmbHeXetTuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbHeXetTuyen.SelectedValue != null)
            {
                NhomNganhService nhomNganhSV = new NhomNganhService();
                string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh =N'{0}' ", cmbHeXetTuyen.SelectedValue.ToString());
                cmbNhomNganh.DataSource = nhomNganhSV.FinNhomNganh(sqlNhomNganh);
                cmbNhomNganh.DisplayMember = "TenNganh";
                cmbNhomNganh.ValueMember = "MaNganh";
            }
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

                cmbNganh.DataSource = dt1;

                cmbNganh.DisplayMember = "TenNganh";
                cmbNganh.ValueMember = "IDNganh";


                

            }
        }

        private void cmbNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            NganhService nganhService = new NganhService();
            string idNganh = "";
            if (cmbNganh.SelectedValue != null)
                idNganh = cmbNganh.SelectedValue.ToString();
            //MessageBox.Show(maNganh);
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {





                DataTable dt2 = nganhService.LoadIDNganh(idNganh, nam);

                cmbMaKhoi.DataSource = dt2;
                //MessageBox.Show(maNganh);
                cmbMaKhoi.DisplayMember = "MaKhoi";
                cmbMaKhoi.ValueMember = "MaKhoi";

            }
        }

        private void cmbMaKhoi_SelectedValueChanged(object sender, EventArgs e)
        {
            KhoiMonService khoiMonService = new KhoiMonService();
            string makhoi = "";
            if (cmbMaKhoi.SelectedValue != null)
                makhoi = cmbMaKhoi.SelectedValue.ToString();
            //MessageBox.Show(maNganh);
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {


                string sqlKhoiMon = string.Format("Select RTRIM(km.MaMon) as MaMon, RTRIM(m.TenMon) as TenMon From T_KhoiMon as km join t_MonXT as m on m.MaMon = km.MaMon where km.Nam = {0} And km.MaKHoi = N'{1}' ", txtNam.Text.ToString().Trim(), makhoi);

                cmbMaMon.DataSource = khoiMonService.FinKhoiMon(sqlKhoiMon);
                //MessageBox.Show(maNganh);
                cmbMaMon.DisplayMember = "TenMon";
                cmbMaMon.ValueMember = "MaMon";

            }
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
            
             congThucCollection = congThucBS.GetListCongThuc();

             if (bw.IsBusy != true)
             {
                 // create a new instance of the alert form
                 alert = new AlertForm(congThucCollection.Count);
                 // event handler for the Cancel button in AlertForm
                 alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                 alert.Show();
                 // Start the asynchronous operation.
                 bw.RunWorkerAsync();
             }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            NganhXetTuyenService nganhXetTuyenBS = new NganhXetTuyenService();
            HoSoService hoSoBS = new HoSoService();
            DataTable dt;
            long idHS = 0;
            for (int w = 0; w < congThucCollection.Count;w++ )
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    dt = nganhXetTuyenBS.LoadByIDNganh(congThucCollection[w].MaNganh, congThucCollection[w].IDNganh, congThucCollection[w].MaDot, congThucCollection[w].Nam);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            idHS = long.Parse(dt.Rows[i]["idHS"].ToString());

                            hoSoBS.UpdateDiemTB(idHS);

                        }
                    }

                    worker.ReportProgress(w);


                }

            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            //  labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            alert.Message = "In progress of " + congThucCollection.Count + " records, please wait... " + e.ProgressPercentage.ToString() + " record";
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
                MessageBox.Show("Có lỗi: " + e.Error.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đã cập nhật điểm trung bình.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Close the AlertForm
            alert.Close();
        }

        private void frmCongThuc_FormClosing(object sender, FormClosingEventArgs e)
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
                else
                {
                    e.Cancel = true;
                }
            }
        }

                     
    }
}

