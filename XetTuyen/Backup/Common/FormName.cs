using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class FormName
    {                
        #region "Authorization"
        public const string GROUP = "Danh mục nhóm người dùng";
        public const string USER_GROUP = "Danh mục nhóm người dùng - người dùng";
        public const string AUTHORIZATION = "Phân quyền";
        public const string USER = "Danh mục người dùng";
        public const string HISTORY = "Lịch sử người dùng";
        #endregion   
    
        #region "Catalogue"
        public const string DotXetTuyen = "Danh mục đợt xét tuyển";
        public const string HoSo = "Danh mục hồ sơ xét tuyển";
        public const string NganhXetTuyen = "Danh mục ngành xét tuyển";
        public const string DiemXetTuyen = "Danh mục điểm xét tuyển";
        #endregion    
        #region "Processing"
        public const string CongThuc = "Lập công thức xét tuyển";
        public const string DieuKien = "Điều kiện xét tuyển";
        public const string XetTuyenHS = "Xét tuyển hồ sơ";
        public const string TTXetTuyen = "Thông tin xét tuyển";
        #endregion   
        #region "Statistic"
        public const string InGiayBao = "In giấy báo nhập học";

        #endregion   
    }

    public class FunctionName
    {                                
        #region "Security"
        public const string SC_GotoMultilanguageScreen = "Di chuyển đến màn hình đa ngôn ngữ";
        public const string SC_MultilanguageData = "Đa ngôn ngữ dữ liệu";

        //User
        public const string SC_AddUser = "Thêm 1 Người Dùng";
        public const string SC_EditUser = "Sửa 1 Người Dùng";
        public const string SC_DeleteUser = "Xóa 1 Người Dùng";

        //Group
        public const string SC_AddGroup = "Thêm 1 Nhóm Người Dùng";
        public const string SC_EditGroup = "Sửa 1 Nhóm Người Dùng";
        public const string SC_DeleteGroup = "Xóa 1 Nhóm Người Dùng";

        //User-Group
        public const string SC_AddOrDeleteUserInGroup = "Thêm Hoặc Xóa Người Dùng Trong Nhóm";

        //Authorization
        public const string SC_AddOrEditAuthorization = "Thêm Hoặc Sửa Các Quyền";

        //GroupAuthorization
        public const string SC_AddOrDeleteGroupAuthorization = "Thêm Hoặc Xóa Quyền Nhóm Người Dùng";
    
        //History
        public const string SC_DeleteAudid = "Xóa lịch sử người dùng";

        #endregion
        #region "Catalogue"

        //DotXetTuyen
        public const string  Cat_AddDotXetTuyen = "Thêm đợt xét tuyển";
        public const string Cat_EditDotXetTuyen = "Sửa đợt xét tuyển";
        public const string Cat_DeleteDotXetTuyen = "Xóa đợt xét tuyển";

        //HoSo
        public const string Cat_AddHoSo = "Thêm đợt hồ sơ xét tuyển";
        public const string Cat_EditHoSo = "Sửa hồ sơ xét tuyển";
        public const string Cat_DeleteHoSo = "Xóa hồ sơ xét tuyển";
        //DiemXetTuyen
        public const string Cat_AddDienXetTuyen = "Thêm điểm xét tuyển";
        public const string Cat_EditDienXetTuyen = "Sửa điểm xét tuyển";
        public const string Cat_DeleteDienXetTuyen = "Xóa điểm xét tuyển";
        //NganhXetTuyen
        public const string Cat_AddNganhXetTuyen = "Thêm ngành xét tuyển";
        public const string Cat_EditNganhXetTuyen = "Sửa ngành xét tuyển";
        public const string Cat_DeleteNganhXetTuyen = "Xóa ngành xét tuyển";
        #endregion
        #region "Processing"
        //CongThuc
        public const string Proc_AddCongThuc = "Thêm hệ số công thức";
        public const string Proc_EditCongThuc = "Sửa hệ số công thức";
        public const string Proc_DeleteConThuc = "Xóa hệ số công thức";
        //DieuKienXT
        public const string Proc_AddDieuKien= "Thêm điều kiện";
        public const string Proc_EditDieuKien = "Sửa điều kiện";
        public const string Proc_DeleteDieuKien = "Xóa điều kiện";

        //XetTuyen
        public const string Proc_AddXetTuyen = "Xét tuyển";
        
        //TTXetTuyen
        public const string Proc_ViewdTTXetTuyen = "Xem Thông tin xét tuyển";
        #endregion

        #region "Statistic"
        //Giay bao

        public const string Stat_InGiayBao = "In giấy báo nhập học";
        #endregion

    }
}
