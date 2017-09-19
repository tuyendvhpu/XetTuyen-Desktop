using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodDescriptionAttribute : System.Attribute
    {        
        private string _title;
        private string _description;
        private ModuleType _moduleType;     

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ModuleType ModuleType
        {
            get { return _moduleType; }
            set { _moduleType = value; }
        }

        public MethodDescriptionAttribute(ModuleType moduleType, string sTitle, string sDescription)
        {
            this.ModuleType = moduleType;
            this.Title = sTitle;
            this.Description = sDescription;
        }
    }
}
