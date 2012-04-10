using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class TMItemData
    {
        public string Name;
        public string Type;
        public int Price;
        public int SellPrice;
        public string MoveTaught;

        public TMItemData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += SellPrice.ToString() + ", ";
            toString += MoveTaught.ToString();

            return toString;
        }
    }
}
