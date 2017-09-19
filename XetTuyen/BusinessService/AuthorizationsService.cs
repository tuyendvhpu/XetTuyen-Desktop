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
    class AuthorizationsService

    {
        public enum Action { Update, MultilangUI, MultilangData }
        public bool IsAuthorized(Action action)
        {
            string sMethodName = string.Empty;
            switch (action)
            {
                case Action.Update:
                    sMethodName = "AddOrUpdate";
                    break;
                //case Action.MultilangUI:
                //    sMethodName = "MultilangUI";
                //    break;
                //case Action.MultilangData:
                //    sMethodName = "MultilangData";
                //    break;
            }

            return SecurityManager.IsAuthorized(typeof(AuthorizationsService).GetMethod(sMethodName));
        }
        private static AuthorizationCollection m_AuthCollection = null;
        private DataTable dataTable = new DataTable();
       
         public AuthorizationsService()
        {
        }
      

        public  bool Insert(Authorizations Authorizations) {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Authorizations));


                db.ExecuteNonQueryWithTransaction("proc_t_AuthorizationsInsert");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
         
   
        }
        public bool Insert(Authorizations Authorizations, DbAccess db)
        {
            
            
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Authorizations));


                db.ExecuteNonQueryWithTransaction("proc_t_AuthorizationsInsert");

               
                return true;
            }
            catch
            {
               
                return false;
            }



        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        public bool Update(Authorizations Authorizations, DbAccess db)
        {

            
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Authorizations));
                db.ExecuteNonQueryWithTransaction("proc_t_AuthorizationsUpdate");

                
                return true;
            }
            catch
            {
                
                return false;
            }
            
          
        }
     
        public bool Delete(Guid AuthorizationsID)
        {

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@AuthorizationsID", AuthorizationsID);

                db.ExecuteNonQuery("proc_t_AuthorizationsDelete");
                return true;
            }
            catch
            {
                return false;
            }

      
           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_AuthorizationsLoadAll]", Utilities.conDBConnection);
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }


        public DataTable FinAuthorizations(string sql) {
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(Guid AuthorizationsID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_AuthorizationsLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.AuthorizationID;
            p.Value = AuthorizationsID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

     



        [MethodDescription(ModuleType.Administration, FormName.AUTHORIZATION, FunctionName.SC_AddOrEditAuthorization)]
        public void AddOrUpdate(Authorizations authorization, DbAccess db)
        {
            Authorizations existingAuth = FetchByMethodFullNameWithOpenningConnection(authorization.MethodFullName, db);
            if (existingAuth == null)
            {
                authorization.AuthorizationID = Guid.NewGuid();

                Insert(authorization, db);
            }
            else
            {
                authorization.AuthorizationID = existingAuth.AuthorizationID;

                Update(authorization, db);
            }
        }

        /// <summary>
        /// FetchByMethodFullName
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        public Authorizations FetchByMethodFullName(string sMethodFullName)
        {
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@MethodFullName", sMethodFullName);

            SqlDataReader reader = db.ExecuteReader("spAuthorization_FetchByMethodFullName");

            Authorizations objAuthorization = null;
            if (reader.Read())
            {
                objAuthorization = new Authorizations();

                objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                objAuthorization.Title = reader["Title"].ToString();
                objAuthorization.Description = reader["Description"].ToString();
                objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
                objAuthorization.ModuleID = (int)reader["ModuleID"];
            }

            // Call Close when reading done.
            reader.Close();

            return objAuthorization;
        }

        /// <summary>
        /// FetchByMethodFullNameWithOpenningConnection
        /// </summary>
        /// <param name="sMethodFullName"></param>
        /// <returns></returns>
        public Authorizations FetchByMethodFullNameWithOpenningConnection(string sMethodFullName, DbAccess db)
        {
            db.CreateNewSqlCommand();
            db.AddParameter("@MethodFullName", sMethodFullName);

            SqlDataReader reader = db.ExecuteReaderWithOpenningConnection("spAuthorization_FetchByMethodFullName");

            Authorizations objAuthorization = null;
            if (reader.Read())
            {
                objAuthorization = new Authorizations();

                objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                objAuthorization.Title = reader["Title"].ToString();
                objAuthorization.Description = reader["Description"].ToString();
                objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
                objAuthorization.ModuleID = (int)reader["ModuleID"];
            }

            // Call Close when reading done.
            reader.Close();

            return objAuthorization;
        }
       
        /// <summary>
        /// GetAuthorizationByID
        /// </summary>
        /// <param name="authorizationID"></param>
        /// <returns></returns>
        public Authorizations GetAuthorizationByID(Guid authorizationID)
        {
            foreach (Authorizations obj in AuthorizationCollection)
            {
                if (obj.AuthorizationID == authorizationID)
                    return obj;
            }

            return null;
        }


        public static AuthorizationCollection GetAuthorizationCollectionByModuleType(ModuleType moduleType)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorizations objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.ModuleID == (int)moduleType)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        public static AuthorizationCollection GetAuthorizationCollectionByTitle(ModuleType moduleType, string sTitle)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorizations objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.ModuleID == (int)moduleType && objAuthorization.Title == sTitle)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        /// <summary>
        /// GetAuthorizationCollectionByTitle 
        /// </summary>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        public static AuthorizationCollection GetAuthorizationCollectionByTitle(string sTitle)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorizations objAuthorization in AuthorizationCollection)
            {
                if (objAuthorization.Title == sTitle)
                    authorizationCollection.Add(objAuthorization);
            }

            return authorizationCollection;
        }

        /// <summary>
        /// GetAuthorization 
        /// </summary>
        /// <param name="memInfo"></param>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public Authorizations GetAuthorization(System.Reflection.MemberInfo memInfo,MethodDescriptionAttribute attrib)
        {
            Authorizations objAuthorization = new Authorizations();

            objAuthorization.Title = attrib.Title;
            objAuthorization.Description = attrib.Description;
            objAuthorization.MethodFullName = GetMethodFullName(memInfo);
            objAuthorization.ModuleID = (int)attrib.ModuleType;

            return objAuthorization;
        }

        /// <summary>
        /// GetMethodFullName
        /// </summary>
        /// <param name="memInfo"></param>
        /// <returns></returns>
        public string GetMethodFullName(System.Reflection.MemberInfo memInfo)
        {
            if(memInfo!=null)
            return string.Format("{0}[{1}]", memInfo.DeclaringType, memInfo);
            return "";
        }

        /// <summary>
        /// GetAuthorizationCollectionByGroupID
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static AuthorizationCollection GetAuthorizationCollectionByGroupID(ModuleType moduleType)
        {
            AuthorizationCollection authorizationCollection = new AuthorizationCollection();
            foreach (Authorizations authorization in AuthorizationCollection)
            {
                if (authorization.ModuleID == (int)moduleType)
                    authorizationCollection.Add(authorization);
            }

            return authorizationCollection;
        }

        public static AuthorizationCollection AuthorizationCollection
        {
            get
            {
                if (m_AuthCollection == null)
                {
                    m_AuthCollection = new AuthorizationCollection();
                    try
                    {
                        DbAccess db = new DbAccess();
                        db.CreateNewSqlCommand();
                        SqlDataReader reader = db.ExecuteReader("proc_t_AuthorizationsLoadAll");

                        while (reader.Read())
                        {
                            Authorizations authorization = new Authorizations();

                            authorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                            authorization.Title = reader["Title"].ToString();
                            authorization.Description = reader["Description"].ToString();
                            authorization.MethodFullName = reader["MethodFullName"].ToString();
                            authorization.ModuleID = (int)reader["ModuleID"];

                            m_AuthCollection.Add(authorization);
                        }

                        //Call Close when reading done.
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return m_AuthCollection;
            }
            set
            {
                m_AuthCollection = value;
            }
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
