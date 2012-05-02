using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses
{
    public abstract class AttackEffect
    {
        #region Protected Members
        protected int power;
        protected float effectPercentage;
        #endregion Protected Members

        #region Constructors
        public AttackEffect(int p, float effectP)
        {
            power = p;
            effectPercentage = effectP;
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

        /// <summary>
        /// Gets or sets the effectpercentage.
        /// </summary>
        public float EffectPercentage
        {
            get { return effectPercentage; }
            set { effectPercentage = value; }
        }
        #endregion Public Attributes

        public abstract void ApplyEffect(Pokemon user, Pokemon target, Attack attack);

    }
}
