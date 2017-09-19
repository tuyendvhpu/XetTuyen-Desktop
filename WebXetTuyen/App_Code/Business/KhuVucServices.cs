using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class KhuVucServices
    {
        public KhuVucServices() 
         { }
        public static bool Insert(KhuVuc KhuVuc)
        {
            KhuVucADO KhuVucADO = new KhuVucADO();
            
            return KhuVucADO.Insert(KhuVuc);
        }
        public static Boolean Update(KhuVuc KhuVuc)
        {
            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.Update(KhuVuc);
        }
        public static bool Delete(string MaKhuVuc)
        {
            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.Delete(MaKhuVuc);
        }
        public static DataTable LoadByPrimaryKey(string MaKhuVuc)
        {
            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.LoadByPrimaryKey(MaKhuVuc);
        }
        public static DataTable LoaAll()
        {
            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.LoadAll();
        }
        public static KhuVuc GetKhuVucByID(string maKV)
        {

            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.GetKhuVucByID(maKV);
        }
    
        public static DataTable FindKhuVuc(string sql)
        {

            KhuVucADO KhuVucADO = new KhuVucADO();
            return KhuVucADO.FinKhuVuc(sql);
        }
    }
}
