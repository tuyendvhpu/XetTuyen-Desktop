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
using DataAccess;
using Business;
using BusinessLogic;
using System.Globalization;


public partial class Admin_HoSoTraCuu : System.Web.UI.Page
{
    private DataView dtv =null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AddStatus"]==null)
            Response.Redirect(ResolveUrl("Login.html"));
        if (!IsPostBack) {
            drlDotXetTuyen.DataSource = DotXetTuyenServices.LoaAll();
            drlDotXetTuyen.DataValueField = "MaDot";
            drlDotXetTuyen.DataTextField = "TenDot";
            drlDotXetTuyen.DataBind();
            loadView();
        }
    }
    private void loadView()
    {
        string sql = "Select * From v_HoSo_NganhXetTuyen";
        dtv = new DataView(HoSoServices.FindHoSo(sql));
       
            dtv.RowFilter = "SoBaoDanh like '%" + txtSoBaoDanh.Text.Trim() + "%' AND SoCMTND like '%" + txtSoCMTD.Text.Trim() + "%' " + " AND DienThoai like '%" + txtDienThoai.Text.Trim() + "%' " + " AND MaDot = '" + drlDotXetTuyen.SelectedValue.ToString() + "' ";
      
       
        dtv.Sort = "NgayNhap";
        grvHoSo.DataSource = dtv;

        grvHoSo.DataBind();
        
    }
    protected void grvHoSo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHoSo.PageIndex = e.NewPageIndex;
        loadView();
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        loadView();
        
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("Companies.xls", grvHoSo);
       
    }
}
