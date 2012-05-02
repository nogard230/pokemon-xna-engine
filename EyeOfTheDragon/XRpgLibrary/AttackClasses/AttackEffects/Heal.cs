using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class Heal : AttackEffect
    {
        float heal;
        public Heal(float healPercentage, float effectPercentage)
            : base(0, effectPercentage)
        {
            heal = healPercentage;
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            user.heal((int) (user.CurrentHP.MaximumValue * heal));
        }
    }
}
