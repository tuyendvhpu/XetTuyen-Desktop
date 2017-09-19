
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
    public partial class frmDiemXetTuyen : frmBase
    {
        bool blnIsDataBinding = true;
        bool blnIsClosing = false;
        DiemXetTuyenService diemXetTuyenBS = new DiemXetTuyenService();
        private  long idhs = 0;
        HoSoService hoSoBS;
        NganhXetTuyenService nganhXetTuyenBS;
       // NganhXetTuyen objNganhXetTuyen;
        private Regex decimalRegex = null;
        HoSo objHoSo;
        #region "Form Events"
        public frmDiemXetTuyen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmGroup_Load
        /// </summary>        
        private void frmGroup_Load(object sender, EventArgs e)
        {
            dgvDienXetTuyen.AutoGenerateColumns = false;
           // MessageBox.Show(idhs.ToString());
             hoSoBS = new HoSoService();
             objHoSo = hoSoBS.GetHoSoByID(idhs);
            txtHoTen.Text = objHoSo.HoTen;
            
            txtSoBaoDanh.Text = objHoSo.SoBaoDanh;
            txtMaHS.Text = objHoSo.MaHS;
            nganhXetTuyenBS = new NganhXetTuyenService();
          
            SetDataSource();
            
            EnableControls(false);

            SetAuthorization();
        }

        public void ShowDialog(long idHS)
         {
             this.idhs = idHS;
             this.ShowDialog();
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
            //ucDataButton1.AddNewVisible = diemXetTuyenBS.IsAuthorized(DiemXetTuyenService.DiemXetTuyenAction.Insert);
            ucDataButton1.EditVisible = diemXetTuyenBS.IsAuthorized(DiemXetTuyenService.DiemXetTuyenAction.Update);
            //ucDataButton1.DeleteVisible = diemXetTuyenBS.IsAuthorized(DiemXetTuyenService.DiemXetTuyenAction.Delete);
            //ucDataButton1.MultiLanguageVisible = groupBS.IsAuthorized(clsGroupBS.GroupAction.MultilangUI);
        }

        /// <summary>
        /// Set Data Source for DataGridView
        /// </summary>
        private void SetDataSource()
        {
            blnIsDataBinding = true;
           
            string sqlnganh = string.Format("SELECT DISTINCT Makhoi from t_NganhXetTuyen Where IDHS ={0}", idhs);
            DataTable dtKhoi = nganhXetTuyenBS.FinNganhXetTuyen(sqlnganh);
            cmbKhoiXT.DataSource = dtKhoi;
            cmbKhoiXT.DisplayMember="Makhoi";
            cmbKhoiXT.ValueMember = "Makhoi";


           // MessageBox.Show(cmbKhoiXT.SelectedValue.ToString());





            if (cmbKhoiXT.SelectedValue != null)
                LoadDiem(objHoSo.Idhs, cmbKhoiXT.SelectedValue.ToString());
        }
        private void LoadDiem(long idHS, string maKhoi)
        {
            //MessageBox.Show(idhs.ToString());
            //string sql = string.Format("SELECT dxt.IDHS, dxt.MaMon, dxt.Diem, km.ViTri From (select * from  t_DiemXetTuyen where IDHS={0}) as dxt INNER JOIN (select * from  t_KhoiMon where MaKHoi=N'{1}') as km  on dxt.MaMon = km.MaMon  Order by km.ViTri", idHS, maKhoi);
            DiemXetTuyenCollection diemXetTuyenCollection = diemXetTuyenBS.GetListDiemXetTuyen(idhs);
            dgvDienXetTuyen.DataSource = diemXetTuyenBS.LoadByIdHSAndMaKhoi(idhs,maKhoi);
            string sqlNganhXT = string.Format("SELECT DISTINCT Makhoi,[DiemTB],[DiemUTKV],[DiemUTDT],[DiemTXT],[TrangThai] from t_NganhXetTuyen Where IDHS ={0} AND MaKhoi = N'{1}'", idHS, maKhoi);

            DataTable dtNganh = nganhXetTuyenBS.FinNganhXetTuyen(sqlNganhXT);

            if (dtNganh.Rows.Count > 0)
            {
                txtDiemTB.Text = dtNganh.Rows[0]["DiemTB"].ToString();
                txtDiemUTKV.Text = dtNganh.Rows[0]["DiemUTKV"].ToString();
                txtDiemUTDT.Text = dtNganh.Rows[0]["DiemUTDT"].ToString();
                txtTongDiem.Text = dtNganh.Rows[0]["DiemTXT"].ToString();
            }
            blnIsDataBinding = false;
        }
        /// <summary>
        /// DisplayText
        /// </summary>
        private void DisplayText()
        {
           // txtMaNganh.Text = dgvDienXetTuyen.SelectedRows[0].Cells[clmMaDot.Name].Value.ToString();
           
        }

        /// <summary>
        /// ClearText
        /// </summary>
        private void ClearText()
        {
            //txtMaNganh.Text = string.Empty;
            
        }

        /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
        private bool IsDataOK()
        {
            //if (txtMaNganh.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Bạn chưa nhập mã đợt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
           
            return true;
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        private void EnableControls(bool bln)
        {            
            //txtMaNganh.Enabled = bln;
            dgvDienXetTuyen.Columns["clmDiem"].ReadOnly= !bln;
            cmbKhoiXT.Enabled = !bln;
            
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

            bool blnResult = false;


            double TongDiem = 0;

                if (ucDataButton1.DataMode == DataState.Edit)
                {
                    /* Vị Trí điểm
                    double diem1 = 0; double diem2 = 0; double diem3 = 0; double diem4 = 0; double diem5 = 0; double diem6 = 0;
                    double diem7 = 0; double diem8 = 0; double diem9 = 0; double diem10 = 0; double diem11 = 0; double diem12 = 0;
                    double diem13 = 0; double diem14 = 0; double diem15 = 0; double diem16 = 0; double diem17 = 0; double diem18 = 0;
                    */
                    for (int i = 0; i < dgvDienXetTuyen.RowCount; i++)
                    {
                        
                        DiemXetTuyen objDiemXetTuyen = new DiemXetTuyen();
                        objDiemXetTuyen.Idhs = idhs;
                        objDiemXetTuyen.MaKhoi = cmbKhoiXT.SelectedValue.ToString();
                        objDiemXetTuyen.MaMon = Convert.ToInt32( dgvDienXetTuyen.Rows[i].Cells[clmMaMon.Name].Value.ToString().Trim());
                        objDiemXetTuyen.Diem = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                        TongDiem += (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                        /* Cập nhập bảng trung tuyển
                        int vitri = (int)dgvDienXetTuyen.Rows[i].Cells[clmViTri.Name].Value;
                        //MessageBox.Show(vitri.ToString());
                        switch (vitri) { 
                       
                            case 1:
                                diem1 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                            case 2:
                               diem2 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 3:
                               diem3 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 4:
                               diem4 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 5:
                               diem5 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 6:
                               diem6 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 7:
                               diem7 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 8:
                               diem8 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 9:
                               diem9 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 10:
                               diem10 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 11:
                               diem11 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 12:
                               diem12 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 13:
                               diem13 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 14:
                               diem14 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 15:
                               diem15 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 16:
                               diem16 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                                case 17:
                               diem17 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                            case 18:
                               diem18 = (double)dgvDienXetTuyen.Rows[i].Cells[clmDiem.Name].Value;
                               break;
                            default:
                              
                               break;
                        
                        }
                         */

                        AudidService audBS = new AudidService();
                        DiemXetTuyen objDiemXTOld = diemXetTuyenBS.LoadByIdHSAndMaKhoiAndMaMon(idhs, cmbKhoiXT.SelectedValue.ToString(), Convert.ToInt32(dgvDienXetTuyen.Rows[i].Cells[clmMaMon.Name].Value.ToString().Trim()));
                        audBS.AdidDiemXetTuyen(objDiemXTOld, objDiemXetTuyen, clsCommon.CurrentUser.LoginID, "Update");
                        diemXetTuyenBS.Update(objDiemXetTuyen);
                        
                    }
                    
                   if(Utilities.loadCompany() )
                   {
                       blnResult = hoSoBS.UpdateDiemTB(idhs, Utilities.acCompConfig.so);
                      // MessageBox.Show(objHoSo.MaHS + "id: " + idhs);
                   }else{ blnResult =hoSoBS.UpdateDiemTB(idhs,2);}
                   
                   
                    //Cần Xem Lại - Trả về danh sách đối tượng*************************************
                 /*
                    NganhXetTuyenCollection nganhXTCollection = nganhXetTuyenBS.GetNganhXetTuyenByID(idhs);
                   foreach(NganhXetTuyen objNganhXT in nganhXTCollection){
                       if (objNganhXT.MaKhoi == cmbKhoiXT.SelectedValue.ToString().Trim() )
                       {
                           double DiemTB = Math.Round((TongDiem / dgvDienXetTuyen.RowCount), 2, MidpointRounding.ToEven);
                           
                           objNganhXT.DiemTB = DiemTB;

                         //  MessageBox.Show("Diem TB: " + objNganhXT.DiemTB.ToString());
                           double DiemTXT = DiemTB + objNganhXT.DiemUTDT + objNganhXT.DiemUTKV;
                           
                           objNganhXT.DiemTXT = DiemTXT;
                           
                        //  MessageBox.Show("DiemTXT: " + objNganhXT.DiemTXT.ToString());
                           
                       //nganhXetTuyenBS.Update(objNganhXT);
                       }
                   }
                    */
                    //Kiem tra xem co du diem do khong tuong ung voi nganh da dang ky
                   // bool kt = false;
                    //string Soqd="";
                    /*
                    if(objHoSo.HeXetTuyen==0){
                        if (objNganhXetTuyen.DiemTB >= 5.5)
                        {
                            kt = true;
                             
                          
                        }
                        else { 
                             kt = false;
                             lblThongBao.Text = "Bạn không đủ điểm vui lòng đăng ký ngành khác! ";
                        }
                    }
                    if (objHoSo.HeXetTuyen == 1)
                    {
                        if (objNganhXetTuyen.DiemTB >= 6.0)
                        {
                            kt = true;
                             
                            
                        }
                        else
                        {
                            kt = false;
                            lblThongBao.Text = "Bạn không đủ điểm vui lòng đăng ký ngành khác! ";
                        }
                    }
                     */
                    /*inset vao bảng trúng tuyển
                    //Kiem tra da co idhs va Mahs da co trong bang cu chua
                    string sql = string.Format("Select * From t_TrungTuyen Where idhs = {0} AND MaHS = N'{1}' ", idhs,objHoSo.MaHS);
                    DataTable dt = hoSoBS.FinHoSo(sql);
                    if (dt.Rows.Count <= 0)
                    {
                        if (kt)
                        {
                            string khoi = "";
                            khoi = objNganhXetTuyen.MaKhoi.Replace("THPT_","");
                            Soqd = hoSoBS.GetSoQuyetDinh(objNganhXetTuyen.IDNganh);
                           
                          if( diemXetTuyenBS.InsertTrungTuyen(objHoSo.Idhs, objHoSo.MaHS, khoi, diem1, diem2, diem3, diem4, diem5, diem6, diem7, diem8, diem9, diem10, diem11, diem12, diem13, diem14, diem15, diem16, diem17, diem18, objNganhXetTuyen.MaKhoi, objNganhXetTuyen.IDNganh, objNganhXetTuyen.MaDot, Soqd,1,0))
                                 lblThongBao.Text = "Bạn đã trúng tuyển số quyết định của bạn là: " + Soqd;
                        }
                    }
                    else { 
                    // Ton tai ban ghi, hay nganh da dng ky
                        if (kt) { 
                            //Khong thay doi nganh chi cap nhat lai diem thanh phan
                            if (objNganhXetTuyen.IDNganh.Trim() == dt.Rows[0]["NganhXT"].ToString().Trim())
                            {
                                string khoi = "";


                                khoi = objNganhXetTuyen.MaKhoi.Replace("THPT_", "");
                                    
                                  
                                  Soqd =dt.Rows[0]["SoQD"].ToString();
                                  if(diemXetTuyenBS.UpdateTrungTuyen(objHoSo.Idhs, objHoSo.MaHS, diem1, diem2, diem3, diem4, diem5, diem6, diem7, diem8, diem9, diem10, diem11, diem12, diem13, diem14, diem15, diem16, diem17, diem18, khoi, objNganhXetTuyen.MaKhoi, objNganhXetTuyen.IDNganh, objNganhXetTuyen.MaDot, Soqd,1,0))
                                      lblThongBao.Text = "Bạn đã trúng tuyển số quyết định của bạn là: " + Soqd;
                            }
                            else {
                                //chuyen nganh moi danh so quyet dinh
                                string khoi = "";
                                khoi = objNganhXetTuyen.MaKhoi.Replace("THPT_", "");
                                //MessageBox.Show(objNganhXetTuyen.IDNganh);
                                Soqd = hoSoBS.GetSoQuyetDinh(objNganhXetTuyen.IDNganh);
                                //MessageBox.Show(Soqd);
                             

                                if (diemXetTuyenBS.UpdateTrungTuyen(objHoSo.Idhs, objHoSo.MaHS, diem1, diem2, diem3, diem4, diem5, diem6, diem7, diem8, diem9, diem10, diem11, diem12, diem13, diem14, diem15, diem16, diem17, diem18, khoi, objNganhXetTuyen.MaKhoi, objNganhXetTuyen.IDNganh, objNganhXetTuyen.MaDot, Soqd,1,0))
                                    lblThongBao.Text = "Bạn đã trúng tuyển số quyết định của bạn là: " + Soqd;
                            }
                        }
                    }
                     */


                }

                if (blnResult)
                {
                    clsCommon.SaveSuccessfully();

                    //If user is closing form.
                    if (blnIsClosing) return;

                    LoadDiem(idhs,cmbKhoiXT.SelectedValue.ToString());
                    
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

            
        }

        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            //MessageBox.Show("update");
            dgvDienXetTuyen.EditMode = DataGridViewEditMode.EditOnEnter;
           
                EnableControls(true);
           
            //dgvDienXetTuyen.;
        }

        /// <summary>
        /// ucDataButton1_DeleteHandler
        /// </summary>
        private void ucDataButton1_DeleteHandler()
        {
            if (clsCommon.ConfirmDeletion() == DialogResult.No)
                return;

           

            for (int i = 0; i < dgvDienXetTuyen.SelectedRows.Count; i++)
            {
                //string sMadot = dgvDienXetTuyen.SelectedRows[i].Cells[clmMaDot.Name].Value.ToString();
                //int iNam =int.Parse( dgvDienXetTuyen.SelectedRows[i].Cells[clmNam.Name].Value.ToString());
                //dotXetTuyenBS.Delete(sMadot, iNam);
            }

            SetDataSource();
            if (dgvDienXetTuyen.RowCount > 0)
            {
                dgvDienXetTuyen.CurrentCell = null;

                dgvDienXetTuyen.CurrentCell = dgvDienXetTuyen.Rows[0].Cells[1];
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
                if (dgvDienXetTuyen.SelectedRows.Count > 0)
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
            if (blnIsDataBinding || dgvDienXetTuyen.SelectedRows.Count == 0) return;

            DisplayText();     
        }

        private void dgvDienXetTuyen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //decimalRegex = new Regex(@"^[1-9][0-9]*([\.\,][0-9]+)?$");
            //if ( !decimalRegex.IsMatch(e.FormattedValue.ToString()))
            //{
            //    System.Media.SystemSounds.Beep.Play();
            //    //e.Cancel = true;
            //}
            string columnName = this.dgvDienXetTuyen.Columns[e.ColumnIndex].Name;

            // Check for the column to validate
            if (columnName.Equals("clmDiem"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    this.dgvDienXetTuyen.Rows[e.RowIndex].ErrorText = "MyColumn could not be empty.";
                    e.Cancel = true;
                }
                else
                {
                    // Check if the input format is correct
                    //Regex datePattern = new Regex("((19|20)[0-9]{2}[/](0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01]))");
                    decimalRegex = new Regex(@"^[0-9][0-9]*([\.\,][0-9]+)?$");
                    if (!decimalRegex.IsMatch(e.FormattedValue.ToString()))
                    {
                        //MessageBox.Show(e.FormattedValue.ToString());
                         this.dgvDienXetTuyen.Rows[e.RowIndex].ErrorText = "Nhập dữ liệu số";
                        e.Cancel = true;
                    }
                    else {
                        float diem = float.Parse(e.FormattedValue.ToString());
                        if (0 > diem || diem > 10)
                        {
                            this.dgvDienXetTuyen.Rows[e.RowIndex].ErrorText = "Điểm phải lớn hơn 0 và nhỏ hơn 10";
                            e.Cancel = true;
                        }
                        else { this.dgvDienXetTuyen.Rows[e.RowIndex].ErrorText = string.Empty; }

                    }

                }
            }
        }

        private void cmbKhoiXT_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cmbKhoiXT.SelectedValue != null)
                LoadDiem(objHoSo.Idhs, cmbKhoiXT.SelectedValue.ToString());
        }

        private void cmbKhoiXT_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void ucDataButton1_Load(object sender, EventArgs e)
        {

        }

                     
    }
}

