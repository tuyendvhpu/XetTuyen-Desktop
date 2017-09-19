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
using System.Globalization;

public partial class Admin_UsersAdd : System.Web.UI.Page
{
    private UserCollection userCollection;
  
    private DateTime dtmMaxDate = new DateTime(9999, 12, 31);
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
        
        if (!IsPostBack) {
            LoadData();
        }
    }
   
    public void LoadData()
    {

       
        cblGroup.DataSource = GroupsServices.LoaAll();
        cblGroup.DataTextField = "GroupName";
        cblGroup.DataValueField = "GroupID";
        cblGroup.DataBind();



    }
    /// <summary>
    /// IsUserNameExists
    /// </summary>
    /// <param name="sUserName"></param>
    /// <returns></returns>
    private bool IsUserNameExists(string sLoginID)
    {
        foreach (Users objUser in userCollection)
        {
           // lbleror.Text = objUser.LoginID.ToLower() + "<br />";
            if (objUser.LoginID.ToLower() == sLoginID.ToLower())
            {
                
                return true;
            }
        }

        return false;
    }
     /// <summary>
        /// IsDataOK
        /// </summary>
        /// <returns></returns>
    private bool IsDataOK()
    {
        lbleror.Text = "";
        string mserror = "";
        userCollection = UsersServices.GetListUser();
        
        bool isval = true;
       // lbleror.Text = "";
        if (IsUserNameExists(txtUser.Text.Trim())) {
            isval = false;
            mserror += "Tên đăng nhập đã  được dùng!";
        }
        bool itemChecked = false;
        foreach (ListItem item in cblGroup.Items)
        {

            if (item.Selected)
            {
                itemChecked = true;
            }
        }
        if (itemChecked==false) {
            isval = false;
             mserror +=   "<br />" + "Bạn chưa chọn nhóm người dùng!";
        }
        if (isval == false) {
            lbleror.Text = mserror;
        
        }

        return isval;
    }
    protected void bntUpdate_Click(object sender, EventArgs e)
    {
        if (IsDataOK()) {
            GroupUser objGroupUser;
            Users objUser = new Users();
            objUser.LoginID = txtUser.Text.Trim();
            objUser.Password = txtRePass.Text.Trim();
            objUser.FullName = txtName.Text.Trim();
            objUser.Email = txtEmail.Text.Trim();
            objUser.BirthDay = DateTime.ParseExact(txtBirthDay.Text.Trim(), "dd/MM/yyyy", null);
            objUser.Gender = drlGioiTinh.SelectedValue;
            objUser.LockedReason = txtLockReason.Text;
            objUser.LockedUser = cbLock.Checked;
          
            objUser.DeadlineOfUsing = DateTime.ParseExact(txtDateDeadline.Text.Trim(), "dd/MM/yyyy", null);

            if (UsersServices.Insert(objUser))
            {
                lblAdd.Text = "Đã thêm vào cơ sở dữ liệu hãy nhấn vào <a href='" + ResolveUrl("~/Admin/Users.html") + "'target='_self'>Đây</a> để quay về quản trị Album";
                lblAdd.Visible = true;

            }
            //Add User-Group   
            foreach (ListItem item in cblGroup.Items)
            {

                if (item.Selected)
                {
                    objGroupUser = new GroupUser();
                    Guid  groupID = new Guid( item.Value.ToString());
                    objGroupUser.GroupID = groupID;
                    objGroupUser.LoginID = txtUser.Text.Trim();
                    GroupUserServices.Insert(objGroupUser);
                }
            }
            

            
        }
      

    }
}
