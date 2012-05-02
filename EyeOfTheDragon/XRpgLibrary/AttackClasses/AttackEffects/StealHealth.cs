using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class StealHealth : AttackEffect
    {
        #region Private Members
        float health;
        int power;
        #endregion Private Members
        #region Constructors
        public StealHealth(int damage, float effectPercentage, float healthPercentage)
            : base(effectPercentage)
        {
            health = healthPercentage;
            power = damage;
        }

        public StealHealth()
            : base(1f)
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        public float Health
        {
            get { return health; }
            set { health = value; }
        }

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
            int damage = BattleCalculator.CalculateDamage(user, target, attack, power);
            target.damage(damage);
            user.heal((int) (damage * health));
        }

        public override string ToString()
        {
            string toString = "Steal Health";
            toString += ", " + power;
            toString += ", " + health;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
