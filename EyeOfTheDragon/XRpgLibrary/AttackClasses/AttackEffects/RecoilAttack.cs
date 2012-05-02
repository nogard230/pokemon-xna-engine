using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class RecoilAttack : AttackEffect
    {
        #region Private Members
        float recoil;
        int power;
        #endregion Private Members
        #region Constructors
        public RecoilAttack(int damage, float effectPercentage, float recoilPercentage)
            : base(effectPercentage)
        {
            recoil = recoilPercentage;
            power = damage;
        }

        public RecoilAttack()
            : base(1f)
        {

        }
        #endregion Constructors

        #region Public Attributes
        /// <summary>
        /// Gets or sets the recoil.
        /// </summary>
        public float Recoil
        {
            get { return recoil; }
            set { recoil = value; }
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
            user.damage((int) (damage * recoil));
        }

        public override string ToString()
        {
            string toString = "Recoil Attack";
            toString += ", " + power;
            toString += ", " + recoil;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
