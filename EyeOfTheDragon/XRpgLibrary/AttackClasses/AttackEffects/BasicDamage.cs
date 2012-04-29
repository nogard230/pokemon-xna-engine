using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    class BasicDamage : AttackEffect
    {
        public BasicDamage(int damage, float effectPErcentage)
            : base(damage, effectPErcentage)
        {

        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            target.damage(BattleCalculator.CalculateDamage(user, target, attack, power));
        }
    }
}
