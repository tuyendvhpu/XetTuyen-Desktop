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

public partial class TruongPT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id ="";
        int Nam  = Convert.ToInt32(Application["nam"]); ;

        if (!IsPostBack)
        {
            if (Request.QueryString.Get("ID") != null)
                id = Request.QueryString.Get("ID").ToString();

            grvTruongpt.DataSource = TruongPTServices.LoadByMaTinh(id,Nam);
            grvTruongpt.DataBind();


        }
    }
}
