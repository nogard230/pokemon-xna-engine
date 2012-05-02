using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class FixedDamage : AttackEffect
    {
        public FixedDamage(int damage, float effectPercentage)
            : base(damage, effectPercentage)
        {
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            if (BattleCalculator.CalculateEffectiveness(attack.AttackElementType, target) != 0)
            {
                target.damage(power);
            }
        }
    }
}
