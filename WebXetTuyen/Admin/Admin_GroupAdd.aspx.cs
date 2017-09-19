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

public partial class Admin_GroupAdd : System.Web.UI.Page
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
    }

    
    protected void bntUpdate_Click(object sender, EventArgs e)
    {

        Groups objGroup = new Groups();
        Guid groupID;
        groupID = Guid.NewGuid();
        objGroup.GroupID = groupID;
        objGroup.GroupName = txtName.Text.Trim();
        objGroup.Note = txtGhichu.Text.Trim();
        objGroup.IsAdmin = false;
      
        if (GroupsServices.Insert(objGroup))
        {
            lblAdd.Text = "Đã thêm vào cơ sở dữ liệu hãy nhấn vào <a href='" + ResolveUrl("~/Admin/Group.html") + "'target='_self'>Đây</a> để quay về quản trị Album";
            lblAdd.Visible = true;

        }

    }
}
