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
    public  class CongThucService
    {
        private DataTable dataTable ;

        public CongThucService()
        {
        }
        public enum CongThucAction { Insert, Update, Delete }
        public bool IsAuthorized(CongThucAction action)
        {
            string sMethodName = string.Empty;
            switch (action)
            {
                case CongThucAction.Insert:
                    sMethodName = "Insert";
                    break;
                case CongThucAction.Update:
                    sMethodName = "Update";
                    break;
                case CongThucAction.Delete:
                    sMethodName = "Delete";
                    break;
                //case GroupAction.MultilangUI:
                //    sMethodName = "MultilangUI";
                //    break;
                //case GroupAction.MultilangData:
                //    sMethodName = "MultilangData";
                //    break;
            }

            return SecurityManager.IsAuthorized(typeof(CongThucService).GetMethod(sMethodName));
        }

        [MethodDescription(ModuleType.Processing, FormName.CongThuc, FunctionName.Proc_AddCongThuc)]
        public bool Insert(CongThuc CongThuc)
        {

            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(CongThuc));


                db.ExecuteNonQuery("proc_t_CongThucInsert");


                return true;
            }
            catch
            {

                return false;
            }
           
            
        }
        [MethodDescription(ModuleType.Processing, FormName.CongThuc, FunctionName.Proc_EditCongThuc)]
        public bool Update(CongThuc CongThuc)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(CongThuc));


                db.ExecuteNonQuery("proc_t_CongThucUpdate");


                return true;
            }
            catch
            {

                return false;
            }




        }
        [MethodDescription(ModuleType.Processing, FormName.CongThuc, FunctionName.Proc_DeleteConThuc)]

        public bool Delete(string manganh, string MaMon, string makhoi, int nam, string iDNganh, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = MaMon;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = iDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            cmd.Connection = DbConnection.SqlConnection; 
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;

        }


        public bool DeleteByKhoi(string makhoi, int nam, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByKhoi]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            cmd.Connection = DbConnection.SqlConnection; 
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool DeleteByNganh(string manganh, int nam, string IDNganh, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;

        }

        public bool DeleteByMaNganh(string manganh, int nam, string madot)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucDeleteByMaNganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = nam;



            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;

        }

        /// <summary>
        /// GetListCongThuc
        /// </summary>
        /// <returns>CongThucCollection</returns>
        public CongThucCollection GetListCongThuc()
        {
            CongThucCollection congThucCollection = new CongThucCollection();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_CongThucLoadAll");

            while (reader.Read())
            {
                CongThuc objCongThuc = new CongThuc();
                objCongThuc.MaDot = reader["MaDot"].ToString();
                objCongThuc.Nam = (int)reader["Nam"];
                objCongThuc.HeSo = (double)reader["HeSo"];
                objCongThuc.IDNganh = reader["IDNganh"].ToString();
                objCongThuc.MaNganh = reader["MaNganh"].ToString();
                objCongThuc.MaKHoi = reader["MaKHoi"].ToString();
                objCongThuc.MaMon = reader["MaMon"].ToString();
                congThucCollection.Add(objCongThuc);
            }

            //Call Close when done reading.
            reader.Close();

            return congThucCollection;
        }
         

        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_CongThucLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();

            return dataTable;
        }
        public DataTable FinCongThuc(string sql)
        {
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
        public DataTable LoadyKey(string manganh, string madot, string makhoi, int nam, string IDNganh)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_CongThucLoadByKey]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = manganh;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = madot;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = IDNganh;

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

        public DataTable GetCongThucNam_Dot_IdNganh(int nam, string madot, string IDNganh)
        {


            SqlCommand cmd = new SqlCommand();
           
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_IdNganh]";

            SqlParameter p;

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



        public DataTable GetCongThucNam_Dot_MaNganh(int nam, string madot, string manganh)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_MaNganh]";

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


        public DataTable GetCongThucNam_Dot_Khoi_Nganh(int nam, string madot, string idNganh, string makhoi)
        {


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_Khoi_Nganh]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = idNganh;

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



        public DataTable GetCongThucNam_Dot_Khoi(int nam, string madot,  string makhoi)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GetCongThucNam_Dot_Khoi]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = makhoi;

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

      
        
        
        protected SqlCommand CreateParameters(CongThuc CongThuc)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.HeSo);
            p.Value = CongThuc.HeSo;

            p = cmd.Parameters.Add(Parameters.MaDot);
            p.Value = CongThuc.MaDot;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = CongThuc.MaKHoi;

            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = CongThuc.MaMon;

            p = cmd.Parameters.Add(Parameters.MaNganh);
            p.Value = CongThuc.MaNganh;

            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = CongThuc.Nam;
            p = cmd.Parameters.Add(Parameters.IDNganh);
            p.Value = CongThuc.IDNganh;
           
           
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

            public static SqlParameter IDNganh
            {
                get
                {
                    return new SqlParameter("@IDNganh", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter MaKHoi
            {
                get
                {
                    return new SqlParameter("@MaKHoi", SqlDbType.NVarChar, 20);
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

            public static SqlParameter HeSo
            {
                get
                {
                    return new SqlParameter("@HeSo", SqlDbType.Float, 0);
                }
            }

            public static SqlParameter MaMon
            {
                get
                {
                    return new SqlParameter("@MaMon", SqlDbType.NVarChar, 20);
                }
            }

        }
        #endregion		

    }
}
