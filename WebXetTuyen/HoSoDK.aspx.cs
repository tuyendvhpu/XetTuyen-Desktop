using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using BusinessLogic;
using DataAccess;

public partial class HoSoDK : System.Web.UI.Page
{
    private DataView dtv = null;
    public int TongSo = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            loadView();
          
        }

    }

    private void loadView()
    {
        string sql = "Select * From  T_HoSo Order by  NgaySua desc, NgayNhap desc, idhs desc";
        dtv = new DataView(HoSoServices.FindHoSo(sql));
        TongSo = dtv.Count;
        dtv.RowFilter = "Diachi like '%" + txtLop12.Text.Trim() + "%' AND SoCMTND like '%" + txtSoCMTD.Text.Trim() + "%' " + " AND HoTen like '%" + txtHoTen.Text.Trim() + "%' "  ;

        dtv.Sort = "NgaySua desc,NgayNhap desc,idhs desc";
        dgvDK.DataSource = dtv;

        dgvDK.DataBind();

    }
    protected void dgvDK_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }
    protected void dgvDK_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvDK.PageIndex = e.NewPageIndex;
        loadView();
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        loadView();

    }
    protected void dgvDK_DataBinding(object sender, EventArgs e)
    {

    }
    protected void dgvDK_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sDotNgay="";
            string sNganhHB = "";
            string sNganhThi = "";
            string sNgayDK = "<table width='80px'>";
            string sHinhThucHB = "";
            string sHinhThucThi = "";
            string sTrangThai = "";
            List<string> lstNganhHB= new List<string>();
            List<string> lstNganhThi= new List<string>();
            Label lblDot = e.Row.FindControl("lblDot") as Label;
             Label lblNganh = e.Row.FindControl("lblNganh") as Label;
             Label lblNgayDK = e.Row.FindControl("lblNgayDK") as Label;
             Label lblHinhThuc = e.Row.FindControl("lblHinhThuc") as Label;
             Label lblTrangThai = e.Row.FindControl("lblTrangThai") as Label;
            DataRowView dr = e.Row.DataItem as DataRowView;
            string idhs = dr["IDHS"].ToString();
            string maHS = dr["maHS"].ToString();
            string sqlDot = string.Format("Select DISTINCT  MaDot,nam From t_NganhXetTuyen Where iDHS ={0} ", idhs);
            DataTable nganhDot = NganhXetTuyenServices.FindNganhXetTuyen(sqlDot);
            if (nganhDot.Rows.Count > 0)
            {
                for (int i = 0; i < nganhDot.Rows.Count; i++)
                {
                    sDotNgay = "<tr><td align='center'>" + sDotNgay + nganhDot.Rows[i]["MaDot"].ToString();
                    string madot = nganhDot.Rows[i]["MaDot"].ToString();
                    DataTable dtDot = DotXetTuyenServices.LoadByPrimaryKey(madot, Convert.ToInt32(nganhDot.Rows[i]["Nam"].ToString()));
                    DateTime dtNgaykt = Convert.ToDateTime(dtDot.Rows[0]["NgayKT"].ToString()).AddDays(1);
                    sDotNgay = sDotNgay + "<br />" + "(" + dtNgaykt.ToString("dd/MM/yyyy") + ")" + "</td></tr>";
                    string sqlNganh = string.Format("SELECT nganhdk.IDHS,nganhdk.IDNganh,nganhdk.MaNganh,nganhdk.MaKhoi,nganhdk.MaDot,nganhdk.TrangThai,nganhdk.NgayDK,nganh.TenNganh FROM [t_NganhXetTuyen] as nganhdk,[t_Nganh] as nganh  where IDHS ={0} AND MaDot =N'{1}' And nganhdk.IDNganh = nganh.IDNganh AND nganhdk.MaKhoi = nganh.MaKhoi ", idhs, madot);
                    DataTable dtNganhdk = NganhXetTuyenServices.FindNganhXetTuyen(sqlNganh);
                    int idot = 0;
                    if (dtNganhdk.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtNganhdk.Rows.Count; j++)
                        {
                            if (dtNganhdk.Rows[j]["MaKhoi"].ToString().Length > 3)
                            {
                                //sNganhHB = sNganhHB + dtNganhdk.Rows[j]["TenNganh"].ToString() +", ";

                                sNganhHB = dtNganhdk.Rows[j]["TenNganh"].ToString().Trim();
                                if (!lstNganhHB.Contains(sNganhHB))
                                {
                                    lstNganhHB.Add(sNganhHB);
                                    if (maHS.Length > 0)
                                    {
                                        if (dtNganhdk.Rows[j]["TrangThai"].ToString().Equals("0"))
                                        {
                                            sTrangThai = sTrangThai + "<tr><td>Đang xét tuyển</td></tr>";
                                        }
                                        else
                                        {
                                            sTrangThai = sTrangThai + "<tr><td>Đã xét tuyển</td></tr>";
                                        }
                                    }
                                    else {
                                        sTrangThai = sTrangThai + "<tr><td>Hồ sơ thiếu</td></tr>";
                                    }
                                    if (dtNganhdk.Rows[j]["MaNganh"].ToString().Trim().Substring(0, 1) == "D")
                                    {
                                        sHinhThucHB = sHinhThucHB + "<tr><td>Đại học</td></tr>";
                                    }
                                    else {
                                        sHinhThucHB = sHinhThucHB + "<tr><td>Cao đẳng</td></tr>";
                                    }
                                   // sHinhThucHB = sHinhThucHB + "<tr><td>Theo HB</td></tr>";

                                    DateTime dtngdk = Convert.ToDateTime(dtNganhdk.Rows[j]["NgayDK"].ToString());
                                    sNgayDK = sNgayDK + "<tr><td>" + dtngdk.ToString("dd/MM/yyyy") + "</td></tr>";
                                    idot += 1;
                                }
                            }
                            else
                            {
                                //sNganhThi = sNganhThi + dtNganhdk.Rows[j]["TenNganh"].ToString() + ", ";
                                sNganhThi = dtNganhdk.Rows[j]["TenNganh"].ToString().Trim();
                                if (!lstNganhThi.Contains(sNganhThi))
                                {
                                    lstNganhThi.Add(sNganhThi);
                                    if (maHS.Length > 0)
                                    {
                                        if (dtNganhdk.Rows[j]["TrangThai"].ToString().Equals("0"))
                                        {
                                            sTrangThai = sTrangThai + "<tr><td>Đang xét tuyển</td></tr>";
                                        }
                                        else
                                        {
                                            sTrangThai = sTrangThai + "<tr><td>Đã xét tuyển</td></tr>";
                                        }
                                    }
                                    else {
                                        sTrangThai = sTrangThai + "<tr><td>Hồ sơ thiếu</td></tr>";
                                    }
                                    if (dtNganhdk.Rows[j]["MaNganh"].ToString().Trim().Substring(0, 1) == "D")
                                    {
                                        sHinhThucThi = sHinhThucThi + "<tr><td>Đại học</td></tr>";
                                    }
                                    else
                                    {
                                        sHinhThucThi = sHinhThucThi + "<tr><td>Cao đẳng</td></tr>";
                                    }
                                    //sHinhThucThi = sHinhThucThi + "<tr><td>THPT Quốc gia</td></tr>";
                                    DateTime dtngdk = Convert.ToDateTime(dtNganhdk.Rows[j]["NgayDK"].ToString());
                                    sNgayDK = sNgayDK + "<tr><td>" + dtngdk.ToString("dd/MM/yyyy") + "</td></tr>";
                                    idot += 1;
                                }
                            }

                        }
                    }
                    for (int jdot = 0; jdot < idot - 1; jdot++)
                    {
                        sDotNgay = sDotNgay + "<tr><td></td></tr>";
                    }
                }
            }
            sNganhHB = "";
            foreach (string shb in lstNganhHB) { sNganhHB = sNganhHB + "<tr><td>" + shb + "</td></tr>"; }
            //if(sNganhHB.Length>0)
          //  sNganhHB = sNganhHB.Remove(0, 1);
            sNganhThi = "";
            foreach (string sthi in lstNganhThi) { sNganhThi = sNganhThi + "<tr><td>" + sthi + "</td></tr>"; }
            sNgayDK = sNgayDK + "</table>";
            //if (sNganhThi.Length > 0)
            //    sNganhThi = sNganhThi.Remove(0, 1);

            lblTrangThai.Text = "<table width='100px'>"  + sTrangThai + "</table>";
            lblDot.Text = "<table width='90px'>" + sDotNgay + "</table>"; ;
            lblHinhThuc.Text = "<table width='90px'>" + sHinhThucHB + sHinhThucThi + "</table>";
           
            lblNgayDK.Text = sNgayDK;
            lblNganh.Text = "<table width='200px'>" + sNganhHB + sNganhThi + "</table>";


        }
        
    }
}