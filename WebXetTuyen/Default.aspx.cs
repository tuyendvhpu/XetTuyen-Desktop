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
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    public double seconds;
    public DataTable dtDot;
    public DataTable dtDotCurent = null;
    private int nam = 0; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Utilities.getConnection();
            nam = Convert.ToInt32(Application["nam"]); 
        //lbltime.Text = seconds.ToString();
        dtDotCurent = DotXetTuyenServices.LoadByDate(Utilities.GetServerTime());//du lieu tu dong theo ngay hien tai
        DateTime dt = GetEndTime();
       Session["KT"] = dt.AddDays(1).ToString("dd/MM/yyyy");
        seconds = (GetEndTime() - GetStartTime()).TotalSeconds;
        if (!IsPostBack)
        {
            Session["CapNhat"] = null;
           
            
        }
        dtDot = DotXetTuyenServices.LoadByNam(nam);
       
    }
    private DateTime GetStartTime()
    {
        return Utilities.GetServerTime();
    }
    private DateTime GetEndTime()
    {
       // DateTime ad = new DateTime();
        //ad = DateTime.ParseExact(dtDotCurent.Rows[0]["NgayKT"].ToString(), "dd/MM/yyyy", null) ;
        if (dtDotCurent.Rows.Count>0)
        lbltime.Text = dtDotCurent.Rows[0]["NgayKT"].ToString();
        
       // return new DateTime(2011, 12, 08, 8, 12, 0);
        if (dtDotCurent.Rows.Count > 0)
        {
            //  return DateTime.ParseExact(dtDotCurent.Rows[0]["NgayKT"].ToString(), "MM/dd/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
         return   Convert.ToDateTime(dtDotCurent.Rows[0]["NgayKT"].ToString());
        }
        return DateTime.Now;
        
    }
    protected void imgTHPT_Click(object sender, ImageClickEventArgs e)
    {
        if (dtDotCurent.Rows.Count <= 0)
        {
            Response.Redirect(ResolveUrl("~/ThongBao/1.html"));
        }
        Session["HinhThuc"] = "THPT";
        Session["CapNhat"] = "";
        Response.Redirect(ResolveUrl("~/SoCMTND.html"));
    }
    protected void imgDH_Click(object sender, ImageClickEventArgs e)
    {
        if (dtDotCurent.Rows.Count <= 0)
        {
            Response.Redirect(ResolveUrl("~/ThongBao/1.html"));
        }
        Session["HinhThuc"] = "THI ĐẠI HỌC";
        Session["CapNhat"] = "";
        Response.Redirect(ResolveUrl("~/SoCMTND.html"));
    }
    protected void imgCapNhat_Click(object sender, ImageClickEventArgs e)
    {
        
      Response.Redirect(ResolveUrl("~/TimKiemHS.html"));
    }
}
