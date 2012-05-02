using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class FixedDamage : AttackEffect
    {
        #region Private Members
        int power;
        #endregion Private Members
        #region Constructors
        public FixedDamage(int damage, float effectPercentage)
            : base(effectPercentage)
        {
            power = damage;
        }

        public FixedDamage()
            : base(1f)
        {

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
            if (BattleCalculator.CalculateEffectiveness(attack.AttackElementType, target) != 0)
            {
                target.damage(power);
            }
        }

        public override string ToString()
        {
            string toString = "Fixed Damage";
            toString += ", " + power;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
