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

public partial class Admin_Admin_Del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Admin"] == null || Session["AddStatus"] == null)
        //{
        //    Response.Redirect(ResolveUrl("~/Admin/Login.html"));
        //}
         DataTable dt;
        string Name = Request.QueryString["Name"];
        
        switch (Name)
        {
            
          
          
         case "Group":
              Guid groupID = new Guid(Request.QueryString["ID"].ToString());
             GroupsServices.Delete(groupID);
           
            Response.Redirect("~/Admin/Group.html");
            break;
         case "Users":

            string LoginID = Request.QueryString["ID"].ToString();
                
            GroupUserServices.Delete(LoginID);
            UsersServices.Delete(LoginID);
            Response.Redirect("~/Admin/Users.html");
            break;
        
            default:
            Response.Redirect("~/Admin/Index.html");
                break;
        }
    }
}
