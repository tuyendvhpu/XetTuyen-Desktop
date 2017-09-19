using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
     class AuthorizationsADO
    {
         private DataTable dataTable = new DataTable();
        
        public AuthorizationsADO()
        {
        }
      

            public  bool Insert(Authorizations Authorizations) {
            SqlCommand cmd = CreateParameters(Authorizations);
            cmd.CommandText = "[proc_t_AuthorizationsInsert]";
            Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public bool Update(Authorizations Authorizations) {
            SqlCommand cmd = CreateParameters(Authorizations);
            cmd.CommandText = "[proc_t_AuthorizationsUpdate]";
            Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
          
        }

        public bool Delete(Guid authorizationID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_AuthorizationsDelete]";

            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.AuthorizationID);
            p.Value = authorizationID;
            Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
            
        }
        public DataTable LoadAll()
        {

            Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_AuthorizationsLoadAll]", Utilities.conDBConnection);
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }
        public DataTable FinAuthorizations(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(Guid authorizationID)
        {


            SqlCommand cmd = new SqlCommand();
            Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_AuthorizationsLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.AuthorizationID;
            p.Value = authorizationID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        
       
	 protected SqlCommand CreateParameters(Authorizations Authorizations)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.AuthorizationID);
            p.Value = Authorizations.AuthorizationID;

            p = cmd.Parameters.Add(Parameters.Description);
            p.Value = Authorizations.Description;

            p = cmd.Parameters.Add(Parameters.MethodFullName);
            p.Value = Authorizations.MethodFullName;

            p = cmd.Parameters.Add(Parameters.ModuleID);
            p.Value = Authorizations.ModuleID;

            p = cmd.Parameters.Add(Parameters.Title);
            p.Value = Authorizations.Title;

            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter AuthorizationID
         {
             get
             {
                 return new SqlParameter("@AuthorizationID", SqlDbType.UniqueIdentifier, 0);
             }
         }

         public static SqlParameter Title
         {
             get
             {
                 return new SqlParameter("@Title", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter Description
         {
             get
             {
                 return new SqlParameter("@Description", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter MethodFullName
         {
             get
             {
                 return new SqlParameter("@MethodFullName", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter ModuleID
         {
             get
             {
                 return new SqlParameter("@ModuleID", SqlDbType.Int, 0);
             }
         }

     }
     #endregion
	
	
    }
}
