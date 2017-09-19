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
using System.Text.RegularExpressions;
using DataAccess;
using Business;

public partial class Step2DH : System.Web.UI.Page
{
    private int nam = 2014;
    public static int irow = 0;
    private Regex decimalRegex = null;
    private long idHS ;
    private string dotxetuyen = "";
    private int HeSo = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]);
        HeSo = Convert.ToInt32(Application["HeSo"]); 
        if (Session["step1"] == null || Session["step1"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/ChonNganh.html"));
        }
        if (Session["objHoSo"] == null || Session["objHoSo"] == null)
        {
            Response.Redirect(ResolveUrl("~/ChonNganh.html"));
        }
        decimalRegex = new Regex(@"^[1-9][0-9]*([\.\,][0-9]+)?$");
        perror.Visible = false;

        if (Session["objHoSo"] != null && Session["objHoSo"].ToString() != "")
        {
            HoSo objHoso = new HoSo();
            objHoso = (HoSo)Session["objHoSo"];
            // Response.Write(objHoso.Idhs);
            idHS = objHoso.Idhs;
           
            // hexettuyen = objHoso.HeXetTuyen;
            dotxetuyen = DotXetTuyenServices.LoadByDate(Utilities.GetServerTime()).Rows[0]["Madot"].ToString();//du lieu tu dong theo ngay hien tai
            //  Response.Write(Utilities.GetServerTime().ToLongDateString());
           
        }
        else
        {
            // Response.Redirect(ResolveUrl("~/SetpOne.html"));'
            //idHS = 12;
        }
        string sqlnganh = string.Format("SELECT DISTINCT Makhoi from t_NganhXetTuyen Where IDHS ={0}",idHS);
       DataTable dtKhoi = NganhXetTuyenServices.FindNganhXetTuyen(sqlnganh);
       /*
        DataTable dtKhoi = new DataTable();

        dtKhoi.Columns.Add("MaKhoi", typeof(string));
        dtKhoi.Rows.Add("A");
        dtKhoi.Rows.Add("A1");
        */
        if (dtKhoi.Rows.Count > 0)
        {
           
            for (int j = 0; j < dtKhoi.Rows.Count; j++)

            {
                string khoiXT = dtKhoi.Rows[j]["MaKhoi"].ToString();
                if (khoiXT.Length < 3)//kiem tra co phai khoi THPT ko?
                {
                    DataTable dtMon = KhoiMonServices.LoadTenMonByPrimaryKey(nam, khoiXT);


                    irow = dtMon.Rows.Count;
                    TextBox txt = null;
                    Label lblMon = null;
                    Literal litK = new Literal();
                    litK.Text = "Khối " + khoiXT + ": &nbsp </br>";

                    string slqNganh = string.Format("Select * From t_NganhXetTuyen Where idhs = {0} And TrangThai = 1 And MaKhoi ='{1}'",idHS, khoiXT);
                    DataTable dtNganhXT = NganhXetTuyenServices.FindNganhXetTuyen(slqNganh);
                    int iNganhXt = dtNganhXT.Rows.Count;
                    holder.Controls.Add(litK);
                    for (int i = 0; i < dtMon.Rows.Count; i++)
                    {

                        string sqlDiemXT = string.Format("SELECT * FROM t_DiemXetTuyen Where IdHs ={0} And Mamon ='{1}'", idHS, dtMon.Rows[i]["MaMon"].ToString());
                        DataTable dtDiemxt = DiemXetTuyenServices.FindDiemXetTuyen(sqlDiemXT);
                        txt = new TextBox();
                        lblMon = new Label();
                        lblMon.ID = "lbl" + i.ToString() + dtMon.Rows[i]["MaMon"] + j.ToString();
                        lblMon.Text = "&nbsp" + dtMon.Rows[i]["TenMon"].ToString() + "&nbsp";

                        txt.ID = dtMon.Rows[i]["MaMon"].ToString() + "_" + khoiXT;
                        txt.CssClass = "Diemtxt";
                        txt.MaxLength = 4;
                        if (dtDiemxt.Rows.Count > 0)
                            txt.Text = dtDiemxt.Rows[0]["Diem"].ToString();
                        if (iNganhXt > 0)
                            txt.Enabled = false;
                        if (i == 6)
                        {
                            Literal lit = new Literal();
                            lit.Text = "</br>";
                            holder.Controls.Add(lit);
                        }
                        holder.Controls.Add(lblMon);
                        holder.Controls.Add(txt);



                    }
                }
                Literal libr = new Literal();
                libr.Text = "</br>";
                holder.Controls.Add(libr);
            }
        }


        if (!IsPostBack) {
            if (Session["CapNhat"].ToString() == "CẬP NHẬT")
            {
                //DataTable dtMonXT = DiemXetTuyenServices.LoadByIdHS(idHS);
                //for (int i = 0; i < dtMonXT.Rows.Count; i++)
                //{
                //    if (dtMonXT.Rows[i]["MaMon"].ToString().Length < 6)
                //    {

                //        DiemXetTuyenServices.Delete(idHS, dtMonXT.Rows[i]["MaMon"].ToString());

                //    }
                //}
             //   DiemXetTuyenServices.Delete(idHS);

            }
           
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        /*
        Table tb = new Table();
        tb.ID = "tb1";
        TableRow tr = new TableRow();


        for (int i = 0; i < 3; i++)
        {
            TextBox tbox = new TextBox();
            tbox.ID = i.ToString();


            TableCell tc = new TableCell();
            tc.Controls.Add(tbox);
            tr.Cells.Add(tc);
            tb.Rows.Add(tr);
        }
        Panel1.Controls.Add(tb);
         */ 
    }
    protected void btnNop_Click(object sender, EventArgs e)
    {
       /*
        Table t = (Table)Page.FindControl("Panel1").FindControl("tb");
        TextBox tbox;


        foreach (TableRow tr in t.Rows)
        {
            foreach (TableCell tc in tr.Cells)
            {
                foreach (Control c in tc.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        tbox = (TextBox)c;
                        Response.Write("TextBox ID = " + tbox.ID + "<br/>");
                        Response.Write("TextBox Text = " + tbox.Text + "<br/>");
                    }
                }
            }
        }
        */
        TextBox tbox;
        DiemXetTuyen objDiemXetTuyen = null;
        if (validateMath())
        {
            foreach (Control c in holder.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    tbox = (TextBox)c;

                    string maMon = tbox.ID;
                    maMon = maMon.Substring(0,maMon.IndexOf('_'));
                    int iMaMon = Convert.ToInt32(maMon);
                    string maKhoi = tbox.ID;
                    
                    maKhoi = maKhoi.Remove(0, maMon.Length + 1);
                    double diem = Double.Parse(tbox.Text.Trim());
    /*
                    Response.Write("TextBox ID = " + tbox.ID + "<br/>");
                    Response.Write("MaMdiemon = " + maMon + "<br/>");
                    Response.Write("MaKhoi = " + maKhoi + "<br/>");
                    Response.Write("Điểm = " + diem.ToString() + "<br/>");
     */
                    string slqNganh = string.Format("Select * From t_NganhXetTuyen Where idhs = {0} And TrangThai = 1 And MaKhoi ='{1}'", idHS, maKhoi);
                    //Response.Write(slqNganh);
                   DataTable dtNganhXT = NganhXetTuyenServices.FindNganhXetTuyen(slqNganh);
                    int iNganhXt = dtNganhXT.Rows.Count;
                    if (iNganhXt <= 0)
                    {
                     
                        objDiemXetTuyen = new DiemXetTuyen(idHS, iMaMon, diem, maKhoi);
                        if(maKhoi.Length<3)
                       DiemXetTuyenServices.Delete(idHS, iMaMon, maKhoi);
                        DiemXetTuyenServices.Insert(objDiemXetTuyen);
                    }
                   // DiemXetTuyenServices.Insert(objDiemXetTuyen);
                }
            }

            HoSoServices.UpdateDienTB(idHS, HeSo);
           
            HoSo objHoso = new HoSo();
            objHoso = (HoSo)Session["objHoSo"];
            objHoso.Buoc = 3;
            HoSoServices.Update(objHoso);
            Response.Redirect(ResolveUrl("~/Thongbao.html"));
        
           
        }
        

    }
    private bool validateMath()
    {
        if (IsValid)
        {
            TextBox tbox;
           
            foreach (Control c in holder.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    tbox = (TextBox)c;
                    //Response.Write("TextBox ID = " + tbox.ID + "<br/>");
                    //Response.Write("TextBox Text = " + tbox.Text + "<br/>");
                    if (!decimalRegex.IsMatch(tbox.Text))
                    {
                        perror.Visible = true;
                        perror.InnerHtml = "Bạn phải nhập dữ liệu số! <br />";
                        tbox.Focus();
                        return false;
                    }
                    else
                    {
                        tbox.Text = tbox.Text.Replace(",", ".");
                       
                        float diem = float.Parse(tbox.Text.Trim());
                        if (0 > diem || diem > 10)
                        {
                            perror.Visible = true;
                            perror.InnerHtml = "Điểm phải lớn hơn 0 và nhỏ hơn hoặc bằng 10! <br />";
                            tbox.Focus();
                            return false;

                        }
                    }

                }
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
        }
            perror.Visible = false;
            perror.InnerHtml = "";
            return true;
        
    }
}
