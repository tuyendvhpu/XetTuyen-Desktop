using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using BusinessService;
using DataAccess;
using Common;
namespace DataAccess
{
    [Authorization]
     class AudidService
     {
         public enum AudidAction { Insert, Update, Delete }

         public bool IsAuthorized(AudidAction action)
         {
             string sMethodName = string.Empty;
             switch (action)
             {
                 //case AudidAction.Insert:
                 //    sMethodName = "Insert";
                 //    break;
                 //case AudidAction.Update:
                 //    sMethodName = "Update";
                 //    break;
                 case AudidAction.Delete:
                     sMethodName = "Delete";
                     break;
                 //case GroupAction.MultilangUI:
                 //    sMethodName = "MultilangUI";
                 //    break;
                 //case GroupAction.MultilangData:
                 //    sMethodName = "MultilangData";
                 //    break;
             }

             return SecurityManager.IsAuthorized(typeof(AudidService).GetMethod(sMethodName));
         }

         
         public void AdidDiemXetTuyen(DiemXetTuyen objDiemXTOld, DiemXetTuyen objDiemXTNew, string logInID, string action)
         {
             Audid objAudid = new Audid();
             objAudid.TableName = "t_DiemXetTuyen";
             objAudid.Action = action;
             objAudid.ChangedBy = logInID;
             objAudid.ChangedDate = DateTime.Now.Date;

             objAudid.RowID = objDiemXTOld.Idhs.ToString() + "_" + objDiemXTOld.MaMon.ToString();

             if (objDiemXTOld.Diem!= objDiemXTNew.Diem)
             {
                 objAudid.ColumnName = "Diem";
                 objAudid.OldValue = objDiemXTOld.Diem.ToString();
                 objAudid.NewValue = objDiemXTNew.Diem.ToString();
                 this.Insert(objAudid);
             }
             
         }
         public void AdidNganhXetTuyen(NganhXetTuyen objNganhXTOld, NganhXetTuyen objNganhXTNew, string logInID, string action)
         {
             Audid objAudid = new Audid();
             objAudid.TableName = "t_NganhXetTuyen";
             objAudid.Action = action;
             objAudid.ChangedBy = logInID;
             objAudid.ChangedDate = DateTime.Now.Date;

             objAudid.RowID = objNganhXTOld.Idhs.ToString();

             if(objNganhXTOld.DiemTB!=objNganhXTNew.DiemTB){
                 objAudid.ColumnName = "DiemTB";
                 objAudid.OldValue = objNganhXTOld.DiemTB.ToString();
                 objAudid.NewValue = objNganhXTNew.DiemTB.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.DiemTXT != objNganhXTNew.DiemTXT)
             {
                 objAudid.ColumnName = "DiemTXT";
                 objAudid.OldValue = objNganhXTOld.DiemTXT.ToString();
                 objAudid.NewValue = objNganhXTNew.DiemTXT.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.DiemUTDT != objNganhXTNew.DiemUTDT)
             {
                 objAudid.ColumnName = "DiemUTDT";
                 objAudid.OldValue = objNganhXTOld.DiemUTDT.ToString();
                 objAudid.NewValue = objNganhXTNew.DiemUTDT.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.DiemUTKV != objNganhXTNew.DiemUTKV)
             {
                 objAudid.ColumnName = "DiemUTKV";
                 objAudid.OldValue = objNganhXTOld.DiemUTKV.ToString();
                 objAudid.NewValue = objNganhXTNew.DiemUTKV.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.IDNganh != objNganhXTNew.IDNganh)
             {
                 objAudid.ColumnName = "IDNganh";
                 objAudid.OldValue = objNganhXTOld.IDNganh.ToString();
                 objAudid.NewValue = objNganhXTNew.IDNganh.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.MaDot != objNganhXTNew.MaDot)
             {
                 objAudid.ColumnName = "MaDot";
                 objAudid.OldValue = objNganhXTOld.MaDot.ToString();
                 objAudid.NewValue = objNganhXTNew.MaDot.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.MaKhoi != objNganhXTNew.MaKhoi)
             {
                 objAudid.ColumnName = "MaKhoi";
                 objAudid.OldValue = objNganhXTOld.MaKhoi.ToString();
                 objAudid.NewValue = objNganhXTNew.MaKhoi.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.MaNganh != objNganhXTNew.MaNganh)
             {
                 objAudid.ColumnName = "MaNganh";
                 objAudid.OldValue = objNganhXTOld.MaNganh.ToString();
                 objAudid.NewValue = objNganhXTNew.MaNganh.ToString();
                 this.Insert(objAudid);
             }
             if (objNganhXTOld.Nam != objNganhXTNew.Nam)
             {
                 objAudid.ColumnName = "Nam";
                 objAudid.OldValue = objNganhXTOld.Nam.ToString();
                 objAudid.NewValue = objNganhXTNew.Nam.ToString();
                 this.Insert(objAudid);
             }
         }
         public void AdidHoSo(HoSo objHoSoOld, HoSo objHoSoNew, string logInID, string action)
         {
             Audid objAudid = new Audid();
             objAudid.TableName = "t_HoSo";
             objAudid.Action = action;
             objAudid.ChangedBy = logInID;
             objAudid.ChangedDate = DateTime.Now.Date;

             objAudid.RowID = objHoSoOld.Idhs.ToString();



             if (objHoSoOld.HoTen != objHoSoNew.HoTen)
             {
                 objAudid.ColumnName = "HoTen";
                 objAudid.OldValue = objHoSoOld.HoTen;
                 objAudid.NewValue = objHoSoNew.HoTen;
                 this.Insert(objAudid);
                 
             }

             if (objHoSoOld.DanToc != objHoSoNew.DanToc)
             {
                 objAudid.ColumnName = "DanToc";
                 objAudid.OldValue = objHoSoOld.DanToc;
                 objAudid.NewValue = objHoSoNew.DanToc;
                 this.Insert(objAudid);
             }

             if (objHoSoOld.HoKhau != objHoSoNew.HoKhau)
             {
                 objAudid.ColumnName = "HoKhau";
                 objAudid.OldValue = objHoSoOld.HoKhau;
                 objAudid.NewValue = objHoSoNew.HoKhau;
                 this.Insert(objAudid);
             }
                 if (objHoSoOld.DiaChi != objHoSoNew.DiaChi)
                 {
                     objAudid.ColumnName = "DiaChi";
                     objAudid.OldValue = objHoSoOld.DiaChi;
                     objAudid.NewValue = objHoSoNew.DiaChi;
                     this.Insert(objAudid);
                 }
             if (objHoSoOld.DienThoai != objHoSoNew.DienThoai)
             {
                 objAudid.ColumnName = "DienThoai";
                 objAudid.OldValue = objHoSoOld.DienThoai;
                 objAudid.NewValue = objHoSoNew.DienThoai;
                 this.Insert(objAudid);
             }

             if (objHoSoOld.Email != objHoSoNew.Email)
             {
                 objAudid.ColumnName = "Email";
                 objAudid.OldValue = objHoSoOld.Email;
                 objAudid.NewValue = objHoSoNew.Email;
                 this.Insert(objAudid);
             }
             
             if (objHoSoOld.Lop10 != objHoSoNew.Lop10)
             {
                 objAudid.ColumnName = "Lop10";
                 objAudid.OldValue = objHoSoOld.Lop10;
                 objAudid.NewValue = objHoSoNew.Lop10;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.Lop10MaTinh != objHoSoNew.Lop10MaTinh)
             {
                 objAudid.ColumnName = "Lop10MaTinh";
                 objAudid.OldValue = objHoSoOld.Lop10MaTinh;
                 objAudid.NewValue = objHoSoNew.Lop10MaTinh;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.Lop10MaTruong != objHoSoNew.Lop10MaTruong)
             {
                 objAudid.ColumnName = "Lop10MaTruong";
                 objAudid.OldValue = objHoSoOld.Lop10MaTruong;
                 objAudid.NewValue = objHoSoNew.Lop10MaTruong;
                 this.Insert(objAudid);

             }

             if (objHoSoOld.Lop11 != objHoSoNew.Lop11)
             {
                 objAudid.ColumnName = "Lop11";
                 objAudid.OldValue = objHoSoOld.Lop11;
                 objAudid.NewValue = objHoSoNew.Lop11;
                 this.Insert(objAudid);

             }
             if (objHoSoOld.Lop11MaTinh != objHoSoNew.Lop11MaTinh)
             {
                 objAudid.ColumnName = "Lop11MaTinh";
                 objAudid.OldValue = objHoSoOld.Lop11MaTinh;
                 objAudid.NewValue = objHoSoNew.Lop11MaTinh;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.Lop11MaTruong != objHoSoNew.Lop11MaTruong)
             {
                 objAudid.ColumnName = "Lop11MaTruong";
                 objAudid.OldValue = objHoSoOld.Lop11MaTruong;
                 objAudid.NewValue = objHoSoNew.Lop11MaTruong;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.Lop12 != objHoSoNew.Lop12)
             {
                 objAudid.ColumnName = "Lop12";
                 objAudid.OldValue = objHoSoOld.Lop12;
                 objAudid.NewValue = objHoSoNew.Lop12;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.Lop12MaTinh != objHoSoNew.Lop12MaTinh)
             {
                 objAudid.ColumnName = "Lop12MaTinh";
                 objAudid.OldValue = objHoSoOld.Lop12MaTinh;
                 objAudid.NewValue = objHoSoNew.Lop12MaTinh;
                 this.Insert(objAudid);

             }
             if (objHoSoOld.Lop12MaTruong != objHoSoNew.Lop12MaTruong)
             {
                 objAudid.ColumnName = "Lop12MaTruong";
                 objAudid.OldValue = objHoSoOld.Lop12MaTruong;
                 objAudid.NewValue = objHoSoNew.Lop12MaTruong;
                 this.Insert(objAudid);
             }

             if (objHoSoOld.MaDT != objHoSoNew.MaDT)
             {
                 objAudid.ColumnName = "MaDT";
                 objAudid.OldValue = objHoSoOld.MaDT;
                 objAudid.NewValue = objHoSoNew.MaDT;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.MaHS != objHoSoNew.MaHS)
             {
                 objAudid.ColumnName = "MaHS";
                 objAudid.OldValue = objHoSoOld.MaHS;
                 objAudid.NewValue = objHoSoNew.MaHS;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.MaHuyen != objHoSoNew.MaHuyen)
             {
                 objAudid.ColumnName = "MaHuyen";
                 objAudid.OldValue = objHoSoOld.MaHuyen;
                 objAudid.NewValue = objHoSoNew.MaHuyen;
                 this.Insert(objAudid);

             }
             if (objHoSoOld.MaKV != objHoSoNew.MaKV)
             {
                 objAudid.ColumnName = "MaKV";
                 objAudid.OldValue = objHoSoOld.MaKV;
                 objAudid.NewValue = objHoSoNew.MaKV;
                 this.Insert(objAudid);

             }
             if (objHoSoOld.MaTinh != objHoSoNew.MaTinh)
             {
                 objAudid.ColumnName = "MaTinh";
                 objAudid.OldValue = objHoSoOld.MaTinh;
                 objAudid.NewValue = objHoSoNew.MaTinh;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.SoBaoDanh != objHoSoNew.SoBaoDanh)
             {
                 objAudid.ColumnName = "SoBaoDanh";
                 objAudid.OldValue = objHoSoOld.SoBaoDanh;
                 objAudid.NewValue = objHoSoNew.SoBaoDanh;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.SoCMTND != objHoSoNew.SoCMTND)
             {
                 objAudid.ColumnName = "SoCMTND";
                 objAudid.OldValue = objHoSoOld.SoCMTND;
                 objAudid.NewValue = objHoSoNew.SoCMTND;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NamTotNghiep != objHoSoNew.NamTotNghiep)
             {
                 objAudid.ColumnName = "NamTotNghiep";
                 objAudid.OldValue = objHoSoOld.NamTotNghiep.ToString();
                 objAudid.NewValue = objHoSoNew.NamTotNghiep.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NgaySinh != objHoSoNew.NgaySinh)
             {
                 objAudid.ColumnName = "NgaySinh";
                 objAudid.OldValue = objHoSoOld.NgaySinh.ToString("dd/MM/yyyy");
                 objAudid.NewValue = objHoSoNew.NgaySinh.ToString("dd/MM/yyyy");
                 this.Insert(objAudid);
             }
             if (objHoSoOld.TruongDT != objHoSoNew.TruongDT)
             {
                 objAudid.ColumnName = "TruongDT";
                 objAudid.OldValue = objHoSoOld.TruongDT;
                 objAudid.NewValue = objHoSoNew.TruongDT;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.HanhKiem != objHoSoNew.HanhKiem)
             {
                 objAudid.ColumnName = "HanhKiem";
                 objAudid.OldValue = objHoSoOld.HanhKiem;
                 objAudid.NewValue = objHoSoNew.HanhKiem;
                 this.Insert(objAudid);
             }
             if (objHoSoOld.HinhThuc != objHoSoNew.HinhThuc)
             {
                 objAudid.ColumnName = "HinhThuc";
                 objAudid.OldValue = objHoSoOld.HinhThuc.ToString();
                 objAudid.NewValue = objHoSoNew.HinhThuc.ToString();
                 this.Insert(objAudid);
             }

             if (objHoSoOld.GioiTinh != objHoSoNew.GioiTinh)
             {
                 objAudid.ColumnName = "GioiTinh";
                 objAudid.OldValue = objHoSoOld.GioiTinh.ToString();
                 objAudid.NewValue = objHoSoNew.GioiTinh.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NopLePhi != objHoSoNew.NopLePhi)
             {
                 objAudid.ColumnName = "NopLePhi";
                 objAudid.OldValue = objHoSoOld.NopLePhi.ToString();
                 objAudid.NewValue = objHoSoNew.NopLePhi.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.KhoiDT != objHoSoNew.KhoiDT)
             {
                 objAudid.ColumnName = "KhoiDT";
                 objAudid.OldValue = objHoSoOld.KhoiDT.ToString();
                 objAudid.NewValue = objHoSoNew.KhoiDT.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NgayNhap != objHoSoNew.NgayNhap)
             {
                 objAudid.ColumnName = "NgayNhap";
                 objAudid.OldValue = objHoSoOld.NgayNhap.ToString();
                 objAudid.NewValue = objHoSoNew.NgayNhap.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NgaySua != objHoSoNew.NgaySua)
             {
                 objAudid.ColumnName = "NgaySua";
                 objAudid.OldValue = objHoSoOld.NgaySua.ToString();
                 objAudid.NewValue = objHoSoNew.NgaySua.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NguoiNhap != objHoSoNew.NguoiNhap)
             {
                 objAudid.ColumnName = "NguoiNhap";
                 objAudid.OldValue = objHoSoOld.NguoiNhap.ToString();
                 objAudid.NewValue = objHoSoNew.NguoiNhap.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.NguoiSua != objHoSoNew.NguoiSua)
             {
                 objAudid.ColumnName = "NguoiSua";
                 objAudid.OldValue = objHoSoOld.NguoiSua.ToString();
                 objAudid.NewValue = objHoSoNew.NguoiSua.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.SoBaoDanh != objHoSoNew.SoBaoDanh)
             {
                 objAudid.ColumnName = "SoBaoDanh";
                 objAudid.OldValue = objHoSoOld.SoBaoDanh.ToString();
                 objAudid.NewValue = objHoSoNew.SoBaoDanh.ToString();
                 this.Insert(objAudid);
             }
             if (objHoSoOld.SoCMTND != objHoSoNew.SoCMTND)
             {
                 objAudid.ColumnName = "SoCMTND";
                 objAudid.OldValue = objHoSoOld.SoCMTND.ToString();
                 objAudid.NewValue = objHoSoNew.SoCMTND.ToString();
                 this.Insert(objAudid);
             }
         }

         public AudidService()
        {
        }
      

            public  bool Insert(Audid Audid) {
            SqlCommand cmd = CreateParameters(Audid);
            cmd.CommandText = "[proc_t_AudidInsert]";
           
            cmd.Connection = DbConnection.SqlConnection;
            DbConnection.Open();
            int i = cmd.ExecuteNonQuery();
            DbConnection.Close();
            if (i != 0) return true;
            return false;
            
        }
       
       
       
        public DataTable LoadAll()
        {

             DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("[proc_t_AudidLoadAll]", DbConnection.SqlConnection);
            DbConnection.Open();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();

           
            return dataTable;
        }
        public DataTable FinAudid(string sql) {
             DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConnection.SqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DbConnection.Open();
            dataAdapter.Fill(dataTable);
            DbConnection.Close();
            return dataTable;
        }

        [MethodDescription(ModuleType.Administration, FormName.HISTORY, FunctionName.SC_DeleteAudid)]
        public bool Delete(Audid audid)
        {

            DbAccess db = new DbAccess();

            try
            {
                SqlCommand cmd = CreateParameters(audid);
                cmd.CommandText = "[proc_t_AudidDelete]";

                cmd.Connection = DbConnection.SqlConnection;
                DbConnection.Open();
                int i = cmd.ExecuteNonQuery();
                DbConnection.Close();
                if (i != 0) return true;
                return false;

                
            }
            catch
            {

                return false;
            }


        }
       
	 protected SqlCommand CreateParameters(Audid Audid)
        {
            SqlParameter p;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            // Add params

            p = cmd.Parameters.Add(Parameters.Changed_By);
            p.Value = Audid.ChangedBy;

            p = cmd.Parameters.Add(Parameters.Row_ID);
            p.Value = Audid.RowID;


            p = cmd.Parameters.Add(Parameters.TableName);
            p.Value = Audid.TableName;

            p = cmd.Parameters.Add(Parameters.Changed_Date);
            p.Value = Audid.ChangedDate;

            p = cmd.Parameters.Add(Parameters.ColumnName);
            p.Value = Audid.ColumnName;

            

            p = cmd.Parameters.Add(Parameters.New_Value);
            p.Value = Audid.NewValue;

            p = cmd.Parameters.Add(Parameters.Old_Value);
            p.Value = Audid.OldValue;

            p = cmd.Parameters.Add(Parameters.Action);
            p.Value = Audid.Action;


            return cmd;
        }
     #region Parameters
     protected class Parameters
     {


         public static SqlParameter TableName
         {
             get
             {
                 return new SqlParameter("@TableName", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter ColumnName
         {
             get
             {
                 return new SqlParameter("@ColumnName", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter Row_ID
         {
             get
             {
                 return new SqlParameter("@Row_ID", SqlDbType.NVarChar, 50);
             }
         }

         public static SqlParameter Changed_Date
         {
             get
             {
                 return new SqlParameter("@Changed_Date", SqlDbType.Date, 30);
             }
         }

         public static SqlParameter Changed_By
         {
             get
             {
                 return new SqlParameter("@Changed_By", SqlDbType.VarChar, 50);
             }
         }

         public static SqlParameter Old_Value
         {
             get
             {
                 return new SqlParameter("@Old_Value", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter New_Value
         {
             get
             {
                 return new SqlParameter("@New_Value", SqlDbType.NVarChar, 1073741823);
             }
         }

         public static SqlParameter Action
         {
             get
             {
                 return new SqlParameter("@Action", SqlDbType.NVarChar, 50);
             }
         }
			

     }
     #endregion
	
    }
}
