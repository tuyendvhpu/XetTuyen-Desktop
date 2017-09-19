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
using DataAccess;
using Business;
using System.Collections.Generic;


public partial class StepOne : System.Web.UI.Page

{
    public static int nam = 2015;
    private int namTotNghiep = 0;
    private string maTruongPT10 = "";
    private string maTinh10 = "";
    //private string maTruongDH = "";
    private string maTruongPT11 = "";
    private string maTinh11 = "";
    private string maTruongPT12 = "";
    private string maTinh12 = "";
    //private string maKhoi = "";
    private byte HeXetTuyen =1;
    private string HanhKiem = "";
    private string maDoiTuong = "";
    public static string smaKV = "";
    private DataTable dtDotCurent;
    public static string sTruong12="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]);
        
        if (Session["step1"] == null || Session["step1"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/Thongtin.html"));
        }
        if (Session["objHoSo"] == null || Session["objHoSo"] == null)
        {
            Response.Redirect(ResolveUrl("~/Thongtin.html"));
        }
        if (Session["HinhThuc"].ToString() != "THPT" && Session["HinhThuc"].ToString() != "CẬP NHẬT")
        {
            Response.Redirect(ResolveUrl("~/home.html"));
        }
        dtDotCurent = DotXetTuyenServices.LoadByDate(Utilities.GetServerTime());//du lieu tu dong theo ngay hien tai
        if (dtDotCurent.Rows.Count <= 0)
        {
            Response.Redirect(ResolveUrl("~/ThongBao/1.html"));
        }
        if (!IsPostBack)
        {
            DateTime objdt = DateTime.Now;


            int iYear = objdt.Year;
            for (int i = iYear; i >= iYear - 50; i--)
            {
                drbNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            if (Session["objHoSo"] != null || Session["objHoSo"].ToString() != "")
            {
                HoSo objHoso = new HoSo();
                objHoso = (HoSo)Session["objHoSo"];
                drbHanhKiem.SelectedValue = objHoso.HanhKiem;
                if (objHoso.Lop10MaTinh.Length >= 1)
                    txtMaTinh10.Text = objHoso.Lop10MaTinh.Substring(0, 1);
                if (objHoso.Lop10MaTinh.Length > 1)
                    txtMaTinh10_1.Text = objHoso.Lop10MaTinh.Substring(1, 1);
                if (objHoso.Lop10MaTruong.Length >= 1)
                    txtMaTruong10.Text = objHoso.Lop10MaTruong.Substring(0, 1); ;
                if (objHoso.Lop10MaTruong.Length > 1)
                    txtMaTruong10_1.Text = objHoso.Lop10MaTruong.Substring(1, 1);
                if (objHoso.Lop10MaTruong.Length > 2)
                    txtMaTruong10_2.Text = objHoso.Lop10MaTruong.Substring(2, 1);
                lblTruongPT10.Text = TruongPT(objHoso.Lop10MaTinh, objHoso.Lop10MaTruong);

                if (objHoso.Lop11MaTinh.Length >= 1)
                    txtMaTinh11.Text = objHoso.Lop11MaTinh.Substring(0, 1);
                if (objHoso.Lop11MaTinh.Length > 1)
                    txtMaTinh11_1.Text = objHoso.Lop11MaTinh.Substring(1, 1);
                if (objHoso.Lop11MaTruong.Length >= 1)
                    txtMaTruong11.Text = objHoso.Lop11MaTruong.Substring(0, 1);
                if (objHoso.Lop11MaTruong.Length > 1)
                    txtMaTruong11_1.Text = objHoso.Lop11MaTruong.Substring(1, 1);
                if (objHoso.Lop11MaTruong.Length > 2)
                    txtMaTruong11_2.Text = objHoso.Lop11MaTruong.Substring(2, 1);

                lblTruongPT11.Text = TruongPT(objHoso.Lop11MaTinh, objHoso.Lop11MaTruong);

                if (objHoso.Lop12MaTinh.Length >= 1)
                    txtMaTinh12.Text = objHoso.Lop12MaTinh.Substring(0, 1);
                if (objHoso.Lop12MaTinh.Length > 1)
                    txtMaTinh12_1.Text = objHoso.Lop12MaTinh.Substring(1, 1);
                if (objHoso.Lop12MaTruong.Length >= 1)
                    txtMaTruong12.Text = objHoso.Lop12MaTruong.Substring(0, 1);
                if (objHoso.Lop12MaTruong.Length > 1)
                    txtMaTruong12_1.Text = objHoso.Lop12MaTruong.Substring(1, 1);
                if (objHoso.Lop12MaTruong.Length > 2)
                    txtMaTruong12_2.Text = objHoso.Lop12MaTruong.Substring(2, 1);

                lblTruongPT12.Text = TruongPT_KV(objHoso.Lop12MaTinh, objHoso.Lop12MaTruong);

                if (objHoso.MaDT.Length >= 1)
                txtDoiTuong.Text = objHoso.MaDT.Substring(0, 1);
                if (objHoso.MaDT.Length > 1)
                txtDoiTuong1.Text = objHoso.MaDT.Substring(1, 1);

                drbNam.SelectedValue = objHoso.NamTotNghiep.ToString();
                HeXetTuyen = objHoso.HeXetTuyen;

               
                for (int i = 0; i < cblHeXeTuyen.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblHeXeTuyen.Items[i].Value.Equals(HeXetTuyen.ToString()))
                    {

                        cblHeXeTuyen.Items[i].Selected = true;
                    }

                }
                if (HeXetTuyen == 2)
                {
                    for (int i = 0; i < cblHeXeTuyen.Items.Count; i++)
                    {
                        cblHeXeTuyen.Items[i].Selected = true;
                    }
                }

            }

           
            perror.Visible = false;
            perror.InnerHtml = "";



        }
       // maTruongDH = txtMaTruong.Text.Trim() + txtMaTruong1.Text.Trim() + txtMaTruong_2.Text.Trim();
        //maKhoi = txtKhoi.Text.Trim() + txtKhoi1.Text.Trim();
        maTruongPT10 = txtMaTruong10.Text.Trim() + txtMaTruong10_1.Text.Trim() + txtMaTruong10_2.Text.Trim();
        maTinh10 = txtMaTinh10.Text.Trim() + txtMaTinh10_1.Text.Trim();
        maTruongPT11 = txtMaTruong11.Text.Trim() + txtMaTruong11_1.Text.Trim() + txtMaTruong11_2.Text.Trim();
        maTinh11 = txtMaTinh11.Text.Trim() + txtMaTinh11_1.Text.Trim();
        maTruongPT12 = txtMaTruong12.Text.Trim() + txtMaTruong12_1.Text.Trim() + txtMaTruong12_2.Text.Trim();
        maTinh12 = txtMaTinh12.Text.Trim() + txtMaTinh12_1.Text.Trim();
        namTotNghiep = Convert.ToInt16(drbNam.SelectedValue.ToString());
        List<byte> hexetemselect = new List<byte>();
        
        foreach (ListItem item in cblHeXeTuyen.Items)
        {
            if (item.Selected)
            {
                hexetemselect.Add(Convert.ToByte(item.Value));
            }
        }

        if (hexetemselect.Count > 1)
        {
            HeXetTuyen = 2;
        }
        else
        {
            if (hexetemselect.Count > 0)
            {
                HeXetTuyen = hexetemselect[0];
            }
            else {
                HeXetTuyen = 3;
            }
        }
       
       //HeXetTuyen = drbHeXeTuyen.SelectedValue.ToString();
        HanhKiem = drbHanhKiem.SelectedValue.ToString();
        maDoiTuong = txtDoiTuong.Text.Trim() + txtDoiTuong1.Text.Trim();

    }
    private string Tinh(string matinh)
    {
        string ten = "";
        DataTable dt = TinhServices.LoadByPrimaryKey(matinh);
        if (dt.Rows.Count > 0)
        {
            ten = dt.Rows[0]["TenTinh"].ToString();

        }

        return ten;

    }
    [WebMethod()]
    public static string TruongPT(string matinh, string matruongPT)
    {
        string ten = "";
        DataTable dt = TruongPTServices.LoadByPrimaryKey(matruongPT, matinh,nam);
        if (dt.Rows.Count > 0)
        {
            ten = dt.Rows[0]["TenTruong"].ToString() + " - " + dt.Rows[0]["Diachi"].ToString();

        }
        return ten;

    }
    [WebMethod()]
    public static string TruongPT_KV(string matinh, string matruongPT)
    {
        string ten = "";
        DataTable dt = TruongPTServices.LoadByPrimaryKey(matruongPT, matinh,nam);
        if (dt.Rows.Count > 0)
        {
            smaKV = dt.Rows[0]["MaKV"].ToString();
            sTruong12 = dt.Rows[0]["TenTruong"].ToString() + " - " + dt.Rows[0]["Diachi"].ToString();
            ten = sTruong12  + " <strong style='border:2px #cbcbcb; background:#ffffff;width:25px;'>  KV " + smaKV + " </strong>";

        }
        return ten;

    }
    [WebMethod()]
    public static string TruongDH(string matruongDH)
    {
        string ten = "";
        DataTable dt = TruongDHServices.LoadByPrimaryKey(matruongDH, nam);
        if (dt.Rows.Count > 0)
        {
            ten = dt.Rows[0]["TenTruong"].ToString();

        }
        return ten;

    }



    protected void btnTiep_Click(object sender, EventArgs e)
    {
        string msg = "";
        perror.Visible = false;

        //if (KhoiThiServices.LoadByPrimaryKey(maKhoi, nam).Rows.Count <= 0)
        //{
        //    perror.Visible = true;
        //    msg = msg + "Mã khối thi không tồn tại! <br />";
        //    // perror.InnerHtml = "Mã khối thi không tồn tại! <br />";
        //}

        string madoituong = txtDoiTuong.Text.Trim() + txtDoiTuong1.Text.Trim();
        if (DoiTuongUTServices.LoadByPrimaryKey(madoituong).Rows.Count <= 0)
        {
            perror.Visible = true;
            msg = msg + "Mã đối tượng không tồn tại! <br />";
            // perror.InnerHtml = "Mã đối tượng không tồn tại! <br />";
        }
        lblTruongPT10.Text = TruongPT(maTinh10, maTruongPT10);
        lblTruongPT11.Text = TruongPT(maTinh11, maTruongPT11);
        lblTruongPT12.Text = TruongPT_KV(maTinh12, maTruongPT12);
        if (lblTruongPT12.Text == "" || lblTruongPT11.Text == "" || lblTruongPT10.Text == "")
        {
            perror.Visible = true;
            msg = msg + "Nhập sai mã tỉnh hoặc mã trường phổ thông! <br />";
            //perror.InnerHtml = "Mã trường phổ thông không tồn tại!";
            //perror.InnerHtml = maTruongDH;
        }

        
        if (HeXetTuyen == 3)
        {
            perror.Visible = true;
            msg = msg + "Bạn phải chọn hệ để xét tuyển! <br />";
            //perror.InnerHtml = "Bạn phải chọn hệ để xét tuyển! <br />";
        }
       
            perror.InnerHtml = msg;
      
             
       
        if (perror.Visible == false & perror.InnerHtml == "")
        {
            HoSo objHoso = new HoSo();
            if (Session["objHoSo"] != null && Session["objHoSo"] != null)
            {
                objHoso = (HoSo)Session["objHoSo"];
                //Response.Write(HeXetTuyen);
                objHoso.HanhKiem = HanhKiem;
                
              
                objHoso.Lop10MaTinh = maTinh10;
                objHoso.Lop10MaTruong = maTruongPT10;
                objHoso.Lop10 = lblTruongPT10.Text;
                objHoso.Lop11MaTinh = maTinh11;
                objHoso.Lop11MaTruong = maTruongPT11;
                objHoso.Lop11 = lblTruongPT11.Text;
                objHoso.Lop12MaTinh = maTinh12;
                objHoso.Lop12MaTruong = maTruongPT12;
                objHoso.Lop12 = sTruong12;
                objHoso.NamTotNghiep = namTotNghiep;
                objHoso.MaDT = maDoiTuong;
                objHoso.MaKV = smaKV;
                objHoso.NguoiNhap = "online";
                objHoso.NgayNhap = Utilities.GetServerTime();
                objHoso.HeXetTuyen = HeXetTuyen;
                objHoso.DangXetTuyen = true;
                objHoso.HinhThuc = 0;
                objHoso.Buoc = 1;
                if (HoSoServices.Update(objHoso))
                {
                    Session["objHoSo"] = objHoso;
                    Session["step2"] = 2;
                    Response.Redirect(ResolveUrl("~/ChonNganh.html"));
                }
            }
            else {
                Response.Redirect(ResolveUrl("~/Thongtin.html"));
                    
            }
        }
    }
    protected void cblHeXeTuyen_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < cblHeXeTuyen.Items.Count; i++)
        {
            //Response.Write(cblCNTT.Items[i].Value);
            if (cblHeXeTuyen.Items[i].Value.Equals(HeXetTuyen.ToString()))
            {

                cblHeXeTuyen.Items[i].Selected=true;
            }
            
        }
        
    }
}
