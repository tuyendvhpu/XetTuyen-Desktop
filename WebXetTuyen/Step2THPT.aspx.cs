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

public partial class Step2THPT : System.Web.UI.Page
{
    private int nam = 2014;
    public static int irow = 0;
    private Regex decimalRegex = null;
    private long idHS;
    private string dotxetuyen = "";
    private   int HeSo = 0;
    protected void Page_Load(object sender, EventArgs e)

    {
        nam = Convert.ToInt32(Application["nam"]);
        HeSo = Convert.ToInt32(Application["HeSo"]); 
        //Session["objHoSo"] = HoSoServices.GetObjectHoSoBySoCMTND("123456789", nam);
        // Session["objHoSo"] = objHoso;
        Session["step1"] = 2;
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
            //Dot xet tuyen ***
             dotxetuyen = DotXetTuyenServices.LoadByDate(Utilities.GetServerTime()).Rows[0]["Madot"].ToString();//du lieu tu dong theo ngay hien tai
            //  Response.Write(Utilities.GetServerTime().ToLongDateString());

        }
        else
        {
            // Response.Redirect(ResolveUrl("~/SetpOne.html"));'
            //idHS = 12;
        }


        string sqlnganh = string.Format("SELECT DISTINCT Makhoi from t_NganhXetTuyen Where IDHS ={0}", idHS);
       DataTable dtKhoi = NganhXetTuyenServices.FindNganhXetTuyen(sqlnganh);

        
      //DataTable dtKhoi = new DataTable();

      //dtKhoi.Columns.Add("MaKhoi", typeof(string));
      //dtKhoi.Rows.Add("THPT_A");
     // dtKhoi.Rows.Add("THPT_A1");
      

        if (dtKhoi.Rows.Count > 0)
        {

            for (int j = 0; j < dtKhoi.Rows.Count; j++)
            {
                string khoiXT = dtKhoi.Rows[j]["MaKhoi"].ToString();
                if (khoiXT.Length > 3)//kiem tra co phai khoi THPT ko?
                {

                    //DataTable dtMon = NganhXetTuyenServices.LoadMonXetTuyen(idHS, nam);
                    DataTable dtMon = KhoiMonServices.LoadTenMonByPrimaryKey(nam, khoiXT);

                    string slqNganh = string.Format("Select * From t_NganhXetTuyen Where idhs = {0} And TrangThai = 1 And MaKhoi ='{1}'", idHS, khoiXT);
                    DataTable dtNganhXT = NganhXetTuyenServices.FindNganhXetTuyen(slqNganh);

                    string sqlMonTeam = string.Format("Select * From TeamMonKhoi Where Makhoi=N'{0}' ", khoiXT.Substring(khoiXT.IndexOf('_') + 1, khoiXT.Length - khoiXT.IndexOf('_') - 1));
                    DataTable dtMonTeam = MonXTServices.FindMonXT(sqlMonTeam);
                    int iNganhXt = dtNganhXT.Rows.Count;

                    irow = dtMon.Rows.Count;

                    TableRow tr = null;
                    TableRow trct = null;
                    TextBox txt = null;
                    Label lblMon = null;
                    Table tb = new Table();
                    Table tbct = null;
                    tb.ID = "tb1" +j;
                    tr = new TableRow();
                    TableCell tc = null;
                   // TextBox tbox = null;
                    int dem = 0;
                    int dem2 = 0;
                    int dem3 = 0;
                    int dem4 = 0;
                    int vitri = 0;
                    
                  //  string ten = "";
                    
                    for (int i = 0; i < irow; i++)
                    {
                        dem2 = dem2 + 1; dem3 += 1; ;
                        
                        if (dem3 == 3)
                        {
                          
                            lblMon = new Label();
                            lblMon.ID="Khoi"+j;
                            lblMon.Text = "Khối " + khoiXT+ ": &nbsp </br>";
                            lblMon.CssClass = "Mon";
                            holder.Controls.Add(lblMon);
                        }

                        if (dem == 0)
                        {
                            

                            tbct = new Table();
                           
                          

                            trct = new TableRow();
                            tc = new TableCell();
                            lblMon = new Label();
                         

                            lblMon.ID = "lblMon1" + i.ToString() +j.ToString() +dem3.ToString();
                            if(dtMonTeam.Rows.Count>0)
                            lblMon.Text = "&nbsp" + dtMonTeam.Rows[0]["Mon1"].ToString();
                            lblMon.CssClass = "Lop";
                            tc.Controls.Add(lblMon);
                            trct.Cells.Add(tc);

                            tc = new TableCell();
                            lblMon = new Label();
                            lblMon.ID = "lblMom2" + i.ToString() + j.ToString() + dem3.ToString();
                            if (dtMonTeam.Rows.Count > 0)
                                lblMon.Text = "&nbsp" + dtMonTeam.Rows[0]["Mon2"].ToString();
                            lblMon.CssClass = "Lop";
                            tc.Controls.Add(lblMon);
                            trct.Cells.Add(tc);

                            tc = new TableCell();
                            lblMon = new Label();
                            lblMon.ID = "lblMon3" + i.ToString() + j.ToString() + dem3.ToString();
                            if (dtMonTeam.Rows.Count > 0)
                                lblMon.Text = "&nbsp" + dtMonTeam.Rows[0]["Mon3"].ToString();
                            lblMon.CssClass = "Lop";
                            tc.Controls.Add(lblMon);
                            trct.Cells.Add(tc);
                            
                            tbct.Rows.Add(trct);


                        }
                        dem += 1;
                        if (dem4 ==0)
                        {
                          



                            trct = new TableRow();
                            tc = new TableCell();

                        }
                        

                        string sqlDiemXT = string.Format("SELECT * FROM t_DiemXetTuyen Where IdHs ={0} And Mamon ='{1}'", idHS, dtMon.Rows[i]["MaMon"].ToString());
                        DataTable dtDiemxt = DiemXetTuyenServices.FindDiemXetTuyen(sqlDiemXT);

                        tc = new TableCell();
                        //Sinh textbox nhap diem
                        txt = new TextBox();


                        txt.ID = dtMon.Rows[i]["MaMon"].ToString() + "_" + khoiXT;

                        if (dtDiemxt.Rows.Count > 0)
                            txt.Text = dtDiemxt.Rows[0]["Diem"].ToString();

                        if (iNganhXt > 0)
                            txt.Enabled = false;

                        txt.CssClass = "Diemtxt";
                        //txt.Text = ten + hk + slop; 
                        //txt.Text = i.ToString();
                        txt.MaxLength = 4;
                        tc.Controls.Add(txt);
                        trct.Cells.Add(tc);
                        
                        dem4 += 1;

                        if (dem4 == 3)
                        {

                            
                            tbct.Rows.Add(trct);

                        }
                        
                        if (dem2 == 3)
                        {

                            tc = new TableCell();
                            tc.Controls.Add(tbct);
                            tr.Cells.Add(tc);
                            dem2 = 0;
                            dem = 0;
                            dem4 = 0;

                        }

                      
                        if (i == irow - 1)
                        {
                            tc = new TableCell();
                            tc.HorizontalAlign = HorizontalAlign.Left;
                            tc.Controls.Add(tbct);
                            tr.HorizontalAlign = HorizontalAlign.Left;
                            tr.Cells.Add(tc);
                            tb.Rows.Add(tr);
                            //Response.Write(dem2);
                        }
                        if (dem3 == 3)
                        {
                            tb.Rows.Add(tr);
                            tr = new TableRow();
                            tc = new TableCell();
                            tc.ColumnSpan = 4;
                            tc.Text = "<div class='line' style='height:20px;'></div>";
                            tr.Cells.Add(tc);
                            tb.Rows.Add(tr);
                            tr = new TableRow();
                            dem3 = 0;
                            

                        }
                    }

                       holder.Controls.Add(tb);


                }
            }
        }



      

        if (!IsPostBack)
        {
            //if (Session["CapNhat"].ToString() == "CẬP NHẬT")
            //{
                //DataTable dtMonXT = DiemXetTuyenServices.LoadByIdHS(idHS);
                //for (int i = 0; i < dtMonXT.Rows.Count;i++ )
                //{
                //    if (dtMonXT.Rows[i]["MaMon"].ToString().Length > 6)
                //    {

                //        DiemXetTuyenServices.Delete(idHS, dtMonXT.Rows[i]["MaMon"].ToString());
                        
                //    }
                //}
                //DiemXetTuyenServices.Delete(idHS);

            //}

        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {


        

    }
    protected void btnNop_Click(object sender, EventArgs e)
    {
        
        
        TextBox tbox;
       
        
        Table tb ;
        Table tbct ;

     DiemXetTuyen objDiemXetTuyen = null;
        if (validateMath())
        {
            //  Response.Write("ok");
            foreach (Control c in holder.Controls)
            {
                if (c.GetType() == typeof(Table))
                {
                    tb = (Table)c;
                    foreach (TableRow tr in tb.Rows)
                    {
                        foreach (TableCell tc in tr.Cells)
                        {
                            foreach (Control c1 in tc.Controls)
                            {
                                if (c1.GetType() == typeof(Table))
                                {
                                    tbct = (Table)c1;
                                    foreach (TableRow trct in tbct.Rows)
                                    {
                                        foreach (TableCell tcct in trct.Cells)
                                        {
                                            foreach (Control c2 in tcct.Controls)
                                            {
                                                if (c2.GetType() == typeof(TextBox))
                                                {
                                                    tbox = (TextBox)c2;

                                                    string maMon = tbox.ID;
                                                    maMon = maMon.Substring(0, maMon.IndexOf('_'));
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
                                                   //Response.Write("TextBox ID = " + tbox.ID + "<br/>");
                                                    //Response.Write("TextBox Text = " + tbox.Text + "<br/>");
                                                 //   objDiemXetTuyen = new DiemXetTuyen(idHS, tbox.ID, Double.Parse(tbox.Text.Trim()));

                                                    string slqNganh = string.Format("Select * From t_NganhXetTuyen Where idhs = {0} And TrangThai = 1 And MaKhoi ='{1}'", idHS, maKhoi);
                                                    //Response.Write(slqNganh);
                                                    DataTable dtNganhXT = NganhXetTuyenServices.FindNganhXetTuyen(slqNganh);
                                                    int iNganhXt = dtNganhXT.Rows.Count;
                                                    if (iNganhXt <= 0)
                                                    {

                                                        objDiemXetTuyen = new DiemXetTuyen(idHS, iMaMon, diem, maKhoi);
                                                        if (maKhoi.Length > 3)
                                                        DiemXetTuyenServices.Delete(idHS, iMaMon, maKhoi);
                                                        DiemXetTuyenServices.Insert(objDiemXetTuyen);
                                                    }

                                                }
                                            }
                                        }
                                    }

                                }
                            }

                        }
                    }

                }
               

                
            }
            
            HoSoServices.UpdateDienTB(idHS,HeSo);
            HoSo objHoso = new HoSo();
            objHoso = (HoSo)Session["objHoSo"];
            objHoso.Buoc = 3;
            HoSoServices.Update(objHoso);
            Response.Redirect(ResolveUrl("~/Thongbao.html"));
            
        }
    }
    private bool validateMath()

    {
       
            TextBox tbox;

            Table tb;
            Table tbct;
           
            foreach (Control c in holder.Controls)
            {
                if (c.GetType() == typeof(Table))
                {
                    tb = (Table)c;
                    foreach (TableRow tr in tb.Rows)
                    {
                        foreach (TableCell tc in tr.Cells)
                        {
                            foreach (Control c1 in tc.Controls)
                            {
                                if (c1.GetType() == typeof(Table))
                                {
                                    tbct = (Table)c1;
                                    foreach (TableRow trct in tbct.Rows)
                                    {
                                        foreach (TableCell tcct in trct.Cells)
                                        {
                                            foreach (Control c2 in tcct.Controls)
                                            {
                                                if (c2.GetType() == typeof(TextBox))
                                                {
                                                    tbox = (TextBox)c2;
                                                    ////Response.Write("TextBox ID = " + tbox.ID + "<br/>");
                                                 //   Response.Write("TextBox Text = " + tbox.Text + "<br/>");
                                                    if (!decimalRegex.IsMatch(tbox.Text.Trim()))
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
                                        }

                                    }
                                }

                            }
                        }

                    }

                }

            if (!captcha.Decide())
            {
                captcha.message = "Mã nhập sai!";
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
