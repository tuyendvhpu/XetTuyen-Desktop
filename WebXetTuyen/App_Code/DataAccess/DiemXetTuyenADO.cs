using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
    public class DiemXetTuyenADO
    {
         private DataTable dataTable ;
        
        public DiemXetTuyenADO()
        {
           
           
        }
      

        public  bool Insert(DiemXetTuyen DiemXetTuyen) {
            SqlCommand cmd = CreateParameters(DiemXetTuyen);
            cmd.CommandText = "[proc_t_DiemXetTuyenInsert]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(DiemXetTuyen DiemXetTuyen) {
            SqlCommand cmd = CreateParameters(DiemXetTuyen);
            cmd.CommandText = "[proc_t_DiemXetTuyenUpdate]";
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete(Int64 idHS, int mamon,string makhoi)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;
            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = mamon;
            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = makhoi;
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            Utilities.conDBConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Delete(Int64 idHS)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenDeleteByIdHS]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DiemXetTuyenLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable FinDiemXetTuyen(string sql) {
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
        public DataTable LoadByIdHS(Int64 idHS)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenLoadByIdHS]";

            SqlParameter p;

            p = Parameters.IDHS;
            p.Value = idHS;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
        public DataTable LoadByByMaKhoiMaNganh(Int64 idHS,string manganh, int mamon, string makhoi, string madot, int nam, string idnganh)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenLoadByMaKhoiMaNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            p = cmd.Parameters.Add("@MaNganh", SqlDbType.NVarChar, 20);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = mamon;

            p = cmd.Parameters.Add("@MaKhoi", SqlDbType.NVarChar, 20);
            p.Value = makhoi;
          
            p = cmd.Parameters.Add("@MaDot", SqlDbType.NVarChar, 20);
            p.Value = madot;

            p = cmd.Parameters.Add("@Nam", SqlDbType.Int, 0);
            p.Value = nam;

            p = cmd.Parameters.Add("@IDNganh", SqlDbType.NVarChar, 20);
            p.Value = idnganh;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(DiemXetTuyen DiemXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = DiemXetTuyen.Idhs;

            p = cmd.Parameters.Add(Parameters.Diem);
            p.Value = DiemXetTuyen.Diem;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = DiemXetTuyen.MaMon;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = DiemXetTuyen.MaKhoi;

           
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter IDHS
         {
             get
             {
                 return new SqlParameter("@IDHS", SqlDbType.BigInt, 0);
             }
         }

         public static SqlParameter MaMon
         {
             get
             {
                 return new SqlParameter("@MaMon", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter Diem
         {
             get
             {
                 return new SqlParameter("@Diem", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter MaKhoi
         {
             get
             {
                 return new SqlParameter("@MaKhoi", SqlDbType.NVarChar, 20);
             }
         }

     }
     #endregion	
	
    }
}
