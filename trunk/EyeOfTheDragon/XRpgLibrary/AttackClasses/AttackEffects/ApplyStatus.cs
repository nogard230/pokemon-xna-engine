using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using RpgLibrary.EffectClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class ApplyStatus : AttackEffect
    {
        StatusType status;
        Pokemon pokemonAffected;

        public ApplyStatus(StatusType statusToApply, Pokemon appliedTo, float effectPercentage)
            : base(0, effectPercentage)
        {
            status = statusToApply;
            pokemonAffected = appliedTo;
        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            pokemonAffected.applyCondition(status);
        }
    }
}
