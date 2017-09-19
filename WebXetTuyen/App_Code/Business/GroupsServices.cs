using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class GroupsServices
    {
        public GroupsServices() 
         { }
        public static bool Insert(Groups Groups)
        {
            GroupsADO GroupsADO = new GroupsADO();
            
            return GroupsADO.Insert(Groups);
        }
        public static Boolean Update(Groups Groups)
        {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.Update(Groups);
        }
        public static bool Delete(Guid GroupID)
        {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.Delete(GroupID);
        }
        public static DataTable LoadByPrimaryKey(Guid GroupID)
        {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.LoadByPrimaryKey(GroupID);
        }
        public static DataTable LoaAll()
        {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.LoadAll();
        }
      
        public static DataTable FindGroups(string sql)
        {

            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.FinGroups(sql);
        }
         /// <summary>
        /// GetListGroup
        /// </summary>
        /// <returns></returns>
        public static GroupCollection GetListGroup()
        {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.GetListGroup();
        }
          /// <summary>
        ///GetGroupByID
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns>Groups object class</returns>
        public Groups GetGroupByID(Guid GroupID) {
            GroupsADO GroupsADO = new GroupsADO();
            return GroupsADO.GetGroupByID(GroupID);
        }
    }
}
