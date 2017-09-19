using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public  class CongThucADO
    {
        private DataTable dataTable ;

        public CongThucADO()
        {
        }


        public bool Insert(CongThuc CongThuc)
        {
            SqlCommand cmd = CreateParameters(CongThuc);
            cmd.CommandText = "[proc_t_CongThucInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public bool Update(CongThuc CongThuc)
        {
            SqlCommand cmd = CreateParameters(CongThuc);
            cmd.CommandText = "[proc_t_CongThucUpdate]";


            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool Delete(string manganh, string MaMon, string makhoi, int nam, string iDNganh, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = MaMon;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = iDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }


        public bool DeleteByKhoi(string makhoi, int nam, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByKhoi]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool DeleteByNganh(string manganh, int nam, string IDNganh, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool DeleteByMaNganh(string manganh, int nam, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByMaNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;



            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;
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
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_CongThucLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable FinCongThuc(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadyKey(string manganh, string madot, string makhoi, int nam, string IDNganh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucLoadByKey]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

          

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }

        public DataTable GetCongThucNam_Dot_IdNganh(int nam, string madot, string IDNganh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_IdNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }



        public DataTable GetCongThucNam_Dot_MaNganh(int nam, string madot, string manganh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_MaNganh]";

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
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }


        public DataTable GetCongThucNam_Dot_Khoi_Nganh(int nam, string madot, string manganh, string makhoi)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_Khoi_Nganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }



        public DataTable GetCongThucNam_Dot_Khoi(int nam, string madot,  string makhoi)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_Khoi]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }

        protected SqlCommand CreateParameters(CongThuc CongThuc)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.HeSo);
            p.Value = CongThuc.HeSo;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = CongThuc.MaDot;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = CongThuc.MaKHoi;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = CongThuc.MaMon;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = CongThuc.MaNganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = CongThuc.MaNganh;
           
           
            return cmd;
        }
        #region Parameters
        protected class Parameters
        {

            public static SqlParameter MaNganh
            {
                get
                {
                    return new SqlParameter("@MaNganh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter IDNganh
            {
                get
                {
                    return new SqlParameter("@IDNganh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaKHoi
            {
                get
                {
                    return new SqlParameter("@MaKHoi", SqlDbType.NVarChar, 20);
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

            public static SqlParameter HeSo
            {
                get
                {
                    return new SqlParameter("@HeSo", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter MaMon
            {
                get
                {
                    return new SqlParameter("@MaMon", SqlDbType.NVarChar, 20);
                }
            }

        }
        #endregion		

    }
}
