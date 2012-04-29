using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses
{
    abstract class AttackEffect
    {
        protected int power;
        protected float effectPercentage;

        public AttackEffect(int p, float effectP)
        {
            power = p;
            effectPercentage = effectP;
        }

        public abstract void ApplyEffect(Pokemon user, Pokemon target, Attack attack);

    }
}
