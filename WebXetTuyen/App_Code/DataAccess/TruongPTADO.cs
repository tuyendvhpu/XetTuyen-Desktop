using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    class TruongPTADO
    {
         private DataTable dataTable;
        
        public TruongPTADO()
        {
        }
      

        public  bool Insert(TruongPT TruongPT) {
            SqlCommand cmd = CreateParameters(TruongPT);
            cmd.CommandText = "[proc_t_TruongPTInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
           
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(TruongPT TruongPT) {
            SqlCommand cmd = CreateParameters(TruongPT);
            cmd.CommandText = "[proc_t_TruongPTUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
             Utilities.conDBConnection.Close();
           
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaTruongPT,string MaTinh, int Nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = MaTruongPT;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = MaTinh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

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

            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_TruongPTLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

           
            return dataTable;
        }
        public DataTable FinTruongPT(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaTruongPT, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaTruong;
            p.Value = MaTruongPT;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }

        public DataTable LoadByPrimaryKey(string MaTruongPT,string MaTinh, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTLoadByMaTinh_MaTruong]";

            SqlParameter p;

            p = Parameters.MaTruong;
            p.Value = MaTruongPT;
            cmd.Parameters.Add(p);
           
            p = Parameters.MaTinh;
            p.Value = MaTinh;
            
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value =Nam ;

            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

            return dataTable;
        }

        public DataTable LoadByMaTinh(string MaTinh,int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTLoadByMaTinh]";

            SqlParameter p;

          
            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(TruongPT TruongPT)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.DiaChi);
            p.Value = TruongPT.DiaChi;
            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = TruongPT.MaTinh;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = TruongPT.Nam;
            p = cmd.Parameters.Add(Parameters.MaKV);
            p.Value = TruongPT.MaKV;

            

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = TruongPT.MaTruong;

            p = cmd.Parameters.Add(Parameters.TenTruong);
            p.Value = TruongPT.TenTruong;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaTruong
         {
             get
             {
                 return new SqlParameter("@MaTruong", SqlDbType.NVarChar, 20);
             }
         }
         public static SqlParameter MaTinh
         {
             get
             {
                 return new SqlParameter("@MaTinh", SqlDbType.NVarChar, 20);
             }
         }
         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int );
             }
         }

         public static SqlParameter MaKV
         {
             get
             {
                 return new SqlParameter("@MaKV", SqlDbType.NVarChar, 20);
             }
         }

         
         public static SqlParameter TenTruong
         {
             get
             {
                 return new SqlParameter("@TenTruong", SqlDbType.NVarChar, 225);
             }
         }

         public static SqlParameter DiaChi
         {
             get
             {
                 return new SqlParameter("@DiaChi", SqlDbType.NVarChar, 300);
             }
         }

     }
     #endregion		
	
	
    }
}
