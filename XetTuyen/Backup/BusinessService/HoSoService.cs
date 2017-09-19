using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using DataAccess;
using Common;

namespace BusinessService
{
    [Authorization]
    public class HoSoService
    {
        private DataTable dataTable ;

        public HoSoService()
        {
        }

        public enum HoSoAction { Insert, Update, Delete,PrintGiayBao, XetTuyenHS}
        public bool IsAuthorized(HoSoAction action)
        {
            string sMethodName = string.Empty;
            switch (action)
            {
                case HoSoAction.Insert:
                    sMethodName = "Insert";
                    break;
                case HoSoAction.Update:
                    sMethodName = "Update";
                    break;
                case HoSoAction.Delete:
                    sMethodName = "Delete";
                    break;
                    case HoSoAction.PrintGiayBao:
                    sMethodName = "PrintGiayBao";
                    break;
                    case HoSoAction.XetTuyenHS:
                    sMethodName = "XetTuyenHS";
                    break;
                //case GroupAction.MultilangUI:
                //    sMethodName = "MultilangUI";
                //    break;
                //case GroupAction.MultilangData:
                //    sMethodName = "MultilangData";
                //    break;
            }

            return SecurityManager.IsAuthorized(typeof(HoSoService).GetMethod(sMethodName));
        }

        [MethodDescription(ModuleType.Catalogue, FormName.HoSo, FunctionName.Cat_AddHoSo)]
        public bool Insert(HoSo HoSo)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(HoSo));


                db.ExecuteNonQuery("proc_t_HoSoInsert");


                return true;
            }
            catch
            {

                return false;
            }

        }
        [MethodDescription(ModuleType.Catalogue, FormName.HoSo, FunctionName.Cat_EditHoSo)]
        public bool Update(HoSo HoSo)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(HoSo));


                db.ExecuteNonQuery("proc_t_HoSoUpdate");


                return true;
            }
            catch
            {

                return false;
            }

        }
         [MethodDescription(ModuleType.Statistic, FormName.InGiayBao, FunctionName.Stat_InGiayBao)]
        public bool  PrintGiayBao()
        {
            return true;
        }

        public bool UpdateDiemTB(long idHS)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.IDHS;
                p.Value = idHS;
                db.AddParameter(p);


                db.ExecuteNonQuery("proc_t_HoSoUpdateDiemByIdHS");


                return true;
            }
            catch
            {

                return false;
            }


        }
        public bool UpdateDiemTB(long idHS,int heso)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.IDHS;
                p.Value = idHS;
                db.AddParameter(p);

                p = new SqlParameter("@HeSo", SqlDbType.TinyInt, 0);
                p.Value = heso;
                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_HoSoUpdateDiemByIdHS");


                return true;
            }
            catch
            {

                return false;
            }


        }

        [MethodDescription(ModuleType.Catalogue, FormName.HoSo, FunctionName.Cat_DeleteHoSo)]
        public bool Delete(long idHS)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.IDHS;
                p.Value = idHS;
                db.AddParameter(p);

               
                db.ExecuteNonQuery("proc_t_HoSoDelete");


                return true;
            }
            catch
            {

                return false;
            }

        }



        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_HoSoLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        public DataTable FinHoSo(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
          
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(Int64 idHS)
        {
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable.Rows.Clear();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public int CheckHoSo(Int64 idHS) {
            int i = 0;
            DataTable dt = LoadByPrimaryKey(idHS);
           if(dt.Rows.Count>=0){
               i = Convert.ToInt32( dt.Rows[0]["KetQua"].ToString());
           }
            return i;
        }
        public DataTable LoadBySoCMTND(string sSoCMTND)
        {
          

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoCMTND]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = sSoCMTND;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoBD(string sSoBD)
        {
          

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoBD]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoBaoDanh);
            p.Value = sSoBD;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        /// <summary>
        ///GetHoSoByID
        /// </summary>
        /// <param name="MaDot"></param>
        /// <returns>HoSo object class</returns>
        public HoSo GetHoSoBySoCMTND_SoBD(string sSoCMTND, string sSoBD, int nam)
        {
            HoSo objHoSo = new HoSo();
            objHoSo.Idhs = -1;
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.SoCMTND;
            p.Value = sSoCMTND;
            db.AddParameter(p);

            p = Parameters.SoBaoDanh;
            p.Value = sSoBD;
            db.AddParameter(p);

            p = Parameters.Nam;
            p.Value = nam;
            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_HoSoLoadBySoCMTND_SoBD");
            if (reader.Read())
            {
                

                objHoSo.DangXetTuyen = (bool)reader["DangXetTuyen"];
                objHoSo.DanToc = reader["DanToc"].ToString();
                objHoSo.DiaChi = reader["DiaChi"].ToString();
                objHoSo.DienThoai = reader["DienThoai"].ToString();
                objHoSo.Email = reader["Email"].ToString();
                objHoSo.GiayTotNghiep = (bool)reader["GiayTotNghiep"];
                objHoSo.GioiTinh = reader["GioiTinh"].ToString();
                objHoSo.HanhKiem = reader["HanhKiem"].ToString();
                objHoSo.HeXetTuyen = (byte)reader["HeXetTuyen"];
                objHoSo.HinhThuc = (byte)reader["HinhThuc"];
                objHoSo.HocBa = (bool)reader["HocBa"];
                objHoSo.HoKhau = reader["HoKhau"].ToString();
                objHoSo.HoTen = reader["HoTen"].ToString();
                objHoSo.Idhs = (long)reader["Idhs"];
                objHoSo.KhoiDT = reader["KhoiDT"].ToString();
                objHoSo.LienThong = (bool)reader["LienThong"];
                objHoSo.LoaiHocBa = reader["Idhs"].ToString();
                objHoSo.Lop10 = reader["Lop10"].ToString();
                objHoSo.Lop10MaTinh = reader["Lop10MaTinh"].ToString();
                objHoSo.Lop10MaTruong = reader["Lop10MaTruong"].ToString();
                objHoSo.Lop11 = reader["Lop11"].ToString();
                objHoSo.Lop11MaTinh = reader["Lop11MaTinh"].ToString();
                objHoSo.Lop11MaTruong = reader["Lop11MaTruong"].ToString();
                objHoSo.Lop12 = reader["Lop12"].ToString();
                objHoSo.Lop12MaTinh = reader["Lop12MaTinh"].ToString();
                objHoSo.Lop12MaTruong = reader["Lop12MaTruong"].ToString();
                objHoSo.MaDT = reader["MaDT"].ToString();
                objHoSo.MaHuyen = reader["MaHuyen"].ToString();
                objHoSo.MaKV = reader["MaKV"].ToString();
                objHoSo.MaTinh = reader["MaTinh"].ToString();
                objHoSo.Nam = (int)reader["Nam"];
                objHoSo.NamTotNghiep = (int)reader["NamTotNghiep"];
                objHoSo.NgayNhap = (DateTime)reader["NgayNhap"];
                objHoSo.NgaySinh = (DateTime)reader["NgaySinh"];
                objHoSo.NgaySua = (DateTime)reader["NgaySua"];
                objHoSo.NguoiNhap = reader["NguoiNhap"].ToString();
                objHoSo.NguoiSua = reader["NguoiSua"].ToString();
                objHoSo.NopLePhi = (bool)reader["NopLePhi"];
                objHoSo.Online = (bool)reader["Online"];
                objHoSo.SoBaoDanh = reader["SoBaoDanh"].ToString();
                objHoSo.SoCMTND = reader["SoCMTND"].ToString();
                objHoSo.TotNghiep = reader["TotNghiep"].ToString();
                objHoSo.TruongDT = reader["TruongDT"].ToString();



            }

            //Call Close when done reading.
            reader.Close();

            return objHoSo;
        }

        /// <summary>
        ///GetHoSoByMaHS
        /// </summary>
        /// <param name="MaDot"></param>
        /// <returns>HoSo object class</returns>
        public HoSo GetHoSoByMaHS(string MaHS)
        {
            HoSo objHoSo = new HoSo();
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
          

            p = Parameters.MaHS;
            p.Value = MaHS;

            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_HoSoLoadByMaHS");
            if (reader.Read())
            {


                objHoSo.DangXetTuyen = (bool)reader["DangXetTuyen"];
                objHoSo.DanToc = reader["DanToc"].ToString();
                objHoSo.DiaChi = reader["DiaChi"].ToString();
                objHoSo.DienThoai = reader["DienThoai"].ToString();
                objHoSo.Email = reader["Email"].ToString();
                objHoSo.GiayTotNghiep = (bool)reader["GiayTotNghiep"];
                objHoSo.GioiTinh = reader["GioiTinh"].ToString();
                objHoSo.HanhKiem = reader["HanhKiem"].ToString();
                objHoSo.HeXetTuyen = (byte)reader["HeXetTuyen"];
                objHoSo.HinhThuc = (byte)reader["HinhThuc"];
                objHoSo.HocBa = (bool)reader["HocBa"];
                objHoSo.HoKhau = reader["HoKhau"].ToString();
                objHoSo.HoTen = reader["HoTen"].ToString();
                objHoSo.Idhs = (long)reader["Idhs"];
                objHoSo.KhoiDT = reader["KhoiDT"].ToString();
                objHoSo.LienThong = (bool)reader["LienThong"];
                objHoSo.LoaiHocBa = reader["Idhs"].ToString();
                objHoSo.Lop10 = reader["Lop10"].ToString();
                objHoSo.Lop10MaTinh = reader["Lop10MaTinh"].ToString();
                objHoSo.Lop10MaTruong = reader["Lop10MaTruong"].ToString();
                objHoSo.Lop11 = reader["Lop11"].ToString();
                objHoSo.Lop11MaTinh = reader["Lop11MaTinh"].ToString();
                objHoSo.Lop11MaTruong = reader["Lop11MaTruong"].ToString();
                objHoSo.Lop12 = reader["Lop12"].ToString();
                objHoSo.Lop12MaTinh = reader["Lop12MaTinh"].ToString();
                objHoSo.Lop12MaTruong = reader["Lop12MaTruong"].ToString();
                objHoSo.MaDT = reader["MaDT"].ToString();
                objHoSo.MaHuyen = reader["MaHuyen"].ToString();
                objHoSo.MaKV = reader["MaKV"].ToString();
                objHoSo.MaTinh = reader["MaTinh"].ToString();
                objHoSo.Nam = (int)reader["Nam"];
                objHoSo.NamTotNghiep = (int)reader["NamTotNghiep"];
                objHoSo.NgayNhap = (DateTime)reader["NgayNhap"];
                objHoSo.NgaySinh = (DateTime)reader["NgaySinh"];
                objHoSo.NgaySua = (DateTime)reader["NgaySua"];
                objHoSo.NguoiNhap = reader["NguoiNhap"].ToString();
                objHoSo.NguoiSua = reader["NguoiSua"].ToString();
                objHoSo.NopLePhi = (bool)reader["NopLePhi"];
                objHoSo.Online = (bool)reader["Online"];
                objHoSo.SoBaoDanh = reader["SoBaoDanh"].ToString();
                objHoSo.SoCMTND = reader["SoCMTND"].ToString();
                objHoSo.TotNghiep = reader["TotNghiep"].ToString();
                objHoSo.TruongDT = reader["TruongDT"].ToString();
                objHoSo.MaHS = reader["MaHS"].ToString();


            }

            //Call Close when done reading.
            reader.Close();

            return objHoSo;
        }
         public DataTable LoadMonInHoSo(long idHS, int nam)
        {
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_LoadMonHoso]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoCMTND_SoBD(string sSoCMTND, string sSoBD)
        {
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoCMTND_SoBD]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = sSoCMTND;
            p = cmd.Parameters.Add(Parameters.SoBaoDanh);
            p.Value = sSoBD;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }


        /// <summary>
        /// GetListHoSo
        /// </summary>
        /// <returns>HoSoCollection</returns>
        public HoSoCollection GetListHoSo()
        {
            HoSoCollection hoSoCollection = new HoSoCollection();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_HoSoLoadAll");

            while (reader.Read())
            {
                HoSo objHoSo= new HoSo();
                objHoSo.DangXetTuyen = (bool)reader["DangXetTuyen"];
                objHoSo.DanToc = reader["DanToc"].ToString();
                objHoSo.DiaChi = reader["DiaChi"].ToString();
                objHoSo.DienThoai = reader["DienThoai"].ToString();
                objHoSo.Email = reader["Email"].ToString();
                objHoSo.GiayTotNghiep =(bool) reader["GiayTotNghiep"];
                objHoSo.GioiTinh = reader["GioiTinh"].ToString();
                objHoSo.HanhKiem = reader["HanhKiem"].ToString();
                objHoSo.HeXetTuyen =(byte) reader["HeXetTuyen"];
                objHoSo.HinhThuc = (byte)reader["HinhThuc"];
                objHoSo.HocBa = (bool)reader["HocBa"];
                objHoSo.HoKhau = reader["HoKhau"].ToString();
                objHoSo.HoTen = reader["HoTen"].ToString();
                objHoSo.Idhs = (long)reader["Idhs"];
                objHoSo.KhoiDT = reader["KhoiDT"].ToString();
                objHoSo.LienThong = (bool)reader["LienThong"];
                objHoSo.LoaiHocBa = reader["LoaiHocBa"].ToString();
                objHoSo.Lop10 = reader["Lop10"].ToString();
                objHoSo.Lop10MaTinh = reader["Lop10MaTinh"].ToString();
                objHoSo.Lop10MaTruong = reader["Lop10MaTruong"].ToString();
                objHoSo.Lop11 = reader["Lop11"].ToString();
                objHoSo.Lop11MaTinh = reader["Lop11MaTinh"].ToString();
                objHoSo.Lop11MaTruong = reader["Lop11MaTruong"].ToString();
                objHoSo.Lop12 = reader["Lop12"].ToString();
                objHoSo.Lop12MaTinh = reader["Lop12MaTinh"].ToString();
                objHoSo.Lop12MaTruong = reader["Lop12MaTruong"].ToString();
                objHoSo.MaDT = reader["MaDT"].ToString();
                objHoSo.MaHuyen = reader["MaHuyen"].ToString();
                objHoSo.MaKV = reader["MaKV"].ToString();
                objHoSo.MaTinh = reader["MaTinh"].ToString();
                objHoSo.Nam = (int)reader["Nam"];
                objHoSo.NamTotNghiep = (int)reader["NamTotNghiep"];
                objHoSo.NgayNhap = (DateTime)reader["NgayNhap"];
                objHoSo.NgaySinh = (DateTime)reader["NgaySinh"];
                objHoSo.NgaySua = (DateTime)reader["NgaySua"];
                objHoSo.NguoiNhap = reader["NguoiNhap"].ToString();
                objHoSo.NguoiSua = reader["NguoiSua"].ToString();
                objHoSo.NopLePhi = (bool)reader["NopLePhi"];
                objHoSo.Online = (bool)reader["Online"];
                objHoSo.SoBaoDanh = reader["SoBaoDanh"].ToString();
                objHoSo.SoCMTND = reader["SoCMTND"].ToString();
                objHoSo.TotNghiep = reader["TotNghiep"].ToString();
                objHoSo.TruongDT = reader["TruongDT"].ToString();
                objHoSo.MaHS = reader["MaHS"].ToString();
                objHoSo.KetQua = (byte)reader["KetQua"];

                hoSoCollection.Add(objHoSo);
            }

            //Call Close when done reading.
            reader.Close();

            return hoSoCollection;
        }


        /// <summary>
        /// Find list HoSo
        /// </summary>
        /// <returns>HoSoCollection</returns>
        public HoSoCollection FindListHoSo(string sql)
        {
            HoSoCollection hoSoCollection = new HoSoCollection();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommandText();
            SqlDataReader reader = db.ExecuteReader(sql);

            while (reader.Read())
            {
                HoSo objHoSo = new HoSo();
                objHoSo.DangXetTuyen = (bool)reader["DangXetTuyen"];
                objHoSo.DanToc = reader["DanToc"].ToString();
                objHoSo.DiaChi = reader["DiaChi"].ToString();
                objHoSo.DienThoai = reader["DienThoai"].ToString();
                objHoSo.Email = reader["Email"].ToString();
                objHoSo.GiayTotNghiep = (bool)reader["GiayTotNghiep"];
                objHoSo.GioiTinh = reader["GioiTinh"].ToString();
                objHoSo.HanhKiem = reader["HanhKiem"].ToString();
                objHoSo.HeXetTuyen = (byte)reader["HeXetTuyen"];
                objHoSo.HinhThuc = (byte)reader["HinhThuc"];
                objHoSo.HocBa = (bool)reader["HocBa"];
                objHoSo.HoKhau = reader["HoKhau"].ToString();
                objHoSo.HoTen = reader["HoTen"].ToString();
                objHoSo.Idhs = (long)reader["Idhs"];
                objHoSo.KhoiDT = reader["KhoiDT"].ToString();
                objHoSo.LienThong = (bool)reader["LienThong"];
                objHoSo.LoaiHocBa = reader["LoaiHocBa"].ToString();
                objHoSo.Lop10 = reader["Lop10"].ToString();
                objHoSo.Lop10MaTinh = reader["Lop10MaTinh"].ToString();
                objHoSo.Lop10MaTruong = reader["Lop10MaTruong"].ToString();
                objHoSo.Lop11 = reader["Lop11"].ToString();
                objHoSo.Lop11MaTinh = reader["Lop11MaTinh"].ToString();
                objHoSo.Lop11MaTruong = reader["Lop11MaTruong"].ToString();
                objHoSo.Lop12 = reader["Lop12"].ToString();
                objHoSo.Lop12MaTinh = reader["Lop12MaTinh"].ToString();
                objHoSo.Lop12MaTruong = reader["Lop12MaTruong"].ToString();
                objHoSo.MaDT = reader["MaDT"].ToString();
                objHoSo.MaHuyen = reader["MaHuyen"].ToString();
                objHoSo.MaKV = reader["MaKV"].ToString();
                objHoSo.MaTinh = reader["MaTinh"].ToString();
                objHoSo.Nam = (int)reader["Nam"];
                objHoSo.NamTotNghiep = (int)reader["NamTotNghiep"];
                objHoSo.NgayNhap = (DateTime)reader["NgayNhap"];
                objHoSo.NgaySinh = (DateTime)reader["NgaySinh"];
                objHoSo.NgaySua = (DateTime)reader["NgaySua"];
                objHoSo.NguoiNhap = reader["NguoiNhap"].ToString();
                objHoSo.NguoiSua = reader["NguoiSua"].ToString();
                objHoSo.NopLePhi = (bool)reader["NopLePhi"];
                objHoSo.Online = (bool)reader["Online"];
                objHoSo.SoBaoDanh = reader["SoBaoDanh"].ToString();
                objHoSo.SoCMTND = reader["SoCMTND"].ToString();
                objHoSo.TotNghiep = reader["TotNghiep"].ToString();
                objHoSo.TruongDT = reader["TruongDT"].ToString();
                objHoSo.MaHS = reader["MaHS"].ToString();
                objHoSo.KetQua = (byte)reader["KetQua"];

                hoSoCollection.Add(objHoSo);
            }

            //Call Close when done reading.
            reader.Close();

            return hoSoCollection;
        }

        /// <summary>
        ///GetHoSoByID
        /// </summary>
        /// <param name="MaDot"></param>
        /// <returns>HoSo object class</returns>
        public HoSo GetHoSoByID(long idHS)
        {
            HoSo objHoSo = new HoSo();
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);
           
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_HoSoLoadByPrimaryKey");
            if (reader.Read())
            {

                objHoSo.DangXetTuyen = (bool)reader["DangXetTuyen"];
                objHoSo.DanToc = reader["DanToc"].ToString();
                objHoSo.DiaChi = reader["DiaChi"].ToString();
                objHoSo.DienThoai = reader["DienThoai"].ToString();
                objHoSo.Email = reader["Email"].ToString();
                objHoSo.GiayTotNghiep = (bool)reader["GiayTotNghiep"];
                objHoSo.GioiTinh = reader["GioiTinh"].ToString();
                objHoSo.HanhKiem = reader["HanhKiem"].ToString();
                objHoSo.HeXetTuyen = (byte)reader["HeXetTuyen"];
                objHoSo.HinhThuc = (byte)reader["HinhThuc"];
                objHoSo.HocBa = (bool)reader["HocBa"];
                objHoSo.HoKhau = reader["HoKhau"].ToString();
                objHoSo.HoTen = reader["HoTen"].ToString();
                objHoSo.Idhs = (long)reader["Idhs"];
                objHoSo.KhoiDT = reader["KhoiDT"].ToString();
                objHoSo.LienThong = (bool)reader["LienThong"];
                objHoSo.LoaiHocBa = reader["LoaiHocBa"].ToString();
                objHoSo.Lop10 = reader["Lop10"].ToString();
                objHoSo.Lop10MaTinh = reader["Lop10MaTinh"].ToString();
                objHoSo.Lop10MaTruong = reader["Lop10MaTruong"].ToString();
                objHoSo.Lop11 = reader["Lop11"].ToString();
                objHoSo.Lop11MaTinh = reader["Lop11MaTinh"].ToString();
                objHoSo.Lop11MaTruong = reader["Lop11MaTruong"].ToString();
                objHoSo.Lop12 = reader["Lop12"].ToString();
                objHoSo.Lop12MaTinh = reader["Lop12MaTinh"].ToString();
                objHoSo.Lop12MaTruong = reader["Lop12MaTruong"].ToString();
                objHoSo.MaDT = reader["MaDT"].ToString();
                objHoSo.MaHuyen = reader["MaHuyen"].ToString();
                objHoSo.MaKV = reader["MaKV"].ToString();
                objHoSo.MaTinh = reader["MaTinh"].ToString();
                objHoSo.Nam = (int)reader["Nam"];
                objHoSo.NamTotNghiep = (int)reader["NamTotNghiep"];
                objHoSo.NgayNhap = (DateTime)reader["NgayNhap"];
                objHoSo.NgaySinh = (DateTime)reader["NgaySinh"];
                objHoSo.NgaySua = (DateTime)reader["NgaySua"];
                objHoSo.NguoiNhap = reader["NguoiNhap"].ToString();
                objHoSo.NguoiSua = reader["NguoiSua"].ToString();
                objHoSo.NopLePhi = (bool)reader["NopLePhi"];
                objHoSo.Online = (bool)reader["Online"];
                objHoSo.SoBaoDanh = reader["SoBaoDanh"].ToString();
                objHoSo.SoCMTND = reader["SoCMTND"].ToString();
                objHoSo.TotNghiep = reader["TotNghiep"].ToString();
                objHoSo.TruongDT = reader["TruongDT"].ToString();
                objHoSo.MaHS = reader["MaHS"].ToString();
                objHoSo.KetQua = (byte)reader["KetQua"];
                objHoSo.Buoc = (int)reader["Buoc"];


            }

            //Call Close when done reading.
            reader.Close();

            return objHoSo;
        }
        public bool UpdateTrungTuyen(long idHS, string MaHS, double diem1, double diem2, double diem3, double diem4, double diem5, double diem6, double diem7, double diem8, double diem9, double diem10, double diem11, double diem12, double diem13, double diem14, double diem15, double diem16, double diem17, double diem18, string makhoi, string khoDK, string idNganh, string maDot, string soQD, int trangThai, int soIn, int chonIn)
        {



            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();
                db.AddParameter("@M1L10HK1", diem1);
                db.AddParameter("@M1L10HK2", diem2);
                db.AddParameter("@M2L10HK1", diem3);

                db.AddParameter("@M2L10HK2", diem4);
                db.AddParameter("@M3L10HK1", diem5);
                db.AddParameter("@M3L10HK2", diem6);

                db.AddParameter("@M1L11HK1", diem7);
                db.AddParameter("@M1L11HK2", diem8);
                db.AddParameter("@M2L11HK1", diem9);

                db.AddParameter("@M2L11HK2", diem10);
                db.AddParameter("@M3L11HK1", diem11);
                db.AddParameter("@M3L11HK2", diem12);

                db.AddParameter("@M1L12HK1", diem13);
                db.AddParameter("@M1L12HK2", diem14);
                db.AddParameter("@M2L12HK1", diem15);

                db.AddParameter("@M2L12HK2", diem16);
                db.AddParameter("@M3L12HK1", diem17);
                db.AddParameter("@M3L12HK2", diem18);

                db.AddParameter("@IdHS", idHS);
                db.AddParameter("@MaHS", MaHS);
                db.AddParameter("@Makhoi", makhoi);
                db.AddParameter("@KhoiDk", khoDK);
                db.AddParameter("@NganhXT", idNganh);
                db.AddParameter("@MaDot", maDot);
                db.AddParameter("@SoQD", soQD);
                db.AddParameter("@TrangThai", trangThai);
                db.AddParameter("@SoIn", soIn);
                db.AddParameter("@ChonIn", chonIn);
                db.ExecuteNonQuery("proc_t_TrungTuyenUpdate");
                return true;
            }
            catch
            {

                return false;
            }



        }

        public bool UpdateTrungTuyenTrangThai(long idHS, string MaHS, string makhoi, string idNganh, int trangThai)
        {



            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();


                db.AddParameter("@IdHS", idHS);
                db.AddParameter("@MaHS", MaHS);
                db.AddParameter("@Makhoi", makhoi);

                db.AddParameter("@NganhXT", idNganh);


                db.AddParameter("@TrangThai", trangThai);
                db.ExecuteNonQuery("proc_t_TrungTuyenUpdateTrangThai");


                return true;
            }
            catch
            {

                return false;
            }



        }

        public bool UpdateTrungTuyenSoIn(long idHS, string MaHS, string makhoi, string idNganh, int soIn)
        {



            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();


                db.AddParameter("@IdHS", idHS);
                db.AddParameter("@MaHS", MaHS);
                db.AddParameter("@Makhoi", makhoi);

                db.AddParameter("@NganhXT", idNganh);


                db.AddParameter("@SoIn", soIn);
                db.ExecuteNonQuery("proc_t_TrungTuyenUpdateSoIn");


                return true;
            }
            catch
            {

                return false;
            }


        }

        public bool CheckDieuKienXetTuyen(string idNganh, string maKhoi, string maDot, int nam, double tb)
        {
            bool resutl = true;
            DieuKienService dieuKienBS = new DieuKienService();
            DieuKien objDieuKien = dieuKienBS.GetDieuKien(idNganh, maKhoi, maDot, nam);
            if (tb < objDieuKien.DiemSan || tb < objDieuKien.DiemChuan)
            {
                resutl = false;
            }

            return resutl;
        }
        [MethodDescription(ModuleType.Processing, FormName.XetTuyenHS, FunctionName.Proc_AddXetTuyen)]
        public bool XetTuyenHS(long idHS, string MaHS, string maKhoi, double diem1, double diem2, double diem3, double diem4, double diem5, double diem6, double diem7, double diem8, double diem9, double diem10, double diem11, double diem12, double diem13, double diem14, double diem15, double diem16, double diem17, double diem18, string khoiDK, string nganhXT, string maDot, string soQD, int trangThai, int soIn, int chonIn)
        {



            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();
                db.AddParameter("@M1L10HK1", diem1);
                db.AddParameter("@M1L10HK2", diem2);
                db.AddParameter("@M2L10HK1", diem3);

                db.AddParameter("@M2L10HK2", diem4);
                db.AddParameter("@M3L10HK1", diem5);
                db.AddParameter("@M3L10HK2", diem6);

                db.AddParameter("@M1L11HK1", diem7);
                db.AddParameter("@M1L11HK2", diem8);
                db.AddParameter("@M2L11HK1", diem9);

                db.AddParameter("@M2L11HK2", diem10);
                db.AddParameter("@M3L11HK1", diem11);
                db.AddParameter("@M3L11HK2", diem12);

                db.AddParameter("@M1L12HK1", diem13);
                db.AddParameter("@M1L12HK2", diem14);
                db.AddParameter("@M2L12HK1", diem15);

                db.AddParameter("@M2L12HK2", diem16);
                db.AddParameter("@M3L12HK1", diem17);
                db.AddParameter("@M3L12HK2", diem18);

                db.AddParameter("@IdHS", idHS);
                db.AddParameter("@MaHS", MaHS);
                db.AddParameter("@Makhoi", maKhoi);
                db.AddParameter("@KhoiDk", khoiDK);
                db.AddParameter("@NganhXT", nganhXT);
                db.AddParameter("@MaDot", maDot);
                db.AddParameter("@SoQD ", soQD);
                db.AddParameter("@TrangThai ", trangThai);
                db.AddParameter("@SoIn", soIn);
                db.AddParameter("@ChonIn", chonIn);

                db.ExecuteNonQuery("proc_t_TrungTuyenInsert");


                return true;
            }
            catch
            {

                return false;
            }



        }
        public string GetSoBaoDanh(int Nam, string Matruong, int len)
        {
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GenaraSoBD]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;
            
            p = cmd.Parameters.Add(new SqlParameter("@MaTruong", SqlDbType.NVarChar, 20));
            p.Value = Matruong;

            p = cmd.Parameters.Add(new SqlParameter("@len", SqlDbType.TinyInt));
            p.Value = len;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable.Rows.Clear();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["SoBaoDanh"].ToString();
            }
            return string.Empty;
        }
        public string GetSoBaoDanhRandom(int Nam, string Matruong, int len)
        {
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GenaraSoBDRandom]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            p = cmd.Parameters.Add(new SqlParameter("@MaTruong", SqlDbType.NVarChar, 20));
            p.Value = Matruong;

            p = cmd.Parameters.Add(new SqlParameter("@len", SqlDbType.TinyInt));
            p.Value = len;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable.Rows.Clear();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["SoBaoDanh"].ToString();
            }
            return string.Empty;
        }
        public string GetSoQuyetDinh(string idNganh, string nam)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_t_GenaraSoQD";

            SqlParameter p;




            p = cmd.Parameters.Add(new SqlParameter("@idNganh", SqlDbType.NVarChar, 20));
            p.Value = idNganh;

            p = cmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.NVarChar, 20));
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["SoQD"].ToString();
            }
            return string.Empty;
        }
        protected SqlCommand CreateParameters(HoSo HoSo)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.DangXetTuyen);
            p.Value = HoSo.DangXetTuyen;

            p = cmd.Parameters.Add(Parameters.DanToc);
            p.Value = HoSo.DanToc;

            p = cmd.Parameters.Add(Parameters.DiaChi);
            p.Value = HoSo.DiaChi;

            p = cmd.Parameters.Add(Parameters.DienThoai);
            p.Value = HoSo.DienThoai;

            p = cmd.Parameters.Add(Parameters.Email);
            p.Value = HoSo.Email;

            p = cmd.Parameters.Add(Parameters.GiayTotNghiep);
            p.Value = HoSo.GiayTotNghiep;

            p = cmd.Parameters.Add(Parameters.HanhKiem);
            p.Value = HoSo.HanhKiem;

            p = cmd.Parameters.Add(Parameters.HocBa);
            p.Value = HoSo.HocBa;

            p = cmd.Parameters.Add(Parameters.HoKhau);
            p.Value = HoSo.HoKhau;

            p = cmd.Parameters.Add(Parameters.HoTen);
            p.Value = HoSo.HoTen;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = HoSo.Idhs;

            p = cmd.Parameters.Add(Parameters.KhoiDT);
            p.Value = HoSo.KhoiDT;

            p = cmd.Parameters.Add(Parameters.LienThong);
            p.Value = HoSo.LienThong;

            p = cmd.Parameters.Add(Parameters.LoaiHocBa);
            p.Value = HoSo.LoaiHocBa;

            p = cmd.Parameters.Add(Parameters.Lop10);
            p.Value = HoSo.Lop10;

            p = cmd.Parameters.Add(Parameters.Lop10MaTinh);
            p.Value = HoSo.Lop10MaTinh;

            p = cmd.Parameters.Add(Parameters.Lop10MaTruong);
            p.Value = HoSo.Lop10MaTruong;

            p = cmd.Parameters.Add(Parameters.Lop11);
            p.Value = HoSo.Lop11;

            p = cmd.Parameters.Add(Parameters.Lop11MaTinh);
            p.Value = HoSo.Lop11MaTinh;


            p = cmd.Parameters.Add(Parameters.Lop11MaTruong);
            p.Value = HoSo.Lop11MaTruong;

            p = cmd.Parameters.Add(Parameters.Lop12);
            p.Value = HoSo.Lop12;

            p = cmd.Parameters.Add(Parameters.Lop12MaTinh);
            p.Value = HoSo.Lop12MaTinh;

            p = cmd.Parameters.Add(Parameters.Lop12MaTruong);
            p.Value = HoSo.Lop12MaTruong;

            p = cmd.Parameters.Add(Parameters.MaDT);
            p.Value = HoSo.MaDT;

            p = cmd.Parameters.Add(Parameters.MaHuyen);
            p.Value = HoSo.MaHuyen;

            p = cmd.Parameters.Add(Parameters.MaKV);
            p.Value = HoSo.MaKV;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = HoSo.MaTinh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = HoSo.Nam;

            p = cmd.Parameters.Add(Parameters.NamTotNghiep);
            p.Value = HoSo.NamTotNghiep;

            p = cmd.Parameters.Add(Parameters.GioiTinh);
            p.Value = HoSo.GioiTinh;

            p = cmd.Parameters.Add(Parameters.NgayNhap);
            p.Value = HoSo.NgayNhap;

            p = cmd.Parameters.Add(Parameters.NgaySinh);
            p.Value = HoSo.NgaySinh;

            p = cmd.Parameters.Add(Parameters.NgaySua);
            p.Value = HoSo.NgaySua;


            p = cmd.Parameters.Add(Parameters.NguoiNhap);
            p.Value = HoSo.NguoiNhap;

            p = cmd.Parameters.Add(Parameters.NguoiSua);
            p.Value = HoSo.NguoiSua;

            p = cmd.Parameters.Add(Parameters.NopLePhi);
            p.Value = HoSo.NopLePhi;

            p = cmd.Parameters.Add(Parameters.Online);
            p.Value = HoSo.Online;

            p = cmd.Parameters.Add(Parameters.SoBaoDanh);
            p.Value = HoSo.SoBaoDanh;

            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = HoSo.SoCMTND;

            p = cmd.Parameters.Add(Parameters.TotNghiep);
            p.Value = HoSo.TotNghiep;


            p = cmd.Parameters.Add(Parameters.TruongDT);
            p.Value = HoSo.TruongDT;

            p = cmd.Parameters.Add(Parameters.HeXetTuyen);
            p.Value = HoSo.HeXetTuyen;


            p = cmd.Parameters.Add(Parameters.HinhThuc);
            p.Value = HoSo.HinhThuc;

            p = cmd.Parameters.Add(Parameters.Buoc);
            p.Value = HoSo.Buoc;

            p = cmd.Parameters.Add(Parameters.KetQua);
            p.Value = HoSo.KetQua;

            p = cmd.Parameters.Add(Parameters.MaHS);
            p.Value = HoSo.MaHS;
           
            return cmd;
        }
        #region Parameters
        protected class Parameters
        {

            public static SqlParameter IDHS
            {
                get
                {
                    return new SqlParameter("@IDHS", SqlDbType.BigInt, 0);
                }
            }

            public static SqlParameter SoCMTND
            {
                get
                {
                    return new SqlParameter("@SoCMTND", SqlDbType.NVarChar, 50);
                }
            }

            public static SqlParameter HoTen
            {
                get
                {
                    return new SqlParameter("@HoTen", SqlDbType.NVarChar, 255);
                }
            }

            public static SqlParameter NgaySinh
            {
                get
                {
                    return new SqlParameter("@NgaySinh", SqlDbType.DateTime, 0);
                }
            }

            public static SqlParameter GioiTinh
            {
                get
                {
                    return new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 50);
                }
            }

            public static SqlParameter HoKhau
            {
                get
                {
                    return new SqlParameter("@HoKhau", SqlDbType.NVarChar, 3000);
                }
            }

            public static SqlParameter DiaChi
            {
                get
                {
                    return new SqlParameter("@DiaChi", SqlDbType.NVarChar, 300);
                }
            }

            public static SqlParameter DienThoai
            {
                get
                {
                    return new SqlParameter("@DienThoai", SqlDbType.NVarChar, 100);
                }
            }

            public static SqlParameter Email
            {
                get
                {
                    return new SqlParameter("@Email", SqlDbType.NVarChar, 255);
                }
            }

            public static SqlParameter MaTinh
            {
                get
                {
                    return new SqlParameter("@MaTinh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaHuyen
            {
                get
                {
                    return new SqlParameter("@MaHuyen", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaDT
            {
                get
                {
                    return new SqlParameter("@MaDT", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop10
            {
                get
                {
                    return new SqlParameter("@Lop10", SqlDbType.NVarChar, 1073741823);
                }
            }

            public static SqlParameter Lop10MaTinh
            {
                get
                {
                    return new SqlParameter("@Lop10MaTinh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop10MaTruong
            {
                get
                {
                    return new SqlParameter("@Lop10MaTruong", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop11
            {
                get
                {
                    return new SqlParameter("@Lop11", SqlDbType.NVarChar, 1073741823);
                }
            }

            public static SqlParameter Lop11MaTinh
            {
                get
                {
                    return new SqlParameter("@Lop11MaTinh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop11MaTruong
            {
                get
                {
                    return new SqlParameter("@Lop11MaTruong", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop12
            {
                get
                {
                    return new SqlParameter("@Lop12", SqlDbType.NVarChar, 1073741823);
                }
            }

            public static SqlParameter Lop12MaTinh
            {
                get
                {
                    return new SqlParameter("@Lop12MaTinh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Lop12MaTruong
            {
                get
                {
                    return new SqlParameter("@Lop12MaTruong", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaKV
            {
                get
                {
                    return new SqlParameter("@MaKV", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter TruongDT
            {
                get
                {
                    return new SqlParameter("@TruongDT", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter KhoiDT
            {
                get
                {
                    return new SqlParameter("@KhoiDT", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter DanToc
            {
                get
                {
                    return new SqlParameter("@DanToc", SqlDbType.NVarChar, 100);
                }
            }

            public static SqlParameter HanhKiem
            {
                get
                {
                    return new SqlParameter("@HanhKiem", SqlDbType.NVarChar, 50);
                }
            }

            public static SqlParameter HocBa
            {
                get
                {
                    return new SqlParameter("@HocBa", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter LoaiHocBa
            {
                get
                {
                    return new SqlParameter("@LoaiHocBa", SqlDbType.NVarChar, 100);
                }
            }

            public static SqlParameter NamTotNghiep
            {
                get
                {
                    return new SqlParameter("@NamTotNghiep", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter GiayTotNghiep
            {
                get
                {
                    return new SqlParameter("@GiayTotNghiep", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter NgayNhap
            {
                get
                {
                    return new SqlParameter("@NgayNhap", SqlDbType.DateTime, 0);
                }
            }

            public static SqlParameter NguoiNhap
            {
                get
                {
                    return new SqlParameter("@NguoiNhap", SqlDbType.VarChar, 50);
                }
            }

            public static SqlParameter NgaySua
            {
                get
                {
                    return new SqlParameter("@NgaySua", SqlDbType.DateTime, 0);
                }
            }

            public static SqlParameter NguoiSua
            {
                get
                {
                    return new SqlParameter("@NguoiSua", SqlDbType.VarChar, 50);
                }
            }

            public static SqlParameter SoBaoDanh
            {
                get
                {
                    return new SqlParameter("@SoBaoDanh", SqlDbType.NVarChar, 100);
                }
            }

            public static SqlParameter DangXetTuyen
            {
                get
                {
                    return new SqlParameter("@DangXetTuyen", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter Nam
            {
                get
                {
                    return new SqlParameter("@Nam", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter NopLePhi
            {
                get
                {
                    return new SqlParameter("@NopLePhi", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter LienThong
            {
                get
                {
                    return new SqlParameter("@LienThong", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter TotNghiep
            {
                get
                {
                    return new SqlParameter("@TotNghiep", SqlDbType.NVarChar, 255);
                }
            }

            public static SqlParameter Online
            {
                get
                {
                    return new SqlParameter("@Online", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter HeXetTuyen
            {
                get
                {
                    return new SqlParameter("@HeXetTuyen", SqlDbType.TinyInt, 0);
                }
            }
            public static SqlParameter HinhThuc
            {
                get
                {
                    return new SqlParameter("@HinhThuc", SqlDbType.TinyInt, 0);
                }
            }
            public static SqlParameter Buoc
            {
                get
                {
                    return new SqlParameter("@Buoc", SqlDbType.Int, -1);
                }
            }
            public static SqlParameter KetQua
            {
                get
                {
                    return new SqlParameter("@KetQua", SqlDbType.TinyInt, 0);
                }
            }
            public static SqlParameter MaHS
            {
                get
                {
                    return new SqlParameter("@MaHS", SqlDbType.NVarChar, 50);
                }
            }
        }
        #endregion		

    }
}
