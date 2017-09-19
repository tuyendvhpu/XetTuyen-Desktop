using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class MethodBrowsableAttribute : System.Attribute
    {
        private bool m_Browsable;

        public MethodBrowsableAttribute() { }
        public MethodBrowsableAttribute(bool browsable)
        {
            this.m_Browsable = browsable;
        }

        public bool Browsable
        {
            get { return m_Browsable; }
        }
    }    
}
