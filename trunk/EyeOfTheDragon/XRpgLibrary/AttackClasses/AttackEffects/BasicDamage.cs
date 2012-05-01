using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class BasicDamage : AttackEffect
    {
        public BasicDamage(int damage, float effectPercentage)
            : base(damage, effectPercentage)
        {

        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            target.damage(BattleCalculator.CalculateDamage(user, target, attack, power));
        }
    }
}
