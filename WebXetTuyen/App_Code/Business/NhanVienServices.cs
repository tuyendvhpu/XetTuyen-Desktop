using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class NhanVienServices
    {
        public NhanVienServices() 
         { }
        public static bool Insert(NhanVien NhanVien)
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.Insert(NhanVien);
        }
        public static Boolean Update(NhanVien NhanVien)
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.Update(NhanVien);
        }
        public static bool Delete(int ID)
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.Delete(ID);
        }
        public static DataTable LoadByPrimaryKey(int ID)
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.LoadByPrimaryKey(ID);
        }
        public static DataTable LoaAll()
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.LoadAll();
        }
        public static DataTable LoadByUser(string taikhoan, string matkhau)
        {
            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.LoadByUser(taikhoan.Trim(),Utilities.encryptMD5String(matkhau));
        }
        public static DataTable FindNhanVien(string sql)
        {

            NhanVienADO NhanVienADO = new NhanVienADO();
            return NhanVienADO.FinNhanVien(sql);
        }
    }
}
