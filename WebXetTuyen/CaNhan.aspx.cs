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
using System.Web.Services;
using Business;
using DataAccess;

public partial class CaNhan : System.Web.UI.Page
{
    private string hoten = "";
    private string dienthoai="";
    private string sEmail = "";
    private string sdantoc = "";
    private string diachi = "";
    private string ngaysinh;
    private string gioitinh = "";
    private string hokhau = "";
    private string matinh = "";
    private string mahuyen = "";
    private HoSo objHoso;
    private int nam = 2014;
    private bool thanhcong = false;
    private void Enable(bool trangThai) {
        this.txtDiaChi.Enabled = trangThai;
        this.txtEmail.Enabled = trangThai;
        this.txtHoKhau.Enabled = trangThai;
        this.txtHoTen.Enabled = trangThai;
        this.txtMaHuyen.Enabled = trangThai;
        this.txtMaHuyen1.Enabled = trangThai;
        this.txtMaTinh.Enabled = trangThai;
        this.txtMaTinh1.Enabled = trangThai;
        this.txtNgaySinh.Enabled = trangThai;
        this.txtSoDienThoai.Enabled = trangThai;
        this.drlDanToc.Enabled = trangThai;
        this.drlGioiTinh.Enabled = trangThai;
        this.imgDate.Visible = trangThai;
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        var culture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yy";
        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
    }
    protected void Page_Load(object sender, EventArgs e)

    {

        nam = Convert.ToInt32(Application["nam"]);
        if (Session["soCMTND"] == null )
        {
            Response.Redirect(ResolveUrl("~/SoCMTND.html"));
        }
        if (Session["soCMTND"].ToString() == "" )
        {
            Response.Redirect(ResolveUrl("~/SoCMTND.html"));
        }
        HoSo objHoso = new HoSo();   
        if(!IsPostBack){
           
            DataTable dt = DanTocServices.LoaAll();
            if (dt.Rows.Count > 0)
            {
                drlDanToc.DataSource = dt;
                drlDanToc.DataTextField = "TenDanToc";
                drlDanToc.DataValueField = "TenDanToc";
                drlDanToc.DataBind();
                drlDanToc.SelectedValue = "Kinh";
            if (Session["objHoSo"] != null || Session["objHoSo"].ToString() != "")
            {

                
                objHoso = (HoSo)Session["objHoSo"];
                txtHoTen.Text = Utilities.StandardString( objHoso.HoTen);
                txtSoDienThoai.Text = objHoso.DienThoai;
                txtEmail.Text = objHoso.Email;
                txtDiaChi.Text = objHoso.DiaChi;
                txtNgaySinh.Text = objHoso.NgaySinh.ToString("dd/MM/yyyy");
                txtHoKhau.Text = objHoso.HoKhau;
                if (objHoso.MaTinh.Length >= 1)
                txtMaTinh.Text = objHoso.MaTinh.Substring(0, 1);
                if (objHoso.MaTinh.Length > 1)
                 txtMaTinh1.Text = objHoso.MaTinh.Substring(1, 1);
                if (objHoso.MaHuyen.Length >= 1)
                    txtMaHuyen.Text = objHoso.MaHuyen.Substring(0, 1);
                if (objHoso.MaHuyen.Length > 1)
                    txtMaHuyen1.Text = objHoso.MaHuyen.Substring(1, 1);
                lblHuyen.Text = GetHuyen(objHoso.MaTinh, objHoso.MaHuyen);
                drlDanToc.SelectedValue = objHoso.DanToc;
                drlGioiTinh.SelectedValue = objHoso.GioiTinh;
                if(objHoso.KetQua ==1||objHoso.MaHS.Length>0)
                Enable(false);
            }
            else {
                Response.Redirect(ResolveUrl("~/SoCMTND.html"));
            }
            
            }
        }
        lblThongBao.Text = "";
        hoten = txtHoTen.Text.Trim();
        dienthoai = txtSoDienThoai.Text.Trim();
        sEmail = txtEmail.Text.Trim();
        sdantoc = drlDanToc.SelectedValue;
        diachi = txtDiaChi.Text.Trim();
        ngaysinh = txtNgaySinh.Text.Trim();
        gioitinh = drlGioiTinh.SelectedValue;
        hokhau = txtHoKhau.Text.Trim();
        matinh = txtMaTinh.Text.Trim() + txtMaTinh1.Text.Trim();
        mahuyen = txtMaHuyen.Text.Trim() + txtMaHuyen1.Text.Trim();
        
    }
    [WebMethod()]
   
    public static string dataSave(string name)
    {
        return name;
    }
    [WebMethod()]
    public static string GetHuyen(string matinh, string mahuyen)
    {
        
        string ten = "";
        //if (mahuyen.Length <= 0) {
        //   ten = "Xin vui lòng nhập mã huyện!";
        //   return ten;
        //}
        //if (matinh.Length <= 0)
        //{
        //    ten = "Xin vui lòng nhập mã tỉnh!";
        //    return ten;
        //}
        DataTable dt = HuyenServices.LoadByPrimaryKey(mahuyen, matinh);
        if (dt.Rows.Count > 0)
        {
            ten = dt.Rows[0]["TenHuyen"].ToString();

        }
        return ten;
    }
   
    private string Huyen(string mahuyen,string matinh)
    {
        string ten = "";
        DataTable dt = HuyenServices.LoadByPrimaryKey(mahuyen,matinh);
        if (dt.Rows.Count > 0)
        {
            ten = dt.Rows[0]["TenHuyen"].ToString();

        }

        return ten;

    }
    
    protected void btnTiep_Click(object sender, EventArgs e)
    
    {
       
        if(validateForm()){
            
           //Response.Write(objHoso.Idhs.ToString() + "smt" + objHoso.SoCMTND + "- sbd: " + objHoso.SoBaoDanh + " - Ngaysinh:" + objHoso.NgaySinh.ToString());
            objHoso = new HoSo();

           

            objHoso = (HoSo)Session["objHoSo"];
            objHoso.HoTen = Utilities.StandardString( hoten);
           
            objHoso.DienThoai = dienthoai;
            objHoso.Email =sEmail;
            objHoso.DanToc = sdantoc;
            objHoso.DiaChi = diachi;
            objHoso.NgaySinh = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", null);
            objHoso.GioiTinh = gioitinh;
            objHoso.HoKhau = hokhau;
            objHoso.MaTinh = matinh;
            objHoso.MaHuyen = mahuyen;
            objHoso.Buoc = 0;
            objHoso.Online = true;

            if (Session["CapNhat"].ToString().Equals("Mới")) {
                Session["soBaoDanh"] = HoSoServices.GetSoBaoDanhRandom(nam, "DHP", 6);

                objHoso.SoBaoDanh = Session["soBaoDanh"].ToString();

                if (HoSoServices.Insert(objHoso))
                {
                   
                string msg = "<b>Bạn đã sử dụng mail này gửi thông tin đăng ký dự tuyển vào trường Đại học Dân lập Hải Phòng.<b>";
                msg = msg + "<b>Thông tin đã đăng ký như sau:</b> <br>";
                msg = msg + " - Họ tên: " + Utilities.StandardString( objHoso.HoTen) + "<br>";
                msg = msg + " - Ngày sinh: " + objHoso.NgaySinh.ToString("dd/MM/yyyy") + "<br>";
                msg = msg + "- Giới tính: " + objHoso.GioiTinh + "<br>";
                msg = msg + "- Dân tộc: " + objHoso.DanToc + "<br>";
                msg = msg + "- Hộ khẩu: " + objHoso.HoKhau + "<br>";
                msg = msg + " - Điện thoại: " + objHoso.DienThoai + "<br>";
                msg = msg + " - Email: " + objHoso.Email + "<br>";
                msg = msg + "<b>Bạn hãy nhớ số chứng minh thư và số điện thoại để dùng cho việc đăng ký hồ sơ xét tuyển</b><br>";
                msg = msg + "Số CMTND: <b>" + objHoso.SoCMTND + "<b><br>";
                msg = msg + "Số điện thoại: <b>" + objHoso.DienThoai + "<b><br>";
                msg = msg + "<b>Chi tiết xin liên hệ hotline: 0901 598 698<b> <br>";
                msg = msg + "  Website:  <a href='http://hpu.edu.vn'> hpu.edu.vn</a>  <br>";
                //Utilities.SendMail("dangkyxettuyen@hpu.edu.vn", "Trường Đại học Dân lập Hải Phòng", "2012hpu246357", objHoso.Email, "Thông báo xét tuyển Đại học Dân lập Hải Phòng", msg);
                Utilities.SendMailToQueue(objHoso.Email, "Thông báo xét tuyển Đại học Dân lập Hải Phòng", "", "", msg, 1);
                thanhcong = true;
                }

            }
            else{

                if (HoSoServices.Update(objHoso))
                {


                    thanhcong = true;
                 
                    //Response.Write("oc");

                }
               
            }

            if (thanhcong)
            {
                objHoso = HoSoServices.GetObjectHoSoBySoCMTND(Session["soCMTND"].ToString(), nam);
                Session["objHoSo"] = objHoso;
                Session["step1"] = 1;
                if (Session["HinhThuc"].ToString().Equals("THPT"))
                {
                    Response.Redirect(ResolveUrl("~/SetpOneTHPT.html"));
                }
                if (Session["HinhThuc"].ToString().Equals("THI ĐẠI HỌC"))
                {
                    Response.Redirect(ResolveUrl("~/SetpOne.html"));
                }

               
                 
            }
        }
       
      
    }

    private bool validateForm()
    {
        //if (dtbNgaySinh.SelectedDate == null)
        //{
        //    lblThongBao.Text = "Phải chọn ngày sinh";
        //    return false;
        //}
       
        if (Page.IsValid)
        {
            lblError.Text = "";
            lblHuyen.Text = Huyen(mahuyen, matinh);
            if (lblHuyen.Text.Trim().Equals(""))
            {
                lblError.Text = "Không tồn tại mã tỉnh hoặc mã huyện như trên! ";
                return false;
            }
            if (!captcha.Decide())
            {
                captcha.message = "Mã sác nhận sai!";
                return false;
            }
            else
            {
                //  Response.Write("<b> Bạn đã nhập đúng.</b><br><br>");

            }

            if (!cbXacThuc.Checked)
            {
                lblThongBao.Text = "Bạn phải xác nhận thông tin";
                return false;

            }
            
        }
        else
        {
            return false;
        }
        return true;
    }
}
