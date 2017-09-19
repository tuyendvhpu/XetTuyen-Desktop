
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
    public partial class frmHoSo : frmBase
    {
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        HoSoService hoSoBS = new HoSoService();
        private NganhXetTuyenService nganhXetTuyenBS;
        private Dictionary<int, string> heXTDict;
        private Dictionary<string, string> hanhKiemDict;
        private Dictionary<string, string> loaiHocBaDict;
        private Dictionary<string, string> gioiTinhDict;
        private HoSo objSelectedHoSo;
        //private NganhXetTuyen objNganhXetTuyen;
        private NganhXetTuyen objSelectedNganhXetTuyen;
        private long idHS = 0;
        private string sKetQua = "";
        private string truong10, truong11, truong12;
        #region "Form Events"
        public frmHoSo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            objSelectedHoSo = new HoSo();
          nganhXetTuyenBS = new NganhXetTuyenService();
            //objNganhXetTuyen = new NganhXetTuyen();
            objSelectedNganhXetTuyen = new NganhXetTuyen();
           
            txtNam.Text = DateTime.Now.Year.ToString();
           


            heXTDict = new Dictionary<int, string>();
            heXTDict.Add(0, "Cao đẳng");
            heXTDict.Add(1, "Đại học");
            heXTDict.Add(2, "ĐH + CĐ");

            cmbHeXetTuyen.DataSource = new BindingSource(heXTDict, null); ;

            cmbHeXetTuyen.DisplayMember = "value";
            cmbHeXetTuyen.ValueMember = "key";


            hanhKiemDict = new Dictionary<string, string>();

            hanhKiemDict.Add("Tốt", "Tốt");
            hanhKiemDict.Add("Khá", "Khá");
            hanhKiemDict.Add("Trung Bình", "Trung Bình");
            hanhKiemDict.Add("Yếu", "Yếu");

            cmbHanhKiem.DataSource = new BindingSource(hanhKiemDict, null); ;

            cmbHanhKiem.DisplayMember = "value";
            cmbHanhKiem.ValueMember = "key";
           
            
            


            loaiHocBaDict = new Dictionary<string, string>();

            loaiHocBaDict.Add("Phô tô", "Phô tô");
            loaiHocBaDict.Add("Phô tô công trứng", "Phô tô công trứng");
            loaiHocBaDict.Add("Bản chính", "Bản chính");

            cmbLoaiHocBa.DataSource = new BindingSource(loaiHocBaDict, null); ;

            cmbLoaiHocBa.DisplayMember = "value";
            cmbLoaiHocBa.ValueMember = "key";
            cmbLoaiHocBa.SelectedValue = 0;

            gioiTinhDict = new Dictionary<string, string>();

            gioiTinhDict.Add("Nam", "Nam");
            gioiTinhDict.Add("Nữ", "Nữ");
            gioiTinhDict.Add("Khác", "Khác");

            cmbGioiTinh.DataSource = new BindingSource(gioiTinhDict, null); ;

            cmbGioiTinh.DisplayMember = "value";
            cmbGioiTinh.ValueMember = "key";
            cmbGioiTinh.SelectedValue = 0;

            LoadData();
            dgvHoSo.AutoGenerateColumns = false;


            int online = 0;
            if (rdbOnline.Checked == true)
                online = 1;
            string sqlHS = string.Format("Select * From T_HoSo Where Online ={0} ORDER BY IDHS ", online);
            SetDataSource(sqlHS);
            
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
            bool bsk = true;
            if (!sKetQua.Equals("0"))
            {
                //addmintoanquyen
                if (clsCommon.IsAdminUser)
                {
                    bsk = true;
                }
                else
                {
                    bsk = true;
                }
               // MessageBox.Show(sKetQua);
            }
            ucDataButton1.AddNewVisible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.Insert) && bsk;
            ucDataButton1.EditVisible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.Update) && bsk;
            ucDataButton1.DeleteVisible = hoSoBS.IsAuthorized(HoSoService.HoSoAction.Delete) && bsk;
           //truong hop xet tuyen roi
           
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource(string sqlHS)
        {
            blnIsDataBinding = true;
            
            HoSoCollection hoSoCollection = hoSoBS.FindListHoSo(sqlHS) ;
            //MessageBox.Show(hoSoCollection.Count.ToString());
          
            dgvHoSo.DataSource = hoSoCollection;
            blnIsDataBinding = false;
        }

        /// <summary>
        /// DisplayText
        /// </summary>
        private void LoadData() {
           
          
            DanTocService dantocService = new DanTocService();
            DataTable dt = dantocService.LoadAll();
           
            if (dt.Rows.Count > 0)
            {
                cmbDanToc.DataSource = dt;
                cmbDanToc.DisplayMember = "TenDanToc";
                cmbDanToc.ValueMember = "TenDanToc";
                cmbDanToc.SelectedValue = "Kinh";

            } 
            TinhService tinhService = new TinhService();
            DataTable dt10, dt11, dt12;
            dt = tinhService.LoadAll();

            if (dt.Rows.Count > 0)
            {
                cmbMaTinh.DataSource = dt;
                cmbMaTinh.DisplayMember = "TenTinh";
                cmbMaTinh.ValueMember = "MaTinh";
                cmbMaTinh.SelectedValue = "03";

            }
            TinhService tinhService10 = new TinhService();
            dt10 = tinhService10.LoadAll();
            if (dt10.Rows.Count > 0)
            {
                cmbMaTinh10.DataSource = dt10;
                cmbMaTinh10.DisplayMember = "TenTinh";
                cmbMaTinh10.ValueMember = "MaTinh";
                cmbMaTinh10.SelectedValue = "03";
            }
            TinhService tinhService11 = new TinhService();
            dt11 = tinhService11.LoadAll();
            if (dt11.Rows.Count > 0)
            {
                cmbMaTinh11.DataSource = dt11;
                cmbMaTinh11.DisplayMember = "TenTinh";
                cmbMaTinh11.ValueMember = "MaTinh";
                cmbMaTinh11.SelectedValue = "03";

            }
            TinhService tinhService12 = new TinhService();
            dt12 = tinhService12.LoadAll();
            if (dt11.Rows.Count > 0)
            {
                cmbMaTinh12.DataSource = dt;
                cmbMaTinh12.DisplayMember = "TenTinh";
                cmbMaTinh12.ValueMember = "MaTinh";
                cmbMaTinh12.SelectedValue = "03";

            }
           
            
           //HuyenService huyenService = new HuyenService();
           //dt = huyenService.LoadAll();
           //if (dt.Rows.Count > 0)
           //{
           //    cmbMaHuyen.DataSource = dt;
           //    cmbMaHuyen.DisplayMember = "TenHuyen";
           //    cmbMaHuyen.ValueMember = "MaHuyen";


           //}

            txtNam.Text = Utilities.GetServerTime().Year.ToString();  
           DoiTuongUTService doituongUTService = new DoiTuongUTService();
           int nam = int.Parse(txtNam.Text.ToString());
           dt = doituongUTService.LoadByNam(nam);
           if (dt.Rows.Count > 0)
           {
               cmbMaDoiTuong.DataSource = dt;
               cmbMaDoiTuong.DisplayMember = "MaDT";
               cmbMaDoiTuong.ValueMember = "MaDT";


           }
         
           



        //NganhService nganhService = new NganhService();

        //dt = nganhService.LoadGroupIDNganh(nam);
        //if (dt.Rows.Count > 0)
        //{
        //    cmbChuyenNganh.DataSource = dt;
        //    cmbChuyenNganh.DisplayMember = "TenNganh";
        //    cmbChuyenNganh.ValueMember = "IDNganh";

        //    //cmbKhoiXetTuyen.DataSource = dt;
        //    //cmbKhoiXetTuyen.DisplayMember = "MaKhoi";
        //    //cmbKhoiXetTuyen.ValueMember = "MaKhoi";

        //}
       

     
         
        }
        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {



            sKetQua = dgvHoSo.SelectedRows[0].Cells[clmKetQua.Name].Value.ToString() ;
           
            idHS = long.Parse(dgvHoSo.SelectedRows[0].Cells[clmIDHS.Name].Value.ToString());
          
            txtNam.Text = dgvHoSo.SelectedRows[0].Cells[clmNam.Name].Value.ToString();
            
         

            txtSoBaoDanh.Text= dgvHoSo.SelectedRows[0].Cells[clmSoBaoDanh.Name].Value.ToString();
            txtHoTen.Text = Utilities.StandardString( dgvHoSo.SelectedRows[0].Cells[clmHoTen.Name].Value.ToString());
            txtSoCMTND.Text = dgvHoSo.SelectedRows[0].Cells[clmSoCMTND.Name].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvHoSo.SelectedRows[0].Cells[clmNgaySinh.Name].Value;
            txtSoBaoDanh.Text = dgvHoSo.SelectedRows[0].Cells[clmSoBaoDanh.Name].Value.ToString();
           if( dgvHoSo.SelectedRows[0].Cells[clmGioiTinh.Name].Value !=null)
            cmbGioiTinh.Text = dgvHoSo.SelectedRows[0].Cells[clmGioiTinh.Name].Value.ToString();
            if(dgvHoSo.SelectedRows[0].Cells[clmDanToc.Name].Value!=null)
            cmbDanToc.Text = dgvHoSo.SelectedRows[0].Cells[clmDanToc.Name].Value.ToString();
            txtEmail.Text = dgvHoSo.SelectedRows[0].Cells[clmEmail.Name].Value.ToString();
            if(dgvHoSo.SelectedRows[0].Cells[clmMaTinh.Name].Value!=null)
            cmbMaTinh.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaTinh.Name].Value.ToString();
            if(dgvHoSo.SelectedRows[0].Cells[clmMaHuyen.Name].Value!=null)
            cmbMaHuyen.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaHuyen.Name].Value.ToString();
            if(cmbMaDoiTuong.SelectedValue!=null)
            cmbMaDoiTuong.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmMaDT.Name].Value.ToString();
            txtHoKhau.Text = dgvHoSo.SelectedRows[0].Cells[cmlHoKhau.Name].Value.ToString();
            txtDiaChi.Text = dgvHoSo.SelectedRows[0].Cells[clmDiaChi.Name].Value.ToString();
            txtDienThoai.Text = dgvHoSo.SelectedRows[0].Cells[clmDienThoai.Name].Value.ToString();

            if(dgvHoSo.SelectedRows[0].Cells[clmLop10MaTinh.Name].Value!=null)
            cmbMaTinh10.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop10MaTinh.Name].Value.ToString();
            //txtMaTruong10.Text = 
            if (dgvHoSo.SelectedRows[0].Cells[clmLop10MaTruong.Name].Value != null)
            cmbMaTruong10.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop10MaTruong.Name].Value.ToString();
           // txtLop10.Text = dgvHoSo.SelectedRows[0].Cells[clmLop10.Name].Value.ToString();

          //  txtMaTinh11.Text = 

            if (dgvHoSo.SelectedRows[0].Cells[clmLop11MaTinh.Name].Value != null)
            cmbMaTinh11.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop11MaTinh.Name].Value.ToString();

          //  txtMaTruong11.Text = 
            if (dgvHoSo.SelectedRows[0].Cells[clmLop11MaTruong.Name].Value != null)
            cmbMaTruong11.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop11MaTruong.Name].Value.ToString();
           // txtLop11.Text = dgvHoSo.SelectedRows[0].Cells[clmLop11.Name].Value.ToString();

          //  txtMaTinh12.Text = 
            if (dgvHoSo.SelectedRows[0].Cells[clmLop12MaTinh.Name].Value != null)
            cmbMaTinh12.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop12MaTinh.Name].Value.ToString();
            if (dgvHoSo.SelectedRows[0].Cells[clmLop12MaTruong.Name].Value != null)
          cmbMaTruong12.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLop12MaTruong.Name].Value.ToString();
          //  txtLop12.Text = dgvHoSo.SelectedRows[0].Cells[clmLop12.Name].Value.ToString();

            txtKhuVuc.Text = dgvHoSo.SelectedRows[0].Cells[clmMaKV.Name].Value.ToString();
            txtTruongDuThi.Text = dgvHoSo.SelectedRows[0].Cells[clmTruongDT.Name].Value.ToString();
            txtKhoiDuThi.Text = dgvHoSo.SelectedRows[0].Cells[clmKhoiDT.Name].Value.ToString();
            if (dgvHoSo.SelectedRows[0].Cells[clmHanhKiem.Name].Value != null)
            cmbHanhKiem.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmHanhKiem.Name].Value.ToString();
            chbHocBa.Checked = (bool)dgvHoSo.SelectedRows[0].Cells[clmHocBa.Name].Value;
            cmbLoaiHocBa.Enabled = chbHocBa.Checked;
            if (dgvHoSo.SelectedRows[0].Cells[clmLoaiHocBa.Name].Value != null)
            cmbLoaiHocBa.SelectedValue = dgvHoSo.SelectedRows[0].Cells[clmLoaiHocBa.Name].Value.ToString();
            txtNamTotNghiep.Text = dgvHoSo.SelectedRows[0].Cells[clmNamTotNghiep.Name].Value.ToString();
            chbGiayTotNghiep.Checked = (bool)dgvHoSo.SelectedRows[0].Cells[clmGiayTotNghiep.Name].Value;
            txtTotNghiep.Text = dgvHoSo.SelectedRows[0].Cells[clmTotNghiep.Name].Value.ToString();
            chbLienThong.Checked = (bool)dgvHoSo.SelectedRows[0].Cells[clmLienThong.Name].Value;
            chbNopLePhi.Checked = (bool)dgvHoSo.SelectedRows[0].Cells[clmNopLePhi.Name].Value;
            txtMaHS.Text = dgvHoSo.SelectedRows[0].Cells[clmMaHS.Name].Value.ToString();

            string hext = dgvHoSo.SelectedRows[0].Cells[clmHeXetTuyen.Name].Value.ToString();
           
            cmbHeXetTuyen.SelectedValue =Convert.ToInt32(hext.Trim());
            
            
           // loadNganh();
            //MessageBox.Show(dgvHoSo.SelectedRows[0].Cells[clmHeXetTuyen.Name].Value.ToString());
          //  objNganhXetTuyen = nganhXetTuyenBS.GetNganhXetTuyenByID(long.Parse(dgvHoSo.SelectedRows[0].Cells[clmIDHS.Name].Value.ToString()));

          
           
            
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHoKhau.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtKhoiDuThi.Text = string.Empty;
            txtKhuVuc.Text = string.Empty;
            
           
            txtMaHS.Text = string.Empty;
            
            txtNamTotNghiep.Text = DateTime.Now.Year.ToString();
            txtSoBaoDanh.Text = string.Empty;
            txtSoCMTND.Text = string.Empty;
            txtTenTruongDuThi.Text = string.Empty;
            txtTotNghiep.Text = string.Empty;
            txtTruongDuThi.Text = string.Empty;
            cmbDanToc.SelectedValue = "Kinh";
            chbGiayTotNghiep.Checked = false;
            chbHocBa.Checked = false;
            chbLienThong.Checked = false;
            chbNopLePhi.Checked = false;

            txtNam.Text = Utilities.GetServerTime().Year.ToString();
            cmbHeXetTuyen.SelectedValue = 1;
            cmbMaDoiTuong.SelectedIndex = 0;
            cmbMaTinh.SelectedValue = "03";
           
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
            else
            {
                if (!clsCommon.IsNumber(txtNam.Text.Trim()))
                {
                    MessageBox.Show("Năm phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNam.Focus();
                    return false;
                }
            }
            if (txtMaHS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hồ sơ.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHS.Focus();
                return false;
            }
            else {
                
                string sql = string.Format("Select * From t_HoSo Where MaHS = N'{0}'", txtMaHS.Text.Trim());
                
                //MessageBox.Show(sql);


                if (hoSoBS.FinHoSo(sql).Rows.Count > 0 && ucDataButton1.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Mã hồ sơ đã được sử dụng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHS.Focus();
                    return false;
                }
            }
            if (txtHoTen.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập họ tên.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (txtKhuVuc.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã khu vực.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKhuVuc.Focus();
                return false;
            }
            else
            {

                string sql = string.Format("Select * From t_KhuVuc Where MaKV = N'{0}'", txtKhuVuc.Text.Trim());

                //MessageBox.Show(sql);


                if (hoSoBS.FinHoSo(sql).Rows.Count <=0)
                {
                    MessageBox.Show("Mã khu vực không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKhuVuc.Focus();
                    return false;
                }
            }
            if (txtSoCMTND.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số chứng minh thư nhân dân.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCMTND.Focus();
                return false;
            }
            else
            {

                string sql = string.Format("Select * From t_HoSo Where SoCMTND = N'{0}'", txtSoCMTND.Text.Trim());

                //MessageBox.Show(sql);


                if (hoSoBS.FinHoSo(sql).Rows.Count > 0 && ucDataButton1.DataMode == DataState.Insert)
                {
                    MessageBox.Show("Số chứng minh thư đã được sử dụng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoCMTND.Focus();
                    return false;
                }
            }
            if (cmbGioiTinh.SelectedValue == null)
            {
                //MessageBox.Show(cmbGioiTinh.SelectedValue.ToString());
                MessageBox.Show("Bạn chưa chọn giới tính.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGioiTinh.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() != string.Empty)
            {
                if (!clsCommon.CheckEmailAddress(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Địa chỉ email không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return false;
                }
            }
            if (txtDienThoai.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập điện thoại.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoai.Focus();
                return false;
            } 
            if (txtHoKhau.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập hộ khẩu.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoKhau.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
           
           
            if (cmbMaTruong10.SelectedValue.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn mã trường lớp 10.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaTruong10.Focus();
                return false;
            }


            if (cmbMaTruong11.SelectedValue.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn mã trường lớp 11.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaTruong11.Focus();
                return false;
            }


            if (cmbMaTruong12.SelectedValue.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn mã trường lớp 12.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaTruong12.Focus();
                return false;
            }
            
            if (txtTruongDuThi.Text.Trim() != string.Empty )
            {
                if (txtTenTruongDuThi.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Mã trường dự thi không đúng không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTruongDuThi.Focus();
                    return false;
                }
                if (txtKhoiDuThi.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Bạn chưa nhập khối dự thi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKhoiDuThi.Focus();
                    return false;
                }
                else
                {
                    int nam = DateTime.Today.Year;
                    if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
                    {
                        string sql = string.Format("Select * From t_KhoiThi Where MaKhoi = N'{0}' AND Nam ={1}", txtKhoiDuThi.Text.Trim(),nam);
                        DataTable dtSBD = hoSoBS.FinHoSo(sql);
                        if (dtSBD.Rows.Count == 0)
                        {
                            MessageBox.Show("Khối dự thi không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtKhoiDuThi.Focus();
                            return false;
                        }
                    }
                }
            }
            if (cmbGioiTinh.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn giới tính.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGioiTinh.Focus();
                return false;
            }
            if (cmbHanhKiem.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn hạnh kiểm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbHanhKiem.Focus();
                return false;
            }
            if (cmbMaDoiTuong.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaDoiTuong.Focus();
                return false;
            }
            if (txtNamTotNghiep.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập năm tốt nghiệp.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamTotNghiep.Focus();
                return false;
            }
            else
            {
                if (!clsCommon.IsNumber(txtNamTotNghiep.Text.Trim()))
                {
                    MessageBox.Show("Năm tốt nghiệp phải là kiểu số", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNamTotNghiep.Focus();
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
            txtDiaChi.Enabled = bln;
            txtDienThoai.Enabled = bln;
            txtEmail.Enabled = bln;
            txtHoKhau.Enabled = bln;
            txtHoTen.Enabled = bln;
            txtKhoiDuThi.Enabled = bln;
            txtKhuVuc.Enabled = bln;
            //cmbMaTinh10.Enabled = false;
           // cmbMaTinh11.Enabled = false;
           // cmbMaTinh12.Enabled = false;
           cmbMaTinh10.Enabled = bln;
            cmbMaTinh11.Enabled = bln;
            cmbMaTinh12.Enabled = bln;
            cmbMaTruong10.Enabled = bln;
            cmbMaTruong11.Enabled = bln;
            cmbMaTruong12.Enabled = bln;
            txtNam.Enabled = bln;
            txtMaHS.Enabled = bln;
            txtNamTotNghiep.Enabled = bln;
            txtSoBaoDanh.Enabled = false;
            txtSoCMTND.Enabled = bln;
            txtTenTruongDuThi.Enabled = false;
            txtTotNghiep.Enabled = bln;
            txtTruongDuThi.Enabled = bln;
            cmbDanToc.Enabled = bln;
            chbGiayTotNghiep.Enabled = bln;
            chbHocBa.Enabled = bln;
            chbLienThong.Enabled = bln;
            chbNopLePhi.Enabled = bln;
            dtpNgaySinh.Enabled = bln;
            cmbGioiTinh.Enabled = bln;
            cmbHeXetTuyen.Enabled = bln;
           
           
            cmbMaDoiTuong.Enabled = bln;
            cmbHanhKiem.Enabled = bln;
            cmbMaTinh.Enabled = bln;
            cmbMaHuyen.Enabled = bln;
            btnChonNganh.Enabled = !bln;
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsChangedData()
        {
            if (ucDataButton1.DataMode == DataState.Edit)
            {
                DataGridViewRow modifiedRow = dgvHoSo.SelectedRows[0];

                if (modifiedRow.Cells[clmIDHS.Name].Value.ToString() != txtSoBaoDanh.Text.Trim()
                    || modifiedRow.Cells[clmHoTen.Name].Value.ToString() != txtHoTen.Text.Trim()
                    || modifiedRow.Cells[clmSoCMTND.Name].Value.ToString() != txtSoCMTND.Text.Trim()
                    || modifiedRow.Cells[clmEmail.Name].Value.ToString() != txtEmail.Text.Trim()
                    || modifiedRow.Cells[cmlHoKhau.Name].Value.ToString() != txtHoKhau.Text.Trim()
                    || modifiedRow.Cells[clmDiaChi.Name].Value.ToString() != txtDiaChi.Text.Trim()
                    )
                    return true;

            }
            else if (ucDataButton1.DataMode == DataState.Edit)
            {
                if (
                    txtSoBaoDanh.Text.Trim() != string.Empty
                    || txtHoTen.Text.Trim() != string.Empty
                    || txtSoCMTND.Text.Trim() != string.Empty
                    || txtHoKhau.Text.Trim() != string.Empty
                    || txtDiaChi.Text.Trim() != string.Empty
                    )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save Data
        /// </summary>
        private void SaveData()
        {
            

            HoSo objHoSo = new HoSo();
           // string madot="";
            bool blnResult = false;

            objHoSo.DangXetTuyen = true;
            if (cmbDanToc.SelectedValue != null)
            objHoSo.DanToc = cmbDanToc.SelectedValue.ToString();
            objHoSo.DiaChi = txtDiaChi.Text.Trim();
            objHoSo.DienThoai = txtDienThoai.Text.Trim();
            objHoSo.Email = txtEmail.Text.Trim();
            objHoSo.GiayTotNghiep = chbGiayTotNghiep.Checked;
            if (cmbGioiTinh.SelectedValue != null)
            objHoSo.GioiTinh = cmbGioiTinh.SelectedValue.ToString();
            if (cmbHanhKiem.SelectedValue != null)
            objHoSo.HanhKiem = cmbHanhKiem.SelectedValue.ToString();
            if (cmbHeXetTuyen.SelectedValue != null)
            objHoSo.HeXetTuyen = byte.Parse(cmbHeXetTuyen.SelectedValue.ToString());
            objHoSo.HinhThuc = 1;
            objHoSo.HocBa = chbHocBa.Checked;
            objHoSo.HoKhau = txtHoKhau.Text.Trim();
            objHoSo.HoTen = Utilities.StandardString( txtHoTen.Text.Trim());
            objHoSo.MaHS = txtMaHS.Text.Trim();
            objHoSo.KhoiDT = txtKhoiDuThi.Text.Trim();
            objHoSo.LienThong = chbLienThong.Checked;
            if (cmbLoaiHocBa.SelectedText != null)
            objHoSo.LoaiHocBa = cmbLoaiHocBa.SelectedText;
            objHoSo.Lop10 = truong10;
            if (cmbMaTinh10.SelectedValue != null)
            objHoSo.Lop10MaTinh = cmbMaTinh10.SelectedValue.ToString().Trim();
            if (cmbMaTruong10.SelectedValue != null)
            objHoSo.Lop10MaTruong = cmbMaTruong10.SelectedValue.ToString().Trim();
            objHoSo.Lop11 = truong11;
            if (cmbMaTinh11.SelectedValue != null)
            objHoSo.Lop11MaTinh = cmbMaTinh11.SelectedValue.ToString().Trim();
            if (cmbMaTruong11.SelectedValue != null)
            objHoSo.Lop11MaTruong =cmbMaTruong11.SelectedValue.ToString().Trim();
            objHoSo.Lop12 = truong12;
            if (cmbMaTinh12.SelectedValue != null)
            objHoSo.Lop12MaTinh = cmbMaTinh12.SelectedValue.ToString().Trim();
            if (cmbMaTruong12.SelectedValue != null)
            objHoSo.Lop12MaTruong = cmbMaTruong12.SelectedValue.ToString().Trim();
            if (cmbMaDoiTuong.SelectedValue != null)
            objHoSo.MaDT = cmbMaDoiTuong.SelectedValue.ToString();
            if (cmbMaHuyen.SelectedValue!=null)
            objHoSo.MaHuyen = cmbMaHuyen.SelectedValue.ToString();
            objHoSo.MaKV = txtKhuVuc.Text.Trim();
            if (cmbMaTinh.SelectedValue != null)
            objHoSo.MaTinh = cmbMaTinh.SelectedValue.ToString();
            objHoSo.Nam = int.Parse(txtNam.Text.Trim());
            objHoSo.NamTotNghiep = int.Parse(txtNamTotNghiep.Text.Trim());
           
            objHoSo.NgaySinh = dtpNgaySinh.Value;
            objHoSo.NgaySua = Utilities.GetServerTime();
            
            objHoSo.NguoiSua = clsCommon.CurrentUser.LoginID;
            objHoSo.NopLePhi = chbNopLePhi.Checked;
            objHoSo.Online = false;
          
            objHoSo.SoBaoDanh = txtSoBaoDanh.Text.Trim();
            objHoSo.SoCMTND = txtSoCMTND.Text.Trim();
            objHoSo.MaHS = txtMaHS.Text.Trim();
            objHoSo.TotNghiep = txtTotNghiep.Text.Trim();
            objHoSo.TruongDT = txtTruongDuThi.Text.Trim();

            //KhuVucService khuVucBS = new KhuVucService();
            //KhuVuc objKhuVuc = khuVucBS.GetKhuVucByID(txtKhuVuc.Text.Trim());
            //if (objKhuVuc != null)
            // //   objNganhXetTuyen.DiemUTKV = objKhuVuc.DienUT;

            //DoiTuongUTService doiTuongUTBS = new DoiTuongUTService();
            //DoiTuongUT objDoiTuongUT = doiTuongUTBS.GetDoiTuongByID(txtKhuVuc.Text.Trim());
            //if (objDoiTuongUT != null)
            //    //objNganhXetTuyen.DiemUTDT = objDoiTuongUT.DiemUT;

           
            int nam = DateTime.Now.Year;
            if(txtNam.Text.Trim().Length>0&& clsCommon.IsNumber(txtNam.Text.Trim()))
            {
                nam =int.Parse( txtNam.Text.Trim());
            }
            //objNganhXetTuyen.Nam = nam;
            



            if (ucDataButton1.DataMode == DataState.Insert)
            {
               // MessageBox.Show(objHoSo.MaHS);
                objHoSo.NgayNhap = Utilities.GetServerTime();
                objHoSo.NguoiNhap = clsCommon.CurrentUser.LoginID;
                objHoSo.SoBaoDanh = hoSoBS.GetSoBaoDanh(nam, "DHP", 6);
                blnResult = hoSoBS.Insert(objHoSo);
                if (blnResult) {

                    objHoSo = hoSoBS.GetHoSoByMaHS(txtMaHS.Text.Trim());
                    
                    
                }
            }
            else
            {
                DataGridViewRow modifiedRow = dgvHoSo.SelectedRows[0];
                objHoSo.Idhs = long.Parse(modifiedRow.Cells[clmIDHS.Name].Value.ToString());
                objHoSo.NguoiNhap = modifiedRow.Cells[clmNguoiNhap.Name].Value.ToString();
                objHoSo.NgayNhap = (DateTime) modifiedRow.Cells[clmNgayNhap.Name].Value;
                if(objHoSo.SoBaoDanh.Length<=0)
                    objHoSo.SoBaoDanh = hoSoBS.GetSoBaoDanh(nam, "DHP", 6);
                //Luu vet update ho so
                HoSo objHosoOld = hoSoBS.GetHoSoByID(long.Parse(modifiedRow.Cells[clmIDHS.Name].Value.ToString()));

                AudidService audiBS = new AudidService();

                audiBS.AdidHoSo(objHosoOld, objHoSo, clsCommon.CurrentUser.LoginID, "Update");
                blnResult = hoSoBS.Update(objHoSo);
                if (blnResult)
                {
                   // objNganhXetTuyen.Idhs = objHoSo.Idhs;
                    
                }
            }

            if (blnResult)
            {
                //string soBD = "DHP";
                //string khoi = objNganhXetTuyen.MaKhoi.Replace("THPT_", "");
                //soBD = soBD + khoi + "." + objHoSo.Idhs.ToString();
                //if (objNganhXetTuyen.MaKhoi.Length > 7)
                //{
                //    soBD = soBD + objNganhXetTuyen.MaKhoi.Substring(5, 2) + "." + objHoSo.Idhs.ToString();
                //}
                //else
                //    if (objNganhXetTuyen.MaKhoi.Length > 1)
                //    {
                //        soBD = soBD + objNganhXetTuyen.MaKhoi.Substring(5, 1) + "." + objHoSo.Idhs.ToString();
                //    }
                //    else {
                //        soBD = soBD + objNganhXetTuyen.MaKhoi + "." + objHoSo.Idhs.ToString();
                //    }
               
                //hoSoBS.Update(objHoSo);
                
                clsCommon.SaveSuccessfully();

                //If user is closing form.
                if (blnIsClosing) return;
                int online = 0;
                if (rdbOnline.Checked == true)
                    online = 1;
                string sqlHS = string.Format("Select * From T_HoSo Where Online ={0} ORDER BY IDHS ",online);
                SetDataSource(sqlHS);

                //Set selected row
                for (int i = 0; i < dgvHoSo.RowCount; i++)
                {
                    if (dgvHoSo.Rows[i].Cells[clmIDHS.Name].Value.ToString() == objHoSo.Idhs.ToString())
                    {   dgvHoSo.CurrentCell = dgvHoSo.Rows[i].Cells[1];
                        break;
                    }
                }
                idHS = objHoSo.Idhs;
                ucDataButton1.DataMode = DataState.View;
               
            }
            else
            {
                
                clsCommon.SaveNotSuccessfully();
                return;
            }
        }

        private string TruongPT(string matinh, string matruongPT)
        {
            TruongPTService truongPTBS = new TruongPTService();
            string ten = "";
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {
                DataTable dt = truongPTBS.LoadByPrimaryKey(matruongPT, matinh, nam);
                if (dt.Rows.Count > 0)
                {
                    ten = dt.Rows[0]["TenTruong"].ToString() + " - " + dt.Rows[0]["Diachi"].ToString();

                }
            }
            return ten;

        }

        private string TruongPT_KV(string matinh, string matruongPT)
        {
            TruongPTService truongPTBS = new TruongPTService();
            string smaKV = "";
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {
                DataTable dt = truongPTBS.LoadByPrimaryKey(matruongPT, matinh, nam);
                if (dt.Rows.Count > 0)
                {
                    smaKV = dt.Rows[0]["MaKV"].ToString();

                }
            }
            return smaKV;

        }

        private string TruongDH(string matruongDH)
        {
            TruongDHService truongDHBS = new TruongDHService();
            string ten = "";
            int nam = DateTime.Today.Year;
            if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
            {
                DataTable dt = truongDHBS.LoadByPrimaryKey(matruongDH, nam);
                if (dt.Rows.Count > 0)
                {
                    ten = dt.Rows[0]["TenTruong"].ToString();

                }
            }
            return ten;

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

            txtNam.Focus();
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            EnableControls(true);
            txtNam.Enabled = false;
            txtSoBaoDanh.Enabled = false;
            
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

            for (int i = 0; i < dgvHoSo.SelectedRows.Count; i++)
            {

                //string idHS = dgvHoSo.SelectedRows[i].Cells[clmIDHS.Name].Value.ToString();
                //string sNam = dgvHoSo.SelectedRows[i].Cells[clmNam.Name].Value.ToString();
                
                //if (dotXetTuyenBS.FinDotXetTuyen(sql).Rows.Count > 0 || dotXetTuyenBS.FinDotXetTuyen(sql2).Rows.Count>0)
                //{
                //    //Admin group is not allowed to delete
                //    MessageBox.Show(string.Format("Đợt xét tuyển [{0}] đang được sử dụng không được phép xoá.", dgvHoSo.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString()), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }

            AudidService audiBS = new AudidService();
            HoSo objHoSoDel = new HoSo();
            NganhXetTuyen objNganhXTDel = new NganhXetTuyen();
            DiemXetTuyen objDiemXTDel = new DiemXetTuyen();
            for (int i = 0; i < dgvHoSo.SelectedRows.Count; i++)
            {
                long IdHS =long.Parse( dgvHoSo.SelectedRows[i].Cells[clmIDHS.Name].Value.ToString());
                int iNam =int.Parse( dgvHoSo.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                
                //Luu vet xoa ho so
               
                HoSo objHosoOld = hoSoBS.GetHoSoByID(long.Parse(dgvHoSo.SelectedRows[i].Cells[clmIDHS.Name].Value.ToString()));

                audiBS.AdidHoSo(objHosoOld, objHoSoDel, clsCommon.CurrentUser.LoginID, "Delete");

                DiemXetTuyenService diemXetTuyenBS = new DiemXetTuyenService();

                
                //Luu Vet xoa diem xt
                DiemXetTuyenCollection diemXetTuyenCollection = diemXetTuyenBS.GetListDiemXetTuyen(idHS);
                foreach (DiemXetTuyen objDiemXT in diemXetTuyenCollection)
                {
                    audiBS.AdidDiemXetTuyen(objDiemXT, objDiemXTDel, clsCommon.CurrentUser.LoginID, "Delete");

                }
                diemXetTuyenBS.Delete(IdHS);


                // Luu vet xoa nganh xet tueyn
               
             

                NganhXetTuyenCollection objNganhXTOldCollentinon = nganhXetTuyenBS.GetNganhXetTuyenByID(IdHS);
                foreach (NganhXetTuyen objNganhXTOld in objNganhXTOldCollentinon)
                {
                    //MessageBox.Show(objNganhXTOld.IDNganh);
                    audiBS.AdidNganhXetTuyen(objNganhXTOld, objNganhXTDel, clsCommon.CurrentUser.LoginID, "Delete");
                }
                nganhXetTuyenBS.DeleteByIDHS(IdHS,iNam);
                hoSoBS.Delete(IdHS); 
               
            }

            int online = 0;
            if (rdbOnline.Checked == true)
                online = 1;
            string sqlHS = string.Format("Select * From T_HoSo Where Online ={0} ORDER BY IDHS", online);
            SetDataSource(sqlHS);

            if (dgvHoSo.RowCount > 0)
            {
                dgvHoSo.CurrentCell = null;

                dgvHoSo.CurrentCell = dgvHoSo.Rows[0].Cells[1];
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
            //LoadData();
            DisplayText();
            this.EnableControls(false);
            ucDataButton1.DataMode = DataState.View;
            SetAuthorization();
            
        }

        private void cmbHeXetTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbNganhXetTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           

        }

        private void cmbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    NganhService nganhService = new NganhService();
        //    string maNganh = cmbChuyenNganh.SelectedValue.ToString();
            
        //    int nam = DateTime.Today.Year;
        //    if (txtNam.Text.ToString().Trim().Length > 0 && clsCommon.IsNumber(txtNam.Text.ToString().Trim()))
        //    {



        //        DataTable dt = nganhService.LoadKhoiByNganh(maNganh, nam);
        //        cmbKhoiXetTuyen.DataSource = dt;
        //        MessageBox.Show(maNganh);
        //        cmbKhoiXetTuyen.DisplayMember = "MaKhoi";
        //        cmbKhoiXetTuyen.ValueMember = "MaKhoi";
        //    }
        }

        private void cmbMaTinh_SelectedValueChanged(object sender, EventArgs e)
        {
            HuyenService huyenService = new HuyenService();
            string matinh = "";
            if (cmbMaTinh.SelectedValue != null)
                matinh = cmbMaTinh.SelectedValue.ToString();
          //  MessageBox.Show(matinh);
           




                DataTable dt2 = huyenService.LoadByMaTinh(matinh);

                cmbMaHuyen.DataSource = dt2;
                //MessageBox.Show(maNganh);
                cmbMaHuyen.DisplayMember = "TenHuyen";
                cmbMaHuyen.ValueMember = "MaHuyen";

            
        }

       

        private void txtTruongDuThi_TextChanged(object sender, EventArgs e)
        {
            txtTenTruongDuThi.Text = TruongDH(txtTruongDuThi.Text.Trim());
        }

        private void txtHoKhau_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            //frmDiemXetTuyen frmdiemXetTuyen = new frmDiemXetTuyen();
            //frmdiemXetTuyen.meShowDailog(idHS);
            frmNganhXT frmnganhXT = new frmNganhXT();

            frmnganhXT.ShowDialog(hoSoBS.GetHoSoByID(idHS));
        }

        private void dgvHoSo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //dgvHoSo.Rows[e.RowIndex].Cells["clmSTT"].Value = e.RowIndex + 1;
        }

        private void grbLop12_Enter(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            int online = 0;
            if (rdbOnline.Checked == true)
                online = 1;
            
         
            string sqlHS = string.Format( "Select * From T_HoSo WHERE IDHS IS NOT NULL AND Online ={0} ",online);
            string MaHSFind = txtMaHSFind.Text.Trim().Replace("'", "''");
            string SoCMTNDFind = txtSoCMTNDFind.Text.Trim().Replace("'", "''");
            if (MaHSFind.Length > 0 && !Utilities.checkForSQLInjection(MaHSFind))
            {

                sqlHS = sqlHS + " AND MaHS LIKE  N'%" + MaHSFind + "%' ";
                
            }
            if (SoCMTNDFind.Length > 0 && !Utilities.checkForSQLInjection(SoCMTNDFind))
            {

                sqlHS = sqlHS + " AND SoCMTND LIKE  N'%" + SoCMTNDFind + "%' ";
            }

            sqlHS = sqlHS + " ORDER BY IDHS ";
            SetDataSource(sqlHS);
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            SetDataSource("Select * From T_HoSo ORDER BY IDHS");

        }

        private void cmbMaTruong10_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMaTruong10.SelectedValue == null) return;
            truong10 = TruongPT(cmbMaTinh10.SelectedValue.ToString().Trim(), cmbMaTruong10.SelectedValue.ToString().Trim());
        }

        private void cmbMaTruong11_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMaTruong11.SelectedValue == null) return;
            truong11 = TruongPT(cmbMaTinh11.SelectedValue.ToString().Trim(), cmbMaTruong11.SelectedValue.ToString().Trim());

        }

        private void cmbMaTruong12_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMaTruong12.SelectedValue == null) return;
            truong12 = TruongPT(cmbMaTinh12.SelectedValue.ToString().Trim(), cmbMaTruong12.SelectedValue.ToString().Trim());
            txtKhuVuc.Text = TruongPT_KV(cmbMaTinh12.SelectedValue.ToString().Trim(), cmbMaTruong12.SelectedValue.ToString().Trim());
        }

        private void cmbMaTinh10_SelectedValueChanged(object sender, EventArgs e)
        {
          if(  cmbMaTinh10.SelectedValue ==null) return;
            cmbMaTinh11.SelectedValue = cmbMaTinh10.SelectedValue;
            string matinh = "";
            if (cmbMaTinh10.SelectedValue != null)
                matinh = cmbMaTinh10.SelectedValue.ToString().Trim();
            
            TruongPTService ptService = new TruongPTService();
            DataTable dt = ptService.LoadByMaTinh( matinh,DateTime.Today.Year);
            if (dt.Rows.Count > 0) {
                cmbMaTruong10.DataSource = dt;
                cmbMaTruong10.DisplayMember = "TenTruong";
                cmbMaTruong10.ValueMember = "MaTruong";
                cmbMaTruong10.SelectedIndex = 0;
            }
        }

        private void cmbMaTinh11_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMaTinh11.SelectedValue == null) return;
            cmbMaTinh12.SelectedValue = cmbMaTinh11.SelectedValue;
            string matinh = "";
            if (cmbMaTinh11.SelectedValue != null)
                matinh = cmbMaTinh11.SelectedValue.ToString().Trim();

            TruongPTService ptService = new TruongPTService();
            DataTable dt = ptService.LoadByMaTinh(matinh, DateTime.Today.Year);
            if (dt.Rows.Count > 0)
            {
                cmbMaTruong11.DataSource = dt;
                cmbMaTruong11.DisplayMember = "TenTruong";
                cmbMaTruong11.ValueMember = "MaTruong";
                cmbMaTruong11.SelectedIndex = 0;
            }

        }

        private void cmbMaTinh12_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMaTinh12.SelectedValue == null) return;
            string matinh = "";
            if (cmbMaTinh12.SelectedValue != null)
                matinh = cmbMaTinh12.SelectedValue.ToString().Trim();

            TruongPTService ptService = new TruongPTService();
            DataTable dt = ptService.LoadByMaTinh(matinh, DateTime.Today.Year);
            if (dt.Rows.Count > 0)
            {
                cmbMaTruong12.DataSource = dt;
                cmbMaTruong12.DisplayMember = "TenTruong";
                cmbMaTruong12.ValueMember = "MaTruong";
                cmbMaTruong12.SelectedIndex = 0;
            }
        }

        private void chbHocBa_CheckedChanged(object sender, EventArgs e)
        {
           
                cmbLoaiHocBa.Enabled = chbHocBa.Checked;
           

        }

        private void chbGiayTotNghiep_CheckedChanged(object sender, EventArgs e)
        {
            txtTotNghiep.Enabled = chbGiayTotNghiep.Checked;

        }

        private void txtTotNghiep_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucDataButton1_Load(object sender, EventArgs e)
        {

        }

        private void cmbMaTruong10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaTruong10.SelectedValue == null) return;
            cmbMaTinh11.SelectedValue = cmbMaTinh10.SelectedValue;
            cmbMaTruong11.SelectedValue = cmbMaTruong10.SelectedValue;
        }

        private void cmbMaTruong11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaTruong11.SelectedValue == null) return;
            cmbMaTinh12.SelectedValue = cmbMaTinh11.SelectedValue;
            cmbMaTruong12.SelectedValue = cmbMaTruong11.SelectedValue;
        }

        private void grpDetailInfo_Enter(object sender, EventArgs e)
        {

        }

        private void dgvHoSo_MouseClick(object sender, MouseEventArgs e)
        {
            if (blnIsDataBinding || dgvHoSo.SelectedRows.Count == 0) return;
            //LoadData();
            DisplayText();
            this.EnableControls(false);
            ucDataButton1.DataMode = DataState.View;
            SetAuthorization();
        }

        private void dgvHoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

                     
    }
}

