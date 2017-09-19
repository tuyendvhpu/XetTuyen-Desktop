using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class KhoiThiServices
    {
        public KhoiThiServices() 
         { }
        public static bool Insert(KhoiThi KhoiThi)
        {
            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            
            return KhoiThiADO.Insert(KhoiThi);
        }
        public static Boolean Update(KhoiThi KhoiThi)
        {
            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            return KhoiThiADO.Update(KhoiThi);
        }
        public static bool Delete(string MaKhoiThi)
        {
            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            return KhoiThiADO.Delete(MaKhoiThi);
        }
        public static DataTable LoadByPrimaryKey(string MaKhoiThi,int nam)
        {
            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            return KhoiThiADO.LoadByPrimaryKey(MaKhoiThi,nam);
        }
        public static DataTable LoaAll()
        {
            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            return KhoiThiADO.LoadAll();
        }
      
        public static DataTable FindKhoiThi(string sql)
        {

            KhoiThiADO KhoiThiADO = new KhoiThiADO();
            return KhoiThiADO.FinKhoiThi(sql);
        }
    }
}
