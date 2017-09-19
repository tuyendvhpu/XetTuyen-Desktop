using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Business;
using DataAccess;


namespace DataAccess
{
    class GroupsADO
    {
         private DataTable dataTable ;

         public GroupsADO()
        {
        }
      

        public  bool Insert(Groups Groups) {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Groups));
              

                db.ExecuteNonQueryWithTransaction("proc_t_GroupsInsert");

                db.CommitTransaction();
                return true;
            }catch{
                db.RollbackTransaction();
                return false;
            }
            
         
   
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        public bool Update(Groups Groups) {

            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(Groups));
                db.ExecuteNonQueryWithTransaction("proc_t_GroupsUpdate");

                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
            
          
        }
       
        public bool Delete( Guid GroupID)
        {



            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@GroupID", GroupID);

                db.ExecuteNonQuery("proc_t_GroupsDelete");
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_GroupsLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
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
            System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader("proc_t_GroupsLoadAll");

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
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
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
            if (Utilities.conDBConnection.State != ConnectionState.Open) Utilities.conDBConnection.Open();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
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
