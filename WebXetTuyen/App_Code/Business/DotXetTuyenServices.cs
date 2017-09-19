using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
  public   class DotXetTuyenServices
    {
        public DotXetTuyenServices() 
         { }
        public static bool Insert(DotXetTuyen DotXetTuyen)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            
            return DotXetTuyenADO.Insert(DotXetTuyen);
        }
        public static Boolean Update(DotXetTuyen DotXetTuyen)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.Update(DotXetTuyen);
        }
        public static bool Delete(string MaDotXetTuyen)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.Delete(MaDotXetTuyen);
        }
        public static DataTable LoadByPrimaryKey(string MaDotXetTuyen,int nam)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.LoadByPrimaryKey(MaDotXetTuyen,nam);
        }
        public static DataTable LoadByNam(int nam)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.LoadByNam( nam);
        }
        public static DataTable LoadByDate(DateTime ngay)
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.LoadByDate(ngay);
        }
        public static DataTable LoaAll()
        {
            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.LoadAll();
        }
      
        public static DataTable FindDotXetTuyen(string sql)
        {

            DotXetTuyenADO DotXetTuyenADO = new DotXetTuyenADO();
            return DotXetTuyenADO.FinDotXetTuyen(sql);
        }
    }
}
