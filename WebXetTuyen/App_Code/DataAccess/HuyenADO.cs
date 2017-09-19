using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
     class HuyenADO
    {
         private DataTable dataTable ;
        
        public HuyenADO()
        {
        }
      

        public  bool Insert(Huyen Huyen) {
            SqlCommand cmd = CreateParameters(Huyen);
            cmd.CommandText = "[proc_t_HuyenInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(Huyen Huyen) {
            SqlCommand cmd = CreateParameters(Huyen);
            cmd.CommandText = "[proc_t_HuyenUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaHuyen)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaHuyen);
            p.Value = MaHuyen;
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

            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_HuyenLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinHuyen(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaHuyen)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaHuyen;
            p.Value = MaHuyen;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByMaTinh(string MaTinh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByMaTinh]";

            SqlParameter p;

            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
                        Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string MaHuyen,string MaTinh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByMa]";

            SqlParameter p;

            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);
            
            p = Parameters.MaHuyen;
            p.Value = MaHuyen;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(Huyen Huyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaHuyen);
            p.Value = Huyen.MaHuyen;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = Huyen.MaTinh;

            p = cmd.Parameters.Add(Parameters.TenHuyen);
            p.Value = Huyen.TenHuyen;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaHuyen
         {
             get
             {
                 return new SqlParameter("@MaHuyen", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter MaTinh
         {
             get
             {
                 return new SqlParameter("@MaTinh", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenHuyen
         {
             get
             {
                 return new SqlParameter("@TenHuyen", SqlDbType.NVarChar, 255);
             }
         }

     }
     #endregion		
	
    }
}
