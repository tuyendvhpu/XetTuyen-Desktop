
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
    public partial class frmDieuKien : frmBase
    {
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        DieuKienService dieuKienBS = new DieuKienService();
        private Regex decimalRegex = null;
        private Dictionary<string, string> nganhDict;
        #region "Form Events"
        public frmDieuKien()
        {

            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvCongThuc.AutoGenerateColumns = false;

            SetDataSource("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where DK.IDNganh = vNganh.IDNganh ");

            nganhDict = new Dictionary<string, string>();
            nganhDict.Add("C", "Cao đẳng");
            nganhDict.Add("ĐH", "Đại học");


            cmbHeXetTuyen.DataSource = new BindingSource(nganhDict, null);
            cmbHeXetTuyen.DisplayMember = "value";
            cmbHeXetTuyen.ValueMember = "key";
            cmbHeXetTuyen.SelectedValue = "ĐH";

            cmbHeTK.DataSource = new BindingSource(nganhDict, null);
            cmbHeTK.DisplayMember = "value";
            cmbHeTK.ValueMember = "key";
            cmbHeTK.SelectedValue = "ĐH";

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
            ucDataButton1.AddNewVisible = dieuKienBS.IsAuthorized(DieuKienService.DieuKienAction.Insert);
            ucDataButton1.EditVisible = dieuKienBS.IsAuthorized(DieuKienService.DieuKienAction.Update);
            ucDataButton1.DeleteVisible = dieuKienBS.IsAuthorized(DieuKienService.DieuKienAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource(string sql)
        {
            blnIsDataBinding = true;
            //DieuKienCollection dieuKienCollection = dieuKienBS.FinListDieuKien(sql) ;
            dgvCongThuc.DataSource = dieuKienBS.FinDieuKien(sql);
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
                txtDiemChuan.Text = dgvCongThuc.SelectedRows[0].Cells[clmDiemChuan.Name].Value.ToString();
                txtDiemSan.Text = dgvCongThuc.SelectedRows[0].Cells[clmDiemSan.Name].Value.ToString();
            }
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();
            txtDiemChuan.Text = "5.0";
            txtDiemSan.Text = "5.0";
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
                txtNam.Focus();
                return false;
            }
            else {
                if (!clsCommon.IsNumber(txtNam.Text.Trim())) {
                    MessageBox.Show("Năm phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNam.Focus();
                    return false;
                }
            }
            if (txtDiemChuan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập điểm chuẩn.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiemChuan.Focus();
                return false;
            }
            else
            {
                decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
                if (!decimalRegex.IsMatch(txtDiemChuan.Text.Trim()))
                {
                    MessageBox.Show("Điểm chuẩn phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiemChuan.Focus();
                    return false;
                }
            }
            if (txtDiemSan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập điểm sàn.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiemSan.Focus();
                return false;
            }
            else
            {
                decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
                if (!decimalRegex.IsMatch(txtDiemSan.Text.Trim()))
                {
                    MessageBox.Show("Điểm sàn phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiemSan.Focus();
                    return false;
                }
            }
            string dot = "";
            string idNganh = "";
           
            string khoi = "";
            int nam = Convert.ToInt32(txtNam.Text.Trim());
            if(cmbMaDot.SelectedValue!=null)
             dot = cmbMaDot.SelectedValue.ToString();
           
            if (cmbNganh.SelectedValue != null)
                idNganh = cmbNganh.SelectedValue.ToString();
            if (cmbMaKhoi.SelectedValue != null)
                khoi = cmbMaKhoi.SelectedValue.ToString();
            DataTable dt = new DataTable();
            string sqlCongThuc = string.Format("Select * From t_DieuKien Where idNganh = N'{0}' And MaDot = N'{1}' And MaKhoi = N'{2}' And Nam ={3}", idNganh, dot, khoi,  nam);
            dt = dieuKienBS.FinDieuKien(sqlCongThuc);
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
            txtDiemChuan.Enabled = bln;
            txtDiemSan.Enabled = bln;
            txtNam.Enabled = bln;
            cmbNganh.Enabled = bln;
            cmbNhomNganh.Enabled = bln;
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
           NganhService nganhBS = new NganhService();
           NhomNganhService nhomNganhBS = new NhomNganhService();
            DieuKien objDieuKien ;
                string madot = "";
                bool blnResult = false;

          


                
                if (ucDataButton1.DataMode == DataState.Insert)
                {
                    List<DieuKien> dklist = new List<DieuKien>();
                    string smadot = cmbMaDot.SelectedValue.ToString().Trim();
                    int inam = Int32.Parse(txtNam.Text.Trim());
                    string sMaNganh = cmbNhomNganh.SelectedValue.ToString().Trim();
                    string sIdNganh = cmbNganh.SelectedValue.ToString().Trim();
                    string sMaKhoi = cmbMaKhoi.SelectedValue.ToString().Trim();
                    double dDiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                    double dDiemSan = double.Parse(txtDiemSan.Text.Trim());
                    if (sMaNganh == "ALL")
                    {
                        string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh = N'{0}'", cmbHeXetTuyen.SelectedValue.ToString());
                        DataTable dtNhomNganh = nhomNganhBS.FinNhomNganh(sqlNhomNganh);
                        if (dtNhomNganh.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtNhomNganh.Rows.Count; i++)
                            {
                                string sqlNganh = string.Format("Select * From T_Nganh Where MaNganh = N'{0}'", dtNhomNganh.Rows[i]["MaNganh"].ToString());
                                DataTable dtNganh = nganhBS.FinNganh(sqlNganh);
                                if (dtNganh.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dtNganh.Rows.Count; j++)
                                    {
                                        objDieuKien = new DieuKien();
                                        objDieuKien.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
                                        objDieuKien.Nam = Int32.Parse(txtNam.Text.Trim());
                                        objDieuKien.MaNganh = dtNganh.Rows[j]["MaNganh"].ToString().Trim();
                                        objDieuKien.IDNganh = dtNganh.Rows[j]["IDNganh"].ToString().Trim();
                                        objDieuKien.MaKhoi = dtNganh.Rows[j]["MaKhoi"].ToString().Trim();
                                        objDieuKien.DiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                                        objDieuKien.DiemSan = double.Parse(txtDiemSan.Text.Trim());
                                        dklist.Add(objDieuKien);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (sIdNganh == "ALL")
                        {
                            string sqlNganh = string.Format("Select * From T_Nganh Where MaNganh = N'{0}'", sMaNganh);
                            DataTable dtNganh = nganhBS.FinNganh(sqlNganh);
                            if (dtNganh.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtNganh.Rows.Count; j++)
                                {
                                    objDieuKien = new DieuKien();
                                    objDieuKien.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
                                    objDieuKien.Nam = Int32.Parse(txtNam.Text.Trim());
                                    objDieuKien.MaNganh = dtNganh.Rows[j]["MaNganh"].ToString().Trim();
                                    objDieuKien.IDNganh = dtNganh.Rows[j]["IDNganh"].ToString().Trim();
                                    objDieuKien.MaKhoi = dtNganh.Rows[j]["MaKhoi"].ToString().Trim();
                                    objDieuKien.DiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                                    objDieuKien.DiemSan = double.Parse(txtDiemSan.Text.Trim());
                                    dklist.Add(objDieuKien);
                                }
                            }
                        }
                        else
                        {
                            if (sMaKhoi == "ALL")
                            {
                                string sqlNganh = string.Format("Select * From T_Nganh Where MaNganh = N'{0}' AND iDNganh =N'{1}' ", sMaNganh, sIdNganh);
                                DataTable dtNganh = nganhBS.FinNganh(sqlNganh);
                                if (dtNganh.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dtNganh.Rows.Count; j++)
                                    {
                                        objDieuKien = new DieuKien();
                                        objDieuKien.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
                                        objDieuKien.Nam = Int32.Parse(txtNam.Text.Trim());
                                        objDieuKien.MaNganh = dtNganh.Rows[j]["MaNganh"].ToString().Trim();
                                        objDieuKien.IDNganh = dtNganh.Rows[j]["IDNganh"].ToString().Trim();
                                        objDieuKien.MaKhoi = dtNganh.Rows[j]["MaKhoi"].ToString().Trim();
                                        objDieuKien.DiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                                        objDieuKien.DiemSan = double.Parse(txtDiemSan.Text.Trim());
                                        dklist.Add(objDieuKien);
                                    }
                                }
                            }
                            else
                            {
                                string sqlNganh = string.Format("Select * From T_Nganh Where MaNganh = N'{0}' AND iDNganh =N'{1}' AND MaKhoi = N'{2}' ", sMaNganh, sIdNganh, sMaKhoi);
                                DataTable dtNganh = nganhBS.FinNganh(sqlNganh);
                                if (dtNganh.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dtNganh.Rows.Count; j++)
                                    {
                                        objDieuKien = new DieuKien();
                                        objDieuKien.MaDot = cmbMaDot.SelectedValue.ToString().Trim();
                                        objDieuKien.Nam = Int32.Parse(txtNam.Text.Trim());
                                        objDieuKien.MaNganh = dtNganh.Rows[j]["MaNganh"].ToString().Trim();
                                        objDieuKien.IDNganh = dtNganh.Rows[j]["IDNganh"].ToString().Trim();
                                        objDieuKien.MaKhoi = dtNganh.Rows[j]["MaKhoi"].ToString().Trim();
                                        objDieuKien.DiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                                        objDieuKien.DiemSan = double.Parse(txtDiemSan.Text.Trim());
                                        dklist.Add(objDieuKien);
                                    }
                                }
                            }
                        }

                    }
                    //MessageBox.Show(objCongThuc.MaDot +"-"+ objCongThuc.MaKHoi +"-" +objCongThuc.MaMon +"-"+ objCongThuc.MaNganh +"-"+ objCongThuc.Nam.ToString() + "hs"+ objCongThuc.HeSo.ToString());
                    foreach (DieuKien objDK in dklist) {


                        DataTable dt = new DataTable();
                        string sqlCongThuc = string.Format("Select * From t_DieuKien Where idNganh = N'{0}' And MaDot = N'{1}' And MaKhoi = N'{2}' And Nam ={3}", objDK.IDNganh, objDK.MaDot, objDK.MaKhoi, objDK.Nam);
                        dt = dieuKienBS.FinDieuKien(sqlCongThuc);
                        if(dt.Rows.Count<=0)
                        blnResult = dieuKienBS.Insert(objDK);
                    }
                   
                }
                else
                {
                    List<DieuKien> dklist = new List<DieuKien>();
                    DataGridViewRow modifiedRow = dgvCongThuc.SelectedRows[0];
                    madot = modifiedRow.Cells[clmMaDot.Name].Value.ToString();
                    for (int i = 0; i < dgvCongThuc.SelectedRows.Count; i++)
                    {
                        objDieuKien = new DieuKien();
                        objDieuKien.MaDot = dgvCongThuc.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                        objDieuKien.Nam = int.Parse(dgvCongThuc.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                        objDieuKien.MaNganh = dgvCongThuc.SelectedRows[i].Cells[clmMaNganh.Name].Value.ToString();
                        objDieuKien.IDNganh = dgvCongThuc.SelectedRows[i].Cells[clmIDNganh.Name].Value.ToString();
                        objDieuKien.MaKhoi = dgvCongThuc.SelectedRows[i].Cells[clmMaKhoi.Name].Value.ToString();
                        objDieuKien.DiemChuan = double.Parse(txtDiemChuan.Text.Trim());
                        objDieuKien.DiemSan = double.Parse(txtDiemSan.Text.Trim());
                        dklist.Add(objDieuKien);
                        
                    }
                    foreach (DieuKien objDK in dklist)
                    {
                        blnResult = dieuKienBS.Update(objDK);
                    }
                    
                    
                }

                if (blnResult)
                {
                    clsCommon.SaveSuccessfully();

                    //If user is closing form.
                    if (blnIsClosing) return;

                    SetDataSource("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where DK.IDNganh = vNganh.IDNganh");

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
            txtNam.Text=nam.ToString();
            DotXetTuyenService dotXetTuyenService = new DotXetTuyenService();

           DataTable dt = dotXetTuyenService.LoadByNam(nam);
            if (dt.Rows.Count > 0)
            {
                cmbMaDot.DataSource = dt;
                cmbMaDot.DisplayMember = "MaDot";
                cmbMaDot.ValueMember = "MaDot";

                cmbDotTK.DataSource = dt;
                cmbDotTK.DisplayMember = "MaDot";
                cmbDotTK.ValueMember = "MaDot";
            }
           
        NhomNganhService nhomNganhSV = new NhomNganhService();
            string sqlNhomNganh = string.Format("Select * From T_NhomNganh Where LoaiNganh =N'{0}' ", cmbHeXetTuyen.SelectedValue.ToString());
            DataTable dtNhomNganh =nhomNganhSV.FinNhomNganh(sqlNhomNganh);
            DataRow dr1 = dtNhomNganh.NewRow();
            dr1[0] = "ALL"; dr1[1] = "";  dr1[2] = "ALL"; dr1[3] = "";
            dtNhomNganh.Rows.Add(dr1);
            cmbNhomNganh.DataSource = dtNhomNganh;
          cmbNhomNganh.DisplayMember = "TenNganh";
          cmbNhomNganh.ValueMember = "MaNganh";

             KhoiThiService khoiThiBS = new KhoiThiService();
             DataTable dtKhoiThi = khoiThiBS.LoadAll();
             DataRow dr2 = dtKhoiThi.NewRow();
          dr2[0] = "ALL"; dr2[1] = nam; dr2[2] = "ALL";
          dtKhoiThi.Rows.Add(dr2);

          cmbKhoiTK.DataSource = dtKhoiThi;
          cmbKhoiTK.DisplayMember = "TenKhoi";
          cmbKhoiTK.ValueMember = "MaKhoi";
          cmbKhoiTK.SelectedValue = "ALL";
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
           //EnableControls(true);
            txtDiemChuan.Enabled = true;
           txtDiemSan.Enabled = true;
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
                string madot = dgvCongThuc.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                int iNam =int.Parse( dgvCongThuc.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                dieuKienBS.Delete(idNganh, makhoi, madot, iNam);
            }

            SetDataSource("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where DK.IDNganh = vNganh.IDNganh");
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
                DataTable dtNhomNganh = nhomNganhSV.FinNhomNganh(sqlNhomNganh);
                DataRow dr1 = dtNhomNganh.NewRow();
                dr1[0] = "ALL"; dr1[1] = "";  dr1[2] = "ALL"; dr1[3] = "";
                dtNhomNganh.Rows.Add(dr1);
                cmbNhomNganh.DataSource = dtNhomNganh;
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
                DataRow dr1 = dt1.NewRow();
                dr1[0] = "ALL"; dr1[1] = ""; dr1[2] = ""; dr1[3] = nam.ToString(); dr1[4] = "ALL";
                dt1.Rows.Add(dr1);
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

                DataRow dr1 = dt2.NewRow();
                dr1[0] = ""; dr1[1] = ""; dr1[2] = "ALL"; dr1[3] = nam.ToString(); dr1[4] = "";
                dt2.Rows.Add(dr1);
                cmbMaKhoi.DataSource = dt2;
                //MessageBox.Show(maNganh);
                cmbMaKhoi.DisplayMember = "MaKhoi";
                cmbMaKhoi.ValueMember = "MaKhoi";

            }
        }

        private void cmbMaKhoi_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sqlDK = "";
            if (cmbKhoiTK.SelectedValue.ToString() == "ALL")
            {
                if (rdoAll.Checked)
                {
                    sqlDK = string.Format("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where  MaNganh in (select MaNganh From t_NhomNganh Where LoaiNganh =N'{0}') AND MaDot =N'{1}' AND DK.IDNganh = vNganh.IDNganh ", cmbHeTK.SelectedValue.ToString(), cmbDotTK.SelectedValue.ToString());
                }
                if(rdbDH.Checked){
                    sqlDK = string.Format("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where  MaNganh in (select MaNganh From t_NhomNganh Where LoaiNganh =N'{0}') AND Len(MaKhoi)<3 AND MaDot =N'{1}' AND DK.IDNganh = vNganh.IDNganh ", cmbHeTK.SelectedValue.ToString(), cmbDotTK.SelectedValue.ToString());
                }
                if (rdoTHPT.Checked)
                {
                    sqlDK = string.Format("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where  MaNganh in (select MaNganh From t_NhomNganh Where LoaiNganh =N'{0}') AND Len(MaKhoi)>3 AND MaDot =N'{1}' AND DK.IDNganh = vNganh.IDNganh ", cmbHeTK.SelectedValue.ToString(), cmbDotTK.SelectedValue.ToString());
                }
            }
            else {
                sqlDK = string.Format("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where  MaNganh in (select MaNganh From t_NhomNganh Where LoaiNganh =N'{0}') AND MaKhoi =N'{1}' AND MaDot =N'{2}' AND DK.IDNganh = vNganh.IDNganh ", cmbHeTK.SelectedValue.ToString(), cmbKhoiTK.SelectedValue.ToString(), cmbDotTK.SelectedValue.ToString());
            }
            SetDataSource(sqlDK);
        }

        private void bntHienAll_Click(object sender, EventArgs e)
        {
            SetDataSource("SELECT  DK.[IDNganh],DK.[MaNganh],DK.[MaKhoi],DK.[MaDot],DK.[Nam] ,DK.[DiemChuan],DK.[DiemSan],vNganh.TenNganh FROM  t_DieuKien as DK, View_NghanhDistinct as vNganh Where DK.IDNganh = vNganh.IDNganh");
        }

        private void cmbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

                     
    }
}

