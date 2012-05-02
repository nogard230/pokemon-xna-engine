using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class StealHealth : AttackEffect
    {
        float health;
        public StealHealth(int damage, float effectPercentage, float healthPercentage)
            : base(damage, effectPercentage)
        {
            health = healthPercentage;
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            int damage = BattleCalculator.CalculateDamage(user, target, attack, power);
            target.damage(damage);
            user.heal((int) (damage * health));
        }
    }
}
