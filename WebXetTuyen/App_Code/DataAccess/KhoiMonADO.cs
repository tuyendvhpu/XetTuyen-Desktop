using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class KhoiMonADO
    {
        private DataTable dataTable ;

        public KhoiMonADO()
        {
        }


        public bool Insert(KhoiMon KhoiMon)
        {
            SqlCommand cmd = CreateParameters(KhoiMon);
            cmd.CommandText = "[proc_t_KhoiMonInsert]";
            //cmd.Parameters["@IDHS"].Direction = ParameterDirection.Output;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }
        public bool Update(KhoiMon KhoiMon)
        {
            SqlCommand cmd = CreateParameters(KhoiMon);
            cmd.CommandText = "[proc_t_KhoiMonUpdate]";

            if (Utilities.conDBConnection == null) Utilities.getConnection();

            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool Delete(int Nam, string Makhoi)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiMonDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;
            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = Makhoi;

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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_KhoiMonLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        public DataTable FinKhoiMon(string sql)
        {
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
        public DataTable LoadByPrimaryKey(int Nam, string MaKhoi)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiMonLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = MaKhoi;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();


            return dataTable;
        }

        public DataTable LoadTenMonByPrimaryKey(int Nam, string MaKhoi)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiTenMonLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = MaKhoi;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }

        protected SqlCommand CreateParameters(KhoiMon KhoiMon)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            


            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = KhoiMon.MaKHoi;
            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = KhoiMon.Nam;

            return cmd;
        }
        #region Parameters
        protected class Parameters
        {

            public static SqlParameter MaKHoi
            {
                get
                {
                    return new SqlParameter("@MaKHoi", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Nam
            {
                get
                {
                    return new SqlParameter("@Nam", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter MaMon
            {
                get
                {
                    return new SqlParameter("@MaMon", SqlDbType.Int,0);
                }
            }

        }
        #endregion		


    }
}
