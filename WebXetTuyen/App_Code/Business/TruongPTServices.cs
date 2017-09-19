using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Business;
using System.Collections;
using System.Data;

namespace Business
{
    public class TruongPTServices
    {
        public TruongPTServices()
        { }
        public static bool Insert(TruongPT TruongPT)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();

            return TruongPTADO.Insert(TruongPT);
        }
        public static Boolean Update(TruongPT TruongPT)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.Update(TruongPT);
        }
        public static bool Delete(string MaTruongPT, string MaTinh, int Nam)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.Delete(MaTruongPT, MaTinh, Nam);
        }
        public static DataTable LoadByPrimaryKey(string MaTruongPT, int Nam)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.LoadByPrimaryKey(MaTruongPT, Nam);
        }
        public static DataTable LoadByMaTinh(string MaTinh, int Nam)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.LoadByMaTinh(MaTinh, Nam);
        }
        public static DataTable LoadByPrimaryKey(string MaTruongPT, string MaTinh, int Nam)
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.LoadByPrimaryKey(MaTruongPT, MaTinh, Nam);
        }
        public static DataTable LoaAll()
        {
            TruongPTADO TruongPTADO = new TruongPTADO();
        return TruongPTADO.LoadAll();
        }

        public static DataTable FindTruongPT(string sql)
        {

            TruongPTADO TruongPTADO = new TruongPTADO();
            return TruongPTADO.FinTruongPT(sql);
        }
    }
}
