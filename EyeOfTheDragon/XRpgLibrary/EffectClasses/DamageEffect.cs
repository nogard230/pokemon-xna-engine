﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.CharacterClasses;

namespace RpgLibrary.EffectClasses
{
    public class DamageEffect : BaseEffect
    {
        #region Field Region

        DamageType damageType;
        //AttackType attackType;
        DieType dieType;
        int numberOfDice;
        int modifier;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        private DamageEffect()
        {
        }

        #endregion

        #region Method Region

        public static DamageEffect FromDamageEffectData(DamageEffectData data)
        {
            DamageEffect effect = new DamageEffect();

            effect.damageType = data.DamageType;
            //effect.attackType = data.AttackType;
            effect.dieType = data.DieType;
            effect.numberOfDice = data.NumberOfDice;
            effect.modifier = data.Modifier;

            return effect;
        }

        #endregion

        #region Virtual Method Region

        public override void Apply(Entity entity)
        {
            int amount = modifier;

            for (int i = 0; i < numberOfDice; i++)
                amount += Mechanics.RollDie(dieType);

            foreach (Weakness weakness in entity.Weaknesses)
                if (weakness.WeaknessType == damageType)
                    amount = weakness.Apply(amount);

            foreach (Resistance resistance in entity.Resistances)
                if (resistance.ResistanceType == damageType)
                    amount = resistance.Apply(amount);

            if (amount < 1)
                amount = 1;

            //switch (attackType)
            //{
            //    case AttackType.Health:
            //        entity.Health.Damage((ushort)amount);
            //        break;
            //    case AttackType.Mana:
            //        entity.Mana.Damage((ushort)amount);
            //        break;
            //    case AttackType.Stamina:
            //        entity.Stamina.Damage((ushort)amount);
            //        break;
            //}
        }

        #endregion
    }
}
