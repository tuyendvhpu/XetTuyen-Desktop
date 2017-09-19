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
        private DataTable dataTable = new DataTable();

        public KhoiMonADO()
        {
        }


        public bool Insert(KhoiMon KhoiMon)
        {
            SqlCommand cmd = CreateParameters(KhoiMon);
            cmd.CommandText = "[proc_t_KhoiMonInsert]";
            //cmd.Parameters["@IDHS"].Direction = ParameterDirection.Output;
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;

        }
        public bool Update(KhoiMon KhoiMon)
        {
            SqlCommand cmd = CreateParameters(KhoiMon);
            cmd.CommandText = "[proc_t_KhoiMonUpdate]";
           
            

            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
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


            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;

        }



        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_KhoiMonLoadAll]", Utilities.conDBConnection);
            dataAdapter.Fill(dataTable);


            return dataTable;
        }
        public DataTable FinKhoiMon(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(int Nam, string MaKhoi)
        {


            SqlCommand cmd = new SqlCommand();
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
            dataAdapter.Fill(dataTable);

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
                    return new SqlParameter("@MaMon", SqlDbType.NVarChar, 20);
                }
            }

        }
        #endregion		


    }
}
