using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary.BattleClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class ModifyStat : AttackEffect
    {
        #region Private Members
        Stat stat;
        int modifyAmount;
        bool modifySelf;
        #endregion Private Members

        #region Constructors
        public ModifyStat(Stat statModified, int amount, bool selfModify, float effectPercentage)
            : base(effectPercentage)
        {
            stat = statModified;
            modifyAmount = amount;
            modifySelf = selfModify;
        }

        public ModifyStat()
            : base(1f)
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the stat.
        /// </summary>
        public Stat Stat
        {
            get { return stat; }
            set { stat = value; }
        }

        /// <summary>
        /// Gets or sets the modifyamount.
        /// </summary>
        public int ModifyAmount
        {
            get { return modifyAmount; }
            set { modifyAmount = value; }
        }

        /// <summary>
        /// Gets or sets the modifyself.
        /// </summary>
        public bool ModifySelf
        {
            get { return modifySelf; }
            set { modifySelf = value; }
        }
        #endregion Public Attributes

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            if (modifySelf)
            {
                user.modifyStatStage(stat, modifyAmount);
            }
            else
            {
                target.modifyStatStage(stat, modifyAmount);
            }
        }

        public override string ToString()
        {
            string toString = "Modify Stat";
            toString += ", " + stat.ToString();
            toString += ", " + modifyAmount;
            toString += ", " + modifySelf;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
