using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class NganhServices
    {
        public NganhServices() 
         { }
        public static bool Insert(Nganh Nganh)
        {
            NganhADO NganhADO = new NganhADO();

            return NganhADO.Insert(Nganh);
        }
        public static Boolean Update(Nganh Nganh)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.Update(Nganh);
        }
        public static bool Delete(string IDNganh,int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.Delete(IDNganh,Nam);
        }
        public static bool Delete(string IDNganh, string MaKhoi,int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.Delete(IDNganh, MaKhoi,Nam);
        }
        public static DataTable LoadByPrimaryKey(string IDNganh, string MaKhoi, int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadByPrimaryKey(IDNganh, MaKhoi, Nam); 
        }
        public static DataTable LoadGroupIDNganh(int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadGroupIDNganh(Nam);
        }
        public static DataTable LoadByIDNganh(string IDNganh,int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadIDNganh(IDNganh,Nam);
        }
        public static DataTable LoadByMaNganh(string MaNganh, int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadByMaNganh(MaNganh, Nam);
        }
        public static DataTable LoadNganh(string MaNganh, int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadNganh(MaNganh, Nam);
        }
        public static DataTable LoadKhoiByNganh(string MaNganh, int Nam)
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadKhoiByNganh(MaNganh, Nam);
        }
        public static DataTable LoaAll()
        {
            NganhADO NganhADO = new NganhADO();
            return NganhADO.LoadAll();
        }
      
        public static DataTable FindNganh(string sql)
        {

            NganhADO NganhADO = new NganhADO();
            return NganhADO.FinNganh(sql);
        }
    }
}
