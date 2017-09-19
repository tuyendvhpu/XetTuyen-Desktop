using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    class NhomNganhADO
    {
         private DataTable dataTable ;
        
        public NhomNganhADO()
        {
        }
      

        public  bool Insert(NhomNganh NhomNganh) {
            SqlCommand cmd = CreateParameters(NhomNganh);
            cmd.CommandText = "[proc_t_NhomNganhInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(NhomNganh NhomNganh) {
            SqlCommand cmd = CreateParameters(NhomNganh);
            cmd.CommandText = "[proc_t_NhomNganhUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaNhomNganh)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomNganhDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = MaNhomNganh;
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

            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NhomNganhLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinNhomNganh(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaNhomNganh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomNganhLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaNganh;
            p.Value = MaNhomNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(NhomNganh NhomNganh)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = NhomNganh.MaNganh;

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = NhomNganh.MaTruong;

            p = cmd.Parameters.Add(Parameters.TenNganh);
            p.Value = NhomNganh.TenNganh;

            p = cmd.Parameters.Add(Parameters.LoaiNganh);
            p.Value = NhomNganh.LoaiNganh;
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

         public static SqlParameter MaTruong
         {
             get
             {
                 return new SqlParameter("@MaTruong", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenNganh
         {
             get
             {
                 return new SqlParameter("@TenNganh", SqlDbType.NVarChar, 300);
             }
         }
         public static SqlParameter LoaiNganh
         {
             get
             {
                 return new SqlParameter("@LoaiNganh", SqlDbType.NVarChar, 20);
             }
         }

     }
     #endregion		
	
    }
}
