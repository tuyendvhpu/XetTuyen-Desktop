using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
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
            cmd.Parameters["@MaMon"].Direction = ParameterDirection.Output;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(MonXT MonXT) {
            SqlCommand cmd = CreateParameters(MonXT);
            cmd.CommandText = "[proc_t_MonXTUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_MonXTLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

           
            return dataTable;
        }
        public DataTable FinMonXT(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaMonXT)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
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
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

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
                 return new SqlParameter("@MaMon", SqlDbType.Int , 0);
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
