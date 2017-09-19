using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class CongThucServices
    {
        public CongThucServices() 
         { }
        public static bool Insert(CongThuc CongThuc)
        {
            CongThucADO CongThucADO = new CongThucADO();
            
            return CongThucADO.Insert(CongThuc);
        }
        public static Boolean Update(CongThuc CongThuc)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.Update(CongThuc);
        }
        public static bool Delete(string manganh, string MaMon, string makhoi, int nam, string IDNganh, string madot)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.Delete(manganh, MaMon, makhoi, nam, IDNganh, madot);
        }

        public static bool DeleteByKhoi(string makhoi, int nam, string madot)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.DeleteByKhoi(makhoi, nam, madot);
        }

        public static bool DeleteByNganh(string manganh, int nam, string IDNganh, string madot)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.DeleteByNganh(manganh, nam, IDNganh, madot);
        }

        public static bool DeleteByMaNganh(string manganh, int nam, string madot)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.DeleteByMaNganh(manganh, nam, madot);    
        }

        public static DataTable LoadyKey(string manganh, string madot, string makhoi, int nam, string IDNganh)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.LoadyKey(manganh, madot, makhoi, nam, IDNganh);
        }
        public static DataTable LoaAll()
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.LoadAll();
        }
      
        public static DataTable FindCongThuc(string sql)
        {

            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.FinCongThuc(sql);
        }
        public static DataTable GetCongThucNam_Dot_Khoi(int nam, string madot, string makhoi)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.GetCongThucNam_Dot_Khoi(nam,madot,makhoi);
        }
        public static DataTable GetCongThucNam_Dot_Khoi_Nganh(int nam, string madot, string manganh, string makhoi)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.GetCongThucNam_Dot_Khoi_Nganh(nam,madot,manganh,makhoi);
        }
        public static DataTable GetCongThucNam_Dot_MaNganh(int nam, string madot, string manganh)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.GetCongThucNam_Dot_MaNganh(nam, madot, manganh);
        }
        public static DataTable GetCongThucNam_Dot_IdNganh(int nam, string madot, string IDNganh)
        {
            CongThucADO CongThucADO = new CongThucADO();
            return CongThucADO.GetCongThucNam_Dot_IdNganh(nam, madot, IDNganh);
        }
    }
}
