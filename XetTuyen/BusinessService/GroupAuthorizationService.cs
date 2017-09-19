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
    class GroupAuthorizationService
    {
         private DataTable dataTable ;
         public bool IsAuthorized()
         {
             return SecurityManager.IsAuthorized(typeof(GroupAuthorizationService).GetMethod("UpdateData"));
         }   
         public GroupAuthorizationService()
        {
        }
      

        public  bool Insert(GroupAuthorization GroupAuthorization) {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(GroupAuthorization));


                db.ExecuteNonQueryWithTransaction("proc_t_GroupAuthorizationInsert");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
         
   
        }

        public bool Delete(Guid GroupID, Guid AuthorizationID)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                SqlParameter p;
                p = Parameters.GroupID;
                p.Value = GroupID;
                db.AddParameter(p);
                p = Parameters.AuthorizationID;
                p.Value = AuthorizationID;
                db.AddParameter(p);
                db.ExecuteNonQueryWithTransaction("proc_t_GroupAuthorizationDelete");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_GroupAuthorizationLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

           
            return dataTable;
        }
                     
        public DataTable FinGroupAuthorization(string sql) {
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
        public DataTable LoadByPrimaryKey(Guid GroupID, Guid AuthorizationID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GroupAuthorizationLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.GroupID;
            p.Value = GroupID;
            cmd.Parameters.Add(p);

            p = Parameters.AuthorizationID;
            p.Value = AuthorizationID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }


        

        /// <summary>
        /// Get Group Authorization By ID
        /// </summary>
        /// <param name="objGroupAuthorizationID">ID of Group Authorization</param>
        /// <returns></returns>
        public GroupAuthorization GetGroupAuthorizationByID(Guid groupID, Guid authorizationID)
        {
            GroupAuthorization objGroupAuthorization = new GroupAuthorization();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();

            db.AddParameter("@GroupID", groupID);
            db.AddParameter("@AuthorizationID", authorizationID);
            SqlDataReader reader = db.ExecuteReader("proc_t_GroupAuthorizationLoadByPrimaryKey");

            if (reader.Read())
            {
                objGroupAuthorization.GroupID = (Guid)reader["GroupID"];
                objGroupAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
            }

            // Call Close when reading done.
            reader.Close();

            return objGroupAuthorization;
        }

        [MethodDescription(ModuleType.Administration, FormName.AUTHORIZATION, FunctionName.SC_AddOrDeleteGroupAuthorization)]
        public bool UpdateData(List<GroupAuthorization> lstAddedGroupAuthorization, List<GroupAuthorization> lstDeletedGroupAuthorization,
                                List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                UpdateGroupAuthorization(db, lstAddedGroupAuthorization, lstDeletedGroupAuthorization);
                new MenuGroupService().UpdateMenuGroup(db, lstAddedMenuGroup, lstDeletedMenuGroup);

                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }

        /// <summary>
        /// UpdateGroupAuthorization
        /// </summary>
        /// <param name="lstAddedGroupAuthorization"></param>
        /// <param name="lstDeletedGroupAuthorization"></param>
        private void UpdateGroupAuthorization(DbAccess db, List<GroupAuthorization> lstAddedGroupAuthorization, List<GroupAuthorization> lstDeletedGroupAuthorization)
        {
            try
            {
                //1. Insert lstAddedGroupAuthorization
                for (int i = 0; i < lstAddedGroupAuthorization.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstAddedGroupAuthorization[i].GroupID);
                    db.AddParameter("@AuthorizationID", lstAddedGroupAuthorization[i].AuthorizationID);
                    db.ExecuteNonQueryWithTransaction("proc_t_GroupAuthorizationInsert");
                }

                //2. Delete lstDeletedGroupAuthorization
                for (int i = 0; i < lstDeletedGroupAuthorization.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstDeletedGroupAuthorization[i].GroupID);
                    db.AddParameter("@AuthorizationID", lstDeletedGroupAuthorization[i].AuthorizationID);
                    db.ExecuteNonQueryWithTransaction("proc_t_GroupAuthorizationDelete");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetAuthorization
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Authorizations GetAuthorization(SqlDataReader reader)
        {
            Authorizations objAuthorization = new Authorizations();

            objAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
            objAuthorization.Title = reader["Title"].ToString();
            objAuthorization.Description = reader["Description"].ToString();
            objAuthorization.MethodFullName = reader["MethodFullName"].ToString();
            objAuthorization.ModuleID = (int)reader["ModuleID"];

            return objAuthorization;
        }

        /// <summary>
        /// GetGroup
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Groups GetGroup(SqlDataReader reader)
        {
            Groups objGroup = new Groups();

            objGroup.GroupID = (Guid)reader["GroupID"];
            objGroup.GroupName = reader["GroupName"].ToString();
            objGroup.Note = reader["Note"].ToString();
            objGroup.IsAdmin = (bool)reader["IsAdmin"];

            return objGroup;
        }

        private static GroupAuthorizationCollection _authorizationCollection = null;
        public static GroupAuthorizationCollection GroupAuthorizationCollection
        {
            get
            {
                if (_authorizationCollection == null)
                {
                    _authorizationCollection = new GroupAuthorizationCollection();
                    GroupAuthorizationCollection groupAuthorizationCollection = new GroupAuthorizationCollection();

                    DbAccess db = new DbAccess();
                    db.CreateNewSqlCommand();
                    SqlDataReader reader = db.ExecuteReader("spGroupAuthorization_SelectAll");

                    while (reader.Read())
                    {
                        GroupAuthorization objGroupAuthorization = new GroupAuthorization();

                        objGroupAuthorization.AuthorizationID = (Guid)reader["AuthorizationID"];
                        objGroupAuthorization.GroupID = (Guid)reader["GroupID"];
                        objGroupAuthorization.Authorization = GetAuthorization(reader);
                        objGroupAuthorization.Group = GetGroup(reader);

                        _authorizationCollection.Add(objGroupAuthorization);
                    }

                    // Call Close when reading done.
                    reader.Close();
                }

                return _authorizationCollection;
            }
            set
            {
                _authorizationCollection = value;
            }
        }


        private static GroupAuthorizationCollection _authorizationCollectionOfCurrentUser = null;
        public static GroupAuthorizationCollection AuthorizationCollectionOfCurrentUser
        {
            get
            {
                if (_authorizationCollectionOfCurrentUser == null)
                {
                    //Get Groups which this user belongs to
                    List<Guid> lstGroups = new List<Guid>();
                    GroupUserService groupUserBS = new GroupUserService();

                    lstGroups = groupUserBS.GetListGroupIdByUserID(clsCommon.CurrentUser.LoginID.ToLower());
                    //End            

                    _authorizationCollectionOfCurrentUser = new GroupAuthorizationCollection();
                    for (int i = 0; i < lstGroups.Count; i++)
                    {
                        foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
                        {
                            if (objGroupAuthorization.GroupID == lstGroups[i])
                                _authorizationCollectionOfCurrentUser.Add(objGroupAuthorization);
                        }
                    }
                }

                return _authorizationCollectionOfCurrentUser;
            }
            set
            {
                _authorizationCollectionOfCurrentUser = value;
            }
        }

        /// <summary>
        /// GetAuthorizationRoleCollectionByRoleID
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public GroupAuthorizationCollection GetGroupAuthorizationCollectionByGroupID(Guid groupID)
        {
            GroupAuthorizationCollection groupAuthorizationCollection = new GroupAuthorizationCollection();
            foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
            {
                if (objGroupAuthorization.GroupID == groupID)
                    groupAuthorizationCollection.Add(objGroupAuthorization);
            }

            return groupAuthorizationCollection;
        }

        /// <summary>
        /// CountAuthorizationCollectionByGroupID
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public int CountAuthorizationCollectionByGroupID(Guid groupID)
        {
            int count = 0;
            foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationCollection)
            {
                if (objGroupAuthorization.GroupID == groupID)
                    count++;
            }

            return count;
        }


        
	 protected SqlCommand CreateParameters(GroupAuthorization GroupAuthorization)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.GroupID);
            p.Value = GroupAuthorization.GroupID;
            p = cmd.Parameters.Add(Parameters.AuthorizationID);
            p.Value = GroupAuthorization.AuthorizationID;
            


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

         public static SqlParameter AuthorizationID
         {
             get
             {
                 return new SqlParameter("@AuthorizationID", SqlDbType.UniqueIdentifier, 0);
             }
         }

     }
     #endregion
	
		
	
	
    }
}
