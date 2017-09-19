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
    private int nam = 2014;
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]);
       
        if (Session["HinhThuc"] == null || Session["HinhThuc"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/Home.html"));
        }
            Session["soCMTND"] = "";
            Session["soBaoDanh"] = "";
     
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string sSoCMMTND = txtSoCMTND.Text.Trim();
        if (!sSoCMMTND.Equals("") || sSoCMMTND.Length<=0)
        {
            DataTable dtSoCMTND = HoSoServices.LoadByPrimaryKey(sSoCMMTND,nam);
            int num = dtSoCMTND.Rows.Count;
            if (num > 0)
            {
               // if (Convert.ToInt32(dtSoCMTND.Rows[0]["Buoc"].ToString()) >0)
                //{
                    HoSo objHoso = HoSoServices.GetObjectHoSoBySoCMTND(sSoCMMTND, nam);
                    Session["objHoSo"] = objHoso;
                    Session["step2"] = 2;
                    Session["soCMTND"] = objHoso.SoCMTND;
                    Session["soBaoDanh"] = objHoso.SoBaoDanh;
                   Response.Redirect(ResolveUrl("~/SoCMTNDError.html"));
                //}
                /*
                else {
                    HoSo objHoso = HoSoServices.GetObjectHoSoBySoCMTND(sSoCMMTND,nam);
                    Session["step1"] = 1;
                    Session["objHoSo"] = objHoso;
                    Session["step2"] = 2;
                    Session["soCMTND"] = objHoso.SoCMTND;
                    Session["soBaoDanh"] = objHoso.SoBaoDanh;
                    Session["CapNhat"] = "CẬP NHẬT";
                    Response.Redirect(ResolveUrl("~/Thongtin.html"));
                }
                */

            }
            else {
                Session["soCMTND"] = sSoCMMTND;
               // Session["soBaoDanh"] = HoSoServices.GetSoBaoDanhRandom(nam, "DHP", 6);
                HoSo objHoso = new HoSo();
                objHoso.SoCMTND = Session["soCMTND"].ToString();
                objHoso.SoBaoDanh = Session["soBaoDanh"].ToString();
                Session["CapNhat"] = "Mới";
                objHoso.Buoc = 0;
                objHoso.Nam = nam;
                Session["objHoSo"] = objHoso;
                //HoSoServices.Insert(objHoso);
               // objHoso = HoSoServices.GetObjectHoSoBySoCMTND_soBD(Session["soCMTND"].ToString(), Session["soBaoDanh"].ToString(),nam);
                //Session["objHoSo"] = objHoso;
               // Response.Write(objHoso.Idhs.ToString() + "smt" + objHoso.SoCMTND + "- sbd: " + objHoso.SoBaoDanh + " - Ngaysinh:" + objHoso.NgaySinh.ToString());
                Response.Redirect(ResolveUrl("~/Thongtin.html"));
            }
        }
      
    }
}
