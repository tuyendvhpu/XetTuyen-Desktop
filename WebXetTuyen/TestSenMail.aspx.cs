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

public partial class TestSenMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       /*
        // Session["objHoSo"] = HoSoServices.GetObjectHoSoBykey(38);
        HoSo  objHoso = new HoSo();
        objHoso = (HoSo)Session["objHoSo"];
        // Response.Write(objHoso.Idhs);
       long idHS = objHoso.Idhs;
       DataTable dtNganh = NganhXetTuyenServices.LoadByIdHS(idHS);
       DataTable dtDiem = DiemXetTuyenServices.LoadByIdHS(idHS);
        if (objHoso.Email.Length > 0)
        {

            string msg = "<b>Bạn đã sử dụng mail này gửi thông tin đăng ký dự tuyển vào trường Dân lập Hải Phòng.<b>";
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
                    msg = msg + "<li> Tên ngành: " + dtNganh.Rows[i]["TenNganh"].ToString() + " - Khối: " + dtNganh.Rows[i]["Makhoi"].ToString() + " - Điểm TB: " + Math.Round(Convert.ToDouble(dtNganh.Rows[i]["DiemTB"].ToString()), 2) + "</li>";
                }
                msg = msg + "</ul>";
            }

            if (dtDiem.Rows.Count > 0)
            {
                msg = msg + " <b> ĐIỂM XÉT TUYỂN <b><br>";
                msg = msg + "<ul>";
                for (int i = 0; i < dtDiem.Rows.Count; i++)
                {
                    msg = msg + "<li> Môn: " + dtDiem.Rows[i]["MaMon"].ToString() + " - Điểm: " + dtDiem.Rows[i]["Diem"].ToString() + "</li>";

                }
                msg = msg + "</ul>";
            }

            msg = msg + "<br><b>Bạn sẽ nhận được thông tin xét tuyển từ hội đồng tuyển sinh nhà trường sau 24h!<b>" + "<br>";
            msg = msg + "<b>Chi tiết xin liên hệ: Phòng đào tạo trường Đại học Dân lập Hải phòng, 36 đường Dân Lập - Dư Hàng kênh - Lê chân -Hải phòng<b> <br>";
            msg = msg + "Điện thoại:  031.3740577 – 031.3833802 - 098.965 2819  <br>";
            msg = msg + "  Website:  <a href='http://hpu.edu.vn'> hpu.edu.vn</a>  <br>";
            msg = msg + "  Email: daotao@hpu.edu.vn  hoặc luanpt@hpu.edu.vn <br>";
            msg = msg + "Link tra cứu điểm tuyển sinh: <a href='http://hpu.edu.vn:8181/tabid/67/Default.aspx'> http://hpu.edu.vn:8181/tabid/67/Default.aspx </a>";

            Utilities.SendMail("dangkyxettuyen@hpu.edu.vn", "Trường Đại học Dân lập Hải Phòng", "2012hpu246357", objHoso.Email, "Thông báo xét tuyển Đại học Dân lập Hải Phòng", msg);
        }
        */
    }
}
