using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class MonXTServices
    {
        public MonXTServices() 
         { }
        public static bool Insert(MonXT MonXT)
        {
            MonXTADO MonXTADO = new MonXTADO();
            
            return MonXTADO.Insert(MonXT);
        }
        public static Boolean Update(MonXT MonXT)
        {
            MonXTADO MonXTADO = new MonXTADO();
            return MonXTADO.Update(MonXT);
        }
        public static bool Delete(string MaMonXT)
        {
            MonXTADO MonXTADO = new MonXTADO();
            return MonXTADO.Delete(MaMonXT);
        }
        public static DataTable LoadByPrimaryKey(string MaMonXT)
        {
            MonXTADO MonXTADO = new MonXTADO();
            return MonXTADO.LoadByPrimaryKey(MaMonXT);
        }
        public static DataTable LoaAll()
        {
            MonXTADO MonXTADO = new MonXTADO();
            return MonXTADO.LoadAll();
        }
      
        public static DataTable FindMonXT(string sql)
        {

            MonXTADO MonXTADO = new MonXTADO();
            return MonXTADO.FinMonXT(sql);
        }
    }
}
