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
    class GroupsService
    {
         private DataTable dataTable ;

         public GroupsService()
        {
        }

         public enum GroupAction { Insert, Update, Delete, MultilangUI, MultilangData }
         public bool IsAuthorized(GroupAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case GroupAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case GroupAction.Update:
                     sMethodName = "Update";
                     break;
                 case GroupAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(GroupsService).GetMethod(sMethodName));
         }
         [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_AddGroup)]
        public  bool Insert(Groups Groups) {
            DbAccess db = new DbAccess();
            
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Groups));


                db.ExecuteNonQuery("proc_t_GroupsInsert");

             
                return true;
            }catch{
                
                return false;
            }
            
         
   
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
          [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_EditGroup)]
        public bool Update(Groups Groups) {

            DbAccess db = new DbAccess();
           
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Groups));
                db.ExecuteNonQuery("proc_t_GroupsUpdate");

                
                return true;
            }
            catch
            {
               
                return false;
            }
            
          
        }
          [MethodDescription(ModuleType.Administration, FormName.GROUP, FunctionName.SC_DeleteGroup)]
        public bool Delete( Guid GroupID)
        {
            DbAccess db = new DbAccess();
            
            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.GroupID;
                p.Value = GroupID;
                db.AddParameter(p);
                db.ExecuteNonQuery("proc_t_GroupsDelete");

                
                return true;
            }catch{
                
                return false;
            }
            
           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_GroupsLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }


        /// <summary>
        /// GetListGroup
        /// </summary>
        /// <returns></returns>
        public GroupCollection GetListGroup()
        {
            GroupCollection groupCollection = new GroupCollection();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_GroupsLoadAll");

            while (reader.Read())
            {
                Groups objGroup = new Groups();
                objGroup.GroupID = (Guid)reader["GroupID"];
                objGroup.GroupName = reader["GroupName"].ToString();
                objGroup.Note = reader["Note"].ToString();
                objGroup.IsAdmin = (bool)reader["IsAdmin"];

                groupCollection.Add(objGroup);    
            }

            //Call Close when done reading.
            reader.Close();

            return groupCollection;
        }
        public DataTable FinGroups(string sql) {
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        public DataTable LoadByPrimaryKey(Guid GroupID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GroupsLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.GroupID;
            p.Value = GroupID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
         /// <summary>
        ///GetGroupByID
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns>Groups object class</returns>
        public Groups GetGroupByID(Guid GroupID)
        {
            Groups objGroup = new Groups();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.GroupID;
            p.Value = GroupID;
            db.AddParameter(p);
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_GroupsLoadByPrimaryKey");
            if (reader.Read())
            {
                objGroup.GroupID = GroupID;
                objGroup.GroupName = reader["GroupName"].ToString();
                objGroup.Note = reader["Note"].ToString();
                objGroup.IsAdmin = (bool)reader["IsAdmin"];
               
            }

            //Call Close when done reading.
            reader.Close();

            return objGroup;
        }

        
	 protected SqlCommand CreateParameters(Groups Groups)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.GroupID);
            p.Value = Groups.GroupID;
            p = cmd.Parameters.Add(Parameters.GroupName);
            p.Value = Groups.GroupName;
            p = cmd.Parameters.Add(Parameters.IsAdmin);
            p.Value = Groups.IsAdmin;
            p = cmd.Parameters.Add(Parameters.Note);
            p.Value = Groups.Note;


            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter GroupID
         {
             get
             {
                 return new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, 0);
             }
         }

         public static SqlParameter GroupName
         {
             get
             {
                 return new SqlParameter("@GroupName", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter Note
         {
             get
             {
                 return new SqlParameter("@Note", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter IsAdmin
         {
             get
             {
                 return new SqlParameter("@IsAdmin", SqlDbType.Bit, 0);
             }
         }

     }
     #endregion
		
	
	
    }
}
