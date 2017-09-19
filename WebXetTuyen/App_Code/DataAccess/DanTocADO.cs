using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
     class DanTocADO
    {
         private DataTable dataTable ;
        
        public DanTocADO()
        {
        }
      

            public  bool Insert(DanToc DanToc) {
            SqlCommand cmd = CreateParameters(DanToc);
            cmd.CommandText = "[proc_t_DanTocInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(DanToc DanToc) {
            SqlCommand cmd = CreateParameters(DanToc);
            cmd.CommandText = "[proc_t_DanTocDelete]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaDanToc)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DanTocDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaDanToc);
            p.Value = MaDanToc;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DanTocLoadAll]", Utilities.conDBConnection);
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }
        public DataTable FinDanToc(string sql) {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string MaDanToc)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DanTocLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaDanToc;
            p.Value = MaDanToc;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(DanToc DanToc)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaDanToc);
            p.Value = DanToc.MaDanToc;

            p = cmd.Parameters.Add(Parameters.TenDanToc);
            p.Value = DanToc.TenDanToc;

            p = cmd.Parameters.Add(Parameters.MoTa);
            p.Value = DanToc.MoTa;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaDanToc
         {
             get
             {
                 return new SqlParameter("@MaDanToc", SqlDbType.VarChar, 30);
             }
         }

         public static SqlParameter TenDanToc
         {
             get
             {
                 return new SqlParameter("@TenDanToc", SqlDbType.NVarChar, 500);
             }
         }

         public static SqlParameter MoTa
         {
             get
             {
                 return new SqlParameter("@MoTa", SqlDbType.NVarChar, 1073741823);
             }
         }

     }
     #endregion		
	
	
    }
}
