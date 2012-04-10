using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class KeyItem : BaseItem
    {
        #region Field region
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public KeyItem(string name, string type)
            : base(name, type, 0, 0)
        {
        }

        public KeyItem(KeyItemData data)
            : base(data.Name, data.Type, 0, 0)
        {
        }

        #endregion

        #region Virtual Method Region

        public override object Clone()
        {
            KeyItem key = new KeyItem(this.Name, this.Type);

            return key;
        }

        #endregion
    }
}
