using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Business;
using DataAccess;

public partial class _Default : System.Web.UI.Page
{
    public DataTable dtDot;
    private int nam = 2015;
    private long idHS = 0;
    public HoSo objHoso;
    public DataTable dtNganh;
    public DataTable dtDiem, dtDiemKhoi;
    public int id = 0;
    public string khoi ="";
    public DataTable dtKhoi;
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]); 

        if (!IsPostBack)
        {
           
        }

        //Session["objHoSo"] = HoSoServices.GetObjectHoSoBykey(41);

        if (Request.QueryString.Get("ID") != null)
            id = Convert.ToInt16(Request.QueryString.Get("ID").ToString() + " ");
        dtDot = DotXetTuyenServices.LoadByNam(nam);
     //  Session["objHoSo"] = HoSoServices.GetObjectHoSoBySoCMTND("031246254", nam);
        if (Session["objHoSo"] != null && Session["objHoSo"].ToString() != "")
        {
            objHoso = new HoSo();
            objHoso = (HoSo)Session["objHoSo"];
            // Response.Write(objHoso.Idhs);
            idHS = objHoso.Idhs;
            
            dtNganh = NganhXetTuyenServices.LoadByIdHS(idHS);
            dtDiem = DiemXetTuyenServices.LoadByIdHS(idHS);
            string sqlnganh = string.Format("SELECT DISTINCT Makhoi from t_NganhXetTuyen Where IDHS ={0}", objHoso.Idhs);
            dtKhoi = NganhXetTuyenServices.FindNganhXetTuyen(sqlnganh);
            if (objHoso.Email.Length > 0 &&id==0)
            {

                string msg = "<b>Bạn đã sử dụng mail này gửi thông tin đăng ký dự tuyển vào trường Đại học Dân lập Hải Phòng.<b>";
                msg = msg + "<b>Thông tin đã đăng ký như sau:</b> <br>";
                msg = msg + " - Số báo danh: " + objHoso.SoBaoDanh + "<br>";
                msg = msg + " - Họ tên: " + objHoso.HoTen + "<br>";
                msg = msg + " - Ngày sinh: " + objHoso.NgaySinh.ToString("dd/MM/yyyy") + "<br>";
                msg = msg + "- Giới tính: " + objHoso.GioiTinh + "<br>";
                msg = msg + "- Dân tộc: " + objHoso.DanToc + "<br>";
                msg = msg + "- Hộ khẩu: " + objHoso.HoKhau + "<br>";
                msg = msg + " - Điện thoại: " + objHoso.DienThoai + "<br>";
                msg = msg + " - Email: " + objHoso.Email + "<br>";
                msg = msg + " - Địa chỉ liên hệ: " + objHoso.DiaChi + "<br>";
                msg = msg + " - Lớp 10: " + objHoso.Lop10 + "<br>";
                msg = msg + " - Lớp 11: " + objHoso.Lop11 + "<br>";
                msg = msg + " - Lớp 12: " + objHoso.Lop12 + "<br>";
                msg = msg + " - Khu vực: KV" + objHoso.MaKV + "<br>";
                msg = msg + " - Đối tượng: " + objHoso.MaDT + "<br>";
                if (dtNganh.Rows.Count > 0)
                {
                    msg = msg + " <b> CÁC NGÀNH VÀ KHỐI ĐĂNG KÝ XÉT TUYỂN<b><br>";
                    msg = msg + "<ul>";
                    for (int i = 0; i < dtNganh.Rows.Count; i++)
                    {
                        if (dtNganh.Rows[i]["Makhoi"].ToString().Length >3)
                        {
                            if (checkNganhXT(dtNganh.Rows[i]["MaNganh"].ToString(), Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2)))
                            {
                                msg = msg + "<li>Tên ngành: " + dtNganh.Rows[i]["TenNganh"].ToString() + " - Khối: " + dtNganh.Rows[i]["Makhoi"].ToString() + " - Điểm TB: " + Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2) + " --> Đủ điều kiện xét tuyển!</li>";
                            }
                            else
                            {
                                msg = msg + "<li>Tên ngành: " + dtNganh.Rows[i]["TenNganh"].ToString() + " - Khối: " + dtNganh.Rows[i]["Makhoi"].ToString() + " - Điểm TB: " + Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2) + " --> Không đủ điều kiện xét tuyển!</li>";
                            }
                        }
                        else
                        {
                            msg = msg + "<li>Tên ngành: " + dtNganh.Rows[i]["TenNganh"].ToString() + " - Khối: " + dtNganh.Rows[i]["Makhoi"].ToString() + " - Điểm TB: " + Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2) + "</li>";
                        }
                    }
                    msg = msg + "</ul>";
                }

                if (dtDiem.Rows.Count > 0)
                {
                    msg = msg + " <b> ĐIỂM XÉT TUYỂN <b><br>";
                    msg = msg + "<ul>";
                    for (int i = 0; i < dtDiem.Rows.Count; i++)
                    {
                       
                        msg = msg + "<li> Môn: " + dtDiem.Rows[i]["TenMon"].ToString() + " - Điểm: " + dtDiem.Rows[i]["Diem"].ToString() + "</li>";

                    }
                    msg = msg + "</ul>";
                }

                //msg = msg + "<br><b>Bạn sẽ nhận được thông tin xét tuyển từ hội đồng tuyển sinh nhà trường sau 24h!<b>" + "<br>";
                msg = msg + "<b>Chi tiết xin liên hệ hotline: 0901 598 698<b> <br>";
                msg = msg + "  Website:  <a href='http://hpu.edu.vn'> hpu.edu.vn</a>  <br>";
                

              //Utilities.SendMail("dangkyxettuyen@hpu.edu.vn", "Trường Đại học Dân lập Hải Phòng", "2012hpu246357", objHoso.Email, "Thông báo xét tuyển Đại học Dân lập Hải Phòng", msg);
                Utilities.SendMailToQueue(objHoso.Email, "Thông báo xét tuyển Đại học Dân lập Hải Phòng", "", "", msg, 1);
            }
            
            
        }
    }
    public bool checkNganhXT(string maNganh, double dTB) { 
    
        bool tt = true;
        if (maNganh.Substring(0, 1).Equals("D"))
        {
            if (dTB < 6.0)
            {
                tt = false;
            }
        }
        else {
            if (dTB < 5.5)
            {
                tt = false;
            }
        }

        return tt;

    }
    protected void btnIn_Click(object sender, EventArgs e)
    {

    }
   
    protected void btnKetThuc_Click(object sender, EventArgs e)
    {
        //string url = "KetThuc.aspx";
     
        Session["objHoSo"] = null;
        Session["HinhThuc"] = null;
        Session["CapNhat"] = null;
        Response.Redirect(ResolveUrl("~/Home.html"));
         
    }
}
