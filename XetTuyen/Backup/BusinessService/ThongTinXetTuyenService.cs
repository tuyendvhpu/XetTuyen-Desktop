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
     class ThongTinXetTuyenService
    {
         private DataTable dataTable ;

         public ThongTinXetTuyenService()
        {
        }
         public enum ThongTinXetTuyenAction {  LoadALL }
         public bool IsAuthorized(ThongTinXetTuyenAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {


                 case ThongTinXetTuyenAction.LoadALL:
                     sMethodName = "LoadALL";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(ThongTinXetTuyenService).GetMethod(sMethodName));
         }

         public bool Insert(ThongTinXetTuyen ThongTinXetTuyen)
         {
            SqlCommand cmd = CreateParameters(ThongTinXetTuyen);
            cmd.CommandText = "[proc_t_ThongTinXetTuyenInsert]";
           
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(ThongTinXetTuyen ThongTinXetTuyen) {
            SqlCommand cmd = CreateParameters(ThongTinXetTuyen);
            cmd.CommandText = "proc_t_ThongTinXetTuyenUpdate]";
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }
       
        public bool Delete( string soQD, string status)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_ThongTinXetTuyenDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.SoQD);
            p.Value = soQD;

            p = cmd.Parameters.Add(Parameters.Status);
            p.Value = status;
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        [MethodDescription(ModuleType.Processing, FormName.TTXetTuyen, FunctionName.Proc_ViewdTTXetTuyen)]
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_ThongTinXetTuyenLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            DbConnection.Close();

           
            return dataTable;
        }
        public DataTable FinThongTinXetTuyen(string sql) {
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
        public DataTable LoadByPrimaryKey(string soQD, string status)
        {


            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null)  if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_ThongTinXetTuyenLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.SoQD;
            p.Value = soQD;
            cmd.Parameters.Add(p);

            p = Parameters.Status;
            p.Value = status;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(ThongTinXetTuyen ThongTinXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.CreatedDate);
            p.Value = ThongTinXetTuyen.CreatedDate;

            p = cmd.Parameters.Add(Parameters.LoginID);
            p.Value = ThongTinXetTuyen.LoginID;

            p = cmd.Parameters.Add(Parameters.MaHS);
            p.Value = ThongTinXetTuyen.MaHS;

            p = cmd.Parameters.Add(Parameters.SoQD);
            p.Value = ThongTinXetTuyen.SoQD;


            p = cmd.Parameters.Add(Parameters.Status);
            p.Value = ThongTinXetTuyen.Status;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter SoQD
         {
             get
             {
                 return new SqlParameter("@SoQD", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter Status
         {
             get
             {
                 return new SqlParameter("@Status", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter MaHS
         {
             get
             {
                 return new SqlParameter("@MaHS", SqlDbType.NVarChar, 20);
             }
         }

         public static SqlParameter LoginID
         {
             get
             {
                 return new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
             }
         }

         public static SqlParameter CreatedDate
         {
             get
             {
                 return new SqlParameter("@CreatedDate", SqlDbType.DateTime, 0);
             }
         }

     }
     #endregion
	
	
    }
}
