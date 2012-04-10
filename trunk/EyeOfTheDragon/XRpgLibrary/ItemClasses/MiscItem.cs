using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class MiscItem : BaseItem
    {
        #region Field Region


        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public MiscItem(
                string itemName,
                string itemType,
                int price,
                int sellPrice)
            : base(itemName, itemType, price, sellPrice)
        {

        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {
            MiscItem item = new MiscItem(
                Name,
                Type,
                Price,
                SellPrice);

            return item;
        }

        public override string ToString()
        {
            string itemString = base.ToString();// +", ";

            return itemString;
        }

        #endregion
    }
}
