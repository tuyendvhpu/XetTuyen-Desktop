using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class DotXetTuyenADO
    {
         private DataTable dataTable ;
        
        public DotXetTuyenADO()
        {
        }
      

        public  bool Insert(DotXetTuyen DotXetTuyen) {
            SqlCommand cmd = CreateParameters(DotXetTuyen);
            cmd.CommandText = "[proc_t_DotXetTuyenInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(DotXetTuyen DotXetTuyen) {
            SqlCommand cmd = CreateParameters(DotXetTuyen);
            cmd.CommandText = "[proc_t_DotXetTuyenUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaDotXetTuyen)
        {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = MaDotXetTuyen;

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
           
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DotXetTuyenLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinDotXetTuyen(string sql) {
            if (Utilities.conDBConnection == null) Utilities.getConnection();
          
            SqlCommand cmd = new SqlCommand();
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
        public DataTable LoadByPrimaryKey(string MaDotXetTuyen, int nam)
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaDot;
            p.Value = MaDotXetTuyen;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);


            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }

        public DataTable LoadByNam(int nam)
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByNam]";

            SqlParameter p;

            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByDate(DateTime ngay)
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByDate]";

            SqlParameter p;

            p = new SqlParameter("@Ngay", SqlDbType.DateTime, 0); ;
            p.Value = ngay;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(DotXetTuyen DotXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = DotXetTuyen.MaDot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = DotXetTuyen.Nam;

            p = cmd.Parameters.Add(Parameters.NgayBD);
            p.Value = DotXetTuyen.NgayBD;

            p = cmd.Parameters.Add(Parameters.NgayKT);
            p.Value = DotXetTuyen.NgayKT;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaDot
         {
             get
             {
                 return new SqlParameter("@MaDot", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter NgayBD
         {
             get
             {
                 return new SqlParameter("@NgayBD", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter NgayKT
         {
             get
             {
                 return new SqlParameter("@NgayKT", SqlDbType.DateTime, 0);
             }
         }

     }
     #endregion		
	
    }
}
