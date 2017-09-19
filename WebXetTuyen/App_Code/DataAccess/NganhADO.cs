using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class NganhADO
    {
         private DataTable dataTable ;
        
        public NganhADO()
        {
        }
      

        public  bool Insert(Nganh Nganh) {
            SqlCommand cmd = CreateParameters(Nganh);
            cmd.CommandText = "[proc_t_NganhInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(Nganh Nganh)
        {
            SqlCommand cmd = CreateParameters(Nganh);
            cmd.CommandText = "[proc_t_NganhUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }

        public bool Delete(string IDNganh, string Makhoi, int Nam)
        {

            SqlCommand cmd = new SqlCommand();
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = Makhoi;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }

        public bool Delete(string IDNganh, int Nam)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhDeleteByIDNganh]";

            SqlParameter p;

          

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NganhLoadAll]", Utilities.conDBConnection);

            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

           
            return dataTable;
        }
        public DataTable FinNganh(string sql) {
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
        public DataTable LoadByPrimaryKey(string IDNganh, string MaKhoi, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaKhoi;
            p.Value = MaKhoi;
            cmd.Parameters.Add(p);

            p = Parameters.IDNganh;
            p.Value = IDNganh;
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
      
        public DataTable LoadGroupIDNganh(int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadAllGroupIDNganh]";

            SqlParameter p;



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

        public DataTable LoadIDNganh(string IDNganh, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadAllIDNganh]";

            SqlParameter p;



            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            p = Parameters.IDNganh;
            p.Value = IDNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByMaNganh (string MaNganh, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadAllMaNganh]";

            SqlParameter p;



            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            p = Parameters.MaNganh;
            p.Value = MaNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadNganh(string MaNganh, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadMaNganh]";

            SqlParameter p;



            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            p = Parameters.MaNganh;
            p.Value = MaNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadKhoiByNganh(string MaNganh, int Nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhLoadKhoiByMaNganh]";

            SqlParameter p;



            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            p = Parameters.MaNganh;
            p.Value = MaNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
	 protected SqlCommand CreateParameters(Nganh Nganh)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = Nganh.MaNganh;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = Nganh.IDNganh;

            p = cmd.Parameters.Add(Parameters.TenNganh);
            p.Value = Nganh.TenNganh;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = Nganh.Nam;
           
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter IDNganh
         {
             get
             {
                 return new SqlParameter("@IDNganh", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter MaNganh
         {
             get
             {
                 return new SqlParameter("@MaNganh", SqlDbType.NVarChar, 20);
             }
         }

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

         public static SqlParameter TenNganh
         {
             get
             {
                 return new SqlParameter("@TenNganh", SqlDbType.NVarChar, 225);
             }
         }

     }
     #endregion				
	
	
    }
}
