using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class RecoilAttack : AttackEffect
    {
        float recoil;
        public RecoilAttack(int damage, float effectPercentage, float recoilPercentage)
            : base(damage, effectPercentage)
        {
            recoil = recoilPercentage;
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            int damage = BattleCalculator.CalculateDamage(user, target, attack, power);
            target.damage(damage);
            user.damage((int) (damage * recoil));
        }
    }
}
