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
     class HuyenService
    {
         private DataTable dataTable ;

         public HuyenService()
        {
        }
      

        public  bool Insert(Huyen Huyen) {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(Huyen));


                db.ExecuteNonQuery("proc_t_HuyenInsert");


                return true;
            }
            catch
            {

                return false;
            }
            
            
        }
        public bool Update(Huyen Huyen) {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(Huyen));


                db.ExecuteNonQuery("proc_t_HuyenUpdate");


                return true;
            }
            catch
            {

                return false;
            }
            
          
        }
       
        public bool Delete( string MaHuyen)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.MaHuyen;
                p.Value = MaHuyen;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_HuyenDelete");


                return true;
            }
            catch
            {

                return false;
            }

            
            
        }
        public DataTable LoadAll()
        {
            

            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_HuyenLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable FinHuyen(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaHuyen)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaHuyen;
            p.Value = MaHuyen;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string MaHuyen,string MaTinh)
        {


            SqlCommand cmd = new SqlCommand();
         
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByMa]";

            SqlParameter p;

            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);
            
            p = Parameters.MaHuyen;
            p.Value = MaHuyen;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByMaTinh( string MaTinh)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_HuyenLoadByMaTinh]";

            SqlParameter p;

            p = Parameters.MaTinh;
            p.Value = MaTinh;
            cmd.Parameters.Add(p);

          

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(Huyen Huyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaHuyen);
            p.Value = Huyen.MaHuyen;

            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = Huyen.MaTinh;

            p = cmd.Parameters.Add(Parameters.TenHuyen);
            p.Value = Huyen.TenHuyen;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaHuyen
         {
             get
             {
                 return new SqlParameter("@MaHuyen", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter MaTinh
         {
             get
             {
                 return new SqlParameter("@MaTinh", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenHuyen
         {
             get
             {
                 return new SqlParameter("@TenHuyen", SqlDbType.NVarChar, 255);
             }
         }

     }
     #endregion		
	
    }
}
