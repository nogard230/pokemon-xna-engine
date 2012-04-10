using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class KeyItemData
    {
        #region Field Region

        public string Name;
        public string Type;
        
        #endregion

        #region Constructor Region

        public KeyItemData()
        {
        }

        #endregion

        #region Method Region

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type;

            return toString;
        }
        
        #endregion
    }
}
