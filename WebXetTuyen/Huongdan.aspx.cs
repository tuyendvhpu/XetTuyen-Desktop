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


public partial class Huongdan : System.Web.UI.Page
{
    public DataTable dtTinh;
    public DataTable dtHuyen;
    protected void Page_Load(object sender, EventArgs e)
    {
        dtTinh = TinhServices.LoaAll();
        dtHuyen = HuyenServices.LoadByMaTinh("03");
        if (!IsPostBack)
        {
        }
       

    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        dtHuyen = HuyenServices.LoadByMaTinh(txtMaTinh.Text.Trim());
    }
}
