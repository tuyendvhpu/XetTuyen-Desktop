using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class DoiTuongUTServices
    {
        public DoiTuongUTServices() 
         { }
        public static bool Insert(DoiTuongUT DoiTuongUT)
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            
            return DoiTuongUTADO.Insert(DoiTuongUT);
        }
        public static Boolean Update(DoiTuongUT DoiTuongUT)
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.Update(DoiTuongUT);
        }
        public static bool Delete(string MaDoiTuongUT)
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.Delete(MaDoiTuongUT);
        }
        public static DataTable LoadByPrimaryKey(string MaDoiTuongUT)
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.LoadByPrimaryKey(MaDoiTuongUT);
        }
        public static DataTable LoaAll()
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.LoadAll();
        }
        public static DoiTuongUT GetDoiTuongByID(string maDT)
        {
            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.GetDoiTuongByID(maDT);
        }
      
        public static DataTable FindDoiTuongUT(string sql)
        {

            DoiTuongUTADO DoiTuongUTADO = new DoiTuongUTADO();
            return DoiTuongUTADO.FinDoiTuongUT(sql);
        }
    }
}
