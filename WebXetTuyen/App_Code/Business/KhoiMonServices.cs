using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class KhoiMonServices
    {
        public KhoiMonServices() 
         { }
        public static bool Insert(KhoiMon KhoiMon)
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            
            return KhoiMonADO.Insert(KhoiMon);
        }
        public static Boolean Update(KhoiMon KhoiMon)
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.Update(KhoiMon);
        }
        public static bool Delete(int Nam,string MaKhoi)
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.Delete(Nam,MaKhoi);
        }
        public static DataTable LoadByPrimaryKey(int Nam, string MaKhoi)
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.LoadByPrimaryKey(Nam, MaKhoi);
        }
        public static DataTable LoadTenMonByPrimaryKey(int Nam, string MaKhoi)
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.LoadTenMonByPrimaryKey(Nam, MaKhoi);
        }
        public static DataTable LoaAll()
        {
            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.LoadAll();
        }
      
        public static DataTable FindKhoiMon(string sql)
        {

            KhoiMonADO KhoiMonADO = new KhoiMonADO();
            return KhoiMonADO.FinKhoiMon(sql);
        }
    }
}
