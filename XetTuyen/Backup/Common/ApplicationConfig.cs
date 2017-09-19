using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using BusinessService;
using DataAccess;
using Common;
namespace Common

{
    [Serializable()]
    public class ApplicationConfig
    {
        public string sDBServer;
        public string sDBDatabase;
        public string sDBUserName;
        public bool bDBTrustedConnection;

        private string m_sDBPassword;

        public string sDBPassword
        {
            get
            {
                return Utilities.decryptString(m_sDBPassword);
            }

            set
            {
                m_sDBPassword = Utilities.encryptString(value);
            }
        }

        public ApplicationConfig()
        {
            // 
            // TODO: Add constructor logic here
            //
        }
    }
}