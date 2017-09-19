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
using System.Collections.Generic;
using Business;
using DataAccess;

public partial class ChongNganh : System.Web.UI.Page
{
    private int nam = 2017;
    public static byte hexettuyen=2;
    private string dotxetuyen = "";
    private long idHS = 0;
    private string manganh = "";
    private string sKhoiDT = "";
    private string hinhthuc = "";
    private DataTable dtNganh;
    private double diemUTKV = 0;
    private double diemUTDT = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        nam = Convert.ToInt32(Application["nam"]); 
        if (Session["objHoSo"] == null || Session["objHoSo"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/SetpOne.html"));
        }
        if (Session["step1"] == null || Session["step1"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/SetpOne.html"));
        }
        sKhoiDT = "A";
        hinhthuc = "THI ĐẠI HỌC";
        if (Session["objHoSo"] != null && Session["objHoSo"].ToString() != "")
        {
            //NganhXetTuyenServices.DeleteByIdHS(idHS, nam);
            
            HoSo objHoso = new HoSo();
            hinhthuc = Session["HinhThuc"].ToString();
            objHoso = (HoSo)Session["objHoSo"];
            // Response.Write(objHoso.Idhs);
            idHS = objHoso.Idhs;
            sKhoiDT = objHoso.KhoiDT;
            hexettuyen = objHoso.HeXetTuyen;
           dotxetuyen = DotXetTuyenServices.LoadByDate(Utilities.GetServerTime()).Rows[0]["Madot"].ToString();//du lieu tu dong theo ngay hien tai
            //  Response.Write(Utilities.GetServerTime().ToLongDateString());
            //dot de test****
           //dotxetuyen = "Dot12014";
             string sqlNganh =string.Format("Select * FROM t_NganhXetTuyen Where IDHS = {0} ", idHS);
           if (hinhthuc.Equals("THI ĐẠI HỌC"))
           {
               sqlNganh = string.Format("Select * FROM t_NganhXetTuyen Where IDHS = {0} AND LEN(makhoi) <3", idHS);
           }
           else {
               sqlNganh = string.Format("Select * FROM t_NganhXetTuyen Where IDHS = {0} AND LEN(makhoi) > 3", idHS);
           }

           dtNganh = NganhXetTuyenServices.FindNganhXetTuyen(sqlNganh);

           KhuVuc objKhuVuc = KhuVucServices.GetKhuVucByID(objHoso.MaKV);
           if (objKhuVuc != null)
               diemUTKV = objKhuVuc.DienUT;

           
           DoiTuongUT objDoiTuongUT = DoiTuongUTServices.GetDoiTuongByID(objHoso.MaDT);
           if (objDoiTuongUT != null)
               diemUTDT = objDoiTuongUT.DiemUT;
        }
        else
        {
            // Response.Redirect(ResolveUrl("~/SetpOne.html"));
            //idHS = 12;
        }
        if (!IsPostBack)
        {
            if (Session["CapNhat"].ToString() == "CẬP NHẬT")
            {

            //  dtNganh = NganhXetTuyenServices.LoadByIdHS(idHS, nam, dotxetuyen);
                //NganhXetTuyenServices.DeleteByIdHS(idHS, nam);
                //for (int i = 0; i < dtNganh.Rows.Count; i++)
                //{
                //    //if (dtNganh.Rows[i]["MaKhoi"].ToString().Length > 2)
                //    //{
                //    //    if (hinhthuc.Equals("THPT"))
                //    //    {
                //    //        NganhXetTuyenServices.DeleteByMaNganh(dtNganh.Rows[i]["MaNganh"].ToString(), nam, dtNganh.Rows[i]["IDNganh"].ToString(), dotxetuyen);
                //    //    }
                //    //}
                //    //else {
                //    //    if (hinhthuc.Equals("THI ĐẠI HỌC"))
                //    //    {
                //    //        NganhXetTuyenServices.DeleteByMaNganh(dtNganh.Rows[i]["MaNganh"].ToString(), nam, dtNganh.Rows[i]["IDNganh"].ToString(), dotxetuyen);
                //    //    }
                //    //}
                //    NganhXetTuyenServices.DeleteByMaNganh(dtNganh.Rows[i]["MaNganh"].ToString(), nam, dtNganh.Rows[i]["IDNganh"].ToString(), dotxetuyen);
                //}
               
            }
            //// load nganh congnghe 52480201
            string nganhCongNghe = "52480201";
            ArrayList khoiDH = new ArrayList();
            ArrayList khoiTPHT = new ArrayList();
            DataTable dtKhoi = NganhServices.LoadKhoiByNganh(nganhCongNghe, nam);


            for (int i = 0; i < dtKhoi.Rows.Count; i++)
                {
                    if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                    {
                        khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                    }
                    else {
                        khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                    }
                }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblCNTT.DataSource = khoiDH;
            }
            else {
                cblCNTT.DataSource = khoiTPHT;
            
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblCNTT.DataBind();


            cblNganhCNTT.DataSource = NganhServices.LoadNganh(nganhCongNghe, nam);
            cblNganhCNTT.DataTextField = "TenNganh";
            cblNganhCNTT.DataValueField = "IDNganh";
            cblNganhCNTT.DataBind();
            

            //// load nganh congnghe cao dang C480201
            nganhCongNghe = "C480201";
            khoiTPHT.Clear();
            khoiDH.Clear();
             dtKhoi = NganhServices.LoadKhoiByNganh(nganhCongNghe, nam);


            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblCNTTCD.DataSource = khoiDH;
            }
            else {
                cblCNTTCD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";

            cblCNTTCD.DataBind();

          
             

            cblNganhCNTTCD.DataSource = NganhServices.LoadNganh(nganhCongNghe, nam);
            cblNganhCNTTCD.DataTextField = "TenNganh";
            cblNganhCNTTCD.DataValueField = "IDNganh";
            cblNganhCNTTCD.DataBind();


            // load nganh dien  52510301
            string nganhDien = "52510301";

            dtKhoi = NganhServices.LoadKhoiByNganh(nganhDien, nam);

            khoiTPHT.Clear();
            khoiDH.Clear();
            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblDien.DataSource = khoiDH;
            }
            else {
                cblDien.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblDien.DataBind();

            cblNganhDien.DataSource = NganhServices.LoadNganh(nganhDien, nam);
            cblNganhDien.DataTextField = "TenNganh";
            cblNganhDien.DataValueField = "IDNganh";
            cblNganhDien.DataBind();

            // load nganh dien  C510301

            nganhDien = "C510301";

            dtKhoi = NganhServices.LoadKhoiByNganh(nganhDien, nam);

            khoiTPHT.Clear();
            khoiDH.Clear();
            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblDienCD.DataSource = khoiDH;
            }
            else {
                cblDienCD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblDienCD.DataBind();

            cblNganhDienCD.DataSource = NganhServices.LoadNganh(nganhDien, nam);
            cblNganhDienCD.DataTextField = "TenNganh";
            cblNganhDienCD.DataValueField = "IDNganh";
            cblNganhDienCD.DataBind();

            //// load nganh van hoa 
            string nganhVanHoa = "52220113";

            cblNganhVH.DataSource = NganhServices.LoadNganh(nganhVanHoa, nam);
            cblNganhVH.DataTextField = "TenNganh";
            cblNganhVH.DataValueField = "IDNganh";
            cblNganhVH.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhVanHoa, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblVH.DataSource = khoiDH;
            }
            else {
                cblVH.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblVH.DataBind();

            //// load nganh Xay dung -- C220113
            nganhVanHoa = "C220113";

            cblNganhVHCD.DataSource = NganhServices.LoadNganh(nganhVanHoa, nam);
            cblNganhVHCD.DataTextField = "TenNganh";
            cblNganhVHCD.DataValueField = "IDNganh";
            cblNganhVHCD.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhVanHoa, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblVHCD.DataSource = khoiDH;
            }
            else {
                cblVHCD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblVHCD.DataBind();

            //// load nganh Xay dung 52580201
            string nganhXayDung = "52580201";
            cblNganhXD.DataSource = NganhServices.LoadNganh(nganhXayDung, nam);
            cblNganhXD.DataTextField = "TenNganh";
            cblNganhXD.DataValueField = "IDNganh";
            cblNganhXD.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhXayDung, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblXD.DataSource = khoiDH;
            }
            else {
                cblXD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblXD.DataBind();

            //// load nganh Xay dung --C510102

            nganhXayDung = "C510102";
            cblNganhXDCD.DataSource = NganhServices.LoadNganh(nganhXayDung, nam);
            cblNganhXDCD.DataTextField = "TenNganh";
            cblNganhXDCD.DataValueField = "IDNganh";
            cblNganhXDCD.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhXayDung, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblXDCD.DataSource = khoiDH;
            }
            else {
                cblXDCD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblXDCD.DataBind();

            //// load nganh Moi truong --
            string nganhMoiTruong = "52510406";
            cblNganhMT.DataSource = NganhServices.LoadNganh(nganhMoiTruong, nam);
            cblNganhMT.DataTextField = "TenNganh";
            cblNganhMT.DataValueField = "IDNganh";
            cblNganhMT.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhMoiTruong, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblMT.DataSource = khoiDH;
            }
            else {
                cblMT.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblMT.DataBind();

            //// load nganh Ngon ngu --
            string nganhNgonNgu = "52220201";
            cblNganhNN.DataSource = NganhServices.LoadNganh(nganhNgonNgu, nam);
            cblNganhNN.DataTextField = "TenNganh";
            cblNganhNN.DataValueField = "IDNganh";
            cblNganhNN.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhNgonNgu, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblNN.DataSource = khoiDH;
            }
            else {
                cblNN.DataSource = khoiTPHT;
            
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblNN.DataBind();


            //// load nganh Nong nghiep --
            string nganhNongNghiep = "52620101";
            cblNganhNongNghiep.DataSource = NganhServices.LoadNganh(nganhNongNghiep, nam);
            cblNganhNongNghiep.DataTextField = "TenNganh";
            cblNganhNongNghiep.DataValueField = "IDNganh";
            cblNganhNongNghiep.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhNongNghiep, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblNongNghiep.DataSource = khoiDH;
            }
            else
            {
                cblNongNghiep.DataSource = khoiTPHT;

            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblNongNghiep.DataBind();

            //// load nganh Quan tri --C340301
            string nganhQuanTri = "52340101";
            cblNganhQT.DataSource = NganhServices.LoadNganh(nganhQuanTri, nam);
            cblNganhQT.DataTextField = "TenNganh";
            cblNganhQT.DataValueField = "IDNganh";
            cblNganhQT.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhQuanTri, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblQT.DataSource = khoiDH;
            }
            else {
                cblQT.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblQT.DataBind();

            //// load nganh Quan tri --C340301

            nganhQuanTri = "C340301";
            cblNganhQTCD.DataSource = NganhServices.LoadNganh(nganhQuanTri, nam);
            cblNganhQTCD.DataTextField = "TenNganh";
            cblNganhQTCD.DataValueField = "IDNganh";
            cblNganhQTCD.DataBind();

            khoiTPHT.Clear();
            khoiDH.Clear();
            dtKhoi = NganhServices.LoadKhoiByNganh(nganhQuanTri, nam);

            for (int i = 0; i < dtKhoi.Rows.Count; i++)
            {
                if (dtKhoi.Rows[i]["MaKhoi"].ToString().Length > 3)
                {
                    khoiTPHT.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
                else
                {
                    khoiDH.Add(dtKhoi.Rows[i]["MaKhoi"].ToString());
                }
            }
            if (hinhthuc.Equals("THI ĐẠI HỌC"))
            {
                cblQTCD.DataSource = khoiDH;
            }
            else {
                cblQTCD.DataSource = khoiTPHT;
            }
            // cblCNTT.DataTextField = "MaKhoi";
            // cblCNTT.DataValueField = "MaKhoi";
            cblQTCD.DataBind();

        }
       
    }
   private string getMaNganh(string idNganh){
       return NganhServices.LoadByIDNganh(idNganh, nam).Rows[0]["MaNganh"].ToString();
}
  
    protected void btnTiep_Click(object sender, EventArgs e)
    {
        List<NganhXetTuyen> listNganh = new List<NganhXetTuyen>();
        List<string> listKhoi = new List<string>();
        NganhXetTuyen nganhxetuyen;
        //DH Cong Nghe thong tin
        foreach (ListItem item in cblCNTT.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhCNTT.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                   // nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //DH Dien
        listKhoi.Clear();
        foreach (ListItem item in cblDien.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhDien.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }


        //DH Van hoa
        listKhoi.Clear();
        foreach (ListItem item in cblVH.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhVH.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //DH Xay dung
        listKhoi.Clear();
        foreach (ListItem item in cblXD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhXD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //DH Moi truong
        listKhoi.Clear();
        foreach (ListItem item in cblMT.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhMT.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //DH Ngoai ngu
        listKhoi.Clear();
        foreach (ListItem item in cblNN.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhNN.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //DH Quan Tri
        listKhoi.Clear();
        foreach (ListItem item in cblQT.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhQT.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT,Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }
        //DH Nong Nghiep
        listKhoi.Clear();
        foreach (ListItem item in cblNongNghiep.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhNongNghiep.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //CD Cong Nghe thong tin
        listKhoi.Clear();
        foreach (ListItem item in cblCNTTCD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhCNTTCD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //CD Dien dien tu
        listKhoi.Clear();
        foreach (ListItem item in cblDienCD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhDienCD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                   //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }
        
        //CD Van hoa
        listKhoi.Clear();
        foreach (ListItem item in cblVHCD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhVHCD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                   // nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //CD Xay dung
        listKhoi.Clear();
        foreach (ListItem item in cblXDCD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhXDCD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                   // nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT,Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }


        //CD Quan Tri
        listKhoi.Clear();
        foreach (ListItem item in cblQTCD.Items)
        {
            if (item.Selected)
            {
                listKhoi.Add(item.Value);
            }
        }

        foreach (ListItem item in cblNganhQTCD.Items)
        {
            manganh = getMaNganh(item.Value);
            if (item.Selected)
            {
                for (int i = 0; i < listKhoi.Count; i++)
                {
                    //nganhxetuyen = new NganhXetTuyen(idHS, manganh, listKhoi[i], dotxetuyen, nam, item.Value);
                    nganhxetuyen = new NganhXetTuyen(idHS, item.Value, manganh, listKhoi[i], dotxetuyen, nam, diemUTKV, diemUTDT, Utilities.GetServerTime());
                    listNganh.Add(nganhxetuyen);
                }
            }
        }

        //Insert databse

        //Xoa Nhung nganh chua xet tuyen va chon lai nhung nganh khoi da xet tuyen
        List<NganhXetTuyen> listNganhDaXet = new List<NganhXetTuyen>();
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                long id = Convert.ToInt64(dtNganh.Rows[j]["IdHs"].ToString());
                string sMaNganh = dtNganh.Rows[j]["maNganh"].ToString();
                string sMaKhoi = dtNganh.Rows[j]["maKhoi"].ToString();
                int iNam = Convert.ToInt32(dtNganh.Rows[j]["Nam"].ToString());
                string sIdNganh = dtNganh.Rows[j]["IDNganh"].ToString();
                string sMaDot = dtNganh.Rows[j]["MaDot"].ToString();
                double dDiemTB= Convert.ToDouble(dtNganh.Rows[j]["DiemTB"].ToString());
                double dDiemUTKV= Convert.ToDouble(dtNganh.Rows[j]["DiemUTKV"].ToString());
                double dDiemUTDT= Convert.ToDouble(dtNganh.Rows[j]["DiemUTDT"].ToString());
                double dDiemTXT= Convert.ToDouble(dtNganh.Rows[j]["DiemTXT"].ToString());
                int iTrangThai= Convert.ToInt32(dtNganh.Rows[j]["TrangThai"].ToString());
                if (iTrangThai!=1) {

                    nganhxetuyen = new NganhXetTuyen(id, sIdNganh, sMaNganh, sMaKhoi, sMaDot, iNam, dDiemTB, dDiemUTKV, dDiemUTDT, dDiemTXT, iTrangThai, Utilities.GetServerTime());
                    if (listNganh.Count > 0)
                    {
                        for (int i = 0; i < listNganh.Count; i++)
                        {


                            if (listNganh[i] == nganhxetuyen)
                            {
                                NganhXetTuyenServices.Delete(id, sMaNganh, sMaKhoi, iNam, sIdNganh, sMaDot);
                            }
                            else
                            { // Truong hop khong duoc chọn xóa dựa theo mã khối và hình thức
                                if (hinhthuc.Equals("THI ĐẠI HỌC") && sMaKhoi.Length < 3)
                                {
                                    NganhXetTuyenServices.Delete(id, sMaNganh, sMaKhoi, iNam, sIdNganh, sMaDot);
                                }
                                if (hinhthuc.Equals("THPT") && sMaKhoi.Length > 3)
                                {
                                    NganhXetTuyenServices.Delete(id, sMaNganh, sMaKhoi, iNam, sIdNganh, sMaDot);
                                }
                            }
                                

                           

                        }
                    }
                                      
                                      
                }else{
                    nganhxetuyen = new NganhXetTuyen(id, sIdNganh, sMaNganh, sMaKhoi, sMaDot, iNam, dDiemTB, dDiemUTKV, dDiemUTDT, dDiemTXT, iTrangThai, Utilities.GetServerTime());
                    listNganhDaXet.Add(nganhxetuyen);
            }
            }
        }

        if (listNganh.Count > 0)
        {
            for (int i = 0; i < listNganh.Count; i++)
            {
                if (listNganhDaXet.Count > 0)
                {
                    for (int j = 0; j < listNganhDaXet.Count; j++)
                    {
                        if (listNganh[i] == listNganhDaXet[j])
                        {
                            listNganh.RemoveAt(i);
                        }
                        
                    }

                }
                
            }
        }


        int dem = 0;
        if (listNganh.Count > 0)
        {
            for (int i = 0; i < listNganh.Count; i++)
            {
                
                  NganhXetTuyenServices.Insert(listNganh[i]);
                    dem += 1;
                
                // Response.Write(listNganh[i].Idhs + " - " +listNganh[i].MaNganh + "-"+ listNganh[i].MaKhoi );
                //dem += 1;
            }
        }
        HoSo objHoso = new HoSo();
        
        objHoso = (HoSo)Session["objHoSo"];
        objHoso.Buoc = 2;
        HoSoServices.Update(objHoso);

        if (Session["HinhThuc"].ToString() == "THPT")
        {
            Response.Redirect(ResolveUrl("~/Setp2THPT.html"));
        }else
            if (Session["HinhThuc"].ToString() == "THI ĐẠI HỌC")
            {
                Response.Redirect(ResolveUrl("~/Setp2DH.html"));
        }

    }

    protected void cblCNTT_DataBinding(object sender, EventArgs e)
    {
        foreach (ListItem li in cblCNTTCD.Items)
        {
            if (li.Value.Equals(sKhoiDT))
            {
                li.Selected = true;
            }
            else
            {

            }
        }
    }
    protected void cblCNTT_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblCNTT.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblCNTT.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblCNTT.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblCNTT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblCNTT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblCNTT.Items.Count; i++)
        {
            if (cblCNTT.Items[i].Value.Trim().Length > 3)
            {

                cblCNTT.Items[i].Text = cblCNTT.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count;j++ )
            {
                for (int i = 0; i < cblCNTT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblCNTT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString()=="D480201")
                    {

                        cblCNTT.Items[i].Selected = true;
                       if( dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                        cblCNTT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblDien_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblDien.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblDien.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblDien.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblDien.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblDien.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblDien.Items.Count; i++)
        {
            if (cblDien.Items[i].Value.Trim().Length > 3)
            {

                cblDien.Items[i].Text = cblDien.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblDien.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblDien.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D510301")
                    {

                        cblDien.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblDien.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblVH_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblVH.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblVH.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblVH.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblVH.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblVH.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblVH.Items.Count; i++)
        {
            if (cblVH.Items[i].Value.Trim().Length > 3)
            {

                cblVH.Items[i].Text = cblVH.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblVH.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblVH.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D220113")
                    {

                        cblVH.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblVH.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblXD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblXD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblXD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblXD.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblXD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblXD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }

        for (int i = 0; i < cblXD.Items.Count; i++)
        {
            if (cblXD.Items[i].Value.Trim().Length > 3)
            {

                cblXD.Items[i].Text = cblXD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblXD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblXD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D580201")
                    {

                        cblXD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblXD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblMT_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblMT.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblMT.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblMT.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblMT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblMT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblMT.Items.Count; i++)
        {
            if (cblMT.Items[i].Value.Trim().Length > 3)
            {

                cblMT.Items[i].Text = cblMT.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblMT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblMT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D520320")
                    {

                        cblMT.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblMT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNN_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblNN.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblNN.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblNN.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            
            //  cblCNTT.Items[0].Enabled = false;
            cblNN.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblNN.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblNN.Items.Count; i++)
        {
            if (cblNN.Items[i].Value.Trim().Length>3)
            {

                cblNN.Items[i].Text = cblNN.Items[i].Value.Trim().Remove(0, 5) ;
            }
        }

        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNN.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNN.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D220201")
                    {

                        cblNN.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNN.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }

    }
    protected void cblQT_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblQT.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblQT.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblQT.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblQT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblQT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblQT.Items.Count; i++)
        {
            if (cblQT.Items[i].Value.Trim().Length > 3)
            {

                cblQT.Items[i].Text = cblQT.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblQT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblQT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D340101")
                    {

                        cblQT.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblQT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblCNTTCD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblCNTTCD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblCNTTCD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblCNTTCD.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblCNTTCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblCNTTCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }

        for (int i = 0; i < cblCNTTCD.Items.Count; i++)
        {
            if (cblCNTTCD.Items[i].Value.Trim().Length > 3)
            {

                cblCNTTCD.Items[i].Text = cblCNTTCD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblCNTTCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblCNTTCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "C480201")
                    {

                        cblCNTTCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblCNTTCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblDienCD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblDienCD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblDienCD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblDienCD.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblDienCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblDienCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblDienCD.Items.Count; i++)
        {
            if (cblDienCD.Items[i].Value.Trim().Length > 3)
            {

                cblDienCD.Items[i].Text = cblDienCD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblDienCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblDienCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "C510301")
                    {

                        cblDienCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblDienCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblVHCD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblVHCD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblVHCD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblVHCD.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblVHCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblVHCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblVHCD.Items.Count; i++)
        {
            if (cblVHCD.Items[i].Value.Trim().Length > 3)
            {

                cblVHCD.Items[i].Text = cblVHCD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblVHCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblVHCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "C220113")
                    {

                        cblVHCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblVHCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblXDCD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblXDCD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblXDCD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblXDCD.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblXDCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblXDCD.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblXDCD.Items.Count; i++)
        {
            if (cblXDCD.Items[i].Value.Trim().Length > 3)
            {

                cblXDCD.Items[i].Text = cblXDCD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblXDCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblXDCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "C510102")
                    {

                        cblXDCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblXDCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblQTCD_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblQTCD.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblQTCD.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblQTCD.Items[i].Enabled = false;
                }
                //else{

                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblCNTT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ"; 
        }
        else { cblCNTT.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblQTCD.Items.Count; i++)
        {
            if (cblQTCD.Items[i].Value.Trim().Length > 3)
            {

                cblQTCD.Items[i].Text = cblQTCD.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblQTCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblQTCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "C340301")
                    {

                        cblQTCD.Items[i].Selected = true;
                        
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblQTCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhCNTT_DataBound(object sender, EventArgs e)
    {
        //if (Session["HinhThuc"].ToString() == "CẬP NHẬT")
        //{
        //    for (int i = 0; i < cblNganhCNTT.Items.Count; i++)
        //    {
        //        for (int j = 0; j < dtNganh.Rows.Count; j++)
        //        {
        //            //Response.Write(cblCNTT.Items[i].Value);
        //            if (cblNganhCNTT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["idNganh"]))
        //            {

        //               //cblNganhCNTT.Items[i].Selected=true;
                      
                       
        //            }
        //            //else{
        //            //    cblCNTT.Items[i].Enabled = false; 
        //            //}
        //        }
        //    }
           
        //}
        
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhCNTT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhCNTT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhCNTT.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhCNTT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhDien_DataBound(object sender, EventArgs e)
    {
        //if (Session["HinhThuc"].ToString() == "CẬP NHẬT")
        //{
        //    for (int i = 0; i < cblNganhDien.Items.Count; i++)
        //    {
        //        for (int j = 0; j < dtNganh.Rows.Count; j++)
        //        {
        //            //Response.Write(cblCNTT.Items[i].Value);
        //            if (cblNganhDien.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["idNganh"]))
        //            {

        //                cblNganhDien.Items[i].Selected = true;
        //            }
        //            //else{
        //            //    cblCNTT.Items[i].Enabled = false; 
        //            //}
        //        }
        //    }

        //}


        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhDien.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhDien.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhDien.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhDien.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhVH_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhVH.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhVH.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhVH.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhVH.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhXD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhXD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhXD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhXD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhXD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhMT_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhMT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhMT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhMT.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhMT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhNN_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhNN.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhNN.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhNN.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhNN.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhQT_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhQT.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhQT.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhQT.Items[i].Selected = true;
                        
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhQT.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhCNTTCD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhCNTTCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhCNTTCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhCNTTCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhCNTTCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }

    }
    protected void cblNganhDienCD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhDienCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhDienCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhDienCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhDienCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }

    }
    protected void cblNganhVHCD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhVHCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhVHCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhVHCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhVHCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhXDCD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhXDCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhXDCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhXDCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhXDCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhQTCD_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhQTCD.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhQTCD.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhQTCD.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhQTCD.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNongNghiep_DataBound(object sender, EventArgs e)
    {
        if (hinhthuc.Equals("THI ĐẠI HỌC"))
        {

            for (int i = 0; i < cblNongNghiep.Items.Count; i++)
            {
                //Response.Write(cblCNTT.Items[i].Value);
                if (!cblNongNghiep.Items[i].Value.Trim().Equals(sKhoiDT))
                {

                    cblNongNghiep.Items[i].Enabled = false;
                }
                //else{
                //    cblCNTT.Items[i].Enabled = false; 
                //}
            }
            //  cblCNTT.Items[0].Enabled = false;
            cblNongNghiep.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ";
        }
        else { cblNongNghiep.ToolTip = "A: TOÁN - LÝ - HÓA\nA1: TOÁN - LÝ - ANH\nB: TOÁN - HÓA - SINH\nC: VĂN - SỬ - ĐỊA\nD: TOÁN - VĂN - NGOẠI NGỮ\nD1: TOÁN - VĂN - ANH\nV: TOÁN - LÝ - VẼ\nTH1: TOÁN - ANH HÓA\nTH2: TOÁN - ANH - SINH\nTH3: TOÁN - LÝ - ĐỊA\nTH4: TOÁN - LÝ - SINH\nTH5: VĂN - SỬ - ĐỊA\nTH6: VĂN - ĐỊA - ANH"; }
        for (int i = 0; i < cblNongNghiep.Items.Count; i++)
        {
            if (cblNongNghiep.Items[i].Value.Trim().Length > 3)
            {

                cblNongNghiep.Items[i].Text = cblNongNghiep.Items[i].Value.Trim().Remove(0, 5);
            }
        }
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNongNghiep.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNongNghiep.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["MaKhoi"].ToString()) && dtNganh.Rows[j]["MaNganh"].ToString() == "D620101")
                    {

                        cblNongNghiep.Items[i].Selected = true;
                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNongNghiep.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
    protected void cblNganhNongNghiep_DataBound(object sender, EventArgs e)
    {
        //Load
        if (dtNganh.Rows.Count > 0)
        {
            for (int j = 0; j < dtNganh.Rows.Count; j++)
            {
                for (int i = 0; i < cblNganhNongNghiep.Items.Count; i++)
                {
                    //Response.Write(cblCNTT.Items[i].Value);
                    if (cblNganhNongNghiep.Items[i].Value.Trim().Equals(dtNganh.Rows[j]["IDNganh"].ToString()))
                    {

                        cblNganhNongNghiep.Items[i].Selected = true;

                        if (dtNganh.Rows[j]["TrangThai"].ToString() == "1")
                            cblNganhNongNghiep.Items[i].Enabled = false;
                    }
                    //else{
                    //    cblCNTT.Items[i].Enabled = false; 
                    //}
                }
            }
        }
    }
}
