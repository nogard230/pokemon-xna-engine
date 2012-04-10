using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.ItemClasses;

namespace RpgLibrary.ItemClasses
{
    public class BerryItem : BaseItem
    {
        #region Field Region


        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public BerryItem(
                string berryName,
                string berryType,
                int price,
                int sellPrice)
            : base(berryName, berryType, price, sellPrice)
        {

        }

        public BerryItem(BerryItemData data)
            : base(data.Name, data.Type, data.Price, data.SellPrice)
        {

        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {

            BerryItem berryItem = new BerryItem(
                Name,
                Type,
                Price,
                SellPrice);

            return berryItem;
        }

        public override string ToString()
        {
            string berryString = base.ToString();

            return berryString;
        }

        #endregion
    }
}
