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

public partial class SoCMTND : System.Web.UI.Page
{
    private int nam = 2015;
    public string dienthoai;
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]);
       
        if (!IsPostBack)
        {
              
           
                hdCount.Value = "0";
          //  lblPhone.Text = "Số điện thoại của bạn: ..." + dienthoai.Substring(dienthoai.Length - 5);
            lblError.Visible = false;
        }

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        count += 1;
        lblError.Visible = false;
        string sSoCMMTND = txtSoCMTND.Text.Trim();
        string sSoBD= txtSoBD.Text.Trim();
        if ((!sSoCMMTND.Equals("")) & (!sSoBD.Equals("")))
        {
            DataTable dtSoCMTND = HoSoServices.LoadByCMAndPhone(sSoCMMTND,sSoBD,nam);
            int num = dtSoCMTND.Rows.Count;
            if (num > 0)
            {
                HoSo objHoso = HoSoServices.GetObjectHoSoBySoCMTNDAndPhone(sSoCMMTND, sSoBD,nam);
               
                Session["objHoSoFind"] = objHoso;
                Session["CapNhat"] = "CẬP NHẬT";
          
                Response.Redirect(ResolveUrl("~/ChiTietHS.html"));
            }
            else {
               //Response.Redirect(ResolveUrl("~/ThongBao/2.html"));
                count = Convert.ToInt32(hdCount.Value) + 1;
                if (count >= 3)
                {
                    
                    lblError.Text = "Bạn đã nhập sai quá 3 lần vui lòng liên hệ số điện thoại: 0974 . 010 . 256";
                    
                    //System.Threading.Thread.Sleep(5000);
                    Response.AddHeader("REFRESH", "5;URL=home.html");
                    
                }
                else {
                    lblError.Text = "Số chứng minh thư hoặc số điện thoại không đúng không đúng! Lần: " + count;
                }
              
                lblError.Visible = true;
                hdCount.Value = count.ToString();
                txtSoBD.Focus();
            }
        }
    }
}
