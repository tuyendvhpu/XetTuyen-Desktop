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
   
    class NhomNganhService
    {
         private DataTable dataTable = new DataTable();

         public NhomNganhService()
        {
        }
      

        public  bool Insert(NhomNganh NhomNganh) {
            SqlCommand cmd = CreateParameters(NhomNganh);
            cmd.CommandText = "[proc_t_NhomNganhInsert]";
     
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(NhomNganh NhomNganh) {
            SqlCommand cmd = CreateParameters(NhomNganh);
            cmd.CommandText = "[proc_t_NhomNganhUpdate]";
            
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaNhomNganh)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomNganhDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = MaNhomNganh;

            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NhomNganhLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        private static NhomNganhCollection m_NhonNganhCollection = null;

        /// <summary>
        /// GetNhomNganhCollectionByLoaiNganh
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static NhomNganhCollection GetNhomNganhCollectionByLoaiNganh(string loaiNganh)
        {
            NhomNganhCollection nhomNganhCollection = new NhomNganhCollection();
            foreach (NhomNganh nhomNganh in NhomNganhCollection)
            {
                if (nhomNganh.LoaiNganh.ToString().Trim().Equals(loaiNganh))
                    nhomNganhCollection.Add(nhomNganh);
            }

            return nhomNganhCollection;
        }

        public static NhomNganhCollection NhomNganhCollection
        {
            get
            {
                if (m_NhonNganhCollection == null)
                {
                    m_NhonNganhCollection = new NhomNganhCollection();
                    try
                    {
                        DbAccess db = new DbAccess();
                        db.CreateNewSqlCommand();
                        SqlDataReader reader = db.ExecuteReader("proc_t_NhomNganhLoadAll");

                        while (reader.Read())
                        {
                            NhomNganh nhomNganh = new NhomNganh();

                            nhomNganh.LoaiNganh = reader["LoaiNganh"].ToString();
                            nhomNganh.MaNganh = reader["MaNganh"].ToString();
                            nhomNganh.MaTruong = reader["MaTruong"].ToString();
                            nhomNganh.TenNganh = reader["TenNganh"].ToString();


                            m_NhonNganhCollection.Add(nhomNganh);
                        }

                        //Call Close when reading done.
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return m_NhonNganhCollection;
            }
            set
            {
                m_NhonNganhCollection = value;
            }
        }
        public DataTable FinNhomNganh(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaNhomNganh)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomNganhLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaNganh;
            p.Value = MaNhomNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByLoaiNganh(string loaiNganh)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NhomNganhLoadByLoaiNganh]";

            SqlParameter p;

            p = Parameters.LoaiNganh;
            p.Value = loaiNganh;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(NhomNganh NhomNganh)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = NhomNganh.MaNganh;

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = NhomNganh.MaTruong;

            p = cmd.Parameters.Add(Parameters.TenNganh);
            p.Value = NhomNganh.TenNganh;

            p = cmd.Parameters.Add(Parameters.LoaiNganh);
            p.Value = NhomNganh.LoaiNganh;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MaNganh
         {
             get
             {
                 return new SqlParameter("@MaNganh", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter MaTruong
         {
             get
             {
                 return new SqlParameter("@MaTruong", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter TenNganh
         {
             get
             {
                 return new SqlParameter("@TenNganh", SqlDbType.NVarChar, 300);
             }
         }
         public static SqlParameter LoaiNganh
         {
             get
             {
                 return new SqlParameter("@LoaiNganh", SqlDbType.NVarChar, 20);
             }
         }

     }
     #endregion		
	
    }
}
