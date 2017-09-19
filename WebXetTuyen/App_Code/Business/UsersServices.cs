using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class UsersServices
    {
        public UsersServices() 
         { }
        public static bool Insert(Users Users)
        {
            UsersADO UsersADO = new UsersADO();
            
            return UsersADO.Insert(Users);
        }
        public static Boolean Update(Users Users)
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.Update(Users);
        }
        public static bool Delete(string MaUsers)
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.Delete(MaUsers);
        }
        public static DataTable LoadByPrimaryKey(string MaUsers)
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.LoadByPrimaryKey(MaUsers);
        }
        public static DataTable LoaAll()
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.LoadAll();
        }
      
        public static DataTable FindUsers(string sql)
        {

            UsersADO UsersADO = new UsersADO();
            return UsersADO.FinUsers(sql);
        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        public static   UserCollection GetListUser(){
            UsersADO UsersADO = new UsersADO();
            return UsersADO.GetListUser();
        }

          /// <summary>
        /// GetUserByID
        /// </summary>
        /// <param name="sLoginID"></param>
        /// <returns>Users object class</returns>
        public static Users GetUserByID(string sLoginID) {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.GetUserByID(sLoginID);
        }
        
        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public static bool UpdatePassword(Users objUser) {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.UpdatePassword(objUser);
        }
        /// <summary>
        /// Check Login user
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <param name="sPassword">Password</param>
        /// <param name="status">Status of this User</param>
        /// <returns></returns>
        public static Users CheckUser(string sLoginID, string sPassword, ref UserStatus status)
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.CheckUser(sLoginID,sPassword, ref status);
        }
        public static bool IsAdminUser(string sLoginID)
        {
            UsersADO UsersADO = new UsersADO();
            return UsersADO.IsAdminUser(sLoginID);
        }
    }
}
