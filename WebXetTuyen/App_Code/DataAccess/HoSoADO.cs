using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class HoSoADO
    {
        private DataTable dataTable ;

        public HoSoADO()
        {
        }


        public bool Insert(HoSo HoSo)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlCommand cmd = CreateParameters(HoSo);
            cmd.CommandText = "[proc_t_HoSoInsert]";
            cmd.Parameters["@IDHS"].Direction = ParameterDirection.Output;
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public bool Update(HoSo HoSo)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlCommand cmd = CreateParameters(HoSo);
            cmd.CommandText = "[proc_t_HoSoUpdate]";

            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public bool UpdateDiemTB(long idHS)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "[proc_t_HoSoUpdateDiemByIdHS]";
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public int CheckHoSo(Int64 idHS)
        {
            int i = 0;
            DataTable dt = LoadByPrimaryKey(idHS);
            if (dt.Rows.Count >= 0)
            {
                i = Convert.ToInt32(dt.Rows[0]["KetQua"].ToString());
            }
            return i;
        }
        public bool Delete(long idHS)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;


            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }



        public DataTable LoadAll()
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_HoSoLoadAll]", Utilities.conDBConnection);

          
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        public DataTable FinHoSo(string sql)
        {
            SqlCommand cmd = new SqlCommand();
           
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            dataAdapter.SelectCommand = cmd;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(Int64 idHS)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoCMTND(string sSoCMTND,int Nam)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoCMTND]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = sSoCMTND;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoCMAndPhone(string sSoCMTND,string dienThoai, int Nam)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadByCMAndPhone]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = sSoCMTND;

            p = cmd.Parameters.Add(Parameters.DienThoai);
            p.Value = dienThoai;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoBD(string sSoBD)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoBD]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoBaoDanh);
            p.Value = sSoBD;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadBySoCMTND_SoBD(string sSoCMTND, string sSoBD,int nam)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HoSoLoadBySoCMTND_SoBD]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.SoCMTND);
            p.Value = sSoCMTND;
            p = cmd.Parameters.Add(Parameters.SoBaoDanh);
            p.Value = sSoBD;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }

        public string GetSoBaoDanh(int Nam, string Matruong, int len)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
          

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
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
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["SoBaoDanh"].ToString();
            }
            return string.Empty;
        }
        public bool UpdateDiemTB(long idHS, int heso)
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
        public string GetSoBaoDanhRandom(int Nam, string Matruong, int len)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
          
           

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
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
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["SoBaoDanh"].ToString();
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
