using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class NhomNganhServices
    {
        public NhomNganhServices() 
         { }
        public static bool Insert(NhomNganh NhomNganh)
        {
            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            
            return NhomNganhADO.Insert(NhomNganh);
        }
        public static Boolean Update(NhomNganh NhomNganh)
        {
            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            return NhomNganhADO.Update(NhomNganh);
        }
        public static bool Delete(string MaNhomNganh)
        {
            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            return NhomNganhADO.Delete(MaNhomNganh);
        }
        public static DataTable LoadByPrimaryKey(string MaNhomNganh)
        {
            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            return NhomNganhADO.LoadByPrimaryKey(MaNhomNganh);
        }
        public static DataTable LoaAll()
        {
            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            return NhomNganhADO.LoadAll();
        }
      
        public static DataTable FindNhomNganh(string sql)
        {

            NhomNganhADO NhomNganhADO = new NhomNganhADO();
            return NhomNganhADO.FinNhomNganh(sql);
        }
    }
}
