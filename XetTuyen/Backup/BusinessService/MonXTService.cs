using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using DataAccess;
using Common;

namespace BusinessService
{
    public class MonXTADO
    {
         private DataTable dataTable ;
        
        public MonXTADO()
        {
        }
      

        public  bool Insert(MonXT MonXT) {
            SqlCommand cmd = CreateParameters(MonXT);
            cmd.CommandText = "[proc_t_MonXTInsert]";
     
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(MonXT MonXT) {
            SqlCommand cmd = CreateParameters(MonXT);
            cmd.CommandText = "[proc_t_MonXTUpdate]";
            
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaMonXT)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_MonXTDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = MaMonXT;

            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_MonXTLoadAll]", DbConnection.SqlConnection);
            
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable FinMonXT(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string MaMonXT)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_MonXTLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaMon;
            p.Value = MaMonXT;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(MonXT MonXT)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = MonXT.MaMon;

            p = cmd.Parameters.Add(Parameters.TenMon);
            p.Value = MonXT.TenMon;

            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaMon
         {
             get
             {
                 return new SqlParameter("@MaMon", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenMon
         {
             get
             {
                 return new SqlParameter("@TenMon", SqlDbType.NChar, 255);
             }
         }

     }
     #endregion		
	
    }
}
