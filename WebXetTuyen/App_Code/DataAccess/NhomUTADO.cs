using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    class NhomUTADO
    {
         private DataTable dataTable ;
        
        public NhomUTADO()
        {
        }
      

        public  bool Insert(NhomUT NhomUT) {
            SqlCommand cmd = CreateParameters(NhomUT);
            cmd.CommandText = "[proc_t_NhomUTInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(NhomUT NhomUT) {
            SqlCommand cmd = CreateParameters(NhomUT);
            cmd.CommandText = "[proc_t_NhomUTUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaNhomUT)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomUTDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaN);
            p.Value = MaNhomUT;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NhomUTLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinNhomUT(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaNhomUT)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomUTLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaN;
            p.Value = MaNhomUT;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(NhomUT NhomUT)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaN);
            p.Value = NhomUT.MaN;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = NhomUT.Nam;

            p = cmd.Parameters.Add(Parameters.TenNhom);
            p.Value = NhomUT.TenNhom;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaN
         {
             get
             {
                 return new SqlParameter("@MaN", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenNhom
         {
             get
             {
                 return new SqlParameter("@TenNhom", SqlDbType.NVarChar, 255);
             }
         }

         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int, 0);
             }
         }

     }
     #endregion		
	
    }
}
