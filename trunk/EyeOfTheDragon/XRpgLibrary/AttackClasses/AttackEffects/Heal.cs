using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class Heal : AttackEffect
    {
        #region Private Members
        float heal;
        #endregion Private Members
        #region Constructors
        public Heal(float healPercentage, float effectPercentage)
            : base(effectPercentage)
        {
            heal = healPercentage;
        }

        public Heal()
            : base(1f)
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the heal.
        /// </summary>
        public float HealPercent
        {
            get { return heal; }
            set { heal = value; }
        }
        #endregion Public Attributes

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            user.heal((int) (user.CurrentHP.MaximumValue * heal));
        }

        public override string ToString()
        {
            string toString = "Heal";
            toString += ", " + heal;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
