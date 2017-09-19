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
    class MenuGroupService
    {
         private DataTable dataTable ;

         public MenuGroupService()
        {
        }
      

        public  bool Insert(MenuGroup MenuGroup) {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(MenuGroup));


                db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupInsert");

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
        public bool Update(MenuGroup MenuGroup) {

            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(MenuGroup));
                db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupUpdate");

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
        /// Update menu-group in DB
        /// </summary>
        /// <param name="lstAddedMenuGroup">List of Added Menu-Group</param>
        /// <param name="lstDeletedMenuGroup">List of Deleted Menu-Group</param>
        /// <returns></returns>
        public bool UpdateMenuGroup(DbAccess db, List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            try
            {
                //1. Add new menu 
                for (int i = 0; i < lstAddedMenuGroup.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstAddedMenuGroup[i].GroupID);
                    db.AddParameter("@MenuID", lstAddedMenuGroup[i].MenuID);

                    db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupInsert");
                }

                //2. Delete menu
                for (int i = 0; i < lstDeletedMenuGroup.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstDeletedMenuGroup[i].GroupID);
                    db.AddParameter("@MenuID", lstDeletedMenuGroup[i].MenuID);

                    db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupDelete");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string MenuID, Guid GroupID)
        {

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@MenuID", MenuID);
                db.AddParameter("@GroupID", GroupID);


                db.ExecuteNonQuery("proc_t_MenuGroupDelete");
                return true;
            }
            catch
            {
                return false;
            }

           

        }
        public DataTable LoadAll()
        {


            SqlDataAdapter dataAdapter = new SqlDataAdapter("proc_t_MenuGroupLoadAll", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }


        public DataTable FinMenuGroup(string sql) {
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
        public DataTable LoadByPrimaryKey(string MenuID, Guid GroupID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_MenuGroupLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MenuID;
            p.Value = MenuID;
            cmd.Parameters.Add(p);

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
        /// Update menu-group in DB
        /// </summary>
        /// <param name="lstAddedMenuGroup">List of Added Menu-Group</param>
        /// <param name="lstDeletedMenuGroup">List of Deleted Menu-Group</param>
        /// <returns></returns>
        public bool UpdateMenuGroup(List<MenuGroup> lstAddedMenuGroup, List<MenuGroup> lstDeletedMenuGroup)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();

            try
            {
                //1. Add new menu 
                for (int i = 0; i < lstAddedMenuGroup.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstAddedMenuGroup[i].GroupID);
                    db.AddParameter("@MenuID", lstAddedMenuGroup[i].MenuID);

                    db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupInsert");
                }

                //2. Delete menu
                for (int i = 0; i < lstDeletedMenuGroup.Count; i++)
                {
                    db.CreateNewSqlCommand();

                    db.AddParameter("@GroupID", lstDeletedMenuGroup[i].GroupID);
                    db.AddParameter("@MenuID", lstDeletedMenuGroup[i].MenuID);

                    db.ExecuteNonQueryWithTransaction("proc_t_MenuGroupDelete");
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



        /// <summary>
        /// Get MenuGroup Collection By LanguageID
        /// </summary>       
        /// <returns></returns>
        public MenuGroupCollection GetMenuGroupCollection()
        {
            MenuGroupCollection MenuGroupCollection = new MenuGroupCollection();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_MenuGroupLoadAll");

            while (reader.Read())
            {
                MenuGroup objMenuGroup = new MenuGroup();

                objMenuGroup.MenuID = reader["MenuID"].ToString();
                Guid GorupID = new Guid(reader["GroupID"].ToString());
                objMenuGroup.GroupID = GorupID;
               

                MenuGroupCollection.Add(objMenuGroup);
            }

            //Call Close when done reading.
            reader.Close();

            return MenuGroupCollection;
        }

        /// <summary>
        /// Get Menu Group Collection
        /// </summary>
        /// <returns></returns>
        public MenuGroupCollection GetMenuGroupCollectionByGroupID(List<Guid> lstGroupID)
        {
            MenuGroupCollection allMenuGroupCollection = GetMenuGroupCollection();
            MenuGroupCollection menuGroupCollection = new MenuGroupCollection();

            for (int i = 0; i < lstGroupID.Count; i++)
            {
                foreach (MenuGroup objMenuGroup in allMenuGroupCollection)
                {
                    if (objMenuGroup.GroupID == lstGroupID[i])
                        menuGroupCollection.Add(objMenuGroup);
                }
            }

            return menuGroupCollection;
        }     
	 protected SqlCommand CreateParameters(MenuGroup MenuGroup)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.GroupID);
            p.Value = MenuGroup.GroupID;

            p = cmd.Parameters.Add(Parameters.MenuID);
            p.Value = MenuGroup.MenuID;

           

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

         public static SqlParameter MenuID
         {
             get
             {
                 return new SqlParameter("@MenuID", SqlDbType.VarChar, 100);
             }
         }

     }
     #endregion
	
		
	
	
    }
}
