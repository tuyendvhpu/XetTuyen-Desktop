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


public partial class Admin_Login : System.Web.UI.Page
{

    private UserStatus userSatatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Utilities.encryptMD5String("vanxuanco"));
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPass.Text = "";
        txtUserName.Text = "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtPass.Text.Trim() != string.Empty & txtUserName.Text.Trim() != string.Empty) {

            Session["User"]=UsersServices.CheckUser(txtUserName.Text.Trim(), txtPass.Text.Trim(),ref userSatatus);
            
            if (userSatatus == UserStatus.OK)
            {
                Session["AddStatus"] = userSatatus;
                Response.Redirect(ResolveUrl("TraCuu.html"));
            }
           
        }
    }
    
}
