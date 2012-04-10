using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public enum Hands { One, Two }

    public enum ArmorLocation { Body, Head, Hands, Feet }

    public abstract class BaseItem
    {
        #region Field Region

        string name;
        string type;
        int price;
        int sellPrice;

        #endregion

        #region Property Region

        public string Type
        {
            get { return type; }
            protected set { type = value; }
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public int Price
        {
            get { return price; }
            protected set { price = value; }
        }

        public int SellPrice
        {
            get { return sellPrice; }
            protected set { sellPrice = value; }
        }


        #endregion

        #region Constructor Region

        public BaseItem(string name, string type, int price, int sellPrice)
        {
            Name = name;
            Type = type;
            Price = price;
            SellPrice = sellPrice;
        }

        #endregion

        #region Abstract Method Region

        public abstract object Clone();

        public override string ToString()
        {
            string itemString = "";

            itemString += Name + ", ";
            itemString += type + ", ";
            itemString += Price.ToString() + ", ";
            itemString += SellPrice.ToString();

            return itemString;
        }

        #endregion
    }
}
