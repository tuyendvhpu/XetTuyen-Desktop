using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class NganhXetTuyenServices
    {
        public NganhXetTuyenServices() 
         { }
        public static bool Insert(NganhXetTuyen NganhXetTuyen)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            
            return NganhXetTuyenADO.Insert(NganhXetTuyen);
        }
        public static Boolean Update(NganhXetTuyen NganhXetTuyen)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Update(NganhXetTuyen);
        }
        public static Boolean UpdateDiemTB(Int64 IDHS,  string makhoi, string madot, int nam, string IDNganh,float diemTB, int heso)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.UpdateDiemTB( IDHS,   makhoi,  madot,  nam,  IDNganh, diemTB,heso);
        }

        public static bool Delete(Int64 idHS, string manganh,  string makhoi, int nam, string IDNganh, string madot)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Delete(idHS, manganh, makhoi, madot, nam, IDNganh);
        }

        public static bool DeleteByIdHS(Int64 idHS,  int nam,string madot)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Delete(idHS, madot, nam);
        }
        public static bool DeleteByIdHS(Int64 idHS, int nam)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Delete(idHS, nam);
        }
        public static bool DeleteByNganh(string manganh, int nam, string IDNganh, string madot)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Delete(manganh, madot, nam,IDNganh);
        }

        public static bool DeleteByMaNganh(string manganh, int nam, string IDNganh, string madot)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.Delete(manganh, madot, nam);
        }

        public static DataTable LoadByIdHS(Int64 idHS,string madot, int nam)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadByIDHS(idHS,madot, nam);
        }
        public static DataTable LoadByIdHS(Int64 idHS)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadByIDHS(idHS);
        }
        public static DataTable LoadByNganh(string manganh, int nam,  string madot)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadByNganh(manganh, madot, nam);
        }
        public static DataTable LoadMonXetTuyen(long idHS, int nam)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadMonXetTuyen(idHS, nam);
        }
        public static DataTable LoadByIDNganh(string manganh, int nam, string madot,string IDNganh)
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadByIDNganh(manganh,IDNganh, madot, nam);
        }
        public static DataTable LoaAll()
        {
            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.LoadAll();
        }
      
        public static DataTable FindNganhXetTuyen(string sql)
        {

            NganhXetTuyenADO NganhXetTuyenADO = new NganhXetTuyenADO();
            return NganhXetTuyenADO.FinNganhXetTuyen(sql);
        }
    }
}
