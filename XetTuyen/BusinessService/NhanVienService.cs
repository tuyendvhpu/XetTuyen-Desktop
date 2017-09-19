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
    public class NhanVienService
    {
         private DataTable dataTable ;

         public NhanVienService()
        {
        }
      

        public  bool Insert(NhanVien NhanVien) {
            SqlCommand cmd = CreateParameters(NhanVien);
            cmd.CommandText = "[proc_tbl_NhanVienInsert]";
            cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(NhanVien NhanVien) {
            SqlCommand cmd = CreateParameters(NhanVien);
            cmd.CommandText = "[proc_tbl_NhanVienUpdate]";
            
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete(int ID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_tbl_NhanVienDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.ID);
            p.Value = ID;

            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_tbl_NhanVienLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        public DataTable FinNhanVien(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(int ID)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_tbl_NhanVienLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.ID;
            p.Value = ID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByUser(string  taikhoan, string matkhau)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_tbl_NhanVienLoadByUser]";

            SqlParameter[] arrParam = { 
             new SqlParameter("@TaiKhoan", SqlDbType.VarChar,50), 
             new SqlParameter("@Matkhau ", SqlDbType.VarChar,300), 
         
            };
            arrParam[0].Value = taikhoan;
            arrParam[1].Value = matkhau;
            if (arrParam != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(arrParam);
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(NhanVien NhanVien)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params
            p = cmd.Parameters.Add(Parameters.GioiTinh);
            p.Value = NhanVien.GioiTinh;

            p = cmd.Parameters.Add(Parameters.HoTen);
            p.Value = NhanVien.HoTen;

            p = cmd.Parameters.Add(Parameters.ID);
            p.Value = NhanVien.Id;

            p = cmd.Parameters.Add(Parameters.MatKhau);
            p.Value = NhanVien.MatKhau;

            p = cmd.Parameters.Add(Parameters.NgaySinh);
            p.Value = NhanVien.NgaySinh;

            p = cmd.Parameters.Add(Parameters.NgayTao);
            p.Value = NhanVien.NgayTao;

            p = cmd.Parameters.Add(Parameters.Nhom);
            p.Value = NhanVien.Nhom;

            p = cmd.Parameters.Add(Parameters.TaiKhoan);
            p.Value = NhanVien.TaiKhoan;

           
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter ID
         {
             get
             {
                 return new SqlParameter("@ID", SqlDbType.BigInt, 0);
             }
         }

         public static SqlParameter TaiKhoan
         {
             get
             {
                 return new SqlParameter("@TaiKhoan", SqlDbType.VarChar, 50);
             }
         }

         public static SqlParameter MatKhau
         {
             get
             {
                 return new SqlParameter("@MatKhau", SqlDbType.NVarChar, 300);
             }
         }

         public static SqlParameter HoTen
         {
             get
             {
                 return new SqlParameter("@HoTen", SqlDbType.NVarChar, 255);
             }
         }

         public static SqlParameter Nhom
         {
             get
             {
                 return new SqlParameter("@Nhom", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter NgaySinh
         {
             get
             {
                 return new SqlParameter("@NgaySinh", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter NgayTao
         {
             get
             {
                 return new SqlParameter("@NgayTao", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter GioiTinh
         {
             get
             {
                 return new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 50);
             }
         }

     }
     #endregion		
	
    }
}
