using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class HuyenServices
    {
        public HuyenServices() 
         { }
        public static bool Insert(Huyen Huyen)
        {
            HuyenADO HuyenADO = new HuyenADO();
            
            return HuyenADO.Insert(Huyen);
        }
        public static Boolean Update(Huyen Huyen)
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.Update(Huyen);
        }
        public static bool Delete(string MaHuyen)
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.Delete(MaHuyen);
        }
        public static DataTable LoadByPrimaryKey(string MaHuyen)
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.LoadByPrimaryKey(MaHuyen);
        }
        public static DataTable LoadByMaTinh(string MaTinh)
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.LoadByMaTinh(MaTinh);
        }
        public static DataTable LoadByPrimaryKey(string MaHuyen, string MaTinh)
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.LoadByPrimaryKey(MaHuyen,MaTinh);
        }
        public static DataTable LoaAll()
        {
            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.LoadAll();
        }
      
        public static DataTable FindHuyen(string sql)
        {

            HuyenADO HuyenADO = new HuyenADO();
            return HuyenADO.FinHuyen(sql);
        }
    }
}
