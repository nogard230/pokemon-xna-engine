using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class MiscItemData
    {
        public string Name;
        public string Type;
        public int Price;
        public int SellPrice;

        public MiscItemData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += SellPrice.ToString();

            return toString;
        }
    }
}
