using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class KhuVucADO
    {
         private DataTable dataTable ;
        
        public KhuVucADO()
        {
        }
      

        public  bool Insert(KhuVuc KhuVuc) {
            SqlCommand cmd = CreateParameters(KhuVuc);
            cmd.CommandText = "[proc_t_KhuVucInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();

            if (i != 0) return true;
            return false;
            
        }
        public bool Update(KhuVuc KhuVuc) {
            SqlCommand cmd = CreateParameters(KhuVuc);
            cmd.CommandText = "[proc_t_KhuVucUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();

            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaKhuVuc)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhuVucDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKV);
            p.Value = MaKhuVuc;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();

            if (i != 0) return true;
            return false;
            
        }
        public KhuVuc GetKhuVucByID(string maKV)
        {
            KhuVuc objKhuVuc = new KhuVuc();
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.MaKV;
            p.Value = maKV;
            db.AddParameter(p);


            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_KhuVucLoadByPrimaryKey");
            if (reader.Read())
            {

                objKhuVuc.DienUT = (double)reader["DienUT"];

                objKhuVuc.MaKV = reader["MaKV"].ToString();
                objKhuVuc.TenKV = reader["TenKV"].ToString();

                objKhuVuc.Nam = (int)reader["Nam"];
            }

            //Call Close when done reading.
            reader.Close();

            return objKhuVuc;
        }
        public DataTable LoadAll()
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_KhuVucLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinKhuVuc(string sql) {
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

        public DataTable LoadByPrimaryKey(string MaKhuVuc)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhuVucLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaKV;
            p.Value = MaKhuVuc;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(KhuVuc KhuVuc)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.DienUT);
            p.Value = KhuVuc.DienUT;

            p = cmd.Parameters.Add(Parameters.MaKV);
            p.Value = KhuVuc.MaKV;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = KhuVuc.Nam;
            p = cmd.Parameters.Add(Parameters.TenKV);
            p.Value = KhuVuc.TenKV;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaKV
         {
             get
             {
                 return new SqlParameter("@MaKV", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenKV
         {
             get
             {
                 return new SqlParameter("@TenKV", SqlDbType.NVarChar, 225);
             }
         }

         public static SqlParameter DienUT
         {
             get
             {
                 return new SqlParameter("@DienUT", SqlDbType.Float, 0);
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
