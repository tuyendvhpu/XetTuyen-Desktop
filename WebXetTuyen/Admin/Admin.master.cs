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

public partial class Admin_Admin : System.Web.UI.MasterPage

{
    
        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["AddStatus"] == null)
        {
            Response.Redirect(ResolveUrl("~/Admin/Login.html"));
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["Admin"] = null;
        Session["AddStatus"] = null;
       Response.Redirect(ResolveUrl("~/Home.html"));
    }
}
