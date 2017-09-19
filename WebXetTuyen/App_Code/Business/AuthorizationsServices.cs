using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class AuthorizationsServices
    {
        public AuthorizationsServices() 
         { }
        public static bool Insert(Authorizations Authorizations)
        {
            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            
            return AuthorizationsADO.Insert(Authorizations);
        }
        public static Boolean Update(Authorizations Authorizations)
        {
            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            return AuthorizationsADO.Update(Authorizations);
        }
        public static bool Delete(Guid authorizationID)
        {
            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            return AuthorizationsADO.Delete(authorizationID);
        }
        public static DataTable LoadByPrimaryKey(Guid authorizationID)
        {
            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            return AuthorizationsADO.LoadByPrimaryKey(authorizationID);
        }
        public static DataTable LoaAll()
        {
            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            return AuthorizationsADO.LoadAll();
        }
      
        public static DataTable FindAuthorizations(string sql)
        {

            AuthorizationsADO AuthorizationsADO = new AuthorizationsADO();
            return AuthorizationsADO.FinAuthorizations(sql);
        }
    }
}
