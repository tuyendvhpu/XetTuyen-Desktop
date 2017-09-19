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
    class UsersService
    {
        public UsersService()
        {
        }
        public enum UserAction { Insert, Update, Delete, MultilangUI }
         public bool IsAuthorized(UserAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 case UserAction.Insert:
                     sMethodName = "Insert";
                     break;
                 case UserAction.Update:
                     sMethodName = "Update";
                     break;
                 case UserAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case UserAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
             }

             return SecurityManager.IsAuthorized( typeof(UsersService).GetMethod(sMethodName));
         }
         private DataTable dataTable = new DataTable();
        


         [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_AddUser)]
         public bool Insert(Users objUser, List<GroupUser> lstGroupUser)
         {
             DbAccess db = new DbAccess();
             db.BeginTransaction();

             try
             {
                 //1. Insert a record into Users table
                 db.CreateNewSqlCommand();
                 db.AddParameter("@LoginID", objUser.LoginID);
                 db.AddParameter("@Password", Utilities.encryptMD5String (objUser.Password));
                 db.AddParameter("@FullName", objUser.FullName);
                 db.AddParameter("@Email", objUser.Email);
                 db.AddParameter("@CreatedDate", objUser.CreatedDate);
                 db.AddParameter("@LockedUser", objUser.LockedUser);
                 db.AddParameter("@LockedDate", objUser.LockedDate);
                 db.AddParameter("@LockedReason", objUser.LockedReason);
                 db.AddParameter("@LastLogIn", objUser.LastLogIn);
                 db.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);
                 db.AddParameter("@DeadlineOfUsing", objUser.DeadlineOfUsing);
                 db.AddParameter("@BirthDay", objUser.BirthDay);
                 db.AddParameter("@Gender", objUser.Gender);

                 db.ExecuteNonQueryWithTransaction("proc_t_UsersInsert");

                 //2. Insert records into GroupUser table
                 for (int i = 0; i < lstGroupUser.Count; i++)
                 {
                     db.CreateNewSqlCommand();
                     db.AddParameter("@GroupID", lstGroupUser[i].GroupID);
                     db.AddParameter("@LoginID", lstGroupUser[i].LoginID);
                     db.ExecuteNonQueryWithTransaction("proc_t_GroupUserInsert");
                 }

                 db.CommitTransaction();
                 return true;
             }
             catch
             {
                 db.RollbackTransaction();
                 return false;
             }
         }
         [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_EditUser)]
         public bool Update(Users objUser, List<GroupUser> lstAddedGroupUser, List<GroupUser> lstDeletedGroupUser)
         {
             DbAccess db = new DbAccess();
             db.BeginTransaction();

             try
             {
                 //1. Update a record in Users table
                 db.CreateNewSqlCommand();
                 db.AddParameter("@LoginID", objUser.LoginID);
                 db.AddParameter("@Password", Utilities.encryptMD5String(objUser.Password));
                 db.AddParameter("@FullName", objUser.FullName);
                 db.AddParameter("@Email", objUser.Email);
                 db.AddParameter("@CreatedDate", objUser.CreatedDate);
                 db.AddParameter("@LockedUser", objUser.LockedUser);
                 db.AddParameter("@LockedDate", objUser.LockedDate);
                 db.AddParameter("@LockedReason", objUser.LockedReason);
                 db.AddParameter("@LastLogIn", objUser.LastLogIn);
                 db.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);
                 db.AddParameter("@DeadlineOfUsing", objUser.DeadlineOfUsing);
                 db.AddParameter("@BirthDay", objUser.BirthDay);
                 db.AddParameter("@Gender", objUser.Gender);
                 
                 db.ExecuteNonQueryWithTransaction("proc_t_UsersUpdate");

                 //2. Insert records into GroupUser table
                 for (int i = 0; i < lstAddedGroupUser.Count; i++)
                 {
                     db.CreateNewSqlCommand();
                     db.AddParameter("@GroupID", lstAddedGroupUser[i].GroupID);
                     db.AddParameter("@LoginID", lstAddedGroupUser[i].LoginID);
                     db.ExecuteNonQueryWithTransaction("proc_t_GroupUserInsert");
                 }

                 //3. Delete records in GroupUser table
                 for (int i = 0; i < lstDeletedGroupUser.Count; i++)
                 {
                     db.CreateNewSqlCommand();
                     db.AddParameter("@GroupID", lstDeletedGroupUser[i].GroupID);
                     db.AddParameter("@LoginID", lstDeletedGroupUser[i].LoginID);
                     db.ExecuteNonQueryWithTransaction("proc_t_GroupUserDelete");
                 }


                 db.CommitTransaction();
                 return true;
             }
             catch
             {
                 db.RollbackTransaction();
                 return false;
             }
         }
         [MethodDescription(ModuleType.Administration, FormName.USER, FunctionName.SC_DeleteUser)]
         public bool Delete(List<string> lstUserID, List<GroupUser> lstDeletedGroupUser)
         {
             DbAccess db = new DbAccess();
             db.BeginTransaction();

             try
             {
                 //1. Delete records in GroupUser table
                 for (int i = 0; i < lstDeletedGroupUser.Count; i++)
                 {
                     db.CreateNewSqlCommand();
                     db.AddParameter("@GroupID", lstDeletedGroupUser[i].GroupID);
                     db.AddParameter("@LoginID", lstDeletedGroupUser[i].LoginID);

                     db.ExecuteNonQueryWithTransaction("proc_t_GroupUserDelete");
                 }

                 //2. Delete records in Users table
                 for (int i = 0; i < lstUserID.Count; i++)
                 {
                     db.CreateNewSqlCommand();
                     db.AddParameter("@LoginID", lstUserID[i]);

                     db.ExecuteNonQueryWithTransaction("proc_t_UsersDelete");
                 }

                 db.CommitTransaction();
                 return true;
             }
             catch
             {
                 db.RollbackTransaction();
                 return false;
             }
         }

        
       
       
        public DataTable LoadAll()
        {

             if (Utilities.conDBConnection == null) Utilities.getConnection();
             if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_UsersLoadAll]", Utilities.conDBConnection);
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            
           
            return dataTable;
        }


        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        public UserCollection GetListUser()
        {
            UserCollection userCollection = new UserCollection();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_UsersLoadAll");

            while (reader.Read())
            {
                Users objUser = new Users();

                objUser.BirthDay = (DateTime)reader["BirthDay"];
                objUser.CreatedDate = (DateTime)reader["CreatedDate"];
                objUser.DeadlineOfUsing = (DateTime)reader["DeadlineOfUsing"];
                objUser.Email = reader["Email"].ToString();
                objUser.FullName = reader["FullName"].ToString();
                objUser.Gender = reader["Gender"].ToString();
                objUser.LastChangedPassword = (DateTime)reader["LastChangedPassword"];
                objUser.LastLogIn = (DateTime)reader["LastLogIn"];
                objUser.LockedDate = (DateTime)reader["LockedDate"];
                objUser.LockedReason = reader["LockedReason"].ToString();
                objUser.LockedUser = (bool)reader["LockedUser"];
                objUser.LoginID = reader["LoginID"].ToString();
                objUser.Password = reader["Password"].ToString();

                userCollection.Add(objUser);
            }

            //Call Close when done reading.
            reader.Close();

            return userCollection;
        }
        public DataTable FinUsers(string sql) {
            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
        public DataTable LoadByPrimaryKey(string sLoginID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_UsersLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.LoginID;
            p.Value = sLoginID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }
         /// <summary>
        /// GetUserByID
        /// </summary>
        /// <param name="sLoginID"></param>
        /// <returns>Users object class</returns>
        public Users GetUserByID(string sLoginID)
        {
            Users objUser = new Users();
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlParameter p;
            p = Parameters.LoginID;
            p.Value = sLoginID;
            db.AddParameter(p);
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_UsersLoadByPrimaryKey");
            if (reader.Read())
            {
                objUser.BirthDay = (DateTime)reader["BirthDay"];
                objUser.CreatedDate = (DateTime)reader["CreatedDate"];
                objUser.DeadlineOfUsing=(DateTime)reader["DeadlineOfUsing"];
                objUser.Email = reader["Email"].ToString();
                objUser.FullName = reader["FullName"].ToString();
                objUser.Gender = reader["Gender"].ToString();
                objUser.LastChangedPassword = (DateTime)reader["LastChangedPassword"];
                objUser.LastLogIn = (DateTime)reader["LastLogIn"];
                objUser.LockedDate = (DateTime)reader["LockedDate"];
                objUser.LockedReason = reader["LockedReason"].ToString();
                objUser.LockedUser = (bool)reader["LockedUser"];
                objUser.LoginID = reader["LoginID"].ToString();
                objUser.Password = reader["Password"].ToString();
                         
               
            }

            //Call Close when done reading.
            reader.Close();

            return objUser;
        }

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public bool UpdatePassword(Users objUser)
        {
            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@LoginID", objUser.LoginID);
                db.AddParameter("@Password",Utilities.encryptMD5String(objUser.Password));
                db.AddParameter("@LastChangedPassword", objUser.LastChangedPassword);
                db.ExecuteNonQuery("proc_t_UsersUpdatePassword");

                return true;
            }
            catch
            {
                return false;
            }
        }
         /// <summary>
        /// Check login user belongs to Admin Group ?
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Admin Group or not</returns>
        private bool IsAdminUser(string sLoginID)
        {
            GroupCollection groupCollection = new GroupUserService().GetGroupCollectionByUserID(sLoginID);
            foreach (Groups objGroup in groupCollection)
            {
                if (objGroup.IsAdmin)
                {
                    clsCommon.IsAdminUser = true;
                    return true;
                }
            }

            clsCommon.IsAdminUser = false;
            return false;
        }
        /// <summary>
        /// Check Login user
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <param name="sPassword">Password</param>
        /// <param name="status">Status of this User</param>
        /// <returns></returns>
        public Users CheckUser(string sLoginID, string sPassword, ref UserStatus status)
        {
            sPassword = Utilities.encryptMD5String(sPassword);
            DateTime dtmNow = Utilities.GetServerTime();
            Users objUser = GetUserByID(sLoginID);
            if (objUser != null)
            {
                if (objUser.Password == sPassword)
                {
                    //Check this user belongs to Admin Group ?
                    if (IsAdminUser(sLoginID))
                        status = UserStatus.OK;
                    else
                    {
                        if (!objUser.LockedUser)
                        {
                            if (objUser.DeadlineOfUsing.Date >= dtmNow.Date)
                                status = UserStatus.OK;
                            else
                                status = UserStatus.ExpiredDate;
                        }
                        else
                            status = UserStatus.Locked;
                    }
                }
                else
                    status = UserStatus.NotExists;
            }
            else
                status = UserStatus.NotExists;

            return objUser;
        }
	 protected SqlCommand CreateParameters(Users Users)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.BirthDay);
            p.Value = Users.BirthDay;

            p = cmd.Parameters.Add(Parameters.CreatedDate);
            p.Value = Users.CreatedDate;

            p = cmd.Parameters.Add(Parameters.DeadlineOfUsing);
            p.Value = Users.DeadlineOfUsing;

            p = cmd.Parameters.Add(Parameters.Email);
            p.Value = Users.Email;

            p = cmd.Parameters.Add(Parameters.FullName);
            p.Value = Users.FullName;


            p = cmd.Parameters.Add(Parameters.Gender);
            p.Value = Users.Gender;

            p = cmd.Parameters.Add(Parameters.LastChangedPassword);
            p.Value = Users.LastChangedPassword;

            p = cmd.Parameters.Add(Parameters.LastLogIn);
            p.Value = Users.LastLogIn;

            p = cmd.Parameters.Add(Parameters.LockedDate);
            p.Value = Users.LockedDate;

            p = cmd.Parameters.Add(Parameters.LockedReason);
            p.Value = Users.LockedReason;

            p = cmd.Parameters.Add(Parameters.LockedUser);
            p.Value = Users.LockedUser;

            p = cmd.Parameters.Add(Parameters.LoginID);
            p.Value = Users.LoginID;


            p = cmd.Parameters.Add(Parameters.Password);
            p.Value = Utilities.encryptMD5String (Users.Password);


            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter LoginID
         {
             get
             {
                 return new SqlParameter("@LoginID", SqlDbType.VarChar, 50);
             }
         }

         public static SqlParameter Password
         {
             get
             {
                 return new SqlParameter("@Password", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter FullName
         {
             get
             {
                 return new SqlParameter("@FullName", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter Email
         {
             get
             {
                 return new SqlParameter("@Email", SqlDbType.VarChar, 50);
             }
         }

         public static SqlParameter CreatedDate
         {
             get
             {
                 return new SqlParameter("@CreatedDate", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter LockedUser
         {
             get
             {
                 return new SqlParameter("@LockedUser", SqlDbType.Bit, 0);
             }
         }

         public static SqlParameter LockedDate
         {
             get
             {
                 return new SqlParameter("@LockedDate", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter LockedReason
         {
             get
             {
                 return new SqlParameter("@LockedReason", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter LastLogIn
         {
             get
             {
                 return new SqlParameter("@LastLogIn", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter LastChangedPassword
         {
             get
             {
                 return new SqlParameter("@LastChangedPassword", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter DeadlineOfUsing
         {
             get
             {
                 return new SqlParameter("@DeadlineOfUsing", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter BirthDay
         {
             get
             {
                 return new SqlParameter("@BirthDay", SqlDbType.DateTime, 0);
             }
         }

         public static SqlParameter Gender
         {
             get
             {
                 return new SqlParameter("@Gender", SqlDbType.NVarChar, 50);
             }
         }

     }
     #endregion
		
	
	
    }
}
