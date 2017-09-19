using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class TruongDHServices
    {
        public TruongDHServices() 
         { }
        public static bool Insert(TruongDH TruongDH)
        {
            TruongDHADO TruongDHADO = new TruongDHADO();
            
            return TruongDHADO.Insert(TruongDH);
        }
        public static Boolean Update(TruongDH TruongDH)
        {
            TruongDHADO TruongDHADO = new TruongDHADO();
            return TruongDHADO.Update(TruongDH);
        }
        public static bool Delete(string MaTruongDH, int nam)
        {
            TruongDHADO TruongDHADO = new TruongDHADO();
            return TruongDHADO.Delete(MaTruongDH, nam);
        }
        public static DataTable LoadByPrimaryKey(string MaTruongDH,int nam)
        {
            TruongDHADO TruongDHADO = new TruongDHADO();
            return TruongDHADO.LoadByPrimaryKey(MaTruongDH,nam);
        }
        public static DataTable LoaAll()
        {
            TruongDHADO TruongDHADO = new TruongDHADO();
            return TruongDHADO.LoadAll();
        }
      
        public static DataTable FindTruongDH(string sql)
        {

            TruongDHADO TruongDHADO = new TruongDHADO();
            return TruongDHADO.FinTruongDH(sql);
        }
    }
}
