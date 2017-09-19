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
    public class NganhXetTuyenService
    {
        private DataTable dataTable;
         public enum NganhXetTuyenAction { Insert, Update, Delete }
         public bool IsAuthorized(NganhXetTuyenAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case NganhXetTuyenAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case NganhXetTuyenAction.Update:
                     sMethodName = "Update";
                     break;
                 case NganhXetTuyenAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(NganhXetTuyenService).GetMethod(sMethodName));
         }

         public NganhXetTuyenService()
        {
        }

         [MethodDescription(ModuleType.Catalogue, FormName.NganhXetTuyen, FunctionName.Cat_AddNganhXetTuyen)]
         public bool Insert(NganhXetTuyen NganhXetTuyen)
         {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(NganhXetTuyen));


                db.ExecuteNonQuery("proc_t_NganhXetTuyenInsert");


                return true;
            }
            catch
            {

                return false;
            }

            
            
        }
         [MethodDescription(ModuleType.Catalogue, FormName.NganhXetTuyen, FunctionName.Cat_EditNganhXetTuyen)]
         public bool Update(NganhXetTuyen NganhXetTuyen)
         {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(NganhXetTuyen));


                db.ExecuteNonQuery("proc_t_NganhXetTuyenUpdate");


                return true;
            }
            catch
            {

                return false;
            }

            
           
          
        }
        public bool UpdateDiemTB(long IDHS,  string makhoi, string madot, int nam, string IDNganh,float diemTB,int heso)
        {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = IDHS;
                db.AddParameter(p);

                p = Parameters.MaKhoi;
                p.Value = makhoi;
                db.AddParameter(p);

                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

                p = Parameters.IDNganh;
                p.Value =IDNganh;

                p = Parameters.DiemTB;
                p.Value = diemTB;
                db.AddParameter(p);
               
                p = new SqlParameter("@HeSo", SqlDbType.TinyInt, 0);
                p.Value = heso;
                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_NganhXetTuyenUpdateDiem");


                return true;
            }
            catch
            {

                return false;
            }

           

        }
        public bool UpdateTrangThai(long IDHS, string makhoi, string madot, int nam, string IDNganh, int trangThai)
        {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = IDHS;
                db.AddParameter(p);

                p = Parameters.MaKhoi;
                p.Value = makhoi;
                db.AddParameter(p);

                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

                p = Parameters.IDNganh;
                p.Value = IDNganh;
                db.AddParameter(p);

                p = Parameters.TrangThai;
                p.Value = trangThai;
                db.AddParameter(p);


                db.ExecuteNonQuery("proc_t_NganhXetTuyenUpdateTrangThai");


                return true;
            }
            catch
            {

                return false;
            }



        }
        [MethodDescription(ModuleType.Catalogue, FormName.NganhXetTuyen, FunctionName.Cat_DeleteNganhXetTuyen)]
        public bool Delete(long IDHS, string manganh, string makhoi, string madot, int nam, string IDNganh)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = IDHS;
                db.AddParameter(p);
               
                p = Parameters.MaNganh;
                p.Value = manganh;
                db.AddParameter(p);

                p = Parameters.MaKhoi;
                p.Value = makhoi;
                db.AddParameter(p);

                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

                p = Parameters.IDNganh;
                p.Value = IDNganh;
                
               
                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_NganhXetTuyenDelete");


                return true;
            }
            catch
            {

                return false;
            }

           
            
            
        }
       
        public bool DeleteByIDHS(Int64 IDHS,  string madot, int nam)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = IDHS;
                db.AddParameter(p);

               

                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

              


                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_NganhXetTuyenDeleteByID");


                return true;
            }
            catch
            {

                return false;
            }

           
            
            

        }
       
        public bool DeleteByMaNganh(string manganh,  string madot, int nam)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.MaNganh;
                p.Value = manganh;
                db.AddParameter(p);



                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);




                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_NganhXetTuyenDeleteByMaNganh");


                return true;
            }
            catch
            {

                return false;
            }
           

        }
       
        public bool DeleteByMaNganh( string manganh, string madot, int nam, string IDNganh)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.MaNganh;
                p.Value = manganh;
                db.AddParameter(p);



                p = Parameters.MaDot;
                p.Value = madot;
                db.AddParameter(p);

                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

                p = Parameters.IDNganh;
                p.Value = IDNganh;
                db.AddParameter(p);


                db.AddParameter(p);

                db.ExecuteNonQuery("proc_t_NganhXetTuyenDeleteByNganh");


                return true;
            }
            catch
            {

                return false;
            }


            

        }
       
        public bool DeleteByIDHS( long idHS, int nam)
        {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value =idHS;
                db.AddParameter(p);



                p = Parameters.Nam;
                p.Value = nam;
                db.AddParameter(p);

                

             

                db.ExecuteNonQuery("proc_t_NganhXetTuyenDeleteByIDHS");


                return true;
            }
            catch
            {

                return false;
            }


            

        }
        
        public DataTable LoadAll()
        {

             if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_NganhXetTuyenLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }

        
        public DataTable FinNganhXetTuyen(string sql) {
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByIDHS(long idHS, string madot, int nam)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByIDHS]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public NganhXetTuyen LoadNganhXTByIDHS(long idHS, string maNganh,string maKhoi,string IDNganh, string madot, int nam)
        {

            NganhXetTuyen objNganhXetTuyen = new NganhXetTuyen();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);

            p = Parameters.MaNganh;
            p.Value = maNganh;
            db.AddParameter(p);

            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            db.AddParameter(p);

            p = Parameters.IDNganh;
            p.Value = IDNganh;
            db.AddParameter(p);

            p = Parameters.MaDot;
            p.Value = madot;
            db.AddParameter(p);

            p = Parameters.Nam;
            p.Value = nam;
            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_NganhXetTuyenLoadByKey");
            if (reader.Read())
            {
               
                objNganhXetTuyen.DiemTB = (double)reader["DiemTB"];
                objNganhXetTuyen.DiemTXT = (double)reader["DiemTXT"];
                objNganhXetTuyen.DiemUTDT = (double)reader["DiemUTDT"];
                objNganhXetTuyen.DiemUTKV = (double)reader["DiemUTKV"];
                objNganhXetTuyen.Idhs = (long)reader["Idhs"];
                objNganhXetTuyen.IDNganh = reader["IDNganh"].ToString();
                objNganhXetTuyen.MaDot = reader["MaDot"].ToString();
                objNganhXetTuyen.MaKhoi = reader["MaKhoi"].ToString();
                objNganhXetTuyen.MaNganh = reader["MaNganh"].ToString();
                objNganhXetTuyen.Nam = (int)reader["Nam"];
                objNganhXetTuyen.TrangThai = (int)reader["TrangThai"];
               
            }

            //Call Close when done reading.
            reader.Close();

            return objNganhXetTuyen;


        }


        /// <summary>
        ///GetNganhXetTuyenByID
        /// </summary>
        /// <param name="MaDot"></param>
        /// <returns>HoSo object class</returns>
        public NganhXetTuyenCollection GetNganhXetTuyenByID(long idHS)
        {
            NganhXetTuyenCollection nganhXTColection = new NganhXetTuyenCollection();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);
           

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_NganhXetTuyenLoadByID");
            while (reader.Read())
            {
                NganhXetTuyen objNganhXetTuyen = new NganhXetTuyen();
                objNganhXetTuyen.DiemTB = (double)reader["DiemTB"];
                objNganhXetTuyen.DiemTXT = (double)reader["DiemTXT"];
                objNganhXetTuyen.DiemUTDT = (double)reader["DiemUTDT"];
                objNganhXetTuyen.DiemUTKV = (double)reader["DiemUTKV"];
                objNganhXetTuyen.Idhs = (long)reader["Idhs"];
                objNganhXetTuyen.IDNganh = reader["IDNganh"].ToString();
                objNganhXetTuyen.MaDot = reader["MaDot"].ToString();
                objNganhXetTuyen.MaKhoi = reader["MaKhoi"].ToString();
                objNganhXetTuyen.MaNganh = reader["MaNganh"].ToString();
                objNganhXetTuyen.Nam = (int)reader["Nam"];
                objNganhXetTuyen.TrangThai = (int)reader["TrangThai"];
                nganhXTColection.Add(objNganhXetTuyen);
            }

            //Call Close when done reading.
            reader.Close();

            return nganhXTColection;
        }

        public DataTable LoadByIDHS(long idHS)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByID]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
           
            return dataTable;
        }
        
        /// <summary>
        ///GetListNganhXetTuyenByID
        /// </summary>
        /// <param name="MaDot"></param>
        /// <returns>HoSo object class</returns>
        public NganhXetTuyenCollection GetNganhXetTuyenByID(Int64 idHS, string madot, int nam)
        {
            NganhXetTuyenCollection nganhXTCollection = new NganhXetTuyenCollection();
            DbAccess db = new DbAccess();

            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);
            p = Parameters.MaDot;
            p.Value = madot;
            db.AddParameter(p);
            p = Parameters.Nam;
            p.Value = nam;
            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_NganhXetTuyenLoadByIDHS");
            while (reader.Read())
            {
                NganhXetTuyen objNganhXetTuyen = new NganhXetTuyen();
                objNganhXetTuyen.DiemTB = (double)reader["DiemTB"];
                objNganhXetTuyen.DiemTXT = (double)reader["DiemTXT"];
                objNganhXetTuyen.DiemUTDT = (double)reader["DiemUTDT"];
                objNganhXetTuyen.DiemUTKV = (double)reader["DiemUTKV"];
                objNganhXetTuyen.Idhs = (long)reader["Idhs"];
                objNganhXetTuyen.IDNganh = reader["IDNganh"].ToString();
                objNganhXetTuyen.MaDot = reader["MaDot"].ToString();
                objNganhXetTuyen.MaKhoi = reader["MaKhoi"].ToString();
                objNganhXetTuyen.MaNganh = reader["MaNganh"].ToString();
                objNganhXetTuyen.Nam = (int)reader["Nam"];
                objNganhXetTuyen.TrangThai = (int)reader["TrangThai"];
                nganhXTCollection.Add(objNganhXetTuyen);
            }

            //Call Close when done reading.
            reader.Close();

            return nganhXTCollection;
        }

        public DataTable LoadByNganh(string manganh, string madot, int nam )
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByIDNganh(string manganh,string IDNganh, string madot, int nam)
        {


            SqlCommand cmd = new SqlCommand();
         
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_NganhXetTuyenLoadByIDNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;
           
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }


        public DataTable LoadMonXetTuyen( long idHS, int nam)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_LoadMonHoso]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = idHS;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(NganhXetTuyen NganhXetTuyen)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.IDHS);
            p.Value = NganhXetTuyen.Idhs;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = NganhXetTuyen.MaDot;

            p = cmd.Parameters.Add(Parameters.MaKhoi);
            p.Value = NganhXetTuyen.MaKhoi;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = NganhXetTuyen.MaNganh;
            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = NganhXetTuyen.Nam;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = NganhXetTuyen.IDNganh;

            p = cmd.Parameters.Add(Parameters.DiemTB);
            p.Value = NganhXetTuyen.DiemTB;

            p = cmd.Parameters.Add(Parameters.DiemTXT);
            p.Value = NganhXetTuyen.DiemTXT;


            p = cmd.Parameters.Add(Parameters.DiemUTDT);
            p.Value = NganhXetTuyen.DiemUTDT;
            
            p = cmd.Parameters.Add(Parameters.DiemUTKV);
            p.Value = NganhXetTuyen.DiemUTKV;

            p = cmd.Parameters.Add(Parameters.TrangThai);
            p.Value = NganhXetTuyen.TrangThai;

            p = cmd.Parameters.Add(Parameters.NgayDK);
            p.Value = NganhXetTuyen.NgayDK;

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

         public static SqlParameter DiemTB
         {
             get
             {
                 return new SqlParameter("@DiemTB", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter DiemUTKV
         {
             get
             {
                 return new SqlParameter("@DiemUTKV", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter DiemUTDT
         {
             get
             {
                 return new SqlParameter("@DiemUTDT", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter DiemTXT
         {
             get
             {
                 return new SqlParameter("@DiemTXT", SqlDbType.Float, 0);
             }
         }

         public static SqlParameter TrangThai
         {
             get
             {
                 return new SqlParameter("@TrangThai", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter NgayDK
         {
             get
             {
                 return new SqlParameter("@NgayDK", SqlDbType.DateTime, 0);
             }
         }

     }
     #endregion
    }
}
