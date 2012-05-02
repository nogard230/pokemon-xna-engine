using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary.BattleClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class ModifyStat : AttackEffect
    {
        Stat stat;
        int modifyAmount;
        Pokemon pokemonModified;

        public ModifyStat(Stat statModified, int amount, Pokemon modified, float effectPercentage)
            : base(0, effectPercentage)
        {
            stat = statModified;
            modifyAmount = amount;
            pokemonModified = modified;
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            pokemonModified.modifyStatStage(stat, modifyAmount);
        }
    }
}
