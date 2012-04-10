using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.EffectClasses;

namespace RpgLibrary.ItemClasses
{
    public class RecoveryItemData
    {
        public string Name;
        public string Type;
        public int Price;
        public int SellPrice;
        public int HealValue;
        public float HealPercentage;
        public bool CanRevive;
        public int LevelsGained;
        public int PPRestoreValue;
        public int MovesRestored;
        public StatusType StatusCured;
        public bool CureAllStatuses;

        public RecoveryItemData()
        {
        }

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += SellPrice.ToString() + ", ";
            toString += HealValue.ToString() + ", ";
            toString += HealPercentage.ToString() + ", ";
            toString += CanRevive.ToString() + ", ";
            toString += LevelsGained.ToString() + ", ";
            toString += PPRestoreValue.ToString() + ", ";
            toString += MovesRestored.ToString() + ", ";
            toString += StatusCured.ToString() + ", ";
            toString += CureAllStatuses.ToString();

            return toString;
        }
    }
}
