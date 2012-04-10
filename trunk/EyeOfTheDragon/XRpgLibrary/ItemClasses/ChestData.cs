using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.SkillClasses;

namespace RpgLibrary.ItemClasses
{
    public class ChestData
    {
        public string Name;
        public string Item;

        public ChestData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Item.ToString();

            return toString;
        }
    }
}
