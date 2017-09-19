
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
    public partial class frmInGiayBao : frmBase
    {
        bool blnIsDataBinding = true;
       
        DataTable dtHoSoXT = null;
        HoSoService hoSoBS;
        string sql = "";
    
        private Dictionary<string, string> nganhDict;
        private Dictionary<string, string> soSanhDict;
        #region "Form Events"
        public frmInGiayBao()
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
            

            nganhDict = new Dictionary<string , string>();
           // nganhDict.Add(2, "ALL");
            nganhDict.Add("C", "Cao đẳng");
            nganhDict.Add("ĐH", "Đại học");

            cmbHeXetTuyen.DataSource = new BindingSource(nganhDict, null);
            cmbHeXetTuyen.DisplayMember = "value";
            cmbHeXetTuyen.ValueMember = "key";
            cmbHeXetTuyen.SelectedValue = "ĐH";

            soSanhDict = new Dictionary<string, string>();
            
            soSanhDict.Add("NOT", "NOT");
            soSanhDict.Add("=", "=");
            soSanhDict.Add(">", ">");
            soSanhDict.Add("<", "<");
            soSanhDict.Add(">=", ">=");
            soSanhDict.Add("<=", "<=");

            cmbSoSanh.DataSource = new BindingSource(soSanhDict, null);
            cmbSoSanh.DisplayMember = "value";
            cmbSoSanh.ValueMember = "key";
            cmbSoSanh.SelectedValue = "NOT";
            txtNam.Text = DateTime.Now.Year.ToString();
            txtDiemTB.Text = "0";
            LoadData();

            sql = "Select * FROM V_HoSo_NganhXetTuyen_HocBong";
            if (rdoTHPT.Checked)
            {
                sql += " Where len(MaKhoi) >3";
            }
            else
            {
                sql += " Where len(MaKhoi) <3";
            }
            if (cmbHeXetTuyen.SelectedValue != null)
            {

                sql += string.Format(" AND LoaiNganh = N'{0}' ", cmbHeXetTuyen.SelectedValue.ToString());

            }
            if (rdoSoQD.Checked)
            {

                sql += string.Format("  ORDER BY CONVERT(INT, LEFT(SoQD, CHARINDEX('/',SoQD)-1)) ");
            }
            if (rdoMaHS.Checked)
            {

                sql += string.Format(" ORDER BY CASE WHEN 1 = IsNumeric(MaHS) THEN CAST(MaHS AS INT) END ");
            }
            SetDataSource(sql);
            if (Utilities.loadParamaster()) {
                txtThoiGian.Text = Utilities.acParaConfig.Time;
                txtDiaDiem.Text = Utilities.acParaConfig.Address;
            }
            
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
            ucDataButton1.PrintVisible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.PrintGiayBao);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource(string sql)
        {
            //MessageBox.Show(sql);
            blnIsDataBinding = true;
            
            dtHoSoXT = hoSoBS.FinHoSo(sql);
            
            dgvHoSo.DataSource = dtHoSoXT;
            txtSoHoSo.Text = dtHoSoXT.Rows.Count.ToString();
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
           // cmbMaDot.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaDot.Name].Value.ToString();
           // txtNam.Text = dgvHoSo.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
           // cmbNhomNganh.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaNganh.Name].Value;
           // cmbNganh.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmIDNganh.Name].Value;
           //cmbMaKhoi.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaKhoi.Name].Value;
           //cmbMaMon.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaMon.Name].Value;
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
            if (txtNam.Text.Length > 0 && clsCommon.IsNumber(txtNam.Text.Trim())) {
                nam =int.Parse( txtNam.Text.Trim());
            }
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
            NhomNganhService nhomNganhService = new NhomNganhService();
            string loaiNganh = " ";
            
            loaiNganh = cmbHeXetTuyen.SelectedValue.ToString();
            DataTable dt = nhomNganhService.LoadByLoaiNganh(loaiNganh);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "ALL"; dr1[1] = ""; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = "";
            dt.Rows.Add(dr1);
            if (dt.Rows.Count > 0)
            {

                cmbNhomNganh.DataSource = dt;
                cmbNhomNganh.DisplayMember = "TenNganh";
                cmbNhomNganh.ValueMember = "MaNganh";


            }
            cmbNhomNganh.SelectedValue = "ALL";
           // MessageBox.Show(loaiNganh.ToString());
            
        }

        private void cmbNhomNganh_SelectedValueChanged(object sender, EventArgs e)
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
                DataRow dr1 = dt1.NewRow();
                dr1[0] = "ALL"; dr1[1] = ""; dr1[1] =""; dr1[2] = ""; dr1[3] = nam.ToString(); dr1[4] = "ALL"; 
                dt1.Rows.Add(dr1);
                cmbNganh.DataSource = dt1;

                cmbNganh.DisplayMember = "TenNganh";
                cmbNganh.ValueMember = "IDNganh";


                

            }
            if (maNganh == "ALL")
            {
                cmbNganh.SelectedValue = "ALL";
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
              //  objdsTuyenSinh.Tables["Images"].Rows.Add(drow);



               // rptGiayBaoDiem rptD = new rptGiayBaoDiem();
               // rptGiayBaoDiem3chung rptD3chung = new rptGiayBaoDiem3chung();
                //rptGiayBao rpt = new rptGiayBao();
               // rptGiayBaoDiemCD rptCD = new rptGiayBaoDiemCD();
               // rptGiayBaoDiemCD3chung rptCD3chung = new rptGiayBaoDiemCD3chung();
                rptGiayBao2016 rpt2016 = new rptGiayBao2016();
                string mySql =  sql;

             

                //MessageBox.Show(sql);

                SqlDataAdapter ad = new SqlDataAdapter(mySql, DbConnection.SqlConnection);
               DbConnection.Open();
               objdsTuyenSinh.Clear();
               ad.Fill(objdsTuyenSinh, "V_HoSo_NganhXetTuyen_HocBong");
                DbConnection.Close();

              
              



                //rpt.SetDataSource(objdsTuyenSinh);
             //   rptCD.SetDataSource(objdsTuyenSinh);
                //rptCD3chung.SetDataSource(objdsTuyenSinh);
               // rptD.SetDataSource(objdsTuyenSinh);
               // rptD3chung.SetDataSource(objdsTuyenSinh);
                rpt2016.SetDataSource(objdsTuyenSinh);
            // MessageBox.Show( objdsTuyenSinh.v_HoSo_NganhXetTuyen.Rows.Count.ToString());
           
                //Utilities.conDBConnection.Close();
                if (txtThoiGian.Text.Trim() != string.Empty)
                {
                    //rptD.SetParameterValue("pThoiGianNhap", txtThoiGian.Text.Trim());
                   // rptD3chung.SetParameterValue("pThoiGianNhap", txtThoiGian.Text.Trim());
                   // rptCD.SetParameterValue("pThoiGianNhap", txtThoiGian.Text.Trim());
                    rpt2016.SetParameterValue("pThoiGianNhap", txtThoiGian.Text.Trim());
                }
                else {
                   // rptD.SetParameterValue("pThoiGianNhap", "16/8/2014 từ 7h30' - 17h00'");
                   // rptD3chung.SetParameterValue("pThoiGianNhap", "16/8/2014 từ 7h30' - 17h00'");
                    //rptCD.SetParameterValue("pThoiGianNhap", "16/8/2014 từ 7h30' - 17h00'");
                    rpt2016.SetParameterValue("pThoiGianNhap", "16/8/2014 từ 7h30' - 17h00'");
                }
                if (txtDiaDiem.Text.Trim() != string.Empty)
                {
                    //rptD.SetParameterValue("pDiaDiem", txtDiaDiem.Text.Trim());
                   // rptD3chung.SetParameterValue("pDiaDiem", txtDiaDiem.Text.Trim());
                    //rptCD.SetParameterValue("pDiaDiem", txtDiaDiem.Text.Trim());
                    rpt2016.SetParameterValue("pDiaDiem", txtDiaDiem.Text.Trim());
                }
                else
                {
                   // rptD.SetParameterValue("pDiaDiem", "Khu liên hợp thể dục thể thao Khách sạn sinh viên - 50 Quán Nam, Kênh Dương, Lê Chân, TP. Hải Phòng.");
                    //rptD3chung.SetParameterValue("pDiaDiem", "Khu liên hợp thể dục thể thao Khách sạn sinh viên - 50 Quán Nam, Kênh Dương, Lê Chân, TP. Hải Phòng.");
                    //rptCD.SetParameterValue("pDiaDiem", "Khu liên hợp thể dục thể thao Khách sạn sinh viên - 50 Quán Nam, Kênh Dương, Lê Chân, TP. Hải Phòng.");
                    rpt2016.SetParameterValue("pDiaDiem", "trường Đại học Dân lập Hải Phòng, số 36 Đường Dân Lập - Phường Dư Hàng Kênh - Quận Lê Chân - Tp Hải Phòng");
                }
                //rpt.SetParameterValue("sTen", Utilities.acCompConfig.Name);
                //rpt.SetParameterValue("sDiaChi", Utilities.acCompConfig.Address);
                //rpt.SetParameterValue("sDienThoai", Utilities.acCompConfig.Phone);
                //rpt.SetParameterValue("sFax", Utilities.acCompConfig.Fax);
                //rpt.SetParameterValue("sMail", Utilities.acCompConfig.Mail);
                //rpt.SetParameterValue("sTienChu", sTien);
            
                if (frmPreview._selt == null)
                {
                    frmPreview frm = new frmPreview();
                   /* 
                    if (cmbHeXetTuyen.SelectedValue.ToString() == "C")
                        if (rdoTHPT.Checked)
                        {
                            frm.setReportSource(rptCD);
                        }
                        else {
                            frm.setReportSource(rptCD3chung);
                        }
                    else
                    {
                        if (rdoTHPT.Checked)
                        {
                            frm.setReportSource(rptD);
                        }
                        else {
                            frm.setReportSource(rptD3chung);
                        }
                    }*/
                    frm.setReportSource(rpt2016);
                    frm.WindowState = FormWindowState.Maximized;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    //objdsTuyenSinh.Clear();
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
            sql  = "Select * FROM V_HoSo_NganhXetTuyen_HocBong ";
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
                    sql += string.Format(" Where Nam = {0} ",txtNam.Text.Trim());
                    if(cmbMaDot.SelectedValue.ToString() !="ALL")
                    sql += string.Format(" AND MaDot = N'{0}'", cmbMaDot.SelectedValue.ToString());
                    if (cmbHeXetTuyen.SelectedValue.ToString() != "ALL")
                    {
                        
                            sql += string.Format(" AND LoaiNganh = N'{0}' ", cmbHeXetTuyen.SelectedValue.ToString());
                        
                    }
                             
                    if (cmbNhomNganh.SelectedValue.ToString() != "ALL")
                        sql += string.Format(" AND  MaNganh  = N'{0}' ", cmbNhomNganh.SelectedValue.ToString());
                    if (cmbNganh.SelectedValue != null)
                    {
                        if (cmbNganh.SelectedValue.ToString() != "ALL")
                            sql += string.Format(" AND  IDNganh  = N'{0}' ", cmbNganh.SelectedValue.ToString());
                    }
                    if (cmbMaKhoi.SelectedValue != null)
                    {
                        if (cmbMaKhoi.SelectedValue.ToString() != "ALL")
                            sql += string.Format(" AND  MaKhoi  = N'{0}' ", cmbMaKhoi.SelectedValue.ToString());
                    }
                    if (cmbSoSanh.SelectedValue != null)
                    {
                        if (cmbSoSanh.SelectedValue.ToString() != "NOT")
                            if (txtDiemTB.Text.Trim() == string.Empty)
                            {
                                MessageBox.Show("Bạn chưa nhập điểm để so sánh.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtDiemTB.Focus();
                                vali = false;
                            }
                            else {
                                Regex decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
                                if (!decimalRegex.IsMatch(txtDiemTB.Text.Trim()))
                                {
                                    MessageBox.Show("Điểm trung bình phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtDiemTB.Focus();
                                    vali = false;
                                }
                                else
                                {
                                    sql += string.Format(" AND  DiemTB  {0} {1} ", cmbSoSanh.SelectedValue.ToString(), txtDiemTB.Text.Trim());
                                }
                            }
                           
                    }
                    
                    //int lienthong = 0;
                    //if (ckbLienThong.Checked) {
                    //    lienthong = 1;
                    //}
                    //sql += string.Format(" AND  LienThong =  {0}  ", lienthong);

                    if (txtSoBaoDanh.Text.Trim() != string.Empty) {
                        sql += string.Format(" AND  SoCMTND like  N'%{0}%' ", txtSoBaoDanh.Text.Trim());
                    }
                    if (txtMaHS.Text.Trim() != string.Empty)
                    {
                        sql += string.Format(" AND  MaHS like  N'%{0}%' ", txtMaHS.Text.Trim());
                    }
                    if (txtHoTen.Text.Trim() != string.Empty)
                    {
                        sql += string.Format(" AND  HoTen like  N'%{0}%' ", txtHoTen.Text.Trim());
                    }
                    if((txtSoStart.Text.Trim()!=string.Empty && txtSoEnd.Text.Trim()!=string.Empty) &&(clsCommon.IsNumber(txtSoEnd.Text.Trim()) && clsCommon.IsNumber(txtSoStart.Text.Trim()))) {

                        sql += string.Format(" AND  COALESCE(CASE WHEN 1 = IsNumeric(MaHS) THEN CAST(MaHS AS INT)  END,0 )  BETWEEN {0} AND {1}", txtSoStart.Text.Trim(), txtSoEnd.Text.Trim());
                    }
                    if (rdoTHPT.Checked)
                    {
                        sql += " AND len(MaKhoi) >3";
                    }
                    else
                    {
                        sql += " AND len(MaKhoi) <3";
                    }
                    if (rdoSoQD.Checked)
                    {

                        sql += string.Format("  ORDER BY CONVERT(INT, LEFT(SoQD, CHARINDEX('/',SoQD)-1)) ");
                    }
                    if (rdoMaHS.Checked)
                    {

                        sql += string.Format(" ORDER BY CASE WHEN 1 = IsNumeric(MaHS) THEN CAST(MaHS AS INT) END ");
                    }
                   //MessageBox.Show(sql);
                    if (vali)
                    {
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

        private void cmbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveParra_Click(object sender, EventArgs e)
        {
            ParamasterConfig objParmaster = new ParamasterConfig();
            objParmaster.Time = txtThoiGian.Text.Trim();
            objParmaster.Address = txtDiaDiem.Text.Trim();
            if (Utilities.saveParamaster(objParmaster))
            {

                MessageBox.Show("Lưu thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Lưu thông tin không thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        }

                    
    }


