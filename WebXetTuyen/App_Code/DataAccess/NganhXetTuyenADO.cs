using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class NganhXetTuyenADO
    {
         private DataTable dataTable ;
         
        public NganhXetTuyenADO()
        {
        }
      

        public  bool Insert(NganhXetTuyen NganhXetTuyen) {
            SqlCommand cmd = CreateParameters(NganhXetTuyen);
            cmd.CommandText = "[proc_t_NganhXetTuyenInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(NganhXetTuyen NganhXetTuyen) {

            SqlCommand cmd = CreateParameters(NganhXetTuyen);

            cmd.CommandText = "[proc_t_NganhXetTuyenUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
        public bool UpdateDiemTB(Int64 IDHS, string makhoi, string madot, int nam, string IDNganh, float diemTB, int heso)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenUpdateDiem]";
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = IDHS;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.DiemTB);
            p.Value = diemTB;

            p = cmd.Parameters.Add(new SqlParameter("@HeSo", SqlDbType.TinyInt, 0));
            p.Value = heso;
            

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
       
        public bool Delete( Int64 IDHS,string manganh, string makhoi, string madot, int nam, string IDNganh )
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = IDHS;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }

        public bool Delete(Int64 IDHS,  string madot, int nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenDeleteByID]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = IDHS;

          
            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public bool Delete(Int64 IDHS,  int nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenDeleteByIDHS]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = IDHS;


           
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }


        public bool Delete(string manganh,  string madot, int nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenDeleteByMaNganh]";

            SqlParameter p;

           

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

           
            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool Delete( string manganh, string madot, int nam, string IDNganh)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenDeleteByNganh]";

            SqlParameter p;

         

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;


            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NganhXetTuyenLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinNganhXetTuyen(string sql) {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByIDHS(Int64 idHS, string madot, int nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByIDHS]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


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
        public DataTable LoadByIDHS(long idHS)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByID]";

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
        public DataTable LoadByNganh(string manganh, string madot, int nam )
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


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
        public DataTable LoadByIDNganh(string manganh,string IDNganh, string madot, int nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByIDNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;
           
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


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


        public DataTable LoadMonXetTuyen( long idHS, int nam)
        {

            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_LoadMonHoso]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

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

        protected SqlCommand CreateParameters(NganhXetTuyen NganhXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = NganhXetTuyen.Idhs;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = NganhXetTuyen.MaDot;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = NganhXetTuyen.MaKhoi;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = NganhXetTuyen.MaNganh;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = NganhXetTuyen.Nam;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = NganhXetTuyen.IDNganh;

            p = cmd.Parameters.Add(Parameters.DiemTB);
            p.Value = NganhXetTuyen.DiemTB;

            p = cmd.Parameters.Add(Parameters.DiemTXT);
            p.Value = NganhXetTuyen.DiemTXT;


            p = cmd.Parameters.Add(Parameters.DiemUTDT);
            p.Value = NganhXetTuyen.DiemUTDT;

            p = cmd.Parameters.Add(Parameters.DiemUTKV);
            p.Value = NganhXetTuyen.DiemUTKV;

            p = cmd.Parameters.Add(Parameters.TrangThai);
            p.Value = NganhXetTuyen.TrangThai;

            p = cmd.Parameters.Add(Parameters.NgayDK);
            p.Value = NganhXetTuyen.NgayDK;
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

            public static SqlParameter IDNganh
            {
                get
                {
                    return new SqlParameter("@IDNganh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaNganh
            {
                get
                {
                    return new SqlParameter("@MaNganh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaKhoi
            {
                get
                {
                    return new SqlParameter("@MaKhoi", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaDot
            {
                get
                {
                    return new SqlParameter("@MaDot", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Nam
            {
                get
                {
                    return new SqlParameter("@Nam", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter DiemTB
            {
                get
                {
                    return new SqlParameter("@DiemTB", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter DiemUTKV
            {
                get
                {
                    return new SqlParameter("@DiemUTKV", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter DiemUTDT
            {
                get
                {
                    return new SqlParameter("@DiemUTDT", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter DiemTXT
            {
                get
                {
                    return new SqlParameter("@DiemTXT", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter TrangThai
            {
                get
                {
                    return new SqlParameter("@TrangThai", SqlDbType.Int, 0);
                }
            }
            public static SqlParameter NgayDK
            {
                get
                {
                    return new SqlParameter("@NgayDK", SqlDbType.DateTime, 0);
                }
            }
        }
        #endregion
	
    }
}
