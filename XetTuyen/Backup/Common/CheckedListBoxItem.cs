using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CheckedListBoxItem
    {                    
        public string Text;
        public object Tag;

        // override ToString(); this
        // is what the checkbox control
        // displays as text
        public override string ToString()
        {
            return this.Text;
        }
    }
}
