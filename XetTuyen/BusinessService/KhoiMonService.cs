using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using BusinessService;
using Common;
using DataAccess;

namespace BusinessService
{
    public class KhoiMonService
    {
        private DataTable dataTable;

        public KhoiMonService()
        {
        }


        public bool Insert(KhoiMon KhoiMon)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(KhoiMon));


                db.ExecuteNonQuery("proc_t_KhoiMonInsert");


                return true;
            }
            catch
            {

                return false;
            }
            

        }
        public bool Update(KhoiMon KhoiMon)
        {
            DbAccess db = new DbAccess();

            try
            {
                db.CreateNewSqlCommand(CreateParameters(KhoiMon));


                db.ExecuteNonQuery("proc_t_KhoiMonUpdate");


                return true;
            }
            catch
            {

                return false;
            }
            
            

        }

        public bool Delete(int Nam, string Makhoi)
        {

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                SqlParameter p;

                p = Parameters.Nam;
                p.Value = Nam;
                db.AddParameter(p);
                p = Parameters.MaKHoi;
                p.Value = Makhoi;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_KhoiMonDelete");
                return true;
            }
            catch
            {
                return false;
            }


         

        }



        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_KhoiMonLoadAll]",DbConnection.SqlConnection);
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();

            return dataTable;
        }
        public DataTable FinKhoiMon(string sql)
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
        public DataTable LoadByPrimaryKey(int Nam, string MaKhoi)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiMonLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = MaKhoi;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }

        public DataTable LoadTenMonByPrimaryKey(int Nam, string MaKhoi)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_KhoiTenMonLoadByPrimaryKey]";

            SqlParameter p;


            p = cmd.Parameters.Add(Parameters.Nam);
            p.Value = Nam;

            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = MaKhoi;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }

        protected SqlCommand CreateParameters(KhoiMon KhoiMon)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            


            p = cmd.Parameters.Add(Parameters.MaKHoi);
            p.Value = KhoiMon.MaKHoi;
            p = cmd.Parameters.Add(Parameters.MaMon);
            p.Value = KhoiMon.Nam;
            p = cmd.Parameters.Add(Parameters.ViTri);
            p.Value = KhoiMon.ViTri;

            return cmd;
        }
        #region Parameters
        protected class Parameters
        {

            public static SqlParameter MaKHoi
            {
                get
                {
                    return new SqlParameter("@MaKHoi", SqlDbType.NVarChar, 20);
                }
            }

            public static SqlParameter Nam
            {
                get
                {
                    return new SqlParameter("@Nam", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter MaMon
            {
                get
                {
                    return new SqlParameter("@MaMon", SqlDbType.NVarChar, 20);
                }
            }
            public static SqlParameter ViTri
            {
                get
                {
                    return new SqlParameter("@ViTri",SqlDbType.Int,0);
                }
            }

        }
        #endregion		


    }
}
