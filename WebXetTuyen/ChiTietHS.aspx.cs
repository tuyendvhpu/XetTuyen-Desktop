using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

public partial class _Default : System.Web.UI.Page
{
    public DataTable dtDot;
    private int nam = 2015;
    public HoSo objHoso;
    public DataTable dtNganh,dtTrungTuyen;
   

    public int id = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]); 

       
            if (Session["CapNhat"] != null)
            {
                if (Session["objHoSoFind"] == null || Session["CapNhat"].ToString() != "CẬP NHẬT")
                {
                    Response.Redirect(ResolveUrl("~/Home.html"));
                }
                else
                {
                    objHoso = new HoSo();
                    objHoso = (HoSo)Session["objHoSoFind"];
                    dtDot = DotXetTuyenServices.LoadByNam(nam);

                    dtNganh = NganhXetTuyenServices.LoadByIdHS(objHoso.Idhs);


                    string sqlnganh = string.Format("SELECT * from v_HoSo_NganhXetTuyen Where IDHS ={0}", objHoso.Idhs);
                    dtTrungTuyen = NganhXetTuyenServices.FindNganhXetTuyen(sqlnganh);
                    if (dtTrungTuyen.Rows.Count > 0)
                    {
                        for (int inganh = 0; inganh < dtTrungTuyen.Rows.Count; inganh++)
                        {
                            string snganh = string.Format("Tên ngành: {0} - Khối:{1} - Điểm trung bình: {2}<strong style='color:blue'> : Trúng tuyển!</strong>", dtTrungTuyen.Rows[inganh]["TenNganh"].ToString(), dtTrungTuyen.Rows[inganh]["MaKhoi"].ToString(), dtTrungTuyen.Rows[inganh]["DiemTB"].ToString());
                            rblTrungTuyen.Items.Add(new ListItem(snganh, dtTrungTuyen.Rows[inganh]["IDNganh"].ToString()));
                        }
                    }


                }
            }
            else { Response.Redirect(ResolveUrl("~/Home.html")); }
        

    }
    public bool checkNganhXT(string maNganh, double dTB) { 
    
        bool tt = true;
        if (maNganh.Substring(0, 1).Equals("D"))
        {
            if (dTB < 6.0)
            {
                tt = false;
            }
        }
        else {
            if (dTB < 5.5)
            {
                tt = false;
            }
        }

        return tt;

    }

    protected void btnKetThuc_Click(object sender, EventArgs e)
    {
        if (Session["CapNhat"] != null)
        {
            if (Session["objHoSoFind"] != null )
            {
                if (dtTrungTuyen.Rows.Count > 0)
                {
                    string sup = string.Format("Update t_TrungTuyen set ChonIn = 0 Where IDHS ={0}", objHoso.Idhs);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sup;
                    if (Utilities.getConnection())
                    {
                        cmd.Connection = Utilities.conDBConnection;
                        if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
                        int i = cmd.ExecuteNonQuery();
                        Utilities.conDBConnection.Close();
                    }
                    Session["snganh"] = "";
                    foreach (ListItem li in rblTrungTuyen.Items)
                    {

                        if (li.Selected)
                        {
                            string sqlnganh = string.Format("SELECT * from v_HoSo_NganhXetTuyen Where IDHS ={0} AND IDNganh = N'{1}'", objHoso.Idhs, li.Value.ToString());
                            dtTrungTuyen = NganhXetTuyenServices.FindNganhXetTuyen(sqlnganh);
                     if (dtTrungTuyen.Rows.Count > 0)
                    {
                        for (int inganh = 0; inganh < dtTrungTuyen.Rows.Count; inganh++)
                        {
                             Session["snganh"]  = string.Format(" {0} - Khối:{1} - Điểm trung bình: {2} ", dtTrungTuyen.Rows[inganh]["TenNganh"].ToString(), dtTrungTuyen.Rows[inganh]["MaKhoi"].ToString(), dtTrungTuyen.Rows[inganh]["DiemTB"].ToString());
                           
                        }
                    }
                            sup = string.Format("Update t_TrungTuyen set ChonIn = 1 Where IDHS ={0} AND NganhXT =N'{1}' ", objHoso.Idhs, li.Value.ToString());
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sup;
                            if (Utilities.getConnection())
                            {
                                cmd.Connection = Utilities.conDBConnection;
                                if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
                                int i = cmd.ExecuteNonQuery();
                                Utilities.conDBConnection.Close();
                            }
                        }
                    }

                }
            }
        }
        Session["CapNhat"] = null;
        Session["objHoSoFind"] = null;
        Response.Redirect(ResolveUrl("~/Home.html"));
    }
}
