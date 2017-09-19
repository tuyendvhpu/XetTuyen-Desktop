using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    class TinhADO
    {
         private DataTable dataTable;
        
        public TinhADO()
        {
        }
      

        public  bool Insert(Tinh Tinh) {
            SqlCommand cmd = CreateParameters(Tinh);
            cmd.CommandText = "[proc_t_TinhInsert]";
          //  cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(Tinh Tinh) {
            SqlCommand cmd = CreateParameters(Tinh);
            cmd.CommandText = "[proc_t_TinhUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaTinh)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TinhDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = MaTinh;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_TinhLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinTinh(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaTinh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TinhLoadByPrimaryKey]";

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
        
        
       
	 protected SqlCommand CreateParameters(Tinh Tinh)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = Tinh.MaTinh;

            p = cmd.Parameters.Add(Parameters.TenTinh);
            p.Value = Tinh.TenTinh;
            return cmd;
        }
    
        #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaTinh
         {
             get
             {
                 return new SqlParameter("@MaTinh", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenTinh
         {
             get
             {
                 return new SqlParameter("@TenTinh", SqlDbType.NVarChar, 255);
             }
         }

     }
     #endregion		
	
    }
}
