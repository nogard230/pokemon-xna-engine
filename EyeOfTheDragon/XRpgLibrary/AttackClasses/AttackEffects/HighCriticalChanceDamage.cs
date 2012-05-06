using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class HighCriticalChanceDamage : AttackEffect
    {
        #region Protected Members
        protected int power;
        #endregion Protected Members

        #region Constructors
        public HighCriticalChanceDamage(int damage, float effectPercentage)
            : base(effectPercentage)
        {
            power = damage;
        }

        public HighCriticalChanceDamage()
            : base(1f)
        {
            power = 0;
        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the power.
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        #endregion Public Attributes

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            user.modifyStatStage(Stat.Critical, 1);
            target.damage(BattleCalculator.CalculateDamage(user, target, attack, power));
            user.modifyStatStage(Stat.Critical, -1);
        }

        public override string ToString()
        {
            string toString = "High Critical Chance Damage Damage";
            toString += ", " + power;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
