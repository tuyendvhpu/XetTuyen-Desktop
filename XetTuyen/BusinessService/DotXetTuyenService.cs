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
    [Authorization]
    public class DotXetTuyenService
    {
         private DataTable dataTable ;
         public enum DotXetTuyenAction { Insert, Update, Delete }
         public bool IsAuthorized(DotXetTuyenAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case DotXetTuyenAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case DotXetTuyenAction.Update:
                     sMethodName = "Update";
                     break;
                 case DotXetTuyenAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(DotXetTuyenService).GetMethod(sMethodName));
         }
         public DotXetTuyenService()
        {
        }
         

         [MethodDescription(ModuleType.Catalogue, FormName.DotXetTuyen, FunctionName.Cat_AddDotXetTuyen)]
        public  bool Insert(DotXetTuyen DotXetTuyen) {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(DotXetTuyen));


                db.ExecuteNonQuery("proc_t_DotXetTuyenInsert");


                return true;
            }
            catch
            {

                return false;
            }
            
            
        }
         [MethodDescription(ModuleType.Catalogue, FormName.DotXetTuyen, FunctionName.Cat_EditDotXetTuyen)]
        public bool Update(DotXetTuyen DotXetTuyen) {

            DbAccess db = new DbAccess();

            try
            {
             
                db.CreateNewSqlCommand(CreateParameters(DotXetTuyen));

                db.ExecuteNonQuery("proc_t_DotXetTuyenUpdate");


                return true;
            }
            catch
            {

                return false;
            }
            
           
          
        }
         [MethodDescription(ModuleType.Catalogue, FormName.DotXetTuyen, FunctionName.Cat_DeleteDotXetTuyen)]
        public bool Delete( string MaDotXetTuyen, int Nam)
        {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.MaDot;
                p.Value = MaDotXetTuyen;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = Nam;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_DotXetTuyenDelete");


                return true;
            }
            catch
            {

                return false;
            }
            
            
        }
         /// <summary>
         /// GetListDotXetTuyen
         /// </summary>
         /// <returns>DotXetTuyenCollection</returns>
         public DotXetTuyenCollection GetListDotXetTuyen()
         {
             DotXetTuyenCollection dotXetTuyenCollection = new DotXetTuyenCollection();


             DbAccess db = new DbAccess();
             db.CreateNewSqlCommand();
             SqlDataReader reader = db.ExecuteReader("proc_t_DotXetTuyenLoadAll");

             while (reader.Read())
             {
                 DotXetTuyen objDotXetTuyen = new DotXetTuyen();
                 objDotXetTuyen.MaDot = reader["MaDot"].ToString();
                 objDotXetTuyen.Nam = (int) reader["Nam"];
                 objDotXetTuyen.NgayBD = (DateTime)reader["NgayBD"];
                 objDotXetTuyen.NgayKT = (DateTime)reader["NgayKT"];
                 objDotXetTuyen.TenDot = reader["TenDot"].ToString();
                 dotXetTuyenCollection.Add(objDotXetTuyen);
             }

             //Call Close when done reading.
             reader.Close();

             return dotXetTuyenCollection;
         }
         /// <summary>
         ///GetDotXetTuyenByID
         /// </summary>
         /// <param name="MaDot"></param>
         /// <returns>DotXetTuyen object class</returns>
         public DotXetTuyen GetDotXetTuyenByID(string MaDot, int Nam)
         {
             DotXetTuyen objDotXetTuyen = new DotXetTuyen();
             DbAccess db = new DbAccess();
            
             db.CreateNewSqlCommand();
             SqlParameter p;
             p = Parameters.MaDot;
             p.Value = MaDot;
             db.AddParameter(p);
             p = Parameters.Nam;
             p.Value = Nam;
             db.AddParameter(p);
             System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_DotXetTuyenLoadByPrimaryKey");
             if (reader.Read())
             {
                
                 objDotXetTuyen.MaDot = reader["MaDot"].ToString();
                 objDotXetTuyen.Nam = (int)reader["Nam"];
                 objDotXetTuyen.NgayBD = (DateTime)reader["NgayBD"];
                 objDotXetTuyen.NgayKT = (DateTime)reader["NgayKT"];
                 objDotXetTuyen.TenDot = reader["TenDot"].ToString();

                

             }

             //Call Close when done reading.
             reader.Close();

             return objDotXetTuyen;
         }


        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DotXetTuyenLoadAll]", DbConnection.SqlConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }
        public DataTable FinDotXetTuyen(string sql) {
           
           
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
        public DataTable LoadByPrimaryKey(string MaDotXetTuyen, int nam)
        {

           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MaDot;
            p.Value = MaDotXetTuyen;
            cmd.Parameters.Add(p);

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

        public DataTable LoadByNam(int nam)
        {

            
         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByNam]";

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
        public DataTable LoadByDate(DateTime ngay)
        {

            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DotXetTuyenLoadByDate]";

            SqlParameter p;

            p = new SqlParameter("@Ngay", SqlDbType.DateTime, 0); ;
            p.Value = ngay;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(DotXetTuyen DotXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = DotXetTuyen.MaDot;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = DotXetTuyen.Nam;

            p = cmd.Parameters.Add(Parameters.NgayBD);
            p.Value = DotXetTuyen.NgayBD;

            p = cmd.Parameters.Add(Parameters.NgayKT);
            p.Value = DotXetTuyen.NgayKT;
            p = cmd.Parameters.Add(Parameters.TenDot);
            p.Value = DotXetTuyen.TenDot;
            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

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

         public static SqlParameter NgayBD
         {
             get
             {
                 return new SqlParameter("@NgayBD", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter NgayKT
         {
             get
             {
                 return new SqlParameter("@NgayKT", SqlDbType.DateTime, 0);
             }
         }
         public static SqlParameter TenDot
         {
             get
             {
                 return new SqlParameter("@TenDot", SqlDbType.NVarChar, 50);
             }
         }
     }
     #endregion		
	
    }
}
