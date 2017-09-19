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
    class TruongPTService
    {
         private DataTable dataTable ;

         public TruongPTService()
        {
        }
      

        public  bool Insert(TruongPT TruongPT) {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(TruongPT));


                db.ExecuteNonQuery("proc_t_TruongPTInsert");


                return true;
            }
            catch
            {

                return false;
            }
            
            
        }
        public bool Update(TruongPT TruongPT) {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(TruongPT));


                db.ExecuteNonQuery("proc_t_TruongPTUpdate");


                return true;
            }
            catch
            {

                return false;
            }
            
           
          
        }
       
        public bool Delete( string MaTruongPT)
        {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.MaTruong;
                p.Value = MaTruongPT;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_TruongPTDelete");


                return true;
            }
            catch
            {

                return false;
            }
          
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_TruongPTLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable FinTruongPT(string sql) {
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string MaTruongPT)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaTruong;
            p.Value = MaTruongPT;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }

        public DataTable LoadByPrimaryKey(string MaTruongPT,string MaTinh, int nam)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
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
            p.Value = nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByMaTinh( string MaTinh, int nam)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongPTLoadByMaTinh]";

            SqlParameter p;

           
            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);
            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
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

            p = cmd.Parameters.Add(Parameters.MaKV);
            p.Value = TruongPT.MaKV;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = TruongPT.MaTinh;

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = TruongPT.MaTruong;

            p = cmd.Parameters.Add(Parameters.TenTruong);
            p.Value = TruongPT.TenTruong;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = TruongPT.Nam;
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
                 return new SqlParameter("@Nam", SqlDbType.Int);
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
