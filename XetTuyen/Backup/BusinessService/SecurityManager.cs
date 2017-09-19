using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
using BusinessLogic;
using Common;

namespace BusinessService
{
    public class SecurityManager
    {
        private static AuthorizationsService authorizationBS;
        private static bool _isDebugMode = false;       
        public static bool IsDebugMode
        {
            get { return _isDebugMode; }
            set { _isDebugMode = value; }
        }

        private static System.Collections.Specialized.StringCollection AssembliesToVerify
        {
            get
            {
                
                System.Collections.Hashtable hash = (System.Collections.Hashtable)System.Configuration.ConfigurationManager.GetSection("security");
                System.Collections.Specialized.StringCollection mCol = new System.Collections.Specialized.StringCollection();
                foreach (string key in hash.Keys)
                    if (bool.Parse(hash[key].ToString()))
                        mCol.Add(key);
                return mCol;
            }
        }

        /// <summary>
        /// CheckAllAssemblies
        /// </summary>
        public static bool CheckAllAssemblies()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {                
                authorizationBS = new AuthorizationsService();
                foreach (string sAss in AssembliesToVerify)
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.Load(sAss);
                    CheckAssemblyAutorization(ass, db);
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
        /// CheckAllAssemblies
        /// </summary>
        public static bool CheckAllAssemblies(ModulesCollection moduleCollection)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                //1. Update Modules
                ModuleService moduleBS = new ModuleService();
                foreach (Modules objModule in moduleCollection)
                {
                    moduleBS.InsertOrUpdate(db,objModule);
                }

                //2. Update Authorization
                authorizationBS = new AuthorizationsService();
                foreach (string sAss in AssembliesToVerify)
                {
                    System.Reflection.Assembly ass = System.Reflection.Assembly.Load(sAss);
                    CheckAssemblyAutorization(ass, db);
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
        /// CheckAssemblyAutorization
        /// </summary>
        /// <param name="ass"></param>
        public static void CheckAssemblyAutorization(System.Reflection.Assembly ass, DbAccess db)
        {
            foreach (Type t in ass.GetTypes())
            {                
                CheckAuthorizations(t, db);             
            }
        }

        /// <summary>
        /// CheckAuthorizations
        /// </summary>
        /// <param name="t"></param>
        private static void CheckAuthorizations(Type t, DbAccess db)
        {
            if ((t.GetCustomAttributes(typeof(AuthorizationAttribute), true).Length == 0)) return;
            foreach (System.Reflection.MemberInfo memInfo in t.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                object[] objBrowse = memInfo.GetCustomAttributes(typeof(MethodBrowsableAttribute), true);
                if (objBrowse.Length > 0 && !((MethodBrowsableAttribute)objBrowse[0]).Browsable) continue;
                

                object[] objMethods = memInfo.GetCustomAttributes(typeof(MethodDescriptionAttribute), true);
                if (objMethods.Length > 0)
                {
                    MethodDescriptionAttribute descriptionAttribute = (MethodDescriptionAttribute)objMethods[0];                    
                    Authorizations objAuthorization = authorizationBS.GetAuthorization(memInfo, descriptionAttribute);
                    
                    try
                    {
                        authorizationBS.AddOrUpdate(objAuthorization, db);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Check invoked method is authorized for login user
        /// </summary>
        /// <param name="methodBase">invoked method</param>
        /// <returns></returns>
        public static bool IsAuthorized(System.Reflection.MethodBase methodBase)
        {
            if (clsCommon.IsAdminUser)
                return true;
            else
            {
                AuthorizationsService authorizationBS = new AuthorizationsService();

                //clsGroupAuthorizationCollection groupAuthorizationCollection = new clsGroupAuthorizationBS().GetGroupAuthorizationCollectionByUserID(clsCommonBS.CurrentUser.UserName.ToLower());
                foreach (GroupAuthorization objGroupAuthorization in GroupAuthorizationService.AuthorizationCollectionOfCurrentUser)/*groupAuthorizationCollection)*/
                {
                    if (objGroupAuthorization.Authorization.MethodFullName == authorizationBS.GetMethodFullName(methodBase))
                        return true;
                }

                return false;
            }
        }                 
    }
}
