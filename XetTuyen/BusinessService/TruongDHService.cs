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
    class TruongDHService
    {
         private DataTable dataTable ;

         public TruongDHService()
        {
        }
      

        public  bool Insert(TruongDH TruongDH) {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(TruongDH));


                db.ExecuteNonQuery("proc_t_TruongDHInsert");


                return true;
            }
            catch
            {

                return false;
            }
            
            
        }
        public bool Update(TruongDH TruongDH) {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(TruongDH));


                db.ExecuteNonQuery("proc_t_TruongDHUpdate");


                return true;
            }
            catch
            {

                return false;
            }
            
            
           
        }
       
        public bool Delete( string MaTruongDH, int nam)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.MaTruong;
                p.Value = MaTruongDH;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_TruongDHDelete");


                return true;
            }
            catch
            {

                return false;
            }
            
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_TruongDHLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        public DataTable FinTruongDH(string sql) {
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
        public DataTable LoadByPrimaryKey(string MaTruongDH, int Nam)
        {

          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongDHLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaTruong;
            p.Value = MaTruongDH;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = Nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(TruongDH TruongDH)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.BoNganh);
            p.Value = TruongDH.BoNganh;

            p = cmd.Parameters.Add(Parameters.DiaChi);
            p.Value = TruongDH.DiaChi;

            p = cmd.Parameters.Add(Parameters.LoaiTruong);
            p.Value = TruongDH.LoaiTruong;


            p = cmd.Parameters.Add(Parameters.MaTinh);
            p.Value = TruongDH.MaTinh;


            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = TruongDH.MaTruong;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = TruongDH.Nam;


            p = cmd.Parameters.Add(Parameters.TenTruong);
            p.Value = TruongDH.TenTruong;

            p = cmd.Parameters.Add(Parameters.ThiDH);
            p.Value = TruongDH.ThiDH;
            p = cmd.Parameters.Add(Parameters.DienThoai);
            p.Value = TruongDH.DienThoai;

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
			
			public static SqlParameter TenTruong
			{
				get
				{
					return new SqlParameter("@TenTruong", SqlDbType.NVarChar, 255);
				}
			}
			
			public static SqlParameter LoaiTruong
			{
				get
				{
					return new SqlParameter("@LoaiTruong", SqlDbType.NVarChar, 20);
				}
			}
			
			public static SqlParameter DiaChi
			{
				get
				{
					return new SqlParameter("@DiaChi", SqlDbType.NVarChar, 300);
				}
			}
			
			public static SqlParameter BoNganh
			{
				get
				{
					return new SqlParameter("@BoNganh", SqlDbType.NVarChar, 255);
				}
			}
			
			public static SqlParameter ThiDH
			{
				get
				{
					return new SqlParameter("@ThiDH", SqlDbType.Bit, 0);
				}
			}
			
			public static SqlParameter Nam
			{
				get
				{
					return new SqlParameter("@Nam", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter DienThoai
			{
				get
				{
					return new SqlParameter("@DienThoai", SqlDbType.NVarChar, 30);
				}
			}
			
		}
		#endregion		
	
    }
}
