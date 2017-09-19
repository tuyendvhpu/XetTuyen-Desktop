using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class DiemXetTuyenServices
    {
        public DiemXetTuyenServices() 
         { }
        public static bool Insert(DiemXetTuyen DiemXetTuyen)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            
            return DiemXetTuyenADO.Insert(DiemXetTuyen);
        }
        public static Boolean Update(DiemXetTuyen DiemXetTuyen)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.Update(DiemXetTuyen);
        }
        public static bool Delete(Int64 idHS, int mamon, string makhoi)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.Delete(idHS, mamon,makhoi);
        }
        public static bool Delete(Int64 idHS)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.Delete(idHS);
        }
        public static DataTable LoadByIdHS(Int64 idHS)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.LoadByIdHS(idHS);
        }

        public static DataTable LoadByByMaKhoiMaNganh(Int64 idHS, string manganh, int mamon, string makhoi, string madot, int nam, string idNganh)
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.LoadByByMaKhoiMaNganh(idHS, manganh, mamon, makhoi, madot, nam, idNganh);
        }
        public static DataTable LoaAll()
        {
            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.LoadAll();
        }
      
        public static DataTable FindDiemXetTuyen(string sql)
        {

            DiemXetTuyenADO DiemXetTuyenADO = new DiemXetTuyenADO();
            return DiemXetTuyenADO.FinDiemXetTuyen(sql);
        }
    }
}
