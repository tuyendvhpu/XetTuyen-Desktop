using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class NhomUTServices
    {
        public NhomUTServices() 
         { }
        public static bool Insert(NhomUT NhomUT)
        {
            NhomUTADO NhomUTADO = new NhomUTADO();
            
            return NhomUTADO.Insert(NhomUT);
        }
        public static Boolean Update(NhomUT NhomUT)
        {
            NhomUTADO NhomUTADO = new NhomUTADO();
            return NhomUTADO.Update(NhomUT);
        }
        public static bool Delete(string MaNhomUT)
        {
            NhomUTADO NhomUTADO = new NhomUTADO();
            return NhomUTADO.Delete(MaNhomUT);
        }
        public static DataTable LoadByPrimaryKey(string MaNhomUT)
        {
            NhomUTADO NhomUTADO = new NhomUTADO();
            return NhomUTADO.LoadByPrimaryKey(MaNhomUT);
        }
        public static DataTable LoaAll()
        {
            NhomUTADO NhomUTADO = new NhomUTADO();
            return NhomUTADO.LoadAll();
        }
      
        public static DataTable FindNhomUT(string sql)
        {

            NhomUTADO NhomUTADO = new NhomUTADO();
            return NhomUTADO.FinNhomUT(sql);
        }
    }
}
