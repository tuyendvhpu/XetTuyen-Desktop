
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
using System.IO;
using XetTuyen.Report;
using System.Data.Odbc;
using Office_12 = Microsoft.Office.Core;
using Excel_12 = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace XetTuyen
{
    public partial class frmXetTuyen : frmBase
    {
        bool blnIsDataBinding = true;
        AlertForm alert;
        DataTable dtHoSoXT = null;
        HoSoService hoSoBS;
       
        string sql = "";
    
        private Dictionary<string, string> nganhDict;
        private Dictionary<string, string> soSanhDict;
        #region "Form Events"
        public frmXetTuyen()
        {

            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvHoSo.AutoGenerateColumns = false;
            hoSoBS = new HoSoService();
          
            sql = "Select hs.* FROM v_HoSoChiTiet as hs, t_DieuKien as dk where hs.idNganh = dk.IDNganh AND hs.MaDot = dk.MaDot AND hs.Nam = dk.Nam AND hs.MaKhoi = dk.MaKhoi AND hs.DiemTB>= dk.DiemSan AND hs.DiemTB >=dk.DiemChuan AND hs.MaHS  IS NOT NULL AND hs.TrangThai =0  AND hs.DiemTXT>hs.DiemTB  ORDER BY COALESCE(CASE WHEN 1 = IsNumeric(hs.MaHS) THEN CAST(hs.MaHS AS INT)  END,0 ) ";
            SetDataSource(sql);

            nganhDict = new Dictionary<string , string>();
           // nganhDict.Add(2, "ALL");
            nganhDict.Add("C", "Cao đẳng");
            nganhDict.Add("ĐH", "Đại học");
            nganhDict.Add("ALL", "ALL");

            cmbHeTK.DataSource = new BindingSource(nganhDict, null);
            cmbHeTK.DisplayMember = "value";
            cmbHeTK.ValueMember = "key";
            cmbHeTK.SelectedValue = "ĐH";

            cmbHe.DataSource = new BindingSource(nganhDict, null);
            cmbHe.DisplayMember = "value";
            cmbHe.ValueMember = "key";
            cmbHe.SelectedValue = "ĐH";

            NhomNganhService nhomNganhBS = new NhomNganhService();
            cmbNhomNganh.DataSource = nhomNganhBS.LoadByLoaiNganh(cmbHe.SelectedValue.ToString());
            cmbNhomNganh.DisplayMember = "TenNganh";
            cmbNhomNganh.ValueMember = "MaNganh";


            DataTable dtNhomNganh = nhomNganhBS.LoadByLoaiNganh(cmbHeTK.SelectedValue.ToString());
            DataRow dr1 = dtNhomNganh.NewRow();
            dr1[0] = "ALL"; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = "";
            dtNhomNganh.Rows.Add(dr1);
            cmbNhonNganhTK.DataSource = dtNhomNganh;
            cmbNhonNganhTK.DisplayMember = "TenNganh";
            cmbNhonNganhTK.ValueMember = "MaNganh";
            cmbNhonNganhTK.SelectedValue = "ALL";

            soSanhDict = new Dictionary<string, string>();
            
            soSanhDict.Add("NOT", "NOT");
            soSanhDict.Add("=", "=");
            soSanhDict.Add(">", ">");
            soSanhDict.Add("<", "<");
            soSanhDict.Add(">=", ">=");
            soSanhDict.Add("<=", "<=");

            
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
            //ucDataButton1.AddNewVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Insert);
            //ucDataButton1.EditVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Update);
            //ucDataButton1.DeleteVisible = congThucBS.IsAuthorized(CongThucService.CongThucAction.Delete);
           // MessageBox.Show(hoSoBS.IsAuthorized(HoSoService.HoSoAction.XetTuyenHS).ToString());
            btnCapNhap.Visible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.XetTuyenHS);
           ucDataButton1.PrintVisible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.PrintGiayBao);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource(string sql)
        {
            blnIsDataBinding = true;
            
            dtHoSoXT = hoSoBS.FinHoSo(sql);
            
            dgvHoSo.DataSource = dtHoSoXT;
           
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
           txtHoTen.Text = dgvHoSo.SelectedRows[0].Cells[clmHoTen.Name].Value.ToString();
           txtMaHS.Text = dgvHoSo.SelectedRows[0].Cells[clmMaHS.Name].Value.ToString();
           txtSoBaoDanh.Text = dgvHoSo.SelectedRows[0].Cells[clmSoCMTND.Name].Value.ToString();
           // txtNam.Text = dgvHoSo.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
            cmbNhomNganh.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaNganh.Name].Value;
           // cmbNganh.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmIDNganh.Name].Value;
            cmbMaKhoi.SelectedValue = dgvHoSo.SelectedRows[0].Cells[cmlMaKhoi.Name].Value;
           cmbHeTK.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmHe.Name].Value;
           //txtHeSo.Text = dgvHoSo.SelectedRows[0].Cells[clmHeSo.Name].Value.ToString();
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            
            //txtNam.Text = DateTime.Now.Year.ToString();
            //txtHeSo.Text = "1";
            //cmbHeXetTuyen.SelectedValue = 1;
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
           
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
            //if (txtHeSo.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Bạn chưa nhập hệ số.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //else
            //{
            //    decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
            //    if (!decimalRegex.IsMatch(txtHeSo.Text.Trim()))
            //    {
            //        MessageBox.Show("Hệ số phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //txtHeSo.Enabled = bln;
            //txtNam.Enabled = bln;
            //cmbNganh.Enabled = bln;
            //cmbNhomNganh.Enabled = bln;
            //cmbMaMon.Enabled = bln;
            //cmbMaKhoi.Enabled = bln;
            //cmbMaDot.Enabled = bln;
            //cmbHeXetTuyen.Enabled = bln;
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            //if (ucDataButton1.DataMode == DataState.Edit)
            //{
            //    DataGridViewRow modifiedRow = dgvHoSo.SelectedRows[0];

            //    if (modifiedRow.Cells[clmMaDot.Name].Value.ToString() != cmbMaDot.SelectedValue.ToString().Trim()
            //        || modifiedRow.Cells[clmNam.Name].Value.ToString() != txtNam.Text.Trim())
            //        return true;

            //}
            //else if (ucDataButton1.DataMode == DataState.Edit)
            //{
            //    if (cmbMaDot.SelectedValue != null
            //        || cmbMaKhoi.SelectedValue != null)
            //        return true;
            //}

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {


            //CongThuc objCongThuc = new CongThuc();
            //    string madot = "";
            //    bool blnResult = false;

            //    objCongThuc.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
            //    objCongThuc.Nam = Int32.Parse(txtNam.Text.Trim());
            //    objCongThuc.MaNganh = cmbNhomNganh.SelectedValue.ToString().Trim();
            //    objCongThuc.IDNganh = cmbNganh.SelectedValue.ToString().Trim();
            //    objCongThuc.MaKHoi = cmbMaKhoi.SelectedValue.ToString().Trim();
            //    objCongThuc.MaMon = cmbMaMon.SelectedValue.ToString().Trim();
            //    objCongThuc.HeSo =double.Parse(txtHeSo.Text.Trim());
            //    if (ucDataButton1.DataMode == DataState.Insert)
            //    {

            //        //MessageBox.Show(objCongThuc.MaDot +"-"+ objCongThuc.MaKHoi +"-" +objCongThuc.MaMon +"-"+ objCongThuc.MaNganh +"-"+ objCongThuc.Nam.ToString() + "hs"+ objCongThuc.HeSo.ToString());
            //        blnResult = congThucBS.Insert(objCongThuc);
            //    }
            //    else
            //    {
            //        DataGridViewRow modifiedRow = dgvHoSo.SelectedRows[0];
            //        madot = modifiedRow.Cells[clmMaDot.Name].Value.ToString();



            //        blnResult = congThucBS.Update(objCongThuc);
            //    }

            //    if (blnResult)
            //    {
            //        clsCommon.SaveSuccessfully();

            //        //If user is closing form.
            //        if (blnIsClosing) return;

            //        SetDataSource();

            //        //Set selected row
            //        for (int i = 0; i < dgvHoSo.RowCount; i++)
            //        {
            //            if (dgvHoSo.Rows[i].Cells[clmMaDot.Name].Value.ToString() == madot)
            //            {
            //                dgvHoSo.CurrentCell = dgvHoSo.Rows[i].Cells[1];
            //                break;
            //            }
            //        }

            //        ucDataButton1.DataMode = DataState.View;

            //    }
            //    else
            //    {
            //        clsCommon.SaveNotSuccessfully();
            //        return;
            //    }
           
        }
        #endregion

        private void LoadData()
        {



            int nam = DateTime.Now.Year;
            if (txtNam.Text.Length > 0 && clsCommon.IsNumber(txtNam.Text.Trim()))
            {
                nam = int.Parse(txtNam.Text.Trim());
            }
            txtNam.Text = nam.ToString();
            DotXetTuyenService dotXetTuyenService = new DotXetTuyenService();

           DataTable dt = dotXetTuyenService.LoadByNam(nam);
           DataRow dr1 = dt.NewRow();
           dr1[0] = "ALL";  dr1[1] = nam.ToString(); dr1[2] = DateTime.Now.Date.ToString(); dr1[3] = DateTime.Now.Date.ToString(); dr1[4] = "ALL";
           dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {
                cmbMaDot.DataSource = dt;
                cmbMaDot.DisplayMember = "TenDot";
                cmbMaDot.ValueMember = "MaDot";

            }
            
            string maNganh = "";
            DataTable dt1;
            NganhService nganhService = new NganhService();
            if (cmbNhomNganh.SelectedValue != null)
                maNganh = cmbNhomNganh.SelectedValue.ToString();


            //MessageBox.Show(maNganh);

            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {



                dt1 = nganhService.LoadNganh(maNganh, nam);
                ////MessageBox.Show(dt.Rows.Count.ToString());

                cmbNganh.DataSource = dt1;

                cmbNganh.DisplayMember = "TenNganh";
                cmbNganh.ValueMember = "IDNganh";


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
            //if (clsCommon.ConfirmDeletion() == DialogResult.No)
            //    return;

                   

            //for (int i = 0; i < dgvHoSo.SelectedRows.Count; i++)
            //{
            //    string manganh = dgvHoSo.SelectedRows[i].Cells[clmMaNganh.Name].Value.ToString();
            //    string idNganh= dgvHoSo.SelectedRows[i].Cells[clmIDNganh.Name].Value.ToString();
            //    string makhoi = dgvHoSo.SelectedRows[i].Cells[clmMaKhoi.Name].Value.ToString();
            //    string mamon = dgvHoSo.SelectedRows[i].Cells[clmMaMon.Name].Value.ToString();
            //    string madot = dgvHoSo.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
            //    int iNam =int.Parse( dgvHoSo.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
            //    congThucBS.Delete(manganh, mamon,makhoi,iNam,idNganh,madot);
            //}

            //SetDataSource();
            //if (dgvHoSo.RowCount > 0)
            //{
            //    dgvHoSo.CurrentCell = null;

            //    dgvHoSo.CurrentCell = dgvHoSo.Rows[0].Cells[1];
            //}  
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
                if (dgvHoSo.SelectedRows.Count > 0)
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
            if (blnIsDataBinding || dgvHoSo.SelectedRows.Count == 0) return;

            DisplayText();     
        }

        private void cmbHeXetTuyen_SelectedValueChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(loaiNganh.ToString());
            
        }

        private void cmbNhomNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
            
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
                DataRow dr1 = dt2.NewRow();
                dr1[0] = ""; dr1[1] = ""; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = nam.ToString(); dr1[4] = ""; dr1[5] = "1";
                dt2.Rows.Add(dr1);
                cmbMaKhoi.DataSource = dt2;
                //MessageBox.Show(maNganh);
                cmbMaKhoi.DisplayMember = "MaKhoi";
                cmbMaKhoi.ValueMember = "MaKhoi";

            }
            if (idNganh == "ALL")
            {
                cmbMaKhoi.SelectedValue = "ALL";
            }
           
        }
        public static void ExportDataGridViewTo_Excel12(DataGridView myDataGridViewQuantity)
        {

            Excel_12.Application oExcel_12 = null; //Excel_12 Application 

            Excel_12.Workbook oBook = null; // Excel_12 Workbook 

            Excel_12.Sheets oSheetsColl = null; // Excel_12 Worksheets collection 

            Excel_12.Worksheet oSheet = null; // Excel_12 Worksheet 

            Excel_12.Range oRange = null; // Cell or Range in worksheet 

            Object oMissing = System.Reflection.Missing.Value;


            // Create an instance of Excel_12. 

            oExcel_12 = new Excel_12.Application();


            // Make Excel_12 visible to the user. 

            oExcel_12.Visible = true;


            // Set the UserControl property so Excel_12 won't shut down. 

            oExcel_12.UserControl = true;

            // System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US"); 

            //object file = File_Name;

            //object missing = System.Reflection.Missing.Value;



            // Add a workbook. 

            oBook = oExcel_12.Workbooks.Add(oMissing);

            // Get worksheets collection 

            oSheetsColl = oExcel_12.Worksheets;

            // Get Worksheet "Sheet1" 

            oSheet = (Excel_12.Worksheet)oSheetsColl.get_Item("Sheet1");
            oSheet.Name = "HoSo";




            // Export titles 

            for (int j = 0; j < myDataGridViewQuantity.Columns.Count; j++)
            {

                oRange = (Excel_12.Range)oSheet.Cells[1, j + 1];

                oRange.Value2 = myDataGridViewQuantity.Columns[j].HeaderText;

            }

            // Export data 

            for (int i = 0; i < myDataGridViewQuantity.Rows.Count; i++)
            {

                for (int j = 0; j < myDataGridViewQuantity.Columns.Count; j++)
                {
                    oRange = (Excel_12.Range)oSheet.Cells[i + 2, j + 1];

                    oRange.Value2 = myDataGridViewQuantity[j, i].Value;

                }

            }
            oBook = null;
            oExcel_12.Quit();
            oExcel_12 = null;
            GC.Collect();
        }
        private void cmbMaKhoi_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        

        private void dgvHoSo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvHoSo.Rows[e.RowIndex].Cells["clmSTT"].Value = e.RowIndex + 1;
        }

        private void ucDataButton1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void ucDataButton1_PrintHandler()
        {
           
                DataRow drow = objdsTuyenSinh.Tables["Images"].NewRow();
                FileStream fs;
                //objdsTuyenSinh.Table.Clear();
                objdsTuyenSinh.EnforceConstraints = false;
                BinaryReader br;
                if (File.Exists(Application.StartupPath + "\\" + Utilities.acCompConfig.Logo))
                {
                    fs = new FileStream(Application.StartupPath + "\\" + Utilities.acCompConfig.Logo, FileMode.Open);
                }
                else
                {
                    fs = new FileStream(Application.StartupPath + "\\logo.jpg", FileMode.Open);
                }
                br = new BinaryReader(fs);

                Byte[] imgbyte = new Byte[fs.Length];



                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                drow[0] = imgbyte;      // add the image in bytearray
                // dt.Rows.Add(drow) ;      // add row into the datatable
                br.Close();              // close the binary reader
                fs.Close();             // close the file stream


                // crptLogo rptlogo = new crptLogo();
                // dtsNhapHangCT.Clear();
                objdsTuyenSinh.Tables["Images"].Rows.Add(drow);



                rptGiayBaoDiem rptD = new rptGiayBaoDiem();
                //rptGiayBao rpt = new rptGiayBao();
                rptGiayBaoDiemCD rptCD = new rptGiayBaoDiemCD();
                string mySql =  sql;
               
                //MessageBox.Show(sql);

                SqlDataAdapter ad = new SqlDataAdapter(mySql, DbConnection.SqlConnection);
               DbConnection.Open();

               ad.Fill(objdsTuyenSinh, "v_HoSoChiTiet");
                DbConnection.Close();


              



                //rpt.SetDataSource(objdsTuyenSinh);
                rptCD.SetDataSource(objdsTuyenSinh);
                rptD.SetDataSource(objdsTuyenSinh);
                //Utilities.conDBConnection.Close();
               
                //rpt.SetParameterValue("sTen", Utilities.acCompConfig.Name);
                //rpt.SetParameterValue("sDiaChi", Utilities.acCompConfig.Address);
                //rpt.SetParameterValue("sDienThoai", Utilities.acCompConfig.Phone);
                //rpt.SetParameterValue("sFax", Utilities.acCompConfig.Fax);
                //rpt.SetParameterValue("sMail", Utilities.acCompConfig.Mail);
                //rpt.SetParameterValue("sTienChu", sTien);
                if (frmPreview._selt == null)
                {
                    frmPreview frm = new frmPreview();
                    if (cmbHeTK.SelectedValue.ToString() == "0")
                        frm.setReportSource(rptCD);
                    else
                    {
                        frm.setReportSource(rptD);
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    objdsTuyenSinh.Clear();
                }
                else
                {
                    frmPreview._selt.WindowState = FormWindowState.Maximized;
                    frmPreview._selt.Activate();
                }
            }
        
        private void btnLocDL_Click(object sender, EventArgs e)
        {
            bool vali = true;

            sql = "Select hs.* FROM v_HoSoChiTiet as hs, t_DieuKien as dk where hs.idNganh = dk.IDNganh AND hs.MaDot = dk.MaDot AND hs.Nam = dk.Nam AND hs.MaKhoi = dk.MaKhoi AND hs.DiemTB>= dk.DiemSan AND hs.DiemTB >=dk.DiemChuan AND hs.MaHS  IS NOT NULL AND hs.TrangThai =0 AND hs.DiemTXT>hs.DiemTB ";
            if (txtNam.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập năm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNam.Focus();
                vali = false;
            }
            else
            {
                if (!clsCommon.IsNumber(txtNam.Text.Trim()))
                {
                    MessageBox.Show("Năm phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNam.Focus();
                    vali = false;
                }
                else {
                    sql += string.Format(" AND hs.Nam = {0} ", txtNam.Text.Trim());
                    if(cmbMaDot.SelectedValue.ToString() !="ALL")
                        sql += string.Format(" AND hs.MaDot = N'{0}'", cmbMaDot.SelectedValue.ToString());
                    if (cmbHeTK.SelectedValue != null)
                    {
                        if (cmbHeTK.SelectedValue.ToString() != "ALL")
                            sql += string.Format(" AND  hs.LoaiNganh  = N'{0}' ", cmbHeTK.SelectedValue.ToString());
                    }
                             
                    if (cmbNhonNganhTK.SelectedValue.ToString() != "ALL")
                        sql += string.Format(" AND  hs.MaNganh  = N'{0}' ", cmbNhonNganhTK.SelectedValue.ToString());
                    if (cmbNganhTK.SelectedValue != null)
                    {
                        if (cmbNganhTK.SelectedValue.ToString() != "ALL")
                            sql += string.Format(" AND  hs.IDNganh  = N'{0}' ", cmbNganhTK.SelectedValue.ToString());
                    }
                    if (cmbKhoiTK.SelectedValue != null)
                    {
                        if (cmbKhoiTK.SelectedValue.ToString() != "ALL")
                            sql += string.Format(" AND  hs.MaKhoi  = N'{0}' ", cmbKhoiTK.SelectedValue.ToString());
                    }


                    if ((txtSoStart.Text.Trim() != string.Empty && txtSoEnd.Text.Trim() != string.Empty) && (clsCommon.IsNumber(txtSoEnd.Text.Trim()) && clsCommon.IsNumber(txtSoStart.Text.Trim())))
                    {

                        sql += string.Format(" AND  COALESCE(CASE WHEN 1 = IsNumeric(hs.MaHS) THEN CAST(hs.MaHS AS INT)  END,0 )  BETWEEN {0} AND {1}", txtSoStart.Text.Trim(), txtSoEnd.Text.Trim());
                    }
                    
                    //int lienthong = 0;
                    //if (ckbLienThong.Checked) {
                    //    lienthong = 1;
                    //}
                    //sql += string.Format(" AND  LienThong =  {0}  ", lienthong);

                    sql += " ORDER BY COALESCE(CASE WHEN 1 = IsNumeric(hs.MaHS) THEN CAST(hs.MaHS AS INT)  END,0 ) ";
                   
                   

                  // MessageBox.Show(sql);
                    if (vali)
                    { if(dtHoSoXT.Rows.Count>0)
                        dtHoSoXT.Rows.Clear();
                        SetDataSource(sql);
                    }
                }
            }
            
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ucDataButton1_ExcelHandler()
        {
            try
            {
                ExportDataGridViewTo_Excel12(dgvHoSo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void lblNam_Click(object sender, EventArgs e)
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
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (clsCommon.ConfirmXetTuyen() == DialogResult.No)
                return;

            if (bw.IsBusy != true)
            {
                // create a new instance of the alert form
                alert = new AlertForm(dtHoSoXT.Rows.Count);
                // event handler for the Cancel button in AlertForm
                alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                alert.Show();
                // Start the asynchronous operation.
                bw.RunWorkerAsync();
            }
            //MessageBox.Show(dtHoSoXT.Rows[0]["M1l10HK1"].ToString());
        }

        private void cmbHeTK_SelectedIndexChanged(object sender, EventArgs e)
        {

            NhomNganhService nhomNganhService = new NhomNganhService();
            string loaiNganh = " ";

            loaiNganh = cmbHeTK.SelectedValue.ToString();
            DataTable dt = nhomNganhService.LoadByLoaiNganh(loaiNganh);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "ALL"; dr1[1] = ""; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = "";
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {

                cmbNhonNganhTK.DataSource = dt;
                cmbNhonNganhTK.DisplayMember = "TenNganh";
                cmbNhonNganhTK.ValueMember = "MaNganh";


            }
            cmbNhonNganhTK.SelectedValue = "ALL";
        }

        private void cmbNhonNganhTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNganh = "";
            DataTable dt1;
            NganhService nganhService = new NganhService();
            if (cmbNhonNganhTK.SelectedValue != null)
                maNganh = cmbNhonNganhTK.SelectedValue.ToString();


            //MessageBox.Show(maNganh);
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {



                dt1 = nganhService.LoadNganh(maNganh, nam);
                ////MessageBox.Show(dt.Rows.Count.ToString());
                DataRow dr1 = dt1.NewRow();
                dr1[0] = "ALL"; dr1[1] = ""; dr1[1] = ""; dr1[2] = ""; dr1[3] = nam.ToString(); dr1[4] = "ALL";
                dt1.Rows.Add(dr1);
                cmbNganhTK.DataSource = dt1;

                cmbNganhTK.DisplayMember = "TenNganh";
                cmbNganhTK.ValueMember = "IDNganh";




            }
            if (maNganh == "ALL")
            {
                cmbNganhTK.SelectedValue = "ALL";
            }
        }

        private void cmbNhomNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNganh = "";
            DataTable dt1;
            NganhService nganhService = new NganhService();
            if (cmbNhomNganh.SelectedValue != null)
                maNganh = cmbNhomNganh.SelectedValue.ToString();


            //MessageBox.Show(maNganh);
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {



                dt1 = nganhService.LoadNganh(maNganh, nam);
                ////MessageBox.Show(dt.Rows.Count.ToString());
              
                cmbNganh.DataSource = dt1;

                cmbNganh.DisplayMember = "TenNganh";
                cmbNganh.ValueMember = "IDNganh";




            }

        }

        private void cmbNganhTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhoiThiService khoiThiBS = new KhoiThiService();
            string sqlNganh = string.Format("Select ng.MaKhoi, kt.TenKhoi From t_Nganh as ng, t_KhoiThi as kt Where ng.MaKhoi = kt.MaKhoi AND ng.IDNganh =N'{0}' AND ng.Nam = {1} ", cmbNganhTK.SelectedValue.ToString(),txtNam.Text);
            DataTable dtKhoiThi = khoiThiBS.FinKhoiThi(sqlNganh);
            DataRow dr2 = dtKhoiThi.NewRow();
            dr2[0] = "ALL";  dr2[1] = "ALL";
            dtKhoiThi.Rows.Add(dr2);

            cmbKhoiTK.DataSource = dtKhoiThi;
            cmbKhoiTK.DisplayMember = "TenKhoi";
            cmbKhoiTK.ValueMember = "MaKhoi";
            cmbKhoiTK.SelectedValue = "ALL";
        }

        private void btnHienAll_Click(object sender, EventArgs e)
        {
            sql = "Select hs.* FROM v_HoSoChiTiet as hs, t_DieuKien as dk where hs.idNganh = dk.IDNganh AND hs.MaDot = dk.MaDot AND hs.Nam = dk.Nam AND hs.MaKhoi = dk.MaKhoi AND hs.DiemTB>= dk.DiemSan AND hs.DiemTB >=dk.DiemChuan AND hs.MaHS  IS NOT NULL AND hs.TrangThai =0  AND hs.DiemTXT>hs.DiemTB ORDER BY COALESCE(CASE WHEN 1 = IsNumeric(hs.MaHS) THEN CAST(hs.MaHS AS INT)  END,0 ) ";
            dtHoSoXT.Rows.Clear();
            SetDataSource(sql);
        }

        private void grpDetailInfo_Enter(object sender, EventArgs e)
        {

        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            //  labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            alert.Message = "In progress of " + dtHoSoXT.Rows.Count + " records, please wait... " + e.ProgressPercentage.ToString() + " record";
            alert.ProgressValue = e.ProgressPercentage;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            ThongTinXetTuyenService TTXetTuyenBS = new ThongTinXetTuyenService();
            ThongTinXetTuyen tTXetTuyen;
            HoSoService hoSoBS = new HoSoService();
            NganhXetTuyenService nganhXTBS = new NganhXetTuyenService();
            bool result = false;
            string Soqd = "";
            string nam = txtNam.Text.Trim();
            for (int i = 0; i < dtHoSoXT.Rows.Count; i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // MessageBox.Show(dtHoSoXT.Rows[i]["IDNganh"].ToString());
                    double diem1 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L10HK1"].ToString());
                    double diem2 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L10HK2"].ToString());
                    double diem3 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L10HK1"].ToString());
                    double diem4 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L10HK2"].ToString());
                    double diem5 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L10HK1"].ToString());
                    double diem6 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L10HK2"].ToString());
                    double diem7 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L11HK1"].ToString());
                    double diem8 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L11HK2"].ToString());
                    double diem9 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L11HK1"].ToString());
                    double diem10 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L11HK2"].ToString());
                    double diem11 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L11HK1"].ToString());
                    double diem12 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L11HK2"].ToString());
                    double diem13 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L12HK1"].ToString());
                    double diem14 = Convert.ToDouble(dtHoSoXT.Rows[i]["M1L12HK2"].ToString());
                    double diem15 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L12HK1"].ToString());
                    double diem16 = Convert.ToDouble(dtHoSoXT.Rows[i]["M2L12HK2"].ToString());
                    double diem17 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L12HK1"].ToString());
                    double diem18 = Convert.ToDouble(dtHoSoXT.Rows[i]["M3L12HK2"].ToString());

                    string khoi = dtHoSoXT.Rows[i]["MaKhoi"].ToString();
                    if (khoi.Length > 3)
                        khoi = khoi.Replace("THPT_", "");
                    long idHS = Convert.ToInt64(dtHoSoXT.Rows[i]["Idhs"].ToString());
                    Soqd = hoSoBS.GetSoQuyetDinh(dtHoSoXT.Rows[i]["IDNganh"].ToString(), nam);
                    string maHS = dtHoSoXT.Rows[i]["MaHS"].ToString();
                    string maKhoi = dtHoSoXT.Rows[i]["MaKhoi"].ToString();
                    string idNganh = dtHoSoXT.Rows[i]["IDNganh"].ToString();
                    string maNganh = dtHoSoXT.Rows[i]["maNganh"].ToString();
                    string maDot = dtHoSoXT.Rows[i]["MaDot"].ToString();
                    //public bool Insert(long idHS, string MaHS, string maKhoi, double diem1, double diem2, double diem3, double diem4, double diem5, double diem6, double diem7, double diem8, double diem9, double diem10, double diem11, double diem12, double diem13, double diem14, double diem15, double diem16, double diem17, double diem18, string khoiDK, string nganhXT, string maDot, string soQD, int trangThai, int soIn,int ChonIn)
                    result = hoSoBS.XetTuyenHS(idHS, maHS, khoi, diem1, diem2, diem3, diem4, diem5, diem6, diem7, diem8, diem9, diem10, diem11, diem12, diem13, diem14, diem15, diem16, diem17, diem18, maKhoi, idNganh, maDot, Soqd, 1, 0, 1);
                    // MessageBox.Show(khoi + );
                    //Thay đổi trạng thái của hồ sơ và ngành đăng ký
                    if (result)
                    {
                        HoSo objHoSo = hoSoBS.GetHoSoByID(idHS);
                        objHoSo.KetQua = 1;
                        hoSoBS.Update(objHoSo);

                        //MessageBox.Show(idHS + "-" + maNganh +"-"+ maKhoi+"-" + idNganh +"-"+ maDot +"-"+ nam);
                        nganhXTBS.UpdateTrangThai(idHS, maKhoi, maDot, Convert.ToInt32(nam), idNganh, 1);
                        // MessageBox.Show(objNganhXT.MaNganh + "-"+ objNganhXT.Idhs);
                        tTXetTuyen = new ThongTinXetTuyen();
                        tTXetTuyen.LoginID = clsCommon.CurrentUser.LoginID;
                        tTXetTuyen.SoQD = Soqd;
                        tTXetTuyen.Status = "Add";
                        tTXetTuyen.MaHS = maHS;
                        tTXetTuyen.CreatedDate = Utilities.GetServerTime();
                        TTXetTuyenBS.Insert(tTXetTuyen);

                    }

                    worker.ReportProgress(i);


                }
               
            }
          
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
                clsCommon.XetTuyenSuccessfully();
                dtHoSoXT.Rows.Clear();
               
            }
            // Close the AlertForm
            alert.Close();
        }

        private void frmXetTuyen_FormClosing(object sender, FormClosingEventArgs e)
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


