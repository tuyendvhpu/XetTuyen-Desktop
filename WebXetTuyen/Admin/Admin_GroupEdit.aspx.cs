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

public partial class Admin_GroupEdit : System.Web.UI.Page
{
    public Guid groupID;
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
        groupID = new Guid(Request.QueryString["ID"].ToString());

        if(!IsPostBack){  
        LoadData();
        }
    }

    public void LoadData()
    {

        DataTable dt = GroupsServices.LoadByPrimaryKey(groupID);
        

            txtName.Text = dt.Rows[0]["GroupName"].ToString();
            txtGhichu.Text = dt.Rows[0]["Note"].ToString();
            bool isAdmin = Convert.ToBoolean(dt.Rows[0]["isAdmin"].ToString());

            rdbIsAdmin.Checked = isAdmin;



    }
    protected void bntUpdate_Click(object sender, EventArgs e)
    {

        Groups objGroup = new Groups();
      
        objGroup.GroupID = groupID;
        objGroup.GroupName = txtName.Text.Trim();
        objGroup.Note = txtGhichu.Text.Trim();
        objGroup.IsAdmin = rdbIsAdmin.Checked;

        if (GroupsServices.Update(objGroup))
        {
            lblAdd.Text = "Đã cập nhật vào cơ sở dữ liệu hãy nhấn vào <a href='" + ResolveUrl("~/Admin/Group.html") + "'target='_self'>Đây</a> để quay về quản trị Album";
            lblAdd.Visible = true;

        }

    }
}
