using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;


namespace Business
{
    public class HoSoServices
    {
        public HoSoServices() 
         { }
        public static bool Insert(HoSo HoSo)
        {
            HoSoADO HoSoADO = new HoSoADO();
            
            return HoSoADO.Insert(HoSo);
        }
        public static Boolean Update(HoSo HoSo)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.Update(HoSo);
        }
        public static Boolean UpdateDienTB(long  idHS)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.UpdateDiemTB(idHS);
        }
        public static Boolean UpdateDienTB(long idHS,int heSo)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.UpdateDiemTB(idHS,heSo);
        }
        public static bool Delete(Int64 idHS)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.Delete(idHS);
        }
        public static DataTable LoadByPrimaryKey(long idHS)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadByPrimaryKey(idHS);
        }
        public static DataTable LoadByPrimaryKey(string sSoCMTND,int Nam)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadBySoCMTND(sSoCMTND,Nam);
        }
        public static DataTable LoadByCMAndPhone(string sSoCMTND, string dienThoai, int Nam)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadBySoCMAndPhone(sSoCMTND,dienThoai, Nam);
        }
        public static int CheckHoSo(Int64 idHS)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.CheckHoSo(idHS);
        }
        public static DataTable LoadByPrimaryKey(string sSoCMTND,string sSoBD, int nam)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadBySoCMTND_SoBD(sSoCMTND,sSoBD,nam);
        }
        public static HoSo GetObjectHoSo(DataRowCollection row)
        {

            HoSo objHoSo = new HoSo();
        
            objHoSo.DangXetTuyen = Convert.ToBoolean(row[0]["dangXetTuyen"].ToString());
            objHoSo.DanToc =  row[0]["danToc"].ToString();
            objHoSo.DiaChi = row[0]["diaChi"].ToString();
            objHoSo.DienThoai = row[0]["dienThoai"].ToString();
            objHoSo.Email =  row[0]["email"].ToString();
            objHoSo.GiayTotNghiep =  Convert.ToBoolean(row[0]["giayTotNghiep"].ToString());
            objHoSo.GioiTinh = row[0]["GioiTinh"].ToString();
            objHoSo.HanhKiem = row[0]["hanhKiem"].ToString();
            objHoSo.HeXetTuyen = Convert.ToByte(row[0]["heXetTuyen"].ToString());
            objHoSo.HinhThuc =Convert.ToByte(row[0]["hinhThuc"].ToString());
            objHoSo.HocBa = Convert.ToBoolean(row[0]["hocBa"].ToString());
            objHoSo.HoKhau =   row[0]["hoKhau"].ToString();
            objHoSo.HoTen = row[0]["hoTen"].ToString();
            objHoSo.Idhs = Convert.ToInt64(row[0]["idhs"].ToString());
            objHoSo.KhoiDT =  row[0]["khoiDT"].ToString();
            objHoSo.LienThong =  Convert.ToBoolean(row[0]["lienThong"].ToString());
            objHoSo.LoaiHocBa = row[0]["loaiHocBa"].ToString();
            objHoSo.Lop10 =  row[0]["lop10"].ToString();
            objHoSo.Lop10MaTinh =  row[0]["lop10MaTinh"].ToString();
            objHoSo.Lop10MaTruong =  row[0]["lop10MaTruong"].ToString();
            objHoSo.Lop11 =  row[0]["lop11"].ToString();
            objHoSo.Lop11MaTinh =  row[0]["lop11MaTinh"].ToString();
            objHoSo.Lop11MaTruong =  row[0]["lop11MaTruong"].ToString();
            objHoSo.Lop12 =  row[0]["lop12"].ToString();
            objHoSo.Lop12MaTinh =  row[0]["lop12MaTinh"].ToString();
            objHoSo.Lop12MaTruong =  row[0]["lop12MaTruong"].ToString();
            objHoSo.MaDT =  row[0]["maDT"].ToString();
            objHoSo.MaHuyen = row[0]["maHuyen"].ToString();
            objHoSo.MaKV =    row[0]["maKV"].ToString();
            objHoSo.MaTinh = row[0]["maTinh"].ToString();
            objHoSo.Buoc=Convert.ToInt32(row[0]["Buoc"].ToString());
            objHoSo.Nam = Convert.ToInt32(row[0]["nam"].ToString());
            objHoSo.NamTotNghiep =  Convert.ToInt32(row[0]["namTotNghiep"].ToString());
            objHoSo.NgayNhap =  Convert.ToDateTime(row[0]["ngayNhap"].ToString());
            objHoSo.NgaySinh = Convert.ToDateTime(row[0]["ngaySinh"].ToString());
            objHoSo.NgaySua =  Convert.ToDateTime(row[0]["ngaySua"].ToString());
            objHoSo.NguoiNhap = row[0]["nguoiNhap"].ToString();
            objHoSo.NguoiSua = row[0]["nguoiSua"].ToString();
            objHoSo.NopLePhi = Convert.ToBoolean(row[0]["nopLePhi"].ToString());
            objHoSo.Online =  Convert.ToBoolean(row[0]["online"].ToString());
            objHoSo.SoBaoDanh = row[0]["soBaoDanh"].ToString();
            objHoSo.SoCMTND = row[0]["soCMTND"].ToString();
            objHoSo.TotNghiep =   row[0]["totNghiep"].ToString();
            objHoSo.TruongDT = row[0]["truongDT"].ToString();
            objHoSo.MaHS = row[0]["MaHS"].ToString();
            objHoSo.KetQua =Convert.ToByte(row[0]["KetQua"].ToString());;
            return objHoSo;
        }
        public static HoSo GetObjectHoSoBykey(long idHS)
        {
            DataTable dt = LoadByPrimaryKey(idHS);
            if (dt.Rows.Count > 0)
            return (GetObjectHoSo(dt.Rows));
            return null;
        
        }
        public static HoSo GetObjectHoSoBySoCMTND_soBD(string sSoCMTND, string sSoBD,int nam)
        {
            DataTable dt = LoadByPrimaryKey(sSoCMTND, sSoBD,nam);

            return (GetObjectHoSo(dt.Rows));

        }
        public static HoSo GetObjectHoSoBySoCMTND(string sSoCMTND, int Nam)
        {
            DataTable dt = LoadByPrimaryKey(sSoCMTND,Nam);
            if(dt.Rows.Count>0)
            return (GetObjectHoSo(dt.Rows));
            return null;

        }
        public static HoSo GetObjectHoSoBySoCMTNDAndPhone(string sSoCMTND,string dienThoai, int Nam)
        {
            DataTable dt = LoadByCMAndPhone(sSoCMTND,dienThoai, Nam);
            if (dt.Rows.Count > 0)
                return (GetObjectHoSo(dt.Rows));
            return null;

        }
        public static DataTable LoadBySoBD(string sSoBD)
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadBySoBD(sSoBD);
        }
        public static DataTable LoaAll()
        {
            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.LoadAll();
        }
      
        public static DataTable FindHoSo(string sql)
        {

            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.FinHoSo(sql);
        }
        public static string GetSoBaoDanh(int Nam, string Matruong, int len)
        {

            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.GetSoBaoDanh(Nam,Matruong,len);
        }
        public static string GetSoBaoDanhRandom(int Nam, string Matruong, int len)
        {

            HoSoADO HoSoADO = new HoSoADO();
            return HoSoADO.GetSoBaoDanhRandom(Nam, Matruong, len);
        }
    }
}
