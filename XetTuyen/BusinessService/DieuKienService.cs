using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using BusinessService;
using DataAccess;
using Common;
namespace DataAccess
{
    [Authorization]
     public class DieuKienService
    {
         private DataTable dataTable ;

         public DieuKienService()
        {
        }
         public enum DieuKienAction { Insert, Update, Delete }
         public bool IsAuthorized(DieuKienAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case DieuKienAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case DieuKienAction.Update:
                     sMethodName = "Update";
                     break;
                 case DieuKienAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(DieuKienService).GetMethod(sMethodName));
         }
         [MethodDescription(ModuleType.Processing, FormName.DieuKien, FunctionName.Proc_AddDieuKien)]
         public bool Insert(DieuKien DieuKien)
         {
            SqlCommand cmd = CreateParameters(DieuKien);
            cmd.CommandText = "[proc_t_DieuKienInsert]";
           
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
         [MethodDescription(ModuleType.Processing, FormName.DieuKien, FunctionName.Proc_EditDieuKien)]
        public bool Update(DieuKien DieuKien) {
            SqlCommand cmd = CreateParameters(DieuKien);
            cmd.CommandText = "[proc_t_DieuKienUpdate]";
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
         [MethodDescription(ModuleType.Processing, FormName.DieuKien, FunctionName.Proc_DeleteDieuKien)]
        public bool Delete(string idNganh, string maKhoi, string maDot, int nam)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DieuKienDelete]";

            SqlParameter p;

            

            p = Parameters.IDNganh;
            p.Value = idNganh;
            cmd.Parameters.Add(p);

            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            cmd.Parameters.Add(p);

            p = Parameters.MaDot;
            p.Value = maDot;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        /// <summary>
        /// GetListDieuKien
        /// </summary>
        /// <returns>DieuKienCollection</returns>
        public DieuKienCollection GetListDieuKien()
        {
            DieuKienCollection dieuKienCollection = new DieuKienCollection();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_DieuKienLoadAll");

            while (reader.Read())
            {
                DieuKien objDieuKien = new DieuKien();
                objDieuKien.MaDot = reader["MaDot"].ToString();
                objDieuKien.Nam = (int)reader["Nam"];
                objDieuKien.DiemChuan = (double)reader["DiemChuan"];
                objDieuKien.DiemSan = (double)reader["DiemSan"];
                objDieuKien.IDNganh = reader["IDNganh"].ToString();
                objDieuKien.MaNganh = reader["MaNganh"].ToString();
                objDieuKien.MaKhoi = reader["MaKhoi"].ToString();

                dieuKienCollection.Add(objDieuKien);
            }

            //Call Close when done reading.
            reader.Close();

            return dieuKienCollection;
        }

        public DieuKienCollection FinListDieuKien(string sql)
        {
            DieuKienCollection dieuKienCollection = new DieuKienCollection();


           
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommandText();
            SqlDataReader reader = db.ExecuteReader(sql);
            while (reader.Read())
            {
                DieuKien objDieuKien = new DieuKien();
                objDieuKien.MaDot = reader["MaDot"].ToString();
                objDieuKien.Nam = (int)reader["Nam"];
                objDieuKien.DiemChuan = (double)reader["DiemChuan"];
                objDieuKien.DiemSan = (double)reader["DiemSan"];
                objDieuKien.IDNganh = reader["IDNganh"].ToString();
                objDieuKien.MaNganh = reader["MaNganh"].ToString();
                objDieuKien.MaKhoi = reader["MaKhoi"].ToString();

                dieuKienCollection.Add(objDieuKien);
            }
            reader.Close();
            return dieuKienCollection;
        }
        public DataTable LoadAll()
        {

            
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DieuKienLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();

           
            return dataTable;
        }
        public DataTable FinDieuKien(string sql) {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null)  if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// GetDieuKien
        /// </summary>
        /// <returns>DieuKien</returns>
        public DieuKien GetDieuKien(string idNganh, string maKhoi, string maDot, int nam)
        {
            DieuKien objDieuKien = new DieuKien();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;

            p = Parameters.IDNganh;
            p.Value = idNganh;
            db.AddParameter(p);

            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            db.AddParameter(p);

            p = Parameters.MaDot;
            p.Value = maDot;
            db.AddParameter(p);

            p = Parameters.Nam;
            p.Value = nam;
            db.AddParameter(p);

            SqlDataReader reader = db.ExecuteReader("proc_t_DieuKienLoadByPrimaryKey");

            while (reader.Read())
            {
                objDieuKien.MaDot = reader["MaDot"].ToString();
                objDieuKien.Nam = (int)reader["Nam"];
                objDieuKien.DiemChuan = (double)reader["DiemChuan"];
                objDieuKien.DiemSan = (double)reader["DiemSan"];
                objDieuKien.IDNganh = reader["IDNganh"].ToString();
                objDieuKien.MaNganh = reader["MaNganh"].ToString();
                objDieuKien.MaKhoi = reader["MaKhoi"].ToString();

                
            }

            //Call Close when done reading.
            reader.Close();

            return objDieuKien;
        }
        public DataTable LoadByPrimaryKey(string idNganh, string maKhoi, string maDot, int nam)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null)  if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_t_DieuKienLoadByPrimaryKey";

            SqlParameter p;

            p = Parameters.IDNganh;
            p.Value = idNganh;
            cmd.Parameters.Add(p);

            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            cmd.Parameters.Add(p);

            p = Parameters.MaDot;
            p.Value = maDot;
            cmd.Parameters.Add(p);

            p = Parameters.Nam;
            p.Value = nam;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(DieuKien DieuKien)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.DiemChuan);
            p.Value = DieuKien.DiemChuan;

            p = cmd.Parameters.Add(Parameters.DiemSan);
            p.Value = DieuKien.DiemSan;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = DieuKien.IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = DieuKien.MaDot;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = DieuKien.MaKhoi;
            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = DieuKien.MaNganh;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = DieuKien.Nam;
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

         public static SqlParameter MaDot
         {
             get
             {
                 return new SqlParameter("@MaDot", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter Nam
         {
             get
             {
                 return new SqlParameter("@Nam", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter DiemChuan
         {
             get
             {
                 return new SqlParameter("@DiemChuan", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter DiemSan
         {
             get
             {
                 return new SqlParameter("@DiemSan", SqlDbType.Float, 0);
             }
         }

     }
     #endregion
	
    }
}
