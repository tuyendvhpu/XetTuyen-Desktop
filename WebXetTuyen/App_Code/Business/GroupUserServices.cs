using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class GroupUserServices
    {
        public GroupUserServices() 
         { }
        public static bool Insert(GroupUser GroupUser)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            
            return GroupUserADO.Insert(GroupUser);
        }

        public static bool Delete(Guid GroupID, string LoginID)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.Delete(GroupID,LoginID);
        }
        public static bool Delete(string LoginID)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.Delete(LoginID);
        }
        public static DataTable LoadByPrimaryKey(Guid GroupID, string LoginID)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.LoadByPrimaryKey(GroupID,LoginID);
        }
        public static DataTable LoaAll()
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.LoadAll();
        }
      
        public static DataTable FindGroupUser(string sql)
        {

            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.FinGroupUser(sql);
        }
         /// <summary>
        /// GetGroupUserByID
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        public static GroupUser GetGroupByID(Guid GroupID, string LoginID) {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.GetGroupByID( GroupID,LoginID) ;
        }

        // <summary>
        /// Get Group Collection By User ID
        /// </summary>
        /// <param name="sUserName">User Name</param>
        /// <returns>Group Collection</returns>
        public static GroupCollection GetGroupCollectionByUserID(string LoginID) {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.GetGroupCollectionByUserID(LoginID);
        }
        /// <summary>
        /// GetListGroupIdByUserAndLanguageID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Guid> GetListGroupIdByUserID(string sLoginID)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.GetListGroupIdByUserID(sLoginID);
        }
          /// <summary>
        /// GetListGroupIdByUserID
        /// </summary>
        /// <returns></returns>
        public static GroupUserCollection GetListGroupUserByUserID(string LoginID)
        {
            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.GetListGroupUserByUserID(LoginID);
        }
         
        public GroupUserCollection GetListGroup() {

            GroupUserADO GroupUserADO = new GroupUserADO();
            return GroupUserADO.GetListGroup();
        }
    }
}
