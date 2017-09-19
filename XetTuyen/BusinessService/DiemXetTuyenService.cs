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
    public class DiemXetTuyenService
    {
         private DataTable dataTable ;

         public DiemXetTuyenService()
        {
        }
         public enum DiemXetTuyenAction { Insert, Update, Delete }
         public bool IsAuthorized(DiemXetTuyenAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case DiemXetTuyenAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case DiemXetTuyenAction.Update:
                     sMethodName = "Update";
                     break;
                 case DiemXetTuyenAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(DiemXetTuyenService).GetMethod(sMethodName));
         }

         [MethodDescription(ModuleType.Catalogue, FormName.DiemXetTuyen, FunctionName.Cat_AddDienXetTuyen)]
        public  bool Insert(DiemXetTuyen DiemXetTuyen) {


            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(DiemXetTuyen));


                db.ExecuteNonQuery("proc_t_DiemXetTuyenInsert");


                return true;
            }
            catch
            {

                return false;
            }
           
            
        }
         [MethodDescription(ModuleType.Catalogue, FormName.DiemXetTuyen, FunctionName.Cat_EditDienXetTuyen)]
        public bool Update(DiemXetTuyen DiemXetTuyen) {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(DiemXetTuyen));


                db.ExecuteNonQuery("proc_t_DiemXetTuyenUpdate");


                return true;
            }
            catch
            {

                return false;
            }
           
            
          
        }
         public bool UpdateTrungTuyen(long idHS, string MaHS, double diem1, double diem2, double diem3, double diem4, double diem5, double diem6, double diem7, double diem8, double diem9, double diem10, double diem11, double diem12, double diem13, double diem14, double diem15, double diem16, double diem17, double diem18, string makhoi, string khoDK, string idNganh, string maDot, string soQD, int trangThai, int soIn)
         {

             

             try
             {
                 DbAccess db = new DbAccess();
                 db.CreateNewSqlCommand();
                 db.AddParameter("@M1L10HK1",diem1);
                 db.AddParameter("@M1L11HK1", diem2);
                 db.AddParameter("@M1L12HK1", diem3);

                 db.AddParameter("@M1L10HK2", diem4);
                 db.AddParameter("@M1L11HK2", diem5);
                 db.AddParameter("@M1L12HK2", diem6);

                 db.AddParameter("@M2L10HK1", diem7);
                 db.AddParameter("@M2L11HK1", diem8);
                 db.AddParameter("@M2L12HK1", diem9);

                 db.AddParameter("@M2L10HK2", diem10);
                 db.AddParameter("@M2L11HK2", diem11);
                 db.AddParameter("@M2L12HK2", diem12);
                 
                 db.AddParameter("@M3L10HK1", diem13);
                 db.AddParameter("@M3L11HK1", diem14);
                 db.AddParameter("@M3L12HK1", diem15);

                 db.AddParameter("@M3L10HK2", diem16);
                 db.AddParameter("@M3L11HK2", diem17);
                 db.AddParameter("@M3L12HK2", diem18);

                 db.AddParameter("@IdHS", idHS);
                 db.AddParameter("@MaHS", MaHS);
                 db.AddParameter("@Makhoi", makhoi);
                 db.AddParameter("@KhoiDk", khoDK);
                 db.AddParameter("@NganhXT", idNganh);
                 db.AddParameter("@MaDot", maDot);
                 db.AddParameter("@SoQD", soQD);
                 db.AddParameter("@TrangThai", trangThai);
                 db.AddParameter("@SoIn", soIn);
                 db.ExecuteNonQuery("proc_t_TrungTuyenUpdate");


                 return true;
             }
             catch
             {

                 return false;
             }



         }

         public bool UpdateTrungTuyenTrangThai(long idHS, string MaHS,string makhoi,  string idNganh,  int trangThai)
         {



             try
             {
                 DbAccess db = new DbAccess();
                 db.CreateNewSqlCommand();
               

                 db.AddParameter("@IdHS", idHS);
                 db.AddParameter("@MaHS", MaHS);
                 db.AddParameter("@Makhoi", makhoi);
                 
                 db.AddParameter("@NganhXT", idNganh);
               
                
                 db.AddParameter("@TrangThai", trangThai);
                 db.ExecuteNonQuery("proc_t_TrungTuyenUpdateTrangThai");


                 return true;
             }
             catch
             {

                 return false;
             }



         }

         public bool UpdateTrungTuyenSoIn(long idHS, string MaHS, string makhoi, string idNganh, int soIn)
         {



             try
             {
                 DbAccess db = new DbAccess();
                 db.CreateNewSqlCommand();


                 db.AddParameter("@IdHS", idHS);
                 db.AddParameter("@MaHS", MaHS);
                 db.AddParameter("@Makhoi", makhoi);

                 db.AddParameter("@NganhXT", idNganh);


                 db.AddParameter("@SoIn", soIn);
                 db.ExecuteNonQuery("proc_t_TrungTuyenUpdateSoIn");


                 return true;
             }
             catch
             {

                 return false;
             }



         }
         public bool InsertTrungTuyen(long idHS, string MaHS, string maKhoi, double diem1, double diem2, double diem3, double diem4, double diem5, double diem6, double diem7, double diem8, double diem9, double diem10, double diem11, double diem12, double diem13, double diem14, double diem15, double diem16, double diem17, double diem18, string khoiDK, string nganhXT, string maDot, string soQD, int trangThai, int soIn)
         {



             try
             {
                 DbAccess db = new DbAccess();
                 db.CreateNewSqlCommand();
                 db.AddParameter("@M1L10HK1", diem1);
                 db.AddParameter("@M1L11HK1", diem2);
                 db.AddParameter("@M1L12HK1", diem3);

                 db.AddParameter("@M1L10HK2", diem4);
                 db.AddParameter("@M1L11HK2", diem5);
                 db.AddParameter("@M1L12HK2", diem6);

                 db.AddParameter("@M2L10HK1", diem7);
                 db.AddParameter("@M2L11HK1", diem8);
                 db.AddParameter("@M2L12HK1", diem9);

                 db.AddParameter("@M2L10HK2", diem10);
                 db.AddParameter("@M2L11HK2", diem11);
                 db.AddParameter("@M2L12HK2", diem12);

                 db.AddParameter("@M3L10HK1", diem13);
                 db.AddParameter("@M3L11HK1", diem14);
                 db.AddParameter("@M3L12HK1", diem15);

                 db.AddParameter("@M3L10HK2", diem16);
                 db.AddParameter("@M3L11HK2", diem17);
                 db.AddParameter("@M3L12HK2", diem18);

                 db.AddParameter("@IdHS", idHS);
                 db.AddParameter("@MaHS", MaHS);
                 db.AddParameter("@Makhoi", maKhoi);
                 db.AddParameter("@KhoiDk", khoiDK);
                 db.AddParameter("@NganhXT", nganhXT);
                 db.AddParameter("@MaDot", maDot);
                 db.AddParameter("@SoQD ", soQD);
                 db.AddParameter("@TrangThai ", trangThai);
                 db.AddParameter("@SoIn", soIn);

                 db.ExecuteNonQuery("proc_t_TrungTuyenInsert");


                 return true;
             }
             catch
             {

                 return false;
             }



         }

         /// <summary>
         /// GetListDiemXetTuyen
         /// </summary>
         /// <returns>DotXetTuyenCollection</returns>
         public DiemXetTuyenCollection GetListDiemXetTuyen(long idHS)
         {
             DiemXetTuyenCollection diemXetTuyenCollection = new DiemXetTuyenCollection();


             DbAccess db = new DbAccess();
             db.CreateNewSqlCommand();

             SqlParameter p;

             p = Parameters.IDHS;
             p.Value = idHS;
             db.AddParameter(p);

             SqlDataReader reader = db.ExecuteReader("proc_t_DiemXetTuyenLoadByIdHS");

             while (reader.Read())
             {
                 DiemXetTuyen objDiemXetTuyen = new DiemXetTuyen();
                 objDiemXetTuyen.Idhs =long.Parse( reader["Idhs"].ToString());
                 objDiemXetTuyen.MaMon = Convert.ToInt32( reader["MaMon"].ToString());
                 objDiemXetTuyen.Diem = (double)reader["Diem"];
                 objDiemXetTuyen.MaKhoi = reader["MaKhoi"].ToString();

                 diemXetTuyenCollection.Add(objDiemXetTuyen);
             }

             //Call Close when done reading.
             reader.Close();

             return diemXetTuyenCollection;
         }

        public bool DeleteByIdHS(long idHS, Int32 mamon, string makhoi)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = idHS;
                db.AddParameter(p);

                p = Parameters.MaMon;
                p.Value = mamon;
                db.AddParameter(p);

                p = Parameters.MaKhoi;
                p.Value = makhoi;
                db.AddParameter(p);

               

                db.ExecuteNonQuery("proc_t_DiemXetTuyenDelete");


                return true;
            }
            catch
            {

                return false;
            }

           
            
        }
        [MethodDescription(ModuleType.Catalogue, FormName.DiemXetTuyen, FunctionName.Cat_DeleteDienXetTuyen)]
        public bool Delete(long idHS)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;

                p = Parameters.IDHS;
                p.Value = idHS;
                db.AddParameter(p);




               
                db.ExecuteNonQuery("proc_t_DiemXetTuyenDeleteByIdHS");


                return true;
            }
            catch
            {

                return false;
            }

           
           

        }
        public DataTable LoadAll()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_DiemXetTuyenLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            DbConnection.Close();
            return dataTable;
        }
        public DataTable FinDiemXetTuyen(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection =DbConnection.SqlConnection;
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
        public DataTable LoadByIdHS(long idHS)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenLoadByIdHS]";

            SqlParameter p;

            p = Parameters.IDHS;
            p.Value = idHS;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }
        public DataTable LoadByIdHSAndMaKhoi(long idHS,string maKhoi)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_DiemXetTuyenLoadByIdHSAndMaKhoi]";

            SqlParameter p;

            p = Parameters.IDHS;
            p.Value = idHS;
            cmd.Parameters.Add(p);
            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }

        public DiemXetTuyenCollection LoadByIdHSAndMaKhoiCelection(long idHS, string maKhoi)
        {

            DiemXetTuyenCollection objDiemClec = new DiemXetTuyenCollection();
            
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;

            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);
            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_DiemXetTuyenLoadByIdHSAndMaKhoi");
            while (reader.Read())
            {
                DiemXetTuyen objDiemXT = new  DiemXetTuyen();
                objDiemXT.Diem = (double)reader["Diem"];
                objDiemXT.Idhs = (long)reader["Idhs"];
                objDiemXT.MaKhoi = reader["MaKhoi"].ToString();
                objDiemXT.MaMon =(int)reader["MaMon"];
                objDiemClec.Add(objDiemXT);
            }

            //Call Close when done reading.
            reader.Close();

            return objDiemClec;
        }
        public DiemXetTuyen LoadByIdHSAndMaKhoiAndMaMon(long idHS, string maKhoi,int maMon)
        {

            DiemXetTuyen objDiemXT = new DiemXetTuyen();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;

            p = Parameters.IDHS;
            p.Value = idHS;
            db.AddParameter(p);

            p = Parameters.MaKhoi;
            p.Value = maKhoi;
            db.AddParameter(p);

            p = Parameters.MaMon;
            p.Value = maMon;
            db.AddParameter(p);

            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_DiemXetTuyenLoadByIdHSAndMaKhoiAndMaMon");
            while (reader.Read())
            {
                
                objDiemXT.Diem = (double)reader["Diem"];
                objDiemXT.Idhs = (long)reader["Idhs"];
                objDiemXT.MaKhoi = reader["MaKhoi"].ToString();
                objDiemXT.MaMon = (int)reader["MaMon"];
                
            }

            //Call Close when done reading.
            reader.Close();

            return objDiemXT;
        }
       
        public DataTable LoadByByMaKhoiMaNganh(Int64 idHS,string manganh, Int32 mamon, string makhoi, string madot, int nam, string idnganh)
        {


            SqlCommand cmd = new SqlCommand();
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

            p = cmd.Parameters.Add("@MaKhoi", SqlDbType.Int, 0);
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
            dataAdapter.Fill(dataTable);

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
