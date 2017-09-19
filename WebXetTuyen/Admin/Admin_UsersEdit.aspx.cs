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

public partial class Admin_UsersEdit : System.Web.UI.Page
{
    private UserCollection userCollection;
    private GroupUserCollection groupUserCollection;
    private string sLoginID = "";
    private Users objUser = null;
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
        else {
            Response.Redirect(ResolveUrl("Login.html"));
        }
        sLoginID = Request.QueryString["ID"].ToString().Trim();
        if (!IsPostBack) {
            LoadData();
        }
    }
   
    public void LoadData()
    {
        groupUserCollection = GroupUserServices.GetListGroupUserByUserID(sLoginID);
        objUser = UsersServices.GetUserByID(sLoginID);

        txtUser.Text = objUser.LoginID;
       // txtPass.Text = Utilities.decryptString(objUser.Password);
        //txtRePass.Text = Utilities.decryptString(objUser.Password);
        txtName.Text = objUser.FullName;
        txtBirthDay.Text = objUser.BirthDay.ToString("dd/MM/yyyy");
        drlGioiTinh.SelectedValue = objUser.Gender;
        txtEmail.Text = objUser.Email;
        cbLock.Checked = Convert.ToBoolean(objUser.LockedUser);
        txtLockReason.Text = objUser.LockedReason;
        txtDateDeadline.Text = objUser.DeadlineOfUsing.ToString("dd/MM/yyyy");

        cblGroup.DataSource = GroupsServices.LoaAll();
        cblGroup.DataTextField = "GroupName";
        cblGroup.DataValueField = "GroupID";
        cblGroup.DataBind();

        SetCheckedGroupsForSelectedUser();

    }
    /// <summary>
    /// Set Checked Groups For Selected User
    /// </summary>
    private void SetCheckedGroupsForSelectedUser()
    {
      //  ClearCheckedGroups();
        //string groupslect= "";
        for (int i = 0; i < groupUserCollection.Count; i++)
        {
            for (int j = 0; j < cblGroup.Items.Count; j++)
            {

                GroupUser objGroupUser = (GroupUser)groupUserCollection[i];

                if (cblGroup.Items[j].Value.Equals(objGroupUser.GroupID.ToString()))
                {
                    cblGroup.Items[j].Selected = true;
                    //groupslect += cblGroup.Items[j].Value +"---" + j.ToString();
                    break;
                }
            }
        }
        //lbleror.Text = groupslect;
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        var culture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yy";
        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
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
        //if (IsUserNameExists(txtUser.Text.Trim())) {
        //    isval = false;
        //    mserror += "Tên đăng nhập đã  được dùng!";
        //}
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
            if (objUser == null)
                objUser = new Users();
            objUser.LoginID = txtUser.Text.Trim();
            objUser.Password = txtRePass.Text.Trim();
            objUser.FullName = txtName.Text.Trim();
            objUser.Email = txtEmail.Text.Trim();
            objUser.BirthDay = DateTime.ParseExact(txtBirthDay.Text.Trim(), "dd/MM/yyyy", null);
            objUser.Gender = drlGioiTinh.SelectedValue;
            objUser.LockedReason = txtLockReason.Text;
            objUser.LockedUser = cbLock.Checked;
          
            objUser.DeadlineOfUsing = DateTime.ParseExact(txtDateDeadline.Text.Trim(), "dd/MM/yyyy", null);

            if (UsersServices.Update(objUser))
            {
                lblAdd.Text = "Đã cập nhật vào cơ sở dữ liệu hãy nhấn vào <a href='" + ResolveUrl("~/Admin/Users.html") + "'target='_self'>Đây</a> để quay về quản trị User";
                lblAdd.Visible = true;

            }
            
            //Delete User-Group
            GroupUserServices.Delete( objUser.LoginID.Trim() );
            //lbleror.Text= objUser.LoginID;
            ////Add User-Group   
            foreach (ListItem item in cblGroup.Items)
            {

                if (item.Selected)
                {
                    objGroupUser = new GroupUser();
                    Guid groupID = new Guid(item.Value.ToString());
                    objGroupUser.GroupID = groupID;
                    objGroupUser.LoginID = txtUser.Text.Trim();
                    GroupUserServices.Insert(objGroupUser);
                }
            }
            

            
        }
      

    }
    protected void cblGroup_DataBinding(object sender, EventArgs e)
    {
        SetCheckedGroupsForSelectedUser();
    }
}
