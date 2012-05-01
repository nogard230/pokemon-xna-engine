using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;
using XRpgLibrary.AttackClasses;

namespace XRpgLibrary
{
    public enum ElementType { Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel };

    public class BattleCalculator
    {

        static public int CalculateDamage(Pokemon user, Pokemon target, Attack attackUsed, int basePower)
        {
            int attack = 0;
            int defense = 0;
            int level = user.Level;
            float stab = BattleCalculator.CalculateSTAB(attackUsed.AttackElementType, user);
            int effective = BattleCalculator.CalculateEffectiveness(attackUsed.AttackElementType, target);

            double r = (new Random().Next(85, 101)) / 100.0;
            int critical = BattleCalculator.CalculateCritical(user);
            int other = BattleCalculator.CalculateOtherModifier();
            double modifier = stab * effective * critical * other * r;

            if (attackUsed.AttackType == AttackType.Physical)
            {
                attack = user.AttackStat;
                defense = target.DefenseStat;
            }

            if (attackUsed.AttackType == AttackType.Special)
            {
                attack = user.SpecialAttackStat;
                defense = target.SpecialDefenseStat;
            }

            int totalDamage = (int)((((2 * user.Level + 10) / 250.0) * (attack / (double) defense) * basePower + 2) * modifier);

            return totalDamage;
        }

        private static int CalculateCritical(Pokemon user)
        {
            if (isCritical(user))
            {
                //Abilities that modify critical hits?

                return 2;
            }
            return 1;
        }

        private static int CalculateOtherModifier()
        {
            return 1;
        }

        private static bool isCritical(Pokemon user)
        {
            double r = new Random().Next(0, 101) / 100.0;
            if (r <= user.CriticalStage)
                return true;
            return false;
        }

        static public float CalculateSTAB(ElementType attackType, Pokemon user)
        {
            float stab = 1;

            if (user.isType(attackType))
            {
                stab = 1.5f;
            }

            return stab;
        }

        static public int CalculateEffectiveness(ElementType attackType, Pokemon target)
        {
            int effectiveness = 1;

            switch (attackType)
            {
                case (ElementType.Normal):
                    if (target.isType(ElementType.Rock))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness = 0;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Fire):
                    if (target.isType(ElementType.Fire))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Water))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ice))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Bug))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Dragon))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness *= 2;
                    break;

                case (ElementType.Water):
                    if (target.isType(ElementType.Fire))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Water))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Dragon))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Electric):
                    if (target.isType(ElementType.Water))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Electric))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness = 0;
                    if (target.isType(ElementType.Flying))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Dragon))
                        effectiveness /= 2;
                    break;

                case (ElementType.Grass):
                    if (target.isType(ElementType.Fire))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Water))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Bug))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Dragon))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Ice):
                    if (target.isType(ElementType.Fire))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Water))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ice))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Dragon))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Fighting):
                    if (target.isType(ElementType.Normal))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ice))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Psychic))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Bug))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness = 0;
                    if (target.isType(ElementType.Dark))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness *= 2;
                    break;

                case (ElementType.Poison):
                    if (target.isType(ElementType.Grass))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness = 0;
                    break;

                case (ElementType.Ground):
                    if (target.isType(ElementType.Fire))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Electric))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness = 0;
                    if (target.isType(ElementType.Bug))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness *= 2;
                    break;

                case (ElementType.Flying):
                    if (target.isType(ElementType.Electric))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Fighting))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Bug))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Psychic):
                    if (target.isType(ElementType.Fighting))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Psychic))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Dark))
                        effectiveness = 0;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Bug):
                    if (target.isType(ElementType.Fire))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Grass))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Fighting))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Poison))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Psychic))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Dark))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Rock):
                    if (target.isType(ElementType.Fire))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ice))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Fighting))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ground))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Flying))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Bug))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Ghost):
                    if (target.isType(ElementType.Normal))
                        effectiveness = 0;
                    if (target.isType(ElementType.Psychic))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Dark))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Dragon):
                    if (target.isType(ElementType.Dragon))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Dark):
                    if (target.isType(ElementType.Fighting))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Psychic))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Ghost))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Dark))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

                case (ElementType.Steel):
                    if (target.isType(ElementType.Fire))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Water))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Electric))
                        effectiveness /= 2;
                    if (target.isType(ElementType.Ice))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Rock))
                        effectiveness *= 2;
                    if (target.isType(ElementType.Steel))
                        effectiveness /= 2;
                    break;

            }

            return effectiveness;
        }
    }
}
