using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class TMItem : BaseItem
    {
        #region Field Region

        string moveTaught;

        #endregion

        #region Property Region

        public string MoveTaught
        {
            get { return moveTaught; }
            protected set { moveTaught = value; }
        }

        #endregion

        #region Constructor Region

        public TMItem(
                string TMName,
                string TMType,
                int price,
                int sellPrice,
                string moveTaught)
            : base(TMName, TMType, price, sellPrice)
        {
            MoveTaught = moveTaught;
        }

        #endregion

        #region Abstract Method Region

        public override object Clone()
        {

            TMItem tmItem = new TMItem(
                Name,
                Type,
                Price,
                SellPrice,
                MoveTaught);

            return tmItem;
        }

        public override string ToString()
        {
            string tmString = base.ToString() + ", ";
            tmString += MoveTaught.ToString();

            return tmString;
        }

        #endregion
    }
}
