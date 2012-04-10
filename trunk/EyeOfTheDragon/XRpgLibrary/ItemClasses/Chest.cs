using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.TrapClasses;

namespace RpgLibrary.ItemClasses
{
    public class Chest : BaseItem
    {
        #region Field Region

        ChestData chestData;

        #endregion

        #region Property Region

        public BaseItem Item
        {
            get
            {
                return chestData.Item;
            }
        }

        #endregion

        #region Constructor Region

        public Chest(ChestData data)
            : base(data.Name, "", 0, 0)
        {
            this.chestData = data;
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public override object Clone()
        {
            ChestData data = new ChestData();
            data.Name = chestData.Name;
            data.Item = chestData.Item;

            Chest chest = new Chest(data);
            return chest;
        }
        
        #endregion
    }
}
