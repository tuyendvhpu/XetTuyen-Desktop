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
    class MenuService
    {
         private DataTable dataTable ;

         public MenuService()
        {
        }


         public bool Insert(BusinessLogic.Menu objMenu, DbAccess db)
         {
           
            //db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(objMenu));
                //db.CreateNewSqlCommand();

                //db.AddParameter("@MenuID", objMenu.MenuID);
                //db.AddParameter("@MenuPosition", objMenu.MenuPosition);
                //db.AddParameter("@MenuValue", objMenu.MenuValue);
                //db.AddParameter("@MenuFiliationID", objMenu.MenuFiliationID);
                //db.AddParameter("@FormName", objMenu.FormName);
                db.ExecuteNonQueryWithTransaction("proc_t_MenuInsert");

               // db.CommitTransaction();
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
         public bool Update(BusinessLogic.Menu objMenu, DbAccess db)
         {

           
           // db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand(CreateParameters(objMenu));

                //db.CreateNewSqlCommand();

                //db.AddParameter("@MenuID", objMenu.MenuID);
                //db.AddParameter("@MenuPosition", objMenu.MenuPosition);
                //db.AddParameter("@MenuValue", objMenu.MenuValue);
                //db.AddParameter("@MenuFiliationID", objMenu.MenuFiliationID);
                //db.AddParameter("@FormName", objMenu.FormName);
                db.ExecuteNonQueryWithTransaction("proc_t_MenuUpdate");

                //db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
          
        }

        public bool Delete(string MenuID)
        {

            try
            {
                DbAccess db = new DbAccess();
                db.CreateNewSqlCommand();

                db.AddParameter("@MenuID", MenuID);

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


            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_MenuLoadAll]", Utilities.conDBConnection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
           
            return dataTable;
        }


        public DataTable FinMenu(string sql) {
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
        public DataTable LoadByPrimaryKey(string MenuID)
        {


            SqlCommand cmd = new SqlCommand();
             if (Utilities.conDBConnection == null) Utilities.getConnection();
            cmd.Connection = Utilities.conDBConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[proc_t_MenuLoadByPrimaryKey]";

            SqlParameter p;

            p = Parameters.MenuID;
            p.Value = MenuID;
            cmd.Parameters.Add(p);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            Utilities.conDBConnection.Close();
            return dataTable;
        }


        #region Write Data

        /// <summary>
        /// Update Menu in DB
        /// </summary>
        /// <param name="lstAddedMenu">List of menus need to be updated</param>        
        public bool UpdateMenu(List<BusinessLogic.Menu> lstMenu)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
               BusinessLogic.Menu objMenu;

                for (int i = 0; i < lstMenu.Count; i++)
                {
                    objMenu = GetMenuByID(lstMenu[i].MenuID,db);

                    if (objMenu != null)
                    {
                        objMenu.MenuFiliationID = lstMenu[i].MenuFiliationID;
                        objMenu.MenuValue = lstMenu[i].MenuValue;
                        objMenu.FormName = lstMenu[i].FormName;
                        objMenu.MenuPosition = lstMenu[i].MenuPosition;
                        objMenu.MenuID = lstMenu[i].MenuID;
                        this.Update(objMenu, db);
                    }
                    else
                    {

                        Insert(lstMenu[i], db);
                    }
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
        /// Get menu for updating
        /// </summary>
        /// <param name="objMenuID">Menu ID</param>
        /// <returns></returns>
        public BusinessLogic.Menu GetMenuByID(string sMenuID, DbAccess db)
        {
            BusinessLogic.Menu objMenu = null;
            db.CreateNewSqlCommand();

            db.AddParameter("@MenuID", sMenuID);
            SqlDataReader reader = db.ExecuteReaderWithOpenningConnection("proc_t_MenuLoadByPrimaryKey");

            if (reader.Read())
            {
                objMenu = new BusinessLogic.Menu();
                objMenu.MenuID = sMenuID;
                objMenu.MenuValue = reader["MenuValue"].ToString();
                objMenu.MenuPosition = Convert.ToInt32(reader["MenuPosition"]);
                objMenu.MenuFiliationID = reader["MenuFiliationID"].ToString();
                objMenu.FormName = reader["FormName"].ToString();
            }

            //Call Close when done reading.
            reader.Close();

            return objMenu;
        }

    
        #endregion


        /// <summary>
        /// Get Menu Collection By LanguageID
        /// </summary>       
        /// <returns></returns>
        public MenuCollection GetMenuCollection()
        {
            MenuCollection menuCollection = new MenuCollection();

            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            SqlDataReader reader = db.ExecuteReader("proc_t_MenuLoadAll");

            while (reader.Read())
            {
                Menu objMenu = new Menu();

                objMenu.MenuID = reader["MenuID"].ToString();
                objMenu.MenuPosition = Convert.ToInt32(reader["MenuPosition"]);
                objMenu.MenuValue = reader["MenuValue"].ToString();
                objMenu.MenuFiliationID = reader["MenuFiliationID"].ToString();
                objMenu.FormName = reader["FormName"].ToString();

                menuCollection.Add(objMenu);
            }

            //Call Close when done reading.
            reader.Close();

            return menuCollection;
        }

	 protected SqlCommand CreateParameters(Menu Menu)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.FormName);
            p.Value = Menu.FormName;

            p = cmd.Parameters.Add(Parameters.MenuFiliationID);
            p.Value = Menu.MenuFiliationID;

            p = cmd.Parameters.Add(Parameters.MenuID);
            p.Value = Menu.MenuID;

            p = cmd.Parameters.Add(Parameters.MenuPosition);
            p.Value = Menu.MenuPosition;

            p = cmd.Parameters.Add(Parameters.MenuValue);
            p.Value = Menu.MenuValue;

            return cmd;
        }
     #region Parameters
     protected class Parameters
     {

         public static SqlParameter MenuID
         {
             get
             {
                 return new SqlParameter("@MenuID", SqlDbType.VarChar, 100);
             }
         }

         public static SqlParameter MenuPosition
         {
             get
             {
                 return new SqlParameter("@MenuPosition", SqlDbType.Int, 0);
             }
         }

         public static SqlParameter MenuValue
         {
             get
             {
                 return new SqlParameter("@MenuValue", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter MenuFiliationID
         {
             get
             {
                 return new SqlParameter("@MenuFiliationID", SqlDbType.VarChar, 100);
             }
         }

         public static SqlParameter FormName
         {
             get
             {
                 return new SqlParameter("@FormName", SqlDbType.VarChar, 100);
             }
         }

     }
     #endregion
		
	
	
    }
}
