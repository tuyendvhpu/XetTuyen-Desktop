using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public enum ModuleType
    {        
        Administration = 0,
        Catalogue = 1,
        Processing = 2,        
        Statistic = 3
    }

    public class GetModuleTypeName
    {
        public static string GetString(ModuleType type)
        {
            switch (type)
            {
                case ModuleType.Administration: return "Quản Trị Hệ thống";//you can get this text from somewhere like DB, XML files, ...
                case ModuleType.Catalogue: return "Danh Mục";
                case ModuleType.Processing: return "Xử Lý Nghiệp Vụ";                
                case ModuleType.Statistic: return "Báo Cáo - Thống Kê";                
            }
            return string.Empty;
        }        
    }
}
