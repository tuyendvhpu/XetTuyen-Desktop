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
    public class KhoiThiService
    {
         private DataTable dataTable ;

         public KhoiThiService()
        {
        }
      

        public  bool Insert(KhoiThi KhoiThi) {
            SqlCommand cmd = CreateParameters(KhoiThi);
            cmd.CommandText = "[proc_t_KhoiThiInsert]";
           
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(KhoiThi KhoiThi) {
            SqlCommand cmd = CreateParameters(KhoiThi);
            cmd.CommandText = "[proc_t_KhoiThiUpdate]";
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaKhoiThi)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiThiDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = MaKhoiThi;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_KhoiThiLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinKhoiThi(string sql) {
            SqlCommand cmd = new SqlCommand();
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
        public DataTable LoadByPrimaryKey(string MaKhoiThi, int nam)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiThiLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaKhoi;
            p.Value = MaKhoiThi;
            cmd.Parameters.Add(p);
            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(KhoiThi KhoiThi)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = KhoiThi.MaKhoi;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = KhoiThi.Nam;

            p = cmd.Parameters.Add(Parameters.TenKhoi);
            p.Value = KhoiThi.TenKhoi;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaKhoi
         {
             get
             {
                 return new SqlParameter("@MaKhoi", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter TenKhoi
         {
             get
             {
                 return new SqlParameter("@TenKhoi", SqlDbType.NVarChar, 255);
             }
         }

     }
     #endregion		
	
    }
}
