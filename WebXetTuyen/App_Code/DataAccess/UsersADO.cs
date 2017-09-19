using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;

namespace DataAccess
{
     class UsersADO
    {
         private DataTable dataTable ;

         public UsersADO()
        {
        }


        public bool Insert(Users Users)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Users));

                db.ExecuteNonQueryWithTransaction("proc_t_UsersInsert");

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
        /// Update user
        /// </summary>
        /// <returns></returns>
        public bool Update(Users Users)
        {

            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Users));
                db.ExecuteNonQueryWithTransaction("proc_t_UsersUpdate");

                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }


        }

        public bool Delete(string LoginID)
        {
            //DbAccess db = new DbAccess();
            //db.BeginTransaction();
            //try
            //{
            //    db.CreateNewSqlCommand();
            //    SqlParameter p;
            //    p = Parameters.LoginID;
            //    p.Value = LoginID;
            //    db.AddParameter(p);
            //    db.ExecuteNonQueryWithTransaction("proc_t_UsersDelete");

            //    db.CommitTransaction();
            //    return true;
            //}
            //catch
            //{
            //    db.RollbackTransaction();
            //    return false;
            //}

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@LoginID", LoginID);

                db.ExecuteNonQuery("proc_t_UsersDelete");
                return true;
            }
            catch
            {
                return false;
            }

        }
        public DataTable LoadAll()
        {

            if (Utilities.conDBConnection == null) Utilities.getConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_UsersLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
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
        public DataTable FinUsers(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
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
            dataTable = new DataTable();
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
                db.AddParameter("@Password", Utilities.encryptString(objUser.Password));
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
        public bool IsAdminUser(string sLoginID)
        {
            GroupCollection groupCollection = GroupUserServices.GetGroupCollectionByUserID(sLoginID);
            foreach (Groups objGroup in groupCollection)
            {
                if (objGroup.IsAdmin)
                {
                    Utilities.IsAdminUser = true;
                    return true;
                }
            }

            Utilities.IsAdminUser = false;
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
            p.Value = Utilities.encryptMD5String(Users.Password);


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
