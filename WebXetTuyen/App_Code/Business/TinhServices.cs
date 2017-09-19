using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class TinhServices
    {
        public TinhServices() 
         { }
        public static bool Insert(Tinh Tinh)
        {
            TinhADO TinhADO = new TinhADO();
            
            return TinhADO.Insert(Tinh);
        }
        public static Boolean Update(Tinh Tinh)
        {
            TinhADO TinhADO = new TinhADO();
            return TinhADO.Update(Tinh);
        }
        public static bool Delete(string MaTinh)
        {
            TinhADO TinhADO = new TinhADO();
            return TinhADO.Delete(MaTinh);
        }
        public static DataTable LoadByPrimaryKey(string MaTinh)
        {
            TinhADO TinhADO = new TinhADO();
            return TinhADO.LoadByPrimaryKey(MaTinh);
        }
        public static DataTable LoaAll()
        {
            TinhADO TinhADO = new TinhADO();
            return TinhADO.LoadAll();
        }
      
        public static DataTable FindTinh(string sql)
        {

            TinhADO TinhADO = new TinhADO();
            return TinhADO.FinTinh(sql);
        }
    }
}
