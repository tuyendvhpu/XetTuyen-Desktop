using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class DanTocServices
    {
        public DanTocServices() 
         { }
        public static bool Insert(DanToc DanToc)
        {
            DanTocADO DanTocADO = new DanTocADO();
            
            return DanTocADO.Insert(DanToc);
        }
        public static Boolean Update(DanToc DanToc)
        {
            DanTocADO DanTocADO = new DanTocADO();
            return DanTocADO.Update(DanToc);
        }
        public static bool Delete(string MaDanToc)
        {
            DanTocADO DanTocADO = new DanTocADO();
            return DanTocADO.Delete(MaDanToc);
        }
        public static DataTable LoadByPrimaryKey(string MaDanToc)
        {
            DanTocADO DanTocADO = new DanTocADO();
            return DanTocADO.LoadByPrimaryKey(MaDanToc);
        }
        public static DataTable LoaAll()
        {
            DanTocADO DanTocADO = new DanTocADO();
            return DanTocADO.LoadAll();
        }
      
        public static DataTable FindDanToc(string sql)
        {

            DanTocADO DanTocADO = new DanTocADO();
            return DanTocADO.FinDanToc(sql);
        }
    }
}
