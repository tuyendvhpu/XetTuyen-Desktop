using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    class TruongDHADO
    {
         private DataTable dataTable;
        
        public TruongDHADO()
        {
        }
      

        public  bool Insert(TruongDH TruongDH) {
            SqlCommand cmd = CreateParameters(TruongDH);
            cmd.CommandText = "[proc_t_TruongDHInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
     
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            Utilities.conDBConnection.Close();
            return false;
            
        }
        public bool Update(TruongDH TruongDH) {
            SqlCommand cmd = CreateParameters(TruongDH);
            cmd.CommandText = "[proc_t_TruongDHUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string MaTruongDH, int nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_TruongDHDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaTruong);
            p.Value = MaTruongDH;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_TruongDHLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();

           
            return dataTable;
        }
        public DataTable FinTruongDH(string sql) {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
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
        public DataTable LoadByPrimaryKey(string MaTruongDH, int Nam)
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
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
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
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
