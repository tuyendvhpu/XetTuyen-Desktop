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
    public class DoiTuongUTService
    {
         private DataTable dataTable;

         public DoiTuongUTService()
        {
        }
      

        public  bool Insert(DoiTuongUT DoiTuongUT) {
            SqlCommand cmd = CreateParameters(DoiTuongUT);
            cmd.CommandText = "[proc_t_DoiTuongUTInsert]";
           
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            DbConnection.Close();
            return false;
            
        }
        public bool Update(DoiTuongUT DoiTuongUT) {
            SqlCommand cmd = CreateParameters(DoiTuongUT);
            cmd.CommandText = "[proc_t_DoiTuongUTUpdate]";
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            DbConnection.Close();
            return false;
          
        }
       
        public bool Delete( string MaDoiTuongUT)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DoiTuongUTDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaDT);
            p.Value = MaDoiTuongUT;
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DoiTuongUTLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable FinDoiTuongUT(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaDoiTuongUT)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DoiTuongUTLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaDT;
            p.Value = MaDoiTuongUT;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable.Rows.Clear();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }


        /// <summary>
        ///GetKhuVucByID
        /// </summary>
        /// <param name="maKhuVuc"></param>
        /// <returns>KhuVuc object class</returns>
        public DoiTuongUT GetDoiTuongByID(string maDT)
        {
            DoiTuongUT objDoiTuongUT = new DoiTuongUT();
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.MaDT;
            p.Value = maDT;
            db.AddParameter(p);


            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_DoiTuongUTLoadByPrimaryKey");
            if (reader.Read())
            {

                objDoiTuongUT.DiemUT = (double)reader["DiemUT"];

                objDoiTuongUT.MaDT = reader["MaDT"].ToString();
                objDoiTuongUT.MaN = reader["MaN"].ToString();
                objDoiTuongUT.TenDT = reader["TenDT"].ToString();
                objDoiTuongUT.Nam = (int)reader["Nam"];
            }

            //Call Close when done reading.
            reader.Close();

            return objDoiTuongUT;
        }
        public DataTable LoadByNam(int nam)
        {


            SqlCommand cmd = new SqlCommand();
           
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DoiTuongUTLoadByNam]";

            SqlParameter p;

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
        
       
	 protected SqlCommand CreateParameters(DoiTuongUT DoiTuongUT)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.DiemUT);
            p.Value = DoiTuongUT.DiemUT;

            p = cmd.Parameters.Add(Parameters.MaDT);
            p.Value = DoiTuongUT.MaDT;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = DoiTuongUT.Nam;

            p = cmd.Parameters.Add(Parameters.MaN);
            p.Value = DoiTuongUT.MaN;

            p = cmd.Parameters.Add(Parameters.TenDT);
            p.Value = DoiTuongUT.TenDT;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaDT
         {
             get
             {
                 return new SqlParameter("@MaDT", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter MaN
         {
             get
             {
                 return new SqlParameter("@MaN", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenDT
         {
             get
             {
                 return new SqlParameter("@TenDT", SqlDbType.NVarChar, 225);
             }
         }

         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter DiemUT
         {
             get
             {
                 return new SqlParameter("@DiemUT", SqlDbType.Float, 0);
             }
         }

     }
     #endregion		
	
	
    }
}
