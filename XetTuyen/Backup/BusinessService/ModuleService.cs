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
    class ModuleService
    {
         private DataTable dataTable;

         public ModuleService()
        {
        }

         /// <summary>
         /// InsertOrUpdate
         /// </summary>
         /// <param name="moduleID"></param>
         public void InsertOrUpdate( DbAccess db,Modules objModule)
         {
             try
             {
                 Modules objNewModule = GetModuleByModuleID(db,objModule.ModuleID);

                 if (objNewModule != null)
                     Update(objModule,db);
                 else
                     Insert(objModule,db);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public bool Insert(Modules Module, DbAccess db)
         {
           
           // db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Module));


                db.ExecuteNonQueryWithTransaction("proc_t_ModulesInsert");

                
                return true;
            }catch{
               // db.RollbackTransaction();
                return false;
            }
            
         
   
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
         public bool Update(Modules Module, DbAccess db)
         {

            
            //db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Module));
                db.ExecuteNonQueryWithTransaction("proc_t_ModulesUpdate");

               
                return true;
            }
            catch
            {
              //  db.RollbackTransaction();
                return false;
            }
            
          
        }
       
        public bool Delete( int ModuleID)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.ModuleID;
                p.Value = ModuleID;
                db.AddParameter(p);
                db.ExecuteNonQueryWithTransaction("proc_t_ModulesDelete");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_ModuleLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }


        /// <summary>
        /// GetModuleByModuleID
        /// </summary>
        /// <param name="nModuleID"></param>
        /// <returns></returns>
        public Modules GetModuleByModuleID( DbAccess db,int nModuleID )
        {
            Modules objModule = null;
          
            db.CreateNewSqlCommand();
            db.AddParameter("@ModuleID", nModuleID);
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReaderWithOpenningConnection("proc_t_ModulesLoadByPrimaryKey");

            if (reader.Read())
            {
                objModule = new Modules();

                objModule.ModuleID = nModuleID;
                objModule.ModuleName = reader["ModuleName"].ToString();
                objModule.Note = reader["Note"].ToString();
            }

            //Call Close when reading done.
            reader.Close();

            return objModule;
        }

        /// <summary>
        /// GetAllModules
        /// </summary>
        /// <returns></returns>
        public ModulesCollection GetAllModules()
        {
            ModulesCollection moduleCollection = new ModulesCollection();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_ModulesLoadAll");

            while (reader.Read())
            {
                Modules objModule = new Modules();

                objModule.ModuleID = Convert.ToInt32(reader["ModuleID"]);
                objModule.ModuleName = reader["ModuleName"].ToString();
                objModule.Note = reader["Note"].ToString();

                moduleCollection.Add(objModule);
            }

            //Call Close when reading done.
            reader.Close();

            return moduleCollection;
        }        
        public DataTable FinModule(string sql) {
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
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
        public DataTable LoadByPrimaryKey(int MenuID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_ModulesLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.ModuleID;
            p.Value = MenuID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
       
	 protected SqlCommand CreateParameters(Modules Module)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.ModuleID);
            p.Value = Module.ModuleID;

            p = cmd.Parameters.Add(Parameters.ModuleName);
            p.Value = Module.ModuleName;


            p = cmd.Parameters.Add(Parameters.Note);
            p.Value = Module.Note;



            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter ModuleID
         {
             get
             {
                 return new SqlParameter("@ModuleID", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter ModuleName
         {
             get
             {
                 return new SqlParameter("@ModuleName", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter Note
         {
             get
             {
                 return new SqlParameter("@Note", SqlDbType.NVarChar, 1073741823);
             }
         }

     }
     #endregion
	
	
	
    }
}
