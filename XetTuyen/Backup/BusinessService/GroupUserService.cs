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
    class GroupUserService
    {
         private DataTable dataTable ;

         public GroupUserService()
        {
        }
      

        public  bool Insert(GroupUser GroupUser) {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(GroupUser));


                db.ExecuteNonQueryWithTransaction("proc_t_GroupUserInsert");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
         
   
        }
  
       
        public bool Delete( Guid GroupID,string LoginID)
        {

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@GroupID", GroupID);
                db.AddParameter("@LoginID", LoginID);

                db.ExecuteNonQuery("proc_t_GroupUserDelete");
                return true;
            }
            catch
            {
                return false;
            }
            
           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_GroupUserLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }


        /// <summary>
        /// GetListGroupUser
        /// </summary>
        /// <returns></returns>
        public GroupUserCollection GetListGroup()
        {
            GroupUserCollection groupuserCollection = new GroupUserCollection();


            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_GroupUserLoadAll");

            while (reader.Read())
            {
                GroupUser objGroupUser = new GroupUser();
                objGroupUser.GroupID = (Guid)reader["GroupID"];
                objGroupUser.LoginID = reader["LoginID"].ToString();


                groupuserCollection.Add(objGroupUser);    
            }

            //Call Close when done reading.
            reader.Close();

            return groupuserCollection;
        }
        /// <summary>
        /// GetListGroupIdByUserID
        /// </summary>
        /// <returns></returns>
        public GroupUserCollection GetListGroupUserByUserID(string LoginID)
        {
            GroupUserCollection groupuserCollection = new GroupUserCollection();

            LoginID = LoginID.ToLower();
            DbAccess db = new DbAccess();
            
            db.CreateNewSqlCommand();
            SqlParameter p;
           
            p = Parameters.LoginID;
            p.Value = LoginID;
            db.AddParameter(p);
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_GroupUserLoadByLoginID");

            while (reader.Read())
            {
                GroupUser objGroupUser = new GroupUser();
                objGroupUser.GroupID = (Guid)reader["GroupID"];
                objGroupUser.LoginID = reader["LoginID"].ToString();


                groupuserCollection.Add(objGroupUser);
            }

            //Call Close when done reading.
            reader.Close();

            return groupuserCollection;
        }
        /// <summary>
        /// GetListGroupIdByUserAndLanguageID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Guid> GetListGroupIdByUserID(string sLoginID)
        {
            sLoginID = sLoginID.ToLower();
            List<Guid> lstGroupID = new List<Guid>();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.LoginID;
            p.Value = sLoginID;
            db.AddParameter(p);

            SqlDataReader reader = db.ExecuteReader("proc_t_GroupUserLoadByLoginID");
            while (reader.Read())
            {
                lstGroupID.Add((Guid)reader["GroupID"]);
            }

            //Call Close when done reading.
            reader.Close();

            return lstGroupID;
        }

        // <summary>
        /// Get Group Collection By User ID
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Group Collection</returns>
        public GroupCollection GetGroupCollectionByUserID(string LoginID)
        {
            GroupCollection groupCollection = new GroupCollection();
           LoginID = LoginID.ToLower();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@LoginID", LoginID);
            SqlDataReader reader = db.ExecuteReader("proc_t_GroupLoadByLoginID");

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

        public DataTable FinGroupUser(string sql) {
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataTable = new DataTable();
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

       

        public DataTable LoadByPrimaryKey(Guid GroupID, string LoginID)
        {

            LoginID = LoginID.ToLower();
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_GroupUserLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.GroupID;
            p.Value = GroupID;
            cmd.Parameters.Add(p);

            p = Parameters.LoginID;
            p.Value = LoginID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        /// <summary>
        /// GetGroupUserByID
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        public GroupUser GetGroupByID(Guid GroupID, string LoginID)
        {
            LoginID = LoginID.ToLower();
            GroupUser objGroupUser = new GroupUser();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.GroupID;
            p.Value = GroupID;
            db.AddParameter(p);
            p = Parameters.LoginID;
            p.Value = LoginID;
            db.AddParameter(p);
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_GroupUserLoadByPrimaryKey");
            if (reader.Read())
            {
                objGroupUser.GroupID = (Guid)reader["GroupID"];
                objGroupUser.LoginID = reader["LoginID"].ToString();
               
            }

            //Call Close when done reading.
            reader.Close();

            return objGroupUser;
        }

        
	 protected SqlCommand CreateParameters(GroupUser GroupUser)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.GroupID);
            p.Value = GroupUser.GroupID;
            p = cmd.Parameters.Add(Parameters.LoginID);
            p.Value = GroupUser.LoginID;
           


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

         public static SqlParameter LoginID
         {
             get
             {
                 return new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
             }
         }

     }
     #endregion
		
	
	
    }
}
