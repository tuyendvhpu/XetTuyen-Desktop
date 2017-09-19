using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Business;
using DataAccess;

public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AddStatus"] != null)
        {

            Users objUser = (Users)Session["User"];
            if (!UsersServices.IsAdminUser(objUser.LoginID))
            {
                Response.Redirect(ResolveUrl("ThongBao.html"));
            }

        }
        else
        {
            Response.Redirect(ResolveUrl("Login.html"));
        }

        if (!IsPostBack)
        {
            BindData();
        }

    }
    public void BindData()
    {
        //string sql = "Select * From tbl_QuangCao Order by IThuThu";
        gvTinTuc.DataSource = Business.UsersServices.LoaAll();
        gvTinTuc.DataBind();
        lblThongbao.Text = "Bạn đang ở trang số: " + (gvTinTuc.PageIndex + 1) + " Trong tổng số: " + gvTinTuc.PageCount + " trang";
    }
    protected void gvTinTuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTinTuc.PageIndex = e.NewPageIndex;

        BindData();
    }
   
}
